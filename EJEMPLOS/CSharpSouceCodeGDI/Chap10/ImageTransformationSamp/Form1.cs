using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ImageTransformationSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem RotationMenu;
		private System.Windows.Forms.MenuItem ScalingMenu;
		private System.Windows.Forms.MenuItem TranslationMenu;
		private System.Windows.Forms.MenuItem ReflectionMenu;
		private System.Windows.Forms.MenuItem ShearMenu;
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
			this.RotationMenu = new System.Windows.Forms.MenuItem();
			this.ScalingMenu = new System.Windows.Forms.MenuItem();
			this.TranslationMenu = new System.Windows.Forms.MenuItem();
			this.ReflectionMenu = new System.Windows.Forms.MenuItem();
			this.ShearMenu = new System.Windows.Forms.MenuItem();
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
																					  this.RotationMenu,
																					  this.ScalingMenu,
																					  this.TranslationMenu,
																					  this.ReflectionMenu,
																					  this.ShearMenu});
			this.menuItem1.Text = "Image Transformation";
			// 
			// RotationMenu
			// 
			this.RotationMenu.Index = 0;
			this.RotationMenu.Text = "Rotation";
			this.RotationMenu.Click += new System.EventHandler(this.RotationMenu_Click);
			// 
			// ScalingMenu
			// 
			this.ScalingMenu.Index = 1;
			this.ScalingMenu.Text = "Scaling";
			this.ScalingMenu.Click += new System.EventHandler(this.ScalingMenu_Click);
			// 
			// TranslationMenu
			// 
			this.TranslationMenu.Index = 2;
			this.TranslationMenu.Text = "Translation";
			this.TranslationMenu.Click += new System.EventHandler(this.TranslationMenu_Click);
			// 
			// ReflectionMenu
			// 
			this.ReflectionMenu.Index = 3;
			this.ReflectionMenu.Text = "Reflection";
			this.ReflectionMenu.Click += new System.EventHandler(this.ReflectionMenu_Click);
			// 
			// ShearMenu
			// 
			this.ShearMenu.Index = 4;
			this.ShearMenu.Text = "Shear";
			this.ShearMenu.Click += new System.EventHandler(this.ShearMenu_Click);
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

		private void RotationMenu_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Bitmap curBitmap = new Bitmap(@"roses.jpg");		
			g.DrawImage(curBitmap, 0, 0, 200, 200);
			// Create a Matrix, call its Rotate method
			// and set it as Graphics.Transform
			Matrix X = new Matrix();
			X.Rotate(30);
			g.Transform = X;		
			// Draw Image
			g.DrawImage(curBitmap, 
				new Rectangle(205, 0, 200, 200),  
				0, 0, curBitmap.Width, 
				curBitmap.Height, 
				GraphicsUnit.Pixel) ; 
			// Dispose
			curBitmap.Dispose();
			g.Dispose();		
		}

		private void ScalingMenu_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Bitmap curBitmap = new Bitmap(@"roses.jpg");		
			Matrix X = new Matrix();
			X.Scale(2, 1, MatrixOrder.Append);
			g.Transform = X;		
			g.DrawImage(curBitmap, 
				new Rectangle(0, 0, 200, 200),  
				0, 0, curBitmap.Width, 
				curBitmap.Height, 
				GraphicsUnit.Pixel) ; 
			// Dispose
			curBitmap.Dispose();
			g.Dispose();
		}

		private void TranslationMenu_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Bitmap curBitmap = new Bitmap(@"roses.jpg");		
			Matrix X = new Matrix();
			X.Translate(100, 100); 
			g.Transform = X;
			g.DrawImage(curBitmap, 
				new Rectangle(0, 0, 200, 200),  
				0, 0, curBitmap.Width, 
				curBitmap.Height, 
				GraphicsUnit.Pixel) ; 
			// Dispose
			curBitmap.Dispose();
			g.Dispose();
		
		}

		private void ReflectionMenu_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Bitmap curBitmap = new Bitmap(@"roses.jpg");		
			Matrix X = new Matrix();
			X.Invert(); 
			g.Transform = X;
			g.DrawImage(curBitmap, 
				new Rectangle(0, 0, 200, 200),  
				0, 0, curBitmap.Width, 
				curBitmap.Height, 
				GraphicsUnit.Pixel) ; 
			// Dispose
			curBitmap.Dispose();
			g.Dispose();
		
		}

		private void ShearMenu_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Bitmap curBitmap = new Bitmap(@"roses.jpg");		
			Matrix X = new Matrix();
			X.Shear(2, 1);
			g.Transform = X;		
			g.DrawImage(curBitmap, 
				new Rectangle(0, 0, 200, 200),  
				0, 0, curBitmap.Width, 
				curBitmap.Height, 
				GraphicsUnit.Pixel) ; 
			// Dispose
			curBitmap.Dispose();
			g.Dispose();		
		}
	}
}



