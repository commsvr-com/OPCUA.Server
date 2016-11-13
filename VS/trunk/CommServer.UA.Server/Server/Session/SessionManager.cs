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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;

namespace Opc.Ua.Server
{    
    /// <summary>
    /// A generic session manager object for a server.
    /// </summary>
    public class SessionManager : ISessionManager, IDisposable
    {
        #region Constructors
        /// <summary>
        /// Initializes the manager with its configuration.
        /// </summary>
        public SessionManager(
            IServerInternal          server,
            ApplicationConfiguration configuration)
        {
            if (server == null)        throw new ArgumentNullException("server");
            if (configuration == null) throw new ArgumentNullException("configuration");
            
            m_server = server;

            m_minSessionTimeout            = configuration.ServerConfiguration.MinSessionTimeout;
            m_maxSessionTimeout            = configuration.ServerConfiguration.MaxSessionTimeout;
            m_maxSessionCount              = configuration.ServerConfiguration.MaxSessionCount;
            m_maxRequestAge                = configuration.ServerConfiguration.MaxRequestAge;
            m_maxBrowseContinuationPoints  = configuration.ServerConfiguration.MaxBrowseContinuationPoints;
            m_maxHistoryContinuationPoints = configuration.ServerConfiguration.MaxHistoryContinuationPoints;
            m_minNonceLength               = configuration.SecurityConfiguration.NonceLength;

            m_sessions       = new Dictionary<NodeId,Session>();
            m_nonceGenerator = new RNGCryptoServiceProvider();
            
            // create a event to signal shutdown.
            m_shutdownEvent = new ManualResetEvent(true);            
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// The finializer implementation.
        /// </summary>
        ~SessionManager() 
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
                List<Session> sessions = null;

                lock (m_lock)
                {
                    sessions = new List<Session>(m_sessions.Values);
                    m_sessions.Clear();
                }
                
                foreach (Session session in sessions)
                {
                    Utils.SilentDispose(session);
                }

                m_shutdownEvent.Set();
                m_shutdownEvent.Close();
            }
        }
        #endregion
              
        #region Public Interface
        /// <summary>
        /// Starts the session manager.
        /// </summary>
        public virtual void Startup()
        {
            lock (m_lock)
            {
                // start thread to monitor sessions.
                m_shutdownEvent.Reset();

                m_monitoringThread = new Thread(new ParameterizedThreadStart(MonitorSessions));
                m_monitoringThread.IsBackground = true;
                m_monitoringThread.Name = "MonitorSessions";
                m_monitoringThread.Start(m_minSessionTimeout);
            }            
        }
             
        /// <summary>
        /// Stops the session manager and closes all sessions.
        /// </summary>
        public virtual void Shutdown()
        {
            lock (m_lock)
            {
                // stop the monitoring thread.
                m_shutdownEvent.Set();
                m_monitoringThread = null;
                
                // dispose of session objects.
                foreach (Session session in m_sessions.Values)
                {
                    session.Dispose();
                }

                m_sessions.Clear();
            }            
        }

