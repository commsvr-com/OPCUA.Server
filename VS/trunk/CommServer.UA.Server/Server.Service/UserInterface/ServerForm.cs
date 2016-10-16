//<summary>
//  Title   : Server Form
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

using CAS.CommServer.UA.Server.Service.Properties;
using CAS.Lib.CodeProtect;
using CAS.Lib.ControlLibrary;
using CAS.Lib.RTLib.Processes;
using CAS.Windows.Forms.CodeProtectControls;
using Opc.Ua;
using Opc.Ua.Server;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace CAS.CommServer.UA.Server.Service.UserInterface
{
  internal partial class ServerForm : Form
  {
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ServerForm"/> class.
    /// </summary>
    /// <param name="server">The server.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="application">The application.</param>
    public ServerForm(StandardServer server, ApplicationConfiguration configuration, CASApplicationInstance application)
    {
      InitializeComponent();
      m_application = application;
      m_server = server;
      this.ServerDiagnosticsCTRL.Initialize(m_server, configuration);
      ApplicationCertificate.DisplayUaTcpImplementation( x => this.Text = x, this.Text, configuration);
      m_server.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
      TrayIcon.Text = this.Text;
    }
    #endregion

    #region Private Fields
    private StandardServer m_server;
    private CASApplicationInstance m_application;
    #endregion

    #region Private Methods
    /// <summary>
    /// Shows the diagnostics window
    /// </summary>
    private void ShowStatus()
    {
      Show();
      this.WindowState = FormWindowState.Normal;
      this.BringToFront();
    }
    /// <summary>
    /// Displays an unhandled exception.
    /// </summary>
    private static void HandleException(string caption, MethodBase method, Exception e)
    {
      if (String.IsNullOrEmpty(caption))
      {
        caption = method.Name;
      }
      MessageBox.Show(e.Message, caption);
    }
    #endregion

    #region Event Handlers
    /// <summary>
    /// Handles a certificate validation error.
    /// </summary>
    /// <param name="validator">The validator.</param>
    /// <param name="e">The <see cref="Opc.Ua.CertificateValidationEventArgs"/> instance containing the event data.</param>
    private void CertificateValidator_CertificateValidation(CertificateValidator validator, CertificateValidationEventArgs e)
    {
      try
      {
        string message = ApplicationCertificate.HandleCertificateValidationError( e);
        if (MessageBox.Show(message, this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
          e.Accept = true;
      }
      catch (Exception exception)
      {
        HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
      }
    }
    private void TrayIcon_Click(object sender, EventArgs e)
    {
      try
      {
        ShowStatus();
      }
      catch (Exception exception)
      {
        HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
      }
    }
    private void ServerForm_Resize(object sender, EventArgs e)
    {
      if (FormWindowState.Minimized == WindowState)
      {
        Hide();
      }
    }
    private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        DialogResult dr = MessageBox.Show("Do you want to extit application and stop CommServer UA?", "Exit CommServer UA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        if (dr == DialogResult.OK)
          m_server.Stop();
        else if (dr == DialogResult.Cancel)
          e.Cancel = true;
      }
      catch (Exception exception)
      {
        Utils.Trace(exception, "Error stopping server.");
      }
    }
    private void TrayIcon_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        if (m_server != null)
        {
          TrayIcon.Text = String.Format(
              "{0} [{1} {2:HH:mm:ss}]",
              m_application.ApplicationName,
              m_server.CurrentInstance.CurrentState,
              DateTime.Now);
        }
      }
      catch (Exception exception)
      {
        Utils.Trace(exception, "Error getting server status.");
      }
    }
    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (AboutForm dial = new AboutForm
        (Properties.Resources.about_CommServer, "Freeware", Assembly.GetEntryAssembly()))
      {
        dial.ShowDialog();
      }
    }
    private void onlineHelpToolStripMenuItem_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start(Resources.Help_Main);
    }
    private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Hide();
    }
    private void oPCUAViewerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string appname = AppDomain.CurrentDomain.BaseDirectory + "CAS.OPC.UA.Viewer.exe";
      string longappname = "OPC UA Viewer - OPC UA client";
      RunMethodAsynchronously runasync = new RunMethodAsynchronously
        (delegate(object[] o)
        {
          try
          {
            System.Diagnostics.Process.Start(appname);
          }
          catch (Exception ex)
          {
            MessageBox.Show(appname, "Cannot start the " + longappname + " :" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          };
        }
       );
      runasync.RunAsync();
    }
    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        DialogResult dr = MessageBox.Show("Do you want to extit application and stop CommServer UA?", "Exit CommServer UA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        if (dr == DialogResult.OK)
        {
          m_server.Stop();
          this.Dispose(true);
        }
      }
      catch (Exception exception)
      {
        Utils.Trace(exception, "Error stopping server.");
      }
    }
    private void rSSFeedsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start(Resources.RSS);
    }
    private void supportToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string MessageToBeShown = Resources.Support_MessageToBeShown;
      string MessageCaption = Resources.Support_MessageCaption;
      string emailAddress = Resources.Support_emailAddress;
      string messageSubject = Resources.Support_messageSubject;
      string MessageBody = Resources.Support_MessageBody;
      MessageBoxSentEmail.ShowMessageAndOpenEmailClient(MessageToBeShown, MessageCaption, DialogResult.OK, MessageBoxButtons.OKCancel, emailAddress, messageSubject, MessageBody);
    }
    private void homeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start(Resources.Home);
    }
    #endregion

    private void licenseInformationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (LicenseForm dial = new LicenseForm(Properties.Resources.about_CommServer, "Free ware", Assembly.GetEntryAssembly()))
      {
        Licenses cLicDial = new Licenses();
        dial.SetAdditionalControl = cLicDial;
        dial.LicenceRequestMessageProvider
          = new LicenseForm.LicenceRequestMessageProviderDelegate(
            delegate() { return cLicDial.GetLicenseMessageRequest(); });
        dial.ShowDialog();
      }
    }

    private void openLogContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string path = InstallContextNames.ApplicationDataPath + "\\log";
      try
      {
        using (Process process = Process.Start(@path)) { }
      }
      catch (Win32Exception)
      {
        MessageBox.Show("No Log folder exists under this link: " + path + " You can create this folder yourself.", "No Log folder !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      catch (Exception)
      {
        MessageBox.Show("An error during opening a log folder occurs and the log folder cannot be open", "Problem with log folder !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
    }

    private void enterUnlockCodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (UnlockKeyDialog dialog = new UnlockKeyDialog())
      {
        dialog.ShowDialog();
      }
    }

    private System.Resources.ResourceManager Getter()
    {
      return Resources.ResourceManager;
    }
  }
}