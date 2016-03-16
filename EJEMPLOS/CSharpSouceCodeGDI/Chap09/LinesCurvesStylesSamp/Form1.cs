using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace LinesCurvesStylesSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem DashedMenu;
		private System.Windows.Forms.MenuItem SetStrokeCapsMenu;
		private System.Windows.Forms.MenuItem AdjustableRowCapMenu;
		private System.Windows.Forms.MenuItem GetCapStyles;
		private System.Windows.Forms.MenuItem LineDashStyle;
		private System.Windows.Forms.MenuItem LineDashCap;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem OtherObjects;
		private System.Windows.Forms.MenuItem CustomLineCap;
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
			this.GetCapStyles = new System.Windows.Forms.MenuItem();
			this.LineDashStyle = new System.Windows.Forms.MenuItem();
			this.LineDashCap = new System.Windows.Forms.MenuItem();
			this.OtherObjects = new System.Windows.Forms.MenuItem();
			this.DashedMenu = new System.Windows.Forms.MenuItem();
			this.CustomLineCap = new System.Windows.Forms.MenuItem();
			this.SetStrokeCapsMenu = new System.Windows.Forms.MenuItem();
			this.AdjustableRowCapMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.GetCapStyles,
																					  this.LineDashStyle,
																					  this.LineDashCap,
																					  this.OtherObjects,
																					  this.DashedMenu,
																					  this.CustomLineCap,
																					  this.SetStrokeCapsMenu,
																					  this.AdjustableRowCapMenu});
			this.menuItem1.Text = "Lines and Curves";
			// 
			// GetCapStyles
			// 
			this.GetCapStyles.Index = 0;
			this.GetCapStyles.Text = "Get LineCap Styles";
			this.GetCapStyles.Click += new System.EventHandler(this.GetCapStyles_Click);
			// 
			// LineDashStyle
			// 
			this.LineDashStyle.Index = 1;
			this.LineDashStyle.Text = "Get LineDash Styles";
			this.LineDashStyle.Click += new System.EventHandler(this.LineDashStyle_Click);
			// 
			// LineDashCap
			// 
			this.LineDashCap.Index = 2;
			this.LineDashCap.Text = "Get Line DahsCap ";
			this.LineDashCap.Click += new System.EventHandler(this.LineDashCap_Click);
			// 
			// OtherObjects
			// 
			this.OtherObjects.Index = 3;
			this.OtherObjects.Text = "Other Objects";
			this.OtherObjects.Click += new System.EventHandler(this.OtherObjects_Click);
			// 
			// DashedMenu
			// 
			this.DashedMenu.Index = 4;
			this.DashedMenu.Text = "Dashed ";
			this.DashedMenu.Click += new System.EventHandler(this.DashedMenu_Click);
			// 
			// CustomLineCap
			// 
			this.CustomLineCap.Index = 5;
			this.CustomLineCap.Text = "CustomLineCap";
			this.CustomLineCap.Click += new System.EventHandler(this.CustomLineCap_Click);
			// 
			// SetStrokeCapsMenu
			// 
			this.SetStrokeCapsMenu.Index = 6;
			this.SetStrokeCapsMenu.Text = "SetStrokeCaps";
			this.SetStrokeCapsMenu.Click += new System.EventHandler(this.SetStrokeCapsMenu_Click);
			// 
			// AdjustableRowCapMenu
			// 
			this.AdjustableRowCapMenu.Index = 7;
			this.AdjustableRowCapMenu.Text = "AdjustableRowCap";
			this.AdjustableRowCapMenu.Click += new System.EventHandler(this.AdjustableRowCapMenu_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 385);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Drawing Lines and Curves with Styles";

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

		private void DashedMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);
			// Create three pens
			Pen redPen = new Pen(Color.Red, 10);
			Pen bluePen = new Pen(Color.Blue, 8);
			Pen greenPen = new Pen(Color.Green, 8);
			// Setting line styles 		
			redPen.DashStyle = DashStyle.Dash;
			redPen.SetLineCap(LineCap.DiamondAnchor, 
				LineCap.ArrowAnchor, DashCap.Flat);
			greenPen.DashStyle = DashStyle.DashDotDot;
			greenPen.StartCap = LineCap.Triangle;
			greenPen.EndCap = LineCap.Square;
			greenPen.DashCap = DashCap.Triangle;
			greenPen.DashOffset = 3.4f;
			greenPen.EndCap = LineCap.DiamondAnchor;
			bluePen.DashStyle = DashStyle.Dot;
			bluePen.DashCap = DashCap.Triangle;
			bluePen.DashStyle = DashStyle.DashDot;
			bluePen.EndCap = LineCap.ArrowAnchor;
			bluePen.StartCap = LineCap.SquareAnchor; 
			bluePen.DashPattern = new float[]{1.0f};
			// Drawing Lines and curves
			PointF pt1 = new PointF( 90.0F,  40.0F);
			PointF pt2 = new PointF(130.0F,  80.0F);
			PointF pt3 = new PointF(200.0F, 100.0F);
			PointF pt4 = new PointF(220.0F, 120.0F);
			PointF pt5 = new PointF(250.0F, 250.0F);
			PointF[] ptsArray =
			{
				pt1, pt2, pt3, pt4, pt5
			};
			g.DrawLine(redPen, new Point(20, 20), 
				new Point(300, 20));
			g.DrawLine(greenPen, new Point(20, 80), 
				new Point(300, 80));			
			g.DrawCurve(bluePen, ptsArray);		
			// Dispose
			redPen.Dispose();
			greenPen.Dispose();
			greenPen.Dispose();
			g.Dispose();		
		}

		private void SetStrokeCapsMenu_Click(object sender, 
			System.EventArgs e)
		{
			// Create a graphic 
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);	
			// Create a path for custom line cap. This 
			// path will have two lines from points 
			// -3, -3 to 0, 0 and 0, 0 to 3, -3
			Point[] points =
			{
				new Point(-3, -3),
				new Point(0, 0),
				new Point(3, -3)
			};
			GraphicsPath path = new GraphicsPath();
			path.AddLines(points);
			// Create a Custom line cap from the path
			CustomLineCap cap = 
				new CustomLineCap(null, path);
			// Set the start and end caps of the Custom cap
			cap.SetStrokeCaps(LineCap.Round, LineCap.Triangle);
			// Create a Pen object and set its start and end
			// caps
			Pen redPen = new Pen(Color.Red, 15);
			redPen.CustomStartCap = cap;
			redPen.CustomEndCap = cap;
			redPen.DashStyle = DashStyle.DashDotDot;
			// Draw the line 
			g.DrawLine(redPen,
				new Point(100, 100), 
				new Point(400, 100));
			// Dispose
			g.Dispose();	
		}

		private void AdjustableRowCapMenu_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);
			// Create two AdjustableArrowCap objects
			AdjustableArrowCap cap1 = 
				new AdjustableArrowCap(1, 1, false);
			AdjustableArrowCap cap2 = 
				new AdjustableArrowCap(2, 1);
			// Set cap properties
			cap1.BaseCap = LineCap.Round;		
			cap1.BaseInset = 5;
			cap1.StrokeJoin = LineJoin.Bevel;
			cap2.WidthScale = 3; 
			cap2.BaseCap = LineCap.Square;	
			cap2.Height = 1;
			// Create a pen 
			Pen blackPen = new Pen(Color.Black, 15);
			// Set CustomStartCap and CustomEndCap properties
			blackPen.CustomStartCap = cap1;
			blackPen.CustomEndCap = cap2;
			// Draw line
			g.DrawLine(blackPen, 20, 50, 200, 50);
			// Dispose
			blackPen.Dispose();
			g.Dispose();	
		}	

		private void GetCapStyles_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);
			// Create a pen
			Pen blackPen = new Pen(Color.Black, 10);		
			// Setting line styles 		
			blackPen.StartCap = LineCap.Triangle;
			blackPen.EndCap = LineCap.Triangle;
			g.DrawLine(blackPen, 20, 10, 200, 10);
			blackPen.StartCap = LineCap.Square;
			blackPen.EndCap = LineCap.Square;
			g.DrawLine(blackPen, 20, 30, 200, 30);
			blackPen.StartCap = LineCap.ArrowAnchor;
			blackPen.EndCap = LineCap.ArrowAnchor;
			g.DrawLine(blackPen, 20, 50, 200, 50);
			blackPen.StartCap = LineCap.DiamondAnchor;
			blackPen.EndCap = LineCap.DiamondAnchor;
			g.DrawLine(blackPen, 20, 70, 200, 70);
			blackPen.StartCap = LineCap.Flat;
			blackPen.EndCap = LineCap.Flat;
			g.DrawLine(blackPen, 20, 90, 200, 90);
			blackPen.StartCap = LineCap.Round;
			blackPen.EndCap = LineCap.Round;
			g.DrawLine(blackPen, 20, 110, 200, 110);
			blackPen.StartCap = LineCap.RoundAnchor;
			blackPen.EndCap = LineCap.RoundAnchor;
			g.DrawLine(blackPen, 20, 130, 200, 130);
			blackPen.StartCap = LineCap.Square;
			blackPen.EndCap = LineCap.Square;
			g.DrawLine(blackPen, 20, 150, 200, 150);
			blackPen.StartCap = LineCap.SquareAnchor;
			blackPen.EndCap = LineCap.SquareAnchor;
			g.DrawLine(blackPen, 20, 170, 200, 170);
			blackPen.StartCap = LineCap.Flat;
			blackPen.EndCap = LineCap.Flat;
			g.DrawLine(blackPen, 20, 190, 200, 190);
			// Dispose
			blackPen.Dispose();
			g.Dispose();				
		}

		private void LineDashStyle_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);
			// Create a pen
			Pen blackPen = new Pen(Color.Black, 6);		
			// Setting line styles 		
            blackPen.DashStyle = DashStyle.Dash;
			blackPen.DashOffset = 40;
			blackPen.DashCap = DashCap.Triangle;
			g.DrawLine(blackPen, 20, 10, 500, 10);
			blackPen.DashStyle = DashStyle.DashDot;
			g.DrawLine(blackPen, 20, 30, 500, 30);
			blackPen.DashStyle = DashStyle.DashDotDot;
			g.DrawLine(blackPen, 20, 50, 500, 50);
			blackPen.DashStyle = DashStyle.Dot;
			g.DrawLine(blackPen, 20, 70, 500, 70);
			blackPen.DashStyle = DashStyle.Solid;
			g.DrawLine(blackPen, 20, 70, 500, 70);			
			// Dispose
			blackPen.Dispose();
			g.Dispose();	
		}

		private void LineDashCap_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);		
			// Create a pen
			Pen blackPen = new Pen(Color.Black, 10);		
			// Setting DashCap styles 		
			blackPen.DashStyle = DashStyle.DashDotDot;
			blackPen.DashPattern = new float[]{10};
			blackPen.DashCap = DashCap.Triangle;
			g.DrawLine(blackPen, 20, 10, 500, 10);
			blackPen.DashCap = DashCap.Flat;
			g.DrawLine(blackPen, 20, 30, 500, 30);
			blackPen.DashCap = DashCap.Round;
			g.DrawLine(blackPen, 20, 50, 500, 50);			
			// Dispose
			blackPen.Dispose();
			g.Dispose();			
		}

		private void OtherObjects_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);		
			g.SmoothingMode = SmoothingMode.AntiAlias;
			// Create pen objects
			Pen blackPen = new Pen(Color.Black, 5);		
			Pen bluePen = new Pen(Color.Blue, 8);	
			Pen redPen = new Pen(Color.Red, 4);
			// Setting DashCap styles 	
			blackPen.StartCap = LineCap.DiamondAnchor;
			blackPen.EndCap = LineCap.SquareAnchor;
			blackPen.DashStyle = DashStyle.DashDotDot;
			blackPen.DashPattern = new float[]{10};
			blackPen.DashCap = DashCap.Triangle;
			// Set blue pen dash style and dash cap
			bluePen.DashStyle = DashStyle.DashDotDot;
			bluePen.DashCap = DashCap.Round;
			// Set red pen line cap and line dash styles
			redPen.StartCap = LineCap.Round;
			redPen.EndCap = LineCap.DiamondAnchor;
			redPen.DashCap = DashCap.Triangle;
			redPen.DashStyle = DashStyle.DashDot;
			redPen.DashOffset = 3.4f;
			// Draw a rectangle
			g.DrawRectangle(blackPen, 20, 20, 200, 100);
			// Draw an ellipse
			g.DrawEllipse(bluePen, 20, 150, 200, 100);
			// Draw a curve
			PointF pt1 = new PointF( 90.0F,  40.0F);
			PointF pt2 = new PointF(130.0F,  80.0F);
			PointF pt3 = new PointF(200.0F, 100.0F);
			PointF pt4 = new PointF(220.0F, 120.0F);
			PointF pt5 = new PointF(250.0F, 250.0F);
			PointF[] ptsArray =
			{
				pt1, pt2, pt3, pt4, pt5
			};
			g.DrawCurve(redPen, ptsArray);
			// Dispose
			blackPen.Dispose();
			g.Dispose();
		}

		private void CustomLineCap_Click(object sender, System.EventArgs e)
		{
			// Create a graphic 
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);	
			g.SmoothingMode = SmoothingMode.AntiAlias;
			Pen redPen = new Pen(Color.Red, 20); 
            redPen.LineJoin = LineJoin.Bevel;
			redPen.LineJoin = LineJoin.Miter;
			redPen.LineJoin = LineJoin.MiterClipped;
			redPen.LineJoin = LineJoin.Round;
 			Point[] pts = 
			{
				new Point(150, 20), 
 				new Point(50, 20), 
 				new Point(80, 60), 
 				new Point(50, 150), 
 				new Point(150, 150)
			}; 
			g.DrawLines(redPen, pts); 
			Point[] pts1 = 
			{
				new Point(200, 20), 
				new Point(300, 20),
				new Point(300, 120),
				new Point(200, 120),
				new Point(200, 20)
				
			}; 
			g.DrawLines(redPen, pts1);			
			// Dispose
			redPen.Dispose();
			g.Dispose();	
		}
	}
}



