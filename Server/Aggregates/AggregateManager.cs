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
    /// An object that manages aggregate factories supported by the server.
    /// </summary>
    public class AggregateManager : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Initilizes the manager.
        /// </summary>
        public AggregateManager(IServerInternal server)
        {
            m_server = server;
            m_factories = new Dictionary<NodeId,AggregatorFactory>();
            m_minimumProcessingInterval = 1000;
        }
        #endregion
        
        #region IDisposable Members
        /// <summary>
        /// The finializer implementation.
        /// </summary>
        ~AggregateManager() 
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "m_requestTimer")]
        protected virtual void Dispose(bool disposing)
        {  
            if (disposing)
            {
                // TBD
            }            
        }
        #endregion

        #region Public Members
        /// <summary>
        /// Checks if the aggregate is supported by the server.
        /// </summary>
        /// <param name="aggregateId">The id of the aggregate function.</param>
        /// <returns>True if the aggregate is supported.</returns>
        public bool IsSupported(NodeId aggregateId)
        {
            if (NodeId.IsNull(aggregateId))
            {
                return false;
            }

            lock (m_lock)
            {
                return m_factories.ContainsKey(aggregateId);
            }
        }

        /// <summary>
        /// The minimum processing interval for any aggregate calculation.
        /// </summary>
        public double MinimumProcessingInterval 
        {
            get
            {
                lock (m_lock)
                {
                    return m_minimumProcessingInterval;
                }
            }

            set
            {
                lock (m_lock)
                {
                    m_minimumProcessingInterval = value;
                }
            }
        }

        /// <summary>
        /// Returns the default configuration for the specified variable id.
        /// </summary>
        /// <param name="variableId">The id of history data node.</param>
        /// <returns>The configuration.</returns>
        public AggregateConfiguration GetDefaultConfiguration(NodeId variableId)
        {
            lock (m_lock)
            {
                if (m_defaultConfiguration == null)
                {
                    m_defaultConfiguration = new AggregateConfiguration();
                    m_defaultConfiguration.PercentDataBad = 100;
                    m_defaultConfiguration.PercentDataGood = 100;
                    m_defaultConfiguration.TreatUncertainAsBad = false;
                    m_defaultConfiguration.UseSlopedExtrapolation = false;
                    m_defaultConfiguration.UseServerCapabilitiesDefaults = false;
                }

                return m_defaultConfiguration;
            }
        }

        /// <summary>
        /// Sets the default aggregate configuration.
        /// </summary>
        /// <param name="configuration">The default aggregate configuration..</param>
        public void SetDefaultConfiguration(AggregateConfiguration configuration)
        {
            lock (m_lock)
            {
                m_defaultConfiguration = configuration;
            }
        }

        /// <summary>
        /// Creates a new aggregate calculator.
        /// </summary>
        /// <param name="aggregateId">The id of the aggregate function.</param>
        /// <param name="startTime">When to start processing.</param>
        /// <param name="endTime">When to stop processing.</param>
        /// <param name="processingInterval">The processing interval.</param>
        /// <param name="stepped">Whether stepped interpolation should be used.</param>
        /// <param name="configuration">The configuaration to use.</param>
        /// <returns></returns>
        public IAggregateCalculator CreateCalculator(
            NodeId aggregateId,
            DateTime startTime,
            DateTime endTime,
            double processingInterval,
            bool stepped,
            AggregateConfiguration configuration)
        {
            if (NodeId.IsNull(aggregateId))
            {
                return null;
            }

            AggregatorFactory factory = null;

            lock (m_lock)
            {
                if (!m_factories.TryGetValue(aggregateId, out factory))
                {
                    return null;
                }
            }

            if (configuration.UseServerCapabilitiesDefaults)
            {
                configuration = m_defaultConfiguration;
            }

            IAggregateCalculator calculator = factory(startTime, endTime, processingInterval, stepped, configuration);

            if (calculator == null)
            {
                return null;
            }

            return calculator;
        }

        /// <summary>
        /// Registers an aggregate factory.
        /// </summary>
        /// <param name="aggregateId">The id of the aggregate function.</param>
        /// <param name="aggregateName">The id of the aggregate name.</param>
        /// <param name="factory">The factory used to create calculators.</param>
        public void RegisterFactory(NodeId aggregateId, string aggregateName, AggregatorFactory factory)
        {
            lock (m_lock)
            {
                m_factories[aggregateId] = factory;
            }

            if (m_server != null)
            {
                m_server.DiagnosticsNodeManager.AddAggregateFunction(aggregateId, aggregateName, true);
            }
        }

        /// <summary>
        /// Unregisters an aggregate factory.
        /// </summary>
        /// <param name="aggregateId">The id of the aggregate function.</param>
        public void RegisterFactory(NodeId aggregateId)
        {
            lock (m_lock)
            {
                m_factories.Remove(aggregateId);
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Fields
        private object m_lock = new object();
        private IServerInternal m_server;
        private AggregateConfiguration m_defaultConfiguration;
        private Dictionary<NodeId,AggregatorFactory> m_factories;
        private double m_minimumProcessingInterval;
        #endregion
    }
}
