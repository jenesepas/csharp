using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ButtonViewer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Panel panel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
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
			this.btnClose = new System.Windows.Forms.Button();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(8, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(96, 8);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 128);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(352, 232);
			this.button1.TabIndex = 2;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(168, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(224, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(136, 112);
			this.panel1.TabIndex = 4;
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(376, 365);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.textBox1,
																		  this.button1,
																		  this.btnBrowse,
																		  this.btnClose});
			this.Name = "Form2";
			this.Text = "ButtonViewer";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form2());
		}

    private void btnClose_Click(object sender,
		System.EventArgs e)
    {
      this.Close();
    }

    private void btnBrowse_Click(object sender,
        System.EventArgs e)
    {
	
      OpenFileDialog fdlg = new OpenFileDialog(); 
      fdlg.Title = "C# Corner Open File Dialog" ; 
      fdlg.InitialDirectory = @"c:\" ; 
      fdlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|" +
		  "*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
 
      fdlg.FilterIndex = 2 ; 
      fdlg.RestoreDirectory = true ; 
      if(fdlg.ShowDialog() == DialogResult.OK) 
      { 
        button1.BackgroundImage = 
            Image.FromFile(fdlg.FileName) ; 
        textBox1.Text = fdlg.FileName;
      } 
      Invalidate();
    }

	private void Form2_Load(object sender, System.EventArgs e)
	{
		// Button 1
		button1.ForeColor = Color.Yellow; 
		button1.BackColor = Color.Maroon; 
		button1.FlatStyle = FlatStyle.Flat; 
		button1.Font = new Font ("Verdana", 
			10, FontStyle.Bold); 
		// Close and Browse buttons
		btnClose.ForeColor = Color.Yellow; 
		btnClose.BackColor = Color.Black; 
		btnClose.FlatStyle = FlatStyle.Flat; 
		btnClose.Font = new Font ("Ariel", 
			10, FontStyle.Italic); 
		btnBrowse.ForeColor = Color.White; 
		btnBrowse.BackColor = Color.Black; 
		btnBrowse.FlatStyle = FlatStyle.Flat; 
		btnBrowse.Font = new Font ("Ariel", 
			10, FontStyle.Bold); 
			// Text Box 1
		textBox1.BorderStyle = BorderStyle.FixedSingle;
		textBox1.BackColor = Color.Blue;
		textBox1.ForeColor = Color.Yellow;
		textBox1.Font = new Font("Tahoma", 10,
			FontStyle.Strikeout|FontStyle.Bold|
			FontStyle.Italic);
		// Panel 1
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.BackColor = Color.Red;
		/* Code for transparent controls */
		this.SetStyle(
			ControlStyles.SupportsTransparentBackColor, 
			true);
		button1.BackColor = Color.Transparent;
		btnBrowse.BackColor = Color.Transparent; 
		btnClose.BackColor = Color.Transparent;
		panel1.BackColor = Color.FromArgb(70, 0, 0, 255);
	}
	}
}

