using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TransparentImagesSamp
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
			this.ClientSize = new System.Drawing.Size(456, 317);
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void Form1_Paint(object sender, 
			System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			// Create an Image from a file
			Image curImage = Image.FromFile("myphoto.jpg");
			// Draw image
			g.DrawImage(curImage, 0, 0, 
				curImage.Width, curImage.Height);
			// Create pens with different opacity
			Pen opqPen = 
				new Pen(Color.FromArgb(255, 0, 255, 0), 10);
			Pen transPen = 
				new Pen(Color.FromArgb(128, 0, 255, 0), 10);
			Pen totTransPen = 
				new Pen(Color.FromArgb(40, 0, 255, 0), 10);
			// Draw graphics object using transparent pens
			g.DrawLine(opqPen, 10, 10, 200, 10);
			g.DrawLine(transPen, 10, 30, 200, 30);
			g.DrawLine(totTransPen, 10, 50, 200, 50);
			SolidBrush semiTransBrush = 
				new SolidBrush(Color.FromArgb(60, 0, 255, 0));
			g.FillRectangle(semiTransBrush, 20, 100, 200, 100);
		}
	}
}








