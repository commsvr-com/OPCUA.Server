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
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data;

namespace Opc.Ua.Server
{
    /// <summary>
    /// The interface that a server exposes to objects that it contains.
    /// </summary>
    public static class ServerUtils
    {
        private enum EventType
        {
            WriteValue,
            CreateItem,
            ModifyItem,
            QueueValue,
            FilterValue,
            DiscardValue,
            PublishValue
        }

        private class Event
        {
            public DateTime Timestamp;
            public EventType EventType;
            public NodeId NodeId;
            public uint ServerHandle;
            public DataValue Value;
            public MonitoringParameters Parameters;
            public MonitoringMode MonitoringMode;
        }

        private static Queue<Event> m_events = new Queue<Event>();
        private static bool m_eventsEnabled;

        /// <summary>
        /// Whether event queuing is enabled.
        /// </summary>
        public static bool EventsEnabled
        {
            get { return m_eventsEnabled; }
            
            set 
            {
                if (m_eventsEnabled != value)
                {
                    if (!value)
                    {
                        lock (m_events)
                        {
                            m_events.Clear();
                        }
                    }
                }

                m_eventsEnabled = value; 
            }
        }

        /// <summary>
        /// Empties the event queue and saves it in the dataset.
        /// </summary>
        public static DataSet EmptyQueue(DataSet dataset)
        {
            if (dataset == null)
            {
                dataset = new DataSet();
                dataset.Tables.Add("MonitoredItems");

                dataset.Tables[0].Columns.Add("Id", typeof(uint));
                dataset.Tables[0].Columns.Add("Timestamp", typeof(string));
                dataset.Tables[0].Columns.Add("EventType", typeof(string));
                dataset.Tables[0].Columns.Add("NodeId", typeof(NodeId));
                dataset.Tables[0].Columns.Add("MonitoringMode", typeof(MonitoringMode));
                dataset.Tables[0].Columns.Add("SamplingInterval", typeof(double));
                dataset.Tables[0].Columns.Add("QueueSize", typeof(uint));
                dataset.Tables[0].Columns.Add("DiscardOldest", typeof(bool));
                dataset.Tables[0].Columns.Add("Filter", typeof(string));
                dataset.Tables[0].Columns.Add("Value", typeof(Variant));
                dataset.Tables[0].Columns.Add("StatusCode", typeof(StatusCode));
                dataset.Tables[0].Columns.Add("SourceTimestamp", typeof(string));
                dataset.Tables[0].Columns.Add("ServerTimestamp", typeof(string));

                dataset.Tables[0].DefaultView.Sort = "Timestamp";
            }

            lock (m_events)
            {
                while (m_events.Count > 0)
                {
                    Event e = m_events.Dequeue();

                    DataRow row = dataset.Tables[0].NewRow();

                    row[0] = e.ServerHandle;
                    row[1] = e.Timestamp.ToLocalTime().ToString("HH:mm:ss.ffffff");
                    row[2] = e.EventType.ToString();
                    row[3] = e.NodeId;

                    if (e.Parameters != null)
                    {
                        row[4] = e.MonitoringMode;
                        row[5] = e.Parameters.SamplingInterval;
                        row[6] = e.Parameters.QueueSize;
                        row[7] = e.Parameters.DiscardOldest;

                        if (e.Parameters.Filter != null)
                        {
                            row[8] = e.Parameters.Filter.ToString();
                        }
                    }

                    if (e.Value != null)
                    {
                        row[9]  = e.Value.WrappedValue;
                        row[10] = e.Value.StatusCode;
                        row[11] = e.Value.ServerTimestamp.ToLocalTime().ToString("HH:mm:ss.fff");
                        row[12] = e.Value.ServerTimestamp.ToLocalTime().ToString("HH:mm:ss.fff");
                    }

                    dataset.Tables[0].Rows.Add(row);
                }
            }

            dataset.AcceptChanges();
            return dataset;
        }

        /// <summary>
        /// Reports a value written.
        /// </summary>
        public static void ReportWriteValue(NodeId nodeId, DataValue value, StatusCode error)
        {
            if (!m_eventsEnabled)
            {
                return;
            }

            lock (m_events)
            {
                Event e = new Event();
                e.EventType = EventType.WriteValue;
                e.NodeId = nodeId;
                e.ServerHandle = 0;
                e.Timestamp = HiResClock.UtcNow;
                e.Value = value;
                e.Parameters = null;
                e.MonitoringMode = MonitoringMode.Disabled;

                if (StatusCode.IsBad(error))
                {
                    e.Value = new DataValue(error);
                    e.Value.WrappedValue = value.WrappedValue;
                }

                m_events.Enqueue(e);
            }
        }

