using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MCBPaintBrush
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int xstart, ystart;
		private int xend, yend;
		private int penWidth = 1;
		private Pen colorPen; 
		private Color colorType;
		private int objType = 0;


		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
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


		public MainForm1()
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
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem6,
																					  this.menuItem7,
																					  this.menuItem8,
																					  this.menuItem9});
			this.menuItem1.Text = "Object";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem10,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem13,
																					  this.menuItem14});
			this.menuItem2.Text = "Color";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Pen Width";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "Brush";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Text = "Line";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "Rectangle";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "Ellipse";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 3;
			this.menuItem8.Text = "Curve";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 4;
			this.menuItem9.Text = "Arc";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 0;
			this.menuItem10.Text = "Color Dialog";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 1;
			this.menuItem11.Text = "Blue";
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.Text = "Red";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 3;
			this.menuItem13.Text = "Green";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 4;
			this.menuItem14.Text = "Black";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(656, 445);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "GDI+ PaintBrush Application";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm1());
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics; 
			int x = xstart;
			int y = ystart;
			int width = xend - xstart;
			int height = yend - ystart;

			colorPen = new Pen(Color.Blue, penWidth);

			if(objType == 0)
			{
				Point pt1 = new Point();
				Point pt2 = new Point();
				pt1.X = xstart;
				pt1.Y = ystart;
				pt2.X = xend;
				pt2.Y = yend;

				g.DrawLine(colorPen, pt1, pt2);
			}

			if(objType == 1)
			{
				g.DrawRectangle( colorPen, xstart, ystart, width, height);
			}
			if(objType == 2)
			{
				g.DrawEllipse( colorPen, xstart, ystart, width, height);
			}
			if(objType == 3)
			{
			}
			if(objType == 4)
			{
			}
		}

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			xstart = e.X;
			ystart = e.Y;		
		}

		private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				xend = e.X;
				yend = e.Y;
				Invalidate(this.ClientRectangle);		
			}
		}

		private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//xend = e.X;
			//yend = e.Y;
			//Invalidate(this.ClientRectangle);
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			objType = 0;
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			objType = 1;		
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			objType = 2;
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			objType = 3;
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			objType = 4;
		}
	}
}
