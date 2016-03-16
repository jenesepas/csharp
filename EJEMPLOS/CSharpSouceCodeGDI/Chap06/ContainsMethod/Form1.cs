using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ContainsMethod
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Rectangle bigRect = new Rectangle(50, 50, 100, 100); 

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
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 277);
			this.Name = "Form1";
			this.Text = "Form1";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

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

		private void Form1_MouseDown(object sender, 
			System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				if (bigRect.Contains( new Point(e.X, e.Y)) )
					MessageBox.Show("Clicked inside rectangle");
				else 
					MessageBox.Show("Clicked outside rectangle");		
			}
		}

		private void Form1_Paint(object sender,
			System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.FillRectangle(
				new SolidBrush(Color.Green),bigRect);
		}
	}
}
