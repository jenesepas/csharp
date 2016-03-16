using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GlobalLocalTransSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem GlobalTransformation;
		private System.Windows.Forms.MenuItem LocalTransformation;
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
			this.GlobalTransformation = new System.Windows.Forms.MenuItem();
			this.LocalTransformation = new System.Windows.Forms.MenuItem();
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
																					  this.GlobalTransformation,
																					  this.LocalTransformation});
			this.menuItem1.Text = "Transformation Types";
			// 
			// GlobalTransformation
			// 
			this.GlobalTransformation.Index = 0;
			this.GlobalTransformation.Text = "Global";
			this.GlobalTransformation.Click += new System.EventHandler(this.GlobalTransformation_Click);
			// 
			// LocalTransformation
			// 
			this.LocalTransformation.Index = 1;
			this.LocalTransformation.Text = "Local";
			this.LocalTransformation.Click += new System.EventHandler(this.LocalTransformation_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 277);
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

		private void LocalTransformation_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a GraphicsPath 
			GraphicsPath path = new GraphicsPath();
			// Add an ellipse and a line to the 
			// graphics path
			path.AddEllipse(50, 50, 100, 150);	
			path.AddLine(20, 20, 200, 20);
			// Create a pen with blue color and 
			// width 2
			Pen bluePen = new Pen(Color.Blue, 2);
			// Create a Matrix object
			Matrix X = new Matrix();
			// Rotate with 30 degrees
			X.Rotate(30);
			// Translate with 50 offset in x dir
			X.Translate(50.0f, 0);
			// Apply transformation on the path
			path.Transform(X);
			// Draw a rentalgle, line and the path
			g.DrawRectangle(Pens.Green, 200, 50, 100, 100);
			g.DrawLine(Pens.Green, 30, 20, 200, 20);
			g.DrawPath(bluePen, path);
			// Dispose
			bluePen.Dispose();
			path.Dispose();
			g.Dispose();
			
		}

		private void GlobalTransformation_Click(object sender,
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a pen with blue color and width 2
			Pen bluePen = new Pen(Color.Blue, 2);
			Point pt1 = new Point(10, 10);
			Point pt2 = new Point(20, 20);
			Color [] lnColors = {Color.Black, Color.Red};
			Rectangle rect1 = new Rectangle(10, 10, 15, 15);
			// Create two linear gradient brushes
			LinearGradientBrush lgBrush1 = new LinearGradientBrush
				(rect1, Color.Blue, Color.Green,
				LinearGradientMode.BackwardDiagonal);  
			LinearGradientBrush lgBrush = new LinearGradientBrush
				(pt1, pt2, Color.Red, Color.Green);  
			// Set linear colors
			lgBrush.LinearColors = lnColors;
			// Set gamma correction
			lgBrush.GammaCorrection = true;
			// Fill and draw rectangle and ellipses
			g.FillRectangle(lgBrush, 150, 0, 50, 100);	
			g.DrawEllipse(bluePen, 0, 0, 100, 50);
			g.FillEllipse(lgBrush1, 300, 0, 100, 100);
			// Scale transformation
			g.ScaleTransform(1, 0.5f);
			// Translate transformation
			g.TranslateTransform(50, 0, MatrixOrder.Append);
			//Rotate
			g.RotateTransform(30.0f, MatrixOrder.Append);
			// Fill ellipse
			g.FillEllipse(lgBrush1, 300, 0, 100, 100);
			// Rotate again
			g.RotateTransform(15.0f, MatrixOrder.Append);
			// Fill rectangle
			g.FillRectangle(lgBrush, 150, 0, 50, 100);	
			// Rotate again
			g.RotateTransform(15.0f, MatrixOrder.Append);
			// Draw ellipse
			g.DrawEllipse(bluePen, 0, 0, 100, 50);	
			// Dispose
			lgBrush1.Dispose();
			lgBrush.Dispose();
			bluePen.Dispose();
			g.Dispose();
		}
	}
}

