using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CoordinateSystemProj
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
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(304, 273);
			this.Name = "Form1";
			this.Text = "GDI+ Coordinate System";
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

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.TranslateTransform(50, 40);

			Font vertFont = new Font("Verdana", 10, FontStyle.Regular);
			Font horzFont = new Font("Verdana", 10, FontStyle.Regular);
			SolidBrush blackBrush = new SolidBrush(Color.Black);
			Pen blackPen = new Pen(Color.Black, 1);
			Pen bluePen = new Pen(Color.Blue, 1);
					
			
			/* Page Coordinate ***** */
			//X axis drawing
			g.DrawString("200",horzFont,blackBrush,200,5);
			g.DrawString("100",horzFont,blackBrush, 100,5);
			g.DrawString("X",horzFont,blackBrush,250,0);
			// Drawing vertical strings
			StringFormat vertStrFormat = new StringFormat();
			vertStrFormat.FormatFlags = StringFormatFlags.DirectionVertical;						
			//Y axis drawing
			g.DrawString("100", vertFont,blackBrush, 0, 100);
			g.DrawString("200", vertFont,blackBrush, 0, 200);
			g.DrawString("Y",vertFont,blackBrush, 0, 250);
			// Drawing a vertical and a horizontal line
			g.DrawLine(blackPen, 0, 0, 0, 250);
			g.DrawLine(blackPen, 0, 0, 250, 0);
			
			Point A = new Point(0, 0);
			Point B = new Point(120, 80);
			g.DrawLine(Pens.Black, A, B);
			/***************************/

			/* Device Coordinate ****
			Pen redPen = new Pen(Color.Red, 1/g.DpiX);
			g.TranslateTransform(1, 0.5f);
			g.PageUnit = GraphicsUnit.Inch;
			g.DrawLine(redPen, 0, 0, 2, 1);
			/***************************/

			/*
			g.TranslateTransform(200, 40);
			Point A = new Point(0, 0);
			Point B = new Point(100, 20);
			g.FillRectangle(Brushes.Red, 10, 10, 100, 20); 
			g.RotateTransform(90.0f);
			g.FillRectangle(Brushes.Red, 10, 10, 100, 20); 
			*/


			
		}
	}
}
