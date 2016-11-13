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
using System.Globalization;

namespace Opc.Ua.Server
{
    /// <summary>
    /// Creates a new instance of an aggregate factory.
    /// </summary>
    public delegate IAggregateCalculator AggregatorFactory(
        DateTime startTime,
        DateTime endTime,
        double processingInterval,
        bool stepped,
        AggregateConfiguration configuration);

    /// <summary>
    /// The set of built-in aggregate factories.
    /// </summary>
    public static class Aggregators
    {
        /// <summary>
        /// Creates a calulator for the Interpolative aggregate.
        /// </summary>
        public static IAggregateCalculator InterpolativeFactory(
            DateTime startTime,
            DateTime endTime,
            double processingInterval,
            bool stepped,
            AggregateConfiguration configuration) 
        {
            return new AggregateCalculator(ObjectIds.AggregateFunction_Interpolative, startTime, endTime, processingInterval, stepped, configuration);
        }

        /// <summary>
        /// Creates a calulator for the Start2 aggregate.
        /// </summary>
        public static IAggregateCalculator Start2Factory(
            DateTime startTime,
            DateTime endTime,
            double processingInterval,
            bool stepped,
            AggregateConfiguration configuration)
        {
            return new AggregateCalculator(ObjectIds.AggregateFunction_Start2, startTime, endTime, processingInterval, stepped, configuration);
        }

        /// <summary>
        /// Creates a calulator for the End2 aggregate.
        /// </summary>
        public static IAggregateCalculator End2Factory(
            DateTime startTime,
            DateTime endTime,
            double processingInterval,
            bool stepped,
            AggregateConfiguration configuration)
        {
            return new AggregateCalculator(ObjectIds.AggregateFunction_End2, startTime, endTime, processingInterval, stepped, configuration);
        }

        /// <summary>
        /// Creates a calulator for the Average aggregate.
        /// </summary>
        public static IAggregateCalculator AverageFactory(
            DateTime startTime,
            DateTime endTime,
            double processingInterval,
            bool stepped,
            AggregateConfiguration configuration)
        {
            return new AggregateCalculator(ObjectIds.AggregateFunction_Average, startTime, endTime, processingInterval, stepped, configuration);
        }

        /// <summary>
        /// Creates a calulator for the TimeAverage aggregate.
        /// </summary>
        public static IAggregateCalculator TimeAverageFactory(
            DateTime startTime,
            DateTime endTime,
            double processingInterval,
            bool stepped,
            AggregateConfiguration configuration)
        {
            return new AggregateCalculator(ObjectIds.AggregateFunction_TimeAverage, startTime, endTime, processingInterval, stepped, configuration);
        }

        /// <summary>
        /// Creates a calulator for the TimeAverage2 aggregate.
        /// </summary>
        public static IAggregateCalculator TimeAverage2Factory(
            DateTime startTime,
            DateTime endTime,
            double processingInterval,
            bool stepped,
            AggregateConfiguration configuration)
        {
            return new AggregateCalculator(ObjectIds.AggregateFunction_TimeAverage2, startTime, endTime, processingInterval, stepped, configuration);
        }

        /// <summary>
        /// Creates a calulator for the Count aggregate.
        /// </summary>
        public static IAggregateCalculator CountFactory(
            DateTime startTime,
            DateTime endTime,
            double processingInterval,
            bool stepped,
            AggregateConfiguration configuration)
        {
            return new AggregateCalculator(ObjectIds.AggregateFunction_Count, startTime, endTime, processingInterval, stepped, configuration);
        }

        /// <summary>
        /// Creates a calulator for the Total aggregate.
        /// </summary>
        public static IAggregateCalculator TotalFactory(
            DateTime startTime,
            DateTime endTime,
            double processingInterval,
            bool stepped,
            AggregateConfiguration configuration)
        {
            return new AggregateCalculator(ObjectIds.AggregateFunction_Total, startTime, endTime, processingInterval, stepped, configuration);
        }
    }
}
