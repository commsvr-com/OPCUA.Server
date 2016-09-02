//<summary>
//  Title   : Simulator Dictionary ia a collection of all simulated variables. If variale does not exist is created.
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
using System.Xml;
using CAS.Lib.DeviceSimulator;
using CAS.Lib.RTLib.Processes;
using Opc.Ua;


namespace CAS.UA.Server.DataBindings.Simulator
{
  /// <summary>
  /// Simulator Dictionary ia a collection of all simulated variables. If variale does not exist is created.
  /// </summary>
  internal sealed class SimulatorDictionary: SortedDictionary<string, I4UAServer>
  {
    #region cretor
    public SimulatorDictionary()
    {
      m_Me = this;
    }
    #endregion

    #region public
    internal static I4UAServer Find( bool buffor, BuiltInType type, string itemName, TimeSpan cycle )
    {
      if ( m_Me.ContainsKey( itemName ) )
        return m_Me[ itemName ];
      else
      {
        I4UAServer ds = m_Me.m_Simulator.CreateProcessDataSource( buffor, type, itemName, cycle );
        m_Me.Add( itemName, ds );
        return ds;
      }
    }
    #endregion

    #region private
    sealed internal class Simulator: HandlerWaitTimeList<SimulatorDictionary.Simulator.DataSource>
    {
      public Simulator()
        : base( true, "DataBindingsSimulator", true )
      { }
      internal I4UAServer CreateProcessDataSource( bool buffor, BuiltInType type, string name, TimeSpan cycle )
      {
        DataSource ret = new DataSource( buffor, type, name, this, cycle );
        ret.ResetCounter();
        return ret;
      }
      internal class DataSource: WaitTimeList<DataSource>.TODescriptor, I4UAServer
      {
        #region creator
        public DataSource( bool buffor, BuiltInType type, string name, Simulator queue, TimeSpan cycle )
          : base( queue, cycle )
        {
          m_name = name;
          m_CanonicalType = TypeInfo.GetSystemType( type, ValueRanks.OneDimension );
          m_LastValue = null;//TODO TypeInfo.GetDefaultValue( type ); 
          m_BuiltInType = type;
          if ( buffor )
            m_ValueGenerator = new CreateValue( GetFromBuffer );
          else
          {
            switch ( type )
            {
              case BuiltInType.Boolean:
                m_ValueGenerator = new CreateValue( CreateBoolean );
                break;
              case BuiltInType.Double:
                m_ValueGenerator = new CreateValue( CreateDouble );
                break;
              case BuiltInType.Int32:
                m_ValueGenerator = new CreateValue( CreateInt32 );
                break;
              case BuiltInType.Byte:
                m_ValueGenerator = new CreateValue( CreateByte );
                break;
              case BuiltInType.ByteString:
                m_ValueGenerator = new CreateValue( CreateByteString );
                break;//TODO it must be implemented
              //case BuiltInType.DataValue: 
              //  m_ValueGenerator = new CreateValue( CreateDataValue );
              //  break;
              case BuiltInType.DateTime:
                m_ValueGenerator = new CreateValue( CreateDateTime );
                break;//TODO it must be implemented
              //case BuiltInType.DiagnosticInfo:
              //  m_ValueGenerator = new CreateValue( CreateDiagnosticInfo );
              //  break;
              case BuiltInType.Enumeration:
                m_ValueGenerator = new CreateValue( CreateEnumeration );
                break;//TODO it must be implemented
              //case BuiltInType.ExpandedNodeId:
              //  m_ValueGenerator = new CreateValue( CreateExpandedNodeId );
              //  break;
              case BuiltInType.ExtensionObject:
                m_ValueGenerator = new CreateValue( CreateExtensionObject );
                break;
              case BuiltInType.Float:
                m_ValueGenerator = new CreateValue( CreateFloat );
                break;
              case BuiltInType.Guid:
                m_ValueGenerator = new CreateValue( CreateGuid );
                break;
              case BuiltInType.Int16:
                m_ValueGenerator = new CreateValue( CreateInt16 );
                break;
              case BuiltInType.Int64:
                m_ValueGenerator = new CreateValue( CreateInt64 );
                break;
              case BuiltInType.Integer:
                m_ValueGenerator = new CreateValue( CreateInteger );
                break;
              case BuiltInType.LocalizedText:
                m_ValueGenerator = new CreateValue( CreateLocalizedText );
                break;//TODO it must be implemented
              //case BuiltInType.NodeId:
              //  m_ValueGenerator = new CreateValue( CreateNodeId );
              //  break;
              case BuiltInType.Null:
                m_ValueGenerator = new CreateValue( CreateDouble );  //TODO Should be proper value
                break;
              case BuiltInType.Number:
                m_ValueGenerator = new CreateValue( CreateNumber );
                break;
              case BuiltInType.QualifiedName:
                m_ValueGenerator = new CreateValue( CreateQualifiedName );
                break;
              case BuiltInType.SByte:
                m_ValueGenerator = new CreateValue( CreateSByte );
                break;//TODO it must be implemented
              //case BuiltInType.StatusCode:
              //  m_ValueGenerator = new CreateValue( CreateStatusCode );
              //  break;
              case BuiltInType.String:
                m_ValueGenerator = new CreateValue( CreateString );
                break;
              case BuiltInType.UInt16:
                m_ValueGenerator = new CreateValue( CreateUInt16 );
                break;
              case BuiltInType.UInt32:
                m_ValueGenerator = new CreateValue( CreateUInt32 );
                break;
              case BuiltInType.UInt64:
                m_ValueGenerator = new CreateValue( CreateUInt64 );
                break;
              case BuiltInType.UInteger:
                m_ValueGenerator = new CreateValue( CreateUInteger );
                break;
              case BuiltInType.Variant:
                m_ValueGenerator = new CreateValue( CreateVariant );
                break;
              case BuiltInType.XmlElement:
                m_ValueGenerator = new CreateValue( CreateXmlElement );
                break;
              default:
                // switch off for unknown types;
                this.Cycle = TimeSpan.MaxValue;
                break;
            }
          }
        }
        #endregion

