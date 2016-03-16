using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace GraphicsPathSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem CreateMenu;
		private System.Windows.Forms.MenuItem DrawPathMenu;
		private System.Windows.Forms.MenuItem SubPathMenu;
		private System.Windows.Forms.MenuItem GpSample;
		private System.Windows.Forms.MenuItem Properties;
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
			this.GpSample = new System.Windows.Forms.MenuItem();
			this.CreateMenu = new System.Windows.Forms.MenuItem();
			this.DrawPathMenu = new System.Windows.Forms.MenuItem();
			this.SubPathMenu = new System.Windows.Forms.MenuItem();
			this.Properties = new System.Windows.Forms.MenuItem();
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
																					  this.GpSample,
																					  this.CreateMenu,
																					  this.Properties,
																					  this.DrawPathMenu,
																					  this.SubPathMenu});
			this.menuItem1.Text = "Graphics Path";
			// 
			// GpSample
			// 
			this.GpSample.Index = 0;
			this.GpSample.Text = "GraphicsPath Sample";
			this.GpSample.Click += new System.EventHandler(this.GpSample_Click);
			// 
			// CreateMenu
			// 
			this.CreateMenu.Index = 1;
			this.CreateMenu.Text = "Create";
			this.CreateMenu.Click += new System.EventHandler(this.CreateMenu_Click);
			// 
			// DrawPathMenu
			// 
			this.DrawPathMenu.Index = 3;
			this.DrawPathMenu.Text = "Draw GraphicsPath";
			this.DrawPathMenu.Click += new System.EventHandler(this.DrawPathMenu_Click);
			// 
			// SubPathMenu
			// 
			this.SubPathMenu.Index = 4;
			this.SubPathMenu.Text = "Sub Paths";
			this.SubPathMenu.Click += new System.EventHandler(this.SubPathMenu_Click);
			// 
			// Properties
			// 
			this.Properties.Index = 2;
			this.Properties.Text = "Properties";
			this.Properties.Click += new System.EventHandler(this.Properties_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 365);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Graphics Path Sample";

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

		private void CreateMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);

			Pen greenPen = new Pen(Brushes.Green, 3);
			GraphicsPath path = new GraphicsPath();
			Rectangle rect = new Rectangle(20, 20, 200, 100);
			path.AddLine(20, 30, 150, 70);
			path.AddArc(10, 10, 100, 50, 0, 180);		
			path.AddRectangle(rect);
			g.DrawPath(greenPen, path);
			// Getting GraphicsPath properties
			FillMode fMode = path.FillMode;
			PathData data = path.PathData;
			PointF [] pts = path.PathPoints;
			byte [] ptsTypes = path.PathTypes;
			int count = path.PointCount;		

			// Dispose
			g.Dispose();
		}

		private void DrawPathMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);

            Pen redPen = new Pen(Brushes.Red, 3);
			Rectangle rect = new Rectangle(70, 15, 50, 50);  			
			GraphicsPath path = new GraphicsPath();
			path.AddArc(20, 150, 200, 100, 0, 180);
			path.AddLine(20, 40, 220, 190);
			path.AddLine(20, 220, 320, 20);
			path.AddRectangle(rect);
			path.AddEllipse(250, 200, 50, 50);
			g.DrawPath(redPen, path);

			// Dispose
			g.Dispose();
		}

		private void SubPathMenu_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a GraphicsPath
			GraphicsPath path = new GraphicsPath();
			// Create an array of points 
			Point[] pts = 
			{
				new Point(40, 80),
				new Point(50, 70), 
				new Point(70, 90),
				new Point(100, 120),
				new Point(80, 120) 
            };
			// Start first figure and add an 
			// arc and a line
			path.StartFigure(); 
			path.AddArc(250, 80, 100, 50, 30, -180);
			path.AddLine(180, 220, 320, 80);
			// Close first figure
			path.CloseFigure();
			// Start second figure and two lines 
			// and a curve and close all figures
			path.StartFigure(); 
			path.AddLine(50, 20, 5, 90);
			path.AddLine(50, 150, 150, 180);
			path.AddCurve(pts, 5);
			path.CloseAllFigures();
			// Create third graphics and don't close
			// it
			path.StartFigure(); 
			path.AddLine(200, 230, 250, 200);
			path.AddLine(200, 230, 250, 270);
			// Draw path
			g.DrawPath(new Pen(Color.FromArgb(255, 255, 0, 0), 2)
				, path);
			//path.Reverse();
			//path.Reset();
			// Dispose
			g.Dispose();
		}

		private void Sample_Click(object sender, 
			System.EventArgs e)
		{
			
		}

		private void GpSample_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			// Create a Graphics path
			GraphicsPath path = new GraphicsPath();
			// Add two lines, a rectangle, and 
			// an ellipse
			path.AddLine(20, 20, 200, 20);
			path.AddLine(20, 20, 20, 200);
			path.AddRectangle(new Rectangle(30, 30, 100, 100));
			path.AddEllipse( new Rectangle(50, 50, 60, 60));
			// Draw path
			Pen redPen = new Pen(Color.Red, 2);
			g.DrawPath(redPen, path);
			g.FillPath(new SolidBrush(Color.Black), path);
			// Dispose
			redPen.Dispose();
			g.Dispose();		
		}

		private void Properties_Click(object sender, System.EventArgs e)
		{
			
		}
	}
}



