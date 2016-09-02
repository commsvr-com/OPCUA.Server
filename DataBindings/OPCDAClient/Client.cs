//<summary>
//  Title   : Client OPC for bindongs in OPC UA Server
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
using System.ComponentModel;
using CAS.DataPorter.Configurator;
using CAS.Lib.DeviceSimulator;
using CAS.Lib.OPCClient.Da;
using CAS.Lib.OPCClient.Da.Management;
using Opc.Da;

namespace CAS.UA.Server.DataBindings.OPCDAClient
{
  internal sealed class Client: SortedDictionary<string, I4UAServer>
  {
    #region creator
    public Client( string fileName )
      : base()
    {
      Initialize( fileName );
      m_Me = this;
    }
    #endregion

    #region public
    internal static I4UAServer Find( string serverName, string subscriptionName, string itemName )
    {
      string name = String.Format( "{0}/{1}/{2}", serverName, subscriptionName, itemName );
      if ( m_Me != null )
      {
        if ( m_Me.ContainsKey( name ) )
        {
          TraceEvent.Tracer.TraceVerbose( 45, typeof( Client ).Name + ".Find", String.Format( "Item : {0} is added as OPC source",
             name ) );
          return m_Me[ name ];
        }
        else
        {
          TraceEvent.Tracer.TraceInformation( 51, typeof( Client ).Name + ".Find", String.Format( "Item : is not added (cannot be found) as OPC source {0}",
            name ) );
        }
      }
      else
      {
        TraceEvent.Tracer.TraceWarning( 57, typeof( Client ).Name + ".Find", String.Format( "Item : is not added (OPC Client is not connected (created)) as OPC source {0}",
          name ) );
      }
      return null;
    }
    #endregion

    #region private
    /// <summary>
    /// Initializes the specified OPC DA Clent.
    /// </summary>
    /// <param name="fileName">Name of the file containing the configuration of the client.</param>
    private void Initialize( string fileName )
    {
      if ( string.IsNullOrEmpty( fileName ) )
        return;
      using ( ConfigurationManagement cm = new ConfigurationManagement() )
      {
        cm.ReadConfiguration( fileName );
        foreach ( OPCCliConfiguration.ServersRow srvdsc in cm.Configuartion.Servers )
          try
          {
            //server initialization
            CrateServer( srvdsc, ref m_VolumeConstrain );
          }
          catch ( Exception ex )
          {
            TraceEvent.Tracer.TraceWarning( 51, this.GetType().Name + ".Initialize",
              "Unable to create OPC interface server: " + ex.Message );
          }
      }
    }
    /// <summary>
    /// Creates new instance of an OPC client and
    /// </summary>
    /// <param name="server">The server.</param>
    /// <param name="volumeConstrain">The  volume constrain.</param>
    private void CrateServer( OPCCliConfiguration.ServersRow server, ref uint? volumeConstrain )
    {
      OPC_Interface m_Server = new OPC_Interface( server.PreferedSpecification, server.URL, server.Name );
      foreach ( OPCCliConfiguration.SubscriptionsRow group in server.GetSubscriptionsRows() )
        OPCClientGroup( group, group.GetItemsRows(), m_Server, ref volumeConstrain );
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="OPCClientGroup"/> class.
    /// </summary>
    /// <param name="group">The group description from XML configuration file<see cref="OPCCliConfiguration.SubscriptionsRow"/>.</param>
    /// <param name="items">The table of items <see cref="OPCCliConfiguration.ItemsRow"/>.</param>
    /// <param name="server">Server that this group should belong to</param>
    /// <param name="parent">The parent.</param>
    /// <param name="volumeConstrain">The volume constrain.</param>
    private void OPCClientGroup
      (
      OPCCliConfiguration.SubscriptionsRow group,
      OPCCliConfiguration.ItemsRow[] items,
      OPC_Interface server,
      ref uint? volumeConstrain
      )
    {
      if ( volumeConstrain.HasValue )
        if ( volumeConstrain.Value < items.Length )
          throw new LicenseException( typeof( DataBindingsManager ), this, CAS.Lib.CodeProtect.Properties.Resources.Tx_LicVolumeConstrainErr );
        else
          volumeConstrain = volumeConstrain.Value - Convert.ToUInt32( items.Length );
      SubscriptionState state = group.CreateSubscriptionState;
      OPC_Interface.OPCGroup m_OPCGroup;
      m_OPCGroup = server.CreateOPCGroup( (uint)group.ID, (uint)group.ID_server, group.Asynchronous, state );
      m_OPCGroup.Tags = Tags( items, server, m_OPCGroup );
    }
    private OPC_Interface.OPC_Interface_Tag[] Tags
      ( OPCCliConfiguration.ItemsRow[] items, OPC_Interface server, OPC_Interface.OPCGroup oPCGroup )
    {
      OPC_Interface.OPC_Interface_Tag[] tags = new OPC_Interface.OPC_Interface_Tag[ items.Length ];
      int idx = 0;
      #region foreach ( OPCCliConfiguration.ItemsRow row in items )
      foreach ( OPCCliConfiguration.ItemsRow row in items )
      {
        Opc.Da.Item item = row.Item;
        double measurement_low = double.NaN;
        double measurement_hi = double.NaN;
        double engineer_low = double.NaN;
        double engineer_hi = double.NaN;
        OPCCliConfiguration.ConversionsRow[] conversions = row.GetConversionsRows();
        if ( conversions.Length > 0 )
        {
          if ( conversions.Length != 1 )
            throw new Exception( "Too many ConversionsRows for item " + row.Name );
          //musimy konwersje uruchomic
          measurement_low = conversions[ 0 ].MeasuredValue1;
          measurement_hi = conversions[ 0 ].MeasuredValue2;
          engineer_low = conversions[ 0 ].EngineeringValue1;
          engineer_hi = conversions[ 0 ].EngineeringValue2;
        }
        OPCTag tagStatistics =
          new OPCTag( (uint)row.ID, row.Item, measurement_low, measurement_hi, engineer_low, engineer_hi );
        string path = server.Name + "/" + oPCGroup.Name + "/";
        OPC_Interface.OPC_Interface_Tag tag = new OPC_Interface.OPC_Interface_Tag
            ( tagStatistics, oPCGroup, null, Opc.Da.qualityBits.badNotConnected, null, path, row.Item );
        tag.ClientHandle = idx;
        tags[ idx++ ] = tag;
        this.Add( UniqueIdentyfier( server.Name, oPCGroup.Name, row.Name ), tag );
      }
      #endregion foreach ( OPCCliConfiguration.ItemsRow row in items )
      return tags;
    }
    private static string UniqueIdentyfier( string serverName, string subscriptionName, string itemName )
    {
      return String.Format( "{0}/{1}/{2}", serverName, subscriptionName, itemName );
    }
    private uint? m_VolumeConstrain = uint.MaxValue;
    private static Client m_Me;
    #endregion
  }
}
