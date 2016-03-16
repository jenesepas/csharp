using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace VarialbleScopeSamp
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
			this.ClientSize = new System.Drawing.Size(448, 341);
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
			// Create brushes and pens
			HatchBrush hatchBrush = 
				new HatchBrush(HatchStyle.HorizontalBrick,
				Color.Red, Color.Blue);
			Pen redPen = new Pen(Color.Red, 2);
			Pen hatchPen = new Pen(hatchBrush, 4);
			SolidBrush brush = new SolidBrush(Color.Green);
			// Create points for curve.
			PointF p1 = new PointF(40.0F, 50.0F);
			PointF p2 = new PointF(60.0F, 70.0F);
			PointF p3 = new PointF(80.0F, 34.0F);
			PointF p4 = new PointF(120.0F, 180.0F);
			PointF p5 = new PointF(200.0F, 150.0F);
			PointF[] ptsArray ={ p1, p2, p3, p4, p5 };

			float x = 5.0F, y = 5.0F;
			float width = this.ClientRectangle.Width - 100;
			float height = this.ClientRectangle.Height - 100;

			Point pt1 = new Point(40, 30);
			Point pt2 = new Point(80, 100);
			Color [] lnColors = {Color.Black, Color.Red};
			LinearGradientBrush lgBrush = 
				new LinearGradientBrush
				(pt1, pt2, Color.Red, Color.Green);  
			lgBrush.LinearColors = lnColors;
			lgBrush.GammaCorrection = true;
            		
			// Draw objects
			e.Graphics.DrawPolygon(redPen, ptsArray);
			e.Graphics.DrawRectangle(hatchPen, 
				x, y, width, height);			
			e.Graphics.FillRectangle(lgBrush, 
				200, 200, 200, 200);	

			// Dispose
			lgBrush.Dispose();
			brush.Dispose();
			hatchPen.Dispose();
			redPen.Dispose();
			hatchBrush.Dispose();

		}
	}
}


