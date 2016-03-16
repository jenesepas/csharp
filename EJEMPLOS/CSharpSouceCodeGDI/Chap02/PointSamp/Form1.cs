using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PointSamp
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
																																							this.menuItem5});
			this.menuItem1.Text = "Point";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Point Code";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "PointF Code";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "Point Methods";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "Point Conversions";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 309);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Point Structure Sample";
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

		
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			// Create a new Point
			Point pt = new Point(50, 50);
			// Create a new point using Point.Empty
			Point newPoint = Point.Empty;
			// Set X and Y properties of Point
			newPoint.X = 100;
			newPoint.Y = 200;
			// Create a Graphics object from the 
			// current form's handle
			Graphics g = Graphics.FromHwnd(this.Handle);
			// Create a new pen with blue color
			// and with = 4
			Pen pn = new Pen(Color.Blue, 4);
			// Draw a line from point pt to 
			// new point
			g.DrawLine(pn, pt, newPoint);
			// Dispose pen and graphics objects
			pn.Dispose();
			g.Dispose();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			// Create a new PointF
			PointF pt = new PointF(50.0F, 50.0F);
			// Create a new point using PointF.Empty
			PointF newPoint = PointF.Empty;
			// Set X and Y properties of PointF
			newPoint.X = 100.0F;
			newPoint.Y = 200.0F;
			// Create a Graphics object from the 
			// current form's handle
			Graphics g = Graphics.FromHwnd(this.Handle);
			// Create a new pen with blue color
			// and with = 4
			Pen pn = new Pen(Color.Blue, 4);
			// Draw a line from point pt to 
			// new point
			g.DrawLine(pn, pt, newPoint);
			// Dispose pen and graphics objects
      pn.Dispose();
			g.Dispose();		
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			// Create three points
			PointF pt1 = new PointF(30.6f, 30.8f);
			PointF pt2 = new PointF(50.3f, 60.7f);
			PointF pt3 = new PointF(110.3f, 80.5f);
			// Call Ceiling, Round, and Truncate methods
			// and return new points
			Point pt4 = Point.Ceiling(pt1);
			Point pt5 = Point.Round(pt2);
			Point pt6 = Point.Truncate(pt3);
			// Display results
			MessageBox.Show("Value of pt4: " +pt4.ToString());
			MessageBox.Show("Value of pt5: " +pt5.ToString());
			MessageBox.Show("Value of pt6: " +pt6.ToString());
		
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			// Create a Size 
			Size sz = new Size(12, 12);
			// Create a Point
			Point pt = new Point(20, 20);
			// Add poitn and size and copy to point
			pt = pt+sz;
			MessageBox.Show("Addition :"+ pt.ToString());
			// Subtract point and size
			pt = pt-sz;
			MessageBox.Show("Subtraction :"+ pt.ToString());
			// Create a PointF from Point
			PointF ptf = pt;
			MessageBox.Show("PointF :"+ pt.ToString());
			// Concert Point to Size
			sz = (Size)pt;
			MessageBox.Show("Size :"+ sz.Width.ToString() 
				+","+ sz.Height.ToString() );

		}
	}
}

