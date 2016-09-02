namespace WindowsForms_CommServer
{
  partial class LaunchTest_Form
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.button_start = new System.Windows.Forms.Button();
      this.button_get_info = new System.Windows.Forms.Button();
      this.richTextBox_output = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // button_start
      // 
      this.button_start.Location = new System.Drawing.Point( 12, 12 );
      this.button_start.Name = "button_start";
      this.button_start.Size = new System.Drawing.Size( 75, 23 );
      this.button_start.TabIndex = 0;
      this.button_start.Text = "Start";
      this.button_start.UseVisualStyleBackColor = true;
      this.button_start.Click += new System.EventHandler( this.button_start_Click );
      // 
      // button_get_info
      // 
      this.button_get_info.Location = new System.Drawing.Point( 12, 41 );
      this.button_get_info.Name = "button_get_info";
      this.button_get_info.Size = new System.Drawing.Size( 75, 23 );
      this.button_get_info.TabIndex = 1;
      this.button_get_info.Text = "Get Info";
      this.button_get_info.UseVisualStyleBackColor = true;
      this.button_get_info.Click += new System.EventHandler( this.button_get_info_Click );
      // 
      // richTextBox_output
      // 
      this.richTextBox_output.Location = new System.Drawing.Point( 93, 12 );
      this.richTextBox_output.Name = "richTextBox_output";
      this.richTextBox_output.ReadOnly = true;
      this.richTextBox_output.Size = new System.Drawing.Size( 499, 242 );
      this.richTextBox_output.TabIndex = 3;
      this.richTextBox_output.Text = "";
      // 
      // LaunchTest_Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size( 604, 266 );
      this.Controls.Add( this.richTextBox_output );
      this.Controls.Add( this.button_get_info );
      this.Controls.Add( this.button_start );
      this.Name = "LaunchTest_Form";
      this.Text = "LaunchTest_Form";
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.Button button_start;
    private System.Windows.Forms.Button button_get_info;
    private System.Windows.Forms.RichTextBox richTextBox_output;
  }
}

