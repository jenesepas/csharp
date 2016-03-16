using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BrushTransformationSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem TextureBrush;
		private System.Windows.Forms.MenuItem LinearGradientBrush;
		private System.Windows.Forms.MenuItem PathGradientBrush;
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.TextureBrush = new System.Windows.Forms.MenuItem();
			this.LinearGradientBrush = new System.Windows.Forms.MenuItem();
			this.PathGradientBrush = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.TextureBrush,
																					  this.LinearGradientBrush,
																					  this.PathGradientBrush});
			this.menuItem1.Text = "Brush Transformation";
			// 
			// TextureBrush
			// 
			this.TextureBrush.Index = 0;
			this.TextureBrush.Text = "TextureBrush";
			this.TextureBrush.Click += new System.EventHandler(this.TextureBrush_Click);
			// 
			// LinearGradientBrush
			// 
			this.LinearGradientBrush.Index = 1;
			this.LinearGradientBrush.Text = "LinearGradientBrush";
			this.LinearGradientBrush.Click += new System.EventHandler(this.LinearGradientBrush_Click);
			// 
			// PathGradientBrush
			// 
			this.PathGradientBrush.Index = 2;
			this.PathGradientBrush.Text = "PathGradientBrush";
			this.PathGradientBrush.Click += new System.EventHandler(this.PathGradientBrush_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 321);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";

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

		private void TextureBrush_Click(object sender,
      System.EventArgs e)
    {
      Graphics g = this.CreateGraphics();
      g.Clear(this.BackColor);
      // Create a TextureBrush object
      TextureBrush txtrBrush = new TextureBrush(
        new Bitmap("smallRoses.gif"));
      // Create a transformation matrix.
      Matrix M = new Matrix();
      // Rotate the texture image by 90 degrees.
      txtrBrush.RotateTransform(90, 
        MatrixOrder.Prepend);
      // Translate
      M.Translate(50, 0);
      // Multiply the transformation matrix
      // of tBrush by translateMatrix.
      txtrBrush.MultiplyTransform(M);
      // Scale operation
      txtrBrush.ScaleTransform(2, 1, 
        MatrixOrder.Prepend);
      // Fill a rectangle with texture brush
      g.FillRectangle(txtrBrush, 240, 0, 200, 200);
      // Reset transformation
      txtrBrush.ResetTransform();
      // Fill rectangle after reseting transformation
      g.FillRectangle(txtrBrush, 0, 0, 200, 200);
      // Dispose
      txtrBrush.Dispose();
      g.Dispose();
    }

		private void LinearGradientBrush_Click(object sender,
            System.EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create a LinearGradientBrush object
            Rectangle rect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush lgBrush = 
                new LinearGradientBrush(
                rect, Color.Red, Color.Green, 0.0f, true);
            Point[] ptsArray = {new Point(20, 50), 
                new Point(200,50), new Point(20, 100)};
            Matrix M = new Matrix(rect, ptsArray);
            // Multiply transform
            lgBrush.MultiplyTransform(M, MatrixOrder.Prepend);
            // Rotate transform
            lgBrush.RotateTransform(45.0f, MatrixOrder.Prepend);
            // Scale Transform
            lgBrush.ScaleTransform(2, 1, MatrixOrder.Prepend);
            // Draw a rectangle after transformation
            g.FillRectangle(lgBrush, 0, 0, 200, 100);
            // Reset transform.
            lgBrush.ResetTransform();
            // Draw a rectangle after Reset transform
            g.FillRectangle(lgBrush, 220, 0, 200, 100);     
            // Dispose
            lgBrush.Dispose();
            g.Dispose();        
        }

		private void PathGradientBrush_Click(object sender, 
            System.EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create a GraphicsPath object
            GraphicsPath path = new GraphicsPath();
            // Create a rectangle and add it to path
            Rectangle rect = new Rectangle(20, 20, 200, 200);
            path.AddRectangle(rect);            
            // Create a path gradient brush
            PathGradientBrush pgBrush = 
                new PathGradientBrush(path.PathPoints);
            // Set its center and surrounding colors
            pgBrush.CenterColor = Color.Green;
            pgBrush.SurroundColors = new Color[] {Color.Blue};
            // Create matrix
            Matrix M = new Matrix();
            // Translate
            M.Translate(20.0f, 10.0f, MatrixOrder.Prepend);
            // Rotate
            M.Rotate(10.0f, MatrixOrder.Prepend);
            // Scale
            M.Scale(2, 1, MatrixOrder.Prepend);
            // shear
            M.Shear(.05f, 0.03f, MatrixOrder.Prepend);
            // Apply matrix to the brush
            pgBrush.MultiplyTransform(M);
            // Use brush after transformation
            // to fill a rectangle
            g.FillRectangle(pgBrush, 20, 100, 400, 400);
            // Dispose
            pgBrush.Dispose();
            g.Dispose();
        }
	}
}
