using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ClippingRgnSamp2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem XOR;
		private System.Windows.Forms.MenuItem Union;
		private System.Windows.Forms.MenuItem Exclude;
		private System.Windows.Forms.MenuItem Intersect;
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
			this.XOR = new System.Windows.Forms.MenuItem();
			this.Union = new System.Windows.Forms.MenuItem();
			this.Exclude = new System.Windows.Forms.MenuItem();
			this.Intersect = new System.Windows.Forms.MenuItem();
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
																					  this.XOR,
																					  this.Union,
																					  this.Exclude,
																					  this.Intersect});
			this.menuItem1.Text = "Operation";
			// 
			// XOR
			// 
			this.XOR.Index = 0;
			this.XOR.Text = "XOR";
			this.XOR.Click += new System.EventHandler(this.XOR_Click);
			// 
			// Union
			// 
			this.Union.Index = 1;
			this.Union.Text = "Union";
			this.Union.Click += new System.EventHandler(this.Union_Click);
			// 
			// Exclude
			// 
			this.Exclude.Index = 2;
			this.Exclude.Text = "Exclude";
			this.Exclude.Click += new System.EventHandler(this.Exclude_Click);
			// 
			// Intersect
			// 
			this.Intersect.Index = 3;
			this.Intersect.Text = "Intersect";
			this.Intersect.Click += new System.EventHandler(this.Intersect_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 209);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Clipping Regions Sample";

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

		private void XOR_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Pen pen = new Pen(Color.Red, 5);  
			SolidBrush brush = new SolidBrush(Color.Red); 
			Rectangle rect1 = new Rectangle(50, 0, 50, 150);
			Rectangle rect2 = new Rectangle(0, 50, 150, 50);		
			Region region = new Region(rect1);
			region.Xor(rect2);
			g.FillRegion(brush, region);
			g.Dispose();

		}

		private void Union_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Pen pen = new Pen(Color.Red, 5);  
			SolidBrush brush = new SolidBrush(Color.Red); 
			Rectangle rect1 = new Rectangle(50, 0, 50, 150);
			Rectangle rect2 = new Rectangle(0, 50, 150, 50);		
			Region region = new Region(rect1);
			region.Union(rect2);
			g.FillRegion(brush, region);
			g.Dispose();
		
		}

		private void Exclude_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Pen pen = new Pen(Color.Red, 5);  
			SolidBrush brush = new SolidBrush(Color.Red); 
			Rectangle rect1 = new Rectangle(50, 0, 50, 150);
			Rectangle rect2 = new Rectangle(0, 50, 150, 50);		
			Region region = new Region(rect1);
			region.Exclude(rect2);
			g.FillRegion(brush, region);
			g.Dispose();
		}

		private void Intersect_Click(object sender, System.EventArgs e)
		{
				Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Pen pen = new Pen(Color.Red, 5);  
			SolidBrush brush = new SolidBrush(Color.Red); 
			Rectangle rect1 = new Rectangle(50, 0, 50, 150);
			Rectangle rect2 = new Rectangle(0, 50, 150, 50);		
			Region region = new Region(rect1);
			region.Intersect(rect2);
			g.FillRegion(brush, region);
			g.Dispose();
		
		}
	}
}
