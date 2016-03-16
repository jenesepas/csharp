using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace StructuresSamp
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
		private System.Windows.Forms.Button button1;

		private SolidBrush currentBrush; 

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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
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
																					  this.menuItem4});
			this.menuItem1.Text = "Test";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Point Structure";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Size Structure";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "Rectangle Structure";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 40);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.MouseHover += new System.EventHandler(this.MouseHoverAction);
			this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.ResumeLayout(false);

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

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
				
			PointF pt1 = new PointF(30.6f, 30.8f);
			PointF pt2 = new PointF(50.3f, 60.7f);			
			PointF pt3 = new PointF(110.3f, 80.5f);

			Point pt4 = Point.Ceiling(pt1);
			Point pt5 = Point.Round(pt2);
			Point pt6 = Point.Truncate(pt3);
			
			MessageBox.Show(pt4.ToString());
			MessageBox.Show(pt5.ToString());
			MessageBox.Show(pt6.ToString());

			Graphics g = Graphics.FromHwnd(this.Handle);
			g.Clear(this.BackColor);
			g.Dispose();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			PointF pt1 = new PointF(30.6f, 30.8f);
			PointF pt2 = new PointF(50.3f, 60.7f);			
			PointF pt3 = new PointF(110.3f, 80.5f);
            
			SizeF sz1 = new SizeF(pt1);
			SizeF sz2 = new SizeF(pt2);
			SizeF sz3 = new SizeF(pt3);
            
			Size sz4 = Size.Ceiling(sz1);
			Size sz5 = Size.Round(sz2);
			Size sz6 = Size.Truncate(sz3);

			MessageBox.Show(sz4.ToString());
			MessageBox.Show(sz5.ToString());
			MessageBox.Show(sz6.ToString());

		}

		private void MouseHoverAction(object sender, System.EventArgs e)
		{
		
		}

		private void button1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Rectangle rect = new Rectangle( button1.Location, button1.Size);
			
			if(rect.Contains( new Rectangle( new Point(e.X, e.Y), button1.Size) ) )
			{
				Graphics g = Graphics.FromHwnd(this.Handle);
				g.FillRectangle(SystemBrushes.ControlDarkDark, 10, 20, 50, 100);
				g.Clear(this.BackColor);
				g.Dispose();
			}
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			//e.Graphics.FillRectangle(SystemBrushes.ControlDarkDark, 10, 20, 50, 100);
		}
	}
}
