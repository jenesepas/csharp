using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace GraphicsPathIteratorSamp
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
			this.ClientSize = new System.Drawing.Size(304, 273);
			this.Name = "Form1";
			this.Text = "GraphicsPathIterator Sample";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphicsPathIterator_Paint);

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

		private void GraphicsPathIterator_Paint(object sender,
			System.Windows.Forms.PaintEventArgs e)
		{

			// Get the Graphics object
			Graphics g = e.Graphics;
			// Create a Rectangle
			Rectangle rect = new Rectangle(50, 50, 100, 50);
            // Create a Graphics path
            GraphicsPath path = new  GraphicsPath();
            PointF[] ptsArray = { new PointF(20, 20),
                               new PointF(60, 12),
                               new PointF(100, 20)};
            // Add a curve, rectangle, ellipse, and a line
            path.AddCurve(ptsArray);
            path.AddRectangle(rect);
            rect.Y += 60;
            path.AddEllipse(rect);
            path.AddLine(120, 50, 220, 100); 
            // Draw path
            g.DrawPath(Pens.Blue, path);
            // Create a Graphics path iterator
            GraphicsPathIterator pathIterator = 
                new GraphicsPathIterator(path);
            // Display total points and sub paths
            string str = "Total points = " 
                + pathIterator.Count.ToString();
            str += ", Sub paths = " 
                + pathIterator.SubpathCount.ToString();
            MessageBox.Show(str);           
            // rewind
            pathIterator.Rewind();
            // Read all subpaths and their properties
            for(int i=0; i<pathIterator.SubpathCount; i++)
            {
                int strtIdx, endIdx; 
                bool bClosedCurve; 
                pathIterator.NextSubpath(out strtIdx, 
                    out endIdx, out bClosedCurve);
                str = "Start Index = " + strtIdx.ToString()
                    + ", End Index = " + endIdx.ToString() 
                    + ", IsClosed = " + bClosedCurve.ToString();
                MessageBox.Show(str);
            }
		}
	}
}


