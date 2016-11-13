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
using System.Collections;
using System.Diagnostics;
using System.Xml;
using System.Threading;

namespace Opc.Ua.Server 
{
    /// <summary>
    /// Stores the state of an asynchrounous publish operation.
    /// </summary>  
    public class AsyncPublishOperation
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPublishOperation"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="request">The request.</param>
        /// <param name="server">The server.</param>
        public AsyncPublishOperation(
             OperationContext context,
             IEndpointIncomingRequest request,
             StandardServer server)
        {
            m_context = context;
            m_request = request;
            m_server = server;
            m_response = new PublishResponse();
            m_request.Calldata = this;
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// The finializer implementation.
        /// </summary>
        ~AsyncPublishOperation() 
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
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_request.OperationCompleted(null, StatusCodes.BadServerHalted);
            }
        }
        #endregion

        #region Public Members
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        public OperationContext Context
        {
            get { return m_context; }
        }

        /// <summary>
        /// Gets the request handle.
        /// </summary>
        /// <value>The request handle.</value>
        public uint RequestHandle
        {
            get { return m_request.Request.RequestHeader.RequestHandle; }
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>The response.</value>
        public PublishResponse Response
        {
            get { return m_response; }
        }

        /// <summary>
        /// Gets the calldata.
        /// </summary>
        /// <value>The calldata.</value>
        public object Calldata
        {
            get { return m_calldata; }
        }

        /// <summary>
        /// Schedules a thread to complete the request.
        /// </summary>
        /// <param name="calldata">The data that is used to complete the operation</param>
        public void CompletePublish(object calldata)
        {
            m_calldata = calldata;
            m_server.ScheduleIncomingRequest(m_request);
        }
        #endregion

        #region Private Fields
        private IEndpointIncomingRequest m_request;
        private StandardServer m_server;
        private OperationContext m_context;
        private PublishResponse m_response;
        private object m_calldata;
        #endregion
    }
}