        /// <summary>
        /// Creates a new session.
        /// </summary>
        public virtual Session CreateSession(
            OperationContext       context,
            X509Certificate2       serverCertificate,
            string                 sessionName, 
            byte[]                 clientNonce,
            ApplicationDescription clientDescription,
            string                 endpointUrl,
            X509Certificate2       clientCertificate,
            double                 requestedSessionTimeout, 
            uint                   maxResponseMessageSize,
            out NodeId             sessionId, 
            out NodeId             authenticationToken, 
            out byte[]             serverNonce,
            out double             revisedSessionTimeout)
        {
            sessionId = 0;
            revisedSessionTimeout = requestedSessionTimeout;
                 
            Session session = null;

            lock (m_lock)
            {
                // check session count.
                if (m_maxSessionCount > 0 && m_sessions.Count >= m_maxSessionCount)
                {
                    throw new ServiceResultException(StatusCodes.BadTooManySessions);
                }

                // can assign a simple identifier if secured.
                authenticationToken = null;

                if (!String.IsNullOrEmpty(context.ChannelContext.SecureChannelId))
                {
                    if (context.ChannelContext.EndpointDescription.SecurityMode != MessageSecurityMode.None)
                    {
                        authenticationToken = Utils.IncrementIdentifier(ref m_lastSessionId);
                    }
                }

                // must assign a hard-to-guess id if not secured.
                if (authenticationToken == null)
                {
                    byte[] token = new byte[32];
                    new RNGCryptoServiceProvider().GetNonZeroBytes(token);
                    authenticationToken = new NodeId(token);
                }
                
                // determine session timeout.
                if (requestedSessionTimeout > m_maxSessionTimeout)
                {
                    revisedSessionTimeout = m_maxSessionTimeout;
                }
                
                if (requestedSessionTimeout < m_minSessionTimeout)
                {
                    revisedSessionTimeout = m_minSessionTimeout;
                }
                
                // create server nonce.
                serverNonce = new byte[m_minNonceLength];
                m_nonceGenerator.GetBytes(serverNonce);

                // assign client name.
                if (String.IsNullOrEmpty(sessionName))
                {
                    sessionName = Utils.Format("Session {0}", sessionId);
                }

                // create instance of session.
                session = CreateSession(
                    context,
                    m_server,
                    serverCertificate,
                    authenticationToken,
                    serverNonce,
                    sessionName,
                    clientDescription,
                    endpointUrl,
                    clientCertificate,
                    revisedSessionTimeout,
                    maxResponseMessageSize,
                    m_maxRequestAge,
                    m_maxBrowseContinuationPoints);

                // get the session id.
                sessionId = session.Id;
                
                // save session.
                m_sessions.Add(authenticationToken, session);
            }

            // raise session related event.
            RaiseSessionEvent(session, SessionEventReason.Created);       
                    
            // return session.
            return session;
        }
        
        /// <summary>
        /// Activates an existing session
        /// </summary>
        public virtual bool ActivateSession(
            OperationContext                context,
            NodeId                          authenticationToken,
            SignatureData                   clientSignature,
            List<SoftwareCertificate>       clientSoftwareCertificates,
            ExtensionObject                 userIdentityToken,
            SignatureData                   userTokenSignature,
            StringCollection                localeIds,
            out byte[]                      serverNonce)
        {
            serverNonce = null;
            
            Session session = null;
            UserIdentityToken newIdentity = null;
            UserTokenPolicy userTokenPolicy = null;

            lock (m_lock)
            {
                // find session.
                if (!m_sessions.TryGetValue(authenticationToken, out session))
                {
                    throw new ServiceResultException(StatusCodes.BadSessionClosed);
                }
                
                // create new server nonce.
                serverNonce = new byte[m_minNonceLength];
                m_nonceGenerator.GetBytes(serverNonce);

                // validate before activation.
                session.ValidateBeforeActivate(
                    context,
                    clientSignature,
                    clientSoftwareCertificates,
                    userIdentityToken,
                    userTokenSignature,
                    localeIds,
                    serverNonce,
                    out newIdentity,
                    out userTokenPolicy);
            }
            
            IUserIdentity identity = null;
            IUserIdentity effectiveIdentity = null;
            ServiceResult error = null;

            try
            {
                // check if the application has a callback which validates the identity tokens.
                lock (m_eventLock)
                {
                    if (m_ImpersonateUser != null)
                    {
                        ImpersonateEventArgs args = new ImpersonateEventArgs(newIdentity, userTokenPolicy);
                        m_ImpersonateUser(session, args);
                        
                        if (ServiceResult.IsBad(args.IdentityValidationError))
                        {
                            error = args.IdentityValidationError;
                        }
                        else
                        {
                            identity = args.Identity;
                            effectiveIdentity = args.EffectiveIdentity;
                        }
                    }
                }

                // parse the token manually if the identity is not provided.
                if (identity == null)
                {
                    identity = new UserIdentity(newIdentity);
                }

                // use the identity as the effectiveIdentity if not provided.
                if (effectiveIdentity == null)
                {
                    effectiveIdentity = identity;
                }
            }
            catch (Exception e)
            {
                if (e is ServiceResultException)
                {
                    throw;
                }

                throw ServiceResultException.Create(
                    StatusCodes.BadIdentityTokenInvalid, 
                    e, 
                    "Could not validate user identity token: {0}", 
                    newIdentity);
            }

            // check for validation error.
            if (ServiceResult.IsBad(error))
            {
                throw new ServiceResultException(error);
            }

            // activate session.
            bool contextChanged = session.Activate(
                context,
                clientSoftwareCertificates,
                newIdentity,
                identity,
                effectiveIdentity,
                localeIds,
                serverNonce);

            // raise session related event.
            if (contextChanged)
            {
                RaiseSessionEvent(session, SessionEventReason.Activated); 
            }

            // indicates that the identity context for the session has changed.
            return contextChanged;       
        }

