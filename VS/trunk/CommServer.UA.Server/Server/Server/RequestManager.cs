/* ========================================================================
 * Copyright (c) 2005-2010 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Reciprocal Community Binary License ("RCBL") Version 1.00
 * 
 * Unless explicitly acquired and licensed from Licensor under another 
 * license, the contents of this file are subject to the Reciprocal 
 * Community Binary License ("RCBL") Version 1.00, or subsequent versions 
 * as allowed by the RCBL, and You may not copy or use this file in either 
 * source code or executable form, except in compliance with the terms and 
 * conditions of the RCBL.
 * 
 * All software distributed under the RCBL is provided strictly on an 
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
 * AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT 
 * LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
 * PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the RCBL for specific 
 * language governing rights and limitations under the RCBL.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/RCBL/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Security.Principal;

namespace Opc.Ua.Server
{    
    /// <summary>
    /// An object that manages requests from within the server.
    /// </summary>
    public class RequestManager : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Initilizes the manager.
        /// </summary>
        /// <param name="server"></param>
        public RequestManager(IServerInternal server)
        {
            if (server == null) throw new ArgumentNullException("server");

            m_server       = server;
            m_requests     = new Dictionary<uint,OperationContext>();
            m_requestTimer = null;
        }
        #endregion
        
        #region IDisposable Members
        /// <summary>
        /// The finializer implementation.
        /// </summary>
        ~RequestManager() 
        {
            Dispose(false);
        }
        
        /// <summary>
        /// Frees any unmanaged resources.
        /// </summary>
        public void Dispose()
        {   
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "m_requestTimer")]
        protected virtual void Dispose(bool disposing)
        {  
            if (disposing)
            {
                List<OperationContext> operations = null;

                lock (m_lock)
                {
                    operations = new List<OperationContext>(m_requests.Values);
                    m_requests.Clear();
                }
                
                foreach (OperationContext operation in operations)
                {
                    operation.SetStatusCode(StatusCodes.BadSessionClosed);
                }

                Utils.SilentDispose(m_requestTimer);
                m_requestTimer = null;
            }            
        }
        #endregion

        #region Public Members
        /// <summary>
        /// Raised when the status of an outstanding request changes.
        /// </summary>
        public event RequestCancelledEventHandler RequestCancelled
        {
            add
            {
                lock (m_lock)
                {
                    m_RequestCancelled += value;
                }
            }

            remove
            {
                lock (m_lock)
                {
                    m_RequestCancelled -= value;
                }
            }
        }
        
        /// <summary>
        /// Called when a new request arrives.
        /// </summary>
        /// <param name="context"></param>
        public void RequestReceived(OperationContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            lock (m_requests)
            {
                m_requests.Add(context.RequestId, context);

                if (context.OperationDeadline < DateTime.MaxValue && m_requestTimer == null)
                {
                    m_requestTimer = new Timer(OnTimerExpired, null, 1000, 1000);
                }
            }
        }
        
        /// <summary>
        /// Called when a request completes (normally or abnormally).
        /// </summary>
        public void RequestCompleted(OperationContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            lock (m_requests)
            {      
                // find the completed request.
                bool deadlineExists = false;

                foreach (OperationContext request in m_requests.Values)
                {
                    if (request.RequestId == context.RequestId)
                    {
                        continue;
                    }

                    if (request.OperationDeadline < DateTime.MaxValue)
                    {
                        deadlineExists = true;
                    }
                }

                // check if the timer can be cancelled.
                if (m_requestTimer != null && !deadlineExists)
                {
                    m_requestTimer.Dispose();
                    m_requestTimer = null;
                }

                // remove the request.
                m_requests.Remove(context.RequestId);
            }
        }
        
        /// <summary>
        /// Called when the client wishes to cancel one or more requests.
        /// </summary>
        public void CancelRequests(uint requestHandle, out uint cancelCount)
        {
            List<uint> cancelledRequests = new List<uint>();

            // flag requests as cancelled.
            lock (m_requests)
            {      
                foreach (OperationContext request in m_requests.Values)
                {
                    if (request.ClientHandle == requestHandle)
                    {
                        request.SetStatusCode(StatusCodes.BadRequestCancelledByRequest);
                        cancelledRequests.Add(request.RequestId);
                    }
                }
            }

            // return the number of requests found.
            cancelCount = (uint)cancelledRequests.Count;

            // raise notifications.
            lock (m_lock)
            {   
                for (int ii = 0; ii < cancelledRequests.Count; ii++)
                {
                    if (m_RequestCancelled != null)
                    {
                        try
                        {
                            m_RequestCancelled(this, cancelledRequests[ii], StatusCodes.BadRequestCancelledByRequest);
                        }
                        catch (Exception e)
                        {
                            Utils.Trace(e, "Unexpected error reporting RequestCancelled event.");
                        }                        
                    }
                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Checks for any expired requests and changes their status.
        /// </summary>
        private void OnTimerExpired(object state)
        {
            List<uint> expiredRequests = new List<uint>();

            // flag requests as expired.
            lock (m_requests)
            {      
                foreach (OperationContext request in m_requests.Values)
                {
                    if (request.OperationDeadline < DateTime.UtcNow)
                    {
                        request.SetStatusCode(StatusCodes.BadTimeout);
                        expiredRequests.Add(request.RequestId);
                    }
                }
            }

            // raise notifications.
            lock (m_lock)
            {   
                for (int ii = 0; ii < expiredRequests.Count; ii++)
                {
                    if (m_RequestCancelled != null)
                    {
                        try
                        {
                            m_RequestCancelled(this, expiredRequests[ii], StatusCodes.BadTimeout);
                        }
                        catch (Exception e)
                        {
                            Utils.Trace(e, "Unexpected error reporting RequestCancelled event.");
                        }                        
                    }
                }
            }
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private IServerInternal m_server;
        private Dictionary<uint,OperationContext> m_requests;
        private Timer m_requestTimer;
        private event RequestCancelledEventHandler m_RequestCancelled;
        #endregion
    }
    
    /// <summary>
    /// Called when a request is cancelled.
    /// </summary>
    public delegate void RequestCancelledEventHandler(
        RequestManager source,
        uint           requestId,
        StatusCode     statusCode);
}
