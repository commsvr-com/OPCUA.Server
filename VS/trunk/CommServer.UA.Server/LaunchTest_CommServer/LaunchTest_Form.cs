//<summary>
//  Title   : LaunchTest CommServer Form
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
using System.Windows.Forms;
using Opc.Da;

namespace WindowsForms_CommServer
{
  public partial class LaunchTest_Form: Form
  {
    private CAS.OpcSvr.Da.NETServer.Server m_server = null;

    public LaunchTest_Form()
    {
      InitializeComponent();
      try
      {
        CAS.Lib.CodeProtect.LibInstaller.InstalLicense(true);
      }
      catch { }
    }

    private void button_start_Click( object sender, EventArgs e )
    {
      if ( m_server == null )
      {
        try
        {
          m_server = new CAS.OpcSvr.Da.NETServer.Server( true );
          button_start.Text = "Stop";
        }
        catch ( Exception ex )
        {
          MessageBox.Show( this,
            "Cannot start a new instance of CAS.OpcSvr.Da.NETServer.Server created because of internal error: " + ex.Message + ex.StackTrace.ToString() );
        }
      }
      else
      {
        throw new NotImplementedException();
      }
    }

    private void button_get_info_Click( object sender, EventArgs e )
    {
      if ( m_server == null )
      {
        MessageBox.Show( this,
           "please start the server first" );
      }
      ServerStatus status=m_server.GetStatus();

      richTextBox_output.Text = status.VendorInfo.ToString()+","+status.StatusInfo.ToString()+"\r\n";
      foreach ( BaseStation.Management.Statistics.StationStatistics obj in BaseStation.Management.Statistics.stationList )
      {
        richTextBox_output.Text += "Station:" + obj.myName + " state:" + obj.StationState.ToString() + "\r\n";
      }
      foreach ( BaseStation.Management.Statistics.SegmentStatistics obj in BaseStation.Management.Statistics.segmentList )
      {
        richTextBox_output.Text += "Segment:" + obj.myName + " connectTime:" + obj.ConnectTime.ToString() + "\r\n";
      }
    }
  }
}
