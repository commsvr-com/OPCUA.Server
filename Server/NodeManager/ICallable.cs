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
    /// An interface to a object that exposes methods
    /// </summary>
    [Obsolete("The ICallable interface is obsolete and is not supported. See Opc.Ua.Server.CustomNodeManager for a replacement.")]
    public interface ICallable
    {                        
        /// <summary>
        /// Calls a method defined on a object.
        /// </summary>
        /// <remarks>
        /// The caller ensures that there are the correct number of input arguments and that they
        /// have the correct data type and array size. The implementor may return other validation 
        /// errors for input arguments.
        /// 
        /// Arguments that were not specified are passed as null.
        /// 
        /// If an input argument is invalid the implementor must return BadInvalidArgument and set 
        /// the appropriate errors in the argumentErrors list.
        /// </remarks>
        ServiceResult Call(
            OperationContext     context, 
            NodeId               methodId, 
            object               methodHandle, 
            NodeId               objectId, 
            IList<object>        inputArguments,
            IList<ServiceResult> argumentErrors, 
            IList<object>        outputArguments);
    }
#endif
}
