//<summary>
//  Title   : CommServer UA Installer
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;


namespace CAS.UA.Server
{
  /// <summary>
  /// Class ServiceInstaller - entry point for installer
  /// </summary>
  [RunInstaller( true )]
  public partial class ServiceInstaller: Installer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceInstaller"/> class.
    /// </summary>
    public ServiceInstaller()
    {
      InitializeComponent();
    }
    /// <summary>
    /// When overridden in a derived class, performs the installation.
    /// </summary>
    /// <param name="stateSaver">An <see cref="T:System.Collections.IDictionary"/> used to save information needed to perform a commit, rollback, or uninstall operation.</param>
    /// <exception cref="T:System.ArgumentException">
    /// The <paramref name="stateSaver"/> parameter is null.
    /// </exception>
    /// <exception cref="T:System.Exception">
    /// An exception occurred in the <see cref="E:System.Configuration.Install.Installer.BeforeInstall"/> event handler of one of the installers in the collection.
    /// -or-
    /// An exception occurred in the <see cref="E:System.Configuration.Install.Installer.AfterInstall"/> event handler of one of the installers in the collection.
    /// </exception>
    public override void Commit( IDictionary stateSaver )
    {
      base.Commit( stateSaver );
      
      CASApplicationInstance.InstallServer(Context.Parameters[ "AssemblyPath" ]);
    }
    /// <summary>
    /// When overridden in a derived class, removes an installation.
    /// </summary>
    /// <param name="savedState">An <see cref="T:System.Collections.IDictionary"/> that contains the state of the computer after the installation was complete.</param>
    /// <exception cref="T:System.ArgumentException">
    /// The saved-state <see cref="T:System.Collections.IDictionary"/> might have been corrupted.
    /// </exception>
    /// <exception cref="T:System.Configuration.Install.InstallException">
    /// An exception occurred while uninstalling. This exception is ignored and the uninstall continues. However, the application might not be fully uninstalled after the uninstallation completes.
    /// </exception>
    public override void Uninstall( IDictionary savedState )
    {
      base.Uninstall( savedState );
      CASApplicationInstance.UnInstallServer( Context.Parameters[ "AssemblyPath" ] );
    }
  }
}
