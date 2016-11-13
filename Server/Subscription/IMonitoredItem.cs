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
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Threading;

namespace Opc.Ua.Server 
{
	/// <summary>
	/// Manages a monitored item created by a client.
	/// </summary>
	public interface IMonitoredItem
    {        
		/// <summary>
		/// The node manager that created the item.
		/// </summary>
        INodeManager NodeManager { get; }

		/// <summary>
		/// The session that owns the monitored item.
		/// </summary>
		Session Session { get; }

		/// <summary>
		/// The identifier for the item that is unique within the server.
		/// </summary>
		uint Id { get; } 
        
		/// <summary>
		/// The identifier for the subscription that is unique within the server.
		/// </summary>
		uint SubscriptionId { get; } 

        /// <summary>
        /// The object to call when item is ready to publish.
        /// </summary>
        ISubscription SubscriptionCallback { get; set; } 

		/// <summary>
		/// The handle assigned by the NodeManager.
		/// </summary>
		object ManagerHandle { get; } 

        /// <summary>
        /// A bit mask that indicates what the monitored item is.
        /// </summary>
        /// <remarks>
        /// Predefined bits are defined by the MonitoredItemTypeMasks class.
        /// NodeManagers may use the remaining bits.
        /// </remarks>
        int MonitoredItemType { get; }

        /// <summary>
        /// Checks if the monitored item is ready to publish.
        /// </summary>
        bool IsReadyToPublish { get; }

		/// <summary>
		/// Returns the result after creating the monitor item.
		/// </summary>
        ServiceResult GetCreateResult(out MonitoredItemCreateResult result);

		/// <summary>
		/// Returns the result after modifying the monitor item.
		/// </summary>
        ServiceResult GetModifyResult(out MonitoredItemModifyResult result);

        /// <summary>
        /// The monitoring mode specified for the item.
        /// </summary>
        MonitoringMode MonitoringMode { get; }

        /// <summary>
        /// The sampling interval for the item.
        /// </summary>
        double SamplingInterval { get; }
	}

	/// <summary>
	/// Manages a monitored item created by a client.
	/// </summary>
	public interface IEventMonitoredItem : IMonitoredItem
    {
        /// <summary>
        /// Whether the item is monitoring all events produced by the server.
        /// </summary>
        bool MonitoringAllEvents { get; }

        /// <summary>
        /// Adds an event to the queue.
        /// </summary>
        void QueueEvent(IFilterTarget instance);
        
		/// <summary>
		/// The filter used by the monitored item.
		/// </summary>
		EventFilter EventFilter { get; }

		/// <summary>
		/// Publishes all available event notifications.
        /// </summary>
        /// <returns>True if the caller should re-queue the item for publishing after the next interval elaspses.</returns>
        bool Publish(OperationContext context, Queue<EventFieldList> notifications);

        /// <summary>
        /// Modifies the attributes for monitored item.
        /// </summary>
        ServiceResult ModifyAttributes(
            DiagnosticsMasks diagnosticsMasks,
            TimestampsToReturn timestampsToReturn,
            uint clientHandle,
            MonitoringFilter originalFilter,
            MonitoringFilter filterToUse,
            Range range,
            double samplingInterval,
            uint queueSize,
            bool discardOldest);

        /// <summary>
        /// Changes the monitoring mode for the item.
        /// </summary>
        void SetMonitoringMode(MonitoringMode monitoringMode);
	}
    
	/// <summary>
	/// Manages a monitored item created by a client.
	/// </summary>
	public interface IDataChangeMonitoredItem : IMonitoredItem
    {
      	/// <summary>
		/// Updates the queue with a data value or an error.
		/// </summary>
		void QueueValue(DataValue value, ServiceResult error);
        
		/// <summary>
		/// The filter used by the monitored item.
		/// </summary>
		DataChangeFilter DataChangeFilter { get; }

		/// <summary>
		/// Publishes all available data change notifications.
		/// </summary>
        /// <returns>True if the caller should re-queue the item for publishing after the next interval elaspses.</returns>
		bool Publish(
            OperationContext                 context, 
            Queue<MonitoredItemNotification> notifications,
            Queue<DiagnosticInfo> diagnostics);
	}
    
	/// <summary>
	/// Manages a monitored item created by a client.
	/// </summary>
    public interface IDataChangeMonitoredItem2 : IDataChangeMonitoredItem
    {
        /// <summary>
        /// The attribute being monitored.
        /// </summary>
        uint AttributeId { get; }

        /// <summary>
        /// Updates the queue with a data value or an error.
        /// </summary>
        void QueueValue(DataValue value, ServiceResult error, bool ignoreFilters);
    }

    /// <summary>
    /// Manages a monitored item created by a client.
    /// </summary>
    public interface ISampledDataChangeMonitoredItem : IDataChangeMonitoredItem2
    {  
        /// <summary>
        /// The diagnostics mask specified fro the monitored item.
        /// </summary>
        DiagnosticsMasks DiagnosticsMasks { get; }

        /// <summary>
        /// The queue size for the item.
        /// </summary>
        uint QueueSize { get; }

        /// <summary>
        /// The minimum sampling interval for the item.
        /// </summary>
        double MinimumSamplingInterval { get; }
        
        /// <summary>
        /// Used to check whether the item is ready to sample.
        /// </summary>
        bool SamplingIntervalExpired();

        /// <summary>
        /// Returns the parameters that can be used to read the monitored item.
        /// </summary>
        ReadValueId GetReadValueId();

		/// <summary>
		/// Modifies the attributes for monitored item.
		/// </summary>
		ServiceResult ModifyAttributes(
            DiagnosticsMasks   diagnosticsMasks,
            TimestampsToReturn timestampsToReturn,
            uint               clientHandle,
            MonitoringFilter   originalFilter,
            MonitoringFilter   filterToUse,
            Range              range,
            double             samplingInterval,
            uint               queueSize,
            bool               discardOldest);
		
        /// <summary>
		/// Changes the monitoring mode for the item.
		/// </summary>
        void SetMonitoringMode(MonitoringMode monitoringMode);
        
		/// <summary>
		/// Updates the sampling interval for an item.
		/// </summary>
        void SetSamplingInterval(double samplingInterval);
    }

    /// <summary>
    /// Defines constants for the monitored item type.
    /// </summary>
    /// <remarks>
    /// Bits 1-8 are reserved for internal use. NodeManagers may use other bits.
    /// </remarks>
    public static class MonitoredItemTypeMask
    {
        /// <summary>
        /// The monitored item subscribes to data changes.
        /// </summary>
        public const int DataChange = 0x1;

        /// <summary>
        /// The monitored item subscribes to events.
        /// </summary>
        public const int Events = 0x2;

        /// <summary>
        /// The monitored item subscribes to all events produced by the server.
        /// </summary>
        /// <remarks>
        /// If this bit is set the Events bit must be set too.
        /// </remarks>
        public const int AllEvents = 0x4;
    }
}