        /// <summary>
        /// Closes the specifed session.
        /// </summary>
        /// <remarks>
        /// This method should not throw an exception if the session no longer exists.
        /// </remarks>
        public virtual void CloseSession(NodeId sessionId)
        {
            // find the session.
            Session session = null;

            lock (m_lock)
            {
                foreach (KeyValuePair<NodeId,Session> current in m_sessions)
                {
                    if (current.Value.Id == sessionId)
                    {
                        session = current.Value;
                        m_sessions.Remove(current.Key);
                        break;
                    }
                }
            }

            if (session != null)
            {            
                // raise session related event.
                RaiseSessionEvent(session, SessionEventReason.Closing);
                
                // close the session.
                session.Close();

                // update diagnostics.
                lock (m_server.DiagnosticsLock)
                {
                    m_server.ServerDiagnostics.CurrentSessionCount--;
                }
            }

        }

        /// <summary>
        /// Validates request header and returns a request context.
        /// </summary>
        /// <remarks>
        /// This method verifies that the session id valid and that it uses secure channel id
        /// associated with with current thread. It also verifies that the timestamp is not too 
        /// and that the sequence number is not out of order (update requests only).
        /// </remarks>
        public virtual OperationContext ValidateRequest(RequestHeader requestHeader, RequestType requestType)
        {
            if (requestHeader == null) throw new ArgumentNullException("requestHeader");
            
            Session session = null;

            try
            {
                lock (m_lock)
                {
                    // check for create session request.
                    if (requestType == RequestType.CreateSession || requestType == RequestType.ActivateSession)
                    {
                        return new OperationContext(requestHeader, requestType);
                    }

                    // find session.
                    if (!m_sessions.TryGetValue(requestHeader.AuthenticationToken, out session))
                    {
                        throw new ServiceResultException(StatusCodes.BadSessionClosed);
                    }

                    // validate request header.
                    session.ValidateRequest(requestHeader, requestType);

                    // return context.
                    return new OperationContext(requestHeader, requestType, session);
                }
            }
            catch (Exception e)
            {
                ServiceResultException sre = e as ServiceResultException;

                if (sre != null && sre.StatusCode == StatusCodes.BadSessionNotActivated)
                {
                    if (session != null)
                    {
                        CloseSession(session.Id);
                    }
                }

                throw new ServiceResultException(e, StatusCodes.BadUnexpectedError);
            }
        }
        #endregion
        
        #region Protected Methods
        /// <summary>
        /// Creates a new instance of a session.
        /// </summary>
        protected virtual Session CreateSession(
            OperationContext          context,
            IServerInternal           server,
            X509Certificate2          serverCertificate,
            NodeId                    sessionCookie,
            byte[]                    serverNonce,
            string                    sessionName, 
            ApplicationDescription    clientDescription,
            string                    endpointUrl,
            X509Certificate2          clientCertificate,
            double                    sessionTimeout,
            uint                      maxResponseMessageSize,
            int                       maxRequestAge, // TBD - Remove unused parameter.
            int                       maxContinuationPoints) // TBD - Remove unused parameter.
        {
            Session session = new Session(
                context,
                m_server,
                serverCertificate,
                sessionCookie,
                serverNonce,
                sessionName,
                clientDescription,
                endpointUrl,
                clientCertificate,
                sessionTimeout,
                maxResponseMessageSize,
                m_maxRequestAge,
                m_maxBrowseContinuationPoints,
                m_maxHistoryContinuationPoints);

            return session;
        }

