using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace DrawPathSample
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
			this.ClientSize = new System.Drawing.Size(384, 293);
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
			// Create a pen
			Pen greenPen = new Pen(Color.Green, 1);
			// Create a Graphics path
			GraphicsPath path = new GraphicsPath();
			// Add a line to the path
			path.AddLine(20, 20, 103, 80);
			// Add an ellipse to the path
			path.AddEllipse(100, 50, 100, 100);
			// Add three more lines
			path.AddLine(195, 80, 300, 80);
			path.AddLine(200, 100, 300, 100);
			path.AddLine(195, 120, 300, 120);

			// Create a rectangle and call 
			// AddRectangle
			Rectangle rect = 
				new Rectangle(50, 150, 300, 50);
			path.AddRectangle(rect);
			// Draw path
			e.Graphics.DrawPath(greenPen, path);
			// Dispose
			greenPen.Dispose();
		}
	}
}



