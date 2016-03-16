 using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BlendingSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem ColorBlending;
		private System.Windows.Forms.MenuItem AlphaBlending;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem EllipseMenu;
		private System.Windows.Forms.MenuItem RectangleMenu;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem MixedBlendingMenu;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem SetBlendTriangularShapeMenu;
		private System.Windows.Forms.MenuItem SetSigmaBellShapeMenu;
		private System.Windows.Forms.MenuItem BlendPropMenu;
		private System.Windows.Forms.MenuItem InterpolationColorsMenu;
		private System.Windows.Forms.MenuItem GammaCorrectionMenu;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem PathGradientProsMenu;
		private System.Windows.Forms.MenuItem PathGBBlend;
		private System.Windows.Forms.MenuItem PathGBInterPol;
		private System.Windows.Forms.MenuItem AlphaBPensBrushes;
		private System.Windows.Forms.MenuItem AlphaBImages;
		private System.Windows.Forms.MenuItem AlphaBCompGammaCorr;
		private System.Windows.Forms.MenuItem AlphaBMatrix;
		private System.Windows.Forms.MenuItem CompBlendTSigmaBell;
		private System.Windows.Forms.MenuItem MixedBlending;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem CompBlendTSigmaBellMEnu;
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
			this.ColorBlending = new System.Windows.Forms.MenuItem();
			this.AlphaBlending = new System.Windows.Forms.MenuItem();
			this.MixedBlendingMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.EllipseMenu = new System.Windows.Forms.MenuItem();
			this.RectangleMenu = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.SetBlendTriangularShapeMenu = new System.Windows.Forms.MenuItem();
			this.SetSigmaBellShapeMenu = new System.Windows.Forms.MenuItem();
			this.BlendPropMenu = new System.Windows.Forms.MenuItem();
			this.InterpolationColorsMenu = new System.Windows.Forms.MenuItem();
			this.GammaCorrectionMenu = new System.Windows.Forms.MenuItem();
			this.CompBlendTSigmaBell = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.PathGradientProsMenu = new System.Windows.Forms.MenuItem();
			this.PathGBBlend = new System.Windows.Forms.MenuItem();
			this.PathGBInterPol = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.AlphaBPensBrushes = new System.Windows.Forms.MenuItem();
			this.AlphaBImages = new System.Windows.Forms.MenuItem();
			this.AlphaBCompGammaCorr = new System.Windows.Forms.MenuItem();
			this.AlphaBMatrix = new System.Windows.Forms.MenuItem();
			this.MixedBlending = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.CompBlendTSigmaBellMEnu = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ColorBlending,
																					  this.AlphaBlending,
																					  this.MixedBlendingMenu,
																					  this.menuItem6});
			this.menuItem1.Text = "Blending";
			// 
			// ColorBlending
			// 
			this.ColorBlending.Index = 0;
			this.ColorBlending.Text = "Color Blending";
			this.ColorBlending.Click += new System.EventHandler(this.ColorBlending_Click);
			// 
			// AlphaBlending
			// 
			this.AlphaBlending.Index = 1;
			this.AlphaBlending.Text = "Alpha Blending";
			this.AlphaBlending.Click += new System.EventHandler(this.AlphaBlending_Click);
			// 
			// MixedBlendingMenu
			// 
			this.MixedBlendingMenu.Index = 2;
			this.MixedBlendingMenu.Text = "Mixed Blending";
			this.MixedBlendingMenu.Click += new System.EventHandler(this.MixedBlendingMenu_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.EllipseMenu,
																					  this.RectangleMenu,
																					  this.menuItem3,
																					  this.menuItem5});
			this.menuItem2.Text = "Color Blending";
			// 
			// EllipseMenu
			// 
			this.EllipseMenu.Index = 0;
			this.EllipseMenu.Text = "Ellipse";
			this.EllipseMenu.Click += new System.EventHandler(this.EllipseMenu_Click);
			// 
			// RectangleMenu
			// 
			this.RectangleMenu.Index = 1;
			this.RectangleMenu.Text = "Rectangle";
			this.RectangleMenu.Click += new System.EventHandler(this.RectangleMenu_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.SetBlendTriangularShapeMenu,
																					  this.SetSigmaBellShapeMenu,
																					  this.BlendPropMenu,
																					  this.InterpolationColorsMenu,
																					  this.GammaCorrectionMenu,
																					  this.CompBlendTSigmaBell,
																					  this.CompBlendTSigmaBellMEnu});
			this.menuItem3.Text = "LinearGradientBrush";
			// 
			// SetBlendTriangularShapeMenu
			// 
			this.SetBlendTriangularShapeMenu.Index = 0;
			this.SetBlendTriangularShapeMenu.Text = "SetBlendTriangularShape";
			this.SetBlendTriangularShapeMenu.Click += new System.EventHandler(this.SetBlendTriangularShapeMenu_Click);
			// 
			// SetSigmaBellShapeMenu
			// 
			this.SetSigmaBellShapeMenu.Index = 1;
			this.SetSigmaBellShapeMenu.Text = "SetSigmaBellShape";
			this.SetSigmaBellShapeMenu.Click += new System.EventHandler(this.SetSigmaBellShapeMenu_Click);
			// 
			// BlendPropMenu
			// 
			this.BlendPropMenu.Index = 2;
			this.BlendPropMenu.Text = "Blend";
			this.BlendPropMenu.Click += new System.EventHandler(this.BlendPropMenu_Click);
			// 
			// InterpolationColorsMenu
			// 
			this.InterpolationColorsMenu.Index = 3;
			this.InterpolationColorsMenu.Text = "InterpolationColors";
			this.InterpolationColorsMenu.Click += new System.EventHandler(this.InterpolationColorsMenu_Click);
			// 
			// GammaCorrectionMenu
			// 
			this.GammaCorrectionMenu.Index = 4;
			this.GammaCorrectionMenu.Text = "GammaCorrection";
			this.GammaCorrectionMenu.Click += new System.EventHandler(this.GammaCorrectionMenu_Click);
			// 
			// CompBlendTSigmaBell
			// 
			this.CompBlendTSigmaBell.Index = 5;
			this.CompBlendTSigmaBell.Text = "Compare BlendTriangular and SigmaBell Shapes";
			this.CompBlendTSigmaBell.Click += new System.EventHandler(this.CompBlendTSigmaBell_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.PathGradientProsMenu,
																					  this.PathGBBlend,
																					  this.PathGBInterPol});
			this.menuItem5.Text = "PathGradientBrush";
			// 
			// PathGradientProsMenu
			// 
			this.PathGradientProsMenu.Index = 0;
			this.PathGradientProsMenu.Text = "Properties";
			this.PathGradientProsMenu.Click += new System.EventHandler(this.PathGradientProsMenu_Click);
			// 
			// PathGBBlend
			// 
			this.PathGBBlend.Index = 1;
			this.PathGBBlend.Text = "Blend";
			this.PathGBBlend.Click += new System.EventHandler(this.PathGBBlend_Click);
			// 
			// PathGBInterPol
			// 
			this.PathGBInterPol.Index = 2;
			this.PathGBInterPol.Text = "InterpolationColors";
			this.PathGBInterPol.Click += new System.EventHandler(this.PathGBInterPol_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AlphaBPensBrushes,
																					  this.AlphaBImages,
																					  this.AlphaBCompGammaCorr,
																					  this.AlphaBMatrix,
																					  this.MixedBlending});
			this.menuItem4.Text = "Alpha Blending";
			// 
			// AlphaBPensBrushes
			// 
			this.AlphaBPensBrushes.Index = 0;
			this.AlphaBPensBrushes.Text = "Pens and Brushes";
			this.AlphaBPensBrushes.Click += new System.EventHandler(this.AlphaBPensBrushes_Click);
			// 
			// AlphaBImages
			// 
			this.AlphaBImages.Index = 1;
			this.AlphaBImages.Text = "Images and Alpha Blending";
			this.AlphaBImages.Click += new System.EventHandler(this.AlphaBImages_Click);
			// 
			// AlphaBCompGammaCorr
			// 
			this.AlphaBCompGammaCorr.Index = 2;
			this.AlphaBCompGammaCorr.Text = "CompositeMode and GammaCorrection";
			this.AlphaBCompGammaCorr.Click += new System.EventHandler(this.AlphaBCompGammaCorr_Click);
			// 
			// AlphaBMatrix
			// 
			this.AlphaBMatrix.Index = 3;
			this.AlphaBMatrix.Text = "Matrix In Alpha Blending";
			this.AlphaBMatrix.Click += new System.EventHandler(this.AlphaBMatrix_Click);
			// 
			// MixedBlending
			// 
			this.MixedBlending.Index = 4;
			this.MixedBlending.Text = "Mixed Blending";
			this.MixedBlending.Click += new System.EventHandler(this.MixedBlending_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 3;
			this.menuItem6.Text = "CompBlendTSigmaBell";
			// 
			// CompBlendTSigmaBellMEnu
			// 
			this.CompBlendTSigmaBellMEnu.Index = 6;
			this.CompBlendTSigmaBellMEnu.Text = "CompBlendTSigmaBell";
			this.CompBlendTSigmaBellMEnu.Click += new System.EventHandler(this.CompBlendTSigmaBellMEnu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 317);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Blending Sample";

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

private void ColorBlending_Click(object sender, System.EventArgs e)
{
	Graphics g = this.CreateGraphics();
	g.Clear(this.BackColor);
	// Create three linear gradient brushes
	LinearGradientBrush rgBrush = new LinearGradientBrush(
		new RectangleF(20, 20, 100, 100), 
		Color.Red, Color.Green,
		LinearGradientMode.Horizontal);
	LinearGradientBrush yrBrush = new LinearGradientBrush(
		new RectangleF(140, 20, 150, 300), 
		Color.Yellow, Color.Red,
		LinearGradientMode.ForwardDiagonal);	
	LinearGradientBrush rbBrush = new LinearGradientBrush(
		new RectangleF(10, 10, 50, 50),
		Color.Red, Color.Blue,
		LinearGradientMode.ForwardDiagonal);	
	// Use different brush to draw different graphics
	// object
	g.FillRectangle(rgBrush, 20, 20, 100, 100);
	g.FillEllipse(yrBrush, 140, 20, 200, 200);
	g.DrawString("Color Blending", new Font("Tahoma", 30),
		rbBrush, new RectangleF(100, 240, 300, 300) ); 
	// Dispose
	g.Dispose();
}

		private void AlphaBlending_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create Image from a file
			Image curImage = Image.FromFile("Neel3.jpg");
			g.DrawImage(curImage, 0, 0, curImage.Width, curImage.Height);
			// Create opaque, semi transparent, and full 
			// transparent pens
			Pen opqPen =
				new Pen(Color.FromArgb(255, 0, 255, 0), 10);
			Pen transPen = 
				new Pen(Color.FromArgb(128, 0, 255, 0), 10);
			Pen totTransPen = 
				new Pen(Color.FromArgb(40, 0, 255, 0), 10);
			// Use different pen to draw different graphics
			// object
			g.DrawLine(opqPen, 10, 10, 200, 10);
			g.DrawLine(transPen, 10, 30, 200, 30);
			g.DrawLine(totTransPen, 10, 50, 200, 50);
			SolidBrush semiTransBrush = 
				new SolidBrush(Color.FromArgb(90, 255, 255, 0));
			g.DrawString("Atlanta Photo \nDate: 04/09/2001",
				new Font("Verdana", 14), semiTransBrush,
				new RectangleF(20, 100, 300, 100) );
			// Dispose
			g.Dispose();
		}

		private void EllipseMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Set smmoothing mode and compositing quality
            g.SmoothingMode = SmoothingMode.AntiAlias;
			g.CompositingQuality= 
				CompositingQuality.HighQuality;
			// Create a graphics path and
			// add an ellipse to it
			GraphicsPath path = new GraphicsPath();
			path.AddEllipse(20, 20, 200, 200);
			// Create a path gradient brush with the path
			PathGradientBrush pthGrBrush =
				new PathGradientBrush(path);
			// Create a semi transparent color
			Color transBlackColor = 
				Color.FromArgb(90, 255, 255, 255);
            // Set SurroundColors and CenterColor 
			// of the brush
			Color[] color = {Color.Black};
			pthGrBrush.SurroundColors = color;
			pthGrBrush.CenterColor = Color.Red;
			// Use bush to fill a path
			g.FillPath(pthGrBrush, path);
			// Dispose
			g.Dispose();
		}

		private void RectangleMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);

			LinearGradientBrush rgBrush = 
				new LinearGradientBrush(
				new RectangleF(0, 0, /*50*/ 200, /*50 */ 200), 
				Color.Red, Color.Green,
				LinearGradientMode.Horizontal);
			g.FillRectangle(rgBrush, 0, 0, 200, 50);
		
			// Dispose
			g.Dispose();
		}

		private void MixedBlendingMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Image from a file
			Image curImage = Image.FromFile("Neel3.jpg");
			// Draw Image
			g.DrawImage(curImage, 0, 0, 
				curImage.Width, curImage.Height);
			// Create a graphics path and add a rectangle
			GraphicsPath path = new GraphicsPath();
			path.AddRectangle(new Rectangle(0, 0, 182, 300));
			// Create a path gradient brush
			PathGradientBrush grBrush = 
				new PathGradientBrush(path);
			Color transBlackColor = 
				Color.FromArgb(60, 0, 255, 0);
			// Create a array of colors
			Color[] color = {transBlackColor};
			// Set surround and center colros
			grBrush.SurroundColors = color;
			grBrush.CenterColor = Color.Yellow;
			// Fill path
			g.FillPath(grBrush, path);

			// Dispose
			g.Dispose();
		}

		private void SetBlendTriangularShapeMenu_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a rectangle
            Rectangle rect = new Rectangle(20, 20, 100, 50);
            // Create a linear gradient brush
            LinearGradientBrush rgBrush = 
                new LinearGradientBrush(
                rect, Color.Red, Color.Green,
                0.0f, true);        
            // Fill rectangle
            g.FillRectangle(rgBrush, rect);
            rect.Y = 90;
            // set blend triangular shape
            rgBrush.SetBlendTriangularShape(0.5f, 1.0f);            
            // Fill rectangle again
            g.FillRectangle(rgBrush, rect);
			// Dispose
			g.Dispose();		
		}

		private void SetSigmaBellShapeMenu_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a rectangle
			Rectangle rect = new Rectangle(20, 20, 100, 50);
			// Create a linear gradient brush
			LinearGradientBrush rgBrush = 
				new LinearGradientBrush(
				rect, Color.Red, Color.Green,
				0.0f, true);			
			// Fill rectangle
			g.FillRectangle(rgBrush, rect);
			rect.Y = 90;
			// set signma bell shape
			rgBrush.SetSigmaBellShape(0.5f, 1.0f);			
			// Fill rectangle again
			g.FillRectangle(rgBrush, rect);	
			// Dispose
			g.Dispose();		
		}

		private void BlendPropMenu_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a linear gradient brush
			LinearGradientBrush brBrush = 
				new LinearGradientBrush(
				new Point(0, 0), new Point(50, 20),
				Color.Blue, Color.Red);  
			// Create a Blend object
			Blend blend = new Blend();
			float[] factArray = {0.0f, 0.3f, 0.5f, 1.0f};
			float[] posArray   = {0.0f, 0.2f, 0.6f, 1.0f};
			// Set Blend's factors and positions
			blend.Factors = factArray;
			blend.Positions = posArray;
			// Set Blend property of the brush
			brBrush.Blend = blend;
            // Fill a rectangel and ellipse
			g.FillRectangle(brBrush, 10, 20, 200, 100);
			g.FillEllipse(brBrush, 10, 150, 120, 120);		
			// Dispose
			g.Dispose();
		}

		private void InterpolationColorsMenu_Click
			(object sender,	System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a LinearGradientBrush
			LinearGradientBrush brBrush = 
				new LinearGradientBrush(
				new Point(0, 0), new Point(50, 20),
				Color.Blue, Color.Red);  
			Rectangle rect = 
				new Rectangle(20, 20, 200, 100);
			// Create color and points array
			Color[] clrArray = 
			{
				Color.Red, Color.Blue, Color.Green,
                Color.Pink, Color.Yellow, 
				Color.DarkTurquoise
			};  
			float[] posArray = 
			{
				0.0f, 0.2f, 0.4f, 
				0.6f, 0.8f, 1.0f
			};    
			// Create a ColorBlend object and 
			// set its Colors and positions
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Colors = clrArray;
			colorBlend.Positions = posArray;
			// Set InterpolationColors property
			brBrush.InterpolationColors = colorBlend;
			// Draw shapes		
			g.FillRectangle(brBrush, rect);
			rect.Y = 150;
			rect.Width = 100;
			rect.Height = 100;
			g.FillEllipse(brBrush, rect);			
			// Dispose
			g.Dispose();		
		}

		private void GammaCorrectionMenu_Click(
			object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a rectangle
			Rectangle rect = 
				new Rectangle(20, 20, 100, 50);
			// Create a linear gradient brush
			LinearGradientBrush rgBrush = 
				new LinearGradientBrush(
				rect, Color.Red, Color.Green,
				0.0f, true);		
			// Fill rectangle
			g.FillRectangle(rgBrush, rect);
			rect.Y = 90;
			// Set gamma collection of the brush
			rgBrush.GammaCorrection = true; 
			// Fill rectangle
			g.FillRectangle(rgBrush, rect);
			// Dispose
			g.Dispose();	
		}

		private void PathGradientProsMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Set smoothing mode as anti alias
			g.SmoothingMode = SmoothingMode.AntiAlias;
			// Create a graphics path and add a rectangle
			GraphicsPath path = new GraphicsPath();
			Rectangle rect = 
				new Rectangle(10, 20, 200, 200);
			path.AddRectangle(rect);
			// Create path gradient brush 
			PathGradientBrush rgBrush = 
				new PathGradientBrush(path);
			// Set brush's center and focusscale colors
			rgBrush.CenterColor = Color.Red; 
			rgBrush.FocusScales = 
				new PointF(0.6f, 0.2f);
			Color[] colors = {Color.Green, 
			Color.Blue, Color.Red, Color.Yellow};
			// Set surrounded colors
			rgBrush.SurroundColors = colors;
			// Fill ellipse
			g.FillEllipse(rgBrush, rect);
			// Dispose
			g.Dispose();

		}

		private void PathGBInterPol_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create color and points array
			Color[] clrArray = 
				{Color.Red, Color.Blue, Color.Green,
  			   Color.Pink, Color.Yellow, 
					Color.DarkTurquoise};  
			float[] posArray = 
				{0.0f, 0.2f, 0.4f, 0.6f, 0.8f, 1.0f};    
			// Create a ColorBlend object and set its Colors and 
			// positions
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Colors = clrArray;
			colorBlend.Positions = posArray;
			// Set smoothing mode of Graphics
			g.SmoothingMode = SmoothingMode.AntiAlias;
			// Create a Graphics path and add a rectangle
			GraphicsPath path = new GraphicsPath();
			Rectangle rect = new Rectangle(10, 20, 200, 200);
			path.AddRectangle(rect);
			// Create a path gradiant brush
			PathGradientBrush rgBrush = 
					new PathGradientBrush(path);
			// Set interpolation colors and focus scales
			rgBrush.InterpolationColors =  colorBlend; 
			rgBrush.FocusScales = new PointF(0.6f, 0.2f);
			Color[] colors = {Color.Green};
			// Set ceneter and surrounded colors
			rgBrush.CenterColor = Color.Red;
			rgBrush.SurroundColors = colors;
			// Draw ellipse
			g.FillEllipse(rgBrush, rect);
			// Dispose
			g.Dispose();		
		}

		private void PathGBBlend_Click(object sender,
			System.EventArgs e)
		{			
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Creat Blend object
			Blend blend = new Blend();
			// Create point and position arrays
			float[] factArray = {0.0f, 0.3f, 0.5f, 1.0f};
			float[] posArray   = {0.0f, 0.2f, 0.6f, 1.0f};
			// Set factors and positions of Blend
			blend.Factors = factArray;
			blend.Positions = posArray;
			// Set smoothing mode of Graphics
			g.SmoothingMode = SmoothingMode.AntiAlias;
			// Create path and add a rectangle
			GraphicsPath path = new GraphicsPath();
			Rectangle rect = new Rectangle(10, 20, 200, 200);
			path.AddRectangle(rect);
			// Create path gradient brush
			PathGradientBrush rgBrush = 
				new PathGradientBrush(path);
			// set Blend and FocusScales properties
			rgBrush.Blend = blend; 
			rgBrush.FocusScales = new PointF(0.6f, 0.2f);
			Color[] colors = 
			{
				Color.Green, Color.Blue, 
				Color.Red, Color.Yellow
			};

			// Set CenterColor and SurroundColors 
			rgBrush.CenterColor = Color.Red;
			rgBrush.SurroundColors = colors;
			g.FillEllipse(rgBrush, rect);
			// Dispose
			g.Dispose();	
		}

		private void AlphaBPensBrushes_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create pens with semi transparent colors
			Rectangle rect = 
				new Rectangle(220, 30, 100, 50); 
			Pen transPen = 
				new Pen(Color.FromArgb(128, 255, 255, 255), 10);
			Pen totTransPen = 
				new Pen(Color.FromArgb(40, 0, 255, 0), 10);
			// Draw line, rectangle, ellipse, string using
			// semi transparent colored pens
			g.DrawLine(transPen, 10, 30, 200, 30);
			g.DrawLine(totTransPen, 10, 50, 200, 50);
			g.FillRectangle(new SolidBrush(
				Color.FromArgb(40, 0, 0, 255)), rect);
			rect.Y += 60;
			g.FillEllipse(new SolidBrush(
				Color.FromArgb(20, 255, 255, 0)), rect);
			SolidBrush semiTransBrush = 
				new SolidBrush(Color.FromArgb(90, 0, 50, 255));
			g.DrawString("Some Photo \nDate: 04/09/2001", 
				new Font("Verdana", 14), semiTransBrush,
				new RectangleF(20, 100, 300, 100) );
			// Dispose
			g.Dispose();
		}

		private void AlphaBImages_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Draw an image 
			Image curImage = 
				Image.FromFile("Neel3.jpg");
			g.DrawImage(curImage, 0, 0, 
				curImage.Width, curImage.Height);
			// Create pens and a rectangle
			Rectangle rect = 
				new Rectangle(220, 30, 100, 50); 
			Pen opqPen = 
				new Pen(Color.FromArgb(255, 0, 255, 0), 10);
			Pen transPen = 
				new Pen(Color.FromArgb(128, 255, 255, 255), 10);
			Pen totTransPen = 
				new Pen(Color.FromArgb(40, 0, 255, 0), 10);	
			// Draw lines, rectangle, ellipse and string
			g.DrawLine(opqPen, 10, 10, 200, 10);
			g.DrawLine(transPen, 10, 30, 200, 30);
			g.DrawLine(totTransPen, 10, 50, 200, 50);
			g.FillRectangle(new SolidBrush(
				Color.FromArgb(140, 0, 0, 255)), rect);
			rect.Y += 60;
			g.FillEllipse(new SolidBrush(
				Color.FromArgb(150, 255, 255, 255)), rect);
			SolidBrush semiTransBrush = 
				new SolidBrush(Color.FromArgb(90, 255, 255, 50));
			g.DrawString("Some Photo \nDate: 04/09/2001", 
				new Font("Verdana", 14), semiTransBrush,
				new RectangleF(20, 100, 300, 100) );
			// Dispose
			g.Dispose();
		}

		private void AlphaBCompGammaCorr_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create two rectangles
			Rectangle rect1 = 
				new Rectangle(20, 20, 100, 100);
			Rectangle rect2 = 
				new Rectangle(200, 20, 100, 100);
			// Create two SolidBrush objects
			SolidBrush redBrush = 
				new SolidBrush(Color.FromArgb(150, 255, 0, 0));
			SolidBrush greenBrush = 
				new SolidBrush(Color.FromArgb(180, 0, 255, 0));
			// Create a Bitmap
			Bitmap tempBmp = new Bitmap(200, 150);
			// Create a Graphics objects
			Graphics tempGraphics = 
				Graphics.FromImage(tempBmp);		
			// Set Compositing mode and compositing
			// quality of Graphics object
			tempGraphics.CompositingMode = 
				CompositingMode.SourceOver;
			tempGraphics.CompositingQuality = 
				CompositingQuality.GammaCorrected;
			//tempGraphics.CompositingMode = 
				//CompositingMode.SourceCopy;
			// Fill recntagle
			tempGraphics.FillRectangle(redBrush, rect1);
			rect1.X += 30;
			rect1.Y += 30;
			// Fill ellipse
			tempGraphics.FillEllipse(greenBrush, rect1);		
			g.CompositingQuality = 
				CompositingQuality.GammaCorrected;		
			// Draw image
			g.DrawImage(tempBmp, 0, 0);		
            // Fill rectangle			
			g.FillRectangle(Brushes.Red, rect2);
			rect2.X += 30;
			rect2.Y += 30;
			// Fill ellipse
			g.FillEllipse(Brushes.Green, rect2);
			// Dispose
			greenBrush.Dispose();
			redBrush.Dispose();
			tempBmp.Dispose();
			g.Dispose();		
		}

		private void AlphaBMatrix_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a rectangle 
			Rectangle rect = new Rectangle(20, 20, 200, 100);
			// Create a Bitmap object from a file
			Bitmap bitmap = new Bitmap("MyPhoto.jpg");
			// Create a points array
			float[][] ptsArray =
			{ 
			   new float[] {1, 0, 0, 0, 0},
			   new float[] {0, 1, 0, 0, 0},
			   new float[] {0, 0, 1, 0, 0},
			   new float[] {0, 0, 0, 0.5f, 0}, 
			   new float[] {0, 0, 0, 0, 1}
			}; 
			// Create a ColorMatrix using pts array
			ColorMatrix clrMatrix = 
				new ColorMatrix(ptsArray);
			// Create an ImageAttributes object
			ImageAttributes imgAttributes = 
				new ImageAttributes();
			// Set ColorMatrix of ImageAttributes
			imgAttributes.SetColorMatrix(clrMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap);
			// Fill rectangle
			g.FillRectangle(Brushes.Red, rect);
			rect.Y += 120;
			// Fill ellipse
			g.FillEllipse(Brushes.Black, rect);
			// Draw image using ImageAttributes
			g.DrawImage(bitmap, 
				new Rectangle(0, 0, 
				bitmap.Width, bitmap.Height),  
				0, 0, bitmap.Width, bitmap.Height,
				GraphicsUnit.Pixel, imgAttributes);
			// Dispose
			g.Dispose();
		}

		private void CompBlendTSigmaBell_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a rectangle
			Rectangle rect = new Rectangle(0, 0, 40, 20);
			// Create a linear gradient brush
			LinearGradientBrush rgBrush = 
				new LinearGradientBrush(
				rect, Color.Black, Color.Blue,
				0.0f, true);            
			// Fill rectangle
			g.FillRectangle(rgBrush, 
				new Rectangle(10, 10, 300, 100));
			// set signma bell shape
			rgBrush.SetSigmaBellShape(0.8f, 1.0f);
			// Fill rectangle again
			g.FillRectangle(rgBrush, 
				new Rectangle(10, 120, 300, 100)); 
			// set blend triangular shape
			rgBrush.SetBlendTriangularShape(0.2f, 1.0f);
			// Fill rectangle again
			g.FillRectangle(rgBrush, 
				new Rectangle(10, 240, 300, 100)); 
			// Dispose
			g.Dispose();
		}

		private void MixedBlending_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a LinearGradientBrush
			LinearGradientBrush brBrush = 
				new LinearGradientBrush(
				new Point(0, 0), new Point(50, 20),
				Color.Blue, Color.Red);  
			Rectangle rect = 
				new Rectangle(20, 20, 200, 100);
			// Create color and points array
			Color[] clrArray = 
			{
				Color.Red, Color.Blue, Color.Green,
				Color.Pink, Color.Yellow, 
				Color.DarkTurquoise
			};  
			float[] posArray = 
			{
				0.0f, 0.2f, 0.4f, 
				0.6f, 0.8f, 1.0f
			};    
			// Create a ColorBlend object and 
			// set its Colors and positions
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Colors = clrArray;
			colorBlend.Positions = posArray;
			// Set InterpolationColors property
			brBrush.InterpolationColors = colorBlend;

			// Create a Bitmap object from a file
			Bitmap bitmap = new Bitmap("Neel3.jpg");
			// Create a points array
			float[][] ptsArray =
			{ 
				new float[] {1, 0, 0, 0, 0},
				new float[] {0, 1, 0, 0, 0},
				new float[] {0, 0, 1, 0, 0},
				new float[] {0, 0, 0, 0.5f, 0}, 
				new float[] {0, 0, 0, 0, 1}
			}; 
			// Create a ColorMatrix using pts array
			ColorMatrix clrMatrix = 
				new ColorMatrix(ptsArray);
			// Create an ImageAttributes object
			ImageAttributes imgAttributes = 
				new ImageAttributes();
			// Set ColorMatrix of ImageAttributes
			imgAttributes.SetColorMatrix(clrMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap);
			// Fill rectangle
			g.FillRectangle(brBrush, rect);
			rect.Y += 120;
			// Fill ellipse
			g.FillEllipse(brBrush, rect);
			// Draw image using ImageAttributes
			g.DrawImage(bitmap, 
				new Rectangle(0, 0, 
				bitmap.Width, bitmap.Height),  
				0, 0, bitmap.Width, bitmap.Height,
				GraphicsUnit.Pixel, imgAttributes);

			// Dispose
			brBrush.Dispose();
			bitmap.Dispose();
			g.Dispose();
		}

		private void BlendCenter_Click(object sender, System.EventArgs e)
		{
			
		}

		private void CompBlendTSigmaBellMEnu_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a rectangle
			Rectangle rect = new Rectangle(0, 0, 40, 20);
			// Create a linear gradient brush
			LinearGradientBrush rgBrush = 
				new LinearGradientBrush(
				rect, Color.Black, Color.Blue,
				0.0f, true);            
			// Fill rectangle
			g.FillRectangle(rgBrush, 
				new Rectangle(10, 10, 300, 100));
			// set signma bell shape
			rgBrush.SetSigmaBellShape(0.5f, 1.0f);
			// Fill rectangle again
			g.FillRectangle(rgBrush, 
				new Rectangle(10, 120, 300, 100)); 
			// set blend triangular shape
			rgBrush.SetBlendTriangularShape(0.5f, 1.0f);
			// Fill rectangle again
			g.FillRectangle(rgBrush, 
				new Rectangle(10, 240, 300, 100)); 
			// Dispose
			g.Dispose();
		}
	}
}










