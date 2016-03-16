using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
namespace FillClosedCurve
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
			this.ClientSize = new System.Drawing.Size(336, 277);
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
		  // Create an array of points
      PointF pt1 = new PointF( 40.0F,  50.0F);
      PointF pt2 = new PointF(50.0F,  75.0F);
      PointF pt3 = new PointF(100.0F,  115.0F);
      PointF pt4 = new PointF(200.0F,  180.0F);
      PointF pt5 = new PointF(200.0F, 90.0F);
      PointF[] ptsArray =
      {
        pt1, pt2, pt3, pt4, pt5
      };  
      // Fill a closed curve
      float tension = 1.0F;
      FillMode flMode = FillMode.Alternate;
      SolidBrush blueBrush = new SolidBrush(Color.Blue);
      e.Graphics.FillClosedCurve(blueBrush, ptsArray, 
        flMode, tension);
      // Dispose
      blueBrush.Dispose();
		}
	}
}


