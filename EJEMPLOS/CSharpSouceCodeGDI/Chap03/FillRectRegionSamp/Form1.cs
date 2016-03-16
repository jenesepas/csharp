using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace FillRectRegionSamp
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
			this.ClientSize = new System.Drawing.Size(408, 333);
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
      // Create brushes
      SolidBrush blueBrush = new SolidBrush(Color.Blue);
      SolidBrush redBrush = new SolidBrush(Color.Red);
      // Create a rectangle
      Rectangle rect = new Rectangle(10, 20, 100, 50);      
      // Fill rectangle
      e.Graphics.FillRectangle(new HatchBrush
        (HatchStyle.BackwardDiagonal,
        Color.Yellow, Color.Black),
        rect);  
      e.Graphics.FillRectangle(blueBrush, 
        new Rectangle(150, 20, 50, 100)); 
    //  e.Graphics.FillRectangles(redBrush, rectArray);
      // Dispose
      blueBrush.Dispose();
      redBrush.Dispose();
    }
	}
}
