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
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace Opc.Ua.Server
{
    /// <summary>
    /// The set of all service request types (used for collecting diagnostics and checking permissions).
    /// </summary>
    public enum RequestType
    {
        /// <summary>
        /// The request type is not known.
        /// </summary>
		Unknown,

        /// <see cref="IDiscoveryServer.FindServers" />
		FindServers,

        /// <see cref="IDiscoveryServer.GetEndpoints" />
		GetEndpoints,

        /// <see cref="ISessionServer.CreateSession" />
		CreateSession,

        /// <see cref="ISessionServer.ActivateSession" />
		ActivateSession,

        /// <see cref="ISessionServer.CloseSession" />
		CloseSession,

        /// <see cref="ISessionServer.Cancel" />
		Cancel,

        /// <see cref="ISessionServer.Read" />
		Read,

        /// <see cref="ISessionServer.HistoryRead" />
		HistoryRead,

        /// <see cref="ISessionServer.Write" />
		Write,

        /// <see cref="ISessionServer.HistoryUpdate" />
		HistoryUpdate,

        /// <see cref="ISessionServer.Call" />
		Call,

        /// <see cref="ISessionServer.CreateMonitoredItems" />
		CreateMonitoredItems,

        /// <see cref="ISessionServer.ModifyMonitoredItems" />
		ModifyMonitoredItems,

        /// <see cref="ISessionServer.SetMonitoringMode" />
		SetMonitoringMode,

        /// <see cref="ISessionServer.SetTriggering" />
		SetTriggering,

        /// <see cref="ISessionServer.DeleteMonitoredItems" />
		DeleteMonitoredItems,

        /// <see cref="ISessionServer.CreateSubscription" />
		CreateSubscription,

        /// <see cref="ISessionServer.ModifySubscription" />
		ModifySubscription,

        /// <see cref="ISessionServer.SetPublishingMode" />
		SetPublishingMode,

        /// <see cref="ISessionServer.Publish" />
		Publish,

        /// <see cref="ISessionServer.Republish" />
		Republish,

        /// <see cref="ISessionServer.TransferSubscriptions" />
		TransferSubscriptions,

        /// <see cref="ISessionServer.DeleteSubscriptions" />
		DeleteSubscriptions,

        /// <see cref="ISessionServer.AddNodes" />
		AddNodes,

        /// <see cref="ISessionServer.AddReferences" />
		AddReferences,

        /// <see cref="ISessionServer.DeleteNodes" />
		DeleteNodes,

        /// <see cref="ISessionServer.DeleteReferences" />
		DeleteReferences,

        /// <see cref="ISessionServer.Browse" />
		Browse,

        /// <see cref="ISessionServer.BrowseNext" />
		BrowseNext,

        /// <see cref="ISessionServer.TranslateBrowsePathsToNodeIds" />
		TranslateBrowsePathsToNodeIds,

        /// <see cref="ISessionServer.QueryFirst" />
		QueryFirst,

        /// <see cref="ISessionServer.QueryNext" />
		QueryNext,

        /// <see cref="ISessionServer.RegisterNodes" />
		RegisterNodes,

        /// <see cref="ISessionServer.UnregisterNodes" />
		UnregisterNodes
    }
}
