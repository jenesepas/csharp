using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RectangleSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem RectCreate;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem RectFCreate;
		private System.Windows.Forms.MenuItem RectProperties;
		private System.Windows.Forms.MenuItem RectMethods;
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
			this.RectCreate = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.RectFCreate = new System.Windows.Forms.MenuItem();
			this.RectProperties = new System.Windows.Forms.MenuItem();
			this.RectMethods = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuItem1,
																																							this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.RectCreate,
																																							this.RectProperties,
																																							this.RectMethods});
			this.menuItem1.Text = "Rectangle";
			// 
			// RectCreate
			// 
			this.RectCreate.Index = 0;
			this.RectCreate.Text = "Create";
			this.RectCreate.Click += new System.EventHandler(this.RectCreate_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.RectFCreate});
			this.menuItem3.Text = "RectangleF";
			// 
			// RectFCreate
			// 
			this.RectFCreate.Index = 0;
			this.RectFCreate.Text = "Create";
			this.RectFCreate.Click += new System.EventHandler(this.RectFCreate_Click);
			// 
			// RectProperties
			// 
			this.RectProperties.Index = 1;
			this.RectProperties.Text = "Properties";
			this.RectProperties.Click += new System.EventHandler(this.RectProperties_Click);
			// 
			// RectMethods
			// 
			this.RectMethods.Index = 2;
			this.RectMethods.Text = "Methods";
			this.RectMethods.Click += new System.EventHandler(this.RectMethods_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
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

		private void RectCreate_Click(object sender, System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			int x = 40;
			int y = 40;
			int height = 120;
			int width = 120;
			// Create a Point
			Point pt = new Point(80, 80);
			// Create a Size
			Size sz = new Size(100, 100);
			// Create a Rectangle from Point and Size
			Rectangle rect1 = new Rectangle(pt, sz);
			// Create a Rectangel from integers
			Rectangle rect2 = 
				new Rectangle(x, y, width, height);
			// Create a Rectangle from direct integers
			Rectangle rect3 = 
				new Rectangle(10, 10, 180, 180);
			// Create pens and brushes
			Pen redPen = new Pen(Color.Red, 2);
			SolidBrush greenBrush = 
				new SolidBrush(Color.Blue);
			SolidBrush blueBrush = 
				new SolidBrush(Color.Green);
			// Draw and fill rectangles
			g.DrawRectangle(redPen, rect3);
			g.FillRectangle(blueBrush, rect2);
			g.FillRectangle(greenBrush, rect1);
			// Dispose
			redPen.Dispose();
			blueBrush.Dispose();
			greenBrush.Dispose();
			g.Dispose();
		}

		private void RectFCreate_Click(object sender, System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			float x = 40.0f;
			float y = 40.0f;
			float height = 120.0f;
			float width = 120.0f;
			// Create a Point
			PointF pt = new PointF(80.0f, 80.0f);
			// Create a Size
			SizeF sz = new SizeF(100.0f, 100.0f);
			// Create a Rectangle from Point and Size
			RectangleF rect1 = new RectangleF(pt, sz);
			// Create a Rectangel from integers
			RectangleF rect2 = 
				new RectangleF(x, y, width, height);
			// Create a Rectangle from direct integers
			RectangleF rect3 = 
				new RectangleF(10.0f, 10.0f, 180.0f, 180.0f);
			// Create pens and brushes
			Pen redPen = new Pen(Color.Red, 2);
			SolidBrush greenBrush = 
				new SolidBrush(Color.Blue);
			SolidBrush blueBrush = 
				new SolidBrush(Color.Green);
			// Draw and fill rectangles
			g.DrawRectangle(redPen, rect3.X, rect3.Y,
								rect3.Width, rect3.Height);
			g.FillRectangle(blueBrush, rect2);
			g.FillRectangle(greenBrush, rect1);
			// Dispose
			redPen.Dispose();
			blueBrush.Dispose();
			greenBrush.Dispose();
			g.Dispose();
		}

		private void RectProperties_Click(object sender, System.EventArgs e)
		{
			// Create Point, Size, and Rectangle
			Point pt = new Point(10, 10);
			Size sz = new Size(60, 40);
			Rectangle rect1 = Rectangle.Empty;
			Rectangle rect2 = new Rectangle(20, 30, 30, 10);
			// Set Rectangle properties
			if (rect1.IsEmpty)
			{
				rect1.Location = pt; 
				rect1.Width = sz.Width;
				rect1.Height = sz.Height;
			}
			// Get Rectangle properties
			string str = "Location:"+ rect1.Location.ToString();
			str += ", X:" +rect1.X.ToString();
			str += ", Y:"+ rect1.Y.ToString();
			str += ", Left:"+ rect1.Left.ToString();
			str += ", Right"+ rect1.Right.ToString();
			str += ", Top:"+ rect1.Top.ToString();
			str += ", Bottom:"+ rect1.Bottom.ToString();
			MessageBox.Show(str);
		}

		private void RectMethods_Click(object sender, System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			// Create PointF, SizeF and RectangleF
			PointF pt = new PointF(30.8f, 20.7f);
			SizeF sz = new SizeF(60.0f, 40.0f);
			RectangleF rect2 = 
				new RectangleF(40.2f, 40.6f, 100.5f, 100.0f);
			RectangleF rect1 = new RectangleF(pt, sz);
			Rectangle rect3 = Rectangle.Ceiling(rect1);
			Rectangle rect4 = Rectangle.Truncate(rect1);
			Rectangle rect5 = Rectangle.Round(rect2);
			// Draw rectangles
			g.DrawRectangle(Pens.Black, rect3);
			g.DrawRectangle(Pens.Red, rect5);
			// Intersect rectangles
			Rectangle isectRect = 
				Rectangle.Intersect(rect3, rect5);
			// Fill new rectangle
			g.FillRectangle(
				new SolidBrush(Color.Blue), isectRect);
			// Create a Size
			Size inflateSize = new Size(0, 40);
			// Inflate rectangle
			isectRect.Inflate(inflateSize);
			// Draw new rectangle
			g.DrawRectangle(Pens.Blue, isectRect);
			// Set Rectangle properties
			rect4 = Rectangle.Empty;
			rect4.Location = new Point(50, 50);
			rect4.X = 30;
			rect4.Y = 40;
			// Union two rectangles
			Rectangle unionRect =
				Rectangle.Union(rect4, rect5);
			// Draw new rectangle
			g.DrawRectangle(Pens.Green, unionRect);
			// Create a Graphics object
			g.Dispose();

		}
	}
}
