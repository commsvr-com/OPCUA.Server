//<summary>
//  Title   : Name of Application
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
using CAS.UA.Server.ServerConfiguration;
using System.Linq;

namespace CAS.UA.Server.DataBindings
{
  /// <summary>
  /// Instance of this class is a collection of all instances configurations defined in the configuration file.
  /// </summary>
  internal class InstancesConfigurationDictionary : SortedDictionary<string, InstanceConfiguration>
  {
    #region creators
    /// <summary>
    /// Initializes a new instance of the <see cref="InstancesConfigurationDictionary"/> class from the configuration file.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public InstancesConfigurationDictionary(CASConfiguration configuration)
    {
      TraceEvent.Tracer.TraceVerbose(37, this.GetType().Name + ".InstancesConfigurationDictionary", "At creating process data binding dictionary");
      foreach (InstanceConfiguration item in configuration.CASExtension.NodesConfiguration)
      {
        string key = String.Format(m_KeyFormat, item.NodeDescriptor.NodeIdentifier.Namespace, item.NodeDescriptor.NodeIdentifier.Name);
        string _db = String.Format("{0}: {1}", item.NodeDescriptor, String.Join("'", item.DataSources == null ? new string[] { "No Defined" } : 
                                                                                                                item.DataSources.Select<DataSourceConfiguration, string>(x => x.ToString()).ToArray<string>()));
        TraceEvent.Tracer.TraceVerbose(37, "Add new item", String.Format("Key: {0} Binding: {1}", key, _db));
        this.Add(key, item);
      }
      TraceEvent.Tracer.TraceVerbose(37, this.GetType().Name + ".InstancesConfigurationDictionary", "Finished process data binding dictionary creation");
    }
    #endregion

    #region public
    /// <summary>
    /// Finds the specified instance node by the <see cref="ns"/> and  <see cref="name"/> instance configuration of the<see cref="DataSourceConfiguration"/> type.
    /// </summary>
    /// <param name="nameSpace">The namespace.</param>
    /// <param name="name">The name of the node.</param>
    /// <returns>Instance of <see cref="InstanceConfiguration"/> that provides configuration of the instance node.</returns>
    public InstanceConfiguration Find(string nameSpace, string name)
    {
      string key = String.Format(m_KeyFormat, nameSpace, name);
      if (this.ContainsKey(key))
      {
        TraceEvent.Tracer.TraceVerbose(54, this.GetType().Name + ".Find", String.Format("Key: {0} is found", key));
        return this[key];
      }
      else
      {
        TraceEvent.Tracer.TraceInformation(59, this.GetType().Name + ".Find", String.Format("Key: {0} is not found - Simulator Source is used instead", key));
        DataSourceConfiguration defDataSourceConfiguration = new DataSourceConfiguration()
        {
          Name = key,
          SelectedSource = DataSourceConfiguration.Source.None,
          SelectedSourceConfigurationBrowse = new DefaultSimulatorSourceConfiguration()
          {
            Selected = true,
            Name = key
          }
        };
        return new InstanceConfiguration(new DataSourceConfiguration[] { defDataSourceConfiguration }, nameSpace, name);
      }
    }
    #endregion

    #region private
    private const string m_KeyFormat = "{0}_{1}";
    #endregion

  }
  internal class DefaultSimulatorSourceConfiguration : DefaultSourceConfiguration
  {
    /// <summary>
    /// Gets or sets the name of the item.
    /// </summary>
    /// <value>The item name.</value>
    public string Name
    {
      get { return m_Name; }
      set { m_Name = value; }
    }
    private string m_Name;
  }
}
