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
using System.Text;
using Opc.Ua;

namespace Opc.Ua.Server
{
    /// <summary>
    /// Stores information about a NodeId specified by the client.
    /// </summary>
    /// <remarks>
    /// A NodeHandle is created when GetManagerHandle is called and will only contain
    /// information found by parsing the NodeId. The ValidateNode method is used to 
    /// verify that the NodeId refers to a real Node and find a NodeState object that 
    /// can be used to access the Node.
    /// </remarks>
    public class NodeHandle
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeHandle"/> class.
        /// </summary>
        public NodeHandle()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeHandle"/> class.
        /// </summary>
        /// <param name="nodeId">The node id.</param>
        /// <param name="node">The node.</param>
        public NodeHandle(NodeId nodeId, NodeState node)
        {
            this.NodeId = nodeId;
            this.Validated = true;
            this.Node = node;
        }
        #endregion
        
        #region Public Interface
        /// <summary>
        /// The NodeId provided by the client.
        /// </summary>
        public NodeId NodeId { get; set; }

        /// <summary>
        /// The parsed identifier (must not be null if Validated == False).
        /// </summary>
        public object ParsedNodeId { get; set; }

        /// <summary>
        /// A unique string identifier for the root of a complex object tree.
        /// </summary>
        public NodeId RootId { get; set; }

        /// <summary>
        /// A path to a component within the tree identified by the root id.
        /// </summary>
        public string ComponentPath { get; set; }

        /// <summary>
        /// An index associated with the handle.
        /// </summary>
        /// <remarks>
        /// This is used to keep track of the position in the complete list of Nodes provided by the Client.
        /// </remarks>
        public int Index { get; set; }

        /// <summary>
        /// Whether the handle has been validated.
        /// </summary>
        /// <remarks>
        /// When validation is complete the Node property must have a valid object.
        /// </remarks>
        public bool Validated { get; set; }

        /// <summary>
        /// An object that can be used to access the Node identified by the NodeId.
        /// </summary>
        /// <remarks>
        /// Not set until after the handle is validated.
        /// </remarks>
        public NodeState Node { get; set; }

        /// <summary>
        /// An object that can be used to manage the items which are monitoring the node.
        /// </summary>
        public MonitoredNode2 MonitoredNode { get; set; }
        #endregion
    }
}
