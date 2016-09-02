using System;
using System.Collections.Generic;
using System.Text;
using Opc.Ua;
using CAS.UA.Server.ServerConfiguration;

namespace CAS.UA.Server.DataBindings
{
  public class WrappedMethodState: MethodState
  {
    private WrappedMethodState( NodeState parent )
      : base( parent )
    { }
    internal static WrappedMethodState Create
      ( ISystemContext context, MethodState source, InstanceConfiguration dataSourceConfiguration )
    {
      WrappedMethodState ret = new WrappedMethodState( source.Parent );
      ret.Initialize( context, source );
      return ret;
    }
    protected override ServiceResult Call( ISystemContext context, IList<object> inputArguments, IList<object> outputArguments )
    {
      base.Call( context, inputArguments, outputArguments );
      return ServiceResult.Good;
    }
  }
}
