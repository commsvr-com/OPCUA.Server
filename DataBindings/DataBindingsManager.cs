//<summary>
//  Title   : Data bindings manager provides infrastructure to bind predefined nodes to the real data source.
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
using System.ComponentModel;
using System.IO;
using CAS.Lib.OPCClient.Da;
using CAS.UA.Server.DataBindings.OPCDAClient;
using CAS.UA.Server.ServerConfiguration;
using Opc.Ua;

namespace CAS.UA.Server.DataBindings
{
  /// <summary>
  /// Data bindings manager provides infrastructure to bind predefined nodes to the real data source.
  /// </summary>
  public partial class DataBindingsManager: Component
  {
    #region creators
    /// <summary>
    /// Initializes a new instance of the <see cref="DataBindingsManager"/> class.
    /// </summary>
    public DataBindingsManager()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataBindingsManager"/> class.
    /// </summary>
    /// <param name="container">The container that logically contain zero or more components.</param>
    public DataBindingsManager( IContainer container )
    {
      container.Add( this );
      InitializeComponent();
    }
    #endregion

    #region public
    /// <summary>
    /// Initializes all process data sources.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public void Initialize( CASConfiguration configuration )
    {
      m_SimulatorDictionary = new Simulator.SimulatorDictionary();
      //TODO - initialize and setup m_ExtrernalDataSource
      try
      {
        if ( !string.IsNullOrEmpty( configuration.CASExtension.CommServer.FileName ) )
        {
          m_CommServer.Initialize( CASConfiguration.PreparePathBasedOnBaseDirectory( configuration.CASExtension.CommServer.FileName).FullName );
        }
      }
      catch ( FileNotFoundException ex )
      {
        TraceEvent.Tracer.TraceError( 69, this.GetType().Name + ".Initialize",
          "Unable to find CommServer communication engine configuration file: " + ex.Message );
      }
      catch ( Exception ex )
      {
        TraceEvent.Tracer.TraceWarning( 74, this.GetType().Name + ".Initialize",
          "Unable to create CommServer communication engine: " + ex.ToString() );
      }
      try
      {
        m_OPCDAClient = new Client( CASConfiguration.PreparePathBasedOnBaseDirectory( configuration.CASExtension.OPCDAClient.FileName ).FullName );
      }
      catch ( FileNotFoundException ex )
      {
        TraceEvent.Tracer.TraceError( 83, this.GetType().Name + ".Initialize",
          "Unable to find OPC client configuration file: " + ex.Message );
      }
      catch ( Exception ex )
      {
        TraceEvent.Tracer.TraceWarning( 88, this.GetType().Name + ".Initialize",
          "Unable to create OPC client: " + ex.ToString() );
      }
      try
      {
        m_InstancesConfigurationDictionary = new InstancesConfigurationDictionary( configuration );
      }
      catch ( Exception ex )
      {
        TraceEvent.Tracer.TraceWarning( 98, this.GetType().Name + ".Initialize",
          "Unable to create InstancesConfigurationDictionary: " + ex.Message );
      }
    }
    /// <summary>
    /// Loads the nodes identifiers from file.
    /// </summary>
    /// <param name="csvFilePath">The CSV file path.</param>
    public void LoadIdentifiersFromFile( string csvFilePath )
    {
      if ( m_NodesIdentifiers == null )
        m_NodesIdentifiers = new NodesIdentifiersCollection();
      m_NodesIdentifiers.LoadIdentifiersFromStream( new FileInfo( csvFilePath ) );
    }
    /// <summary>
    /// Stops all data sources and disconnect all servers.
    /// </summary>
    public void Stop()
    {
      OPC_Interface.DisconnectAllServers();
    }
    /// <summary>
    /// Connects all serves and starts pumping the datat .
    /// </summary>
    public void Start()
    {
      OPC_Interface.SwitchOnAllServers();
    }
    /// <summary>
    /// Determines whether the specified passive node is in the nodes identifiers collection.
    /// </summary>
    /// <param name="passiveNode">The node to check.</param>
    /// <returns>
    /// 	<c>true</c> if the collection contains identifier for the specified passive node; otherwise <c>false</c>.
    /// </returns>
    private bool ContainsKey( BaseInstanceState passiveNode )
    {
      if ( m_NodesIdentifiers == null || passiveNode == null )
        return false;
      return m_NodesIdentifiers.ContainsKey( Convert.ToUInt32( passiveNode.NodeId.Identifier ) );
    }
    /// <summary>
    /// Creates the node active replacement that provides process data.
    /// </summary>
    /// <param name="context">The system context.</param>
    /// <param name="passiveNode">The passive node to be replaced.</param>
    /// <returns></returns>
    public void Create( ISystemContext context, BaseVariableState passiveNode )
    {
      if ( !ContainsKey( passiveNode ) )
        return ;
      if (m_InstancesConfigurationDictionary == null)
        return;
      string name = m_NodesIdentifiers[ Convert.ToUInt32( passiveNode.NodeId.Identifier ) ];
      string ns = context.NamespaceUris.GetString( passiveNode.NodeId.NamespaceIndex );
      InstanceConfiguration ds = m_InstancesConfigurationDictionary.Find( ns, name );
      Create( passiveNode, ds );
    }
    #endregion

    #region private
    /// <summary>
    /// Creates an active wrappers that will be used to replace the passive <see cref="source"/> node created as predefined nodes.
    /// </summary>
    /// <param name="context">The system context.</param>
    /// <param name="source">The source noded to be replaced by the created wrapper.</param>
    /// <param name="dataSourceConfiguration">The data source configuration.</param>
    /// <returns></returns>
    private void Create( BaseVariableState source, InstanceConfiguration dataSourceConfiguration )
    {
      if ( source is BaseDataVariableState )
      {
        new VariableMediator( source, dataSourceConfiguration );
        source.AccessLevel = source.UserAccessLevel;
      }
      else if ( source is PropertyState ){
        new VariableMediator( source, dataSourceConfiguration );
        source.AccessLevel = source.UserAccessLevel;
      }
      else
        TraceEvent.Tracer.TraceError( 49, this.GetType().Name, "Node is not supported: " + source.GetType().ToString() );
    }
    private Client m_OPCDAClient;
    private NodesIdentifiersCollection m_NodesIdentifiers;
    private InstancesConfigurationDictionary m_InstancesConfigurationDictionary;
    private Simulator.SimulatorDictionary m_SimulatorDictionary;
    #endregion

  }
}