        /// <summary>
        /// Reports a value queued.
        /// </summary>
        public static void ReportQueuedValue(NodeId nodeId, uint serverHandle, DataValue value)
        {
            if (!m_eventsEnabled)
            {
                return;
            }

            lock (m_events)
            {
                Event e = new Event();
                e.EventType = EventType.QueueValue;
                e.NodeId = nodeId;
                e.ServerHandle = serverHandle;
                e.Timestamp = HiResClock.UtcNow;
                e.Value = value;
                e.Parameters = null;
                e.MonitoringMode = MonitoringMode.Disabled;
                m_events.Enqueue(e);
            }
        }

        /// <summary>
        /// Reports a value excluded by the filter.
        /// </summary>
        public static void ReportFilteredValue(NodeId nodeId, uint serverHandle, DataValue value)
        {
            if (!m_eventsEnabled)
            {
                return;
            }

            lock (m_events)
            {
                Event e = new Event();
                e.EventType = EventType.FilterValue;
                e.NodeId = nodeId;
                e.ServerHandle = serverHandle;
                e.Timestamp = HiResClock.UtcNow;
                e.Value = value;
                e.Parameters = null;
                e.MonitoringMode = MonitoringMode.Disabled;
                m_events.Enqueue(e);
            }
        }

        /// <summary>
        /// Reports a value discarded because of queue overflow.
        /// </summary>
        public static void ReportDiscardedValue(NodeId nodeId, uint serverHandle, DataValue value)
        {
            if (!m_eventsEnabled)
            {
                return;
            }

            lock (m_events)
            {
                Event e = new Event();
                e.EventType = EventType.DiscardValue;
                e.NodeId = nodeId;
                e.ServerHandle = serverHandle;
                e.Timestamp = HiResClock.UtcNow;
                e.Value = value;
                e.Parameters = null;
                e.MonitoringMode = MonitoringMode.Disabled;
                m_events.Enqueue(e);
            }
        }

        /// <summary>
        /// Reports a value published.
        /// </summary>
        public static void ReportPublishValue(NodeId nodeId, uint serverHandle, DataValue value)
        {
            if (!m_eventsEnabled)
            {
                return;
            }

            lock (m_events)
            {
                Event e = new Event();
                e.EventType = EventType.PublishValue;
                e.NodeId = nodeId;
                e.ServerHandle = serverHandle;
                e.Timestamp = HiResClock.UtcNow;
                e.Value = value;
                e.Parameters = null;
                e.MonitoringMode = MonitoringMode.Disabled;
                m_events.Enqueue(e);
            }
        }

        /// <summary>
        /// Reports a new monitored item.
        /// </summary>
        public static void ReportCreateMonitoredItem(
            NodeId nodeId, 
            uint serverHandle,
            double samplingInterval,
            uint queueSize,
            bool discardOldest,
            MonitoringFilter filter,
            MonitoringMode monitoringMode)
        {
            if (!m_eventsEnabled)
            {
                return;
            }

            lock (m_events)
            {
                Event e = new Event();
                e.EventType = EventType.CreateItem;
                e.NodeId = nodeId;
                e.ServerHandle = serverHandle;
                e.Timestamp = HiResClock.UtcNow;
                e.Value = null;
                e.Parameters = new MonitoringParameters();
                e.Parameters.SamplingInterval = samplingInterval;
                e.Parameters.QueueSize = queueSize;
                e.Parameters.DiscardOldest = discardOldest;
                e.Parameters.Filter = new ExtensionObject(filter);
                e.MonitoringMode = monitoringMode;
                m_events.Enqueue(e);
            }
        }

        /// <summary>
        /// Reports a modified monitored item.
        /// </summary>
        public static void ReportModifyMonitoredItem(
            NodeId nodeId,
            uint serverHandle,
            double samplingInterval,
            uint queueSize,
            bool discardOldest,
            MonitoringFilter filter,
            MonitoringMode monitoringMode)
        {
            if (!m_eventsEnabled)
            {
                return;
            }

            lock (m_events)
            {
                Event e = new Event();
                e.EventType = EventType.ModifyItem;
                e.NodeId = nodeId;
                e.ServerHandle = serverHandle;
                e.Timestamp = HiResClock.UtcNow;
                e.Value = null;
                e.Parameters = new MonitoringParameters();
                e.Parameters.SamplingInterval = samplingInterval;
                e.Parameters.QueueSize = queueSize;
                e.Parameters.DiscardOldest = discardOldest;
                e.Parameters.Filter = new ExtensionObject(filter);
                e.MonitoringMode = monitoringMode;
                m_events.Enqueue(e);
            }
        }

