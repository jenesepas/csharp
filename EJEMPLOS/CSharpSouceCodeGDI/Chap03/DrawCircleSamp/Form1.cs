using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DrawCircleSamp
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
      Graphics g = e.Graphics ; 
      // Create pens
      Pen redPen = new Pen(Color.Red, 6 ); 
      Pen bluePen = new Pen(Color.Blue, 4 ); 
      Pen greenPen = new Pen(Color.Green, 2);
      // Create a rectangle
      Rectangle rect = 
        new Rectangle(80, 80, 50, 50); 
      // Draw ellipses
      g.DrawEllipse(greenPen, 
        100.0F, 90.0F, 10.0F, 30.0F ); 
      g.DrawEllipse(redPen, rect );       
      g.DrawEllipse(bluePen, 60, 60, 90, 90);   
      g.DrawEllipse(greenPen, 
        40.0F, 40.0F, 130.0F, 130.0F );   
      // Dispose
      redPen.Dispose();
      greenPen.Dispose();
      bluePen.Dispose();
    }
	}
}
