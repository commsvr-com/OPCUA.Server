
/* ========================================================================
 * Copyright (c) 2005-2010 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace CAS.UA.Server.Demo
{
    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the BoilerStateMachineType_Start Method.
        /// </summary>
        public const uint BoilerStateMachineType_Start = 1095;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Suspend Method.
        /// </summary>
        public const uint BoilerStateMachineType_Suspend = 1096;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Resume Method.
        /// </summary>
        public const uint BoilerStateMachineType_Resume = 1097;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Halt Method.
        /// </summary>
        public const uint BoilerStateMachineType_Halt = 1098;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Reset Method.
        /// </summary>
        public const uint BoilerStateMachineType_Reset = 1099;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Start Method.
        /// </summary>
        public const uint BoilerType_Simulation_Start = 1234;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Suspend Method.
        /// </summary>
        public const uint BoilerType_Simulation_Suspend = 1235;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Resume Method.
        /// </summary>
        public const uint BoilerType_Simulation_Resume = 1236;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Halt Method.
        /// </summary>
        public const uint BoilerType_Simulation_Halt = 1237;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Reset Method.
        /// </summary>
        public const uint BoilerType_Simulation_Reset = 1238;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Start Method.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Start = 1343;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Suspend Method.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Suspend = 1344;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Resume Method.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Resume = 1345;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Halt Method.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Halt = 1346;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Reset Method.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Reset = 1347;
    }
    #endregion

    #region Object Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <summary>
        /// The identifier for the BoilerStateMachineType_FinalResultData Object.
        /// </summary>
        public const uint BoilerStateMachineType_FinalResultData = 1068;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Ready Object.
        /// </summary>
        public const uint BoilerStateMachineType_Ready = 1069;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Running Object.
        /// </summary>
        public const uint BoilerStateMachineType_Running = 1071;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Suspended Object.
        /// </summary>
        public const uint BoilerStateMachineType_Suspended = 1073;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Halted Object.
        /// </summary>
        public const uint BoilerStateMachineType_Halted = 1075;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_HaltedToReady Object.
        /// </summary>
        public const uint BoilerStateMachineType_HaltedToReady = 1077;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ReadyToRunning Object.
        /// </summary>
        public const uint BoilerStateMachineType_ReadyToRunning = 1079;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToHalted Object.
        /// </summary>
        public const uint BoilerStateMachineType_RunningToHalted = 1081;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToReady Object.
        /// </summary>
        public const uint BoilerStateMachineType_RunningToReady = 1083;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToSuspended Object.
        /// </summary>
        public const uint BoilerStateMachineType_RunningToSuspended = 1085;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToRunning Object.
        /// </summary>
        public const uint BoilerStateMachineType_SuspendedToRunning = 1087;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToHalted Object.
        /// </summary>
        public const uint BoilerStateMachineType_SuspendedToHalted = 1089;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToReady Object.
        /// </summary>
        public const uint BoilerStateMachineType_SuspendedToReady = 1091;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ReadyToHalted Object.
        /// </summary>
        public const uint BoilerStateMachineType_ReadyToHalted = 1093;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1 Object.
        /// </summary>
        public const uint BoilerInputPipeType_FlowTransmitter1 = 1102;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve Object.
        /// </summary>
        public const uint BoilerInputPipeType_Valve = 1109;

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator Object.
        /// </summary>
        public const uint BoilerDrumType_LevelIndicator = 1117;

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2 Object.
        /// </summary>
        public const uint BoilerOutputPipeType_FlowTransmitter2 = 1125;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe Object.
        /// </summary>
        public const uint BoilerType_InputPipe = 1133;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1 Object.
        /// </summary>
        public const uint BoilerType_InputPipe_FlowTransmitter1 = 1134;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve Object.
        /// </summary>
        public const uint BoilerType_InputPipe_Valve = 1141;

        /// <summary>
        /// The identifier for the BoilerType_Drum Object.
        /// </summary>
        public const uint BoilerType_Drum = 1148;

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator Object.
        /// </summary>
        public const uint BoilerType_Drum_LevelIndicator = 1149;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe Object.
        /// </summary>
        public const uint BoilerType_OutputPipe = 1156;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2 Object.
        /// </summary>
        public const uint BoilerType_OutputPipe_FlowTransmitter2 = 1157;

        /// <summary>
        /// The identifier for the BoilerType_FlowController Object.
        /// </summary>
        public const uint BoilerType_FlowController = 1164;

        /// <summary>
        /// The identifier for the BoilerType_LevelController Object.
        /// </summary>
        public const uint BoilerType_LevelController = 1168;

        /// <summary>
        /// The identifier for the BoilerType_CustomController Object.
        /// </summary>
        public const uint BoilerType_CustomController = 1172;

        /// <summary>
        /// The identifier for the BoilerType_Simulation Object.
        /// </summary>
        public const uint BoilerType_Simulation = 1178;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_FinalResultData Object.
        /// </summary>
        public const uint BoilerType_Simulation_FinalResultData = 1207;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Ready Object.
        /// </summary>
        public const uint BoilerType_Simulation_Ready = 1416;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Running Object.
        /// </summary>
        public const uint BoilerType_Simulation_Running = 1418;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Suspended Object.
        /// </summary>
        public const uint BoilerType_Simulation_Suspended = 1420;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Halted Object.
        /// </summary>
        public const uint BoilerType_Simulation_Halted = 1422;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_HaltedToReady Object.
        /// </summary>
        public const uint BoilerType_Simulation_HaltedToReady = 1424;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ReadyToRunning Object.
        /// </summary>
        public const uint BoilerType_Simulation_ReadyToRunning = 1426;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToHalted Object.
        /// </summary>
        public const uint BoilerType_Simulation_RunningToHalted = 1428;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToReady Object.
        /// </summary>
        public const uint BoilerType_Simulation_RunningToReady = 1430;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToSuspended Object.
        /// </summary>
        public const uint BoilerType_Simulation_RunningToSuspended = 1432;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToRunning Object.
        /// </summary>
        public const uint BoilerType_Simulation_SuspendedToRunning = 1434;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToHalted Object.
        /// </summary>
        public const uint BoilerType_Simulation_SuspendedToHalted = 1436;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToReady Object.
        /// </summary>
        public const uint BoilerType_Simulation_SuspendedToReady = 1438;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ReadyToHalted Object.
        /// </summary>
        public const uint BoilerType_Simulation_ReadyToHalted = 1440;

        /// <summary>
        /// The identifier for the Boilers Object.
        /// </summary>
        public const uint Boilers = 1240;

        /// <summary>
        /// The identifier for the Boilers_Boiler1 Object.
        /// </summary>
        public const uint Boilers_Boiler1 = 1241;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe Object.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe = 1242;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1 Object.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_FlowTransmitter1 = 1243;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve Object.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_Valve = 1250;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum Object.
        /// </summary>
        public const uint Boilers_Boiler1_Drum = 1257;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator Object.
        /// </summary>
        public const uint Boilers_Boiler1_Drum_LevelIndicator = 1258;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe Object.
        /// </summary>
        public const uint Boilers_Boiler1_OutputPipe = 1265;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2 Object.
        /// </summary>
        public const uint Boilers_Boiler1_OutputPipe_FlowTransmitter2 = 1266;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_FlowController Object.
        /// </summary>
        public const uint Boilers_Boiler1_FlowController = 1273;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_LevelController Object.
        /// </summary>
        public const uint Boilers_Boiler1_LevelController = 1277;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController Object.
        /// </summary>
        public const uint Boilers_Boiler1_CustomController = 1281;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation = 1287;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_FinalResultData Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_FinalResultData = 1316;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Ready Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Ready = 1446;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Running Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Running = 1448;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Suspended Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Suspended = 1450;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Halted Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Halted = 1452;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_HaltedToReady Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_HaltedToReady = 1454;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ReadyToRunning Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ReadyToRunning = 1456;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToHalted Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_RunningToHalted = 1458;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToReady Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_RunningToReady = 1460;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToSuspended Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_RunningToSuspended = 1462;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToRunning Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_SuspendedToRunning = 1464;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToHalted Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_SuspendedToHalted = 1466;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToReady Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_SuspendedToReady = 1468;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ReadyToHalted Object.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ReadyToHalted = 1470;
    }
    #endregion

    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the GenericControllerType ObjectType.
        /// </summary>
        public const uint GenericControllerType = 210;

        /// <summary>
        /// The identifier for the GenericSensorType ObjectType.
        /// </summary>
        public const uint GenericSensorType = 991;

        /// <summary>
        /// The identifier for the GenericActuatorType ObjectType.
        /// </summary>
        public const uint GenericActuatorType = 998;

        /// <summary>
        /// The identifier for the CustomControllerType ObjectType.
        /// </summary>
        public const uint CustomControllerType = 513;

        /// <summary>
        /// The identifier for the ValveType ObjectType.
        /// </summary>
        public const uint ValveType = 1010;

        /// <summary>
        /// The identifier for the LevelControllerType ObjectType.
        /// </summary>
        public const uint LevelControllerType = 1017;

        /// <summary>
        /// The identifier for the FlowControllerType ObjectType.
        /// </summary>
        public const uint FlowControllerType = 1021;

        /// <summary>
        /// The identifier for the LevelIndicatorType ObjectType.
        /// </summary>
        public const uint LevelIndicatorType = 1025;

        /// <summary>
        /// The identifier for the FlowTransmitterType ObjectType.
        /// </summary>
        public const uint FlowTransmitterType = 1032;

        /// <summary>
        /// The identifier for the BoilerStateMachineType ObjectType.
        /// </summary>
        public const uint BoilerStateMachineType = 1039;

        /// <summary>
        /// The identifier for the BoilerInputPipeType ObjectType.
        /// </summary>
        public const uint BoilerInputPipeType = 1101;

        /// <summary>
        /// The identifier for the BoilerDrumType ObjectType.
        /// </summary>
        public const uint BoilerDrumType = 1116;

        /// <summary>
        /// The identifier for the BoilerOutputPipeType ObjectType.
        /// </summary>
        public const uint BoilerOutputPipeType = 1124;

        /// <summary>
        /// The identifier for the BoilerType ObjectType.
        /// </summary>
        public const uint BoilerType = 1132;
    }
    #endregion

    #region ReferenceType Identifiers
    /// <summary>
    /// A class that declares constants for all ReferenceTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ReferenceTypes
    {
        /// <summary>
        /// The identifier for the FlowTo ReferenceType.
        /// </summary>
        public const uint FlowTo = 985;

        /// <summary>
        /// The identifier for the HotFlowTo ReferenceType.
        /// </summary>
        public const uint HotFlowTo = 986;

        /// <summary>
        /// The identifier for the SignalTo ReferenceType.
        /// </summary>
        public const uint SignalTo = 987;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the GenericControllerType_Measurement Variable.
        /// </summary>
        public const uint GenericControllerType_Measurement = 988;

        /// <summary>
        /// The identifier for the GenericControllerType_SetPoint Variable.
        /// </summary>
        public const uint GenericControllerType_SetPoint = 989;

        /// <summary>
        /// The identifier for the GenericControllerType_ControlOut Variable.
        /// </summary>
        public const uint GenericControllerType_ControlOut = 990;

        /// <summary>
        /// The identifier for the GenericSensorType_Output Variable.
        /// </summary>
        public const uint GenericSensorType_Output = 992;

        /// <summary>
        /// The identifier for the GenericSensorType_Output_Definition Variable.
        /// </summary>
        public const uint GenericSensorType_Output_Definition = 1349;

        /// <summary>
        /// The identifier for the GenericSensorType_Output_ValuePrecision Variable.
        /// </summary>
        public const uint GenericSensorType_Output_ValuePrecision = 1350;

        /// <summary>
        /// The identifier for the GenericSensorType_Output_EURange Variable.
        /// </summary>
        public const uint GenericSensorType_Output_EURange = 1351;

        /// <summary>
        /// The identifier for the GenericSensorType_Output_InstrumentRange Variable.
        /// </summary>
        public const uint GenericSensorType_Output_InstrumentRange = 1352;

        /// <summary>
        /// The identifier for the GenericSensorType_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint GenericSensorType_Output_EngineeringUnits = 1353;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input Variable.
        /// </summary>
        public const uint GenericActuatorType_Input = 999;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_Definition Variable.
        /// </summary>
        public const uint GenericActuatorType_Input_Definition = 1000;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_ValuePrecision Variable.
        /// </summary>
        public const uint GenericActuatorType_Input_ValuePrecision = 1001;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_EURange Variable.
        /// </summary>
        public const uint GenericActuatorType_Input_EURange = 1002;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_InstrumentRange Variable.
        /// </summary>
        public const uint GenericActuatorType_Input_InstrumentRange = 1003;

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_EngineeringUnits Variable.
        /// </summary>
        public const uint GenericActuatorType_Input_EngineeringUnits = 1004;

        /// <summary>
        /// The identifier for the CustomControllerType_Input1 Variable.
        /// </summary>
        public const uint CustomControllerType_Input1 = 1005;

        /// <summary>
        /// The identifier for the CustomControllerType_Input2 Variable.
        /// </summary>
        public const uint CustomControllerType_Input2 = 1006;

        /// <summary>
        /// The identifier for the CustomControllerType_Input3 Variable.
        /// </summary>
        public const uint CustomControllerType_Input3 = 1007;

        /// <summary>
        /// The identifier for the CustomControllerType_ControlOut Variable.
        /// </summary>
        public const uint CustomControllerType_ControlOut = 1008;

        /// <summary>
        /// The identifier for the CustomControllerType_DescriptionX Variable.
        /// </summary>
        public const uint CustomControllerType_DescriptionX = 1009;

        /// <summary>
        /// The identifier for the ValveType_Input Variable.
        /// </summary>
        public const uint ValveType_Input = 1011;

        /// <summary>
        /// The identifier for the ValveType_Input_Definition Variable.
        /// </summary>
        public const uint ValveType_Input_Definition = 1012;

        /// <summary>
        /// The identifier for the ValveType_Input_ValuePrecision Variable.
        /// </summary>
        public const uint ValveType_Input_ValuePrecision = 1013;

        /// <summary>
        /// The identifier for the ValveType_Input_EURange Variable.
        /// </summary>
        public const uint ValveType_Input_EURange = 1014;

        /// <summary>
        /// The identifier for the ValveType_Input_InstrumentRange Variable.
        /// </summary>
        public const uint ValveType_Input_InstrumentRange = 1015;

        /// <summary>
        /// The identifier for the ValveType_Input_EngineeringUnits Variable.
        /// </summary>
        public const uint ValveType_Input_EngineeringUnits = 1016;

        /// <summary>
        /// The identifier for the LevelControllerType_Measurement Variable.
        /// </summary>
        public const uint LevelControllerType_Measurement = 1018;

        /// <summary>
        /// The identifier for the LevelControllerType_SetPoint Variable.
        /// </summary>
        public const uint LevelControllerType_SetPoint = 1019;

        /// <summary>
        /// The identifier for the LevelControllerType_ControlOut Variable.
        /// </summary>
        public const uint LevelControllerType_ControlOut = 1020;

        /// <summary>
        /// The identifier for the FlowControllerType_Measurement Variable.
        /// </summary>
        public const uint FlowControllerType_Measurement = 1022;

        /// <summary>
        /// The identifier for the FlowControllerType_SetPoint Variable.
        /// </summary>
        public const uint FlowControllerType_SetPoint = 1023;

        /// <summary>
        /// The identifier for the FlowControllerType_ControlOut Variable.
        /// </summary>
        public const uint FlowControllerType_ControlOut = 1024;

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output Variable.
        /// </summary>
        public const uint LevelIndicatorType_Output = 1026;

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output_Definition Variable.
        /// </summary>
        public const uint LevelIndicatorType_Output_Definition = 1354;

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output_ValuePrecision Variable.
        /// </summary>
        public const uint LevelIndicatorType_Output_ValuePrecision = 1355;

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output_EURange Variable.
        /// </summary>
        public const uint LevelIndicatorType_Output_EURange = 1356;

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output_InstrumentRange Variable.
        /// </summary>
        public const uint LevelIndicatorType_Output_InstrumentRange = 1357;

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint LevelIndicatorType_Output_EngineeringUnits = 1358;

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output Variable.
        /// </summary>
        public const uint FlowTransmitterType_Output = 1033;

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output_Definition Variable.
        /// </summary>
        public const uint FlowTransmitterType_Output_Definition = 1359;

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output_ValuePrecision Variable.
        /// </summary>
        public const uint FlowTransmitterType_Output_ValuePrecision = 1360;

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output_EURange Variable.
        /// </summary>
        public const uint FlowTransmitterType_Output_EURange = 1361;

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output_InstrumentRange Variable.
        /// </summary>
        public const uint FlowTransmitterType_Output_InstrumentRange = 1362;

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint FlowTransmitterType_Output_EngineeringUnits = 1363;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_CurrentState Variable.
        /// </summary>
        public const uint BoilerStateMachineType_CurrentState = 1040;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_CurrentState_Id Variable.
        /// </summary>
        public const uint BoilerStateMachineType_CurrentState_Id = 1041;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_CurrentState_Name Variable.
        /// </summary>
        public const uint BoilerStateMachineType_CurrentState_Name = 1042;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_CurrentState_Number Variable.
        /// </summary>
        public const uint BoilerStateMachineType_CurrentState_Number = 1043;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_CurrentState_EffectiveDisplayName Variable.
        /// </summary>
        public const uint BoilerStateMachineType_CurrentState_EffectiveDisplayName = 1044;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_LastTransition Variable.
        /// </summary>
        public const uint BoilerStateMachineType_LastTransition = 1045;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_LastTransition_Id Variable.
        /// </summary>
        public const uint BoilerStateMachineType_LastTransition_Id = 1046;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_LastTransition_Name Variable.
        /// </summary>
        public const uint BoilerStateMachineType_LastTransition_Name = 1047;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_LastTransition_Number Variable.
        /// </summary>
        public const uint BoilerStateMachineType_LastTransition_Number = 1048;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint BoilerStateMachineType_LastTransition_TransitionTime = 1049;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Creatable Variable.
        /// </summary>
        public const uint BoilerStateMachineType_Creatable = 1050;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Deletable Variable.
        /// </summary>
        public const uint BoilerStateMachineType_Deletable = 1051;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_AutoDelete Variable.
        /// </summary>
        public const uint BoilerStateMachineType_AutoDelete = 1052;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RecycleCount Variable.
        /// </summary>
        public const uint BoilerStateMachineType_RecycleCount = 1053;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_InstanceCount Variable.
        /// </summary>
        public const uint BoilerStateMachineType_InstanceCount = 1054;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_MaxInstanceCount Variable.
        /// </summary>
        public const uint BoilerStateMachineType_MaxInstanceCount = 1055;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_MaxRecycleCount Variable.
        /// </summary>
        public const uint BoilerStateMachineType_MaxRecycleCount = 1056;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics = 1057;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_CreateSessionId Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics_CreateSessionId = 1058;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_CreateClientName Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics_CreateClientName = 1059;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_InvocationCreationTime Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics_InvocationCreationTime = 1060;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastTransitionTime Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics_LastTransitionTime = 1061;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodCall Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics_LastMethodCall = 1062;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodSessionId Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics_LastMethodSessionId = 1063;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodInputArguments Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics_LastMethodInputArguments = 1064;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics_LastMethodOutputArguments = 1065;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodCallTime Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics_LastMethodCallTime = 1066;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ProgramDiagnostics_LastMethodReturnStatus = 1067;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Ready_StateNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_Ready_StateNumber = 1070;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Running_StateNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_Running_StateNumber = 1072;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_Suspended_StateNumber = 1074;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Halted_StateNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_Halted_StateNumber = 1076;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_HaltedToReady_TransitionNumber = 1078;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ReadyToRunning_TransitionNumber = 1080;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_RunningToHalted_TransitionNumber = 1082;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_RunningToReady_TransitionNumber = 1084;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_RunningToSuspended_TransitionNumber = 1086;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_SuspendedToRunning_TransitionNumber = 1088;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_SuspendedToHalted_TransitionNumber = 1090;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_SuspendedToReady_TransitionNumber = 1092;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerStateMachineType_ReadyToHalted_TransitionNumber = 1094;

        /// <summary>
        /// The identifier for the BoilerStateMachineType_UpdateRate Variable.
        /// </summary>
        public const uint BoilerStateMachineType_UpdateRate = 1100;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output Variable.
        /// </summary>
        public const uint BoilerInputPipeType_FlowTransmitter1_Output = 1103;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output_Definition Variable.
        /// </summary>
        public const uint BoilerInputPipeType_FlowTransmitter1_Output_Definition = 1364;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output_ValuePrecision Variable.
        /// </summary>
        public const uint BoilerInputPipeType_FlowTransmitter1_Output_ValuePrecision = 1365;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output_EURange Variable.
        /// </summary>
        public const uint BoilerInputPipeType_FlowTransmitter1_Output_EURange = 1366;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output_InstrumentRange Variable.
        /// </summary>
        public const uint BoilerInputPipeType_FlowTransmitter1_Output_InstrumentRange = 1367;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint BoilerInputPipeType_FlowTransmitter1_Output_EngineeringUnits = 1368;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input Variable.
        /// </summary>
        public const uint BoilerInputPipeType_Valve_Input = 1110;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input_Definition Variable.
        /// </summary>
        public const uint BoilerInputPipeType_Valve_Input_Definition = 1111;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input_ValuePrecision Variable.
        /// </summary>
        public const uint BoilerInputPipeType_Valve_Input_ValuePrecision = 1112;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input_EURange Variable.
        /// </summary>
        public const uint BoilerInputPipeType_Valve_Input_EURange = 1113;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input_InstrumentRange Variable.
        /// </summary>
        public const uint BoilerInputPipeType_Valve_Input_InstrumentRange = 1114;

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input_EngineeringUnits Variable.
        /// </summary>
        public const uint BoilerInputPipeType_Valve_Input_EngineeringUnits = 1115;

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output Variable.
        /// </summary>
        public const uint BoilerDrumType_LevelIndicator_Output = 1118;

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output_Definition Variable.
        /// </summary>
        public const uint BoilerDrumType_LevelIndicator_Output_Definition = 1369;

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output_ValuePrecision Variable.
        /// </summary>
        public const uint BoilerDrumType_LevelIndicator_Output_ValuePrecision = 1370;

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output_EURange Variable.
        /// </summary>
        public const uint BoilerDrumType_LevelIndicator_Output_EURange = 1371;

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output_InstrumentRange Variable.
        /// </summary>
        public const uint BoilerDrumType_LevelIndicator_Output_InstrumentRange = 1372;

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint BoilerDrumType_LevelIndicator_Output_EngineeringUnits = 1373;

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output Variable.
        /// </summary>
        public const uint BoilerOutputPipeType_FlowTransmitter2_Output = 1126;

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output_Definition Variable.
        /// </summary>
        public const uint BoilerOutputPipeType_FlowTransmitter2_Output_Definition = 1374;

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output_ValuePrecision Variable.
        /// </summary>
        public const uint BoilerOutputPipeType_FlowTransmitter2_Output_ValuePrecision = 1375;

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output_EURange Variable.
        /// </summary>
        public const uint BoilerOutputPipeType_FlowTransmitter2_Output_EURange = 1376;

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output_InstrumentRange Variable.
        /// </summary>
        public const uint BoilerOutputPipeType_FlowTransmitter2_Output_InstrumentRange = 1377;

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint BoilerOutputPipeType_FlowTransmitter2_Output_EngineeringUnits = 1378;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_FlowTransmitter1_Output = 1135;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output_Definition Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_FlowTransmitter1_Output_Definition = 1379;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output_ValuePrecision Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_FlowTransmitter1_Output_ValuePrecision = 1380;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output_EURange Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_FlowTransmitter1_Output_EURange = 1381;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output_InstrumentRange Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_FlowTransmitter1_Output_InstrumentRange = 1382;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_FlowTransmitter1_Output_EngineeringUnits = 1383;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_Valve_Input = 1142;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input_Definition Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_Valve_Input_Definition = 1143;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input_ValuePrecision Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_Valve_Input_ValuePrecision = 1144;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input_EURange Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_Valve_Input_EURange = 1145;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input_InstrumentRange Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_Valve_Input_InstrumentRange = 1146;

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input_EngineeringUnits Variable.
        /// </summary>
        public const uint BoilerType_InputPipe_Valve_Input_EngineeringUnits = 1147;

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output Variable.
        /// </summary>
        public const uint BoilerType_Drum_LevelIndicator_Output = 1150;

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output_Definition Variable.
        /// </summary>
        public const uint BoilerType_Drum_LevelIndicator_Output_Definition = 1384;

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output_ValuePrecision Variable.
        /// </summary>
        public const uint BoilerType_Drum_LevelIndicator_Output_ValuePrecision = 1385;

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output_EURange Variable.
        /// </summary>
        public const uint BoilerType_Drum_LevelIndicator_Output_EURange = 1386;

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output_InstrumentRange Variable.
        /// </summary>
        public const uint BoilerType_Drum_LevelIndicator_Output_InstrumentRange = 1387;

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint BoilerType_Drum_LevelIndicator_Output_EngineeringUnits = 1388;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output Variable.
        /// </summary>
        public const uint BoilerType_OutputPipe_FlowTransmitter2_Output = 1158;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output_Definition Variable.
        /// </summary>
        public const uint BoilerType_OutputPipe_FlowTransmitter2_Output_Definition = 1389;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output_ValuePrecision Variable.
        /// </summary>
        public const uint BoilerType_OutputPipe_FlowTransmitter2_Output_ValuePrecision = 1390;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output_EURange Variable.
        /// </summary>
        public const uint BoilerType_OutputPipe_FlowTransmitter2_Output_EURange = 1391;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output_InstrumentRange Variable.
        /// </summary>
        public const uint BoilerType_OutputPipe_FlowTransmitter2_Output_InstrumentRange = 1392;

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint BoilerType_OutputPipe_FlowTransmitter2_Output_EngineeringUnits = 1393;

        /// <summary>
        /// The identifier for the BoilerType_FlowController_Measurement Variable.
        /// </summary>
        public const uint BoilerType_FlowController_Measurement = 1165;

        /// <summary>
        /// The identifier for the BoilerType_FlowController_SetPoint Variable.
        /// </summary>
        public const uint BoilerType_FlowController_SetPoint = 1166;

        /// <summary>
        /// The identifier for the BoilerType_FlowController_ControlOut Variable.
        /// </summary>
        public const uint BoilerType_FlowController_ControlOut = 1167;

        /// <summary>
        /// The identifier for the BoilerType_LevelController_Measurement Variable.
        /// </summary>
        public const uint BoilerType_LevelController_Measurement = 1169;

        /// <summary>
        /// The identifier for the BoilerType_LevelController_SetPoint Variable.
        /// </summary>
        public const uint BoilerType_LevelController_SetPoint = 1170;

        /// <summary>
        /// The identifier for the BoilerType_LevelController_ControlOut Variable.
        /// </summary>
        public const uint BoilerType_LevelController_ControlOut = 1171;

        /// <summary>
        /// The identifier for the BoilerType_CustomController_Input1 Variable.
        /// </summary>
        public const uint BoilerType_CustomController_Input1 = 1173;

        /// <summary>
        /// The identifier for the BoilerType_CustomController_Input2 Variable.
        /// </summary>
        public const uint BoilerType_CustomController_Input2 = 1174;

        /// <summary>
        /// The identifier for the BoilerType_CustomController_Input3 Variable.
        /// </summary>
        public const uint BoilerType_CustomController_Input3 = 1175;

        /// <summary>
        /// The identifier for the BoilerType_CustomController_ControlOut Variable.
        /// </summary>
        public const uint BoilerType_CustomController_ControlOut = 1176;

        /// <summary>
        /// The identifier for the BoilerType_CustomController_DescriptionX Variable.
        /// </summary>
        public const uint BoilerType_CustomController_DescriptionX = 1177;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_CurrentState Variable.
        /// </summary>
        public const uint BoilerType_Simulation_CurrentState = 1179;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_CurrentState_Id Variable.
        /// </summary>
        public const uint BoilerType_Simulation_CurrentState_Id = 1180;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_CurrentState_Name Variable.
        /// </summary>
        public const uint BoilerType_Simulation_CurrentState_Name = 1181;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_CurrentState_Number Variable.
        /// </summary>
        public const uint BoilerType_Simulation_CurrentState_Number = 1182;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_CurrentState_EffectiveDisplayName Variable.
        /// </summary>
        public const uint BoilerType_Simulation_CurrentState_EffectiveDisplayName = 1183;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_LastTransition Variable.
        /// </summary>
        public const uint BoilerType_Simulation_LastTransition = 1184;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_LastTransition_Id Variable.
        /// </summary>
        public const uint BoilerType_Simulation_LastTransition_Id = 1185;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_LastTransition_Name Variable.
        /// </summary>
        public const uint BoilerType_Simulation_LastTransition_Name = 1186;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_LastTransition_Number Variable.
        /// </summary>
        public const uint BoilerType_Simulation_LastTransition_Number = 1187;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint BoilerType_Simulation_LastTransition_TransitionTime = 1188;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Creatable Variable.
        /// </summary>
        public const uint BoilerType_Simulation_Creatable = 1412;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Deletable Variable.
        /// </summary>
        public const uint BoilerType_Simulation_Deletable = 1190;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_AutoDelete Variable.
        /// </summary>
        public const uint BoilerType_Simulation_AutoDelete = 1191;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RecycleCount Variable.
        /// </summary>
        public const uint BoilerType_Simulation_RecycleCount = 1192;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_InstanceCount Variable.
        /// </summary>
        public const uint BoilerType_Simulation_InstanceCount = 1413;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_MaxInstanceCount Variable.
        /// </summary>
        public const uint BoilerType_Simulation_MaxInstanceCount = 1414;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_MaxRecycleCount Variable.
        /// </summary>
        public const uint BoilerType_Simulation_MaxRecycleCount = 1415;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics = 1196;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_CreateSessionId Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics_CreateSessionId = 1197;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_CreateClientName Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics_CreateClientName = 1198;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_InvocationCreationTime Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics_InvocationCreationTime = 1199;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastTransitionTime Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics_LastTransitionTime = 1200;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodCall Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics_LastMethodCall = 1201;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodSessionId Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics_LastMethodSessionId = 1202;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodInputArguments Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics_LastMethodInputArguments = 1203;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics_LastMethodOutputArguments = 1204;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodCallTime Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics_LastMethodCallTime = 1205;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ProgramDiagnostics_LastMethodReturnStatus = 1206;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Ready_StateNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_Ready_StateNumber = 1417;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Running_StateNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_Running_StateNumber = 1419;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Suspended_StateNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_Suspended_StateNumber = 1421;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Halted_StateNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_Halted_StateNumber = 1423;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_HaltedToReady_TransitionNumber = 1425;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ReadyToRunning_TransitionNumber = 1427;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_RunningToHalted_TransitionNumber = 1429;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_RunningToReady_TransitionNumber = 1431;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_RunningToSuspended_TransitionNumber = 1433;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_SuspendedToRunning_TransitionNumber = 1435;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_SuspendedToHalted_TransitionNumber = 1437;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_SuspendedToReady_TransitionNumber = 1439;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint BoilerType_Simulation_ReadyToHalted_TransitionNumber = 1441;

        /// <summary>
        /// The identifier for the BoilerType_Simulation_UpdateRate Variable.
        /// </summary>
        public const uint BoilerType_Simulation_UpdateRate = 1239;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_FlowTransmitter1_Output = 1244;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_Definition Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_Definition = 1394;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_ValuePrecision Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_ValuePrecision = 1395;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_EURange Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_EURange = 1396;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_InstrumentRange Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_InstrumentRange = 1397;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_EngineeringUnits = 1398;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_Valve_Input = 1251;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input_Definition Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_Valve_Input_Definition = 1252;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input_ValuePrecision Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_Valve_Input_ValuePrecision = 1253;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input_EURange Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_Valve_Input_EURange = 1254;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input_InstrumentRange Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_Valve_Input_InstrumentRange = 1255;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input_EngineeringUnits Variable.
        /// </summary>
        public const uint Boilers_Boiler1_InputPipe_Valve_Input_EngineeringUnits = 1256;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Drum_LevelIndicator_Output = 1259;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output_Definition Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Drum_LevelIndicator_Output_Definition = 1399;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output_ValuePrecision Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Drum_LevelIndicator_Output_ValuePrecision = 1400;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output_EURange Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Drum_LevelIndicator_Output_EURange = 1401;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output_InstrumentRange Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Drum_LevelIndicator_Output_InstrumentRange = 1402;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Drum_LevelIndicator_Output_EngineeringUnits = 1403;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output Variable.
        /// </summary>
        public const uint Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output = 1267;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_Definition Variable.
        /// </summary>
        public const uint Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_Definition = 1404;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_ValuePrecision Variable.
        /// </summary>
        public const uint Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_ValuePrecision = 1405;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_EURange Variable.
        /// </summary>
        public const uint Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_EURange = 1406;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_InstrumentRange Variable.
        /// </summary>
        public const uint Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_InstrumentRange = 1407;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_EngineeringUnits Variable.
        /// </summary>
        public const uint Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_EngineeringUnits = 1408;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_FlowController_Measurement Variable.
        /// </summary>
        public const uint Boilers_Boiler1_FlowController_Measurement = 1274;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_FlowController_SetPoint Variable.
        /// </summary>
        public const uint Boilers_Boiler1_FlowController_SetPoint = 1275;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_FlowController_ControlOut Variable.
        /// </summary>
        public const uint Boilers_Boiler1_FlowController_ControlOut = 1276;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_LevelController_Measurement Variable.
        /// </summary>
        public const uint Boilers_Boiler1_LevelController_Measurement = 1278;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_LevelController_SetPoint Variable.
        /// </summary>
        public const uint Boilers_Boiler1_LevelController_SetPoint = 1279;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_LevelController_ControlOut Variable.
        /// </summary>
        public const uint Boilers_Boiler1_LevelController_ControlOut = 1280;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController_Input1 Variable.
        /// </summary>
        public const uint Boilers_Boiler1_CustomController_Input1 = 1282;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController_Input2 Variable.
        /// </summary>
        public const uint Boilers_Boiler1_CustomController_Input2 = 1283;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController_Input3 Variable.
        /// </summary>
        public const uint Boilers_Boiler1_CustomController_Input3 = 1284;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController_ControlOut Variable.
        /// </summary>
        public const uint Boilers_Boiler1_CustomController_ControlOut = 1285;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController_DescriptionX Variable.
        /// </summary>
        public const uint Boilers_Boiler1_CustomController_DescriptionX = 1286;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_CurrentState Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_CurrentState = 1288;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_CurrentState_Id Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_CurrentState_Id = 1289;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_CurrentState_Name Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_CurrentState_Name = 1290;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_CurrentState_Number Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_CurrentState_Number = 1291;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_CurrentState_EffectiveDisplayName Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_CurrentState_EffectiveDisplayName = 1292;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_LastTransition Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_LastTransition = 1293;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_LastTransition_Id Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_LastTransition_Id = 1294;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_LastTransition_Name Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_LastTransition_Name = 1295;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_LastTransition_Number Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_LastTransition_Number = 1296;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_LastTransition_TransitionTime = 1297;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Creatable Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Creatable = 1442;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Deletable Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Deletable = 1299;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_AutoDelete Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_AutoDelete = 1300;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RecycleCount Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_RecycleCount = 1301;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_InstanceCount Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_InstanceCount = 1443;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_MaxInstanceCount Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_MaxInstanceCount = 1444;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_MaxRecycleCount Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_MaxRecycleCount = 1445;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics = 1305;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_CreateSessionId Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics_CreateSessionId = 1306;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_CreateClientName Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics_CreateClientName = 1307;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_InvocationCreationTime Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics_InvocationCreationTime = 1308;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastTransitionTime Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics_LastTransitionTime = 1309;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodCall Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodCall = 1310;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodSessionId Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodSessionId = 1311;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodInputArguments Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodInputArguments = 1312;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodOutputArguments = 1313;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodCallTime Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodCallTime = 1314;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodReturnStatus = 1315;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Ready_StateNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Ready_StateNumber = 1447;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Running_StateNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Running_StateNumber = 1449;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Suspended_StateNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Suspended_StateNumber = 1451;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Halted_StateNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_Halted_StateNumber = 1453;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_HaltedToReady_TransitionNumber = 1455;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ReadyToRunning_TransitionNumber = 1457;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_RunningToHalted_TransitionNumber = 1459;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_RunningToReady_TransitionNumber = 1461;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_RunningToSuspended_TransitionNumber = 1463;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_SuspendedToRunning_TransitionNumber = 1465;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_SuspendedToHalted_TransitionNumber = 1467;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_SuspendedToReady_TransitionNumber = 1469;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_ReadyToHalted_TransitionNumber = 1471;

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_UpdateRate Variable.
        /// </summary>
        public const uint Boilers_Boiler1_Simulation_UpdateRate = 1348;
    }
    #endregion

    #region Method Node Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <summary>
        /// The identifier for the BoilerStateMachineType_Start Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Start = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.BoilerStateMachineType_Start, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Suspend Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Suspend = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.BoilerStateMachineType_Suspend, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Resume Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Resume = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.BoilerStateMachineType_Resume, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Halt Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Halt = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.BoilerStateMachineType_Halt, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Reset Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Reset = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.BoilerStateMachineType_Reset, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Start Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Start = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.BoilerType_Simulation_Start, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Suspend Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Suspend = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.BoilerType_Simulation_Suspend, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Resume Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Resume = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.BoilerType_Simulation_Resume, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Halt Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Halt = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.BoilerType_Simulation_Halt, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Reset Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Reset = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.BoilerType_Simulation_Reset, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Start Method.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Start = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.Boilers_Boiler1_Simulation_Start, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Suspend Method.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Suspend = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.Boilers_Boiler1_Simulation_Suspend, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Resume Method.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Resume = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.Boilers_Boiler1_Simulation_Resume, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Halt Method.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Halt = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.Boilers_Boiler1_Simulation_Halt, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Reset Method.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Reset = new ExpandedNodeId(CAS.UA.Server.Demo.Methods.Boilers_Boiler1_Simulation_Reset, CAS.UA.Server.Demo.Namespaces.Sample);
    }
    #endregion

    #region Object Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <summary>
        /// The identifier for the BoilerStateMachineType_FinalResultData Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_FinalResultData = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_FinalResultData, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Ready Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Ready = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_Ready, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Running Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Running = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_Running, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Suspended Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Suspended = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_Suspended, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Halted Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Halted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_Halted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_HaltedToReady Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_HaltedToReady = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_HaltedToReady, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ReadyToRunning Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ReadyToRunning = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_ReadyToRunning, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_RunningToHalted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_RunningToHalted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToReady Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_RunningToReady = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_RunningToReady, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToSuspended Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_RunningToSuspended = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_RunningToSuspended, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToRunning Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_SuspendedToRunning = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_SuspendedToRunning, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_SuspendedToHalted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_SuspendedToHalted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToReady Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_SuspendedToReady = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_SuspendedToReady, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ReadyToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ReadyToHalted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerStateMachineType_ReadyToHalted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1 Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_FlowTransmitter1 = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerInputPipeType_FlowTransmitter1, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_Valve = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerInputPipeType_Valve, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerDrumType_LevelIndicator = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerDrumType_LevelIndicator, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2 Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerOutputPipeType_FlowTransmitter2 = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerOutputPipeType_FlowTransmitter2, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_InputPipe, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1 Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_FlowTransmitter1 = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_InputPipe_FlowTransmitter1, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_Valve = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_InputPipe_Valve, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Drum Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Drum = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Drum, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Drum_LevelIndicator = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Drum_LevelIndicator, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_OutputPipe = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_OutputPipe, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2 Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_OutputPipe_FlowTransmitter2 = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_OutputPipe_FlowTransmitter2, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_FlowController Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_FlowController = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_FlowController, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_LevelController Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_LevelController = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_LevelController, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_CustomController Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_CustomController = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_CustomController, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_FinalResultData Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_FinalResultData = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_FinalResultData, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Ready Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Ready = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_Ready, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Running Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Running = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_Running, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Suspended Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Suspended = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_Suspended, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Halted Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Halted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_Halted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_HaltedToReady Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_HaltedToReady = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_HaltedToReady, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ReadyToRunning Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ReadyToRunning = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_ReadyToRunning, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_RunningToHalted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_RunningToHalted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToReady Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_RunningToReady = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_RunningToReady, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToSuspended Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_RunningToSuspended = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_RunningToSuspended, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToRunning Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_SuspendedToRunning = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_SuspendedToRunning, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_SuspendedToHalted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_SuspendedToHalted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToReady Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_SuspendedToReady = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_SuspendedToReady, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ReadyToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ReadyToHalted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.BoilerType_Simulation_ReadyToHalted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1 Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1 = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_InputPipe, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1 Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_FlowTransmitter1 = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_InputPipe_FlowTransmitter1, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_Valve = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_InputPipe_Valve, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Drum = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Drum, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Drum_LevelIndicator = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Drum_LevelIndicator, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_OutputPipe = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_OutputPipe, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2 Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_OutputPipe_FlowTransmitter2 = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_OutputPipe_FlowTransmitter2, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_FlowController Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_FlowController = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_FlowController, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_LevelController Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_LevelController = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_LevelController, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_CustomController = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_CustomController, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_FinalResultData Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_FinalResultData = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_FinalResultData, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Ready Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Ready = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_Ready, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Running Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Running = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_Running, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Suspended Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Suspended = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_Suspended, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Halted Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Halted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_Halted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_HaltedToReady Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_HaltedToReady = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_HaltedToReady, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ReadyToRunning Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ReadyToRunning = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_ReadyToRunning, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_RunningToHalted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_RunningToHalted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToReady Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_RunningToReady = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_RunningToReady, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToSuspended Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_RunningToSuspended = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_RunningToSuspended, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToRunning Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_SuspendedToRunning = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_SuspendedToRunning, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_SuspendedToHalted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_SuspendedToHalted, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToReady Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_SuspendedToReady = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_SuspendedToReady, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ReadyToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ReadyToHalted = new ExpandedNodeId(CAS.UA.Server.Demo.Objects.Boilers_Boiler1_Simulation_ReadyToHalted, CAS.UA.Server.Demo.Namespaces.Sample);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the GenericControllerType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GenericControllerType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.GenericControllerType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericSensorType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.GenericSensorType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericActuatorType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.GenericActuatorType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the CustomControllerType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CustomControllerType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.CustomControllerType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the ValveType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId ValveType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.ValveType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelControllerType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId LevelControllerType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.LevelControllerType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowControllerType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId FlowControllerType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.FlowControllerType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelIndicatorType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId LevelIndicatorType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.LevelIndicatorType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowTransmitterType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId FlowTransmitterType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.FlowTransmitterType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.BoilerStateMachineType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.BoilerInputPipeType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerDrumType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId BoilerDrumType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.BoilerDrumType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerOutputPipeType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId BoilerOutputPipeType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.BoilerOutputPipeType, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType = new ExpandedNodeId(CAS.UA.Server.Demo.ObjectTypes.BoilerType, CAS.UA.Server.Demo.Namespaces.Sample);
    }
    #endregion

    #region ReferenceType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ReferenceTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ReferenceTypeIds
    {
        /// <summary>
        /// The identifier for the FlowTo ReferenceType.
        /// </summary>
        public static readonly ExpandedNodeId FlowTo = new ExpandedNodeId(CAS.UA.Server.Demo.ReferenceTypes.FlowTo, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the HotFlowTo ReferenceType.
        /// </summary>
        public static readonly ExpandedNodeId HotFlowTo = new ExpandedNodeId(CAS.UA.Server.Demo.ReferenceTypes.HotFlowTo, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the SignalTo ReferenceType.
        /// </summary>
        public static readonly ExpandedNodeId SignalTo = new ExpandedNodeId(CAS.UA.Server.Demo.ReferenceTypes.SignalTo, CAS.UA.Server.Demo.Namespaces.Sample);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the GenericControllerType_Measurement Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericControllerType_Measurement = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericControllerType_Measurement, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericControllerType_SetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericControllerType_SetPoint = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericControllerType_SetPoint, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericControllerType_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericControllerType_ControlOut = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericControllerType_ControlOut, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericSensorType_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericSensorType_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericSensorType_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericSensorType_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericSensorType_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericSensorType_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericSensorType_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericSensorType_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericSensorType_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericSensorType_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericSensorType_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericSensorType_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericSensorType_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericActuatorType_Input, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericActuatorType_Input_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericActuatorType_Input_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericActuatorType_Input_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericActuatorType_Input_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the GenericActuatorType_Input_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId GenericActuatorType_Input_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.GenericActuatorType_Input_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the CustomControllerType_Input1 Variable.
        /// </summary>
        public static readonly ExpandedNodeId CustomControllerType_Input1 = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.CustomControllerType_Input1, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the CustomControllerType_Input2 Variable.
        /// </summary>
        public static readonly ExpandedNodeId CustomControllerType_Input2 = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.CustomControllerType_Input2, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the CustomControllerType_Input3 Variable.
        /// </summary>
        public static readonly ExpandedNodeId CustomControllerType_Input3 = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.CustomControllerType_Input3, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the CustomControllerType_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId CustomControllerType_ControlOut = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.CustomControllerType_ControlOut, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the CustomControllerType_DescriptionX Variable.
        /// </summary>
        public static readonly ExpandedNodeId CustomControllerType_DescriptionX = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.CustomControllerType_DescriptionX, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the ValveType_Input Variable.
        /// </summary>
        public static readonly ExpandedNodeId ValveType_Input = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.ValveType_Input, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the ValveType_Input_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId ValveType_Input_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.ValveType_Input_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the ValveType_Input_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId ValveType_Input_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.ValveType_Input_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the ValveType_Input_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId ValveType_Input_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.ValveType_Input_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the ValveType_Input_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId ValveType_Input_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.ValveType_Input_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the ValveType_Input_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId ValveType_Input_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.ValveType_Input_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelControllerType_Measurement Variable.
        /// </summary>
        public static readonly ExpandedNodeId LevelControllerType_Measurement = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.LevelControllerType_Measurement, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelControllerType_SetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId LevelControllerType_SetPoint = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.LevelControllerType_SetPoint, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelControllerType_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId LevelControllerType_ControlOut = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.LevelControllerType_ControlOut, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowControllerType_Measurement Variable.
        /// </summary>
        public static readonly ExpandedNodeId FlowControllerType_Measurement = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.FlowControllerType_Measurement, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowControllerType_SetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId FlowControllerType_SetPoint = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.FlowControllerType_SetPoint, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowControllerType_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId FlowControllerType_ControlOut = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.FlowControllerType_ControlOut, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId LevelIndicatorType_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.LevelIndicatorType_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId LevelIndicatorType_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.LevelIndicatorType_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId LevelIndicatorType_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.LevelIndicatorType_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId LevelIndicatorType_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.LevelIndicatorType_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId LevelIndicatorType_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.LevelIndicatorType_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the LevelIndicatorType_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId LevelIndicatorType_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.LevelIndicatorType_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId FlowTransmitterType_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.FlowTransmitterType_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId FlowTransmitterType_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.FlowTransmitterType_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId FlowTransmitterType_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.FlowTransmitterType_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId FlowTransmitterType_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.FlowTransmitterType_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId FlowTransmitterType_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.FlowTransmitterType_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the FlowTransmitterType_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId FlowTransmitterType_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.FlowTransmitterType_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_CurrentState Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_CurrentState = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_CurrentState, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_CurrentState_Id = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_CurrentState_Id, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_CurrentState_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_CurrentState_Name = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_CurrentState_Name, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_CurrentState_Number = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_CurrentState_Number, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_CurrentState_EffectiveDisplayName Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_CurrentState_EffectiveDisplayName = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_CurrentState_EffectiveDisplayName, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_LastTransition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_LastTransition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_LastTransition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_LastTransition_Id = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_LastTransition_Id, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_LastTransition_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_LastTransition_Name = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_LastTransition_Name, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_LastTransition_Number = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_LastTransition_Number, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_LastTransition_TransitionTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_LastTransition_TransitionTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Creatable Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Creatable = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_Creatable, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Deletable Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Deletable = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_Deletable, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_AutoDelete Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_AutoDelete = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_AutoDelete, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RecycleCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_RecycleCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_RecycleCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_InstanceCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_InstanceCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_InstanceCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_MaxInstanceCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_MaxInstanceCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_MaxInstanceCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_MaxRecycleCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_MaxRecycleCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_MaxRecycleCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics_CreateSessionId = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics_CreateSessionId, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics_CreateClientName = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics_CreateClientName, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics_InvocationCreationTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics_InvocationCreationTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics_LastTransitionTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics_LastTransitionTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics_LastMethodCall = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics_LastMethodCall, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics_LastMethodSessionId = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics_LastMethodSessionId, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics_LastMethodInputArguments = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics_LastMethodInputArguments, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics_LastMethodOutputArguments = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics_LastMethodOutputArguments, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics_LastMethodCallTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics_LastMethodCallTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ProgramDiagnostics_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ProgramDiagnostics_LastMethodReturnStatus = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ProgramDiagnostics_LastMethodReturnStatus, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Ready_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_Ready_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Running_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_Running_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Suspended_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_Suspended_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_Halted_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_Halted_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_HaltedToReady_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_HaltedToReady_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ReadyToRunning_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_RunningToHalted_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_RunningToHalted_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_RunningToReady_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_RunningToReady_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_RunningToSuspended_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_SuspendedToRunning_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_SuspendedToHalted_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_SuspendedToReady_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_ReadyToHalted_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerStateMachineType_UpdateRate Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerStateMachineType_UpdateRate = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerStateMachineType_UpdateRate, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_FlowTransmitter1_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_FlowTransmitter1_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_FlowTransmitter1_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_FlowTransmitter1_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_FlowTransmitter1_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_FlowTransmitter1_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_FlowTransmitter1_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_FlowTransmitter1_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_FlowTransmitter1_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_FlowTransmitter1_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_FlowTransmitter1_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_FlowTransmitter1_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_FlowTransmitter1_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_Valve_Input = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_Valve_Input, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_Valve_Input_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_Valve_Input_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_Valve_Input_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_Valve_Input_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_Valve_Input_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_Valve_Input_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_Valve_Input_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_Valve_Input_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerInputPipeType_Valve_Input_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerInputPipeType_Valve_Input_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerInputPipeType_Valve_Input_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerDrumType_LevelIndicator_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerDrumType_LevelIndicator_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerDrumType_LevelIndicator_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerDrumType_LevelIndicator_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerDrumType_LevelIndicator_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerDrumType_LevelIndicator_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerDrumType_LevelIndicator_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerDrumType_LevelIndicator_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerDrumType_LevelIndicator_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerDrumType_LevelIndicator_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerDrumType_LevelIndicator_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerDrumType_LevelIndicator_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerDrumType_LevelIndicator_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerOutputPipeType_FlowTransmitter2_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerOutputPipeType_FlowTransmitter2_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerOutputPipeType_FlowTransmitter2_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerOutputPipeType_FlowTransmitter2_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerOutputPipeType_FlowTransmitter2_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerOutputPipeType_FlowTransmitter2_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerOutputPipeType_FlowTransmitter2_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerOutputPipeType_FlowTransmitter2_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerOutputPipeType_FlowTransmitter2_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerOutputPipeType_FlowTransmitter2_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerOutputPipeType_FlowTransmitter2_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerOutputPipeType_FlowTransmitter2_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerOutputPipeType_FlowTransmitter2_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_FlowTransmitter1_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_FlowTransmitter1_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_FlowTransmitter1_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_FlowTransmitter1_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_FlowTransmitter1_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_FlowTransmitter1_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_FlowTransmitter1_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_FlowTransmitter1_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_FlowTransmitter1_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_FlowTransmitter1_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_FlowTransmitter1_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_FlowTransmitter1_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_FlowTransmitter1_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_Valve_Input = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_Valve_Input, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_Valve_Input_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_Valve_Input_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_Valve_Input_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_Valve_Input_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_Valve_Input_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_Valve_Input_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_Valve_Input_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_Valve_Input_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_InputPipe_Valve_Input_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_InputPipe_Valve_Input_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_InputPipe_Valve_Input_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Drum_LevelIndicator_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Drum_LevelIndicator_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Drum_LevelIndicator_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Drum_LevelIndicator_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Drum_LevelIndicator_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Drum_LevelIndicator_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Drum_LevelIndicator_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Drum_LevelIndicator_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Drum_LevelIndicator_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Drum_LevelIndicator_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Drum_LevelIndicator_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Drum_LevelIndicator_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Drum_LevelIndicator_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_OutputPipe_FlowTransmitter2_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_OutputPipe_FlowTransmitter2_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_OutputPipe_FlowTransmitter2_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_OutputPipe_FlowTransmitter2_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_OutputPipe_FlowTransmitter2_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_OutputPipe_FlowTransmitter2_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_OutputPipe_FlowTransmitter2_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_OutputPipe_FlowTransmitter2_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_OutputPipe_FlowTransmitter2_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_OutputPipe_FlowTransmitter2_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_OutputPipe_FlowTransmitter2_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_OutputPipe_FlowTransmitter2_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_OutputPipe_FlowTransmitter2_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_FlowController_Measurement Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_FlowController_Measurement = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_FlowController_Measurement, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_FlowController_SetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_FlowController_SetPoint = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_FlowController_SetPoint, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_FlowController_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_FlowController_ControlOut = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_FlowController_ControlOut, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_LevelController_Measurement Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_LevelController_Measurement = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_LevelController_Measurement, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_LevelController_SetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_LevelController_SetPoint = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_LevelController_SetPoint, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_LevelController_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_LevelController_ControlOut = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_LevelController_ControlOut, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_CustomController_Input1 Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_CustomController_Input1 = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_CustomController_Input1, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_CustomController_Input2 Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_CustomController_Input2 = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_CustomController_Input2, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_CustomController_Input3 Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_CustomController_Input3 = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_CustomController_Input3, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_CustomController_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_CustomController_ControlOut = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_CustomController_ControlOut, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_CustomController_DescriptionX Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_CustomController_DescriptionX = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_CustomController_DescriptionX, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_CurrentState Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_CurrentState = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_CurrentState, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_CurrentState_Id = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_CurrentState_Id, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_CurrentState_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_CurrentState_Name = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_CurrentState_Name, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_CurrentState_Number = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_CurrentState_Number, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_CurrentState_EffectiveDisplayName Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_CurrentState_EffectiveDisplayName = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_CurrentState_EffectiveDisplayName, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_LastTransition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_LastTransition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_LastTransition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_LastTransition_Id = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_LastTransition_Id, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_LastTransition_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_LastTransition_Name = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_LastTransition_Name, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_LastTransition_Number = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_LastTransition_Number, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_LastTransition_TransitionTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_LastTransition_TransitionTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Creatable Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Creatable = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_Creatable, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Deletable Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Deletable = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_Deletable, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_AutoDelete Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_AutoDelete = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_AutoDelete, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RecycleCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_RecycleCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_RecycleCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_InstanceCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_InstanceCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_InstanceCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_MaxInstanceCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_MaxInstanceCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_MaxInstanceCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_MaxRecycleCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_MaxRecycleCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_MaxRecycleCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics_CreateSessionId = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics_CreateSessionId, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics_CreateClientName = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics_CreateClientName, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics_InvocationCreationTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics_InvocationCreationTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics_LastTransitionTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics_LastTransitionTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics_LastMethodCall = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics_LastMethodCall, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics_LastMethodSessionId = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics_LastMethodSessionId, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics_LastMethodInputArguments = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics_LastMethodInputArguments, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics_LastMethodOutputArguments = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics_LastMethodOutputArguments, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics_LastMethodCallTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics_LastMethodCallTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ProgramDiagnostics_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ProgramDiagnostics_LastMethodReturnStatus = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ProgramDiagnostics_LastMethodReturnStatus, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Ready_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_Ready_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Running_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_Running_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Suspended_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_Suspended_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_Halted_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_Halted_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_HaltedToReady_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_HaltedToReady_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ReadyToRunning_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ReadyToRunning_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_RunningToHalted_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_RunningToHalted_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_RunningToReady_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_RunningToReady_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_RunningToSuspended_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_RunningToSuspended_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_SuspendedToRunning_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_SuspendedToHalted_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_SuspendedToReady_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_SuspendedToReady_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_ReadyToHalted_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_ReadyToHalted_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the BoilerType_Simulation_UpdateRate Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilerType_Simulation_UpdateRate = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.BoilerType_Simulation_UpdateRate, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_FlowTransmitter1_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_FlowTransmitter1_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_FlowTransmitter1_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_Valve_Input = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_Valve_Input, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_Valve_Input_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_Valve_Input_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_Valve_Input_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_Valve_Input_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_Valve_Input_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_Valve_Input_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_Valve_Input_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_Valve_Input_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_InputPipe_Valve_Input_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_InputPipe_Valve_Input_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_InputPipe_Valve_Input_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Drum_LevelIndicator_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Drum_LevelIndicator_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Drum_LevelIndicator_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Drum_LevelIndicator_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Drum_LevelIndicator_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Drum_LevelIndicator_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Drum_LevelIndicator_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Drum_LevelIndicator_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Drum_LevelIndicator_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Drum_LevelIndicator_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Drum_LevelIndicator_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Drum_LevelIndicator_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Drum_LevelIndicator_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_Definition Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_Definition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_Definition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_ValuePrecision Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_ValuePrecision = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_ValuePrecision, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_EURange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_EURange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_InstrumentRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_InstrumentRange = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_InstrumentRange, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_EngineeringUnits = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_OutputPipe_FlowTransmitter2_Output_EngineeringUnits, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_FlowController_Measurement Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_FlowController_Measurement = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_FlowController_Measurement, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_FlowController_SetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_FlowController_SetPoint = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_FlowController_SetPoint, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_FlowController_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_FlowController_ControlOut = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_FlowController_ControlOut, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_LevelController_Measurement Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_LevelController_Measurement = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_LevelController_Measurement, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_LevelController_SetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_LevelController_SetPoint = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_LevelController_SetPoint, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_LevelController_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_LevelController_ControlOut = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_LevelController_ControlOut, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController_Input1 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_CustomController_Input1 = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_CustomController_Input1, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController_Input2 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_CustomController_Input2 = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_CustomController_Input2, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController_Input3 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_CustomController_Input3 = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_CustomController_Input3, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_CustomController_ControlOut = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_CustomController_ControlOut, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_CustomController_DescriptionX Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_CustomController_DescriptionX = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_CustomController_DescriptionX, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_CurrentState Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_CurrentState = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_CurrentState, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_CurrentState_Id = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_CurrentState_Id, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_CurrentState_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_CurrentState_Name = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_CurrentState_Name, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_CurrentState_Number = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_CurrentState_Number, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_CurrentState_EffectiveDisplayName Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_CurrentState_EffectiveDisplayName = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_CurrentState_EffectiveDisplayName, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_LastTransition Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_LastTransition = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_LastTransition, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_LastTransition_Id = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_LastTransition_Id, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_LastTransition_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_LastTransition_Name = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_LastTransition_Name, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_LastTransition_Number = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_LastTransition_Number, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_LastTransition_TransitionTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_LastTransition_TransitionTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Creatable Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Creatable = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_Creatable, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Deletable Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Deletable = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_Deletable, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_AutoDelete Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_AutoDelete = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_AutoDelete, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RecycleCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_RecycleCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_RecycleCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_InstanceCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_InstanceCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_InstanceCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_MaxInstanceCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_MaxInstanceCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_MaxInstanceCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_MaxRecycleCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_MaxRecycleCount = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_MaxRecycleCount, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics_CreateSessionId = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics_CreateSessionId, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics_CreateClientName = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics_CreateClientName, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics_InvocationCreationTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics_InvocationCreationTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics_LastTransitionTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics_LastTransitionTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodCall = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodCall, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodSessionId = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodSessionId, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodInputArguments = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodInputArguments, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodOutputArguments = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodOutputArguments, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodCallTime = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodCallTime, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodReturnStatus = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ProgramDiagnostics_LastMethodReturnStatus, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Ready_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_Ready_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Running_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_Running_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Suspended_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_Suspended_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_Halted_StateNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_Halted_StateNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_HaltedToReady_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_HaltedToReady_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ReadyToRunning_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ReadyToRunning_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_RunningToHalted_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_RunningToHalted_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_RunningToReady_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_RunningToReady_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_RunningToSuspended_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_RunningToSuspended_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_SuspendedToRunning_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_SuspendedToHalted_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_SuspendedToReady_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_SuspendedToReady_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_ReadyToHalted_TransitionNumber = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_ReadyToHalted_TransitionNumber, CAS.UA.Server.Demo.Namespaces.Sample);

        /// <summary>
        /// The identifier for the Boilers_Boiler1_Simulation_UpdateRate Variable.
        /// </summary>
        public static readonly ExpandedNodeId Boilers_Boiler1_Simulation_UpdateRate = new ExpandedNodeId(CAS.UA.Server.Demo.Variables.Boilers_Boiler1_Simulation_UpdateRate, CAS.UA.Server.Demo.Namespaces.Sample);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the Boiler1 component.
        /// </summary>
        public const string Boiler1 = "Boiler #1";

        /// <summary>
        /// The BrowseName for the BoilerDrumType component.
        /// </summary>
        public const string BoilerDrumType = "BoilerDrumType";

        /// <summary>
        /// The BrowseName for the BoilerInputPipeType component.
        /// </summary>
        public const string BoilerInputPipeType = "BoilerInputPipeType";

        /// <summary>
        /// The BrowseName for the BoilerOutputPipeType component.
        /// </summary>
        public const string BoilerOutputPipeType = "BoilerOutputPipeType";

        /// <summary>
        /// The BrowseName for the Boilers component.
        /// </summary>
        public const string Boilers = "Boilers";

        /// <summary>
        /// The BrowseName for the BoilerStateMachineType component.
        /// </summary>
        public const string BoilerStateMachineType = "BoilerStateMachineType";

        /// <summary>
        /// The BrowseName for the BoilerType component.
        /// </summary>
        public const string BoilerType = "BoilerType";

        /// <summary>
        /// The BrowseName for the ControlOut component.
        /// </summary>
        public const string ControlOut = "ControlOut";

        /// <summary>
        /// The BrowseName for the CustomController component.
        /// </summary>
        public const string CustomController = "CCX001";

        /// <summary>
        /// The BrowseName for the CustomControllerType component.
        /// </summary>
        public const string CustomControllerType = "CustomControllerType";

        /// <summary>
        /// The BrowseName for the DescriptionX component.
        /// </summary>
        public const string DescriptionX = "Description";

        /// <summary>
        /// The BrowseName for the Drum component.
        /// </summary>
        public const string Drum = "DrumX001";

        /// <summary>
        /// The BrowseName for the FlowController component.
        /// </summary>
        public const string FlowController = "FCX001";

        /// <summary>
        /// The BrowseName for the FlowControllerType component.
        /// </summary>
        public const string FlowControllerType = "FlowControllerType";

        /// <summary>
        /// The BrowseName for the FlowTo component.
        /// </summary>
        public const string FlowTo = "FlowTo";

        /// <summary>
        /// The BrowseName for the FlowTransmitter1 component.
        /// </summary>
        public const string FlowTransmitter1 = "FTX001";

        /// <summary>
        /// The BrowseName for the FlowTransmitter2 component.
        /// </summary>
        public const string FlowTransmitter2 = "FTX002";

        /// <summary>
        /// The BrowseName for the FlowTransmitterType component.
        /// </summary>
        public const string FlowTransmitterType = "FlowTransmitterType";

        /// <summary>
        /// The BrowseName for the GenericActuatorType component.
        /// </summary>
        public const string GenericActuatorType = "GenericActuatorType";

        /// <summary>
        /// The BrowseName for the GenericControllerType component.
        /// </summary>
        public const string GenericControllerType = "GenericControllerType";

        /// <summary>
        /// The BrowseName for the GenericSensorType component.
        /// </summary>
        public const string GenericSensorType = "GenericSensorType";

        /// <summary>
        /// The BrowseName for the HotFlowTo component.
        /// </summary>
        public const string HotFlowTo = "HotFlowTo";

        /// <summary>
        /// The BrowseName for the Input component.
        /// </summary>
        public const string Input = "Input";

        /// <summary>
        /// The BrowseName for the Input1 component.
        /// </summary>
        public const string Input1 = "Input1";

        /// <summary>
        /// The BrowseName for the Input2 component.
        /// </summary>
        public const string Input2 = "Input2";

        /// <summary>
        /// The BrowseName for the Input3 component.
        /// </summary>
        public const string Input3 = "Input3";

        /// <summary>
        /// The BrowseName for the InputPipe component.
        /// </summary>
        public const string InputPipe = "PipeX001";

        /// <summary>
        /// The BrowseName for the LevelController component.
        /// </summary>
        public const string LevelController = "LCX001";

        /// <summary>
        /// The BrowseName for the LevelControllerType component.
        /// </summary>
        public const string LevelControllerType = "LevelControllerType";

        /// <summary>
        /// The BrowseName for the LevelIndicator component.
        /// </summary>
        public const string LevelIndicator = "LIX001";

        /// <summary>
        /// The BrowseName for the LevelIndicatorType component.
        /// </summary>
        public const string LevelIndicatorType = "LevelIndicatorType";

        /// <summary>
        /// The BrowseName for the Measurement component.
        /// </summary>
        public const string Measurement = "Measurement";

        /// <summary>
        /// The BrowseName for the Output component.
        /// </summary>
        public const string Output = "Output";

        /// <summary>
        /// The BrowseName for the OutputPipe component.
        /// </summary>
        public const string OutputPipe = "PipeX002";

        /// <summary>
        /// The BrowseName for the SetPoint component.
        /// </summary>
        public const string SetPoint = "SetPoint";

        /// <summary>
        /// The BrowseName for the SignalTo component.
        /// </summary>
        public const string SignalTo = "SignalTo";

        /// <summary>
        /// The BrowseName for the Simulation component.
        /// </summary>
        public const string Simulation = "Simulation";

        /// <summary>
        /// The BrowseName for the UpdateRate component.
        /// </summary>
        public const string UpdateRate = "UpdateRate";

        /// <summary>
        /// The BrowseName for the Valve component.
        /// </summary>
        public const string Valve = "ValveX001";

        /// <summary>
        /// The BrowseName for the ValveType component.
        /// </summary>
        public const string ValveType = "ValveType";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the Sample namespace (.NET code namespace is 'CAS.UA.Server.Demo').
        /// </summary>
        public const string Sample = "http://cas.eu/UA/Demo/";

        /// <summary>
        /// Returns a namespace table with all of the URIs defined.
        /// </summary>
        /// <remarks>
        /// This table is was used to create any relative paths in the model design.
        /// </remarks>
        public static NamespaceTable GetNamespaceTable()
        {
            FieldInfo[] fields = typeof(Namespaces).GetFields(BindingFlags.Public | BindingFlags.Static);

            NamespaceTable namespaceTable = new NamespaceTable();

            foreach (FieldInfo field in fields)
            {
                string namespaceUri = (string)field.GetValue(typeof(Namespaces));

                if (namespaceTable.GetIndex(namespaceUri) == -1)
                {
                    namespaceTable.Append(namespaceUri);
                }
            }

            return namespaceTable;
        }
    }
    #endregion
    
    #region GenericControllerState Class
    #if (!OPCUA_EXCLUDE_GenericControllerState)
    /// <summary>
    /// Stores an instance of the GenericControllerType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericControllerState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GenericControllerState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.GenericControllerType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////yRggAABAAAAAQAdAAAAR2VuZXJpY0NvbnRy" +
           "b2xsZXJUeXBlSW5zdGFuY2UBAdIAAwAAAAAYAAAAQSBnZW5lcmljIFBJRCBjb250cm9sbGVyAQHSAP//" +
           "//8DAAAAFWCJCgIAAAABAAsAAABNZWFzdXJlbWVudAEB3AMALgBE3AMAAAAL/////wEB/////wAAAAAV" +
           "YIkKAgAAAAEACAAAAFNldFBvaW50AQHdAwAuAETdAwAAAAv/////AwP/////AAAAABVgiQoCAAAAAQAK" +
           "AAAAQ29udHJvbE91dAEB3gMALgBE3gMAAAAL/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Measurement Property.
        /// </summary>
        public PropertyState<double> Measurement
        {
            get
            { 
                return m_measurement;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_measurement, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_measurement = value;
            }
        }

        /// <summary>
        /// A description for the SetPoint Property.
        /// </summary>
        public PropertyState<double> SetPoint
        {
            get
            { 
                return m_setPoint;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_setPoint, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_setPoint = value;
            }
        }

        /// <summary>
        /// A description for the ControlOut Property.
        /// </summary>
        public PropertyState<double> ControlOut
        {
            get
            { 
                return m_controlOut;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_controlOut, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_controlOut = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_measurement != null)
            {
                children.Add(m_measurement);
            }

            if (m_setPoint != null)
            {
                children.Add(m_setPoint);
            }

            if (m_controlOut != null)
            {
                children.Add(m_controlOut);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case CAS.UA.Server.Demo.BrowseNames.Measurement:
                {
                    if (createOrReplace)
                    {
                        if (Measurement == null)
                        {
                            if (replacement == null)
                            {
                                Measurement = new PropertyState<double>(this);
                            }
                            else
                            {
                                Measurement = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = Measurement;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.SetPoint:
                {
                    if (createOrReplace)
                    {
                        if (SetPoint == null)
                        {
                            if (replacement == null)
                            {
                                SetPoint = new PropertyState<double>(this);
                            }
                            else
                            {
                                SetPoint = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = SetPoint;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.ControlOut:
                {
                    if (createOrReplace)
                    {
                        if (ControlOut == null)
                        {
                            if (replacement == null)
                            {
                                ControlOut = new PropertyState<double>(this);
                            }
                            else
                            {
                                ControlOut = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = ControlOut;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<double> m_measurement;
        private PropertyState<double> m_setPoint;
        private PropertyState<double> m_controlOut;
        #endregion
    }
    #endif
    #endregion

    #region GenericSensorState Class
    #if (!OPCUA_EXCLUDE_GenericSensorState)
    /// <summary>
    /// Stores an instance of the GenericSensorType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericSensorState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GenericSensorState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.GenericSensorType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////yRggAABAAAAAQAZAAAAR2VuZXJpY1NlbnNv" +
           "clR5cGVJbnN0YW5jZQEB3wMDAAAAACsAAABBIGdlbmVyaWMgc2Vuc29yIHRoYXQgcmVhZCBhIHByb2Nl" +
           "c3MgdmFsdWUuAQHfA/////8BAAAAFWCJCgIAAAABAAYAAABPdXRwdXQBAeADAC8BAEAJ4AMAAAAL////" +
           "/wEB/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAUcFAC4AREcFAAABAHQD/////wEB/////wAA" +
           "AAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Output Variable.
        /// </summary>
        public AnalogItemState<double> Output
        {
            get
            { 
                return m_output;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_output, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_output = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_output != null)
            {
                children.Add(m_output);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case CAS.UA.Server.Demo.BrowseNames.Output:
                {
                    if (createOrReplace)
                    {
                        if (Output == null)
                        {
                            if (replacement == null)
                            {
                                Output = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                Output = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = Output;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private AnalogItemState<double> m_output;
        #endregion
    }
    #endif
    #endregion

    #region GenericActuatorState Class
    #if (!OPCUA_EXCLUDE_GenericActuatorState)
    /// <summary>
    /// Stores an instance of the GenericActuatorType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GenericActuatorState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GenericActuatorState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.GenericActuatorType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////yRggAABAAAAAQAbAAAAR2VuZXJpY0FjdHVh" +
           "dG9yVHlwZUluc3RhbmNlAQHmAwMAAAAAQQAAAFJlcHJlc2VudHMgYSBwaWVjZSBvZiBlcXVpcG1lbnQg" +
           "dGhhdCBjYXVzZXMgc29tZSBhY3Rpb24gdG8gb2NjdXIuAQHmA/////8BAAAAFWCJCgIAAAABAAUAAABJ" +
           "bnB1dAEB5wMALwEAQAnnAwAAAAv/////AgL/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEB6gMA" +
           "LgBE6gMAAAEAdAP/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Input Variable.
        /// </summary>
        public AnalogItemState<double> Input
        {
            get
            { 
                return m_input;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_input, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_input = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_input != null)
            {
                children.Add(m_input);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case CAS.UA.Server.Demo.BrowseNames.Input:
                {
                    if (createOrReplace)
                    {
                        if (Input == null)
                        {
                            if (replacement == null)
                            {
                                Input = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                Input = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = Input;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private AnalogItemState<double> m_input;
        #endregion
    }
    #endif
    #endregion

    #region CustomControllerState Class
    #if (!OPCUA_EXCLUDE_CustomControllerState)
    /// <summary>
    /// Stores an instance of the CustomControllerType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CustomControllerState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CustomControllerState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.CustomControllerType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////yRggAABAAAAAQAcAAAAQ3VzdG9tQ29udHJv" +
           "bGxlclR5cGVJbnN0YW5jZQEBAQIDAAAAACUAAABBIGN1c3RvbSBQSUQgY29udHJvbGxlciB3aXRoIDMg" +
           "aW5wdXRzAQEBAv////8FAAAAFWCJCgIAAAABAAYAAABJbnB1dDEBAe0DAC4ARO0DAAAAC/////8CAv//" +
           "//8AAAAAFWCJCgIAAAABAAYAAABJbnB1dDIBAe4DAC4ARO4DAAAAC/////8CAv////8AAAAAFWCJCgIA" +
           "AAABAAYAAABJbnB1dDMBAe8DAC4ARO8DAAAAC/////8CAv////8AAAAAFWCJCgIAAAABAAoAAABDb250" +
           "cm9sT3V0AQHwAwAuAETwAwAAAAv/////AQH/////AAAAABVgyQoCAAAADAAAAERlc2NyaXB0aW9uWAEA" +
           "CwAAAERlc2NyaXB0aW9uAQHxAwAuAETxAwAAABX/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Input1 Property.
        /// </summary>
        public PropertyState<double> Input1
        {
            get
            { 
                return m_input1;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_input1, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_input1 = value;
            }
        }

        /// <summary>
        /// A description for the Input2 Property.
        /// </summary>
        public PropertyState<double> Input2
        {
            get
            { 
                return m_input2;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_input2, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_input2 = value;
            }
        }

        /// <summary>
        /// A description for the Input3 Property.
        /// </summary>
        public PropertyState<double> Input3
        {
            get
            { 
                return m_input3;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_input3, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_input3 = value;
            }
        }

        /// <summary>
        /// A description for the ControlOut Property.
        /// </summary>
        public PropertyState<double> ControlOut
        {
            get
            { 
                return m_controlOut;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_controlOut, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_controlOut = value;
            }
        }

        /// <summary>
        /// A description for the Description Property.
        /// </summary>
        public PropertyState<LocalizedText> DescriptionX
        {
            get
            { 
                return m_descriptionX;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_descriptionX, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_descriptionX = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_input1 != null)
            {
                children.Add(m_input1);
            }

            if (m_input2 != null)
            {
                children.Add(m_input2);
            }

            if (m_input3 != null)
            {
                children.Add(m_input3);
            }

            if (m_controlOut != null)
            {
                children.Add(m_controlOut);
            }

            if (m_descriptionX != null)
            {
                children.Add(m_descriptionX);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case CAS.UA.Server.Demo.BrowseNames.Input1:
                {
                    if (createOrReplace)
                    {
                        if (Input1 == null)
                        {
                            if (replacement == null)
                            {
                                Input1 = new PropertyState<double>(this);
                            }
                            else
                            {
                                Input1 = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = Input1;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.Input2:
                {
                    if (createOrReplace)
                    {
                        if (Input2 == null)
                        {
                            if (replacement == null)
                            {
                                Input2 = new PropertyState<double>(this);
                            }
                            else
                            {
                                Input2 = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = Input2;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.Input3:
                {
                    if (createOrReplace)
                    {
                        if (Input3 == null)
                        {
                            if (replacement == null)
                            {
                                Input3 = new PropertyState<double>(this);
                            }
                            else
                            {
                                Input3 = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = Input3;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.ControlOut:
                {
                    if (createOrReplace)
                    {
                        if (ControlOut == null)
                        {
                            if (replacement == null)
                            {
                                ControlOut = new PropertyState<double>(this);
                            }
                            else
                            {
                                ControlOut = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = ControlOut;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.DescriptionX:
                {
                    if (createOrReplace)
                    {
                        if (DescriptionX == null)
                        {
                            if (replacement == null)
                            {
                                DescriptionX = new PropertyState<LocalizedText>(this);
                            }
                            else
                            {
                                DescriptionX = (PropertyState<LocalizedText>)replacement;
                            }
                        }
                    }

                    instance = DescriptionX;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<double> m_input1;
        private PropertyState<double> m_input2;
        private PropertyState<double> m_input3;
        private PropertyState<double> m_controlOut;
        private PropertyState<LocalizedText> m_descriptionX;
        #endregion
    }
    #endif
    #endregion

    #region ValveState Class
    #if (!OPCUA_EXCLUDE_ValveState)
    /// <summary>
    /// Stores an instance of the ValveType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ValveState : GenericActuatorState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ValveState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.ValveType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////yRggAABAAAAAQARAAAAVmFsdmVUeXBlSW5z" +
           "dGFuY2UBAfIDAwAAAAAyAAAAQW4gYWN0dWF0b3IgdGhhdCBjb250cm9scyB0aGUgZmxvdyB0aHJvdWdo" +
           "IGEgcGlwZS4BAfID/////wEAAAAVYIkKAgAAAAEABQAAAElucHV0AQHzAwAvAQBACfMDAAAAC/////8C" +
           "Av////8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQH2AwAuAET2AwAAAQB0A/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region LevelControllerState Class
    #if (!OPCUA_EXCLUDE_LevelControllerState)
    /// <summary>
    /// Stores an instance of the LevelControllerType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LevelControllerState : GenericControllerState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public LevelControllerState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.LevelControllerType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////yRggAABAAAAAQAbAAAATGV2ZWxDb250cm9s" +
           "bGVyVHlwZUluc3RhbmNlAQH5AwMAAAAAMAAAAEEgY29udHJvbGxlciBmb3IgdGhlIGxldmVsIG9mIGEg" +
           "Zmx1aWQgaW4gYSBkcnVtLgEB+QP/////AwAAABVgiQoCAAAAAQALAAAATWVhc3VyZW1lbnQBAfoDAC4A" +
           "RPoDAAAAC/////8BAf////8AAAAAFWCJCgIAAAABAAgAAABTZXRQb2ludAEB+wMALgBE+wMAAAAL////" +
           "/wMD/////wAAAAAVYIkKAgAAAAEACgAAAENvbnRyb2xPdXQBAfwDAC4ARPwDAAAAC/////8BAf////8A" +
           "AAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region FlowControllerState Class
    #if (!OPCUA_EXCLUDE_FlowControllerState)
    /// <summary>
    /// Stores an instance of the FlowControllerType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FlowControllerState : GenericControllerState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public FlowControllerState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.FlowControllerType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////yRggAABAAAAAQAaAAAARmxvd0NvbnRyb2xs" +
           "ZXJUeXBlSW5zdGFuY2UBAf0DAwAAAAA0AAAAQSBjb250cm9sbGVyIGZvciB0aGUgZmxvdyBvZiBhIGZs" +
           "dWlkIHRocm91Z2ggYSBwaXBlLgEB/QP/////AwAAABVgiQoCAAAAAQALAAAATWVhc3VyZW1lbnQBAf4D" +
           "AC4ARP4DAAAAC/////8BAf////8AAAAAFWCJCgIAAAABAAgAAABTZXRQb2ludAEB/wMALgBE/wMAAAAL" +
           "/////wMD/////wAAAAAVYIkKAgAAAAEACgAAAENvbnRyb2xPdXQBAQAEAC4ARAAEAAAAC/////8BAf//" +
           "//8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region LevelIndicatorState Class
    #if (!OPCUA_EXCLUDE_LevelIndicatorState)
    /// <summary>
    /// Stores an instance of the LevelIndicatorType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LevelIndicatorState : GenericSensorState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public LevelIndicatorState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.LevelIndicatorType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////yRggAABAAAAAQAaAAAATGV2ZWxJbmRpY2F0" +
           "b3JUeXBlSW5zdGFuY2UBAQEEAwAAAAA2AAAAQSBzZW5zb3IgdGhhdCByZXBvcnRzIHRoZSBsZXZlbCBv" +
           "ZiBhIGxpcXVpZCBpbiBhIHRhbmsuAQEBBP////8BAAAAFWCJCgIAAAABAAYAAABPdXRwdXQBAQIEAC8B" +
           "AEAJAgQAAAAL/////wEB/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAUwFAC4AREwFAAABAHQD" +
           "/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region FlowTransmitterState Class
    #if (!OPCUA_EXCLUDE_FlowTransmitterState)
    /// <summary>
    /// Stores an instance of the FlowTransmitterType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FlowTransmitterState : GenericSensorState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public FlowTransmitterState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.FlowTransmitterType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////yRggAABAAAAAQAbAAAARmxvd1RyYW5zbWl0" +
           "dGVyVHlwZUluc3RhbmNlAQEIBAMAAAAAOgAAAEEgc2Vuc29yIHRoYXQgcmVwb3J0cyB0aGUgZmxvdyBv" +
           "ZiBhIGxpcXVpZCB0aHJvdWdoIGEgcGlwZS4BAQgE/////wEAAAAVYIkKAgAAAAEABgAAAE91dHB1dAEB" +
           "CQQALwEAQAkJBAAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBUQUALgBEUQUA" +
           "AAEAdAP/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region BoilerStateMachineState Class
    #if (!OPCUA_EXCLUDE_BoilerStateMachineState)
    /// <summary>
    /// Stores an instance of the BoilerStateMachineType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerStateMachineState : ProgramStateMachineState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public BoilerStateMachineState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.BoilerStateMachineType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////yRggAABAAAAAQAeAAAAQm9pbGVyU3RhdGVN" +
           "YWNoaW5lVHlwZUluc3RhbmNlAQEPBAMAAAAAPgAAAEEgcHJvZ3JhbSB0aGF0IHByb2R1Y2VzIHNpbXVs" +
           "YXRlZCB2YWx1ZXMgZm9yIGEgcnVubmluZyBib2lsZXIuAQEPBP////8KAAAAFWCJCgIAAAAAAAwAAABD" +
           "dXJyZW50U3RhdGUBARAEAC8BAMgKEAQAAAAV/////wEB/////wIAAAAVYIkKAgAAAAAAAgAAAElkAQER" +
           "BAAuAEQRBAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAATnVtYmVyAQETBAAuAEQTBAAAAAf/" +
           "////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BARUEAC8BAM8KFQQAAAAV////" +
           "/wEB/////wMAAAAVYIkKAgAAAAAAAgAAAElkAQEWBAAuAEQWBAAAABH/////AQH/////AAAAABVgiQoC" +
           "AAAAAAAGAAAATnVtYmVyAQEYBAAuAEQYBAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJh" +
           "bnNpdGlvblRpbWUBARkEAC4ARBkEAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAERlbGV0" +
           "YWJsZQEBGwQALgBEGwQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFJlY3ljbGVDb3VudAEB" +
           "HQQALgBEHQQAAAAG/////wEB/////wAAAAAkYYIKBAAAAAAABQAAAFN0YXJ0AQFHBAMAAAAASwAAAENh" +
           "dXNlcyB0aGUgUHJvZ3JhbSB0byB0cmFuc2l0aW9uIGZyb20gdGhlIFJlYWR5IHN0YXRlIHRvIHRoZSBS" +
           "dW5uaW5nIHN0YXRlLgAvAQB6CUcEAAABAQEAAAAANQEBATcEAAAAACRhggoEAAAAAAAHAAAAU3VzcGVu" +
           "ZAEBSAQDAAAAAE8AAABDYXVzZXMgdGhlIFByb2dyYW0gdG8gdHJhbnNpdGlvbiBmcm9tIHRoZSBSdW5u" +
           "aW5nIHN0YXRlIHRvIHRoZSBTdXNwZW5kZWQgc3RhdGUuAC8BAHsJSAQAAAEBAQAAAAA1AQEBPQQAAAAA" +
           "JGGCCgQAAAAAAAYAAABSZXN1bWUBAUkEAwAAAABPAAAAQ2F1c2VzIHRoZSBQcm9ncmFtIHRvIHRyYW5z" +
           "aXRpb24gZnJvbSB0aGUgU3VzcGVuZGVkIHN0YXRlIHRvIHRoZSBSdW5uaW5nIHN0YXRlLgAvAQB8CUkE" +
           "AAABAQEAAAAANQEBAT8EAAAAACRhggoEAAAAAAAEAAAASGFsdAEBSgQDAAAAAGAAAABDYXVzZXMgdGhl" +
           "IFByb2dyYW0gdG8gdHJhbnNpdGlvbiBmcm9tIHRoZSBSZWFkeSwgUnVubmluZyBvciBTdXNwZW5kZWQg" +
           "c3RhdGUgdG8gdGhlIEhhbHRlZCBzdGF0ZS4ALwEAfQlKBAAAAQEDAAAAADUBAQE5BAA1AQEBQQQANQEB" +
           "AUUEAAAAACRhggoEAAAAAAAFAAAAUmVzZXQBAUsEAwAAAABKAAAAQ2F1c2VzIHRoZSBQcm9ncmFtIHRv" +
           "IHRyYW5zaXRpb24gZnJvbSB0aGUgSGFsdGVkIHN0YXRlIHRvIHRoZSBSZWFkeSBzdGF0ZS4ALwEAfglL" +
           "BAAAAQEBAAAAADUBAQE1BAAAAAA1YIkKAgAAAAEACgAAAFVwZGF0ZVJhdGUBAUwEAwAAAAAmAAAAVGhl" +
           "IHJhdGUgYXQgd2hpY2ggdGhlIHNpbXVsYXRpb24gcnVucy4ALgBETAQAAAAH/////wMD/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// The rate at which the simulation runs.
        /// </summary>
        public PropertyState<uint> UpdateRate
        {
            get
            { 
                return m_updateRate;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_updateRate, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_updateRate = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_updateRate != null)
            {
                children.Add(m_updateRate);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case CAS.UA.Server.Demo.BrowseNames.UpdateRate:
                {
                    if (createOrReplace)
                    {
                        if (UpdateRate == null)
                        {
                            if (replacement == null)
                            {
                                UpdateRate = new PropertyState<uint>(this);
                            }
                            else
                            {
                                UpdateRate = (PropertyState<uint>)replacement;
                            }
                        }
                    }

                    instance = UpdateRate;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<uint> m_updateRate;
        #endregion
    }
    #endif
    #endregion

    #region BoilerInputPipeState Class
    #if (!OPCUA_EXCLUDE_BoilerInputPipeState)
    /// <summary>
    /// Stores an instance of the BoilerInputPipeType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerInputPipeState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public BoilerInputPipeState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.BoilerInputPipeType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////wRggAABAAAAAQAbAAAAQm9pbGVySW5wdXRQ" +
           "aXBlVHlwZUluc3RhbmNlAQFNBAEBTQQBAAAAADAAAQFOBAIAAADEYMAKAQAAABAAAABGbG93VHJhbnNt" +
           "aXR0ZXIxAQAGAAAARlRYMDAxAQFOBAMAAAAAEAAAAEZsb3dUcmFuc21pdHRlcjEALwEBCAROBAAAAQEA" +
           "AAAAMAEBAU0EAQAAABVgiQoCAAAAAQAGAAAAT3V0cHV0AQFPBAAvAQBACU8EAAAAC/////8BAf////8B" +
           "AAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQFWBQAuAERWBQAAAQB0A/////8BAf////8AAAAAxGDACgEA" +
           "AAAFAAAAVmFsdmUBAAkAAABWYWx2ZVgwMDEBAVUEAwAAAAAFAAAAVmFsdmUALwEB8gNVBAAAAf////8B" +
           "AAAAFWCJCgIAAAABAAUAAABJbnB1dAEBVgQALwEAQAlWBAAAAAv/////AgL/////AQAAABVgiQoCAAAA" +
           "AAAHAAAARVVSYW5nZQEBWQQALgBEWQQAAAEAdAP/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the FTX001 Object.
        /// </summary>
        public FlowTransmitterState FlowTransmitter1
        {
            get
            { 
                return m_flowTransmitter1;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_flowTransmitter1, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_flowTransmitter1 = value;
            }
        }

        /// <summary>
        /// A description for the ValveX001 Object.
        /// </summary>
        public ValveState Valve
        {
            get
            { 
                return m_valve;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_valve, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_valve = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_flowTransmitter1 != null)
            {
                children.Add(m_flowTransmitter1);
            }

            if (m_valve != null)
            {
                children.Add(m_valve);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case CAS.UA.Server.Demo.BrowseNames.FlowTransmitter1:
                {
                    if (createOrReplace)
                    {
                        if (FlowTransmitter1 == null)
                        {
                            if (replacement == null)
                            {
                                FlowTransmitter1 = new FlowTransmitterState(this);
                            }
                            else
                            {
                                FlowTransmitter1 = (FlowTransmitterState)replacement;
                            }
                        }
                    }

                    instance = FlowTransmitter1;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.Valve:
                {
                    if (createOrReplace)
                    {
                        if (Valve == null)
                        {
                            if (replacement == null)
                            {
                                Valve = new ValveState(this);
                            }
                            else
                            {
                                Valve = (ValveState)replacement;
                            }
                        }
                    }

                    instance = Valve;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private FlowTransmitterState m_flowTransmitter1;
        private ValveState m_valve;
        #endregion
    }
    #endif
    #endregion

    #region BoilerDrumState Class
    #if (!OPCUA_EXCLUDE_BoilerDrumState)
    /// <summary>
    /// Stores an instance of the BoilerDrumType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerDrumState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public BoilerDrumState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.BoilerDrumType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////wRggAABAAAAAQAWAAAAQm9pbGVyRHJ1bVR5" +
           "cGVJbnN0YW5jZQEBXAQBAVwEAQAAAAAwAAEBXQQBAAAAhGDACgEAAAAOAAAATGV2ZWxJbmRpY2F0b3IB" +
           "AAYAAABMSVgwMDEBAV0EAC8BAQEEXQQAAAEBAAAAADABAQFcBAEAAAAVYIkKAgAAAAEABgAAAE91dHB1" +
           "dAEBXgQALwEAQAleBAAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBWwUALgBE" +
           "WwUAAAEAdAP/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the LIX001 Object.
        /// </summary>
        public LevelIndicatorState LevelIndicator
        {
            get
            { 
                return m_levelIndicator;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_levelIndicator, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_levelIndicator = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_levelIndicator != null)
            {
                children.Add(m_levelIndicator);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case CAS.UA.Server.Demo.BrowseNames.LevelIndicator:
                {
                    if (createOrReplace)
                    {
                        if (LevelIndicator == null)
                        {
                            if (replacement == null)
                            {
                                LevelIndicator = new LevelIndicatorState(this);
                            }
                            else
                            {
                                LevelIndicator = (LevelIndicatorState)replacement;
                            }
                        }
                    }

                    instance = LevelIndicator;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private LevelIndicatorState m_levelIndicator;
        #endregion
    }
    #endif
    #endregion

    #region BoilerOutputPipeState Class
    #if (!OPCUA_EXCLUDE_BoilerOutputPipeState)
    /// <summary>
    /// Stores an instance of the BoilerOutputPipeType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerOutputPipeState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public BoilerOutputPipeState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.BoilerOutputPipeType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////wRggAABAAAAAQAcAAAAQm9pbGVyT3V0cHV0" +
           "UGlwZVR5cGVJbnN0YW5jZQEBZAQBAWQEAQAAAAAwAAEBZQQBAAAAhGDACgEAAAAQAAAARmxvd1RyYW5z" +
           "bWl0dGVyMgEABgAAAEZUWDAwMgEBZQQALwEBCARlBAAAAQEAAAAAMAEBAWQEAQAAABVgiQoCAAAAAQAG" +
           "AAAAT3V0cHV0AQFmBAAvAQBACWYEAAAAC/////8BAf////8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdl" +
           "AQFgBQAuAERgBQAAAQB0A/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the FTX002 Object.
        /// </summary>
        public FlowTransmitterState FlowTransmitter2
        {
            get
            { 
                return m_flowTransmitter2;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_flowTransmitter2, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_flowTransmitter2 = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_flowTransmitter2 != null)
            {
                children.Add(m_flowTransmitter2);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case CAS.UA.Server.Demo.BrowseNames.FlowTransmitter2:
                {
                    if (createOrReplace)
                    {
                        if (FlowTransmitter2 == null)
                        {
                            if (replacement == null)
                            {
                                FlowTransmitter2 = new FlowTransmitterState(this);
                            }
                            else
                            {
                                FlowTransmitter2 = (FlowTransmitterState)replacement;
                            }
                        }
                    }

                    instance = FlowTransmitter2;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private FlowTransmitterState m_flowTransmitter2;
        #endregion
    }
    #endif
    #endregion

    #region BoilerState Class
    #if (!OPCUA_EXCLUDE_BoilerState)
    /// <summary>
    /// Stores an instance of the BoilerType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BoilerState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public BoilerState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(CAS.UA.Server.Demo.ObjectTypes.BoilerType, CAS.UA.Server.Demo.Namespaces.Sample, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AQAAABYAAABodHRwOi8vY2FzLmV1L1VBL0RlbW8v/////6RggAABAAAAAQASAAAAQm9pbGVyVHlwZUlu" +
           "c3RhbmNlAQFsBAMAAAAALQAAAEEgYm9pbGVyIHVzZWQgdG8gcHJvZHVjZSBzdGVhbSBmb3IgYSB0dXJi" +
           "aW5lLgEBbAQBBAAAAAAwAAEBbQQAMAABAXwEADAAAQGEBAAkAAEBmgQHAAAAxGDACgEAAAAJAAAASW5w" +
           "dXRQaXBlAQAIAAAAUGlwZVgwMDEBAW0EAwAAAAAJAAAASW5wdXRQaXBlAC8BAU0EbQQAAAEDAAAAADAB" +
           "AQFsBAAwAAEBbgQBAdkDAAEBfAQCAAAAxGDACgEAAAAQAAAARmxvd1RyYW5zbWl0dGVyMQEABgAAAEZU" +
           "WDAwMQEBbgQDAAAAABAAAABGbG93VHJhbnNtaXR0ZXIxAC8BAQgEbgQAAAEBAAAAADABAQFtBAEAAAAV" +
           "YIkKAgAAAAEABgAAAE91dHB1dAEBbwQALwEAQAlvBAAAAAv/////AQECAAAAAQHbAwABAY0EAQHbAwAB" +
           "AZYEAQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBZQUALgBEZQUAAAEAdAP/////AQH/////AAAAAMRg" +
           "wAoBAAAABQAAAFZhbHZlAQAJAAAAVmFsdmVYMDAxAQF1BAMAAAAABQAAAFZhbHZlAC8BAfIDdQQAAAH/" +
           "////AQAAABVgiQoCAAAAAQAFAAAASW5wdXQBAXYEAC8BAEAJdgQAAAAL/////wICAQAAAAEB2wMBAQGP" +
           "BAEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAXkEAC4ARHkEAAABAHQD/////wEB/////wAAAADEYMAK" +
           "AQAAAAQAAABEcnVtAQAIAAAARHJ1bVgwMDEBAXwEAwAAAAAEAAAARHJ1bQAvAQFcBHwEAAABBAAAAAAw" +
           "AQEBbAQBAdkDAQEBbQQAMAABAX0EAQHaAwABAYQEAQAAAIRgwAoBAAAADgAAAExldmVsSW5kaWNhdG9y" +
           "AQAGAAAATElYMDAxAQF9BAAvAQEBBH0EAAABAQAAAAAwAQEBfAQBAAAAFWCJCgIAAAABAAYAAABPdXRw" +
           "dXQBAX4EAC8BAEAJfgQAAAAL/////wEBAQAAAAEB2wMAAQGRBAEAAAAVYIkKAgAAAAAABwAAAEVVUmFu" +
           "Z2UBAWoFAC4ARGoFAAABAHQD/////wEB/////wAAAADEYMAKAQAAAAoAAABPdXRwdXRQaXBlAQAIAAAA" +
           "UGlwZVgwMDIBAYQEAwAAAAAKAAAAT3V0cHV0UGlwZQAvAQFkBIQEAAABAwAAAAAwAQEBbAQBAdoDAQEB" +
           "fAQAMAABAYUEAQAAAIRgwAoBAAAAEAAAAEZsb3dUcmFuc21pdHRlcjIBAAYAAABGVFgwMDIBAYUEAC8B" +
           "AQgEhQQAAAEBAAAAADABAQGEBAEAAAAVYIkKAgAAAAEABgAAAE91dHB1dAEBhgQALwEAQAmGBAAAAAv/" +
           "////AQEBAAAAAQHbAwABAZcEAQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBbwUALgBEbwUAAAEAdAP/" +
           "////AQH/////AAAAAERgwAoBAAAADgAAAEZsb3dDb250cm9sbGVyAQAGAAAARkNYMDAxAQGMBAMAAAAA" +
           "DgAAAEZsb3dDb250cm9sbGVyAC8BAf0DjAQAAP////8DAAAAFWCJCgIAAAABAAsAAABNZWFzdXJlbWVu" +
           "dAEBjQQALgBEjQQAAAAL/////wEBAQAAAAEB2wMBAQFvBAAAAAAVYIkKAgAAAAEACAAAAFNldFBvaW50" +
           "AQGOBAAuAESOBAAAAAv/////AwMBAAAAAQHbAwEBAZgEAAAAABVgiQoCAAAAAQAKAAAAQ29udHJvbE91" +
           "dAEBjwQALgBEjwQAAAAL/////wEBAQAAAAEB2wMAAQF2BAAAAABEYMAKAQAAAA8AAABMZXZlbENvbnRy" +
           "b2xsZXIBAAYAAABMQ1gwMDEBAZAEAwAAAAAPAAAATGV2ZWxDb250cm9sbGVyAC8BAfkDkAQAAP////8D" +
           "AAAAFWCJCgIAAAABAAsAAABNZWFzdXJlbWVudAEBkQQALgBEkQQAAAAL/////wEBAQAAAAEB2wMBAQF+" +
           "BAAAAAAVYIkKAgAAAAEACAAAAFNldFBvaW50AQGSBAAuAESSBAAAAAv/////AwP/////AAAAABVgiQoC" +
           "AAAAAQAKAAAAQ29udHJvbE91dAEBkwQALgBEkwQAAAAL/////wEBAQAAAAEB2wMAAQGVBAAAAABEYMAK" +
           "AQAAABAAAABDdXN0b21Db250cm9sbGVyAQAGAAAAQ0NYMDAxAQGUBAMAAAAAEAAAAEN1c3RvbUNvbnRy" +
           "b2xsZXIALwEBAQKUBAAA/////wUAAAAVYIkKAgAAAAEABgAAAElucHV0MQEBlQQALgBElQQAAAAL////" +
           "/wICAQAAAAEB2wMBAQGTBAAAAAAVYIkKAgAAAAEABgAAAElucHV0MgEBlgQALgBElgQAAAAL/////wIC" +
           "AQAAAAEB2wMBAQFvBAAAAAAVYIkKAgAAAAEABgAAAElucHV0MwEBlwQALgBElwQAAAAL/////wICAQAA" +
           "AAEB2wMBAQGGBAAAAAAVYIkKAgAAAAEACgAAAENvbnRyb2xPdXQBAZgEAC4ARJgEAAAAC/////8BAQEA" +
           "AAABAdsDAAEBjgQAAAAAFWDJCgIAAAAMAAAARGVzY3JpcHRpb25YAQALAAAARGVzY3JpcHRpb24BAZkE" +
           "AC4ARJkEAAAAFf////8BAf////8AAAAAhGCACgEAAAABAAoAAABTaW11bGF0aW9uAQGaBAAvAQEPBJoE" +
           "AAABAQAAAAAkAQEBbAQKAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBAZsEAC8BAMgKmwQAAAAV" +
           "/////wEB/////wIAAAAVYIkKAgAAAAAAAgAAAElkAQGcBAAuAEScBAAAABH/////AQH/////AAAAABVg" +
           "iQoCAAAAAAAGAAAATnVtYmVyAQGeBAAuAESeBAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAOAAAA" +
           "TGFzdFRyYW5zaXRpb24BAaAEAC8BAM8KoAQAAAAV/////wEB/////wMAAAAVYIkKAgAAAAAAAgAAAElk" +
           "AQGhBAAuAEShBAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAATnVtYmVyAQGjBAAuAESjBAAA" +
           "AAf/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAaQEAC4ARKQEAAABACYB" +
           "/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAERlbGV0YWJsZQEBpgQALgBEpgQAAAAB/////wEB////" +
           "/wAAAAAVYIkKAgAAAAAADAAAAFJlY3ljbGVDb3VudAEBqAQALgBEqAQAAAAG/////wEB/////wAAAAAk" +
           "YYIKBAAAAAAABQAAAFN0YXJ0AQHSBAMAAAAASwAAAENhdXNlcyB0aGUgUHJvZ3JhbSB0byB0cmFuc2l0" +
           "aW9uIGZyb20gdGhlIFJlYWR5IHN0YXRlIHRvIHRoZSBSdW5uaW5nIHN0YXRlLgAvAQB6CdIEAAABAQEA" +
           "AAAANQEBAZIFAAAAACRhggoEAAAAAAAHAAAAU3VzcGVuZAEB0wQDAAAAAE8AAABDYXVzZXMgdGhlIFBy" +
           "b2dyYW0gdG8gdHJhbnNpdGlvbiBmcm9tIHRoZSBSdW5uaW5nIHN0YXRlIHRvIHRoZSBTdXNwZW5kZWQg" +
           "c3RhdGUuAC8BAHsJ0wQAAAEBAQAAAAA1AQEBmAUAAAAAJGGCCgQAAAAAAAYAAABSZXN1bWUBAdQEAwAA" +
           "AABPAAAAQ2F1c2VzIHRoZSBQcm9ncmFtIHRvIHRyYW5zaXRpb24gZnJvbSB0aGUgU3VzcGVuZGVkIHN0" +
           "YXRlIHRvIHRoZSBSdW5uaW5nIHN0YXRlLgAvAQB8CdQEAAABAQEAAAAANQEBAZoFAAAAACRhggoEAAAA" +
           "AAAEAAAASGFsdAEB1QQDAAAAAGAAAABDYXVzZXMgdGhlIFByb2dyYW0gdG8gdHJhbnNpdGlvbiBmcm9t" +
           "IHRoZSBSZWFkeSwgUnVubmluZyBvciBTdXNwZW5kZWQgc3RhdGUgdG8gdGhlIEhhbHRlZCBzdGF0ZS4A" +
           "LwEAfQnVBAAAAQEDAAAAADUBAQGUBQA1AQEBnAUANQEBAaAFAAAAACRhggoEAAAAAAAFAAAAUmVzZXQB" +
           "AdYEAwAAAABKAAAAQ2F1c2VzIHRoZSBQcm9ncmFtIHRvIHRyYW5zaXRpb24gZnJvbSB0aGUgSGFsdGVk" +
           "IHN0YXRlIHRvIHRoZSBSZWFkeSBzdGF0ZS4ALwEAfgnWBAAAAQEBAAAAADUBAQGQBQAAAAA1YIkKAgAA" +
           "AAEACgAAAFVwZGF0ZVJhdGUBAdcEAwAAAAAmAAAAVGhlIHJhdGUgYXQgd2hpY2ggdGhlIHNpbXVsYXRp" +
           "b24gcnVucy4ALgBE1wQAAAAH/////wMD/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the PipeX001 Object.
        /// </summary>
        public BoilerInputPipeState InputPipe
        {
            get
            { 
                return m_inputPipe;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_inputPipe, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_inputPipe = value;
            }
        }

        /// <summary>
        /// A description for the DrumX001 Object.
        /// </summary>
        public BoilerDrumState Drum
        {
            get
            { 
                return m_drum;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_drum, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_drum = value;
            }
        }

        /// <summary>
        /// A description for the PipeX002 Object.
        /// </summary>
        public BoilerOutputPipeState OutputPipe
        {
            get
            { 
                return m_outputPipe;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_outputPipe, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_outputPipe = value;
            }
        }

        /// <summary>
        /// A description for the FCX001 Object.
        /// </summary>
        public FlowControllerState FlowController
        {
            get
            { 
                return m_flowController;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_flowController, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_flowController = value;
            }
        }

        /// <summary>
        /// A description for the LCX001 Object.
        /// </summary>
        public LevelControllerState LevelController
        {
            get
            { 
                return m_levelController;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_levelController, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_levelController = value;
            }
        }

        /// <summary>
        /// A description for the CCX001 Object.
        /// </summary>
        public CustomControllerState CustomController
        {
            get
            { 
                return m_customController;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_customController, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_customController = value;
            }
        }

        /// <summary>
        /// A description for the Simulation Object.
        /// </summary>
        public BoilerStateMachineState Simulation
        {
            get
            { 
                return m_simulation;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_simulation, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_simulation = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_inputPipe != null)
            {
                children.Add(m_inputPipe);
            }

            if (m_drum != null)
            {
                children.Add(m_drum);
            }

            if (m_outputPipe != null)
            {
                children.Add(m_outputPipe);
            }

            if (m_flowController != null)
            {
                children.Add(m_flowController);
            }

            if (m_levelController != null)
            {
                children.Add(m_levelController);
            }

            if (m_customController != null)
            {
                children.Add(m_customController);
            }

            if (m_simulation != null)
            {
                children.Add(m_simulation);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case CAS.UA.Server.Demo.BrowseNames.InputPipe:
                {
                    if (createOrReplace)
                    {
                        if (InputPipe == null)
                        {
                            if (replacement == null)
                            {
                                InputPipe = new BoilerInputPipeState(this);
                            }
                            else
                            {
                                InputPipe = (BoilerInputPipeState)replacement;
                            }
                        }
                    }

                    instance = InputPipe;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.Drum:
                {
                    if (createOrReplace)
                    {
                        if (Drum == null)
                        {
                            if (replacement == null)
                            {
                                Drum = new BoilerDrumState(this);
                            }
                            else
                            {
                                Drum = (BoilerDrumState)replacement;
                            }
                        }
                    }

                    instance = Drum;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.OutputPipe:
                {
                    if (createOrReplace)
                    {
                        if (OutputPipe == null)
                        {
                            if (replacement == null)
                            {
                                OutputPipe = new BoilerOutputPipeState(this);
                            }
                            else
                            {
                                OutputPipe = (BoilerOutputPipeState)replacement;
                            }
                        }
                    }

                    instance = OutputPipe;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.FlowController:
                {
                    if (createOrReplace)
                    {
                        if (FlowController == null)
                        {
                            if (replacement == null)
                            {
                                FlowController = new FlowControllerState(this);
                            }
                            else
                            {
                                FlowController = (FlowControllerState)replacement;
                            }
                        }
                    }

                    instance = FlowController;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.LevelController:
                {
                    if (createOrReplace)
                    {
                        if (LevelController == null)
                        {
                            if (replacement == null)
                            {
                                LevelController = new LevelControllerState(this);
                            }
                            else
                            {
                                LevelController = (LevelControllerState)replacement;
                            }
                        }
                    }

                    instance = LevelController;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.CustomController:
                {
                    if (createOrReplace)
                    {
                        if (CustomController == null)
                        {
                            if (replacement == null)
                            {
                                CustomController = new CustomControllerState(this);
                            }
                            else
                            {
                                CustomController = (CustomControllerState)replacement;
                            }
                        }
                    }

                    instance = CustomController;
                    break;
                }

                case CAS.UA.Server.Demo.BrowseNames.Simulation:
                {
                    if (createOrReplace)
                    {
                        if (Simulation == null)
                        {
                            if (replacement == null)
                            {
                                Simulation = new BoilerStateMachineState(this);
                            }
                            else
                            {
                                Simulation = (BoilerStateMachineState)replacement;
                            }
                        }
                    }

                    instance = Simulation;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BoilerInputPipeState m_inputPipe;
        private BoilerDrumState m_drum;
        private BoilerOutputPipeState m_outputPipe;
        private FlowControllerState m_flowController;
        private LevelControllerState m_levelController;
        private CustomControllerState m_customController;
        private BoilerStateMachineState m_simulation;
        #endregion
    }
    #endif
    #endregion
}