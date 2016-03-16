/********************************************
 * Copyright Mahesh Chand, C# Corner, @2002 *
 * *****************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace CSCornerLogo
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
			this.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ClientSize = new System.Drawing.Size(472, 357);
			this.Name = "Form1";
			this.Text = "C# Corner Information Center";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// Create a pen and font
			Graphics g = e.Graphics;
			Pen blackPen = new Pen(Color.Black, 2);
			Font verdanaFont = new Font( "Verdana", 60, FontStyle.Bold);
			// Create points that define polygon.
			Point[] curvePoints1 = { new Point(200, 15), 
									   new Point(200, 200), new Point(375, 250) };
			Point[] curvePoints2 = { new Point(0, 250),	
					new Point(200, 200), new Point(375, 250) };
			Point[] curvePoints3 = { new Point(200, 15),	
					 new Point(200, 200), new Point(0, 250) };		
			// Create linear gradient brushes
			Point pt1 = new Point(10, 10);
			Point pt2 = new Point(30, 30);
			LinearGradientBrush lgBrush1 = 
				new LinearGradientBrush(pt1, pt2, Color.Red, Color.Blue);  
			LinearGradientBrush lgBrush2 = 
				new LinearGradientBrush(pt1, pt2, Color.Red, Color.Green);  
			LinearGradientBrush lgBrush3 = 
				new LinearGradientBrush(pt1, pt2, Color.Blue, Color.Green);  
			// If you want to draw three lines
			//e.Graphics.DrawLine(blackPen, 200, 55, 200, 200);
			//e.Graphics.DrawLine(blackPen, 50, 250, 200, 200);
			//e.Graphics.DrawLine(blackPen, 345, 260, 200, 200);			
			// Set quality of text and shape
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			// Draw three polygons and string
			e.Graphics.FillPolygon(new SolidBrush
				(Color.FromArgb(80, 255, 0, 0)), curvePoints1);
			e.Graphics.FillPolygon(new SolidBrush
				(Color.FromArgb(80, 0, 255, 0)), curvePoints2);
			e.Graphics.FillPolygon(new SolidBrush
				(Color.FromArgb(80, 0, 0, 255)), curvePoints3);
			// Draw C# using the DrawString method 
			// Starting @ point 140, 150
			g.DrawString("C#", verdanaFont, lgBrush1, new PointF(140,150) );
			// Dispose Graphocs
			g.Dispose();
		}
	}
}
