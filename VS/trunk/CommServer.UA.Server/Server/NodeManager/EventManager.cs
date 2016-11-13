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
using System.Text;
using System.Threading;
using System.Security.Principal;

namespace Opc.Ua.Server
{    
    /// <summary>
    /// An object that manages all events raised within the server.
    /// </summary>
    public class EventManager : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance of a sampling group.
        /// </summary>
        public EventManager(IServerInternal server, uint maxQueueSize)
        {
            if (server == null) throw new ArgumentNullException("server");

            m_server = server;
            m_monitoredItems = new Dictionary<uint,IEventMonitoredItem>();
            m_maxEventQueueSize = maxQueueSize;
        }
        #endregion
                      
        #region IDisposable Members
        /// <summary>
        /// The finializer implementation.
        /// </summary>
        ~EventManager() 
        {
            Dispose(false);
        }
        
        /// <summary>
        /// Frees any unmanaged resources.
        /// </summary>
        public void Dispose()
        {   
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {  
            if (disposing)
            {
                List<IEventMonitoredItem> monitoredItems = null;

                lock (m_lock)
                {
                    monitoredItems = new List<IEventMonitoredItem>(m_monitoredItems.Values);
                    m_monitoredItems.Clear();
                }

                foreach (IEventMonitoredItem monitoredItem in monitoredItems)
                {
                    Utils.SilentDispose(monitoredItem);
                }
            }
        }
        #endregion
                 
        #region Public Methods
        /// <summary>
        /// Reports an event.
        /// </summary>
        public static void ReportEvent(IFilterTarget e, IList<IEventMonitoredItem> monitoredItems)
        {
            if (e == null) throw new ArgumentNullException("e");
            
            foreach (IEventMonitoredItem monitoredItem in monitoredItems)
            {
                monitoredItem.QueueEvent(e);
            }
        }
        
        /// <summary>
        /// Creates a set of monitored items.
        /// </summary>
        [Obsolete("Replaced by variant that includes the publishingInterval")]
        public MonitoredItem CreateMonitoredItem(
            OperationContext           context,
            INodeManager               nodeManager,
            object                     handle,
            uint                       subscriptionId,
            uint                       monitoredItemId,
            TimestampsToReturn         timestampsToReturn,
            MonitoredItemCreateRequest itemToCreate,
            EventFilter                filter)
        {
            return CreateMonitoredItem(
                context,
                nodeManager,
                handle,
                subscriptionId,
                monitoredItemId,
                timestampsToReturn,
                0,
                itemToCreate,
                filter);
        }

        /// <summary>
        /// Creates a set of monitored items.
        /// </summary>
        public MonitoredItem CreateMonitoredItem(
            OperationContext           context,
            INodeManager               nodeManager,
            object                     handle,
            uint                       subscriptionId,
            uint                       monitoredItemId,
            TimestampsToReturn         timestampsToReturn,
            double                     publishingInterval,
            MonitoredItemCreateRequest itemToCreate,
            EventFilter                filter)
        {
            lock (m_lock)
            {
                // calculate sampling interval.
                double samplingInterval = itemToCreate.RequestedParameters.SamplingInterval;
                
                if (samplingInterval < 0)
                {
                    samplingInterval = publishingInterval;
                }
                
                // limit the queue size.
                uint queueSize = itemToCreate.RequestedParameters.QueueSize;

                if (queueSize > m_maxEventQueueSize)
                {
                    queueSize = m_maxEventQueueSize;
                }
                
                // create the monitored item.
                MonitoredItem monitoredItem = new MonitoredItem(
                    m_server,
                    nodeManager,
                    handle,
                    subscriptionId,
                    monitoredItemId,
                    context.Session,
                    itemToCreate.ItemToMonitor,
                    context.DiagnosticsMask,
                    timestampsToReturn,
                    itemToCreate.MonitoringMode,
                    itemToCreate.RequestedParameters.ClientHandle,
                    filter,
                    filter,
                    null,
                    samplingInterval,
                    queueSize,
                    itemToCreate.RequestedParameters.DiscardOldest,
                    MinimumSamplingIntervals.Continuous);

                // save the monitored item.
                m_monitoredItems.Add(monitoredItemId, monitoredItem);

                return monitoredItem;
            }
        }
                
        /// <summary>
        /// Modifies a monitored item.
        /// </summary>
        public void ModifyMonitoredItem(
            OperationContext           context,
            IEventMonitoredItem        monitoredItem,
            TimestampsToReturn         timestampsToReturn,
            MonitoredItemModifyRequest itemToModify,
            EventFilter                filter)
        {
            lock (m_lock)
            {
                // should never be called with items that it does not own.
                if (!m_monitoredItems.ContainsKey(monitoredItem.Id))
                {
                    return;
                }

                // limit the queue size.
                uint queueSize = itemToModify.RequestedParameters.QueueSize;

                if (queueSize > m_maxEventQueueSize)
                {
                    queueSize = m_maxEventQueueSize;
                }

                // modify the attributes.
                monitoredItem.ModifyAttributes(
                    context.DiagnosticsMask,
                    timestampsToReturn,
                    itemToModify.RequestedParameters.ClientHandle,
                    filter,
                    filter,
                    null,
                    itemToModify.RequestedParameters.SamplingInterval,
                    queueSize,
                    itemToModify.RequestedParameters.DiscardOldest);
            }           
        }

        /// <summary>
        /// Deletes a monitored item.
        /// </summary>
        public void DeleteMonitoredItem(uint monitoredItemId)
        {
            lock (m_lock)
            {
                m_monitoredItems.Remove(monitoredItemId);
            }
        }

        /// <summary>
        /// Returns the currently active monitored items. 
        /// </summary>
        public IList<IEventMonitoredItem> GetMonitoredItems()
        {
            lock (m_lock)
            {
                return new List<IEventMonitoredItem>(m_monitoredItems.Values);
            }
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();
        private IServerInternal m_server;
        private Dictionary<uint, IEventMonitoredItem> m_monitoredItems;
        private uint m_maxEventQueueSize;
        #endregion
    }
}
