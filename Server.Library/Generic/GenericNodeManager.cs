//<summary>
//  Title   : A generic node manager that creates the address space from configuration and predefined nodes.
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CAS.UA.Common;
using CAS.UA.Server.DataBindings;
using CAS.UA.Server.Library.Base;
using CAS.UA.Server.ServerConfiguration;
using Opc.Ua;

namespace CAS.UA.Server.Library.Generic
{
  /// <summary>
  /// A generic node manager that creates the address space from configuration and predefined nodes.
  /// </summary>
  public class GenericNodeManager: CustomNodeManager2
  {
    #region Constructors
    /// <summary>
    /// Initializes the node manager.
    /// </summary>
    /// <param name="server">The interface that a server exposes to objects that it contains..</param>
    /// <param name="configuration">Configuration for the server.</param>
    /// <param name="dataBindings">Data bindings manager provides infrastructure to bind predefined nodes to the real data source.</param>
    public GenericNodeManager
      (
        Opc.Ua.Server.IServerInternal server, CASConfiguration configuration, DataBindingsManager dataBindings
      )
      : base( server )
    {
      m_SampleConfiguration = configuration;
      m_DataBindings = dataBindings;
      List<FilePaths> m_allPredefinedNodesList = new List<FilePaths>();
      List<string> nsList = new List<string>();
      foreach ( ModelLayer ml in m_SampleConfiguration.CASExtension.ModelLayers )
      {
        nsList.Add( ml.NamespaceUri );
        m_allPredefinedNodesList.Add( new FilePaths(ml.FilePathUanodes,ml.FilePathCsv ));
      }
      NamespaceUris = nsList.ToArray();
      m_allPredefinedNodes = m_allPredefinedNodesList.ToArray();
      if ( m_SampleConfiguration.CASExtension.ModelLayers != null && m_SampleConfiguration.CASExtension.ModelLayers.Length > 0 )
      {
        TraceEvent.Tracer.TraceVerbose( 52, this.GetType().Name + ".ctor", "m_namespaceIndex:" + m_SampleConfiguration.CASExtension.ModelLayers[ 0 ] );
        m_namespaceIndex = Server.NamespaceUris.GetIndexOrAppend( m_SampleConfiguration.CASExtension.ModelLayers[ 0 ].NamespaceUri );
      }
      else
      {
        TraceEvent.Tracer.TraceError(69,this.GetType().Name+".ctor","No namespaces are defined");
      }
      m_lastUsedId = 0;
    }
    #endregion

    #region INodeIdFactory Members
    /// <summary>
    /// Creates the NodeId for the specified node.
    /// </summary>
    /// <param name="context">An interface to an object that describes how access the system containing the data..</param>
    /// <param name="node">The node.</param>
    /// <returns>The new NodeId.</returns>
    public override NodeId New( ISystemContext context, NodeState node )
    {
      uint id = Utils.IncrementIdentifier( ref m_lastUsedId );
      return new NodeId( id, m_namespaceIndex );
    }
    #endregion

    #region INodeManager Members
    /// <summary>
    /// Does any initialization required before the address space can be used.
    /// </summary>
    /// <remarks>
    /// The externalReferences is an out parameter that allows the node manager to link to nodes
    /// in other node managers. For example, the 'Objects' node is managed by the CoreNodeManager and
    /// should have a reference to the root folder node(s) exposed by this node manager.  
    /// </remarks>
    public override void CreateAddressSpace( IDictionary<NodeId, IList<IReference>> externalReferences )
    {
      lock ( Lock )
      {
        base.CreateAddressSpace( externalReferences );

      }
    }
    /// <summary>
    /// Updates the display name for an instance with the unit label name.
    /// </summary>
    /// <param name="instance">The instance to update.</param>
    /// <param name="unitLabel">The unit label.</param>
    /// <remarks>This method assumes the DisplayName has the form NameX001 where X0 is the unit label placeholder.</remarks>
    private void UpdateDisplayName( BaseInstanceState instance, string unitLabel )
    {
      LocalizedText displayName = instance.DisplayName;

      if ( displayName != null )
      {
        string text = displayName.Text;

        if ( text != null )
        {
          text = text.Replace( "X0", unitLabel );
        }

        displayName = new LocalizedText( displayName.Locale, text );
      }

      instance.DisplayName = displayName;
    }