        #region public
        internal void DoSimulation()
        {
          m_RandomValue = m_Generator.NextDouble();
          if ( m_ValueGenerator == null )
            return;
          if ( OnValueChanged != null )
            OnValueChanged( this, new ItemValueArgs( m_ValueGenerator() ) );
        }
        #endregion

        #region private
        private enum TestEnumerator
        {
          testElement1,
          testElement2,
          testElement3
        }
        #region ValueResultCreators
        private delegate Opc.Da.ItemValueResult CreateValue();
        private Opc.Da.ItemValueResult CreateDouble()
        {
          return CreateItemValueResult( m_RandomValue );
        }
        private Opc.Da.ItemValueResult CreateInt32()
        {
          return CreateItemValueResult( Convert.ToInt32( Int32.MaxValue * m_RandomValue + Int32.MinValue ) );
        }
        private Opc.Da.ItemValueResult CreateByte()
        {
          return CreateItemValueResult( Convert.ToByte( Byte.MaxValue * m_RandomValue + Byte.MinValue ) );
        }
        private Opc.Da.ItemValueResult CreateByteString()
        {
          byte[] b = new byte[ 5 ];
          m_Generator.NextBytes( b );
          return CreateItemValueResult( b );
        }//TODO it must be implemented
        //private Opc.Da.ItemValueResult CreateDataValue()
        //{
        //  return CreateItemValueResult( Convert.ToString( 10000 * m_RandomValue ) );
        //}
        private Opc.Da.ItemValueResult CreateDateTime()
        {
          return CreateItemValueResult( DateTime.FromOADate( m_RandomValue ) );
        }//TODO it must be implemented
        //private Opc.Da.ItemValueResult CreateDiagnosticInfo()
        //{
        //  return CreateItemValueResult( Convert.ToString( "CAS_DiagnosticInfo_" + m_RandomValue ) );
        //}
        private Opc.Da.ItemValueResult CreateEnumeration()
        {
          Enum.Parse( typeof( TestEnumerator ), TestEnumerator.testElement1.ToString() );
          TestEnumerator en = (TestEnumerator)( 3 * m_RandomValue + 1 );
          return CreateItemValueResult( en );
        }//TODO it must be implemented
        //private Opc.Da.ItemValueResult CreateExpandedNodeId()
        //{
        //  return CreateItemValueResult( Convert.ToInt32( int.MaxValue * Math.Abs( m_RandomValue ) ) );
        //}
        private Opc.Da.ItemValueResult CreateFloat()
        {
          return CreateItemValueResult( float.MaxValue * m_RandomValue + float.MinValue );
        }
        private Opc.Da.ItemValueResult CreateGuid()
        {
          return CreateItemValueResult( Guid.NewGuid() );
        }
        private Opc.Da.ItemValueResult CreateInt16()
        {
          return CreateItemValueResult( Convert.ToInt16( Int16.MaxValue * m_RandomValue + Int16.MinValue ) );
        }
        private Opc.Da.ItemValueResult CreateInt64()
        {
          return CreateItemValueResult( Convert.ToInt64( Int64.MaxValue * m_RandomValue + Int64.MinValue ) );
        }
        private Opc.Da.ItemValueResult CreateInteger()
        {
          return CreateItemValueResult( Convert.ToInt32( Int32.MaxValue * m_RandomValue + Int32.MinValue ) );
        }
        private Opc.Da.ItemValueResult CreateLocalizedText()
        {
          return CreateItemValueResult( new LocalizedText( "CAS_LocalizedText_" + Convert.ToString( m_RandomValue ) ) );
        }//TODO it must be implemented
        //private Opc.Da.ItemValueResult CreateNodeId()
        //{
        //  return CreateItemValueResult( Convert.ToInt32( Int32.MaxValue * Math.Abs( m_RandomValue ) ) );
        //}
        private Opc.Da.ItemValueResult CreateExtensionObject()
        {
          return CreateItemValueResult( new Object() );
        }
        private Opc.Da.ItemValueResult CreateNumber()
        {
          return CreateItemValueResult( m_RandomValue );
        }
        private Opc.Da.ItemValueResult CreateSByte()
        {
          return CreateItemValueResult( Convert.ToSByte( SByte.MaxValue * m_RandomValue + SByte.MinValue ) );
        }//TODO it must be implemented
        //private Opc.Da.ItemValueResult CreateStatusCode()
        //{
        //  return CreateItemValueResult( Convert.ToString( "CAS_StatusCode_" + m_RandomValue ) );
        //}
        private Opc.Da.ItemValueResult CreateString()
        {
          return CreateItemValueResult( Convert.ToString( "CAS_String_" + m_RandomValue ) );
        }
        private Opc.Da.ItemValueResult CreateUInt32()
        {
          return CreateItemValueResult( Convert.ToUInt32( UInt32.MaxValue * m_RandomValue + UInt32.MinValue ) );
        }
        private Opc.Da.ItemValueResult CreateUInt16()
        {
          return CreateItemValueResult( Convert.ToUInt16( UInt16.MaxValue * m_RandomValue + UInt16.MinValue ) );
        }
        private Opc.Da.ItemValueResult CreateUInt64()
        {
          return CreateItemValueResult( Convert.ToUInt64( UInt64.MaxValue * m_RandomValue + UInt64.MinValue ) );
        }
        private Opc.Da.ItemValueResult CreateUInteger()
        {
          return CreateItemValueResult( Convert.ToUInt32( UInt32.MaxValue * m_RandomValue + UInt32.MinValue ) );
        }
        private Opc.Da.ItemValueResult CreateVariant()
        {
          return CreateItemValueResult( new Object() );
        }
        private Opc.Da.ItemValueResult CreateQualifiedName()
        {
          return CreateItemValueResult( new QualifiedName( "CAS_QualifiedName", Convert.ToUInt16( UInt16.MaxValue * m_RandomValue + UInt16.MinValue ) ) );
        }
        private Opc.Da.ItemValueResult CreateXmlElement()
        {
          XmlDocument xmldoc = new XmlDocument();
          XmlElement xe = xmldoc.CreateElement( "CAS", "Name_" + Convert.ToString( Convert.ToUInt16( UInt16.MaxValue * m_RandomValue + UInt16.MinValue ) ), "http:/cas.eu/UA" );
          return CreateItemValueResult( xe );
        }
        private Opc.Da.ItemValueResult CreateBoolean()
        {
          return CreateItemValueResult( m_RandomValue >= 0.5 );
        }
        private Opc.Da.ItemValueResult GetFromBuffer()
        {
          return CreateItemValueResult( m_LastValue );
        }
        private Opc.Da.ItemValueResult ConvertFromRandom()
        {
          return CreateItemValueResult( TypeInfo.Cast( m_RandomValue, m_BuiltInType ) );
        }
        #endregion

