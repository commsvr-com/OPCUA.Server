//<summary>
//  Title   : Server diagnostic control
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
      

namespace CAS.UA.Server.UserInterface
{
    partial class ServerDiagnosticsCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.components = new System.ComponentModel.Container();
          this.AddressPN = new System.Windows.Forms.Panel();
          this.EndpointsLB = new System.Windows.Forms.Label();
          this.UrlCB = new System.Windows.Forms.ComboBox();
          this.StatusBAR = new System.Windows.Forms.StatusStrip();
          this.ServerStatusLB = new System.Windows.Forms.ToolStripStatusLabel();
          this.ServerStateLB = new System.Windows.Forms.ToolStripStatusLabel();
          this.ServerTimeStartLabel = new System.Windows.Forms.ToolStripStatusLabel();
          this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
          this.StartTimeValueLabel = new System.Windows.Forms.ToolStripStatusLabel();
          this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
          this.UpdateTimerCTRL = new System.Windows.Forms.Timer( this.components );
          this.serverMonitorTabControl = new System.Windows.Forms.TabControl();
          this.SessionsTabPage = new System.Windows.Forms.TabPage();
          this.SessionsGB = new System.Windows.Forms.GroupBox();
          this.SessionsLV = new System.Windows.Forms.ListView();
          this.SessionIdCH = new System.Windows.Forms.ColumnHeader();
          this.SessionNameCH = new System.Windows.Forms.ColumnHeader();
          this.UserNameCH = new System.Windows.Forms.ColumnHeader();
          this.LastContactTimeCH = new System.Windows.Forms.ColumnHeader();
          this.subscriptionsTabPage = new System.Windows.Forms.TabPage();
          this.SubscriptionsGB = new System.Windows.Forms.GroupBox();
          this.SubscriptionsLV = new System.Windows.Forms.ListView();
          this.SubscriptionIdCH = new System.Windows.Forms.ColumnHeader();
          this.PublishingIntervalCH = new System.Windows.Forms.ColumnHeader();
          this.ItemCountCH = new System.Windows.Forms.ColumnHeader();
          this.SequenceNumberCH = new System.Windows.Forms.ColumnHeader();
          this.PriorityCH = new System.Windows.Forms.ColumnHeader();
          this.SessionIdentifier = new System.Windows.Forms.ColumnHeader();
          this.AddressPN.SuspendLayout();
          this.StatusBAR.SuspendLayout();
          this.serverMonitorTabControl.SuspendLayout();
          this.SessionsTabPage.SuspendLayout();
          this.SessionsGB.SuspendLayout();
          this.subscriptionsTabPage.SuspendLayout();
          this.SubscriptionsGB.SuspendLayout();
          this.SuspendLayout();
          // 
          // AddressPN
          // 
          this.AddressPN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.AddressPN.Controls.Add( this.EndpointsLB );
          this.AddressPN.Controls.Add( this.UrlCB );
          this.AddressPN.Dock = System.Windows.Forms.DockStyle.Top;
          this.AddressPN.Location = new System.Drawing.Point( 0, 0 );
          this.AddressPN.Name = "AddressPN";
          this.AddressPN.Padding = new System.Windows.Forms.Padding( 2, 0, 2, 0 );
          this.AddressPN.Size = new System.Drawing.Size( 572, 32 );
          this.AddressPN.TabIndex = 4;
          // 
          // EndpointsLB
          // 
          this.EndpointsLB.AutoSize = true;
          this.EndpointsLB.Location = new System.Drawing.Point( 0, 7 );
          this.EndpointsLB.Name = "EndpointsLB";
          this.EndpointsLB.Size = new System.Drawing.Size( 113, 13 );
          this.EndpointsLB.TabIndex = 2;
          this.EndpointsLB.Text = "Server Endpoint URLs";
          this.EndpointsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // UrlCB
          // 
          this.UrlCB.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                      | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.UrlCB.FormattingEnabled = true;
          this.UrlCB.Location = new System.Drawing.Point( 119, 4 );
          this.UrlCB.Name = "UrlCB";
          this.UrlCB.Size = new System.Drawing.Size( 444, 21 );
          this.UrlCB.TabIndex = 1;
          // 
          // StatusBAR
          // 
          this.StatusBAR.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.ServerStatusLB,
            this.ServerStateLB,
            this.ServerTimeStartLabel,
            this.toolStripStatusLabel1,
            this.StartTimeValueLabel,
            this.toolStripStatusLabel2} );
          this.StatusBAR.Location = new System.Drawing.Point( 0, 323 );
          this.StatusBAR.Name = "StatusBAR";
          this.StatusBAR.Size = new System.Drawing.Size( 572, 22 );
          this.StatusBAR.TabIndex = 5;
          this.StatusBAR.Text = "statusStrip1";
          // 
          // ServerStatusLB
          // 
          this.ServerStatusLB.Name = "ServerStatusLB";
          this.ServerStatusLB.Size = new System.Drawing.Size( 42, 17 );
          this.ServerStatusLB.Text = "Status:";
          // 
          // ServerStateLB
          // 
          this.ServerStateLB.Name = "ServerStateLB";
          this.ServerStateLB.Size = new System.Drawing.Size( 52, 17 );
          this.ServerStateLB.Text = "Running";
          // 
          // ServerTimeStartLabel
          // 
          this.ServerTimeStartLabel.Name = "ServerTimeStartLabel";
          this.ServerTimeStartLabel.Size = new System.Drawing.Size( 49, 17 );
          this.ServerTimeStartLabel.Text = "00:00:00";
          // 
          // toolStripStatusLabel1
          // 
          this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
          this.toolStripStatusLabel1.Size = new System.Drawing.Size( 61, 17 );
          this.toolStripStatusLabel1.Text = "Start time:";
          // 
          // StartTimeValueLabel
          // 
          this.StartTimeValueLabel.Name = "StartTimeValueLabel";
          this.StartTimeValueLabel.Size = new System.Drawing.Size( 49, 17 );
          this.StartTimeValueLabel.Text = "00:00:00";
          // 
          // toolStripStatusLabel2
          // 
          this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
          this.toolStripStatusLabel2.Size = new System.Drawing.Size( 0, 17 );
          // 
          // UpdateTimerCTRL
          // 
          this.UpdateTimerCTRL.Interval = 1000;
          this.UpdateTimerCTRL.Tick += new System.EventHandler( this.UpdateTimerCTRL_Tick );
          // 
          // serverMonitorTabControl
          // 
          this.serverMonitorTabControl.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                      | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.serverMonitorTabControl.Controls.Add( this.SessionsTabPage );
          this.serverMonitorTabControl.Controls.Add( this.subscriptionsTabPage );
          this.serverMonitorTabControl.Location = new System.Drawing.Point( 5, 38 );
          this.serverMonitorTabControl.Name = "serverMonitorTabControl";
          this.serverMonitorTabControl.SelectedIndex = 0;
          this.serverMonitorTabControl.Size = new System.Drawing.Size( 560, 282 );
          this.serverMonitorTabControl.TabIndex = 6;
          // 
          // SessionsTabPage
          // 
          this.SessionsTabPage.Controls.Add( this.SessionsGB );
          this.SessionsTabPage.Location = new System.Drawing.Point( 4, 22 );
          this.SessionsTabPage.Name = "SessionsTabPage";
          this.SessionsTabPage.Padding = new System.Windows.Forms.Padding( 3 );
          this.SessionsTabPage.Size = new System.Drawing.Size( 552, 256 );
          this.SessionsTabPage.TabIndex = 0;
          this.SessionsTabPage.Text = "Sessions";
          this.SessionsTabPage.UseVisualStyleBackColor = true;
          // 
          // SessionsGB
          // 
          this.SessionsGB.Controls.Add( this.SessionsLV );
          this.SessionsGB.Dock = System.Windows.Forms.DockStyle.Fill;
          this.SessionsGB.Location = new System.Drawing.Point( 3, 3 );
          this.SessionsGB.Name = "SessionsGB";
          this.SessionsGB.Size = new System.Drawing.Size( 546, 250 );
          this.SessionsGB.TabIndex = 3;
          this.SessionsGB.TabStop = false;
          this.SessionsGB.Text = "Sessions";
          // 
          // SessionsLV
          // 
          this.SessionsLV.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.SessionIdCH,
            this.SessionNameCH,
            this.UserNameCH,
            this.LastContactTimeCH} );
          this.SessionsLV.Dock = System.Windows.Forms.DockStyle.Fill;
          this.SessionsLV.FullRowSelect = true;
          this.SessionsLV.Location = new System.Drawing.Point( 3, 16 );
          this.SessionsLV.Name = "SessionsLV";
          this.SessionsLV.Size = new System.Drawing.Size( 540, 231 );
          this.SessionsLV.TabIndex = 0;
          this.SessionsLV.UseCompatibleStateImageBehavior = false;
          this.SessionsLV.View = System.Windows.Forms.View.Details;
          // 
          // SessionIdCH
          // 
          this.SessionIdCH.Text = "SessionId";
          this.SessionIdCH.Width = 116;
          // 
          // SessionNameCH
          // 
          this.SessionNameCH.Text = "Name";
          this.SessionNameCH.Width = 97;
          // 
          // UserNameCH
          // 
          this.UserNameCH.Text = "User (session ID)";
          this.UserNameCH.Width = 141;
          // 
          // LastContactTimeCH
          // 
          this.LastContactTimeCH.Text = "Last Contact";
          this.LastContactTimeCH.Width = 126;
          // 
          // subscriptionsTabPage
          // 
          this.subscriptionsTabPage.Controls.Add( this.SubscriptionsGB );
          this.subscriptionsTabPage.Location = new System.Drawing.Point( 4, 22 );
          this.subscriptionsTabPage.Name = "subscriptionsTabPage";
          this.subscriptionsTabPage.Padding = new System.Windows.Forms.Padding( 3 );
          this.subscriptionsTabPage.Size = new System.Drawing.Size( 552, 256 );
          this.subscriptionsTabPage.TabIndex = 1;
          this.subscriptionsTabPage.Text = "Subscriptions";
          this.subscriptionsTabPage.UseVisualStyleBackColor = true;
          // 
          // SubscriptionsGB
          // 
          this.SubscriptionsGB.Controls.Add( this.SubscriptionsLV );
          this.SubscriptionsGB.Dock = System.Windows.Forms.DockStyle.Fill;
          this.SubscriptionsGB.Location = new System.Drawing.Point( 3, 3 );
          this.SubscriptionsGB.Name = "SubscriptionsGB";
          this.SubscriptionsGB.Size = new System.Drawing.Size( 546, 250 );
          this.SubscriptionsGB.TabIndex = 2;
          this.SubscriptionsGB.TabStop = false;
          this.SubscriptionsGB.Text = "Subscriptions";
          // 
          // SubscriptionsLV
          // 
          this.SubscriptionsLV.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.SubscriptionIdCH,
            this.PublishingIntervalCH,
            this.ItemCountCH,
            this.SequenceNumberCH,
            this.PriorityCH,
            this.SessionIdentifier} );
          this.SubscriptionsLV.Dock = System.Windows.Forms.DockStyle.Fill;
          this.SubscriptionsLV.FullRowSelect = true;
          this.SubscriptionsLV.Location = new System.Drawing.Point( 3, 16 );
          this.SubscriptionsLV.Name = "SubscriptionsLV";
          this.SubscriptionsLV.Size = new System.Drawing.Size( 540, 231 );
          this.SubscriptionsLV.TabIndex = 1;
          this.SubscriptionsLV.UseCompatibleStateImageBehavior = false;
          this.SubscriptionsLV.View = System.Windows.Forms.View.Details;
          // 
          // SubscriptionIdCH
          // 
          this.SubscriptionIdCH.Text = "SubscriptionId";
          this.SubscriptionIdCH.Width = 90;
          // 
          // PublishingIntervalCH
          // 
          this.PublishingIntervalCH.Text = "Publishing Interval";
          this.PublishingIntervalCH.Width = 109;
          // 
          // ItemCountCH
          // 
          this.ItemCountCH.Text = "Item Count";
          this.ItemCountCH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
          this.ItemCountCH.Width = 126;
          // 
          // SequenceNumberCH
          // 
          this.SequenceNumberCH.Text = "Seq No";
          this.SequenceNumberCH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
          this.SequenceNumberCH.Width = 66;
          // 
          // PriorityCH
          // 
          this.PriorityCH.Text = "Priority";
          this.PriorityCH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
          this.PriorityCH.Width = 74;
          // 
          // SessionIdentifier
          // 
          this.SessionIdentifier.Text = "SessionId";
          // 
          // ServerDiagnosticsCtrl
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add( this.serverMonitorTabControl );
          this.Controls.Add( this.StatusBAR );
          this.Controls.Add( this.AddressPN );
          this.Name = "ServerDiagnosticsCtrl";
          this.Size = new System.Drawing.Size( 572, 345 );
          this.AddressPN.ResumeLayout( false );
          this.AddressPN.PerformLayout();
          this.StatusBAR.ResumeLayout( false );
          this.StatusBAR.PerformLayout();
          this.serverMonitorTabControl.ResumeLayout( false );
          this.SessionsTabPage.ResumeLayout( false );
          this.SessionsGB.ResumeLayout( false );
          this.subscriptionsTabPage.ResumeLayout( false );
          this.SubscriptionsGB.ResumeLayout( false );
          this.ResumeLayout( false );
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel AddressPN;
        private System.Windows.Forms.Label EndpointsLB;
        private System.Windows.Forms.ComboBox UrlCB;
        private System.Windows.Forms.StatusStrip StatusBAR;
        private System.Windows.Forms.ToolStripStatusLabel ServerStatusLB;
        private System.Windows.Forms.ToolStripStatusLabel ServerStateLB;
        private System.Windows.Forms.ToolStripStatusLabel ServerTimeStartLabel;
        private System.Windows.Forms.Timer UpdateTimerCTRL;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StartTimeValueLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TabControl serverMonitorTabControl;
        private System.Windows.Forms.TabPage SessionsTabPage;
        private System.Windows.Forms.GroupBox SessionsGB;
        private System.Windows.Forms.ListView SessionsLV;
        private System.Windows.Forms.ColumnHeader SessionIdCH;
        private System.Windows.Forms.ColumnHeader SessionNameCH;
        private System.Windows.Forms.ColumnHeader UserNameCH;
        private System.Windows.Forms.ColumnHeader LastContactTimeCH;
        private System.Windows.Forms.TabPage subscriptionsTabPage;
        private System.Windows.Forms.GroupBox SubscriptionsGB;
        private System.Windows.Forms.ListView SubscriptionsLV;
        private System.Windows.Forms.ColumnHeader SubscriptionIdCH;
        private System.Windows.Forms.ColumnHeader PublishingIntervalCH;
        private System.Windows.Forms.ColumnHeader ItemCountCH;
        private System.Windows.Forms.ColumnHeader SequenceNumberCH;
        private System.Windows.Forms.ColumnHeader PriorityCH;
        private System.Windows.Forms.ColumnHeader SessionIdentifier;
    }
}
