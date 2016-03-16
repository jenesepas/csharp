using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace FirstGDI_App
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
			this.ClientSize = new System.Drawing.Size(456, 293);
			this.Name = "Form1";
			this.Text = "My First GDI+ Application";
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

		protected override void OnPaint(PaintEventArgs e)
		{
			// Obtain the Graphics object
			Graphics g = e.Graphics;
			// Set the composit quality and smooting mode
			// of the surface
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			// Create a rectangle from point (20, 20) to (100, 100)
			Rectangle rect = new Rectangle(20, 20, 100, 100);
			// Create two Pen objects with Red and Green color
			Pen redPen = new Pen(Color.Red, 3);
			Pen blackPen = Pens.Black;
			// Create a SolidBrush objects 
			SolidBrush greenBrush = new SolidBrush(Color.Green);
			// Draw shapes and lines
			g.DrawRectangle(redPen, rect);
			g.FillEllipse(greenBrush, rect);
			g.DrawLine(blackPen, 0, 250, this.Width, 250);
			g.FillEllipse(Brushes.Blue, 70, 220, 30, 30);
			g.FillEllipse(Brushes.SkyBlue, 100, 210, 40, 40);
			g.FillEllipse(Brushes.Green, 140, 200, 50, 50);
			g.FillEllipse(Brushes.Yellow, 190, 190, 60, 60);
			g.FillEllipse(Brushes.Violet, 250, 180, 70, 70);
			g.FillEllipse(Brushes.Red, 320, 170, 80, 80);
			// Dispose objects
			greenBrush.Dispose();
			// blackPen.Dispose();
			redPen.Dispose();
			g.Dispose();
		}

		private void Form1_Paint(object sender, 
			System.Windows.Forms.PaintEventArgs e)
		{
		
		}
	}
}


