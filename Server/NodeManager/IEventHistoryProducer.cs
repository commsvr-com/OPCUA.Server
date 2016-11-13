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
    /// An interface to a source that stores the event history associated many Objects or Views.
    /// </summary>
    [Obsolete("The IEventHistoryProducer interface is obsolete and is not supported. See Opc.Ua.Server.CustomNodeManager for a replacement.")]
    public interface IEventHistoryProducer
    {                        
        /// <summary>
        /// Reads events from the historian.
        /// </summary>
        void ReadEvents(
            OperationContext          context,
            ReadEventDetails          details,
            TimestampsToReturn        timestampsToReturn, 
            bool                      releaseContinuationPoints, 
            IList<RequestHandle>      handles,
            IList<HistoryReadValueId> nodesToRead, 
            IList<HistoryReadResult>  results, 
            IList<ServiceResult>      errors);

        /// <summary>
        /// Updates events in the historian.
        /// </summary>
        void UpdateEvents(
            OperationContext           context,
            IList<RequestHandle>       handles,
            IList<UpdateEventDetails>  nodesToUpdate, 
            IList<HistoryUpdateResult> results, 
            IList<ServiceResult>       errors);
                
        /// <summary>
        /// Deletes events in the historian.
        /// </summary>
        void DeleteEvents(
            OperationContext           context,
            IList<RequestHandle>       handles,
            IList<DeleteEventDetails>  eventsToDelete, 
            IList<HistoryUpdateResult> results, 
            IList<ServiceResult>       errors);
    }
#endif
}
