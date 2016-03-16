using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace DrawMethods
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
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;

		private int objType = 0;

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
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem16});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5,
																					  this.menuItem6,
																					  this.menuItem7,
																					  this.menuItem8,
																					  this.menuItem9,
																					  this.menuItem10,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem13,
																					  this.menuItem14,
																					  this.menuItem15});
			this.menuItem1.Text = "Draw Method";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Rectangle";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Line";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "Circle";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "Ellipse";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 4;
			this.menuItem6.Text = "Arc";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 5;
			this.menuItem7.Text = "Bezier";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 6;
			this.menuItem8.Text = "Curve";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 7;
			this.menuItem9.Text = "Icon";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 8;
			this.menuItem10.Text = "Image";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 9;
			this.menuItem11.Text = "Polygon";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 10;
			this.menuItem12.Text = "Text";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 11;
			this.menuItem13.Text = "Path";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 12;
			this.menuItem14.Text = "Pie";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 13;
			this.menuItem15.Text = "Clear";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 1;
			this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem17,
																					   this.menuItem18,
																					   this.menuItem19});
			this.menuItem16.Text = "Image";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 0;
			this.menuItem17.Text = "FromImage";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 1;
			this.menuItem18.Text = "FromHdc";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 2;
			this.menuItem19.Text = "FromHwnd";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 401);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			objType = 9;
			this.Invalidate(this.Region, true);
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			objType = 1;
			this.Invalidate(this.Region, true);
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			objType = 2;		
			this.Invalidate(this.Region, true);
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			objType = 3;		
			this.Invalidate(this.Region, true);		
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			objType = 4;		
			this.Invalidate(this.Region, true);		
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			objType = 5;		
			this.Invalidate(this.Region, true);		
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			objType = 6;		
			this.Invalidate(this.Region, true);
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			objType = 7;		
			this.Invalidate(this.Region, true);		
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			objType = 8;		
			this.Invalidate(this.Region, true);		
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			objType = 10;		
			this.Invalidate(this.Region, true);		
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			objType = 11;		
			this.Invalidate(this.Region, true);		
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			objType = 12;		
			this.Invalidate(this.Region, true);		
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			objType = 13;		
			this.Invalidate(this.Region, true);
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// Keeping Graphics object inside the loop so 
			//I can direct copy code to the chapter

			// Drawing a rectangle
			if ( objType == 1)
			{
				Graphics g = e.Graphics ; 
				SolidBrush blueBrush = new SolidBrush(Color.Green);
				SolidBrush redBrush = new SolidBrush(Color.Green);
				Rectangle rect = new Rectangle(10, 20, 50, 50); 
				
				RectangleF[] rectArray =
				{
					new RectangleF(  0.0F,   0.0F, 60.0F, 60.0F),
					new RectangleF(100.0F, 100.0F, 150.0F,  60.0F),
					new RectangleF(200.0F,   80.0F,  230.0F, 100.0F),
					new RectangleF(40.0F,   32.0F,  20.0F, 200.0F)
				};

				g.FillRectangle(new HatchBrush
					(HatchStyle.BackwardDiagonal, Color.Yellow, Color.Black),
					rect);				
				e.Graphics.FillRectangle(blueBrush, rect);
				e.Graphics.FillRectangles(redBrush, rectArray);


			}
			// Drawing lines
			if ( objType == 2)
			{
				Graphics g = e.Graphics ; 
				Pen pn = new Pen( Color.Blue ); 
				// Rectangle rect = new Rectangle(50, 50, 200, 100); 
				Point pt1 = new Point( 30, 30); 
				Point pt2 = new Point( 110, 100); 
				g.DrawLine( pn, pt1, pt2 ); 


				// Create a pen with red color and width 3
				Pen redPen = new Pen(Color.Red, 3);
				// Create an array of points
				PointF[] ptsArray =
				{
					new PointF( 10.0F,  20.0F),
					new PointF( 50.0F, 40.0F),
					new PointF(220.0F,  120.0F),
					new PointF(120.0F, 20.0F)
				};
				g.DrawLines(redPen, ptsArray);
			}
			// Drawing a Circle
			if ( objType == 3)
			{
				Graphics g = e.Graphics ; 
				Pen pn = new Pen( Color.Blue, 100 ); 
				Rectangle rect = new Rectangle(50, 50, 100, 100); 
				g.DrawEllipse( pn, rect ); 
			}
			// Drawing an Ellipse
			if ( objType == 4)
			{
				Graphics g = e.Graphics ; 
				Rectangle rect = new Rectangle(50, 50, 200, 100); 			
				HatchBrush htchBrush = new HatchBrush(HatchStyle.Cross, 
					Color.Blue, Color.Yellow);
				e.Graphics.FillEllipse(htchBrush, rect);

			}
			// Drawing an arc
			if ( objType == 5)
			{
				Graphics g = e.Graphics ;
				Pen pn = new Pen( Color.Blue );
				Rectangle rect = new Rectangle(50, 50, 200, 100);
				g.DrawArc( pn, rect, 12, 84 );
			}

			// Drawing Beziers
			if ( objType == 6)
			{
				Graphics g = e.Graphics ;
				// Create a green pen.
				Pen greenPen = new Pen(Color.Green, 2);
				// Draw bezier
				e.Graphics.DrawBezier(greenPen, 20.0F, 30.0F,
					100.0F, 200.0F,
					40.0F, 400.0F,
					100.0F, 200.0F);

				// Create pen.
				Pen	redPen = new Pen(Color.Red, 2);
				// Create points for curve.
				PointF p1 = new PointF(40.0F, 50.0F);
				PointF p2 = new PointF(60.0F, 70.0F);
				PointF p3 = new PointF(80.0F, 34.0F);
				PointF p4 = new PointF(120.0F, 180.0F);
				PointF p5 = new PointF(200.0F, 150.0F);
				PointF p6 = new PointF(350.0F, 250.0F);
				PointF p7 = new PointF(200.0F, 200.0F);
				PointF[] ptsArray =
				{
					p1, p2, p3, p4,	p5, p6, p7
				};
				e.Graphics.DrawBeziers(redPen, ptsArray);			

			}

			// Drawing an arc
			if ( objType == 7)
			{
				PointF pt1 = new PointF( 10.0F,  10.0F);
				PointF pt2 = new PointF(50.0F,  35.0F);
				PointF pt3 = new PointF(100.0F,  20.0F);
				PointF pt4 = new PointF(250.0F,  50.0F);
				PointF pt5 = new PointF(300.0F, 100.0F);
				PointF pt6 = new PointF(350.0F, 200.0F);
				PointF pt7 = new PointF(250.0F, 250.0F);
				PointF[] ptsArray =
				{
					pt1, pt2, pt3, pt4, pt5, pt6, pt7
				};				
				float tension = 1.0F;
				FillMode flMode = FillMode.Alternate;			
				SolidBrush blueBrush = new SolidBrush(Color.Blue);
				e.Graphics.FillClosedCurve(blueBrush, ptsArray, flMode, tension);

			}
			// Drawing an Icon
			if ( objType == 8)
			{
				Icon icon = new Icon("mouse.ico");
				int x = 50;
				int y = 100;
				e.Graphics.DrawIcon(icon, x, y);
				Rectangle rect = new Rectangle( 50, 100, 400, 400);
				e.Graphics.DrawIconUnstretched(icon, rect);
			}			
		
			// Drawing a polygon
			if ( objType == 10)
			{
				PointF pt1 = new PointF( 10.0F,  10.0F);
				PointF pt2 = new PointF(100.0F,  25.0F);
				PointF pt3 = new PointF(150.0F,   35.0F);
				PointF pt4 = new PointF(250.0F,  50.0F);
				PointF pt5 = new PointF(300.0F, 100.0F);
				PointF pt6 = new PointF(350.0F, 200.0F);
				PointF pt7 = new PointF(250.0F, 250.0F);
				PointF[] ptsArray =
				{
					pt1, pt2, pt3, pt4, pt5, pt6, pt7
				};
				HatchBrush htchBrush = new HatchBrush(HatchStyle.ForwardDiagonal,
					Color.Black, Color.Red);
				FillMode flMode = FillMode.Winding;
				e.Graphics.FillPolygon(htchBrush, ptsArray, flMode);

			}
				
			
			// Drawing text
			if ( objType == 11)
			{
				Font fnt = new Font("Verdana", 16);
				Graphics g = e.Graphics;
				g.DrawString("GDI+ World", fnt, new SolidBrush(Color.Red), 14,10);
			}
			// Drawing a path
			if ( objType == 12)
			{
				Graphics g = e.Graphics;
				GraphicsPath graphPath = new GraphicsPath();
				graphPath.AddEllipse(50, 50, 150, 200);
				SolidBrush blackBrush = new SolidBrush(Color.Black);	
				e.Graphics.FillPath(blackBrush, graphPath);
			}		
			// Drawing a Pie
			if ( objType == 13)
			{
				Graphics g = e.Graphics;
				g.FillPie(new SolidBrush(Color.Red), 0.0F, 0.0F, 100, 60, 0.0F, 90.0F);
			}
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			g.Dispose();			
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
		
		}


		// FromImage
		private void menuItem17_Click(object sender, System.EventArgs e)
		{
			Image imageFile = Image.FromFile(@"F:\Mahesh\Stuff\hotjb.jpg");
			Graphics g = this.CreateGraphics();
			Graphics newGraphics = Graphics.FromImage(imageFile);
			newGraphics.FillRectangle(new SolidBrush(Color.Black), 100, 50, 100, 100);
			g.DrawImage(imageFile, new PointF(0.0F, 0.0F));
            newGraphics.Dispose();
			g.Dispose();
		}

		// FromHdc
		private void menuItem18_Click(object sender, System.EventArgs e)
		{
			IntPtr hdc = e.Graphics.GetHdc();
			Graphics newGraphics = Graphics.FromHdc(hdc);
			newGraphics.DrawRectangle(new Pen(Color.Red, 3), 0, 0, 200, 100);
			e.Graphics.ReleaseHdc(hdc);	
		}

		//FromHwnd
		private void menuItem19_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
