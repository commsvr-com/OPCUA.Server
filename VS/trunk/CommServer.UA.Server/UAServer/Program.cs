//<summary>
//  Title   : Program
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

using CAS.Lib.RTLib.Utils;
using CAS.UA.SDK.ServerConfigurationBase;
using CAS.UA.Server.Library;
using CAS.UA.Server.Properties;
using CAS.UA.Server.UserInterface;
using Opc.Ua;
using Opc.Ua.Client.Controls;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CAS.UA.Server
{
  static class Program
  {
    private readonly static string str_debug_install_argument = "debug_install";
    private readonly static string str_debug_uninstall_argument = "debug_uninstall";
    private readonly static string str_installic_argument = "installic";
    private class BaseDirectoryProvider: IBaseDirectoryProvider
    {
      private string myPathOfBaseDirectory;
      internal BaseDirectoryProvider( string pathOfBaseDirectory )
      {
        myPathOfBaseDirectory = pathOfBaseDirectory;
      }
      #region IBaseDirectoryProvider Members
      string IBaseDirectoryProvider.GetBaseDirectory()
      {
        return myPathOfBaseDirectory;
      }
      #endregion
    }
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

      string m_cmmdLine = Environment.CommandLine;
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );
      if ( m_cmmdLine.ToLower().Contains( str_debug_install_argument ) )
      {
        CASApplicationInstance.InstallServer( Assembly.GetExecutingAssembly().Location );
      }
      if ( m_cmmdLine.ToLower().Contains( str_debug_uninstall_argument ) )
      {
        CASApplicationInstance.UnInstallServer( Assembly.GetExecutingAssembly().Location );
      }
      CASApplicationInstance application = new CASApplicationInstance();
      CAS.UA.Server.ServerConfiguration.Main config = new CAS.UA.Server.ServerConfiguration.Main();

      try
      {
        if ( !Environment.UserInteractive )
        {
          Directory.SetCurrentDirectory( new FileInfo( Assembly.GetExecutingAssembly().Location ).DirectoryName );
          if ( application.ProcessCommandLine() )
            return;
          application.StartAsService( new UAServer() );
          return;
        }
      }
      catch ( Exception e )
      {
        Utils.Trace( e, "Unexpected error starting service." );
        return;
      }
#if DEBUG
      MessageBox.Show( "Attach debug point" );
#endif
      if ( m_cmmdLine.ToLower().Contains( str_installic_argument ) )
      {
        try
        {
          CAS.Lib.CodeProtect.LibInstaller.InstalLicense( true );
        }
        catch ( Exception ex )
        {
          MessageBox.Show( "License instalation has failed, reason: " + ex.Message );
        }
      }
      UAServer server = new UAServer();
      try
      {
        FileInfo configFI = RelativeFilePathsCalculator.GetAbsolutePathToFileInApplicationDataFolder( Settings.Default.ConfigurationFilePath );
        config.ReadConfiguration( configFI );
        if ( config.Configuration == null )
          throw new ArgumentNullException( "Cannot read configuration" );
        BaseDirectoryHelper.Instance.SetBaseDirectoryProvider( new BaseDirectoryProvider( configFI.DirectoryName ) );
        GuiUtils.CheckApplicationInstanceCertificate( config.Configuration, 1024, true, true );
        GuiUtils.OverrideUaTcpImplementation( config.Configuration );
        server.Start( config.Configuration );
        Application.Run( new ServerForm( server, config.Configuration, application ) );
      }
      catch ( Exception e )
      {
        GuiUtils.HandleException( "UA Server", null, e );
      }
      finally
      {
        server.Stop();
      }
    }
  }
}