//<summary>
//  Title   : TraceEvent in CAS.UA.Server
//  System  : Microsoft Visual C# .NET 
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20090715: mzbrzezny: created
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

namespace CAS.UA.Server.Library
{
  /// <summary>
  /// class responsible for tracing inside BaseStation - please use TraceSource( "CAS.UA.Server.TreaceEvent" )
  /// </summary>
  public class TraceEvent
  {
    private static CAS.Lib.RTLib.Processes.TraceEvent m_traceevent_internal =
      new CAS.Lib.RTLib.Processes.TraceEvent( typeof( TraceEvent ).ToString() );
    /// <summary>
    /// Gets the tracer.
    /// </summary>
    /// <value>The tracer.</value>
    public static CAS.Lib.RTLib.Processes.TraceEvent Tracer
    {
      get
      {
        return m_traceevent_internal;
      }
    }
  }
}
