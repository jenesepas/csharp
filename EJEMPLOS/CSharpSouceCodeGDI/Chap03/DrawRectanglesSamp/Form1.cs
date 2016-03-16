using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DrawRectanglesSamp
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
      // Create pens & points
      Pen redPen = new Pen(Color.Red, 1);
      Pen bluePen = new Pen(Color.Blue, 2);
      Pen greenPen = new Pen(Color.Green, 3);
      float x = 5.0F, y = 5.0F;
      float width = 100.0F;
      float height = 200.0F;
      // Create a rectangle
      Rectangle rect = new Rectangle(20,20, 80, 40);
      // Draw rectangles
     /* e.Graphics.DrawRectangle(bluePen,
        x, y, width, height);
      e.Graphics.DrawRectangle(redPen, 
        60, 80, 140, 50);
      e.Graphics.DrawRectangle(greenPen, rect);
			*/

      RectangleF[] rectArray =
      {
        new RectangleF( 5.0F, 5.0F, 100.0F, 200.0F),
        new RectangleF(20.0F, 20.0F, 80.0F, 40.0F),
        new RectangleF(60.0F, 80.0F, 140.0F, 50.0F)
      };
      // Draw rectangles to screen.
      e.Graphics.DrawRectangles(greenPen, rectArray);

      // Dispose
      redPen.Dispose(); 
      bluePen.Dispose(); 
      greenPen.Dispose(); 
    }
	}
}
