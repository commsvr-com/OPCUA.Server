//<summary>
//  Title   : Data Bindings Manager
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

using CAS.UA.Server.DataSource.External;

namespace CAS.UA.Server.DataBindings
{
  partial class DataBindingsManager
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.m_DAClient = new CAS.Lib.OPCClient.Da.Main(this.components);
      this.m_CommServer = new CommServer.ProtocolHub.Communication.CommServerComponent(this.components);
      this.m_ExternalDataSource = new ExternalDataSourceComponent(this.components);

    }

    #endregion

    private CAS.Lib.OPCClient.Da.Main m_DAClient;
    private CommServer.ProtocolHub.Communication.CommServerComponent m_CommServer;
    private ExternalDataSourceComponent m_ExternalDataSource;
  }
}
