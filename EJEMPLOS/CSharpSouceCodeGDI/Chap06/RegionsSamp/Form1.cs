using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace RegionsSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;

		private int options = 0;
		private Rectangle containRect;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem19; 

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
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem5,
																					  this.menuItem14});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem4});
			this.menuItem1.Text = "Rectangle";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "Round, Truncate and other methods";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "Contains";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "RectangleF";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem6,
																					  this.menuItem7,
																					  this.menuItem8,
																					  this.menuItem9,
																					  this.menuItem10,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem13});
			this.menuItem5.Text = "Region";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 0;
			this.menuItem6.Text = "Construct";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 1;
			this.menuItem7.Text = "Complement";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 2;
			this.menuItem8.Text = "Empty and Others";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 3;
			this.menuItem9.Text = "Exclude";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 4;
			this.menuItem10.Text = "Union";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 5;
			this.menuItem11.Text = "Xor";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 6;
			this.menuItem12.Text = "Intersect";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 7;
			this.menuItem13.Text = "Excl";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 3;
			this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem15,
																					   this.menuItem16,
																					   this.menuItem19});
			this.menuItem14.Text = "Clipping";
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 0;
			this.menuItem15.Text = "ExcludeClip";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 1;
			this.menuItem16.Text = "SetClip";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 2;
			this.menuItem19.Text = "TranslateClip";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 273);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
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

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
			if (options == 1)
			{
				PointF pt = new PointF(30.8f, 20.7f);
				SizeF sz = new SizeF(60.0f, 40.0f);
				RectangleF rect2 = new RectangleF(40.2f, 40.6f, 100.5f, 100.0f);
				RectangleF rect1 = new RectangleF(pt, sz);
		
				Rectangle rect3 = Rectangle.Ceiling(rect1);
				Rectangle rect4 = Rectangle.Truncate(rect1);
				Rectangle rect5 = Rectangle.Round(rect2);
				e.Graphics.DrawRectangle(Pens.Black, rect3);
				e.Graphics.DrawRectangle(Pens.Red, rect5);		
				Rectangle isectRect = Rectangle.Intersect(rect3, rect5);
				e.Graphics.FillRectangle(new SolidBrush(Color.Blue), isectRect);
				Size inflateSize = new Size(0, 40);
				isectRect.Inflate(inflateSize);
				e.Graphics.DrawRectangle(Pens.Blue, isectRect);
				rect4 = Rectangle.Empty;
				rect4.Location = new Point(50, 50);
				rect4.X = 30;
				rect4.Y = 40;
				Rectangle unionRect = Rectangle.Union(rect4, rect5);
				e.Graphics.DrawRectangle(Pens.Green, unionRect);
			}
			if(options == 2)
			{
				Point pt = new Point(0, 0);
				Size sz = new Size(200, 200);
				Rectangle bigRect = new Rectangle(pt, sz);
				Rectangle smallRect = new Rectangle(30, 20, 100, 100);
				//if (bigRect.Contains(smallRect) )
				////	MessageBox.Show("Rectangle "+smallRect.ToString() 
					//	+" is inside Rectangle "+ bigRect.ToString() );
				e.Graphics.DrawRectangle(Pens.Green, bigRect);
			}

		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			options = 1;		
			this.Invalidate(this.ClientRectangle);
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			options = 2;
			this.Invalidate(this.ClientRectangle);
		}

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				Point pt = new Point(0, 0);
				Size sz = new Size(200, 200);
				Rectangle bigRect = new Rectangle(pt, sz);
				if (bigRect.Contains( new Point(e.X, e.Y)) )
					MessageBox.Show("Clicked inside rectangle");
				else 
					MessageBox.Show("Clicked outside rectangle");					
			}			
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			// Create two rectangle
			Rectangle rect1 = 
				new Rectangle(20, 20, 60, 80);
			RectangleF rect2 = 
				new RectangleF(100, 20, 60, 100);
			// Create a Graphics path
			GraphicsPath path = new GraphicsPath();
			// Add a rectangle to graphics path
			path.AddRectangle(rect1);
			// Create a Region from rect1
			Region rectRgn1 = new Region(rect1);
			// Create a Region from rect2
			Region rectRgn2 = new Region(rect2);
			// Create a Region from GraphicsPath
			Region pathRgn = new Region(path);
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			// Create a Graphics
			Graphics g = this.CreateGraphics();
			// Create two Rectangles
			Rectangle rect1 = new Rectangle(20, 20, 60, 80);
			Rectangle rect2 = new Rectangle(50, 30, 60, 80);
			// Create two Regions
			Region rgn1 = new Region(rect1);
			Region rgn2 = new Region(rect2);
			// Draw rectangles
			g.DrawRectangle(Pens.Green, rect1);
			g.DrawRectangle(Pens.Black, rect2);
			// Complement can take a Rectangle, RectangleF,
			// Region or a GraphicsPath as an argument
			rgn1.Complement(rgn2);	
			// rgn1.Complement(rect2);			
			g.FillRegion(Brushes.Blue, rgn1);	
			// Dispose 
			g.Dispose();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{		
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create Rectangles and Regions
			Rectangle rect1 = 
				new Rectangle(20, 20, 60, 80);			
			Rectangle rect2 = 
				new Rectangle(50, 30, 60, 80);
			Region rgn1 = new Region(rect1);
			Region rgn2 = new Region(rect2);
			// If Region is not empty, empty it
			if (! rgn1.IsEmpty(g))
				rgn1.MakeEmpty();
			// If Region is not infinite, infinite 
			// it
			if (! rgn2.IsInfinite(g))
				rgn2.MakeInfinite();
			// Get bounds of the infinite region
			RectangleF rect = rgn2.GetBounds(g);
			// Display
			MessageBox.Show(rect.ToString());
			// Fill the region			
			g.FillRegion(Brushes.Red, rgn2);
			// Dispose 
			g.Dispose();

		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			// Create Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create Rectangles
			Rectangle rect1 = new Rectangle(20, 20, 60, 80);			
			Rectangle rect2 = new Rectangle(50, 30, 60, 80);
			// Create Regions
			Region rgn1 = new Region(rect1);
			Region rgn2 = new Region(rect2);
			// Draw rectangles
			g.DrawRectangle(Pens.Green, rect1);
			g.DrawRectangle(Pens.Black, rect2);
			// Exclued the region
			rgn1.Exclude(rgn2);	
			// Fill region after exclude	
			g.FillRegion(Brushes.Blue, rgn1);	
			// Dispose 
			g.Dispose();
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
		
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);

			Rectangle rect1 = new Rectangle(20, 20, 60, 80);			
			Rectangle rect2 = new Rectangle(50, 30, 60, 80);
			Region rgn1 = new Region(rect1);
			Region rgn2 = new Region(rect2);
			g.DrawRectangle(Pens.Green, rect1);
			g.DrawRectangle(Pens.Black, rect2);
			// Complement can take a Rectangle, RectangleF,
			// Region or a GraphicsPath as an argument
			rgn1.Union(rgn2);	
			// rgn1.Complement(rect2);			
			g.FillRegion(Brushes.Blue, rgn1);
	
			// Dispose 
			g.Dispose();
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			// Create Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create Rectangles
			Rectangle rect1 = new Rectangle(20, 20, 60, 80);
			Rectangle rect2 = new Rectangle(50, 30, 60, 80);
			// Create Regions
			Region rgn1 = new Region(rect1);
			Region rgn2 = new Region(rect2);
			// Draw Rectangles
			g.DrawRectangle(Pens.Green, rect1);
			g.DrawRectangle(Pens.Black, rect2);
			// Xoring two regions
			rgn1.Xor(rgn2);	
			// Fill the region after Xoring
			g.FillRegion(Brushes.Blue, rgn1);	
			// Dispose 
			g.Dispose();
		
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);

			Rectangle rect1 = new Rectangle(20, 20, 60, 80);			
			Rectangle rect2 = new Rectangle(50, 30, 60, 80);
			Region rgn1 = new Region(rect1);
			Region rgn2 = new Region(rect2);
			g.DrawRectangle(Pens.Green, rect1);
			g.DrawRectangle(Pens.Black, rect2);
			// Complement can take a Rectangle, RectangleF,
			// Region or a GraphicsPath as an argument
			rgn1.Intersect(rgn2);	
			// rgn1.Complement(rect2);			
			g.FillRegion(Brushes.Blue, rgn1);
	
			// Dispose 
			g.Dispose();
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create Rectangles
			Rectangle rect1 = new Rectangle(20, 20, 60, 80);
			Rectangle rect2 = new Rectangle(100, 100, 30, 40);
			// Create a Region
			Region rgn1 = new Region(rect2);
			// Exclued Clip
			g.ExcludeClip(rect1);
			g.ExcludeClip(rgn1);
			// Fill rectangle
			g.FillRectangle(Brushes.Red, 0, 0, 200, 200);
			// Dispose 
			g.Dispose();
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			// Create the Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create Rectangles and Regions
			Rectangle rect1 = new Rectangle(20, 20, 200, 200);
			Rectangle rect2 = new Rectangle(100, 100, 200, 200);
			Region rgn1 = new Region(rect1);
			Region rgn2 = new Region(rect2);
			// Call SetClip
			g.SetClip(rgn1, CombineMode.Exclude);
			// Call IntersetClip
			g.IntersectClip(rgn2);
			// Fill Rectangle
			g.FillRectangle(Brushes.Red, 0, 0, 300, 300);
			// ResetClip
			g.ResetClip();
			// Draw rectangles
			g.DrawRectangle(Pens.Green, rect1);
			g.DrawRectangle(Pens.Yellow, rect2);
			// Dispose 
			g.Dispose();
		
		}

		private void menuItem17_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem18_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem19_Click(object sender, System.EventArgs e)
		{
			// Create the Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a RectangleF
			RectangleF rect1 =
				new RectangleF(20.0f, 20.0f, 200.0f, 200.0f);
			// Create a Region
			Region rgn1 = new Region(rect1);
			// Call SetClip
			g.SetClip(rgn1, CombineMode.Exclude);
			float h = 20.0f;
			float w = 30.0f;
			// Call TranslateClip
			g.TranslateClip(h, w);
			// Fill rectangle
			g.FillRectangle(Brushes.Green, 20, 20, 300, 300);

		}
		
	}
}
