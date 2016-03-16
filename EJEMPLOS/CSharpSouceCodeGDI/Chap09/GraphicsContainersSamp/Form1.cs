using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace GraphicsContainersSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem SaveRestoreMenu;
		private System.Windows.Forms.MenuItem DrawTextMenu;
		private System.Windows.Forms.MenuItem DrawShapesMenu;
		private System.Windows.Forms.MenuItem TransformUnits;
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
			this.SaveRestoreMenu = new System.Windows.Forms.MenuItem();
			this.DrawTextMenu = new System.Windows.Forms.MenuItem();
			this.DrawShapesMenu = new System.Windows.Forms.MenuItem();
			this.TransformUnits = new System.Windows.Forms.MenuItem();
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
																					  this.TransformUnits,
																					  this.SaveRestoreMenu,
																					  this.DrawTextMenu,
																					  this.DrawShapesMenu});
			this.menuItem1.Text = "Graphics Containers";
			// 
			// SaveRestoreMenu
			// 
			this.SaveRestoreMenu.Index = 1;
			this.SaveRestoreMenu.Text = "Save Restore Graphics States";
			this.SaveRestoreMenu.Click += new System.EventHandler(this.SaveRestoreMenu_Click);
			// 
			// DrawTextMenu
			// 
			this.DrawTextMenu.Index = 2;
			this.DrawTextMenu.Text = "Draw Text";
			this.DrawTextMenu.Click += new System.EventHandler(this.DrawTextMenu_Click);
			// 
			// DrawShapesMenu
			// 
			this.DrawShapesMenu.Index = 3;
			this.DrawShapesMenu.Text = "Draw Shapes";
			this.DrawShapesMenu.Click += new System.EventHandler(this.DrawShapesMenu_Click);
			// 
			// TransformUnits
			// 
			this.TransformUnits.Index = 0;
			this.TransformUnits.Text = "Transformation - Units";
			this.TransformUnits.Click += new System.EventHandler(this.TransformUnits_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 357);
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

		private void SaveRestoreMenu_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object and set its 
			// background as form's background
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Page transformation
			g.PageUnit = GraphicsUnit.Pixel;   
			// World transformation
			g.RotateTransform(45, MatrixOrder.Append);
			// Save first graphics state
			GraphicsState gs1 = g.Save();
			// one more tranfromation
			g.TranslateTransform(0, 110);
			// Save graphics state again
			GraphicsState gs2 = g.Save();
			// Dismiss all transformation affects by resetting it
			g.ResetTransform();
			// Draw a simple ellipse with no transformation
			g.DrawEllipse(Pens.Red, 100, 0, 100, 50);
			// Restore first graphics state, which means 
			// new item should rotate 45 degrees
			g.Restore(gs1);
			g.FillRectangle(Brushes.Blue, 100, 0, 100, 50);
			// Restore second graphics state which means
			g.Restore(gs2);
			g.DrawEllipse(Pens.Green, 100, 50, 100, 50);
			//Dispose Graphics object
			g.Dispose();
		}


		private void DrawTextMenu_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object and set its 
			// background as form's background
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create font and brushes
			Font tnrFont = new Font("Times New Roman", 40, 
				FontStyle.Bold, GraphicsUnit.Pixel);
			SolidBrush blueBrush = new SolidBrush(Color.Blue);
			g.TextRenderingHint = TextRenderingHint.SystemDefault;
			// First Container boundary starts here
			GraphicsContainer gContrainer1 = g.BeginContainer(); 
			// Gamma correction value 0 - 12. Default is 4.
			g.TextContrast = 4; 
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
			g.DrawString("Text String", tnrFont, blueBrush,
				new PointF(10, 20));
			// Second Container boundary starts here
			GraphicsContainer gContrainer2 = g.BeginContainer();
			g.TextContrast = 12; 
			g.TextRenderingHint =
				TextRenderingHint.AntiAliasGridFit;
			g.DrawString("Text String", tnrFont, blueBrush,
				new PointF(10, 50));
			// Second container boundary finishes here
			g.EndContainer(gContrainer2);
			// First container boundary finishes here
			g.EndContainer(gContrainer1);
			// Draw string outside of the container
			g.DrawString("Text String", tnrFont, blueBrush,
				new PointF(10, 80));
			// Dispose Graphics object
			blueBrush.Dispose();
			g.Dispose();
		}

		private void DrawShapesMenu_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object and set its 
			// background as form's background
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create pens
			Pen redPen = new Pen(Color.Red, 20);
			Pen bluePen = new Pen(Color.Blue, 10);
			// Create first Graphics container
			GraphicsContainer gContainer1 = g.BeginContainer();
			// Set its properties
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.CompositingQuality = 
				CompositingQuality.GammaCorrected; 
			// Draw graphics objects
			g.DrawEllipse(redPen, 10, 10, 100, 50);
			g.DrawRectangle(bluePen, 210, 0, 100, 100);
			// Create second Graphics container
			GraphicsContainer gContainer2 = g.BeginContainer();
			// Set its properties
			g.SmoothingMode = SmoothingMode.HighSpeed;
			g.CompositingQuality = CompositingQuality.HighSpeed; 
			// Draw graphics objects
			g.DrawEllipse(redPen, 10, 150, 100, 50);
			g.DrawRectangle(bluePen, 210, 150, 100, 100);
			// Destroy containers
			g.EndContainer(gContainer2);
			g.EndContainer(gContainer1);
			//Dispose
			redPen.Dispose();
			bluePen.Dispose();
			g.Dispose();
		}

		private void TransformUnits_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object and set its 
			// background as form's background
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Draw an ellipse with default units
			g.DrawEllipse(Pens.Red, 0, 0, 100, 50);
			// Draw an ellipse with page unit as pixel
			g.PageUnit = GraphicsUnit.Pixel;   			
			g.DrawEllipse(Pens.Red, 0, 0, 100, 50);
			// Draw an ellipse with page unit as millimeter
			g.PageUnit = GraphicsUnit.Millimeter;    
			g.DrawEllipse(Pens.Blue, 0, 0, 100, 50);
			// Draw an ellipse with page unit as point
			g.PageUnit = GraphicsUnit.Point;    
			g.DrawEllipse(Pens.Green, 0, 0, 100, 50);
			//Dispose
			g.Dispose();		
		}
	}
}




