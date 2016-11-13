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
    /// An interface to an object manages one or more views.
    /// </summary>
    [Obsolete("The IViewManager interface is obsolete and is not supported. See Opc.Ua.Server.CustomNodeManager for a replacement.")]
    public interface IViewManager
    {                
        /// <summary>
        /// Determines whether a node is in a view.
        /// </summary>
        bool IsNodeInView(ViewDescription description, NodeId nodeId);
        
        /// <summary>
        /// Determines whether a reference is in a view.
        /// </summary>
        bool IsReferenceInView(ViewDescription description, ReferenceDescription reference);
    }
#endif
}