        /// <summary>
        /// Raises an event related to a session.
        /// </summary>
        protected virtual void RaiseSessionEvent(Session session, SessionEventReason reason)
        { 
            lock (m_eventLock)
            {
                SessionEventHandler handler = null;

                switch (reason)
                {
                    case SessionEventReason.Created:   { handler = m_SessionCreated;   break; }
                    case SessionEventReason.Activated: { handler = m_SessionActivated; break; }
                    case SessionEventReason.Closing:   { handler = m_SessionClosing;   break; }
                }

                if (handler != null)
                {
                    try
                    {
                        handler(session, reason);
                    }
                    catch (Exception e)
                    {
                        Utils.Trace(e, "Session event handler raised an exception.");
                    }
                }
            } 
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Periodically checks if the sessions have timed out.
        /// </summary>
        private void MonitorSessions(object data)
        {
            try
            {
                // Utils.Trace("Server: Session Monitor Thread Started.");

                int sleepCycle = Convert.ToInt32(data, CultureInfo.InvariantCulture);

                do
                {
                    Session[] sessions = null;

                    lock (m_lock)
                    {
                        // check if halted.
                        if (m_monitoringThread == null)
                        {
                            return;
                        }

                        sessions = new Session[m_sessions.Count];
                        m_sessions.Values.CopyTo(sessions, 0);
                    }

                    for (int ii = 0; ii < sessions.Length; ii++)
                    {
                        if (sessions[ii].HasExpired)
                        {
                            // update diagnostics.
                            lock (m_server.DiagnosticsLock)
                            {
                                m_server.ServerDiagnostics.SessionTimeoutCount++;
                            }
                         
                            m_server.CloseSession(null, sessions[ii].Id, false);
                        }
                    }

                    if (m_shutdownEvent.WaitOne(sleepCycle, false))
                    {
                        Utils.Trace("Server: Session Monitor Thread Exited Normally.");
                        break;
                    }
                }
                while (true);
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Server: Session Monitor Thread Exited Unexpectedly");
            }
        }
        #endregion
        
        #region Private Fields
        private object m_lock = new object();
        private IServerInternal m_server;
        private Dictionary<NodeId,Session> m_sessions;
        private long m_lastSessionId;
        private Thread m_monitoringThread;
        private ManualResetEvent m_shutdownEvent;
        private RNGCryptoServiceProvider m_nonceGenerator;

        private int m_minSessionTimeout;
        private int m_maxSessionTimeout;
        private int m_maxSessionCount;
        private int m_maxRequestAge;
        private int m_maxBrowseContinuationPoints;
        private int m_maxHistoryContinuationPoints;
        private int m_minNonceLength;

        private object m_eventLock = new object();
        private event SessionEventHandler m_SessionCreated;
        private event SessionEventHandler m_SessionActivated;
        private event SessionEventHandler m_SessionClosing;
        private event ImpersonateEventHandler m_ImpersonateUser;
        #endregion

        #region ISessionManager Members
        /// <summary cref="ISessionManager.SessionCreated" />
        public event SessionEventHandler SessionCreated
        {
            add
            {
                lock (m_eventLock)
                {
                    m_SessionCreated += value;
                }
            }

            remove
            {
                lock (m_eventLock)
                {
                    m_SessionCreated -= value;
                }
            }
        }
        
        /// <summary cref="ISessionManager.SessionActivated" />
        public event SessionEventHandler SessionActivated
        {
            add
            {
                lock (m_eventLock)
                {
                    m_SessionActivated += value;
                }
            }

            remove
            {
                lock (m_eventLock)
                {
                    m_SessionActivated -= value;
                }
            }
        }
        
        /// <summary cref="ISessionManager.SessionClosing" />
        public event SessionEventHandler SessionClosing
        {
            add
            {
                lock (m_eventLock)
                {
                    m_SessionClosing += value;
                }
            }

            remove
            {
                lock (m_eventLock)
                {
                    m_SessionClosing -= value;
                }
            }
        }
        
        /// <summary cref="ISessionManager.ImpersonateUser" />
        public event ImpersonateEventHandler ImpersonateUser
        {
            add
            {
                lock (m_eventLock)
                {
                    m_ImpersonateUser += value;
                }
            }

            remove
            {
                lock (m_eventLock)
                {
                    m_ImpersonateUser -= value;
                }
            }
        }

        /// <summary>
        /// Returns all of the sessions known to the session manager.
        /// </summary>
        /// <returns>A list of the sessions.</returns>
        public IList<Session> GetSessions()
        {
            lock (m_lock)
            {
                return new List<Session>(m_sessions.Values);
            }
        }
        #endregion
    }

