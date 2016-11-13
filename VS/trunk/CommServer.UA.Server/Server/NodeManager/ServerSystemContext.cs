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

namespace Opc.Ua.Server
{
    /// <summary>
    /// A generic implementation for ISystemContext interface.
    /// </summary>
    public class ServerSystemContext : Opc.Ua.SystemContext
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemContext"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        public ServerSystemContext(IServerInternal server)
        {
            OperationContext = null;
            NamespaceUris = server.NamespaceUris;
            ServerUris = server.ServerUris;
            TypeTable = server.TypeTree;
            EncodeableFactory = server.Factory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemContext"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="context">The context.</param>
        public ServerSystemContext(IServerInternal server, OperationContext context)
        {
            OperationContext = context;
            NamespaceUris = server.NamespaceUris;
            ServerUris = server.ServerUris;
            TypeTable = server.TypeTree;
            EncodeableFactory = server.Factory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemContext"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="session">The session.</param>
        public ServerSystemContext(IServerInternal server, Session session)
        {
            OperationContext = null;
            SessionId = session.Id;
            UserIdentity = session.Identity;
            PreferredLocales = session.PreferredLocales;
            NamespaceUris = server.NamespaceUris;
            ServerUris = server.ServerUris;
            TypeTable = server.TypeTree;
            EncodeableFactory = server.Factory;
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The operation context associated with system context.
        /// </summary>
        /// <value>The operation context.</value>
        public new OperationContext OperationContext
        {
            get { return base.OperationContext as OperationContext; } 
            set { base.OperationContext = value; }
        }

        /// <summary>
        /// Creates a copy of the context that can be used with the specified operation context.
        /// </summary>
        /// <returns>A copy of the system context.</returns>
        public ServerSystemContext Copy()
        {
            return (ServerSystemContext)MemberwiseClone();
        }

        /// <summary>
        /// Creates a copy of the context that can be used with the specified operation context.
        /// </summary>
        /// <param name="context">The operation context to use.</param>
        /// <returns>
        /// A copy of the system context that references the new operation context.
        /// </returns>
        public ServerSystemContext Copy(OperationContext context)
        {
            ServerSystemContext copy = (ServerSystemContext)MemberwiseClone();

            if (context != null)
            {
                copy.OperationContext = context;
            }

            return copy;
        }

        /// <summary>
        /// Creates a copy of the context that can be used with the specified session.
        /// </summary>
        /// <param name="session">The session to use.</param>
        /// <returns>
        /// A copy of the system context that references the new operation context.
        /// </returns>
        public ServerSystemContext Copy(Session session)
        {
            ServerSystemContext copy = (ServerSystemContext)MemberwiseClone();

            OperationContext = null;

            if (session != null)
            {
                SessionId = session.Id;
                UserIdentity = session.Identity;
                PreferredLocales = session.PreferredLocales;
            }
            else
            {
                SessionId = null;
                UserIdentity = null;
                PreferredLocales = null;
            }

            return copy;
        }

        /// <summary>
        /// Creates a copy of the context that can be used with the specified session.
        /// </summary>
        /// <param name="context">The session to use.</param>
        /// <returns>
        /// A copy of the system context that references the new operation context.
        /// </returns>
        public ServerSystemContext Copy(ServerSystemContext context)
        {
            ServerSystemContext copy = (ServerSystemContext)MemberwiseClone();

            if (context != null)
            {
                OperationContext = context.OperationContext;
                SessionId = context.SessionId;
                UserIdentity = context.UserIdentity;
                PreferredLocales = context.PreferredLocales;
                NamespaceUris = context.NamespaceUris;
                ServerUris = context.ServerUris;
                TypeTable = context.TypeTable;
                EncodeableFactory = context.EncodeableFactory;
            }

            return copy;
        }
        #endregion
    }
}
