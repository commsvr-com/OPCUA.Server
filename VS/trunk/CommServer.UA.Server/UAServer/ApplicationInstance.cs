using CAS.Lib.CodeProtect;
using CAS.UA.Server.ServerConfiguration;
using Opc.Ua;
using Opc.Ua.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace CAS.UA.Server
{
  /// <summary>
  /// A class that install, configures and runs a UA application.
  /// </summary>
  public class ApplicationInstance
  {
    #region Public Properties
    /// <summary>
    /// Gets or sets the name of the application.
    /// </summary>
    /// <value>The name of the application.</value>
    public string ApplicationName
    {
      get { return m_applicationName; }
      set { m_applicationName = value; }
    }

    /// <summary>
    /// Gets or sets the type of the application configuration.
    /// </summary>
    /// <value>The type of the application configuration.</value>
    public Type ApplicationConfigurationType { get; set; }

    /// <summary>
    /// Gets or sets the type of the application.
    /// </summary>
    /// <value>The type of the application.</value>
    public ApplicationType ApplicationType
    {
      get { return m_applicationType; }
      set { m_applicationType = value; }
    }

    /// <summary>
    /// Gets or sets the name of the config section containing the path to the application configuration file.
    /// </summary>
    /// <value>The name of the config section.</value>
    public string ConfigSectionName
    {
      get { return m_configSectionName; }
      set { m_configSectionName = value; }
    }

    /// <summary>
    /// Gets or sets the installation configuration.
    /// </summary>
    /// <value>The installation configuration.</value>
    public InstalledApplication InstallConfig
    {
      get { return m_installConfig; }
      set { m_installConfig = value; }
    }

    /// <summary>
    /// Gets the server.
    /// </summary>
    /// <value>The server.</value>
    public ServerBase Server
    {
      get { return m_server; }
    }

    /// <summary>
    /// Gets the application configuration used when the Start() method was called.
    /// </summary>
    /// <value>The application configuration.</value>
    public ApplicationConfiguration ApplicationConfiguration
    {
      get { return m_applicationConfiguration; }
    }
    #endregion

    #region InstallConfig Handling
    /// <summary>
    /// Loads the installation configuration from a file.
    /// </summary>
    public InstalledApplication LoadInstallConfigFromFile( string filePath )
    {
      if ( filePath == null )
        throw new ArgumentNullException( "filePath" );

      Stream istrm = null;

      try
      {
        istrm = File.Open( filePath, FileMode.Open, FileAccess.Read );
      }
      catch ( Exception e )
      {
        throw ServiceResultException.Create( StatusCodes.BadDecodingError, e, "Could not open file: {0}", filePath );
      }

      return LoadInstallConfigFromStream( istrm );
    }

    /// <summary>
    /// Loads the installation configuration from an embedded resource.
    /// </summary>
    public InstalledApplication LoadInstallConfigFromResource( string resourcePath, Assembly assembly )
    {
      if ( resourcePath == null )
        throw new ArgumentNullException( "resourcePath" );

      if ( assembly == null )
      {
        assembly = Assembly.GetCallingAssembly();
      }

      Stream istrm = assembly.GetManifestResourceStream( resourcePath );

      if ( istrm == null )
      {
        throw ServiceResultException.Create( StatusCodes.BadDecodingError, "Could not find resource file: {0}", resourcePath );
      }

      return LoadInstallConfigFromStream( istrm );
    }

    /// <summary>
    /// Loads the installation configuration from a stream.
    /// </summary>
    public InstalledApplication LoadInstallConfigFromStream( Stream istrm )
    {
      try
      {
        using ( XmlTextReader reader = new XmlTextReader( istrm ) )
        {
          DataContractSerializer serializer = new DataContractSerializer( typeof( InstalledApplication ) );
          return (InstalledApplication)serializer.ReadObject( reader, false );
        }
      }
      catch ( Exception e )
      {
        throw ServiceResultException.Create( StatusCodes.BadDecodingError, e, "Could not parse install configuration." );
      }
    }

    /// <summary>
    /// Loads the installation configuration into the <c>InstalledApplication</c> property.
    /// </summary>
    /// <param name="configFile">The config file (may be null).</param>
    /// <param name="applicationAssemblyPath">The application assembly path.</param>
    public virtual void LoadInstallConfig( string configFile, string applicationAssemblyPath )
    {
      // load configuration from command line.
      if ( !String.IsNullOrEmpty( configFile ) )
      {
        InstallConfig = LoadInstallConfigFromFile( configFile );
        return;
      }

      // load it from a resource if not already loaded.
      if ( InstallConfig == null )
      {
        foreach ( string resourcePath in Assembly.GetExecutingAssembly().GetManifestResourceNames() )
        {
          if ( resourcePath.EndsWith( "InstallConfig.xml" ) )
          {
            InstallConfig = LoadInstallConfigFromResource( resourcePath, Assembly.GetEntryAssembly() );
            break;
          }
        }
      }

      // override the application name.
      if ( String.IsNullOrEmpty( InstallConfig.Name ) )
      {
        InstallConfig.Name = ApplicationName;
      }
      else
      {
        ApplicationName = InstallConfig.Name;
      }

      // update fixed fields in the installation config.
      InstallConfig.ApplicationType = ApplicationType;
      InstallConfig.ExecutableFile = applicationAssemblyPath;

      if ( InstallConfig.TraceConfiguration != null )
      {
        string logFile = PrepareLogFileName( InstallConfig.TraceConfiguration.OutputFilePath );
        InstallConfig.TraceConfiguration.OutputFilePath = logFile;
        InstallConfig.TraceConfiguration.ApplySettings();
      }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Processes the command line.
    /// </summary>
    /// <returns>
    /// True if the arguments were processed; False otherwise.
    /// </returns>
    public bool ProcessCommandLine()
    {
      return ProcessCommandLine( false );
    }

    /// <summary>
    /// Processes the command line.
    /// </summary>
    /// <param name="ignoreUnknownArguments">if set to <c>true</c> unknown arguments are ignored.</param>
    /// <returns>
    /// True if the arguments were processed; False otherwise.
    /// </returns>
    public bool ProcessCommandLine( bool ignoreUnknownArguments )
    {
      TraceConfiguration config = new TraceConfiguration();
      config.OutputFilePath = LogOutputFilePath;
      config.DeleteOnLoad = false;
      config.TraceMasks = 1023;
      config.ApplySettings();

      string[] args = Environment.GetCommandLineArgs();

      if ( args.Length <= 1 )
      {
        return false;
      }

      return ProcessCommandLine( ignoreUnknownArguments, null, args );
    }

    /// <summary>
    /// Processes the command line.
    /// </summary>
    /// <returns>True if the arguments were processed; False otherwise.</returns>
    public bool ProcessCommandLine( bool ignoreUnknownArguments, string applicationAssemblyPath, params string[] args )
    {
      if ( args.Length <= 1 )
      {
        return false;
      }

      // arguments can be standalone or name-value pairs seperated by a ':'.
      Dictionary<string, string> argTable = new Dictionary<string, string>();

      for ( int ii = 0; ii < args.Length; ii++ )
      {
        string arg = args[ ii ];

        if ( String.IsNullOrEmpty( arg ) )
        {
          continue;
        }

        int index = args[ ii ].IndexOf( ':' );

        if ( index != -1 && index > 0 && index < arg.Length - 1 )
        {
          argTable[ arg.Substring( 0, index ).ToLower() ] = arg.Substring( index + 1 );
        }
        else
        {
          argTable[ arg.ToLower() ] = String.Empty;
        }
      }

      // validate arguments.
      string error = ValidateArguments( ignoreUnknownArguments, argTable );

      if ( !String.IsNullOrEmpty( error ) )
      {
        throw ServiceResultException.Create( StatusCodes.BadInvalidArgument, error );
      }

      // check for the silent switch.
      bool silent = !Environment.UserInteractive;

      if ( argTable.ContainsKey( "/silent" ) )
      {
        silent = true;
      }

      string configFile = null;

      try
      {
        // get configuration file from command line.
        if ( argTable.TryGetValue( "/configFile", out configFile ) )
        {
          configFile = Utils.GetAbsoluteFilePath( configFile, true, true, false );
        }

        // load the configuration.
        LoadInstallConfig( configFile, applicationAssemblyPath );
      }
      catch ( Exception e )
      {
        StringBuilder buffer = new StringBuilder();
        buffer.Append( "Could not load the install configuration. " );
        buffer.Append( configFile );

        if ( !silent )
        {
          throw ServiceResultException.Create( StatusCodes.BadInvalidArgument, e, buffer.ToString() );
        }

        Utils.Trace( e, buffer.ToString() );
        return true;
      }

      try
      {
        // install the application.
        if ( argTable.ContainsKey( "/install" ) )
        {
          Install( silent, argTable );
          return true;
        }

        // uninstall the application.
        if ( argTable.ContainsKey( "/uninstall" ) )
        {
          Uninstall( silent, argTable, ApplicationConfigurationType );
          return true;
        }

        // handle any argument defined by the subclass.
        return ProcessCommand( silent, argTable );
      }
      catch ( Exception e )
      {
        StringBuilder buffer = new StringBuilder();
        buffer.Append( "Could not process the command line arguments provided. " );

        if ( args != null )
        {
          for ( int ii = 1; ii < args.Length; ii++ )
          {
            buffer.AppendFormat( "{0} ", args[ ii ] );
          }
        }

        if ( !silent )
        {
          throw ServiceResultException.Create( StatusCodes.BadInvalidArgument, e, buffer.ToString() );
        }

        Utils.Trace( e, buffer.ToString() );
        return true;
      }
    }

    /// <summary>
    /// Starts the UA server as a Windows Service.
    /// </summary>
    /// <param name="server">The server.</param>
    public void StartAsService( ServerBase server )
    {
      m_server = server;
      ServiceBase.Run( new WindowsService( server, ConfigSectionName, ApplicationType, ApplicationConfigurationType ) );
    }

    /// <summary>
    /// Starts the UA server.
    /// </summary>
    /// <param name="server">The server.</param>
    public void Start( ServerBase server )
    {
      m_server = server;

      if ( m_applicationConfiguration == null )
      {
        LoadApplicationConfiguration( false );
      }

      server.Start( m_applicationConfiguration );
    }

    /// <summary>
    /// Stops the UA server.
    /// </summary>
    public void Stop()
    {
      m_server.Stop();
    }
    #endregion

    #region WindowsService Class
    /// <summary>
    /// Manages the interface between the UA server and the Windows SCM.
    /// </summary>
    protected class WindowsService: ServiceBase
    {
      #region Constructors
      /// <summary>
      /// Initializes a new instance of the <see cref="WindowsService"/> class.
      /// </summary>
      /// <param name="server">The server.</param>
      /// <param name="configSectionName">Name of the config section.</param>
      /// <param name="applicationType">Type of the application.</param>
      /// <param name="applicationConfigurationType">Type of the application configuration.</param>
      public WindowsService( ServerBase server, string configSectionName, ApplicationType applicationType, Type applicationConfigurationType )
      {
        m_server = server;
        m_configSectionName = configSectionName;
        m_applicationType = applicationType;
        m_applicationConfigurationType = applicationConfigurationType;
        EventLog.Source = "UA Application";
      }
      #endregion

      #region Overridden Methods
      /// <summary>
      /// Starts the server in a background thread.
      /// </summary>
      protected override void OnStart( string[] args )
      {
        Thread thread = new Thread( OnBackgroundStart );
        thread.Start( null );
      }

      /// <summary>
      /// Stops the server so the service can shutdown.
      /// </summary>
      protected override void OnStop()
      {
        m_server.Stop();
      }
      #endregion

      #region Private Methods
      /// <summary>
      /// Runs the service in a background thread.
      /// </summary>
      private void OnBackgroundStart( object state )
      {
        try
        {
          string filePath = ApplicationConfiguration.GetFilePathFromAppConfig( m_configSectionName );
          ApplicationConfiguration configuration = ApplicationInstance.LoadAppConfig( false, filePath, m_applicationType, true, m_applicationConfigurationType );
          m_server.Start( configuration );
        }
        catch ( Exception e )
        {
          ServiceResult error = ServiceResult.Create( e, StatusCodes.BadConfigurationError, "Could not start UA Sample Service." );
          this.EventLog.WriteEntry( error.ToLongString(), EventLogEntryType.Error );
        }
      }
      #endregion

      #region Private Fields
      private ServerBase m_server;
      private string m_configSectionName;
      private ApplicationType m_applicationType;
      private Type m_applicationConfigurationType;
      #endregion
    }
    #endregion

    #region ArgumentDescription Class
    /// <summary>
    /// Stores the description of an argument.
    /// </summary>
    protected class ArgumentDescription
    {
      /// <summary>
      /// The argument name.
      /// </summary>
      public string Name;

      /// <summary>
      /// The argument description.
      /// </summary>
      public string Description;

      /// <summary>
      /// Whether the argument requires a value.
      /// </summary>
      public bool ValueRequired;

      /// <summary>
      /// Whether the argument allows a value.
      /// </summary>
      public bool ValueAllowed;

      /// <summary>
      /// Initializes a new instance of the <see cref="ArgumentDescription"/> class.
      /// </summary>
      /// <param name="name">The name.</param>
      /// <param name="valueRequired">if set to <c>true</c> a value is required.</param>
      /// <param name="valueAllowed">if set to <c>true</c> a value is allowed.</param>
      /// <param name="description">The description.</param>
      public ArgumentDescription(
           string name,
           bool valueRequired,
           bool valueAllowed,
           string description )
      {
        Name = name;
        ValueRequired = valueRequired;
        ValueAllowed = valueAllowed;
        Description = description;
      }
    }

    private static ArgumentDescription[] s_SupportedArguments = new ArgumentDescription[]
        {
            new ArgumentDescription("/install", false, false, "Installs the application (/install [/silent] [/configFile:<filepath>])."),
            new ArgumentDescription("/uninstall", false, false, "Uninstalls the application (/uninstall [/silent] [/configFile:<filepath>])."),
            new ArgumentDescription("/silent", false, false, "Performs operations without prompting user to confirm or displaying errors."),
            new ArgumentDescription("/configFile", true, true, "Specifies the installation configuration file."),
        };
    #endregion

    #region Protected Methods
    /// <summary>
    /// Gets the descriptions for the supported arguments.
    /// </summary>
    protected virtual ArgumentDescription[] GetArgumentDescriptions()
    {
      return s_SupportedArguments;
    }

    /// <summary>
    /// Gets the help string.
    /// </summary>
    protected virtual string GetHelpString( ArgumentDescription[] commands )
    {
      StringBuilder text = new StringBuilder();
      text.Append( "These are the supported arguments:\r\n" );

      for ( int ii = 0; ii < commands.Length; ii++ )
      {
        ArgumentDescription command = commands[ ii ];

        text.Append( "\r\n" );

        if ( command.ValueRequired )
        {
          text.AppendFormat( "{0}:<value> {1}", command.Name, command.Description );
        }
        else if ( command.ValueAllowed )
        {
          text.AppendFormat( "{0}[:<value>] {1}", command.Name, command.Description );
        }
        else
        {
          text.AppendFormat( "{0} {1}", command.Name, command.Description );
        }
      }

      text.Append( "\r\n" );
      return text.ToString();
    }

    /// <summary>
    /// Validates the arguments.
    /// </summary>
    protected virtual string ValidateArguments( bool ignoreUnknownArguments, Dictionary<string, string> args )
    {
      ArgumentDescription[] commands = GetArgumentDescriptions();

      // check if help was requested.
      if ( args.ContainsKey( "/?" ) )
      {
        return GetHelpString( commands );
      }

      // validate the arguments.
      StringBuilder error = new StringBuilder();

      foreach ( KeyValuePair<string, string> arg in args )
      {
        ArgumentDescription command = null;

        for ( int ii = 0; ii < commands.Length; ii++ )
        {
          if ( String.Compare( commands[ ii ].Name, arg.Key, StringComparison.OrdinalIgnoreCase ) == 0 )
          {
            command = commands[ ii ];
            break;
          }
        }

        if ( command == null )
        {
          if ( !ignoreUnknownArguments )
          {
            if ( error.Length > 0 )
            {
              error.Append( "\r\n" );
            }

            error.AppendFormat( "Unrecognized argument: {0}", arg.Key );
          }

          continue;
        }

        if ( command.ValueRequired && String.IsNullOrEmpty( arg.Value ) )
        {
          if ( error.Length > 0 )
          {
            error.Append( "\r\n" );
          }

          error.AppendFormat( "{0} requires a value to be specified (syntax {0}:<value>).", arg.Key );
          continue;
        }

        if ( !command.ValueAllowed && !String.IsNullOrEmpty( arg.Value ) )
        {
          if ( error.Length > 0 )
          {
            error.Append( "\r\n" );
          }

          error.AppendFormat( "{0} does not allow a value to be specified.", arg.Key );
          continue;
        }
      }

      // return any error text.
      return error.ToString();
    }

    /// <summary>
    /// Updates the application configuration with the values from the installation configuration.
    /// </summary>
    /// <param name="configuration">The configuration to update.</param>
    protected virtual void UpdateAppConfigWithInstallConfig( ApplicationConfiguration configuration )
    {
      // override the application name.
      if ( InstallConfig.Name != null )
      {
        if ( configuration.SecurityConfiguration != null && configuration.SecurityConfiguration.ApplicationCertificate != null )
        {
          if ( configuration.SecurityConfiguration.ApplicationCertificate.SubjectName == null )
          {
            configuration.SecurityConfiguration.ApplicationCertificate.SubjectName = InstallConfig.Name;
          }
        }

        configuration.ApplicationName = InstallConfig.Name;
      }

      if ( InstallConfig.Uri != null )
      {
        configuration.ApplicationUri = InstallConfig.Uri;
      }

      // replace localhost with the current machine name.
      if ( configuration.ApplicationUri != null )
      {
        int index = configuration.ApplicationUri.IndexOf( "localhost", StringComparison.OrdinalIgnoreCase );

        if ( index != -1 )
        {
          StringBuilder buffer = new StringBuilder();
          buffer.Append( configuration.ApplicationUri.Substring( 0, index ) );
          buffer.Append( System.Net.Dns.GetHostName() );
          buffer.Append( configuration.ApplicationUri.Substring( index + "localhost".Length ) );
          configuration.ApplicationUri = buffer.ToString();
        }
      }

      if ( InstallConfig.BaseAddresses != null )
      {
        if ( configuration.ServerConfiguration != null )
        {
          configuration.ServerConfiguration.BaseAddresses = InstallConfig.BaseAddresses;
        }

        if ( configuration.DiscoveryServerConfiguration != null )
        {
          configuration.DiscoveryServerConfiguration.BaseAddresses = InstallConfig.BaseAddresses;
        }
      }

      if ( InstallConfig.AlternateBaseAddresses != null )
      {
        if ( configuration.ServerConfiguration != null )
        {
          configuration.ServerConfiguration.AlternateBaseAddresses = InstallConfig.BaseAddresses;
        }

        if ( configuration.DiscoveryServerConfiguration != null )
        {
          configuration.DiscoveryServerConfiguration.AlternateBaseAddresses = InstallConfig.BaseAddresses;
        }
      }

      if ( InstallConfig.ApplicationCertificate != null )
      {
        configuration.SecurityConfiguration.ApplicationCertificate = InstallConfig.ApplicationCertificate;
      }

      if ( InstallConfig.DiscoveryEndpoints != null )
      {
        if ( configuration.ClientConfiguration != null )
        {
          configuration.ClientConfiguration.DiscoveryServers = InstallConfig.DiscoveryEndpoints;
        }
      }

      if ( InstallConfig.RegistrationEndpoint != null )
      {
        if ( configuration.ServerConfiguration != null )
        {
          configuration.ServerConfiguration.RegistrationEndpoint = InstallConfig.RegistrationEndpoint;
        }
      }

      if ( InstallConfig.RejectedCertificatesStore != null )
      {
        configuration.SecurityConfiguration.RejectedCertificateStore = InstallConfig.RejectedCertificatesStore;
      }

      if ( InstallConfig.TrustedIssuerStore != null )
      {
        configuration.SecurityConfiguration.TrustedIssuerCertificates.StoreType = InstallConfig.TrustedIssuerStore.StoreType;
        configuration.SecurityConfiguration.TrustedIssuerCertificates.StorePath = InstallConfig.TrustedIssuerStore.StorePath;
        configuration.SecurityConfiguration.TrustedIssuerCertificates.ValidationOptions = InstallConfig.TrustedPeerStore.ValidationOptions;
      }

      if ( InstallConfig.TrustedIssuerCertificates != null )
      {
        configuration.SecurityConfiguration.TrustedIssuerCertificates.TrustedCertificates = InstallConfig.TrustedIssuerCertificates;
      }

      if ( InstallConfig.TrustedPeerStore != null )
      {
        configuration.SecurityConfiguration.TrustedPeerCertificates.StoreType = InstallConfig.TrustedPeerStore.StoreType;
        configuration.SecurityConfiguration.TrustedPeerCertificates.StorePath = InstallConfig.TrustedPeerStore.StorePath;
        configuration.SecurityConfiguration.TrustedPeerCertificates.ValidationOptions = InstallConfig.TrustedPeerStore.ValidationOptions;
      }

      if ( InstallConfig.TrustedPeerCertificates != null )
      {
        configuration.SecurityConfiguration.TrustedPeerCertificates.TrustedCertificates = InstallConfig.TrustedPeerCertificates;
      }
    }

    /// <summary>
    /// Prepares the name of the log file.
    /// </summary>
    /// <param name="logFileName">Name of the log file.</param>
    /// <returns></returns>
    private string PrepareLogFileName( string logFileName )
    {
      string specialFormatToken = "|{0}|";
      if ( logFileName.Contains( "|ApplicationDataPath|" ) )
      {
        logFileName = logFileName.Replace( string.Format( specialFormatToken, "ApplicationDataPath" ), InstallContextNames.ApplicationDataPath );
        return logFileName;
      }
      else
      {
        foreach ( Environment.SpecialFolder folder in Enum.GetValues( typeof( Environment.SpecialFolder ) ) )
        {
          if ( !logFileName.Contains( "|" ) )
            break;
          logFileName = logFileName.Replace( string.Format( specialFormatToken, folder.ToString() ), Environment.GetFolderPath( folder ) );
        }
        foreach ( DictionaryEntry variable in Environment.GetEnvironmentVariables() )
        {
          if ( !logFileName.Contains( "%" ) )
            break;
          logFileName = Regex.Replace( logFileName, string.Format( "\\%{0}\\%", (string)variable.Key ), (string)variable.Value, RegexOptions.IgnoreCase );
        }
        return logFileName;
      }
    }


    /// <summary>
    /// Installs the service.
    /// </summary>
    /// <param name="silent">if set to <c>true</c> no dialogs such be displayed.</param>
    /// <param name="args">Additional arguments provided on the command line.</param>
    protected virtual void Install( bool silent, Dictionary<string, string> args )
    {
      CAS.UA.Server.ServerConfiguration.Main config = new CAS.UA.Server.ServerConfiguration.Main();
      Directory.SetCurrentDirectory( new FileInfo( Assembly.GetExecutingAssembly().Location ).DirectoryName );

      Utils.Trace( Utils.TraceMasks.Information, "Installing application." );

      // check the configuration.
      string filePath = PrepareLogFileName( InstallConfig.ConfigurationFile );

      if ( filePath == null )
      {
        Utils.Trace( "WARNING: Could not load config file specified in the installation configuration: {0}", InstallConfig.ConfigurationFile );
        filePath = ApplicationConfiguration.GetFilePathFromAppConfig( ConfigSectionName );
        InstallConfig.ConfigurationFile = filePath;
      }

      ApplicationConfiguration configuration = LoadAppConfig( silent, filePath, InstallConfig.ApplicationType, false, ApplicationConfigurationType );

      if ( configuration == null )
      {
        return;
      }

      // update the configuration.
      UpdateAppConfigWithInstallConfig( configuration );

      // update configuration with information form the install config.
      // check the certificate.
      X509Certificate2 certificate = configuration.SecurityConfiguration.ApplicationCertificate.Find( true );

      if ( certificate != null )
      {
        if ( !silent )
        {
          if ( CheckApplicationInstanceCertificate( configuration, certificate, silent, InstallConfig.MinimumKeySize ) )
          {
            certificate = null;
          }
        }
      }

      // create a new certificate.
      if ( certificate == null )
      {
        certificate = CreateApplicationInstanceCertificate( configuration, InstallConfig.MinimumKeySize, InstallConfig.LifeTimeInMonths );
      }

      // ensure the certificate is trusted.
      AddToTrustedPeerStore( configuration, certificate );

      // add to discovery server.
      if ( configuration.ApplicationType == ApplicationType.Server || configuration.ApplicationType == ApplicationType.ClientAndServer )
      {
        AddToDiscoveryServerTrustList( configuration, certificate );
      }

      // configure the firewall.
      if ( InstallConfig.ConfigureFirewall )
      {
        ConfigureFirewall( configuration, silent, false );
      }

      // configure HTTP access.
      ConfigureHttpAccess( configuration, false );

      // configure access to the executable, the configuration file and the private key. 
      ConfigureFileAccess( configuration );

      // update configuration file.
      ConfigUtils.UpdateConfigurationLocation( InstallConfig.ExecutableFile, InstallConfig.ConfigurationFile );

      try
      {
        configuration.SaveToFile( configuration.SourceFilePath );
      }
      catch ( Exception e )
      {
        Utils.Trace( e, "Could not save configuration file. FilePath={0}", configuration.SourceFilePath );
      }

      // install the service.
      if ( InstallConfig.InstallAsService )
      {
        Utils.Trace( Utils.TraceMasks.Information, "Installing service '{0}'.", InstallConfig.Name );

        bool start = true;

        bool result = Opc.Ua.Configuration.ServiceInstaller.InstallService(
            InstallConfig.ExecutableFile,
            InstallConfig.Name,
            configuration.ApplicationName,
            InstallConfig.ServiceDescription,
            InstallConfig.ServiceStartMode,
            InstallConfig.ServiceUserName,
            InstallConfig.ServicePassword,
            ref start );

        if ( !result )
        {
          throw ServiceResultException.Create( StatusCodes.BadConfigurationError, "Could not install service." );
        }
      }
    }

    /// <summary>
    /// Uninstalls the service.
    /// </summary>
    /// <param name="silent">if set to <c>true</c> no dialogs such be displayed.</param>
    /// <param name="args">Additional arguments provided on the command line.</param>
    /// <param name="applicationConfigurationType">Type of the application configuration.</param>
    protected virtual void Uninstall( bool silent, Dictionary<string, string> args, Type applicationConfigurationType )
    {
      CAS.UA.Server.ServerConfiguration.Main config = new CAS.UA.Server.ServerConfiguration.Main();
      Directory.SetCurrentDirectory( new FileInfo( Assembly.GetExecutingAssembly().Location ).DirectoryName );
      // check the configuration.
      string filePath = PrepareLogFileName( InstallConfig.ConfigurationFile );
      if ( filePath == null )
      {
        Utils.Trace( "WARNING: Could not load config file specified in the installation configuration: {0}", InstallConfig.ConfigurationFile );
        filePath = ApplicationConfiguration.GetFilePathFromAppConfig( ConfigSectionName );
        InstallConfig.ConfigurationFile = filePath;
      }

      ApplicationConfiguration configuration = LoadAppConfig( silent, filePath, InstallConfig.ApplicationType, false, applicationConfigurationType );

      if ( configuration != null )
      {
        // configure the firewall.
        ConfigureFirewall( configuration, false, true );

        // configure HTTP access.
        ConfigureHttpAccess( configuration, true );

        // delete certificate.
        if ( InstallConfig.DeleteCertificatesOnUninstall )
        {
          DeleteApplicationInstanceCertificate( configuration );
        }
      }

      if ( InstallConfig.InstallAsService )
      {
        if ( !Opc.Ua.Configuration.ServiceInstaller.UnInstallService( InstallConfig.Name ) )
        {
          Utils.Trace( "Service could not be uninstalled." );
        }
      }
    }

    /// <summary>
    /// Processes the command.
    /// </summary>
    /// <param name="silent">if set to <c>true</c> no dialogs such be displayed.</param>
    /// <param name="args">Additional arguments provided on the command line.</param>
    /// <returns>True if the command was processed.</returns>
    protected virtual bool ProcessCommand( bool silent, Dictionary<string, string> args )
    {
      return false;
    }

    /// <summary>
    /// Gets the log output file path.
    /// </summary>
    /// <value>The log output file path.</value>
    protected virtual string LogOutputFilePath
    {
      get { return "%CommonApplicationData%\\OPC Foundation\\Logs\\Default.InstallLog.txt"; }
    }
    #endregion

    #region Static Methods
    /// <summary>
    /// Loads the configuration.
    /// </summary>
    public static ApplicationConfiguration LoadAppConfig(
        bool silent,
        string filePath,
        ApplicationType applicationType,
        bool applyTraceSettings,
        Type applicationConfigurationType )
    {
      Utils.Trace( Utils.TraceMasks.Information, "Loading application configuration file. {0}", filePath );

      try
      {
        // load the configuration file.
        CASConfiguration configuration = CASConfiguration.Load(
            new System.IO.FileInfo( filePath ),
            applicationType,
            applicationConfigurationType,
            applyTraceSettings );

        if ( configuration == null )
        {
          return null;
        }

        return configuration;
      }
      catch ( Exception e )
      {
        // warn user.
        if ( !silent )
        {
          ExceptionDlg.Show( "Load Application Configuration", e );
        }

        Utils.Trace( e, "Could not load configuration file. {0}", filePath );
        return null;
      }
    }

    /// <summary>
    /// Loads the application configuration.
    /// </summary>
    public ApplicationConfiguration LoadApplicationConfiguration( bool silent )
    {
      string filePath = ApplicationConfiguration.GetFilePathFromAppConfig( ConfigSectionName );
      ApplicationConfiguration configuration = LoadAppConfig( silent, filePath, ApplicationType, true, ApplicationConfigurationType );

      if ( configuration == null )
      {
        throw ServiceResultException.Create( StatusCodes.BadConfigurationError, "Could not load configuration file." );
      }

      m_applicationConfiguration = configuration;
      return configuration;
    }

    /// <summary>
    /// Checks for a valid application instance certificate.
    /// </summary>
    /// <param name="silent">if set to <c>true</c> no dialogs will be displayed.</param>
    /// <param name="minimumKeySize">Minimum size of the key.</param>
    public void CheckApplicationInstanceCertificate(
        bool silent,
        ushort minimumKeySize )
    {
      Utils.Trace( Utils.TraceMasks.Information, "Checking application instance certificate." );

      ApplicationConfiguration configuration = null;

      if ( m_applicationConfiguration == null )
      {
        LoadApplicationConfiguration( silent );
      }

      configuration = m_applicationConfiguration;
      bool createNewCertificate = true;

      // find the existing certificate.
      CertificateIdentifier id = configuration.SecurityConfiguration.ApplicationCertificate;

      if ( id == null )
      {
        throw ServiceResultException.Create( StatusCodes.BadConfigurationError, "Configuration file does not specify a certificate." );
      }

      X509Certificate2 certificate = id.Find( true );

      // check that it is ok.
      if ( certificate != null )
      {
        createNewCertificate = !CheckApplicationInstanceCertificate( configuration, certificate, silent, minimumKeySize );
      }
      else
      {
        // check for missing private key.
        certificate = id.Find( false );

        if ( certificate != null )
        {
          throw ServiceResultException.Create( StatusCodes.BadConfigurationError, "Cannot access certificate private key. Subject={0}", certificate.Subject );
        }

        // check for missing thumbprint.
        if ( !String.IsNullOrEmpty( id.Thumbprint ) )
        {
          if ( !String.IsNullOrEmpty( id.SubjectName ) )
          {
            CertificateIdentifier id2 = new CertificateIdentifier();
            id2.StoreType = id.StoreType;
            id2.StorePath = id.StorePath;
            id2.SubjectName = id.SubjectName;

            certificate = id2.Find( true );
          }

          if ( certificate != null )
          {
            string message = Utils.Format(
                "Thumbprint was explicitly specified in the configuration." +
                "\r\nAnother certificate with the same subject name was found." +
                "\r\nUse it instead?\r\n" +
                "\r\nRequested: {0}" +
                "\r\nFound: {1}",
                id.SubjectName,
                certificate.Subject );

            throw ServiceResultException.Create( StatusCodes.BadConfigurationError, message );
          }
          else
          {
            string message = Utils.Format( "Thumbprint was explicitly specified in the configuration. Cannot generate a new certificate." );
            throw ServiceResultException.Create( StatusCodes.BadConfigurationError, message );
          }
        }
      }

      // create a new certificate.
      if ( createNewCertificate )
      {
        certificate = CreateApplicationInstanceCertificate( configuration, minimumKeySize, 600 );
      }
    }
    #endregion

    #region HTTPS Support
    /// <summary>
    /// Uses the UA validation logic for HTTPS certificates.
    /// </summary>
    /// <param name="validator">The validator.</param>
    public static void SetUaValidationForHttps( CertificateValidator validator )
    {
      m_validator = validator;
      System.Net.ServicePointManager.ServerCertificateValidationCallback = HttpsCertificateValidation;
    }

    /// <summary>
    /// Remotes the certificate validate.
    /// </summary>
    private static bool HttpsCertificateValidation(
        object sender,
        X509Certificate cert,
        X509Chain chain,
        System.Net.Security.SslPolicyErrors error )
    {
      try
      {
        // m_validator.Validate(new X509Certificate2(cert.GetRawCertData()));
        return true;
      }
      catch ( Exception e )
      {
        Utils.Trace( e, "Could not verify SSL certificate: {0}", cert.Subject );
        return false;
      }
    }

    private static CertificateValidator m_validator;
    #endregion

    #region Private Methods
    /// <summary>
    /// Creates an application instance certificate if one does not already exist.
    /// </summary>
    private static bool CheckApplicationInstanceCertificate(
        ApplicationConfiguration configuration,
        X509Certificate2 certificate,
        bool silent,
        ushort minimumKeySize )
    {
      if ( certificate == null )
      {
        return false;
      }

      Utils.Trace( Utils.TraceMasks.Information, "Checking application instance certificate. {0}", certificate.Subject );

      // check key size.
      if ( minimumKeySize > certificate.PublicKey.Key.KeySize )
      {
        bool valid = false;

        string message = Utils.Format(
            "The key size ({0}) in the certificate is less than the minimum provided ({1}). Update certificate?",
            certificate.PublicKey.Key.KeySize,
            minimumKeySize );

        if ( !silent )
        {
          if ( MessageBox.Show( message, configuration.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) != DialogResult.Yes )
          {
            valid = true;
          }
        }

        Utils.Trace( message );

        if ( !valid )
        {
          return false;
        }
      }

      // check domains.
      if ( configuration.ApplicationType != ApplicationType.Client )
      {
        if ( !CheckDomainsInCertificate( configuration, certificate, silent ) )
        {
          return false;
        }
      }

      // update uri.
      string applicationUri = Utils.GetApplicationUriFromCertficate( certificate );

      if ( String.IsNullOrEmpty( applicationUri ) )
      {
        bool valid = false;

        string message = "The Application URI is not specified in the certificate. Update certificate?";

        if ( !silent )
        {
          if ( MessageBox.Show( message, configuration.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) != DialogResult.Yes )
          {
            valid = true;
          }
        }

        Utils.Trace( message );

        if ( !valid )
        {
          return false;
        }
      }

      // update configuration.
      configuration.ApplicationUri = applicationUri;
      configuration.SecurityConfiguration.ApplicationCertificate.Certificate = certificate;

      return true;
    }

    /// <summary>
    /// Checks that the domains in the server addresses match the domains in the certificates.
    /// </summary>
    private static bool CheckDomainsInCertificate(
        ApplicationConfiguration configuration,
        X509Certificate2 certificate,
        bool silent )
    {
      Utils.Trace( Utils.TraceMasks.Information, "Checking domains in certificate. {0}", certificate.Subject );

      bool valid = true;
      IList<string> serverDomainNames = configuration.GetServerDomainNames();
      IList<string> certificateDomainNames = Utils.GetDomainsFromCertficate( certificate );

      // get computer name.
      string computerName = System.Net.Dns.GetHostName();

      // get DNS aliases and IP addresses.
      System.Net.IPHostEntry entry = System.Net.Dns.GetHostEntry( computerName );

      for ( int ii = 0; ii < serverDomainNames.Count; ii++ )
      {
        if ( Utils.FindStringIgnoreCase( certificateDomainNames, serverDomainNames[ ii ] ) )
        {
          continue;
        }

        if ( String.Compare( serverDomainNames[ ii ], "localhost", StringComparison.OrdinalIgnoreCase ) == 0 )
        {
          if ( Utils.FindStringIgnoreCase( certificateDomainNames, computerName ) )
          {
            continue;
          }

          // check for aliases.
          bool found = false;

          for ( int jj = 0; jj < entry.Aliases.Length; jj++ )
          {
            if ( Utils.FindStringIgnoreCase( certificateDomainNames, entry.Aliases[ jj ] ) )
            {
              found = true;
              break;
            }
          }

          if ( found )
          {
            continue;
          }

          // check for ip addresses.
          for ( int jj = 0; jj < entry.AddressList.Length; jj++ )
          {
            if ( Utils.FindStringIgnoreCase( certificateDomainNames, entry.AddressList[ jj ].ToString() ) )
            {
              found = true;
              break;
            }
          }

          if ( found )
          {
            continue;
          }
        }

        string message = Utils.Format(
            "The server is configured to use domain '{0}' which does not appear in the certificate. Update certificate?",
            serverDomainNames[ ii ] );

        valid = false;

        if ( !silent )
        {
          if ( MessageBox.Show( message, configuration.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) != DialogResult.Yes )
          {
            valid = true;
            continue;
          }
        }

        Utils.Trace( message );
        break;
      }

      return valid;
    }

    /// <summary>
    /// Configures the firewall.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="silent">if set to <c>true</c> if no dialogs should be displayed.</param>
    /// <param name="remove">if set to <c>true</c> if removing permissions.</param>
    private static void ConfigureFirewall( ApplicationConfiguration configuration, bool silent, bool remove )
    {
      Utils.Trace( Utils.TraceMasks.Information, "Configuring firewall." );

      // check for ports to open/close.
      StringCollection baseAddresses = new StringCollection();

      if ( configuration.ServerConfiguration != null )
      {
        baseAddresses = configuration.ServerConfiguration.BaseAddresses;
      }

      if ( configuration.DiscoveryServerConfiguration != null )
      {
        baseAddresses = configuration.DiscoveryServerConfiguration.BaseAddresses;
      }

      // remove access.
      if ( remove )
      {
        try
        {
          ConfigUtils.RemoveFirewallAccess( Application.ExecutablePath, baseAddresses );
        }
        catch ( Exception e )
        {
          Utils.Trace( e, "Unexpected error while removing firewall access." );
        }

        return;
      }

      // enable access.
      try
      {
        // check if firewall needs configuration.
        if ( !ConfigUtils.CheckFirewallAccess( Application.ExecutablePath, baseAddresses ) )
        {
          bool configure = true;

          if ( !silent )
          {
            string message = "The firewall has not been configured to allow external access to the server. Configure firewall?";

            if ( MessageBox.Show( message, configuration.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question ) != DialogResult.Yes )
            {
              configure = false;
            }
          }

          if ( configure )
          {
            ConfigUtils.SetFirewallAccess( configuration.ApplicationName, Application.ExecutablePath, baseAddresses );
          }
        }
      }
      catch ( Exception e )
      {
        Utils.Trace( e, "Unexpected error while checking or changing the firewall configuration." );
      }
    }

    /// <summary>
    /// Creates the application instance certificate.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="keySize">Size of the key.</param>
    /// <param name="lifetimeInMonths">The lifetime in months.</param>
    /// <returns>The new certificate</returns>
    private static X509Certificate2 CreateApplicationInstanceCertificate(
        ApplicationConfiguration configuration,
        ushort keySize,
        ushort lifetimeInMonths )
    {
      Utils.Trace( Utils.TraceMasks.Information, "Creating application instance certificate. KeySize={0}, Lifetime={1}", keySize, lifetimeInMonths );

      // delete existing any existing certificate.
      DeleteApplicationInstanceCertificate( configuration );

      CertificateIdentifier id = configuration.SecurityConfiguration.ApplicationCertificate;

      // get the domains from the configuration file.
      IList<string> serverDomainNames = configuration.GetServerDomainNames();

      if ( serverDomainNames.Count == 0 )
      {
        serverDomainNames.Add( System.Net.Dns.GetHostName() );
      }

      // ensure the certificate store directory exists.
      if ( id.StoreType == CertificateStoreType.Directory )
      {
        Utils.GetAbsoluteDirectoryPath( id.StorePath, true, true, true );
      }

      X509Certificate2 certificate = Opc.Ua.CertificateFactory.CreateCertificate(
          id.StoreType,
          id.StorePath,
          configuration.ApplicationUri,
          configuration.ApplicationName,
          null,
          serverDomainNames,
          keySize,
          lifetimeInMonths );

      id.Certificate = certificate;
      AddToTrustedPeerStore( configuration, certificate );

      configuration.CertificateValidator.Update( configuration.SecurityConfiguration );

      Utils.Trace( Utils.TraceMasks.Information, "Certificate created. Thumbprint={0}", certificate.Thumbprint );

      return certificate;
    }

    /// <summary>
    /// Deletes an existing application instance certificate.
    /// </summary>
    /// <param name="configuration">The configuration instance that stores the configurable information for a UA application.</param>
    private static void DeleteApplicationInstanceCertificate( ApplicationConfiguration configuration )
    {
      Utils.Trace( Utils.TraceMasks.Information, "Deleting application instance certificate." );

      // create a default certificate id none specified.
      CertificateIdentifier id = configuration.SecurityConfiguration.ApplicationCertificate;

      if ( id == null )
      {
        return;
      }

      // delete private key.
      X509Certificate2 certificate = id.Find();

      // delete trusted peer certificate.
      if ( configuration.SecurityConfiguration != null && configuration.SecurityConfiguration.TrustedPeerCertificates != null )
      {
        string thumbprint = id.Thumbprint;

        if ( certificate != null )
        {
          thumbprint = certificate.Thumbprint;
        }

        using ( ICertificateStore store = configuration.SecurityConfiguration.TrustedPeerCertificates.OpenStore() )
        {
          store.Delete( thumbprint );
        }
      }

      // delete private key.
      if ( certificate != null )
      {
        using ( ICertificateStore store = id.OpenStore() )
        {
          store.Delete( certificate.Thumbprint );
        }
      }
    }

    /// <summary>
    /// Adds the application certificate to the discovery server trust list.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="certificate">The certificate.</param>
    private static void AddToDiscoveryServerTrustList( ApplicationConfiguration configuration, X509Certificate2 certificate )
    {
      Utils.Trace( Utils.TraceMasks.Information, "Adding certificate to discovery server trust list." );

      try
      {
        // find the LDS exe/
        string path = Utils.FindInstalledFile( "Opc.Ua.DiscoveryServer.exe" );

        if ( path == null )
        {
          throw new ServiceResultException( "Could not find the discovery server. Please confirm that it is installed." );
        }

        // load the application configuration.
        ManagedApplication lds = new ManagedApplication();
        lds.SetExecutableFile( path );

        string configurationPath = Utils.GetAbsoluteFilePath( lds.ConfigurationPath, true, false, false );

        if ( configurationPath == null )
        {
          throw new ServiceResultException( "Could not find the discovery server configuration file. Please confirm that it is installed." );
        }

        SecuredApplication ldsConfiguration = new SecurityConfigurationManager().ReadConfiguration( configurationPath );

        // add application certificate to LDS trust list.
        ICertificateStore store = ldsConfiguration.TrustedPeerStore.OpenStore();

        try
        {
          if ( store.FindByThumbprint( certificate.Thumbprint ) == null )
          {
            store.Add( new X509Certificate2( certificate.RawData ) );
          }
        }
        finally
        {
          store.Close();
        }

        // add LDS certificate to application trust list.
        if ( configuration.SecurityConfiguration != null && configuration.SecurityConfiguration.TrustedPeerCertificates != null )
        {
          try
          {
            store = configuration.SecurityConfiguration.TrustedPeerCertificates.OpenStore();

            if ( store.FindByThumbprint( certificate.Thumbprint ) == null )
            {
              store.Add( new X509Certificate2( certificate.RawData ) );
            }
          }
          finally
          {
            store.Close();
          }
        }
      }
      catch ( Exception e )
      {
        Utils.Trace( e, "Could not add certificate to discovery server store." );
      }
    }

    /// <summary>
    /// Adds the certificate to the Trusted Peer Certificate Store
    /// </summary>
    /// <param name="configuration">The application's configuration which specifies the location of the TrustedPeerStore.</param>
    /// <param name="certificate">The certificate to register.</param>
    private static void AddToTrustedPeerStore( ApplicationConfiguration configuration, X509Certificate2 certificate )
    {
      string storePath = null;

      if ( configuration != null && configuration.SecurityConfiguration != null && configuration.SecurityConfiguration.TrustedPeerCertificates != null )
      {
        storePath = configuration.SecurityConfiguration.TrustedPeerCertificates.StorePath;
      }

      if ( String.IsNullOrEmpty( storePath ) )
      {
        Utils.Trace( Utils.TraceMasks.Information, "WARNING: Trusted peer store not specified." );
        return;
      }

      Utils.Trace( Utils.TraceMasks.Information, "Adding certificate to trusted peer store. StorePath={0}", storePath );

      try
      {
        ICertificateStore store = configuration.SecurityConfiguration.TrustedPeerCertificates.OpenStore();

        try
        {
          // check if it already exists.
          X509Certificate2 certificate2 = store.FindByThumbprint( certificate.Thumbprint );

          if ( certificate2 != null )
          {
            return;
          }

          List<string> subjectName = Utils.ParseDistinguishedName( certificate.Subject );

          // check for old certificate.
          X509Certificate2Collection certificates = store.Enumerate();

          for ( int ii = 0; ii < certificates.Count; ii++ )
          {
            if ( Utils.CompareDistinguishedName( certificates[ ii ], subjectName ) )
            {
              if ( certificates[ ii ].Thumbprint == certificate.Thumbprint )
              {
                return;
              }

              store.Delete( certificates[ ii ].Thumbprint );
              break;
            }
          }

          // add new certificate.
          X509Certificate2 publicKey = new X509Certificate2( certificate.GetRawCertData() );
          store.Add( publicKey );
        }
        finally
        {
          store.Close();
        }
      }
      catch ( Exception e )
      {
        Utils.Trace( e, "Could not add certificate to trusted peer store. StorePath={0}", storePath );
      }
    }

    /// <summary>
    /// Configures the HTTP access.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="remove">if set to <c>true</c> then the HTTP access should be removed.</param>
    private void ConfigureHttpAccess( ApplicationConfiguration configuration, bool remove )
    {
      Utils.Trace( Utils.TraceMasks.Information, "Configuring HTTP access." );

      // check for HTTP endpoints which need configuring.
      StringCollection baseAddresses = new StringCollection();

      if ( configuration.DiscoveryServerConfiguration != null )
      {
        baseAddresses = configuration.DiscoveryServerConfiguration.BaseAddresses;
      }

      if ( configuration.ServerConfiguration != null )
      {
        baseAddresses = configuration.ServerConfiguration.BaseAddresses;
      }

      // configure WCF http access.
      for ( int ii = 0; ii < baseAddresses.Count; ii++ )
      {
        string url = baseAddresses[ ii ];

        if ( url.StartsWith( Utils.UriSchemeHttp ) )
        {
          SetHttpAccessRules( url, remove );
        }
      }
    }

    /// <summary>
    /// Gets the access rules to use for the application.
    /// </summary>
    private List<ApplicationAccessRule> GetAccessRules()
    {
      List<ApplicationAccessRule> rules = new List<ApplicationAccessRule>();

      // check for rules specified in the installer configuration.
      bool hasAdmin = false;

      if ( InstallConfig.AccessRules != null )
      {
        for ( int ii = 0; ii < InstallConfig.AccessRules.Count; ii++ )
        {
          ApplicationAccessRule rule = InstallConfig.AccessRules[ ii ];

          if ( rule.Right == ApplicationAccessRight.Configure && rule.RuleType == AccessControlType.Allow )
          {
            hasAdmin = true;
            break;
          }
        }

        rules.AddRange( InstallConfig.AccessRules );
      }

      // provide some default rules.
      if ( rules.Count == 0 )
      {
        // give user run access.
        ApplicationAccessRule rule = new ApplicationAccessRule();
        rule.RuleType = AccessControlType.Allow;
        rule.Right = ApplicationAccessRight.Run;
        rule.IdentityName = WellKnownSids.Users;
        rules.Add( rule );

        // ensure service can access.
        if ( InstallConfig.InstallAsService )
        {
          rule = new ApplicationAccessRule();
          rule.RuleType = AccessControlType.Allow;
          rule.Right = ApplicationAccessRight.Run;
          rule.IdentityName = WellKnownSids.NetworkService;
          rules.Add( rule );

          rule = new ApplicationAccessRule();
          rule.RuleType = AccessControlType.Allow;
          rule.Right = ApplicationAccessRight.Run;
          rule.IdentityName = WellKnownSids.LocalService;
          rules.Add( rule );
        }
      }

      // ensure someone can change the configuration later.
      if ( !hasAdmin )
      {
        ApplicationAccessRule rule = new ApplicationAccessRule();
        rule.RuleType = AccessControlType.Allow;
        rule.Right = ApplicationAccessRight.Configure;
        rule.IdentityName = WellKnownSids.Administrators;
        rules.Add( rule );
      }

      return rules;
    }

    /// <summary>
    /// Sets the HTTP access rules for the URL.
    /// </summary>
    private void SetHttpAccessRules( string url, bool remove )
    {
      try
      {
        List<ApplicationAccessRule> rules = new List<ApplicationAccessRule>();

        if ( !remove )
        {
          rules = GetAccessRules();
        }

        HttpAccessRule.SetAccessRules( new Uri( url ), rules, false );
      }
      catch ( Exception e )
      {
        Utils.Trace( e, "Unexpected configuring the HTTP access rules." );
      }
    }

    /// <summary>
    /// Configures access to the executable, the configuration file and the private key.
    /// </summary>
    private void ConfigureFileAccess( ApplicationConfiguration configuration )
    {
      Utils.Trace( Utils.TraceMasks.Information, "Configuring file access." );

      List<ApplicationAccessRule> rules = GetAccessRules();

      // apply access rules to the excutable file.
      try
      {
        if ( InstallConfig.SetExecutableFilePermisions )
        {
          ApplicationAccessRule.SetAccessRules( InstallConfig.ExecutableFile, rules, true );
        }
      }
      catch ( Exception e )
      {
        Utils.Trace( e, "Could not set executable file permissions." );
      }

      // apply access rules to the configuration file.
      try
      {
        if ( InstallConfig.SetConfigurationFilePermisions )
        {
          ApplicationAccessRule.SetAccessRules( configuration.SourceFilePath, rules, true );
        }
      }
      catch ( Exception e )
      {
        Utils.Trace( e, "Could not set configuration file permissions." );
      }

      // apply access rules to the private key file.
      try
      {
        X509Certificate2 certificate = configuration.SecurityConfiguration.ApplicationCertificate.Find( true );

        if ( certificate != null )
        {
          ICertificateStore store = configuration.SecurityConfiguration.ApplicationCertificate.OpenStore();
          store.SetAccessRules( certificate.Thumbprint, rules, true );
        }
      }
      catch ( Exception e )
      {
        Utils.Trace( e, "Could not set private key file permissions." );
      }
    }
    #endregion

    #region Private Fields
    private string m_applicationName;
    private ApplicationType m_applicationType;
    private string m_configSectionName;
    private InstalledApplication m_installConfig;
    private ServerBase m_server;
    private ApplicationConfiguration m_applicationConfiguration;
    #endregion

  }
}
