using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace RecoloringSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem TranslationMenu;
		private System.Windows.Forms.MenuItem RotationMenu;
		private System.Windows.Forms.MenuItem ScalingMenu;
		private System.Windows.Forms.MenuItem ShearingMenu;
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
			this.TranslationMenu = new System.Windows.Forms.MenuItem();
			this.RotationMenu = new System.Windows.Forms.MenuItem();
			this.ScalingMenu = new System.Windows.Forms.MenuItem();
			this.ShearingMenu = new System.Windows.Forms.MenuItem();
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
																					  this.TranslationMenu,
																					  this.RotationMenu,
																					  this.ScalingMenu,
																					  this.ShearingMenu});
			this.menuItem1.Text = "Recoloring";
			// 
			// TranslationMenu
			// 
			this.TranslationMenu.Index = 0;
			this.TranslationMenu.Text = "Translation";
			this.TranslationMenu.Click += new System.EventHandler(this.TranslationMenu_Click);
			// 
			// RotationMenu
			// 
			this.RotationMenu.Index = 1;
			this.RotationMenu.Text = "Rotation";
			this.RotationMenu.Click += new System.EventHandler(this.RotationMenu_Click);
			// 
			// ScalingMenu
			// 
			this.ScalingMenu.Index = 2;
			this.ScalingMenu.Text = "Scaling";
			this.ScalingMenu.Click += new System.EventHandler(this.ScalingMenu_Click);
			// 
			// ShearingMenu
			// 
			this.ShearingMenu.Index = 3;
			this.ShearingMenu.Text = "Shearing";
			this.ShearingMenu.Click += new System.EventHandler(this.ShearingMenu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 321);
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
			float degrees = 45.0f;
			double r = degrees*System.Math.PI/180; 

            // Create a Graphics object	
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Bitmap from a file
			Bitmap curBitmap = new Bitmap("roses.jpg");			

			// ColorMatrix elements
			float[][] ptsArray = { 
				 new float[] {(float)System.Math.Cos(r),  
							 (float)System.Math.Sin(r),
							 0,  0, 0},
				 new float[] {(float)-System.Math.Sin(r),
							  (float)-System.Math.Cos(r),  
								  0,  0, 0},
				 new float[] {.50f,  0,  1,  0, 0},
				 new float[] {0,  0,  0,  1, 0},
				 new float[] {0, 0, 0, 0, 1}
			};
			// Create a ColorMatrix
			ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
			// Create ImageAttributes
			ImageAttributes imgAttribs = new ImageAttributes();			
			// Set ColorMatrix to ImageAttributes
			imgAttribs.SetColorMatrix(clrMatrix, 
				ColorMatrixFlag.Default,
				ColorAdjustType.Default);
			// Draw image with no affects
			g.DrawImage(curBitmap, 0, 0, 200, 200);
			// Draw image with ImageAttributes
			g.DrawImage(curBitmap, 
				new Rectangle(205, 0, 200, 200),  
				0, 0, curBitmap.Width, curBitmap.Height, 
				GraphicsUnit.Pixel, imgAttribs) ;
			// Dispose
			curBitmap.Dispose();
			g.Dispose();			
		}

		private void TranslationMenu_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Bitmap
			Bitmap curBitmap = new Bitmap("roses.jpg");	
			// ColorMatrix elements
			float[][] ptsArray = 
			{ 
				new float[] {1,  0,  0,  0, 0},
				new float[] {0,  1,  0,  0, 0},
				new float[] {0,  0,  1,  0, 0},
				new float[] {0,  0,  0,  1, 0},
				new float[] {.90f, .0f, .0f, .0f, 1}
			};
			// Create a ColorMatrix
			ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
			// Create ImageAttributes
			ImageAttributes imgAttribs = new ImageAttributes();	
			// Set color matrix
			imgAttribs.SetColorMatrix(clrMatrix, 
				ColorMatrixFlag.Default,
				ColorAdjustType.Default);
			// Draw image with no affects
			g.DrawImage(curBitmap, 0, 0, 200, 200);
			// Draw image with ImageAttributes
			g.DrawImage(curBitmap,
				new Rectangle(205, 0, 200, 200),  
				0, 0, curBitmap.Width, curBitmap.Height, 
				GraphicsUnit.Pixel, imgAttribs) ;
			// Dispose
			curBitmap.Dispose();
			g.Dispose();
		
		}

		private void ScalingMenu_Click(object sender,
			System.EventArgs e)
		{
			// Create a Graphics
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Bitmap
			Bitmap curBitmap = new Bitmap("roses.jpg");			
			// ColorMatrix elements
			float[][] ptsArray = 
			{ 
				 new float[] {1,  0,  0,  0, 0},
				 new float[] {0,  0.8f,  0,  0, 0},
				 new float[] {0,  0,  0.5f,  0, 0},
				 new float[] {0,  0,  0,  0.5f, 0},
				 new float[] {0, 0, 0, 0, 1}
			};
			// Create a ColorMatrix
			ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
			// Create ImageAttributes
			ImageAttributes imgAttribs = new ImageAttributes();			
			// Set color matrix
			imgAttribs.SetColorMatrix(clrMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Default);
			// Draw an image with no affects
			g.DrawImage(curBitmap, 0, 0, 200, 200);
			// Draw Image with image attributes
			g.DrawImage(curBitmap, 
				new Rectangle(205, 0, 200, 200),  
				0, 0, curBitmap.Width, curBitmap.Height, 
				GraphicsUnit.Pixel, imgAttribs) ;
			// Dispose
			curBitmap.Dispose();
			g.Dispose();		
		}

		private void ShearingMenu_Click(object sender,
			System.EventArgs e)
        {
			// Create a Graphics
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Bitmap
			Bitmap curBitmap = new Bitmap("roses.jpg");		
			// ColorMatrix elements
			float[][] ptsArray = 
			{ 
				 new float[] {1,  0,  0,  0, 0},
				 new float[] {0,  1,  0,  0, 0},
				 new float[] {.50f,  0,  1,  0, 0},
				 new float[] {0,  0,  0,  1, 0},
				 new float[] {0, 0, 0, 0, 1}
			};
			// Create ColorMatrix
			ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
			// Create ImageAttributes
			ImageAttributes imgAttribs = new ImageAttributes();	
			// Set color matrix
			imgAttribs.SetColorMatrix(clrMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Default);
			// Draw Image with no effects
			g.DrawImage(curBitmap, 0, 0, 200, 200);
			// Draw Image with image attributes
			g.DrawImage(curBitmap, 
				new Rectangle(205, 0, 200, 200),  
				0, 0, curBitmap.Width, curBitmap.Height, 
				GraphicsUnit.Pixel, imgAttribs);
			// Dispose
			curBitmap.Dispose();
			g.Dispose();		
		}	
	}
}






