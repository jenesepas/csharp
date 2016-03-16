using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FillPolygonSample
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
			this.ClientSize = new System.Drawing.Size(336, 273);
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
			Graphics g = e.Graphics ;
            // Create a solid brush
            SolidBrush greenBrush = 
                new SolidBrush(Color.Green);
            // Create points for polygon.
            PointF p1 = new PointF(40.0F, 50.0F);
            PointF p2 = new PointF(60.0F, 70.0F);
            PointF p3 = new PointF(80.0F, 34.0F);
            PointF p4 = new PointF(120.0F, 180.0F);
            PointF p5 = new PointF(200.0F, 150.0F);
            PointF[] ptsArray =
            {
                p1, p2, p3, p4, p5
            };
            // Draw polygon
            e.Graphics.FillPolygon(greenBrush, ptsArray);
            // Dispose
            greenBrush.Dispose();
		}
	}
}
