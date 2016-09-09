//<summary>
//  Title   : Set of helper function supporting conversion and ahndling of the OPC DA values and attributes
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
using Opc.Da;
using Opc.Ua;

namespace CAS.UA.Server.DataBindings
{
  /// <summary>
  /// Set of helper function supporting conversion and ahndling of the OPC DA values and attributes
  /// </summary>
  internal static class Helpers
  {
    /// <summary>
    /// Assigns the OPC value the instance of the <see cref="BaseVariableState"/>.
    /// </summary>
    /// <param name="value">The OPC DA value to be assigned.</param>
    /// <param name="node">The target node of the assign operation.</param>
    public static void AssignValue( ItemValue value, BaseVariableState node )
    {
      BuiltInType nt;
      try
      {
        bool isGood = StatusCode.IsGood( node.StatusCode );
        nt = TypeInfo.GetBuiltInType( node.DataType );
        node.Value = value.Value; //TODO Resolve the problem with Cast method 
        if ( value.TimestampSpecified )
          node.Timestamp = value.Timestamp;
        else
          node.Timestamp = DateTime.Now;
        if ( value.QualitySpecified )
          switch ( value.Quality.QualityBits )
          {
            case qualityBits.good:
              node.StatusCode = StatusCodes.Good;
              break;
            case qualityBits.goodLocalOverride:
              node.StatusCode = StatusCodes.GoodLocalOverride;
              break;
            case qualityBits.bad:
              node.StatusCode = StatusCodes.Bad;
              break;
            case qualityBits.badConfigurationError:
              node.StatusCode = StatusCodes.BadConfigurationError;
              break;
            case qualityBits.badNotConnected:
              node.StatusCode = StatusCodes.BadNotConnected;
              break;
            case qualityBits.badDeviceFailure:
              node.StatusCode = StatusCodes.BadDeviceFailure;
              break;
            case qualityBits.badSensorFailure:
              node.StatusCode = StatusCodes.BadSensorFailure;
              break;
            case qualityBits.badLastKnownValue:
              node.StatusCode = StatusCodes.UncertainLastUsableValue;
              break;
            case qualityBits.badCommFailure:
              node.StatusCode = StatusCodes.BadCommunicationError;
              break;
            case qualityBits.badOutOfService:
              node.StatusCode = StatusCodes.BadOutOfService;
              break;
            case qualityBits.badWaitingForInitialData:
              node.StatusCode = StatusCodes.BadWaitingForInitialData;
              break;
            case qualityBits.uncertain:
              node.StatusCode = StatusCodes.Uncertain;
              break;
            case qualityBits.uncertainLastUsableValue:
              node.StatusCode = StatusCodes.UncertainLastUsableValue;
              break;
            case qualityBits.uncertainSensorNotAccurate:
              node.StatusCode = StatusCodes.UncertainSensorNotAccurate;
              break;
            case qualityBits.uncertainEUExceeded:
              node.StatusCode = StatusCodes.UncertainEngineeringUnitsExceeded;
              break;
            case qualityBits.uncertainSubNormal:
              node.StatusCode = StatusCodes.UncertainSubNormal;
              break;
            default:
              node.StatusCode = StatusCodes.BadInvalidArgument;
              break;
          }
        else
          node.StatusCode = StatusCodes.Uncertain;
      }
      catch ( Exception Ex )
      {
        node.Value = null;
        node.StatusCode = StatusCodes.BadDataTypeIdUnknown;
        string msg = "There is a problem {0}while assigning value to {1}";
        TraceEvent.Tracer.TraceInformation( 105, typeof( Helpers ).Name, string.Format( msg, node.BrowseName, Ex.Message ) );
      }
      node.ClearChangeMasks( null, true );
    }
  }
}
