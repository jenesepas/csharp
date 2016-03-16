using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OtherMethods
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
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
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
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
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
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5,
																					  this.menuItem6});
			this.menuItem1.Text = "Other Methods";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "ExcludeClip";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "IntersectClip";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "SetClip";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "ResetClip";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 4;
			this.menuItem6.Text = "MeasureString";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 293);
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

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Graphics g = Graphics.FromHwnd(this.Handle);
			g.Clear(this.BackColor);

			SolidBrush redBrush = new SolidBrush(Color.Red);
			Rectangle exRect = new Rectangle(100, 100, 150, 100);
			g.ExcludeClip(exRect);
			g.FillRectangle(redBrush, 10, 10, 350, 300);					
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Graphics g = Graphics.FromHwnd(this.Handle);
			g.Clear(this.BackColor);

			Pen blackPen = new Pen(Color.Black, 2);
			Pen redPen = new Pen(Color.Red, 2);
			Pen greenPen = new Pen(Color.Green, 2);
			Pen yellowPen = new Pen(Color.Yellow, 2);
			Pen yelgreenPen = new Pen(Color.YellowGreen);

			Rectangle rect1 = new Rectangle(0, 0, 50, 50);
			Rectangle rect2 = new Rectangle(50, 50, 100, 100);
			Region region1 = new Region(rect1);
			Region region2 = new Region(rect2);
			g.SetClip(region1, System.Drawing.Drawing2D.CombineMode.Replace);
			Rectangle intRect1 = new Rectangle(25, 25, 75, 75);
			Rectangle intRect2 = new Rectangle(100, 100, 150, 150);

			Region intReg1 = new Region(intRect1);
			Region intReg2 = new Region(intRect2);
			g.IntersectClip(intReg1);
			//g.IntersectClip(intReg2);
			g.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 125, 125);
			g.FillRectangle(new SolidBrush(Color.Blue), 50, 50, 175, 175);
			g.ResetClip();
			g.DrawRectangle(yellowPen, rect1);
			g.DrawRectangle(greenPen, intRect1);
			g.DrawRectangle(blackPen, rect2);
			g.DrawRectangle(redPen, intRect2);
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Graphics g = Graphics.FromHwnd(this.Handle);
			g.Clear(this.BackColor);
			
			// Set clipping region.
			Rectangle clipRect = new Rectangle(0, 0, 200, 200);
			g.SetClip(clipRect);
			// Update clipping region to intersecton of existing region with new rectangle.
			RectangleF intersectRectF = new RectangleF(100.0F, 100.0F, 200.0F, 200.0F);
			g.IntersectClip(intersectRectF);
			// Fill rectangle to demonstrate effective clipping region.
			g.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 500, 500);
			// Reset clipping region to infinite.
			g.ResetClip();
			// Draw clipRect and intersectRect to screen.
			g.DrawRectangle(new Pen(Color.Black), clipRect);
			g.DrawRectangle(new Pen(Color.Red), Rectangle.Round(intersectRectF));

		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
            Graphics g = Graphics.FromHwnd(this.Handle);
			g.Clear(this.BackColor);

			string testString = "This is a test string";
			Font verdana14 = new Font("Verdana", 14);
			Font tahoma18 = new Font("Tahoma", 18);					
			int nChars;
			int nLines;
          
			// Call MeasureString to measure a string
			SizeF sz = g.MeasureString(testString, verdana14);
			string stringDetails = "Height: "+sz.Height.ToString() 
				+ ", Width: "+sz.Width.ToString();
			MessageBox.Show("First string details: "+ stringDetails);
			// 
			g.DrawString(testString, verdana14, Brushes.Green,
				new PointF(0, 100));
			g.DrawRectangle(new Pen(Color.Red, 2), 0.0F, 100.0F, 
				sz.Width, sz.Height);
			
			sz = g.MeasureString("Ellipse", tahoma18, 
				new SizeF(0.0F, 100.0F), new StringFormat(),
				out nChars, out nLines);
			stringDetails = "Height: "+sz.Height.ToString() 
				+ ", Width: "+sz.Width.ToString()
				+ ", Lines: "+nLines.ToString()
				+ ", Chars: "+nChars.ToString();
			MessageBox.Show("Second string details: "+ stringDetails);
			
			g.DrawString("Ellipse", tahoma18, Brushes.Blue,
				new PointF(10, 10));
			g.DrawEllipse( new Pen(Color.Red, 3), 10, 10,  
				sz.Width, sz.Height);
			g.Dispose();
		}
	}
}
