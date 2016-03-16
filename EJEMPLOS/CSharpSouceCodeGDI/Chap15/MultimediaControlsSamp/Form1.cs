using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MultimediaControlsSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private AxMCI.AxMMControl axMMControl1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.axMMControl1 = new AxMCI.AxMMControl();
			((System.ComponentModel.ISupportInitialize)(this.axMMControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// axMMControl1
			// 
			this.axMMControl1.Enabled = true;
			this.axMMControl1.Location = new System.Drawing.Point(8, 8);
			this.axMMControl1.Name = "axMMControl1";
			this.axMMControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMMControl1.OcxState")));
			this.axMMControl1.Size = new System.Drawing.Size(236, 23);
			this.axMMControl1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 365);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.axMMControl1});
			this.Name = "Form1";
			this.Text = "Using Multimedia Controls in .NET";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.axMMControl1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			axMMControl1.FileName = "clock.avi";
			axMMControl1.Command = "Play";


		}
	}
}
