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
    /// The current publishing state for a subcription.
    /// </summary>  
    public enum PublishingState
    {
        /// <summary>
        /// The subscription is not ready to publish.
        /// </summary>
        Idle,

        /// <summary>
        /// The subscription has notifications that are ready to publish.
        /// </summary>
        NotificationsAvailable,

        /// <summary>
        /// The has already indicated that it is waiting for a publish request.
        /// </summary>
        WaitingForPublish,

        /// <summary>
        /// The subscription has expired.
        /// </summary>
        Expired
    }
}