        /// <summary>
        /// Fills in the diagnostic information after an error.
        /// </summary>
        public static uint CreateError(
            uint                     code, 
            OperationContext         context, 
            DiagnosticInfoCollection diagnosticInfos, 
            int                      index)
        {
            ServiceResult error = new ServiceResult(code);
            
            if ((context.DiagnosticsMask & DiagnosticsMasks.OperationAll) != 0)
            {
                diagnosticInfos[index] = new DiagnosticInfo(error, context.DiagnosticsMask, false, context.StringTable);
            }

            return error.Code;
        }
        
        /// <summary>
        /// Fills in the diagnostic information after an error.
        /// </summary>
        public static bool CreateError(
            uint                      code,  
            StatusCodeCollection      results,
            DiagnosticInfoCollection  diagnosticInfos, 
            OperationContext          context)
        {
            ServiceResult error = new ServiceResult(code);
            results.Add(error.Code);
            
            if ((context.DiagnosticsMask & DiagnosticsMasks.OperationAll) != 0)
            {
                diagnosticInfos.Add(new DiagnosticInfo(error, context.DiagnosticsMask, false, context.StringTable));
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Fills in the diagnostic information after an error.
        /// </summary>
        public static bool CreateError(
            uint                     code,  
            StatusCodeCollection     results,
            DiagnosticInfoCollection diagnosticInfos, 
            int                      index,
            OperationContext         context)
        {
            ServiceResult error = new ServiceResult(code);
            results[index] = error.Code;
            
            if ((context.DiagnosticsMask & DiagnosticsMasks.OperationAll) != 0)
            {
                diagnosticInfos[index] = new DiagnosticInfo(error, context.DiagnosticsMask, false, context.StringTable);
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Creates a place holder in the lists for the results.
        /// </summary>
        public static void CreateSuccess(
            StatusCodeCollection     results,
            DiagnosticInfoCollection diagnosticInfos,
            OperationContext         context)
        {
            results.Add(StatusCodes.Good);
            
            if ((context.DiagnosticsMask & DiagnosticsMasks.OperationAll) != 0)
            {
                diagnosticInfos.Add(null);
            }
        }
        
        /// <summary>
        /// Creates a collection of diagnostics from a set of errors.
        /// </summary>
        public static DiagnosticInfoCollection CreateDiagnosticInfoCollection(
            OperationContext     context,
            IList<ServiceResult> errors)
        {
            // all done if no diagnostics requested.
            if ((context.DiagnosticsMask & DiagnosticsMasks.OperationAll) == 0)
            {
                return null;
            }
            
            // create diagnostics.
            DiagnosticInfoCollection results = new DiagnosticInfoCollection(errors.Count);

            foreach (ServiceResult error in errors)
            {
                if (ServiceResult.IsBad(error))
                {
                    results.Add(new DiagnosticInfo(error, context.DiagnosticsMask, false, context.StringTable));
                }
                else
                {
                    results.Add(null);
                }
            }

            return results;
        }
        
        /// <summary>
        /// Creates a collection of status codes and diagnostics from a set of errors.
        /// </summary>
        public static StatusCodeCollection CreateStatusCodeCollection(
            OperationContext             context,
            IList<ServiceResult>         errors, 
            out DiagnosticInfoCollection diagnosticInfos)
        {
            diagnosticInfos = null;

            bool noErrors = true;
            StatusCodeCollection results = new StatusCodeCollection(errors.Count);

            foreach (ServiceResult error in errors)
            {
                if (ServiceResult.IsBad(error))
                {
                    results.Add(error.Code);
                    noErrors = false;
                }
                else
                {
                    results.Add(StatusCodes.Good);
                }
            }

            // only generate diagnostics if errors exist.
            if (noErrors)
            {
                diagnosticInfos = CreateDiagnosticInfoCollection(context, errors);
            }
            
            return results;
        }

        /// <summary>
        /// Creates the diagnostic info and translates any strings.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="context">The context containing the string stable.</param>
        /// <param name="error">The error to translate.</param>
        /// <returns>The diagnostics with references to the strings in the context string table.</returns>
        public static DiagnosticInfo CreateDiagnosticInfo(
            IServerInternal  server,
            OperationContext context,
            ServiceResult    error)
        {
            if (error == null)
            {
                return null;
            }

            ServiceResult translatedError = error;

            if ((context.DiagnosticsMask & DiagnosticsMasks.LocalizedText) != 0)
            {
                translatedError = server.ResourceManager.Translate(context.PreferredLocales, error);
            }

            DiagnosticInfo diagnosticInfo = new DiagnosticInfo(
                translatedError, 
                context.DiagnosticsMask, 
                false, 
                context.StringTable);

            return diagnosticInfo;
        }
    }
}
