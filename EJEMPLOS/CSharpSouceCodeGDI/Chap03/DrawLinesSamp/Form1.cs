using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DrawLinesSamp
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
			this.ClientSize = new System.Drawing.Size(292, 273);
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
      // Creating four Pen objects with red,
      // blue, green and black colors and 
      // different width
      Pen redPen = new Pen(Color.Red, 1);
      Pen bluePen = new Pen(Color.Blue, 2);
      Pen greenPen = new Pen(Color.Green, 3);
      Pen blackPen = new Pen(Color.Black, 4);
      // Draw line using float coordinates 
     float x1 = 20.0F, y1 = 20.0F;
            float x2 = 200.0F, y2 = 20.0F;
      e.Graphics.DrawLine(redPen, x1, y1, x2, y2);    
      // Draw line using Point structure
      Point pt1 = new Point(20, 20);
      Point pt2 = new Point(20, 200);
      e.Graphics.DrawLine(greenPen, pt1, pt2);
      // Draw line using PointF structure
      PointF ptf1 = new PointF(20.0F, 20.0F);
      PointF ptf2 = new PointF(200.0F, 200.0F);
      e.Graphics.DrawLine(bluePen, ptf1, ptf2);
      // Draw line using integer coordinates
      int X1 = 60, Y1 = 40, X2 = 250, Y2 = 100;
      e.Graphics.DrawLine(blackPen, X1, Y1, X2, Y2);

      /*
			 * PointF[] ptsArray =
      {
        new PointF( 20.0F, 20.0F),
        new PointF( 20.0F, 200.0F),
        new PointF(200.0F, 200.0F),
        new PointF(20.0F, 20.0F)      
   
      };
      e.Graphics.DrawLines(redPen, ptsArray);
			*/			
		  // Dispose
      redPen.Dispose();
      bluePen.Dispose(); 
      greenPen.Dispose();
      blackPen.Dispose(); 
    }
	}
}
