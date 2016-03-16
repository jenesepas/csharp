using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace PensSamp
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
		private System.Windows.Forms.MenuItem GetPenTypes;
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
			this.GetPenTypes = new System.Windows.Forms.MenuItem();
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
																																							this.menuItem6,
																																							this.GetPenTypes});
			this.menuItem1.Text = "Pen Samples";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Constructor";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Width_Other Properties";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "Caps";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "Transformation";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 4;
			this.menuItem6.Text = "Other Objects";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// GetPenTypes
			// 
			this.GetPenTypes.Index = 5;
			this.GetPenTypes.Text = "Get Pen Types";
			this.GetPenTypes.Click += new System.EventHandler(this.GetPenTypes_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 297);
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

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
			
		}

	  private void menuItem2_Click(object sender, 
      System.EventArgs e)
    {
      // Create a Graphics object and set it clear
      Graphics g = this.CreateGraphics(); 
      g.Clear(this.BackColor);
      // Create a solid and hatch brush
      SolidBrush blueBrush =
        new SolidBrush(Color.Blue);
      HatchBrush hatchBrush = 
        new HatchBrush(HatchStyle.DashedVertical, 
        Color.Black, Color.Green);
      // Create a pen from a solid brush with
      // width 3
      Pen pn1 = new Pen( blueBrush, 3);
      // Create a pen from a hatch brush
      Pen pn2 = new Pen(hatchBrush, 8);
      // Create a pen from a Color structure
      Pen pn3 = new Pen(Color.Red);
      // Draw a line, ellipse, and rectangle
      g.DrawLine(pn1, 
        new Point(10, 40), new Point(10, 90));
      g.DrawEllipse(pn2, 20, 50, 100, 100);
      g.DrawRectangle(pn3, 40, 90, 100, 100);
      // Dispose
      pn1.Dispose();
      pn2.Dispose();
      pn3.Dispose();
	  blueBrush.Dispose();
	  hatchBrush.Dispose();
      g.Dispose();
    }

		
		private void menuItem3_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);
			// Create three pens
			Pen pn1 = new Pen( Color.Red, 3);
			Pen pn2 = new Pen(Color.Blue);
			Pen pn3 = new Pen(Color.Red);
			SolidBrush greenBrush = new SolidBrush(Color.Green);		
			// Setting Pen1 properties
			pn1.Color = Color.Black;
			// CAUTION: Setting Brush property of the Pen
			// object will remove the color set by using Color
			// property and vice versa.
			pn1.Brush = greenBrush;
			pn1.Width = 4;
			pn1.Alignment = PenAlignment.Left;
			// Getting PenType value
			PenType style = pn1.PenType;		
			// Setting Pen2 and Pen3 properties
			pn2.Width = 3;
			pn2.Alignment = PenAlignment.Inset;
			pn3.Width = 3;
			pn3.Alignment = PenAlignment.Outset;
			// Drawing Lines
			g.DrawLine(pn1, new Point(10, 10), new Point(150, 10));
			g.DrawLine(pn2, new Point(10, 30), new Point(200, 30));
			g.DrawLine(pn3, new Point(10, 50), new Point(250, 50));
			// Releasing resorces. If you don't release using Dispose, 
			// GC (Garbase Collector) takes care for you
			pn1.Dispose();
			pn2.Dispose();
			pn3.Dispose();
			g.Dispose();		
		}
	  private void menuItem4_Click(object sender, 
      System.EventArgs e)
    {
      Graphics g = this.CreateGraphics(); 
      g.Clear(this.BackColor);
      // Create three pens
      Pen redPen = new Pen(Color.Red, 6);
      Pen bluePen = new Pen(Color.Blue, 7);
      Pen greenPen = new Pen(Color.Green, 7);
      redPen.Width = 8;
      // Setting line styles    
      redPen.DashStyle = DashStyle.Dash;
      redPen.SetLineCap(LineCap.DiamondAnchor, 
      LineCap.ArrowAnchor, DashCap.Flat);
      greenPen.DashStyle = DashStyle.DashDotDot;
      greenPen.StartCap = LineCap.Triangle;
      greenPen.EndCap = LineCap.Triangle;
      greenPen.DashCap = DashCap.Triangle;
      greenPen.DashStyle = DashStyle.Dot;
      greenPen.DashOffset = 3.4f;
      bluePen.StartCap = LineCap.Square;
      bluePen.EndCap = LineCap.SquareAnchor;
      greenPen.SetLineCap(LineCap.RoundAnchor, 
        LineCap.Square, DashCap.Round);
      // Drawing Lines
      g.DrawLine(redPen, new Point(20, 50), 
        new Point(150, 50));
      g.DrawLine(greenPen, new Point(30, 80), 
        new Point(200, 80));
      g.DrawLine(bluePen, new Point(30, 120), 
        new Point(250, 120));
      // Releasing resorces. If you don't release 
      // using Dispose, 
      // GC (Garbase Collector) takes care for you
      redPen.Dispose();
      greenPen.Dispose();
      greenPen.Dispose();
      g.Dispose();    
    }

	  private void menuItem5_Click(object sender,
      System.EventArgs e)
    {
      Graphics g = this.CreateGraphics(); 
      g.Clear(this.BackColor);
      // Create a Pen object.
      Pen bluePen = new Pen(Color.Blue, 10);
      Pen redPen = new Pen(Color.Red, 5);
      // Applying rotate and scale transformation
      bluePen.ScaleTransform(3, 1);
      g.DrawEllipse(bluePen, 20, 20, 100, 50);
      g.DrawRectangle(redPen, 20, 120, 100, 50);
      bluePen.RotateTransform(90, MatrixOrder.Append);
      redPen.ScaleTransform(4, 2, MatrixOrder.Append);
      g.DrawEllipse(bluePen, 220, 20, 100, 50);
      g.DrawRectangle(redPen, 220, 120, 100, 50);
      // Dispose
      redPen.Dispose();
      bluePen.Dispose();
      g.Dispose();  
    }

		private void menuItem6_Click(object sender,
      System.EventArgs e)
    {
      Graphics g = this.CreateGraphics(); 
      g.Clear(this.BackColor);
      Pen redPen = new Pen(
        new SolidBrush(Color.Red), 4); 
      Pen bluePen = new Pen(
        new SolidBrush(Color.Blue), 5); 
      Pen blackPen = new Pen(
        new SolidBrush(Color.Black), 3); 
      // Setting line styles    
      redPen.DashStyle = DashStyle.Dash;
      redPen.SetLineCap(LineCap.DiamondAnchor,
        LineCap.ArrowAnchor, DashCap.Flat);
      bluePen.DashStyle = DashStyle.DashDotDot;
      bluePen.StartCap = LineCap.Triangle;
      bluePen.EndCap = LineCap.Triangle;
      bluePen.DashCap = DashCap.Triangle;
      blackPen.DashStyle = DashStyle.Dot;
      blackPen.DashOffset = 3.4f;
      blackPen.SetLineCap(LineCap.RoundAnchor, 
        LineCap.Square, DashCap.Round);
      // Drawing objects      
      g.DrawArc(redPen, 10.0F, 10.0F, 50, 
        100, 45.0F, 90.0F);    
      g.DrawRectangle(bluePen, 60, 80, 140, 50);
      g.DrawBezier(blackPen, 20.0F, 30.0F,
        100.0F, 200.0F, 40.0F, 400.0F,
        100.0F, 200.0F);
      g.DrawEllipse(redPen, 50, 50, 200, 100 );   
      // Dispose
      redPen.Dispose();
      bluePen.Dispose();
      blackPen.Dispose();
      g.Dispose();    
    }

	  private void GetPenTypes_Click(object sender, 
      System.EventArgs e)
    {
      // Create a Graphics object
      Graphics g = this.CreateGraphics(); 
      g.Clear(this.BackColor);
      // Create three different types of brushes
      Image img = new Bitmap("roses.jpg");   
      SolidBrush redBrush = new SolidBrush(Color.Red);
      TextureBrush txtrBrush = 
        new TextureBrush(img); 
      LinearGradientBrush lgBrush = 
        new LinearGradientBrush(
        new Rectangle(10, 10, 10, 10), 
        Color.Red, Color.Black, 45.0f);   
      // Create pens from brushes
      Pen pn1 = new Pen(redBrush, 4); 
      Pen pn2 = new Pen(txtrBrush, 20); 
      Pen pn3 = new Pen(lgBrush, 20); 
      // Drawing objects      
      g.DrawEllipse(pn1, 100, 100, 50, 50);    
      g.DrawRectangle(pn2, 80, 80, 100, 100);
      g.DrawEllipse(pn3, 30, 30, 200, 200 );  

      // Get pen types 
      string str = "Pen1 Type: "+ 
        pn1.PenType.ToString() + "\n";
      str += "Pen2 Type: "+ 
        pn2.PenType.ToString() + "\n";
      str += "Pen3 Type: "+ 
        pn3.PenType.ToString();
      MessageBox.Show(str);

      // Dispose
		  redBrush.Dispose();
		  txtrBrush.Dispose();
		  lgBrush.Dispose();
		  img.Dispose();
      pn1.Dispose();
      pn2.Dispose();
      pn3.Dispose();
      g.Dispose();  
    }
	}
}