    /// <summary>
    /// Allows application components to receive notifications when changes to sessions occur.
    /// </summary>
    /// <remarks>
    /// Sinks that receive these events must not block the thread.
    /// </remarks>
    public interface ISessionManager
    {
        /// <summary>
        /// Raised after a new session is created.
        /// </summary>
        event SessionEventHandler SessionCreated;

        /// <summary>
        /// Raised whenever a session is activated and the user identity or preferred locales changed.
        /// </summary>
        event SessionEventHandler SessionActivated;

        /// <summary>
        /// Raised before a session is closed.
        /// </summary>
        event SessionEventHandler SessionClosing;

        /// <summary>
        /// Raised before the user identity for a session is changed.
        /// </summary>
        event ImpersonateEventHandler ImpersonateUser;

        /// <summary>
        /// Returns all of the sessions known to the session manager.
        /// </summary>
        /// <returns>A list of the sessions.</returns>
        IList<Session> GetSessions();
    }

    /// <summary>
    /// The possible reasons for a session related eventg. 
    /// </summary>
    public enum SessionEventReason
    {
        /// <summary>
        /// A new session was created.
        /// </summary>
        Created,

        /// <summary>
        /// A session is being activated with a new user identity.
        /// </summary>
        Impersonating,

        /// <summary>
        /// A session was activated and the user identity or preferred locales changed.
        /// </summary>
        Activated,

        /// <summary>
        /// A session is about to be closed.
        /// </summary>
        Closing
    }

    /// <summary>
    /// The delegate for functions used to receive session related events.
    /// </summary>
    public delegate void SessionEventHandler(Session session, SessionEventReason reason);
    
    #region ImpersonateEventArgs Class
    /// <summary>
    /// A class which provides the event arguments for session related event.
    /// </summary>
    public class ImpersonateEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public ImpersonateEventArgs(UserIdentityToken newIdentity, UserTokenPolicy userTokenPolicy)
        {
            m_newIdentity = newIdentity;
            m_userTokenPolicy = userTokenPolicy;
        }
        #endregion
        
        #region Public Properties
        /// <summary>
        /// The new user identity for the session.
        /// </summary>
        public UserIdentityToken NewIdentity
        {
            get { return m_newIdentity; }
        }

        /// <summary>
        /// The user token policy selected by the client.
        /// </summary>
        public UserTokenPolicy UserTokenPolicy
        {
            get { return m_userTokenPolicy; }
        }
           
        /// <summary>
        /// An application defined handle that can be used for access control operations.
        /// </summary>
        public IUserIdentity Identity
        {
            get { return m_identity;  }
            set { m_identity = value; }
        }
           
        /// <summary>
        /// An application defined handle that can be used for access control operations.
        /// </summary>
        public IUserIdentity EffectiveIdentity
        {
            get { return m_effectiveIdentity;  }
            set { m_effectiveIdentity = value; }
        }

        /// <summary>
        /// Set to indicate that an error occurred validating the identity and that it should be rejected.
        /// </summary>
        public ServiceResult IdentityValidationError
        {
            get { return m_identityValidationError;  }
            set { m_identityValidationError = value; }
        }
        #endregion

        #region Private Fields
        private UserIdentityToken  m_newIdentity;
        private UserTokenPolicy m_userTokenPolicy;
        private ServiceResult m_identityValidationError;
        private IUserIdentity m_identity;
        private IUserIdentity m_effectiveIdentity;
        #endregion
    }

    /// <summary>
    /// The delegate for functions used to receive impersonation events.
    /// </summary>
    public delegate void ImpersonateEventHandler(Session session, ImpersonateEventArgs args);
    #endregion
}
