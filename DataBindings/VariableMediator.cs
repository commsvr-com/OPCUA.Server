//<summary>
//  Title   : Interconnects an instance of BaseDataVariableState with data source.
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

using CAS.Lib.DeviceSimulator;
using CAS.UA.Server.DataBindings.Properties;
using CAS.UA.Server.ServerConfiguration;
using Opc.Ua;
using System;

namespace CAS.UA.Server.DataBindings
{
  /// <summary>
  /// Interconnects an instance of BaseDataVariableState with data source.
  /// </summary>
  internal class VariableMediator
  {
    public VariableMediator(BaseVariableState variable, InstanceConfiguration dataSourceConfiguration)
    {
      m_variable = variable;
      //TODO MOdelCompiler assigns wrong value for AccessLevel, so we use UserAccessLevel that van be assigned in the model.
      variable.AccessLevel = variable.UserAccessLevel;
      m_variable.OnWriteValue = new NodeValueEventHandler(My_OnNodeWriteEventHandler);
      m_variable.OnStateChanged = new NodeStateChangedHandler(My_OnDeleteEventHandler);
      GetBindings(variable, dataSourceConfiguration);
    }

    #region private
    private void GetBindings(BaseVariableState source, InstanceConfiguration dataSourceConfiguration)
    {
      foreach (DataSourceConfiguration item in dataSourceConfiguration.DataSources)
      {
        TraceEvent.Tracer.TraceVerbose(49, this.GetType().Name + ".GetBindings", String.Format("Item name: {0}, source: {1}",
          item.Name, item.SelectedSource));
        BuiltInType nt = TypeInfo.GetBuiltInType(source.DataType);
        switch (item.SelectedSource)
        {
          case DataSourceConfiguration.Source.None:
            DefaultSimulatorSourceConfiguration noneSC = item.SelectedSourceConfigurationBrowse as DefaultSimulatorSourceConfiguration;
            if (noneSC.Selected && Settings.Default.AutoBindingToSimulatorForNotConfiguredVariables)
            {
              SimulatorInterface = Simulator.SimulatorDictionary.Find
                (false, nt, noneSC.Name, new TimeSpan(0, 0, 0, 0, 500));
              m_variable.AccessLevel = 1;
            }
            break;
          case DataSourceConfiguration.Source.OPCClient:
            OPCDAClientSourceConfiguration opcclientSC = item.SelectedSourceConfiguration as OPCDAClientSourceConfiguration;
            if (opcclientSC.Selected)
              OPCDAInterface = OPCDAClient.Client.Find(opcclientSC.ServerName, opcclientSC.SubscriptionName, opcclientSC.ItemName);
            break;
          case DataSourceConfiguration.Source.CommServer:
            CommServerSourceConfiguration commSvrSC = item.SelectedSourceConfiguration as CommServerSourceConfiguration;
            if (commSvrSC.Selected && !String.IsNullOrEmpty(commSvrSC.ItemName))
              CommServerInterface = CAS.Lib.DeviceSimulator.Device.Find(commSvrSC.ItemName);
            break;
          case DataSourceConfiguration.Source.Simulator:
            SimulatorSourceConfiguration simulatorSC = item.SelectedSourceConfiguration as SimulatorSourceConfiguration;
            if (simulatorSC.Selected)
              SimulatorInterface = Simulator.SimulatorDictionary.Find
                (true, nt, simulatorSC.Tag.ToString(), new TimeSpan(0, 0, 0, 0, 500));
            break;
          default:
            break;
        }
      }
    }
    private BaseVariableState m_variable;
    private I4UAServer m_OPCDAValue;
    private I4UAServer m_SimulatedValue;
    private I4UAServer m_CommServerValue;
    private I4UAServer OPCDAInterface
    {
      set
      {
        m_OPCDAValue = value;
        if (value != null)
          value.OnValueChanged += new EventHandler<ItemValueArgs>(My_OnValueChangedHandler);
      }
    }
    private I4UAServer SimulatorInterface
    {
      set
      {
        m_SimulatedValue = value;
        if (value != null)
          value.OnValueChanged += new EventHandler<ItemValueArgs>(My_OnValueChangedHandler);
      }
    }
    private I4UAServer CommServerInterface
    {
      set
      {
        m_CommServerValue = value;
        if (value != null)
          value.OnValueChanged += new EventHandler<ItemValueArgs>(My_OnValueChangedHandler);
      }
    }
    private ServiceResult CommitWrite(object value, I4UAServer dataSource)
    {
      dataSource.ValueToWrite = Opc.Convert.ChangeType(value, dataSource.ItemCanonicalType);
      if (dataSource.Flush())
        return new ServiceResult(StatusCodes.Good);
      else
      {
        m_variable.StatusCode = StatusCodes.BadNoCommunication;
        return new ServiceResult(StatusCodes.BadNoCommunication);
      }
    }
    #region Event handlers
    private void My_OnDeleteEventHandler(ISystemContext context, NodeState node, NodeStateChangeMasks changes)
    {
      if ((changes & NodeStateChangeMasks.Deleted) != 0)
      {
        if (m_OPCDAValue != null)
        {
          m_OPCDAValue.OnValueChanged -= new EventHandler<ItemValueArgs>(My_OnValueChangedHandler);
          m_OPCDAValue = null;
        }
        if (m_SimulatedValue != null)
        {
          m_SimulatedValue.OnValueChanged -= new EventHandler<ItemValueArgs>(My_OnValueChangedHandler);
          m_SimulatedValue = null;
        }
        if (m_CommServerValue != null)
        {
          m_CommServerValue.OnValueChanged -= new EventHandler<ItemValueArgs>(My_OnValueChangedHandler);
          m_CommServerValue = null;
        }
        m_variable.OnWriteValue = null;
        m_variable.OnStateChanged = null;
      }
    }
    private void My_OnValueChangedHandler(object sender, ItemValueArgs e)
    {
      lock (this)
      {
        Helpers.AssignValue(e.Value, m_variable);
      }
    }
    private ServiceResult My_OnNodeWriteEventHandler
      (
         ISystemContext context,
         NodeState node,
         NumericRange indexRange,
         QualifiedName dataEncoding,
         ref object value,
         ref StatusCode statusCode,
         ref DateTime timestamp
      )
    {
      if (m_CommServerValue != null)
        return CommitWrite(value, m_CommServerValue);
      if (m_OPCDAValue != null)
        return CommitWrite(value, m_OPCDAValue);
      else if (m_SimulatedValue != null)
        return CommitWrite(value, m_SimulatedValue);
      return new ServiceResult(StatusCodes.BadNoCommunication);
    }
    #endregion
    #endregion
  }
}