        private Opc.Da.ItemValueResult CreateItemValueResult( object val )
        {
          Opc.Da.ItemValueResult res = new Opc.Da.ItemValueResult()
          {
            ItemName = m_name,
            Quality = Opc.Da.Quality.Good,
            QualitySpecified = true,
            ResultID = Opc.ResultID.S_OK,
            Timestamp = DateTime.Now,
            TimestampSpecified = true,
            Value = val
          };
          return res;
        }
        private CreateValue m_ValueGenerator = null;
        private Random m_Generator = new Random();
        private double m_RandomValue = double.MinValue;
        private string m_name;
        private object m_ValueToWrite;
        private object m_LastValue;
        private Type m_CanonicalType;
        private BuiltInType m_BuiltInType;
        #endregion

        #region I4UAServer Members
        /// <summary>
        /// Occurs when on value of the process data changed.
        /// </summary>
        public event EventHandler<ItemValueArgs> OnValueChanged;
        /// <summary>
        /// Gets the canonical type of the item.
        /// </summary>
        /// <value>
        /// An instance of the <see cref="Type"/> representing the canonical type of the item.
        /// </value>
        public Type ItemCanonicalType
        {
          get { return null; }
        }
        /// <summary>
        /// Gets the last known value.
        /// </summary>
        /// <value>The last known value.</value>
        public Opc.Da.ItemValue LastKnownValue
        {
          get { return m_ValueGenerator(); }
        }
        /// <summary>
        /// Sets the value to write.
        /// </summary>
        /// <value>The value to write.</value>
        public object ValueToWrite
        {
          set { m_ValueToWrite = value; }
        }
        /// <summary>
        /// Submits outstanding write operation for the last values set by the <see cref="ValueToWrite"/> to the remote OPC Da server.
        /// </summary>
        /// <returns><c>true</c> if sucess.</returns>
        public bool Flush()
        {
          m_LastValue = m_ValueToWrite;
          return true;
        }
        #endregion
      }
      protected override void Handler( DataSource myDsc )
      {
        myDsc.DoSimulation();
      }
    }
    private static SimulatorDictionary m_Me;
    private Simulator m_Simulator = new Simulator();
    #endregion

  }
}
