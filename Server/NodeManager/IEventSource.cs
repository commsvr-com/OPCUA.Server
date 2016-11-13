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
using System.Reflection;
using System.Collections.Generic;

namespace Opc.Ua.Server
{    
#if LEGACY_CORENODEMANAGER
    /// <summary>
    /// An interface to an object monitors for events and reports them when they occur.
    /// </summary>
    [Obsolete("The IEventSource interface is obsolete and is not supported. See Opc.Ua.Server.CustomNodeManager for a replacement.")]
    public interface IEventSource
    {
        /// <summary>
        /// Subscribes/unsubscribes to events for the specified notifier.
        /// </summary>
        /// <remarks>
        /// This method may be called multiple times for the name monitoredItemId if the
        /// context for that MonitoredItem changes (i.e. UserIdentity and/or Locales).
        /// </remarks>
        void SubscribeToEvents(
            OperationContext    context,
            object              notifier, 
            uint                subscriptionId,
            IEventMonitoredItem monitoredItem,
            bool                unsubscribe);
        
        /// <summary>
        /// Subscribes/unsubscribes to all events from the source.
        /// </summary>
        /// <remarks>
        /// This method may be called multiple times for the name monitoredItemId if the
        /// context for that MonitoredItem changes (i.e. UserIdentity and/or Locales).
        /// </remarks>
        void SubscribeToAllEvents(            
            OperationContext    context,
            uint                subscriptionId,
            IEventMonitoredItem monitoredItem,
            bool                unsubscribe);

        /// <summary>
        /// Tells the source to refresh all conditions.
        /// </summary>
        void ConditionRefresh(            
            OperationContext           context,
            IList<IEventMonitoredItem> monitoredItems);
    }
#endif
}
