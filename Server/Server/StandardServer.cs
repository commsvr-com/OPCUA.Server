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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.IdentityModel.Tokens;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Reflection;
using Opc.Ua.Bindings;

namespace Opc.Ua.Server
{
    /// <summary>
    /// The standard implementation of a UA server.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
    public partial class StandardServer : SessionServerBase
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        public StandardServer()
        {            
        }
        #endregion
        
        #region IDisposable Members
        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "m_serverInternal"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "m_registrationTimer"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "m_configurationWatcher")]
        protected override void Dispose(bool disposing)
        {  
            if (disposing)
            {
                // halt any outstanding timer.
                if (m_registrationTimer != null)
                {
                    Utils.SilentDispose(m_registrationTimer);
                    m_registrationTimer = null;
                }
                
                // close the watcher.
                if (m_configurationWatcher != null)
                {
                    Utils.SilentDispose(m_configurationWatcher);
                    m_configurationWatcher = null;
                }
                
                // close the server.
                if (m_serverInternal != null)
                {
                    Utils.SilentDispose(m_serverInternal);
                    m_serverInternal = null;
                }
            }

            base.Dispose(disposing);
        }
        #endregion

        #region IServer Methods
        /// <summary>
        /// Invokes the FindServers service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="endpointUrl">The endpoint URL.</param>
        /// <param name="localeIds">The locale ids.</param>
        /// <param name="serverUris">The server uris.</param>
        /// <param name="servers">The servers.</param>
        /// <returns>
        /// Returns a description for the ResponseHeader DataType, the return type is <seealso cref="ResponseHeader"/>
        /// </returns>
        public override ResponseHeader FindServers(
            RequestHeader                        requestHeader,
            string                               endpointUrl,
            StringCollection                     localeIds,
            StringCollection                     serverUris,
            out ApplicationDescriptionCollection servers)
        {   
            servers = null;
            
            ValidateRequest(requestHeader);
            
            lock (m_lock)
            {
                // parse the url provided by the client.
                Uri parsedEndpointUrl = Utils.ParseUri(endpointUrl);

                servers = new ApplicationDescriptionCollection();
                
                // build list of unique servers.
                Dictionary<string,ApplicationDescription> uniqueServers = new Dictionary<string,ApplicationDescription>();

                foreach (EndpointDescription description in GetEndpoints())
                {
                    ApplicationDescription server = description.Server;

                    // skip servers that have been processed.
                    if (uniqueServers.ContainsKey(server.ApplicationUri))
                    {
                        continue;
                    }

                    // check client is filtering by server uri.
                    if (serverUris != null && serverUris.Count > 0)
                    {
                        if (!serverUris.Contains(server.ApplicationUri))
                        {
                            continue;
                        }
                    }

                    // localize the application name if requested.
                    LocalizedText applicationName = server.ApplicationName;

                    if (localeIds != null && localeIds.Count > 0)
                    {
                        applicationName = m_serverInternal.ResourceManager.Translate(localeIds, applicationName);
                    }

                    // get the application description.
                    ApplicationDescription application = TranslateApplicationDescription(
                        parsedEndpointUrl,
                        server,
                        base.DiscoveryUrls,
                        applicationName);

                    uniqueServers.Add(server.ApplicationUri, application);

                    // add to list of servers to return.
                    servers.Add(application);
                }
            }
                            
            return CreateResponse(requestHeader, StatusCodes.Good);
        }

        /// <summary>
        /// Invokes the GetEndpoints service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="endpointUrl">The endpoint URL.</param>
        /// <param name="localeIds">The locale ids.</param>
        /// <param name="profileUris">The profile uris.</param>
        /// <param name="endpoints">The endpoints.</param>
        /// <returns>
        /// Returns a description for the ResponseHeader DataType
        /// </returns>
        public override ResponseHeader GetEndpoints(
            RequestHeader                     requestHeader,
            string                            endpointUrl,
            StringCollection                  localeIds,
            StringCollection                  profileUris,
            out EndpointDescriptionCollection endpoints)
        {   
            endpoints = null;
            
            ValidateRequest(requestHeader);

            lock (m_lock)
            {
                // parse the url provided by the client.
                Uri parsedEndpointUrl = Utils.ParseUri(endpointUrl);

                // localize the application name if requested.
                LocalizedText applicationName = this.ServerDescription.ApplicationName;

                if (localeIds != null && localeIds.Count > 0)
                {
                    applicationName = m_serverInternal.ResourceManager.Translate(localeIds, applicationName);
                }

                // get the application description.
                ApplicationDescription application = TranslateApplicationDescription(
                    parsedEndpointUrl,
                    base.ServerDescription,
                    base.DiscoveryUrls,
                    applicationName);

                // get the application description.
                endpoints = FilterEndpointDescriptions(
                    parsedEndpointUrl,
                    profileUris,
                    this.Configuration.ServerConfiguration.BaseAddresses,
                    this.Configuration.ServerConfiguration.AlternateBaseAddresses,
                    this.Endpoints,
                    application);
            }
                            
            return CreateResponse(requestHeader, StatusCodes.Good);
        }

        /// <summary>
        /// Invokes the TestStack service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="testId">The test id.</param>
        /// <param name="iteration">The iteration.</param>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <returns>
        /// Returns a description for the ResponseHeader DataType
        /// </returns>
        public override ResponseHeader TestStack(
            RequestHeader requestHeader,
            uint          testId,
            int           iteration,
            Variant       input,
            out Variant   output)
        {               
            ValidateRequest(requestHeader);

            output = input;
                
            return CreateResponse(requestHeader, StatusCodes.Good);
        }

        /// <summary>
        /// Invokes the TestStackEx service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="testId">The test id.</param>
        /// <param name="iteration">The iteration.</param>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <returns>
        /// Returns a description for the ResponseHeader DataType
        /// </returns>
        public override ResponseHeader TestStackEx(
            RequestHeader         requestHeader,
            uint                  testId,
            int                   iteration,
            CompositeTestType     input,
            out CompositeTestType output)
        {
            output = null;

            ValidateRequest(requestHeader);

            output = input;

            return CreateResponse(requestHeader, StatusCodes.Good);
        }

        /// <summary>
        /// Invokes the CreateSession service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="clientDescription">The client description.</param>
        /// <param name="serverUri">The server URI.</param>
        /// <param name="endpointUrl">The endpoint URL.</param>
        /// <param name="sessionName">Name of the session.</param>
        /// <param name="clientNonce">The client nonce.</param>
        /// <param name="clientCertificate">The client certificate.</param>
        /// <param name="requestedSessionTimeout">The requested session timeout.</param>
        /// <param name="maxResponseMessageSize">Size of the max response message.</param>
        /// <param name="sessionId">The session id.</param>
        /// <param name="authenticationToken">The authentication token.</param>
        /// <param name="revisedSessionTimeout">The revised session timeout.</param>
        /// <param name="serverNonce">The server nonce.</param>
        /// <param name="serverCertificate">The server certificate.</param>
        /// <param name="serverEndpoints">The server endpoints.</param>
        /// <param name="serverSoftwareCertificates">The server software certificates.</param>
        /// <param name="serverSignature">The server signature.</param>
        /// <param name="maxRequestMessageSize">Size of the max request message.</param>
        /// <returns>
        /// Returns a description for the ResponseHeader DataType
        /// </returns>
        public override ResponseHeader CreateSession(
            RequestHeader                           requestHeader,
            ApplicationDescription                  clientDescription,
            string                                  serverUri,
            string                                  endpointUrl,
            string                                  sessionName,
            byte[]                                  clientNonce,
            byte[]                                  clientCertificate,
            double                                  requestedSessionTimeout,
            uint                                    maxResponseMessageSize,
            out NodeId                              sessionId,
            out NodeId                              authenticationToken,
            out double                              revisedSessionTimeout,
            out byte[]                              serverNonce,
            out byte[]                              serverCertificate,
            out EndpointDescriptionCollection       serverEndpoints,
            out SignedSoftwareCertificateCollection serverSoftwareCertificates,
            out SignatureData                       serverSignature,
            out uint                                maxRequestMessageSize)
        {       
            sessionId = 0;
            revisedSessionTimeout = 0;
            serverNonce = null;
            serverCertificate = null;
            serverSoftwareCertificates = null;
            serverSignature = null;
            maxRequestMessageSize = (uint)MessageContext.MaxMessageSize;

            OperationContext context = ValidateRequest(requestHeader, RequestType.CreateSession);
        
            try
            {
                // check the server uri.
                if (!String.IsNullOrEmpty(serverUri))
                {
                    if (serverUri != this.Configuration.ApplicationUri)
                    {
                        throw new ServiceResultException(StatusCodes.BadServerUriInvalid);
                    }
                }

                // validate client application instance certificate.
                X509Certificate2 parsedClientCertificate = null;

                if (clientCertificate != null && clientCertificate.Length > 0)
                {
                    try
                    {
                        parsedClientCertificate = CertificateFactory.Create(clientCertificate, true);

                        if (context.SecurityPolicyUri != SecurityPolicies.None)
                        {
                            CertificateValidator.Validate(parsedClientCertificate);
                        }
                    }
                    catch (Exception e)
                    {
                        OnApplicationCertificateError(clientCertificate, new ServiceResult(e));
                    }
                }

                // verify the nonce provided by the client.
                if (clientNonce != null)
                {
                    if (clientNonce.Length < m_minNonceLength)
                    {
                        throw new ServiceResultException(StatusCodes.BadNonceInvalid);
                    }
                }

                // create the session.
                Session session = ServerInternal.SessionManager.CreateSession(
                    context,
                    InstanceCertificate,
                    sessionName,
                    clientNonce,
                    clientDescription,
                    endpointUrl,
                    parsedClientCertificate,
                    requestedSessionTimeout,
                    maxResponseMessageSize,
                    out sessionId,
                    out authenticationToken,
                    out serverNonce,
                    out revisedSessionTimeout);           
                                
                lock (m_lock)
                {                
                    // return the application instance certificate for the server.
                    serverCertificate = InstanceCertificate.RawData;
                                 
                    // return the endpoints supported by the server.
                    serverEndpoints = GetEndpointDescriptions(endpointUrl);

                    // return the software certificates assigned to the server.
                    serverSoftwareCertificates = new SignedSoftwareCertificateCollection(ServerProperties.SoftwareCertificates);
                    
                    // sign the nonce provided by the client.
                    serverSignature = null;
                    
                    //  sign the client nonce (if provided).
                    if (parsedClientCertificate != null && clientNonce != null)
                    {
                        byte[] dataToSign = Utils.Append(clientCertificate, clientNonce);
                        serverSignature = SecurityPolicies.Sign(InstanceCertificate, context.SecurityPolicyUri, dataToSign);
                    }
                }

                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.CurrentSessionCount++;
                    ServerInternal.ServerDiagnostics.CumulatedSessionCount++;
                }

                Utils.Trace("Server - SESSION CREATED. SessionId={0}", sessionId);

                return CreateResponse(requestHeader, StatusCodes.Good);
            }
            catch (ServiceResultException e)
            {
                Utils.Trace("Server - SESSION CREATE failed. {0}", e.Message);

                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedSessionCount++;
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedSessionCount++;
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException((DiagnosticsMasks)requestHeader.ReturnDiagnostics, new StringCollection(), e);
            }  
            finally
            {
                OnRequestComplete(context);
            }
        }

        /// <summary>
        /// Invokes the ActivateSession service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="clientSignature">The client signature.</param>
        /// <param name="clientSoftwareCertificates">The client software certificates.</param>
        /// <param name="localeIds">The locale ids.</param>
        /// <param name="userIdentityToken">The user identity token.</param>
        /// <param name="userTokenSignature">The user token signature.</param>
        /// <param name="serverNonce">The server nonce.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a description for the ResponseHeader DataType
        /// </returns>
        public override ResponseHeader ActivateSession(
            RequestHeader                       requestHeader,
            SignatureData                       clientSignature,
            SignedSoftwareCertificateCollection clientSoftwareCertificates,
            StringCollection                    localeIds,
            ExtensionObject                     userIdentityToken,
            SignatureData                       userTokenSignature,
            out byte[]                          serverNonce,
            out StatusCodeCollection            results,
            out DiagnosticInfoCollection        diagnosticInfos)
        {               
            serverNonce = null;
            results = null;
            diagnosticInfos = null;
     
            OperationContext context = ValidateRequest(requestHeader, RequestType.ActivateSession);
            
            try
            {
                // validate client's software certificates.
                List<SoftwareCertificate> softwareCertificates = new List<SoftwareCertificate>();
                
                if (context.SecurityPolicyUri != SecurityPolicies.None)
                {
                    bool diagnosticsExist = false;
                            
                    if ((context.DiagnosticsMask & DiagnosticsMasks.OperationAll) != 0)
                    {
                        diagnosticInfos = new DiagnosticInfoCollection();
                    }

                    results = new StatusCodeCollection();
                    diagnosticInfos = new DiagnosticInfoCollection();

                    foreach (SignedSoftwareCertificate signedCertificate in clientSoftwareCertificates)
                    {
                        SoftwareCertificate softwareCertificate = null;

                        ServiceResult result = SoftwareCertificate.Validate(
                            CertificateValidator,
                            signedCertificate.CertificateData,
                            out softwareCertificate);

                        if (ServiceResult.IsBad(result))
                        {
                            results.Add(result.Code);
                            
                            // add diagnostics if requested.
                            if ((context.DiagnosticsMask & DiagnosticsMasks.OperationAll) != 0)
                            {
                                DiagnosticInfo diagnosticInfo = ServerUtils.CreateDiagnosticInfo(ServerInternal, context, result);
                                diagnosticInfos.Add(diagnosticInfo);
                                diagnosticsExist = true;
                            }
                        }
                        else
                        {
                            softwareCertificates.Add(softwareCertificate);
                            results.Add(StatusCodes.Good);
                            
                            // add diagnostics if requested.
                            if ((context.DiagnosticsMask & DiagnosticsMasks.OperationAll) != 0)
                            {
                                diagnosticInfos.Add(null);
                            }
                        }
                    }

                    if (!diagnosticsExist && diagnosticInfos != null)
                    {
                        diagnosticInfos.Clear();
                    }
                }
                            
                // check if certificates meet the server's requirements.
                ValidateSoftwareCertificates(softwareCertificates);
                
                // activate the session.
                bool identityChanged = ServerInternal.SessionManager.ActivateSession(
                    context,
                    requestHeader.AuthenticationToken,
                    clientSignature,
                    softwareCertificates,
                    userIdentityToken,
                    userTokenSignature,
                    localeIds,
                    out serverNonce);

                if (identityChanged)
                {
                    // TBD - call Node Manager and Subscription Manager.
                }

                Utils.Trace("Server - SESSION ACTIVATED.");

                return CreateResponse(requestHeader, StatusCodes.Good);
            }
            catch (ServiceResultException e)
            {
                Utils.Trace("Server - SESSION ACTIVATE failed. {0}", e.Message);

                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException((DiagnosticsMasks)requestHeader.ReturnDiagnostics, localeIds, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }  
        }

        /// <summary>
        /// Returns true if the error is a security error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns>
        /// 	<c>true</c> if the error is a one of the security errors, otherwise <c>false</c>.
        /// </returns>
        private bool IsSecurityError(StatusCode error)
        {
            switch (error.CodeBits)
            {
                case StatusCodes.BadUserSignatureInvalid:
                case StatusCodes.BadUserAccessDenied:
                case StatusCodes.BadSecurityPolicyRejected:
                case StatusCodes.BadSecurityModeRejected:
                case StatusCodes.BadSecurityChecksFailed:
                case StatusCodes.BadSecureChannelTokenUnknown:
                case StatusCodes.BadSecureChannelIdInvalid:
                case StatusCodes.BadNoValidCertificates:
                case StatusCodes.BadIdentityTokenInvalid:
                case StatusCodes.BadIdentityTokenRejected:
                case StatusCodes.BadIdentityChangeNotSupported:
                case StatusCodes.BadCertificateUseNotAllowed:
                case StatusCodes.BadCertificateUriInvalid:
                case StatusCodes.BadCertificateUntrusted:
                case StatusCodes.BadCertificateTimeInvalid:
                case StatusCodes.BadCertificateRevoked:
                case StatusCodes.BadCertificateRevocationUnknown:
                case StatusCodes.BadCertificateIssuerUseNotAllowed:
                case StatusCodes.BadCertificateIssuerTimeInvalid:
                case StatusCodes.BadCertificateIssuerRevoked:
                case StatusCodes.BadCertificateIssuerRevocationUnknown:
                case StatusCodes.BadCertificateInvalid:
                case StatusCodes.BadCertificateHostNameInvalid:
                case StatusCodes.BadApplicationSignatureInvalid:
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Invokes the CloseSession service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="deleteSubscriptions">if set to <c>true</c> subscriptions are deleted.</param>
        /// <returns>
        /// Returns a description for the ResponseHeader DataType
        /// </returns>
        public override ResponseHeader CloseSession(RequestHeader requestHeader, bool deleteSubscriptions)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.CloseSession);

            try
            {
                ServerInternal.CloseSession(context, context.Session.Id, deleteSubscriptions);
                return CreateResponse(requestHeader, context.StringTable);
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }  
        }

        /// <summary>
        /// Invokes the Cancel service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="requestHandle">The request handle.</param>
        /// <param name="cancelCount">The cancel count.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader Cancel(
            RequestHeader requestHeader,
            uint          requestHandle,
            out uint      cancelCount)
        {
            cancelCount = 0;

            OperationContext context = ValidateRequest(requestHeader, RequestType.Cancel);
            
            try
            {
                m_serverInternal.RequestManager.CancelRequests(requestHandle, out cancelCount);                
                return CreateResponse(requestHeader, context.StringTable);
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }  
        }

        /// <summary>
        /// Invokes the Browse service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="view">The view.</param>
        /// <param name="requestedMaxReferencesPerNode">The requested max references per node.</param>
        /// <param name="nodesToBrowse">The nodes to browse.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader Browse(
            RequestHeader                requestHeader,
            ViewDescription              view,
            uint                         requestedMaxReferencesPerNode,
            BrowseDescriptionCollection  nodesToBrowse,
            out BrowseResultCollection   results,
            out DiagnosticInfoCollection diagnosticInfos)
        {
            results = null;
            diagnosticInfos = null;

            OperationContext context = ValidateRequest(requestHeader, RequestType.Browse);

            try
            {
                if (nodesToBrowse == null || nodesToBrowse.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }

                m_serverInternal.NodeManager.Browse(
                    context,
                    view,
                    requestedMaxReferencesPerNode,
                    nodesToBrowse,
                    out results,
                    out diagnosticInfos);

                return CreateResponse(requestHeader, context.StringTable);
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }   
        }

        /// <summary>
        /// Invokes the BrowseNext service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="releaseContinuationPoints">if set to <c>true</c> the continuation points are released.</param>
        /// <param name="continuationPoints">The continuation points.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader BrowseNext(
            RequestHeader                requestHeader,
            bool                         releaseContinuationPoints,
            ByteStringCollection         continuationPoints,
            out BrowseResultCollection   results,
            out DiagnosticInfoCollection diagnosticInfos)
        {   
            results = null;
            diagnosticInfos = null;
            
            OperationContext context = ValidateRequest(requestHeader, RequestType.BrowseNext);
            
            try
            {
                if (continuationPoints == null || continuationPoints.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }

                m_serverInternal.NodeManager.BrowseNext(
                    context,
                    releaseContinuationPoints,
                    continuationPoints,
                    out results,
                    out diagnosticInfos);

                return CreateResponse(requestHeader, context.StringTable);    
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }   
        }

        /// <summary>
        /// Registers a set of nodes.
        /// </summary>
        public override ResponseHeader RegisterNodes(
            RequestHeader requestHeader, 
            NodeIdCollection nodesToRegister, 
            out NodeIdCollection registeredNodeIds)
        {
            registeredNodeIds = null;

            OperationContext context = ValidateRequest(requestHeader, RequestType.RegisterNodes);

            try
            {
                if (nodesToRegister == null || nodesToRegister.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }

                m_serverInternal.NodeManager.RegisterNodes(
                    context,
                    nodesToRegister,
                    out registeredNodeIds);

                return CreateResponse(requestHeader, context.StringTable);
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }
            finally
            {
                OnRequestComplete(context);
            }  
        }
        
        /// <summary>
        /// Unregisters a set of nodes.
        /// </summary>
        public override ResponseHeader UnregisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToUnregister)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.UnregisterNodes);

            try
            {
                if (nodesToUnregister == null || nodesToUnregister.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }

                m_serverInternal.NodeManager.UnregisterNodes(
                    context,
                    nodesToUnregister);

                return CreateResponse(requestHeader, context.StringTable);
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }
            finally
            {
                OnRequestComplete(context);
            }  
        }

        /// <summary>
        /// Invokes the TranslateBrowsePathsToNodeIds service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="browsePaths">The browse paths.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object.
        /// </returns>
        public override ResponseHeader TranslateBrowsePathsToNodeIds(
            RequestHeader                  requestHeader, 
            BrowsePathCollection           browsePaths, 
            out BrowsePathResultCollection results, 
            out DiagnosticInfoCollection   diagnosticInfos)
        {
            results = null;
            diagnosticInfos = null;

            OperationContext context = ValidateRequest(requestHeader, RequestType.TranslateBrowsePathsToNodeIds);

            try
            {
                if (browsePaths == null || browsePaths.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }

                m_serverInternal.NodeManager.TranslateBrowsePathsToNodeIds(
                    context,
                    browsePaths,
                    out results,
                    out diagnosticInfos);

                return CreateResponse(requestHeader, context.StringTable);  
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            } 
        }

        /// <summary>
        /// Invokes the Read service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="maxAge">The max age.</param>
        /// <param name="timestampsToReturn">The timestamps to return.</param>
        /// <param name="nodesToRead">The nodes to read.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader Read(
            RequestHeader                requestHeader, 
            double                       maxAge, 
            TimestampsToReturn           timestampsToReturn, 
            ReadValueIdCollection        nodesToRead, 
            out DataValueCollection      results, 
            out DiagnosticInfoCollection diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.Read);

            try
            {
                if (nodesToRead == null || nodesToRead.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }

                m_serverInternal.NodeManager.Read(
                    context,
                    maxAge,
                    timestampsToReturn,
                    nodesToRead,
                    out results,
                    out diagnosticInfos);

                return CreateResponse(requestHeader, context.StringTable);  
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            } 
        }


        /// <summary>
        /// Invokes the HistoryRead service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="historyReadDetails">The history read details.</param>
        /// <param name="timestampsToReturn">The timestamps to return.</param>
        /// <param name="releaseContinuationPoints">if set to <c>true</c> continuation points are released.</param>
        /// <param name="nodesToRead">The nodes to read.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader HistoryRead(
            RequestHeader                   requestHeader, 
            ExtensionObject                 historyReadDetails, 
            TimestampsToReturn              timestampsToReturn, 
            bool                            releaseContinuationPoints, 
            HistoryReadValueIdCollection    nodesToRead, 
            out HistoryReadResultCollection results, 
            out DiagnosticInfoCollection    diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.HistoryRead);
            
            try
            {
                if (nodesToRead == null || nodesToRead.Count == 0)
                {            
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }

                m_serverInternal.NodeManager.HistoryRead(
                    context,
                    historyReadDetails,
                    timestampsToReturn,
                    releaseContinuationPoints,
                    nodesToRead,
                    out results,
                    out diagnosticInfos);            

                return CreateResponse(requestHeader, context.StringTable);   
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            } 
        }


        /// <summary>
        /// Invokes the Write service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="nodesToWrite">The nodes to write.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader Write(
            RequestHeader                requestHeader, 
            WriteValueCollection         nodesToWrite, 
            out StatusCodeCollection     results, 
            out DiagnosticInfoCollection diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.Write);

            try
            {
                if (nodesToWrite == null || nodesToWrite.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }

                m_serverInternal.NodeManager.Write(
                    context,
                    nodesToWrite,
                    out results,
                    out diagnosticInfos);

                return CreateResponse(requestHeader, context.StringTable);
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }
        }


        /// <summary>
        /// Invokes the HistoryUpdate service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="historyUpdateDetails">The history update details.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader HistoryUpdate(
            RequestHeader                     requestHeader,
            ExtensionObjectCollection         historyUpdateDetails,
            out HistoryUpdateResultCollection results,
            out DiagnosticInfoCollection      diagnosticInfos)
        {   
            OperationContext context = ValidateRequest(requestHeader, RequestType.HistoryUpdate);
            
            try
            {
                if (historyUpdateDetails == null || historyUpdateDetails.Count == 0)
                {            
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }

                m_serverInternal.NodeManager.HistoryUpdate(
                    context,
                    historyUpdateDetails,
                    out results,
                    out diagnosticInfos);            

                return CreateResponse(requestHeader, context.StringTable);    
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }
        }


        /// <summary>
        /// Invokes the CreateSubscription service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="requestedPublishingInterval">The requested publishing interval.</param>
        /// <param name="requestedLifetimeCount">The requested lifetime count.</param>
        /// <param name="requestedMaxKeepAliveCount">The requested max keep alive count.</param>
        /// <param name="maxNotificationsPerPublish">The max notifications per publish.</param>
        /// <param name="publishingEnabled">if set to <c>true</c> publishing is enabled.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <param name="revisedPublishingInterval">The revised publishing interval.</param>
        /// <param name="revisedLifetimeCount">The revised lifetime count.</param>
        /// <param name="revisedMaxKeepAliveCount">The revised max keep alive count.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader CreateSubscription(
            RequestHeader requestHeader,
            double        requestedPublishingInterval,
            uint          requestedLifetimeCount,
            uint          requestedMaxKeepAliveCount,
            uint          maxNotificationsPerPublish,
            bool          publishingEnabled,
            byte          priority,
            out uint      subscriptionId,
            out double    revisedPublishingInterval,
            out uint      revisedLifetimeCount,
            out uint      revisedMaxKeepAliveCount)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.CreateSubscription);

            try
            {
                ServerInternal.SubscriptionManager.CreateSubscription(
                    context,
                    requestedPublishingInterval,
                    requestedLifetimeCount,
                    requestedMaxKeepAliveCount,
                    maxNotificationsPerPublish,
                    publishingEnabled,
                    priority,
                    out subscriptionId,
                    out revisedPublishingInterval,
                    out revisedLifetimeCount,
                    out revisedMaxKeepAliveCount);    

                return CreateResponse(requestHeader, context.StringTable);   
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }         
        }


        /// <summary>
        /// Invokes the DeleteSubscriptions service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="subscriptionIds">The subscription ids.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader DeleteSubscriptions(
            RequestHeader                requestHeader, 
            UInt32Collection             subscriptionIds, 
            out StatusCodeCollection     results, 
            out DiagnosticInfoCollection diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.DeleteSubscriptions);

            try
            {
                if (subscriptionIds == null || subscriptionIds.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }         

                ServerInternal.SubscriptionManager.DeleteSubscriptions(
                    context,
                    subscriptionIds,
                    out results,
                    out diagnosticInfos);    

                return CreateResponse(requestHeader, context.StringTable);  
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            } 
        }


        /// <summary>
        /// Invokes the Publish service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="subscriptionAcknowledgements">The subscription acknowledgements.</param>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <param name="availableSequenceNumbers">The available sequence numbers.</param>
        /// <param name="moreNotifications">if set to <c>true</c> more notifications is provided.</param>
        /// <param name="notificationMessage">The notification message.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object 
        /// </returns>
        public override ResponseHeader Publish(
            RequestHeader                         requestHeader, 
            SubscriptionAcknowledgementCollection subscriptionAcknowledgements, 
            out uint                              subscriptionId, 
            out UInt32Collection                  availableSequenceNumbers, 
            out bool                              moreNotifications, 
            out NotificationMessage               notificationMessage, 
            out StatusCodeCollection              results, 
            out DiagnosticInfoCollection          diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.Publish);

            try
            {
                /*
                // check if there is an odd delay.
                if (DateTime.UtcNow > requestHeader.Timestamp.AddMilliseconds(100))
                {
                    Utils.Trace(
                        "WARNING. Unexpected delay receiving Publish request. Time={0:hh:mm:ss.fff}, ReceiveTime={1:hh:mm:ss.fff}",
                        DateTime.UtcNow,
                        requestHeader.Timestamp);
                }
                */
                
                // Utils.Trace("PUBLISH #{0} RECIEVED. TIME={1:hh:hh:ss.fff}", requestHeader.RequestHandle, requestHeader.Timestamp);
                
                notificationMessage = ServerInternal.SubscriptionManager.Publish(
                    context,
                    subscriptionAcknowledgements,
                    null,
                    out subscriptionId,
                    out availableSequenceNumbers,
                    out moreNotifications,
                    out results,
                    out diagnosticInfos);

                /*
                if (notificationMessage != null)
                {
                    Utils.Trace(
                        "PublishResponse: SubId={0} SeqNo={1}, PublishTime={2:mm:ss.fff}, Time={3:mm:ss.fff}",
                        subscriptionId,
                        notificationMessage.SequenceNumber,
                        notificationMessage.PublishTime,
                        DateTime.UtcNow);
                }
                */

                return CreateResponse(requestHeader, context.StringTable);      
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }
        }

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="calldata">The calldata passed with the request.</param>
        protected override void ProcessRequest(IEndpointIncomingRequest request, object calldata)
        {
            if (request.Request.TypeId != DataTypeIds.PublishRequest)
            {
                request.CallSynchronously();
                return;
            }

            // set the context.
            SecureChannelContext.Current = request.SecureChannelContext;

            try
            {
                // begin a new publish.
                if (request.Calldata == null)
                {
                    BeginPublish(request);
                }

                // continue a previously queued publish.
                else
                {
                    CompletePublish(request);
                }
            }
            catch (Exception e)
            {
                request.OperationCompleted(null, new ServiceResult(e));
            }
        }

        /// <summary>
        /// Begins an asynchronous publish operation.
        /// </summary>
        /// <param name="request">The request.</param>
        public virtual void BeginPublish(IEndpointIncomingRequest request)
        {
            PublishRequest input = (PublishRequest)request.Request;
            OperationContext context = ValidateRequest(input.RequestHeader, RequestType.Publish);

            try
            {
                AsyncPublishOperation operation = new AsyncPublishOperation(context, request, this);
                
                 uint subscriptionId = 0;
                 UInt32Collection availableSequenceNumbers = null;
                 bool moreNotifications = false;
                 NotificationMessage notificationMessage = null;
                 StatusCodeCollection results = null;
                 DiagnosticInfoCollection diagnosticInfos = null;

                notificationMessage = ServerInternal.SubscriptionManager.Publish(
                    context,
                    input.SubscriptionAcknowledgements,
                    operation,
                    out subscriptionId,
                    out availableSequenceNumbers,
                    out moreNotifications,
                    out results,
                    out diagnosticInfos);

                // request completed asychrnously.
                if (notificationMessage != null)
                {
                    OnRequestComplete(context);

                    operation.Response.ResponseHeader = CreateResponse(input.RequestHeader, context.StringTable);
                    operation.Response.SubscriptionId = subscriptionId;
                    operation.Response.AvailableSequenceNumbers = availableSequenceNumbers;
                    operation.Response.MoreNotifications = moreNotifications;
                    operation.Response.Results = results;
                    operation.Response.DiagnosticInfos = diagnosticInfos;
                    operation.Response.NotificationMessage = notificationMessage;

                    // Utils.Trace("PUBLISH: #{0} Completed Synchronously", input.RequestHeader.RequestHandle);
                    request.OperationCompleted(operation.Response, null);
                }
            }
            catch (ServiceResultException e)
            {
                OnRequestComplete(context);

                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }
        }

        /// <summary>
        /// Completes an asynchronous publish operation.
        /// </summary>
        /// <param name="request">The request.</param>
        public virtual void CompletePublish(IEndpointIncomingRequest request)
        {
            AsyncPublishOperation operation = (AsyncPublishOperation)request.Calldata;
            OperationContext context = operation.Context;

            try
            {
                if (ServerInternal.SubscriptionManager.CompletePublish(context, operation))
                {
                    operation.Response.ResponseHeader = CreateResponse(request.Request.RequestHeader, context.StringTable);
                    request.OperationCompleted(operation.Response, null);
                    OnRequestComplete(context);
                }
            }
            catch (ServiceResultException e)
            {
                OnRequestComplete(context);

                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }
        }

        /// <summary>
        /// Invokes the Republish service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <param name="retransmitSequenceNumber">The retransmit sequence number.</param>
        /// <param name="notificationMessage">The notification message.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader Republish(
            RequestHeader           requestHeader, 
            uint                    subscriptionId, 
            uint                    retransmitSequenceNumber, 
            out NotificationMessage notificationMessage)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.Republish);

            try
            {
                notificationMessage = ServerInternal.SubscriptionManager.Republish(
                    context,
                    subscriptionId,
                    retransmitSequenceNumber);    

                return CreateResponse(requestHeader, context.StringTable);  
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }   
        }

        /// <summary>
        /// Invokes the ModifySubscription service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <param name="requestedPublishingInterval">The requested publishing interval.</param>
        /// <param name="requestedLifetimeCount">The requested lifetime count.</param>
        /// <param name="requestedMaxKeepAliveCount">The requested max keep alive count.</param>
        /// <param name="maxNotificationsPerPublish">The max notifications per publish.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="revisedPublishingInterval">The revised publishing interval.</param>
        /// <param name="revisedLifetimeCount">The revised lifetime count.</param>
        /// <param name="revisedMaxKeepAliveCount">The revised max keep alive count.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader ModifySubscription(
            RequestHeader requestHeader,
            uint          subscriptionId,
            double        requestedPublishingInterval,
            uint          requestedLifetimeCount,
            uint          requestedMaxKeepAliveCount,
            uint          maxNotificationsPerPublish,
            byte          priority,
            out double    revisedPublishingInterval,
            out uint      revisedLifetimeCount,
            out uint      revisedMaxKeepAliveCount)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.ModifySubscription);
            
            try
            {
                ServerInternal.SubscriptionManager.ModifySubscription(
                    context,
                    subscriptionId,
                    requestedPublishingInterval,
                    requestedLifetimeCount,
                    requestedMaxKeepAliveCount,
                    maxNotificationsPerPublish,
                    priority,
                    out revisedPublishingInterval,
                    out revisedLifetimeCount,
                    out revisedMaxKeepAliveCount);    

                return CreateResponse(requestHeader, context.StringTable);     
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }         
        }


        /// <summary>
        /// Invokes the SetPublishingMode service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="publishingEnabled">if set to <c>true</c> publishing is enabled.</param>
        /// <param name="subscriptionIds">The subscription ids.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a description for the ResponseHeader DataType, the return type is <seealso cref="ResponseHeader"/>
        /// </returns>
        public override ResponseHeader SetPublishingMode(
            RequestHeader                requestHeader, 
            bool                         publishingEnabled, 
            UInt32Collection             subscriptionIds, 
            out StatusCodeCollection     results, 
            out DiagnosticInfoCollection diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.SetPublishingMode);
            
            try
            {
                if (subscriptionIds == null || subscriptionIds.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }         

                ServerInternal.SubscriptionManager.SetPublishingMode(
                    context,
                    publishingEnabled,
                    subscriptionIds,
                    out results,
                    out diagnosticInfos);    

                return CreateResponse(requestHeader, context.StringTable);  
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }            
        }


        /// <summary>
        /// Invokes the CreateMonitoredItems service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <param name="timestampsToReturn">The timestamps to return.</param>
        /// <param name="itemsToCreate">The items to create.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object.
        /// </returns>
        public override ResponseHeader CreateMonitoredItems(
            RequestHeader                           requestHeader, 
            uint                                    subscriptionId, 
            TimestampsToReturn                      timestampsToReturn,
            MonitoredItemCreateRequestCollection    itemsToCreate, 
            out MonitoredItemCreateResultCollection results, 
            out DiagnosticInfoCollection            diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.CreateMonitoredItems);

            try
            {
                if (itemsToCreate == null || itemsToCreate.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }         

                ServerInternal.SubscriptionManager.CreateMonitoredItems(
                    context,
                    subscriptionId,
                    timestampsToReturn,
                    itemsToCreate,
                    out results,
                    out diagnosticInfos);    

                return CreateResponse(requestHeader, context.StringTable);     
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }  
        }


        /// <summary>
        /// Invokes the ModifyMonitoredItems service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <param name="timestampsToReturn">The timestamps to return.</param>
        /// <param name="itemsToModify">The items to modify.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader ModifyMonitoredItems(
            RequestHeader                           requestHeader, 
            uint                                    subscriptionId, 
            TimestampsToReturn                      timestampsToReturn,
            MonitoredItemModifyRequestCollection    itemsToModify, 
            out MonitoredItemModifyResultCollection results, 
            out DiagnosticInfoCollection            diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.ModifyMonitoredItems);

            try
            {
                if (itemsToModify == null || itemsToModify.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }         

                ServerInternal.SubscriptionManager.ModifyMonitoredItems(
                    context,
                    subscriptionId,
                    timestampsToReturn,
                    itemsToModify,
                    out results,
                    out diagnosticInfos);    

                return CreateResponse(requestHeader, context.StringTable);   
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }    
        }


        /// <summary>
        /// Invokes the DeleteMonitoredItems service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <param name="monitoredItemIds">The monitored item ids.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader DeleteMonitoredItems(
            RequestHeader                requestHeader, 
            uint                         subscriptionId, 
            UInt32Collection             monitoredItemIds, 
            out StatusCodeCollection     results, 
            out DiagnosticInfoCollection diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.DeleteMonitoredItems);
            
            try
            {
                if (monitoredItemIds == null || monitoredItemIds.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }         

                ServerInternal.SubscriptionManager.DeleteMonitoredItems(
                    context,
                    subscriptionId,
                    monitoredItemIds,
                    out results,
                    out diagnosticInfos);    

                return CreateResponse(requestHeader, context.StringTable);
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }
        }


        /// <summary>
        /// Invokes the SetMonitoringMode service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <param name="monitoringMode">The monitoring mode.</param>
        /// <param name="monitoredItemIds">The monitored item ids.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader SetMonitoringMode(
            RequestHeader                requestHeader,
            uint                         subscriptionId, 
            MonitoringMode               monitoringMode,
            UInt32Collection             monitoredItemIds,
            out StatusCodeCollection     results, 
            out DiagnosticInfoCollection diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.SetMonitoringMode);
                
            try
            {
                if (monitoredItemIds == null || monitoredItemIds.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }         

                ServerInternal.SubscriptionManager.SetMonitoringMode(
                    context,
                    subscriptionId,
                    monitoringMode,
                    monitoredItemIds,
                    out results,
                    out diagnosticInfos);    

                return CreateResponse(requestHeader, context.StringTable);
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }
        }


        /// <summary>
        /// Invokes the Call service.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="methodsToCall">The methods to call.</param>
        /// <param name="results">The results.</param>
        /// <param name="diagnosticInfos">The diagnostic infos.</param>
        /// <returns>
        /// Returns a ResponseHeader object
        /// </returns>
        public override ResponseHeader Call(
            RequestHeader                  requestHeader,
            CallMethodRequestCollection    methodsToCall,
            out CallMethodResultCollection results,
            out DiagnosticInfoCollection   diagnosticInfos)
        {
            OperationContext context = ValidateRequest(requestHeader, RequestType.Call);
                
            try
            {
                if (methodsToCall == null || methodsToCall.Count == 0)
                {
                    throw new ServiceResultException(StatusCodes.BadNothingToDo);
                }         

                m_serverInternal.NodeManager.Call(
                    context,
                    methodsToCall,
                    out results,
                    out diagnosticInfos);

                return CreateResponse(requestHeader, context.StringTable);
            }
            catch (ServiceResultException e)
            {
                lock (ServerInternal.DiagnosticsLock)
                {
                    ServerInternal.ServerDiagnostics.RejectedRequestsCount++;

                    if (IsSecurityError(e.StatusCode))
                    {
                        ServerInternal.ServerDiagnostics.SecurityRejectedRequestsCount++;
                    }
                }

                throw TranslateException(context, e);
            }  
            finally
            {
                OnRequestComplete(context);
            }
        }
        #endregion

        #region Public Methods used by the Host Process
        /// <summary>
        /// The state object associated with the server.
        /// </summary>
        /// <value>The current instance.</value>
        public IServerInternal CurrentInstance
        {
            get
            {
                lock (m_lock)
                {
                    if (m_serverInternal == null)
                    {                    
                        throw new ServiceResultException(StatusCodes.BadServerHalted);
                    }

                    return m_serverInternal;
                }
            }            
        }

        /// <summary>
        /// Returns the current status of the server.
        /// </summary>
        /// <returns>Returns a ServerStatusDataType object</returns>
        public ServerStatusDataType GetStatus()
        {
            lock (m_lock)
            {
                if (m_serverInternal == null)
                {
                    throw new ServiceResultException(StatusCodes.BadServerHalted);
                }

                return m_serverInternal.Status.Value;
            }
        }

        /// <summary>
        /// Registers the server with the discovery server.
        /// </summary>
        /// <returns>Boolean value.</returns>
        public bool RegisterWithDiscoveryServer()
        {
            // try each endpoint.
            foreach (ConfiguredEndpoint endpoint in m_registrationEndpoints.Endpoints)
            {
                RegistrationClient client = null;

                try
                {
                    // update from the server.
                    bool updateRequired = true;

                    lock (m_registrationLock)
                    {
                        updateRequired = endpoint.UpdateBeforeConnect;
                    }

                    if (updateRequired)
                    {
                        endpoint.UpdateFromServer(m_bindingFactory);                        
                    }
                
                    lock (m_registrationLock)
                    {
                        endpoint.UpdateBeforeConnect = false;
                    }
                    
                    // create the client.
                    client = RegistrationClient.Create(
                        base.Configuration,
                        endpoint.Description,
                        endpoint.Configuration,
                        m_bindingFactory,
                        base.InstanceCertificate);

                    // register the server.
                    RequestHeader requestHeader = new RequestHeader();
                    requestHeader.Timestamp = DateTime.UtcNow;

                    client.OperationTimeout = 10000;
                    client.RegisterServer(requestHeader, m_registrationInfo);
                    return true;
                }
                catch (Exception e)
                {                   
                    Utils.Trace("Register server failed for at: {0}. Exception={1}", endpoint.EndpointUrl, e.Message);
                }
                finally
                {
                    if (client != null)
                    {
                        try
                        {
                            client.Close();
                        }                    
                        catch (Exception e)
                        {                   
                            Utils.Trace("Could not cleanly close connection with LDS. Exception={0}", e.Message);
                        }
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// Registers the server endpoints with the LDS.
        /// </summary>
        /// <param name="state">The state.</param>
        private void OnRegisterServer(object state)
        {
            try
            {
                lock (m_registrationLock)
                {  
                    // halt any outstanding timer.
                    if (m_registrationTimer != null)
                    {
                        m_registrationTimer.Dispose();
                        m_registrationTimer = null;
                    }
                }

                if (RegisterWithDiscoveryServer())
                {
                    // schedule next registration.                        
                    lock (m_registrationLock)
                    {  
                        if (m_maxRegistrationInterval > 0)
                        {
                            m_registrationTimer = new Timer(
                                OnRegisterServer, 
                                this, 
                                m_maxRegistrationInterval, 
                                Timeout.Infinite);

                            m_lastRegistrationInterval = m_minRegistrationInterval;
                            Utils.Trace("Register server succeeded. Registering again in {0} ms", m_maxRegistrationInterval);
                        }
                    }
                }
                else
                {
                    lock (m_registrationLock)
                    {  
                        if (m_registrationTimer == null)
                        {
                            // calculate next registration attempt.
                            m_lastRegistrationInterval *= 2;

                            if (m_lastRegistrationInterval > m_maxRegistrationInterval)
                            {
                                m_lastRegistrationInterval = m_maxRegistrationInterval;
                            }

                            Utils.Trace("Register server failed. Trying again in {0} ms", m_lastRegistrationInterval);
                                      
                            // create timer.        
                            m_registrationTimer = new Timer(OnRegisterServer, this, m_lastRegistrationInterval, Timeout.Infinite);
                        }
                    }
                }
            }
            catch (Exception e)
            {                   
                Utils.Trace(e, "Unexpected exception handling registration timer.");
            }
        }
        #endregion

        #region Protected Members used for Request Processing
        /// <summary>
        /// The state object associated with the server.
        /// </summary>
        /// <value>The server internal data.</value>
        protected ServerInternalData ServerInternal
        {
            get
            {
                ServerInternalData serverInternal = m_serverInternal;

                if (serverInternal == null)
                {                    
                    throw new ServiceResultException(StatusCodes.BadServerHalted);
                }

                return serverInternal;
            }            
        }

        /// <summary>
        /// Verifies that the request header is valid.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        protected override void ValidateRequest(RequestHeader requestHeader)
        {
            // check for server error.
            ServiceResult error = ServerError;

            if (ServiceResult.IsBad(error))
            {
                throw new ServiceResultException(error);
            }
            
            // check server state.
            ServerInternalData serverInternal = m_serverInternal;

            if (serverInternal == null || serverInternal.CurrentState != Opc.Ua.ServerState.Running)
            {
                throw new ServiceResultException(StatusCodes.BadServerHalted);
            }

            base.ValidateRequest(requestHeader);
        }

        /// <summary>
        /// Updates the server state.
        /// </summary>
        /// <param name="state">The state.</param>
        protected virtual void SetServerState(ServerState state)
        {
            lock (m_lock)
            {
                if (ServiceResult.IsBad(ServerError))
                {
                    throw new ServiceResultException(ServerError);
                }

                if (m_serverInternal == null)
                {                    
                    throw new ServiceResultException(StatusCodes.BadServerHalted);
                }

                m_serverInternal.CurrentState = state;
            }
        }

        /// <summary>
        /// Reports an error during initialization after the base server object has been started.
        /// </summary>
        /// <param name="error">The error.</param>
        protected virtual void SetServerError(ServiceResult error)
        {
            lock (m_lock)
            {
                ServerError = error;
            }
        }

        /// <summary>
        /// Handles an error when validating the application instance certificate provided by a client.
        /// </summary>
        /// <param name="clientCertificate">The client certificate.</param>
        /// <param name="result">The result.</param>
        protected virtual void OnApplicationCertificateError(byte[] clientCertificate, ServiceResult result)
        {
            throw new ServiceResultException(result);
        }

        /// <summary>
        /// Inspects the software certificates provided by the server.
        /// </summary>
        /// <param name="softwareCertificates">The software certificates.</param>
        protected virtual void ValidateSoftwareCertificates(List<SoftwareCertificate> softwareCertificates)
        {
            // always accept valid certificates.
        }

        /// <summary>
        /// Verifies that the request header is valid.
        /// </summary>
        /// <param name="requestHeader">The request header.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <returns></returns>
        protected virtual OperationContext ValidateRequest(RequestHeader requestHeader, RequestType requestType)
        {
            base.ValidateRequest(requestHeader);

            if (!ServerInternal.IsRunning)
            {
                throw new ServiceResultException(StatusCodes.BadServerHalted);
            }

            OperationContext context = ServerInternal.SessionManager.ValidateRequest(requestHeader, requestType);

            Utils.Trace(
                (int)Utils.TraceMasks.Service,
                "{0} Validated. ID={1}",
                context.RequestType,
                context.RequestId);

            // notify the request manager.
            ServerInternal.RequestManager.RequestReceived(context);

            return context;
        }

        /// <summary>
        /// Translates an exception.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="e">The ServiceResultException e.</param>
        /// <returns>Returns an exception thrown when a UA defined error occurs, the return type is <seealso cref="ServiceResultException"/>.</returns>
        protected virtual ServiceResultException TranslateException(OperationContext context, ServiceResultException e)
        {
            IList<string> preferredLocales = null;

            if (context != null && context.Session != null)
            {
                preferredLocales = context.Session.PreferredLocales;
            }

            return TranslateException(context.DiagnosticsMask, preferredLocales, e);
        }

        /// <summary>
        /// Translates an exception.
        /// </summary>
        /// <param name="diagnosticsMasks">The fields to return.</param>
        /// <param name="preferredLocales">The preferred locales.</param>
        /// <param name="e">The ServiceResultException e.</param>
        /// <returns>Returns an exception thrown when a UA defined error occurs, the return type is <seealso cref="ServiceResultException"/>.</returns>
        protected virtual ServiceResultException TranslateException(DiagnosticsMasks diagnosticsMasks, IList<string> preferredLocales, ServiceResultException e)
        {
            if (e == null)
            {
                return null;
            }
            
            // check if inner result required.
            ServiceResult innerResult = null;

            if ((diagnosticsMasks & (DiagnosticsMasks.ServiceInnerDiagnostics | DiagnosticsMasks.ServiceInnerStatusCode)) != 0)
            {
                innerResult = e.InnerResult;
            }

            // check if translated text required.
            LocalizedText translatedText = null;

            if ((diagnosticsMasks & DiagnosticsMasks.ServiceLocalizedText) != 0)
            {
                translatedText = e.LocalizedText;
            }

            // create new result object.
            ServiceResult result = new ServiceResult(
                e.StatusCode,
                e.SymbolicId,
                e.NamespaceUri,
                translatedText,
                e.AdditionalInfo,
                innerResult);

            // translate result.
            result = m_serverInternal.ResourceManager.Translate(preferredLocales, result);
            return new ServiceResultException(result);
        }

        /// <summary>
        /// Translates a service result.
        /// </summary>
        /// <param name="diagnosticsMasks">The fields to return.</param>
        /// <param name="preferredLocales">The preferred locales.</param>
        /// <param name="result">The result.</param>
        /// <returns>Returns a class that combines the status code and diagnostic info structures.</returns>
        protected virtual ServiceResult TranslateResult(DiagnosticsMasks diagnosticsMasks, IList<string> preferredLocales, ServiceResult result)
        {
            if (result == null)
            {
                return null;
            }

            return m_serverInternal.ResourceManager.Translate(preferredLocales, result);
        }

        /// <summary>
        /// Verifies that the request header is valid.
        /// </summary>
        /// <param name="context">The operation context.</param>
        protected virtual void OnRequestComplete(OperationContext context)
        {
            lock (m_lock)
            {
                if (m_serverInternal == null)
                {                    
                    throw new ServiceResultException(StatusCodes.BadServerHalted);
                }
           
                m_serverInternal.RequestManager.RequestCompleted(context);
            }
        }        
        #endregion

        #region Protected Members used for Initialization
        /// <summary>
        /// Raised when the configuration changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="Opc.Ua.ConfigurationWatcherEventArgs"/> instance containing the event data.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2109:ReviewVisibleEventHandlers")]
        protected virtual void OnConfigurationChanged(object sender, ConfigurationWatcherEventArgs args)
        {
            try
            {
                ApplicationConfiguration configuration = ApplicationConfiguration.Load(
                    new FileInfo(args.FilePath),
                    Configuration.ApplicationType,
                    Configuration.GetType());

                OnUpdateConfiguration(configuration);
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Could not load updated configuration file from: {0}", args);
            }
        }

        /// <summary>
        /// Called when the server configuration is changed on disk.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <remarks>
        /// Servers are free to ignore changes if it is difficult/impossible to apply them without a restart.
        /// </remarks>
        protected override void OnUpdateConfiguration(ApplicationConfiguration configuration)
        {             
            lock (m_lock)
            {
                // update security configuration.
                configuration.SecurityConfiguration.Validate();
                
                Configuration.SecurityConfiguration.TrustedIssuerCertificates = configuration.SecurityConfiguration.TrustedIssuerCertificates;
                Configuration.SecurityConfiguration.TrustedPeerCertificates = configuration.SecurityConfiguration.TrustedPeerCertificates;
                Configuration.SecurityConfiguration.RejectedCertificateStore = configuration.SecurityConfiguration.RejectedCertificateStore;
                
                Configuration.CertificateValidator.Update(Configuration.SecurityConfiguration);

                // update trace configuration.
                Configuration.TraceConfiguration = configuration.TraceConfiguration;

                if (Configuration.TraceConfiguration == null)
                {
                    Configuration.TraceConfiguration = new TraceConfiguration();
                }

                Configuration.TraceConfiguration.ApplySettings();
            }
        }


        /// <summary>
        /// Called before the server starts.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        protected override void OnServerStarting(ApplicationConfiguration configuration)
        {
            lock (m_lock)
            {
                base.OnServerStarting(configuration);
                           
                // save minimum nonce length.
                m_minNonceLength = configuration.SecurityConfiguration.NonceLength;
            }
        }
        
        /// <summary>
        /// Creates the endpoints and creates the hosts.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="bindingFactory">The binding factory.</param>
        /// <param name="serverDescription">The server description.</param>
        /// <param name="endpoints">The endpoints.</param>
        /// <returns>
        /// Returns IList of a host for a UA service which type is <seealso cref="ServiceHost"/>.
        /// </returns>
        protected override IList<ServiceHost> InitializeServiceHosts(
            ApplicationConfiguration          configuration, 
            BindingFactory                    bindingFactory,
            out ApplicationDescription        serverDescription,
            out EndpointDescriptionCollection endpoints)
        {
            serverDescription = null;
            endpoints = null;

            Dictionary<string,ServiceHost> hosts = new Dictionary<string,ServiceHost>();

            // ensure at least one security policy exists.
            if (configuration.ServerConfiguration.SecurityPolicies.Count == 0)
            {                   
                configuration.ServerConfiguration.SecurityPolicies.Add(new ServerSecurityPolicy());
            }
            
            // ensure at least one user token policy exists.
            if (configuration.ServerConfiguration.UserTokenPolicies.Count == 0)
            {                   
                UserTokenPolicy userTokenPolicy = new UserTokenPolicy();
                
                userTokenPolicy.TokenType = UserTokenType.Anonymous;
                userTokenPolicy.PolicyId  = userTokenPolicy.TokenType.ToString();

                configuration.ServerConfiguration.UserTokenPolicies.Add(userTokenPolicy);
            }

            // build list of discovery uris.
            StringCollection discoveryUrls = new StringCollection();
            string computerName = System.Net.Dns.GetHostName();

            foreach (string baseAddress in configuration.ServerConfiguration.BaseAddresses)
            {
                UriBuilder builder = new UriBuilder(baseAddress);

                int index = baseAddress.IndexOf("localhost", StringComparison.OrdinalIgnoreCase);

                if (index == -1)
                {
                    index = baseAddress.IndexOf("{0}", StringComparison.OrdinalIgnoreCase);
                }

                if (index != -1)
                {
                    builder.Host = computerName;
                }

                if (!baseAddress.StartsWith(Utils.UriSchemeOpcTcp, StringComparison.Ordinal))
                {
                    builder.Path += "/discovery";
                }

                discoveryUrls.Add(builder.ToString());
            }                                     
                    
            // set server description.
            serverDescription = new ApplicationDescription();

            serverDescription.ApplicationUri = configuration.ApplicationUri;
            serverDescription.ApplicationName = configuration.ApplicationName;
            serverDescription.ApplicationType = configuration.ApplicationType;
            serverDescription.ProductUri = configuration.ProductUri;
            serverDescription.DiscoveryUrls = discoveryUrls;
                          
            endpoints = new EndpointDescriptionCollection();
            IList<EndpointDescription> endpointsForHost = null;

            // create hosts for protocols that require one endpoints per security policy
            foreach (ServerSecurityPolicy securityPolicy in configuration.ServerConfiguration.SecurityPolicies)
            {
                endpointsForHost = CreateSinglePolicyServiceHost(
                    hosts,
                    configuration,
                    bindingFactory, 
                    configuration.ServerConfiguration.BaseAddresses, 
                    serverDescription,
                    securityPolicy.SecurityMode, 
                    securityPolicy.SecurityPolicyUri);

                for (int ii = 0; ii < endpointsForHost.Count; ii++)
                {
                    endpointsForHost[ii].SecurityLevel = securityPolicy.SecurityLevel;
                }

                endpoints.AddRange(endpointsForHost);
            }
            
            // create hosts for protocols that allow one endpoint to support multiple policies.
            endpointsForHost = CreateMultiPolicyServiceHost(
                hosts,
                configuration,
                bindingFactory, 
                configuration.ServerConfiguration.BaseAddresses, 
                serverDescription,
                configuration.ServerConfiguration.SecurityPolicies);

            endpoints.InsertRange(0, endpointsForHost);

            return new List<ServiceHost>(hosts.Values);
        }

        /// <summary>
        /// Creates an instance of the service host.
        /// </summary>
        protected virtual ServiceHost CreateServiceHost(ServerBase server, Type endpointType, params Uri[] addresses)
        {
            return new ServiceHost(this, typeof(SessionEndpoint), addresses);
        }

        /// <summary>
        /// Create a new service host for protocols that support only one policy per host.
        /// </summary>
        /// <param name="hosts">The hosts.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="bindingFactory">The binding factory.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        /// <param name="serverDescription">The server description.</param>
        /// <param name="securityMode">The security mode.</param>
        /// <param name="securityPolicyUri">The security policy URI.</param>
        /// <returns>Returns list of descriptions for the EndpointDescription DataType, return type is list of <seealso cref="EndpointDescription"/>.</returns>
        private List<EndpointDescription> CreateSinglePolicyServiceHost(
            IDictionary<string,ServiceHost> hosts,
            ApplicationConfiguration        configuration,
            BindingFactory                  bindingFactory, 
            IList<string>                   baseAddresses,
            ApplicationDescription          serverDescription,
            MessageSecurityMode             securityMode,
            string                          securityPolicyUri)
        {
            // generate a unique host name.
            string hostName = String.Empty;

            if (hosts.ContainsKey(hostName))
            {
                hostName = Utils.Format("/{0}", SecurityPolicies.GetDisplayName(securityPolicyUri));
            }

            if (hosts.ContainsKey(hostName))
            {
                hostName += Utils.Format("/{0}", securityMode);
            }

            if (hosts.ContainsKey(hostName))
            {
                hostName += Utils.Format("/{0}", hosts.Count);
            }

            // build list of uris.
            List<Uri> uris = new List<Uri>();
            List<EndpointDescription> endpoints = new List<EndpointDescription>();
            string computerName = System.Net.Dns.GetHostName();

            for (int ii = 0; ii < baseAddresses.Count; ii++)
            {
                // UA TCP endpoints have their own host.
                if (baseAddresses[ii].StartsWith(Utils.UriSchemeOpcTcp, StringComparison.Ordinal))
                {
                    continue;
                }

                // HTTPS endpoints need no message level security.
                if (baseAddresses[ii].StartsWith(Utils.UriSchemeHttps, StringComparison.Ordinal))
                {
                    if (!String.IsNullOrEmpty(hostName))
                    {
                        continue;
                    }
                }

                UriBuilder uri = new UriBuilder(baseAddresses[ii]);

                if (String.Compare(uri.Host, "localhost", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    uri.Host = computerName;
                }

                uri.Path += hostName;
                uris.Add(uri.Uri);

                // create the endpoint description.
                EndpointDescription description = new EndpointDescription();

                description.EndpointUrl        = uri.ToString();
                description.Server             = serverDescription;
                description.ServerCertificate  = InstanceCertificate.RawData;
                description.SecurityMode       = securityMode;
                description.SecurityPolicyUri  = securityPolicyUri;
                description.UserIdentityTokens = GetUserTokenPolicies(configuration, description);
                
                if (baseAddresses[ii].StartsWith(Utils.UriSchemeHttps, StringComparison.Ordinal))
                {
                    description.SecurityMode = MessageSecurityMode.None;
                    description.SecurityPolicyUri = SecurityPolicies.None;
                }

                endpoints.Add(description);
            }

            // check if nothing to do.
            if (uris.Count == 0)
            {
                return endpoints;
            }

            // create the host.
            ServiceHost serviceHost = CreateServiceHost(this, typeof(SessionEndpoint), uris.ToArray());
            
            // create the endpoint configuration to use.
            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(configuration);
            
            // initialize the host.
            serviceHost.InitializeSinglePolicy(
                typeof(ISessionEndpoint),
                configuration, 
                bindingFactory,
                endpointConfiguration, 
                endpoints, 
                securityMode, 
                securityPolicyUri);

            if (String.IsNullOrEmpty(hostName))
            {
                serviceHost.InitializeDiscovery(configuration, serverDescription.DiscoveryUrls);
            }

            // save in server list.
            hosts[hostName] = serviceHost;

            return endpoints;
        }

        /// <summary>
        /// Create a new service host for protocols that support multiple policies per host.
        /// </summary>
        /// <param name="hosts">The hosts.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="bindingFactory">The binding factory.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        /// <param name="serverDescription">The server description.</param>
        /// <param name="securityPolicies">The security policies.</param>
        /// <returns>Returns list of descriptions for the EndpointDescription DataType, return type is list of <seealso cref="EndpointDescription"/>.</returns>
        private List<EndpointDescription> CreateMultiPolicyServiceHost(
            IDictionary<string,ServiceHost> hosts,
            ApplicationConfiguration        configuration,
            BindingFactory                  bindingFactory, 
            IList<string>                   baseAddresses,
            ApplicationDescription          serverDescription,
            List<ServerSecurityPolicy>      securityPolicies)
        {
            // generate a unique host name.
            string hostName = String.Empty;

            if (hosts.ContainsKey(hostName))
            {
                hostName = "/Tcp";
            }

            if (hosts.ContainsKey(hostName))
            {
                hostName += Utils.Format("/{0}", hosts.Count);
            }

            // check if the server if configured to use the ANSI C stack.
            bool useAnsiCStack = configuration.UseNativeStack;

            // build list of uris.
            List<Uri> uris = new List<Uri>();
            EndpointDescriptionCollection endpoints = new EndpointDescriptionCollection();

            // create the endpoint configuration to use.
            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(configuration);
            string computerName = System.Net.Dns.GetHostName();

            for (int ii = 0; ii < baseAddresses.Count; ii++)
            {
                // only UA TCP endpoints support multiple policies.
                if (!baseAddresses[ii].StartsWith(Utils.UriSchemeOpcTcp, StringComparison.Ordinal))
                {
                    continue;
                }

                UriBuilder uri = new UriBuilder(baseAddresses[ii]);

                if (String.Compare(uri.Host, "localhost", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    uri.Host = computerName;
                }

                uris.Add(uri.Uri);
                
                foreach (ServerSecurityPolicy policy in securityPolicies)
                {
                    // create the endpoint description.
                    EndpointDescription description = new EndpointDescription();

                    description.EndpointUrl         = uri.ToString();
                    description.Server              = serverDescription;
                    description.ServerCertificate   = InstanceCertificate.RawData;
                    description.SecurityMode        = policy.SecurityMode;
                    description.SecurityPolicyUri   = policy.SecurityPolicyUri;
                    description.SecurityLevel       = policy.SecurityLevel;
                    description.UserIdentityTokens  = GetUserTokenPolicies(configuration, description);
                    description.TransportProfileUri = Profiles.UaTcpTransport;

                    endpoints.Add(description);
                }
                
                #if USE_WCF_FOR_UATCP
                if (!useAnsiCStack)
                {
                    continue;
                }
                #endif

                // create the UA-TCP stack listener.
                try
                {
                    TransportListenerSettings settings = new TransportListenerSettings();

                    settings.Descriptions = endpoints;
                    settings.Configuration = endpointConfiguration;
                    settings.ServerCertificate = this.InstanceCertificate;
                    settings.CertificateValidator = configuration.CertificateValidator.GetChannelValidator();
                    settings.NamespaceUris = this.MessageContext.NamespaceUris;
                    settings.Factory = this.MessageContext.Factory;

                    ITransportListener listener = null;

                    Type type = null;

                    if (useAnsiCStack)
                    {
                        type = Type.GetType("Opc.Ua.NativeStack.NativeStackListener,Opc.Ua.NativeStackWrapper");
                    }

                    if (useAnsiCStack && type != null)
                    {
                        listener = (ITransportListener)Activator.CreateInstance(type);
                    }
                    else
                    {
                        listener = new UaTcpChannelListener();
                    }

                    listener.Open(
                       uri.Uri,
                       settings,
                       new SessionEndpoint(this));

                    TransportListeners.Add(listener);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Could not load UA-TCP Stack Listener.");
                }
            }

            #if USE_WCF_FOR_UATCP
            // check if nothing to do.
            if (useAnsiCStack || uris.Count == 0)
            {
                return endpoints;
            }
            
            // create the host.
            ServiceHost serviceHost = CreateServiceHost(this, typeof(NonHttpSessionEndpoint), uris.ToArray());

            // initialize the host.
            serviceHost.InitializeMultiPolicy(
                typeof(ISessionEndpoint),
                configuration,
                bindingFactory,
                endpointConfiguration,
                endpoints);

            // save in server list.
            hosts[hostName] = serviceHost;
            #endif

            return endpoints;
        }


        /// <summary>
        /// Starts the server application.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        protected override void StartApplication(ApplicationConfiguration configuration)
        {
            base.StartApplication(configuration);
                                        
            lock (m_lock)
            {
                try
                {
                    // create the datastore for the instance.
                    m_serverInternal = new ServerInternalData(
                        ServerProperties, 
                        configuration, 
                        MessageContext,
                        CertificateValidator,
                        InstanceCertificate);
                                        
                    // create the manager responsible for providing localized string resources.                    
                    ResourceManager resourceManager = CreateResourceManager(m_serverInternal, configuration);

                    // create the manager responsible for incoming requests.
                    RequestManager requestManager = CreateRequestManager(m_serverInternal, configuration);

                    // create the master node manager.
                    MasterNodeManager masterNodeManager = CreateMasterNodeManager(m_serverInternal, configuration);
                    
                    // add the node manager to the datastore. 
                    m_serverInternal.SetNodeManager(masterNodeManager);

                    // put the node manager into a state that allows it to be used by other objects.
                    masterNodeManager.Startup();
                    
                    // create the manager responsible for handling events.
                    EventManager eventManager = CreateEventManager(m_serverInternal, configuration);

                    // creates the server object. 
                    m_serverInternal.CreateServerObject(
                        eventManager,
                        resourceManager, 
                        requestManager);

                    // do any additional processing now that the node manager is up and running.
                    OnNodeManagerStarted(m_serverInternal);

                    // create the manager responsible for aggregates.
                    m_serverInternal.AggregateManager = CreateAggregateManager(m_serverInternal, configuration);
                    
                    // start the session manager.
                    SessionManager sessionManager = CreateSessionManager(m_serverInternal, configuration);
                    sessionManager.Startup();
                    
                    // start the subscription manager.
                    SubscriptionManager subscriptionManager = CreateSubscriptionManager(m_serverInternal, configuration);
                    subscriptionManager.Startup();
                                     
                    // add the session manager to the datastore. 
                    m_serverInternal.SetSessionManager(sessionManager, subscriptionManager);
                    
#if LEGACY_CORENODEMANAGER
                    m_serverInternal.CoreNodeManager.SuppressModelChangeEvents = false;
#endif

                    ServerError = null;
                    
                    // setup registration information.
                    lock (m_registrationLock)
                    {
                        m_bindingFactory = BindingFactory.Create(configuration, MessageContext);
                        m_maxRegistrationInterval = configuration.ServerConfiguration.MaxRegistrationInterval;

                        ApplicationDescription serverDescription = ServerDescription;

                        m_registrationInfo = new RegisteredServer();

                        m_registrationInfo.ServerUri = serverDescription.ApplicationUri;
                        m_registrationInfo.ServerNames.Add(serverDescription.ApplicationName);
                        m_registrationInfo.ProductUri = serverDescription.ProductUri;
                        m_registrationInfo.ServerType = serverDescription.ApplicationType;
                        m_registrationInfo.GatewayServerUri = null;
                        m_registrationInfo.IsOnline = true;
                        m_registrationInfo.SemaphoreFilePath = null;

                        // add all discovery urls.
                        string computerName = System.Net.Dns.GetHostName();

                        for (int ii = 0; ii < this.DiscoveryUrls.Length; ii++)
                        {
                            UriBuilder uri = new UriBuilder(DiscoveryUrls[ii]);

                            if (String.Compare(uri.Host, "localhost", StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                uri.Host = computerName;
                            }

                            m_registrationInfo.DiscoveryUrls.Add(uri.ToString());
                        }
                        
                        // build list of registration endpoints.
                        m_registrationEndpoints = new ConfiguredEndpointCollection(configuration);

                        EndpointDescription endpoint = configuration.ServerConfiguration.RegistrationEndpoint;

                        if (endpoint == null)
                        {
                            endpoint = new EndpointDescription();
                            endpoint.EndpointUrl = Utils.Format(Utils.DiscoveryUrls[0], "localhost");
                            endpoint.SecurityLevel = 0;
                            endpoint.SecurityMode = MessageSecurityMode.SignAndEncrypt;
                            endpoint.SecurityPolicyUri = SecurityPolicies.Basic128Rsa15;
                            endpoint.Server.ApplicationType = ApplicationType.DiscoveryServer;
                        }

                        m_registrationEndpoints.Add(endpoint);

                        m_minRegistrationInterval  = 1000;
                        m_lastRegistrationInterval = m_minRegistrationInterval;

                        // start registration timer.
                        if (m_registrationTimer != null)
                        {
                            m_registrationTimer.Dispose();
                            m_registrationTimer = null;
                        }

                        if (m_maxRegistrationInterval > 0)
                        {
                            m_registrationTimer = new Timer(OnRegisterServer, this, m_minRegistrationInterval, Timeout.Infinite);
                        }
                    }

                    // set the server status as running.
                    SetServerState(ServerState.Running);

                    // all initialization is complete.
                    OnServerStarted(m_serverInternal); 
                    
                    // monitor the configuration file.
                    if (!String.IsNullOrEmpty(configuration.SourceFilePath))
                    {
                        m_configurationWatcher = new ConfigurationWatcher(configuration);
                        m_configurationWatcher.Changed += new EventHandler<ConfigurationWatcherEventArgs>(this.OnConfigurationChanged);
                    }
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Unexpected error starting application");
                    m_serverInternal = null;
                    ServiceResult error = ServiceResult.Create(e, StatusCodes.BadInternalError, "Unexpected error starting application");
                    ServerError = error;
                    throw new ServiceResultException(error);
                }
            }
        }

        /// <summary>
        /// Returns the UserTokenPolicies supported by the server.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="description">The description.</param>
        /// <returns>Returns a collection of UserTokenPolicy objects, the return type is <seealso cref="UserTokenPolicyCollection"/> . </returns>
        protected virtual UserTokenPolicyCollection GetUserTokenPolicies(ApplicationConfiguration configuration, EndpointDescription description)
        {        
            UserTokenPolicyCollection policies = new UserTokenPolicyCollection();

            foreach (UserTokenPolicy policy in configuration.ServerConfiguration.UserTokenPolicies)
            {
                // ensure a security policy is specified for user tokens.
                if (description.SecurityMode == MessageSecurityMode.None)
                {
                    if (String.IsNullOrEmpty(policy.SecurityPolicyUri))
                    {
                        UserTokenPolicy clone = (UserTokenPolicy)policy.Clone();
                        clone.SecurityPolicyUri = SecurityPolicies.Basic256;
                        policies.Add(clone);
                        continue;
                    }
                }

                policies.Add(policy);
            }

            // ensure each policy has a unique id.
            for (int ii = 0; ii < policies.Count; ii++)
            {
                if (String.IsNullOrEmpty(policies[ii].PolicyId))
                {
                    policies[ii].PolicyId = Utils.Format("{0}", ii);
                }
            }

            return policies;
        }


        /// <summary>
        /// Called before the server stops
        /// </summary>
        protected override void OnServerStopping()
        {
            // halt any outstanding timer.
            lock (m_registrationLock)
            {
                if (m_registrationTimer != null)
                {
                    m_registrationTimer.Dispose();
                    m_registrationTimer = null;
                }
            }

            // attempt graceful shutdown the server.
            try
            {   
                lock (m_lock)
                {
                    if (m_serverInternal != null)
                    {
                        m_serverInternal.SubscriptionManager.Shutdown();
                        m_serverInternal.SessionManager.Shutdown();
                        m_serverInternal.NodeManager.Shutdown();
                    }
                }
            }
            catch (Exception e)
            {
                ServerError = new ServiceResult(e);   
            }
            finally
            {
                // ensure that everything is cleaned up.
                if (m_serverInternal != null)
                {
                    Utils.SilentDispose(m_serverInternal);
                    m_serverInternal = null;
                }
            }
        }

        /// <summary>
        /// Creates the request manager for the server.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>
        /// Returns an object that manages requests from within the server, return type is <seealso cref="RequestManager"/>.
        /// </returns>
        protected virtual RequestManager CreateRequestManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            return new RequestManager(server);
        }

        /// <summary>
        /// Creates the aggregate manager used by the server.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="configuration">The application configuration.</param>
        /// <returns>The manager.</returns>
        protected virtual AggregateManager CreateAggregateManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            AggregateManager manager = new AggregateManager(server);
            manager.RegisterFactory(ObjectIds.AggregateFunction_Interpolative, BrowseNames.AggregateFunction_Interpolative, Aggregators.InterpolativeFactory);
            manager.RegisterFactory(ObjectIds.AggregateFunction_Average, BrowseNames.AggregateFunction_Average, Aggregators.AverageFactory);
            manager.RegisterFactory(ObjectIds.AggregateFunction_TimeAverage, BrowseNames.AggregateFunction_TimeAverage, Aggregators.TimeAverageFactory);
            manager.RegisterFactory(ObjectIds.AggregateFunction_TimeAverage2, BrowseNames.AggregateFunction_TimeAverage2, Aggregators.TimeAverage2Factory);
            manager.RegisterFactory(ObjectIds.AggregateFunction_Start2, BrowseNames.AggregateFunction_Start2, Aggregators.Start2Factory);
            manager.RegisterFactory(ObjectIds.AggregateFunction_End2, BrowseNames.AggregateFunction_End2, Aggregators.End2Factory);
            manager.RegisterFactory(ObjectIds.AggregateFunction_Count, BrowseNames.AggregateFunction_Count, Aggregators.CountFactory);
            manager.RegisterFactory(ObjectIds.AggregateFunction_Total, BrowseNames.AggregateFunction_Total, Aggregators.TotalFactory);
            return manager;
        }
        
        /// <summary>
        /// Creates the resource manager for the server.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Returns an object that manages access to localized resources, the return type is <seealso cref="ResourceManager"/>.</returns>
        protected virtual ResourceManager CreateResourceManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            ResourceManager resourceManager = new ResourceManager(server, configuration);

            // load default text for all status codes.
            resourceManager.LoadDefaultText();

            return resourceManager;
        }

        /// <summary>
        /// Creates the master node manager for the server.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Returns the master node manager for the server, the return type is <seealso cref="MasterNodeManager"/>.</returns>
        protected virtual MasterNodeManager CreateMasterNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            return new MasterNodeManager(server, configuration, null);
        }

        /// <summary>
        /// Creates the event manager for the server.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Returns an object that manages all events raised within the server, the return type is <seealso cref="EventManager"/>.</returns>
        protected virtual EventManager CreateEventManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            return new EventManager(server, (uint)configuration.ServerConfiguration.MaxEventQueueSize);
        }

        /// <summary>
        /// Creates the session manager for the server.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Returns a generic session manager object for a server, the return type is <seealso cref="SessionManager"/>.</returns>
        protected virtual SessionManager CreateSessionManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            return new SessionManager(server, configuration);
        }

        /// <summary>
        /// Creates the session manager for the server.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Returns a generic session manager object for a server, the return type is <seealso cref="SubscriptionManager"/>.</returns>
        protected virtual SubscriptionManager CreateSubscriptionManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            return new SubscriptionManager(server, configuration);
        }

        /// <summary>
        /// Called after the node managers have been started.
        /// </summary>
        /// <param name="server">The server.</param>
        protected virtual void OnNodeManagerStarted(IServerInternal server)
        {
            // may be overridden by the subclass.
        }

        /// <summary>
        /// Called after the server has been started.
        /// </summary>
        /// <param name="server">The server.</param>
        protected virtual void OnServerStarted(IServerInternal server)
        {
            // may be overridden by the subclass.
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();    
        private ServerInternalData m_serverInternal;
        private ConfigurationWatcher m_configurationWatcher;

        private object m_registrationLock = new object();
        private ConfiguredEndpointCollection m_registrationEndpoints;
        private RegisteredServer m_registrationInfo;
        private Timer m_registrationTimer;
        private int m_minRegistrationInterval;
        private int m_maxRegistrationInterval;
        private int m_lastRegistrationInterval;
        private int m_minNonceLength;
        private BindingFactory m_bindingFactory;
        #endregion
    }
}
