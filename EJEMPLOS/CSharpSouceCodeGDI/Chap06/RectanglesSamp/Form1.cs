using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RectanglesSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem CreateRectMenu;
		private System.Windows.Forms.MenuItem PropertiesMenu;
		private System.Windows.Forms.MenuItem MethodsMenu;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem CreateRectF;
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
			this.CreateRectMenu = new System.Windows.Forms.MenuItem();
			this.CreateRectF = new System.Windows.Forms.MenuItem();
			this.PropertiesMenu = new System.Windows.Forms.MenuItem();
			this.MethodsMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
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
																																							this.CreateRectMenu,
																																							this.CreateRectF,
																																							this.PropertiesMenu,
																																							this.MethodsMenu,
																																							this.menuItem2});
			this.menuItem1.Text = "Rectangles";
			// 
			// CreateRectMenu
			// 
			this.CreateRectMenu.Index = 0;
			this.CreateRectMenu.Text = "Create Rectangles";
			this.CreateRectMenu.Click += new System.EventHandler(this.CreateRectMenu_Click);
			// 
			// CreateRectF
			// 
			this.CreateRectF.Index = 1;
			this.CreateRectF.Text = "Create RectangleF";
			this.CreateRectF.Click += new System.EventHandler(this.CreateRectF_Click);
			// 
			// PropertiesMenu
			// 
			this.PropertiesMenu.Index = 2;
			this.PropertiesMenu.Text = "Properties";
			this.PropertiesMenu.Click += new System.EventHandler(this.PropertiesMenu_Click);
			// 
			// MethodsMenu
			// 
			this.MethodsMenu.Index = 3;
			this.MethodsMenu.Text = "Methods";
			this.MethodsMenu.Click += new System.EventHandler(this.MethodsMenu_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 4;
			this.menuItem2.Text = "";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 301);
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

		private void CreateRectMenu_Click(object sender,
			System.EventArgs e)
		{
			int x = 20;
			int y = 30;
			int height = 30;
			int width = 30;
			// Create a Point
			Point pt = new Point(10, 10);
			// Create a Size
			Size sz = new Size(60, 40);
			// Create a Rectangle from point
			// and size
			Rectangle rect1 = new Rectangle(pt, sz);
			Rectangle rect2 = 
				new Rectangle(x, y, width, height);
		}

		private void CreateRectF_Click(object sender,
			System.EventArgs e)
		{
			// Create a Point
			PointF pt = new PointF(30.8f, 20.7f);
			// Create a Size
			SizeF sz = new SizeF(60.0f, 40.0f);
			// Create a Rectangle from a Point and 
			// a Size
			RectangleF rect1 = new RectangleF(pt, sz);
			// Create a Rectangle from floating points
			RectangleF rect2 = 
				new RectangleF(40.2f, 40.6f, 100.5f, 100.0f);			
		}


		private void PropertiesMenu_Click(object sender,
      System.EventArgs e)
    {
      // Create a Point
      PointF pt = new PointF(30.8f, 20.7f);
      // Create a Size
      SizeF sz = new SizeF(60.0f, 40.0f);
      // Create a Rectangle from a Point and 
      // a Size
      RectangleF rect1 = new RectangleF(pt, sz);
      // Create a Rectangle from floating points
      RectangleF rect2 = 
        new RectangleF(40.2f, 40.6f, 100.5f, 100.0f);
      // If rectangle is empty
      // Set its Location, Widht, and Height
      // Properties
      if (rect1.IsEmpty)
      {
        rect1.Location = pt; 
        rect1.Width = sz.Width;
        rect1.Height = sz.Height;
      }
      // Read properties and display
      string str = 
        "Location:"+ rect1.Location.ToString();
      str += "X:"+rect1.X.ToString() + "\n";
      str += "Y:"+ rect1.Y.ToString() + "\n";
      str += "Left:"+ rect1.Left.ToString() + "\n";
      str += "Right:"+ rect1.Right.ToString() + "\n";
      str += "Top:"+ rect1.Top.ToString() + "\n";
      str += "Bottom:"+ rect1.Bottom.ToString();
      MessageBox.Show(str);
    }

	  private void MethodsMenu_Click(object sender, 
      System.EventArgs e)
    {
      // Create a Graphics object
      Graphics g = this.CreateGraphics();
      // Create a Point & Size
      PointF pt = new PointF(30.8f, 20.7f);
      SizeF sz = new SizeF(60.0f, 40.0f);
      // Create two rectangles
      RectangleF rect1 = new RectangleF(pt, sz);
      RectangleF rect2 = 
        new RectangleF(40.2f, 40.6f, 100.5f, 100.0f);
      // Ceiling a rectangle
      Rectangle rect3 = Rectangle.Ceiling(rect1);
      // Truncate a rectangle
      Rectangle rect4 = Rectangle.Truncate(rect1);
      // Round a rectangle
      Rectangle rect5 = Rectangle.Round(rect2);
      // Draw rectangles
      g.DrawRectangle(Pens.Black, rect3);
      g.DrawRectangle(Pens.Red, rect5);   
      // Intersect a rectangle
      Rectangle isectRect = 
        Rectangle.Intersect(rect3, rect5);
      // Fill rectangle
      g.FillRectangle(
        new SolidBrush(Color.Blue), isectRect);
      // Inflate a recntangle
      Size inflateSize = new Size(0, 40);
      isectRect.Inflate(inflateSize);
      // Draw rectangle
      g.DrawRectangle(Pens.Blue, isectRect);
      // Empty rectangle and set its properties
      rect4 = Rectangle.Empty;
      rect4.Location = new Point(50, 50);
      rect4.X = 30;
      rect4.Y = 40;
      // Union rectangles
      Rectangle unionRect = 
        Rectangle.Union(rect4, rect5);
      // Draw rectangle
      g.DrawRectangle(Pens.Green, unionRect);
      // Displose 
      g.Dispose();
    }

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}




