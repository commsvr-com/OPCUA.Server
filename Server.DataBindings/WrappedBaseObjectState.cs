using System;
using System.Collections.Generic;
using System.Text;
using Opc.Ua;
using CAS.UA.Server.ServerConfiguration;

namespace CAS.UA.Server.DataBindings
{
  public class WrappedBaseObjectState: BaseObjectState
  {
    private WrappedBaseObjectState( NodeState parent )
      : base( parent )
    { }
    public static WrappedBaseObjectState Create
      ( ISystemContext context, BaseObjectState source, InstanceConfiguration dataSourceConfiguration )
    {
      WrappedBaseObjectState ret = new WrappedBaseObjectState( source.Parent );
      ret.Initialize( context, source );
      return ret;
    }
  }
}