    /// <summary>
    /// Loads a node set from a file or resource and addes them to the set of predefined nodes.
    /// </summary>
    protected override NodeStateCollection LoadPredefinedNodes( ISystemContext context )
    {
      NodeStateCollection predefinedNodes = new NodeStateCollection();
      for ( int ix = 0; ix < m_allPredefinedNodes.Length; ix++ )
      {
        FileInfo fiPredifinedNodes = CASConfiguration.PreparePathBasedOnBaseDirectory( m_allPredefinedNodes[ ix ].PredefinedNodes );
        using ( Stream reader = File.Open( fiPredifinedNodes.FullName, FileMode.Open ) )
        {
          predefinedNodes.LoadFromBinary( context, reader, true );
        }
        FileInfo csvFi = CASConfiguration.PreparePathBasedOnBaseDirectory( m_allPredefinedNodes[ ix ].CSVFile );
        m_DataBindings.LoadIdentifiersFromFile( csvFi.FullName );
      }
      return predefinedNodes;
    }

    /// <summary>
    /// Replaces the generic node with a node specific to the model.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="predefinedNode"></param>
    /// <returns></returns>
    protected override NodeState AddBehaviourToPredefinedNode( ISystemContext context, NodeState predefinedNode )
    {
      BaseVariableState passiveNode = predefinedNode as BaseVariableState;
      if ( passiveNode == null || passiveNode.NodeId.IdType != IdType.Numeric )
        return predefinedNode;
      if ( !InstanceDeclaration( passiveNode ) )
        return predefinedNode;
      m_DataBindings.Create( context, passiveNode );
      return predefinedNode;
    }
    private bool InstanceDeclaration( BaseInstanceState node )
    {
      if ( node.Parent == null )
        return true;
      BaseInstanceState parent = node.Parent as BaseInstanceState;
      if ( parent == null )
        return false;
      return InstanceDeclaration( parent );
    }
    /// <summary>
    /// Does any processing after a monitored item is created.
    /// </summary>
    protected override void OnCreateMonitoredItem(
        ISystemContext systemContext,
        MonitoredItemCreateRequest itemToCreate,
        MonitoredNode monitoredNode,
        DataChangeMonitoredItem monitoredItem )
    {
      // TBD
    }

    /// <summary>
    /// Does any processing after a monitored item is created.
    /// </summary>
    protected override void OnModifyMonitoredItem(
        ISystemContext systemContext,
        MonitoredItemModifyRequest itemToModify,
        MonitoredNode monitoredNode,
        DataChangeMonitoredItem monitoredItem,
        double previousSamplingInterval )
    {
      // TBD
    }

    /// <summary>
    /// Does any processing after a monitored item is deleted.
    /// </summary>
    protected override void OnDeleteMonitoredItem(
        ISystemContext systemContext,
        MonitoredNode monitoredNode,
        DataChangeMonitoredItem monitoredItem )
    {
      // TBD
    }

    /// <summary>
    /// Does any processing after a monitored item is created.
    /// </summary>
    protected override void OnSetMonitoringMode(
        ISystemContext systemContext,
        MonitoredNode monitoredNode,
        DataChangeMonitoredItem monitoredItem,
        MonitoringMode previousMode,
        MonitoringMode currentMode )
    {
      // TBD
    }
    #endregion

    #region Private Fields
    private struct FilePaths
    {
      public string PredefinedNodes;
      public string CSVFile;
      public FilePaths( string predefinedNodes, string csvFile )
      {
        PredefinedNodes = predefinedNodes;
        CSVFile = csvFile;
      }
      }
    private CASConfiguration m_SampleConfiguration;
    private CAS.UA.Server.DataBindings.DataBindingsManager m_DataBindings;
    private ushort m_namespaceIndex;
    private long m_lastUsedId;
    private FilePaths[] m_allPredefinedNodes;
    #endregion
  }
}
