namespace CAS.UA.Server
{
  partial class ServiceInstaller
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
      this.CodeProtect_LibInstaller = new CAS.Lib.CodeProtect.LibInstaller();
      // 
      // ServiceInstaller
      // 
      this.Installers.AddRange( new System.Configuration.Install.Installer[] {
            this.CodeProtect_LibInstaller} );

    }

    #endregion

    private CAS.Lib.CodeProtect.LibInstaller CodeProtect_LibInstaller;
  }
}