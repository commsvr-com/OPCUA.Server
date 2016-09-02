//<summary>
//  Title   : CAS application instance
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

using CAS.UA.Server.ServerConfiguration;
using Opc.Ua;

namespace CAS.UA.Server
{
  /// <summary>
  ///  A class that install, configures and runs a CAS UA application.
  /// </summary>
  class CASApplicationInstance : ApplicationInstance
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CASApplicationInstance"/> class.
    /// </summary>
    public CASApplicationInstance()
    {
      this.ApplicationType = ApplicationType.Server;
      this.ConfigSectionName = "CAS.UA.Server";
      this.ApplicationConfigurationType = typeof( CASConfiguration );

    }
    /// <summary>
    /// Installs the server.
    /// </summary>
    public static void InstallServer( string applicationAssemblyPath )
    {
      CASApplicationInstance application = new CASApplicationInstance();
      string[] args = new string[ 2 ];
      args[ 0 ] = "/silent";
      args[ 1 ] = "/install";
      application.ProcessCommandLine( true, applicationAssemblyPath, args );
    }

    /// <summary>
    /// Uninstalls the server.
    /// </summary>
    public static void UnInstallServer( string applicationAssemblyPath )
    {
      CASApplicationInstance application = new CASApplicationInstance();
      string[] args = new string[ 2 ];
      args[ 0 ] = "/silent";
      args[ 1 ] = "/uninstall";
      application.ProcessCommandLine( true, applicationAssemblyPath, args );
    }
  }
}
