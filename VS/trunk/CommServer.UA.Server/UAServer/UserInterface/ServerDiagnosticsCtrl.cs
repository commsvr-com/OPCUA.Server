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
      

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Server;

namespace CAS.UA.Server.UserInterface
{
    /// <summary>
    /// Displays diagnostics information for a server running within the process.
    /// </summary>
    public partial class ServerDiagnosticsCtrl : UserControl
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerDiagnosticsCtrl"/> class.
        /// </summary>
        public ServerDiagnosticsCtrl()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        private StandardServer m_server;
        private ApplicationConfiguration m_configuration;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Creates a form which displays the status for a UA server.
        /// </summary>
        /// <param name="server">The server displayed in the form.</param>
        /// <param name="configuration">The configuration used to initialize the server.</param>
        public void Initialize(StandardServer server, ApplicationConfiguration configuration)
        {
            m_server = server;
            m_configuration = configuration;
            UpdateTimerCTRL.Enabled = true;
            
            // add the urls to the drop down.
            UrlCB.Items.Clear();

            foreach (EndpointDescription endpoint in m_server.GetEndpoints())
            {
                if (UrlCB.FindStringExact(endpoint.EndpointUrl) == -1)
                {
                    UrlCB.Items.Add(endpoint.EndpointUrl);
                }
            }

            if (UrlCB.Items.Count > 0)
            {
                UrlCB.SelectedIndex = 0;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Updates the sessions displayed in the form.
        /// </summary>
        private void UpdateSessions()
        {
            SessionsLV.Items.Clear();

            IList<Session> sessions = m_server.CurrentInstance.SessionManager.GetSessions();

            for (int ii = 0; ii < sessions.Count; ii++)
            {
                Session session = sessions[ii];

                lock (session.DiagnosticsLock)
                {
                    ListViewItem item = new ListViewItem(session.SessionDiagnostics.SessionName);

                    if (session.Identity != null)
                    {
                        item.SubItems.Add(session.Identity.DisplayName);
                    }
                    else
                    {
                        item.SubItems.Add(String.Empty);
                    }

                    item.SubItems.Add(String.Format("{0}", session.Id));
                    item.SubItems.Add(String.Format("{0:HH:mm:ss}", session.SessionDiagnostics.ClientLastContactTime.ToLocalTime()));

                    SessionsLV.Items.Add(item);
                }
            }

            // adjust 
            for (int ii = 0; ii < SessionsLV.Columns.Count; ii++)
            {
                SessionsLV.Columns[ii].Width = -2;
            }
        }

        /// <summary>
        /// Updates the subscriptions displayed in the form.
        /// </summary>
        private void UpdateSubscriptions()
        {
            SubscriptionsLV.Items.Clear();

            IList<Subscription> subscriptions = m_server.CurrentInstance.SubscriptionManager.GetSubscriptions();

            for (int ii = 0; ii < subscriptions.Count; ii++)
            {
                Subscription subscription = subscriptions[ii];

                ListViewItem item = new ListViewItem(subscription.Id.ToString());

                item.SubItems.Add(String.Format("{0}", (int)subscription.PublishingInterval));
                item.SubItems.Add(String.Format("{0}", subscription.MonitoredItemCount));

                lock (subscription.DiagnosticsLock)
                {
                    item.SubItems.Add(String.Format("{0}", subscription.Diagnostics.NextSequenceNumber));
                }

                item.SubItems.Add( String.Format( "{0}", subscription.Priority ) );
                item.SubItems.Add( String.Format( "{0}", subscription.Diagnostics.SessionId ) );

                SubscriptionsLV.Items.Add(item);
            }

            for (int ii = 0; ii < SubscriptionsLV.Columns.Count; ii++)
            {
                SubscriptionsLV.Columns[ii].Width = -2;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// A callback used to periodically refresh the form contents.
        /// </summary>
        private void UpdateTimerCTRL_Tick(object sender, EventArgs e)
        {
            try
            {
                ServerStateLB.Text = m_server.CurrentInstance.CurrentState.ToString();
                ServerTimeStartLabel.Text = String.Format("{0:HH:mm:ss}", DateTime.Now);
                StartTimeValueLabel.Text = Utils.Format( "{0:HH:mm:ss.ff}", m_server.GetStatus().StartTime.ToLocalTime() );
                UpdateSessions();
                UpdateSubscriptions();
            }
            catch (Exception)
            {
                // MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
