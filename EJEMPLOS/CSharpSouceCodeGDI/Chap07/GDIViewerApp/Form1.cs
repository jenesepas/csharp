using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GDIViewerApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem OpenFileMenu;
		private System.Windows.Forms.MenuItem SaveFileMenu;
		private System.Windows.Forms.MenuItem ExitFileMenu;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem FitWidthMenu;
		private System.Windows.Forms.MenuItem FitHeightMenu;
		private System.Windows.Forms.MenuItem FitOriginalMenu;
		private System.Windows.Forms.MenuItem FitAllMenu;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem Rotate90Menu;
		private System.Windows.Forms.MenuItem Rotate180Menu;
		private System.Windows.Forms.MenuItem Rotate270Menu;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem NoRotateMenu;
		private System.Windows.Forms.MenuItem FlipXMenu;
		private System.Windows.Forms.MenuItem FlipYMenu;
		private System.Windows.Forms.MenuItem FlipXYMenu;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem Zoom25Menu;
		private System.Windows.Forms.MenuItem Zoom50Menu;
		private System.Windows.Forms.MenuItem Zoom100Menu;
		private System.Windows.Forms.MenuItem Zoom200Menu;
		private System.Windows.Forms.MenuItem Zoom500Menu;
		private System.Windows.Forms.MenuItem BrightnessMenu;
		private System.Windows.Forms.MenuItem ColorMenu;
		private System.Windows.Forms.MenuItem ContrastMenu;
		private System.Windows.Forms.MenuItem GammaMenu;
		private System.Windows.Forms.MenuItem GrayMenu;
		private System.Windows.Forms.MenuItem InvertMenu;

		// user-defined variables
		private System.Drawing.Bitmap bmpImage;
		private double curZoom = 1.0;
		private Rectangle curRect;
		private Size originalSize = new Size(0,0);
		private Point mouseDownPt = new Point(0,0);
		private Point mouseUpPt = new Point(0,0);
		private bool zoomMode = false;
	
		

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
			this.OpenFileMenu = new System.Windows.Forms.MenuItem();
			this.SaveFileMenu = new System.Windows.Forms.MenuItem();
			this.ExitFileMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.FitWidthMenu = new System.Windows.Forms.MenuItem();
			this.FitHeightMenu = new System.Windows.Forms.MenuItem();
			this.FitOriginalMenu = new System.Windows.Forms.MenuItem();
			this.FitAllMenu = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.Rotate90Menu = new System.Windows.Forms.MenuItem();
			this.Rotate180Menu = new System.Windows.Forms.MenuItem();
			this.Rotate270Menu = new System.Windows.Forms.MenuItem();
			this.NoRotateMenu = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.FlipXMenu = new System.Windows.Forms.MenuItem();
			this.FlipYMenu = new System.Windows.Forms.MenuItem();
			this.FlipXYMenu = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.Zoom25Menu = new System.Windows.Forms.MenuItem();
			this.Zoom50Menu = new System.Windows.Forms.MenuItem();
			this.Zoom100Menu = new System.Windows.Forms.MenuItem();
			this.Zoom200Menu = new System.Windows.Forms.MenuItem();
			this.Zoom500Menu = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.BrightnessMenu = new System.Windows.Forms.MenuItem();
			this.ColorMenu = new System.Windows.Forms.MenuItem();
			this.ContrastMenu = new System.Windows.Forms.MenuItem();
			this.GammaMenu = new System.Windows.Forms.MenuItem();
			this.GrayMenu = new System.Windows.Forms.MenuItem();
			this.InvertMenu = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
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
																																							this.OpenFileMenu,
																																							this.SaveFileMenu,
																																							this.ExitFileMenu});
			this.menuItem1.Text = "&File";
			// 
			// OpenFileMenu
			// 
			this.OpenFileMenu.Index = 0;
			this.OpenFileMenu.Text = "&Open File";
			this.OpenFileMenu.Click += new System.EventHandler(this.OpenFileMenu_Click);
			// 
			// SaveFileMenu
			// 
			this.SaveFileMenu.Index = 1;
			this.SaveFileMenu.Text = "&Save File As";
			this.SaveFileMenu.Click += new System.EventHandler(this.SaveFileMenu_Click);
			// 
			// ExitFileMenu
			// 
			this.ExitFileMenu.Index = 2;
			this.ExitFileMenu.Text = "E&xit";
			this.ExitFileMenu.Click += new System.EventHandler(this.ExitFileMenu_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuItem5,
																																							this.menuItem6,
																																							this.menuItem12,
																																							this.menuItem13});
			this.menuItem2.Text = "Op&tions";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.FitWidthMenu,
																																							this.FitHeightMenu,
																																							this.FitOriginalMenu,
																																							this.FitAllMenu});
			this.menuItem5.Text = "Fit";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// FitWidthMenu
			// 
			this.FitWidthMenu.Index = 0;
			this.FitWidthMenu.Text = "Fit Width";
			this.FitWidthMenu.Click += new System.EventHandler(this.FitWidthMenu_Click);
			// 
			// FitHeightMenu
			// 
			this.FitHeightMenu.Index = 1;
			this.FitHeightMenu.Text = "Fit Height";
			this.FitHeightMenu.Click += new System.EventHandler(this.FitHeightMenu_Click);
			// 
			// FitOriginalMenu
			// 
			this.FitOriginalMenu.Index = 2;
			this.FitOriginalMenu.Text = "Original";
			this.FitOriginalMenu.Click += new System.EventHandler(this.FitOriginalMenu_Click);
			// 
			// FitAllMenu
			// 
			this.FitAllMenu.Index = 3;
			this.FitAllMenu.Text = "Fit All";
			this.FitAllMenu.Click += new System.EventHandler(this.FitAllMenu_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.Rotate90Menu,
																																							this.Rotate180Menu,
																																							this.Rotate270Menu,
																																							this.NoRotateMenu});
			this.menuItem6.Text = "Rotate";
			// 
			// Rotate90Menu
			// 
			this.Rotate90Menu.Index = 0;
			this.Rotate90Menu.Text = "90 ";
			this.Rotate90Menu.Click += new System.EventHandler(this.Rotate90Menu_Click);
			// 
			// Rotate180Menu
			// 
			this.Rotate180Menu.Index = 1;
			this.Rotate180Menu.Text = "180";
			this.Rotate180Menu.Click += new System.EventHandler(this.Rotate180Menu_Click);
			// 
			// Rotate270Menu
			// 
			this.Rotate270Menu.Index = 2;
			this.Rotate270Menu.Text = "270";
			this.Rotate270Menu.Click += new System.EventHandler(this.Rotate270Menu_Click);
			// 
			// NoRotateMenu
			// 
			this.NoRotateMenu.Index = 3;
			this.NoRotateMenu.Text = "No Rotate";
			this.NoRotateMenu.Click += new System.EventHandler(this.NoRotateMenu_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.FlipXMenu,
																																							 this.FlipYMenu,
																																							 this.FlipXYMenu});
			this.menuItem12.Text = "Flip";
			// 
			// FlipXMenu
			// 
			this.FlipXMenu.Index = 0;
			this.FlipXMenu.Text = "FlipX";
			this.FlipXMenu.Click += new System.EventHandler(this.FlipXMenu_Click);
			// 
			// FlipYMenu
			// 
			this.FlipYMenu.Index = 1;
			this.FlipYMenu.Text = "FlipY";
			this.FlipYMenu.Click += new System.EventHandler(this.FlipYMenu_Click);
			// 
			// FlipXYMenu
			// 
			this.FlipXYMenu.Index = 2;
			this.FlipXYMenu.Text = "FlipXY";
			this.FlipXYMenu.Click += new System.EventHandler(this.FlipXYMenu_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 3;
			this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.Zoom25Menu,
																																							 this.Zoom50Menu,
																																							 this.Zoom100Menu,
																																							 this.Zoom200Menu,
																																							 this.Zoom500Menu});
			this.menuItem13.Text = "Zoom";
			// 
			// Zoom25Menu
			// 
			this.Zoom25Menu.Index = 0;
			this.Zoom25Menu.Text = "25%";
			this.Zoom25Menu.Click += new System.EventHandler(this.Zoom25Menu_Click);
			// 
			// Zoom50Menu
			// 
			this.Zoom50Menu.Index = 1;
			this.Zoom50Menu.Text = "50%";
			this.Zoom50Menu.Click += new System.EventHandler(this.Zoom50Menu_Click);
			// 
			// Zoom100Menu
			// 
			this.Zoom100Menu.Index = 2;
			this.Zoom100Menu.Text = "100%";
			this.Zoom100Menu.Click += new System.EventHandler(this.Zoom100Menu_Click);
			// 
			// Zoom200Menu
			// 
			this.Zoom200Menu.Index = 3;
			this.Zoom200Menu.Text = "200%";
			this.Zoom200Menu.Click += new System.EventHandler(this.Zoom200Menu_Click);
			// 
			// Zoom500Menu
			// 
			this.Zoom500Menu.Index = 4;
			this.Zoom500Menu.Text = "500%";
			this.Zoom500Menu.Click += new System.EventHandler(this.Zoom500Menu_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.BrightnessMenu,
																																							this.ColorMenu,
																																							this.ContrastMenu,
																																							this.GammaMenu,
																																							this.GrayMenu,
																																							this.InvertMenu});
			this.menuItem3.Text = "&Filters";
			// 
			// BrightnessMenu
			// 
			this.BrightnessMenu.Index = 0;
			this.BrightnessMenu.Text = "Brightness";
			// 
			// ColorMenu
			// 
			this.ColorMenu.Index = 1;
			this.ColorMenu.Text = "Color";
			// 
			// ContrastMenu
			// 
			this.ContrastMenu.Index = 2;
			this.ContrastMenu.Text = "Contrast";
			// 
			// GammaMenu
			// 
			this.GammaMenu.Index = 3;
			this.GammaMenu.Text = "Gamma";
			// 
			// GrayMenu
			// 
			this.GrayMenu.Index = 4;
			this.GrayMenu.Text = "Gray";
			// 
			// InvertMenu
			// 
			this.InvertMenu.Index = 5;
			this.InvertMenu.Text = "Invert";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "&Window";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(544, 381);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "GDI+ Image Viewer";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
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

		private void Form1_Paint(object sender, 
      System.Windows.Forms.PaintEventArgs e)
    {
      if(bmpImage != null)
      {
        e.Graphics.DrawImage(bmpImage, new Rectangle
            (this.AutoScrollPosition.X, this.AutoScrollPosition.Y,
            (int)(curRect.Width*curZoom), 
          (int)(curRect.Height * curZoom)));    
      }   
    }

		private void OpenFileMenu_Click(object sender, 
			System.EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.WMF)"
				+"|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 2 ;
		//	openFileDialog.RestoreDirectory = true ;

			if(DialogResult.OK == openFileDialog.ShowDialog())
			{
				bmpImage = (Bitmap)Bitmap.FromFile
					(openFileDialog.FileName, false);
				this.AutoScroll = true;
				this.AutoScrollMinSize = new Size 
					((int)(bmpImage.Width * curZoom), 
					(int)(bmpImage.Height * curZoom));
				this.Invalidate();
				zoomMode = true;
			}
			curRect = new Rectangle(0, 0, bmpImage.Width, bmpImage.Height);
			originalSize.Width = bmpImage.Width;
			originalSize.Height = bmpImage.Height;			
    }

		private void FitWidthMenu_Click(object sender, 
			System.EventArgs e)
		{
			curRect.Width = this.Width;
			this.Invalidate();		
		}

		private void FitHeightMenu_Click(object sender, 
			System.EventArgs e)
		{
			curRect.Height = this.Height;
			this.Invalidate();			
		}

		private void FitOriginalMenu_Click(object sender, 
			System.EventArgs e)
		{
			curRect.Height = originalSize.Height;
			curRect.Width = originalSize.Width;
			this.Invalidate();			
		}

		private void FitAllMenu_Click(object sender, 
			System.EventArgs e)
		{
			curRect.Height = this.Height;
			curRect.Width = this.Width;
			this.Invalidate();				
		}

		private void SaveFileMenu_Click(object sender, 
			System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();

			saveFileDialog.InitialDirectory = "c:\\" ;
			saveFileDialog.Filter = 
			"Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|"+
				"All valid files (*.bmp/*.jpg)|*.bmp/*.jpg" ;
			saveFileDialog.FilterIndex = 1 ;
			saveFileDialog.RestoreDirectory = true ;

			if(DialogResult.OK == saveFileDialog.ShowDialog())
			{
				bmpImage.Save(saveFileDialog.FileName);
			}
		}

		private void ExitFileMenu_Click(object sender, 
			System.EventArgs e)
		{
			this.Close();
		}

		private void Rotate90Menu_Click(object sender, 
			System.EventArgs e)
		{
			bmpImage.RotateFlip(RotateFlipType.Rotate90FlipNone);	
			this.Invalidate();		
		}

		private void Rotate180Menu_Click(object sender, 
			System.EventArgs e)
		{
			bmpImage.RotateFlip(RotateFlipType.Rotate180FlipNone);	
			this.Invalidate();				
		}

		private void Rotate270Menu_Click(object sender, 
			System.EventArgs e)
		{
			bmpImage.RotateFlip(RotateFlipType.Rotate270FlipNone);	
			this.Invalidate();		
		}

		private void NoRotateMenu_Click(object sender, 
			System.EventArgs e)
		{
			bmpImage.RotateFlip(RotateFlipType.RotateNoneFlipNone);	
			this.Invalidate();			
		}

		private void FlipXMenu_Click(object sender, 
			System.EventArgs e)
		{
			bmpImage.RotateFlip(RotateFlipType.RotateNoneFlipX);	
			this.Invalidate();	
		}

		private void FlipYMenu_Click(object sender, 
			System.EventArgs e)
		{
			bmpImage.RotateFlip(RotateFlipType.RotateNoneFlipY);	
			this.Invalidate();
		}

		private void FlipXYMenu_Click(object sender, 
			System.EventArgs e)
		{
			bmpImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);	
			this.Invalidate();
		}

		private void Zoom25Menu_Click(object sender, 
			System.EventArgs e)
		{
			curZoom = (double)25/100;
			this.Invalidate();
		}

		private void Zoom50Menu_Click(object sender, 
			System.EventArgs e)
		{
			curZoom = (double)50/100;		
			this.Invalidate();
		}

		private void Zoom100Menu_Click(object sender, 
			System.EventArgs e)
		{
			curZoom = 100/100;		
			this.Invalidate();
		}

		private void Zoom200Menu_Click(object sender, 
			System.EventArgs e)
		{
			curZoom = 200/100;		
			this.Invalidate();
		}

		private void Zoom500Menu_Click(object sender, 
			System.EventArgs e)
		{
			curZoom = 500/100;
			this.Invalidate();
		}

		private void Form1_MouseDown(object sender, 
			System.Windows.Forms.MouseEventArgs e)
		{
			if(!zoomMode)
				return;

			if(e.Button == MouseButtons.Left)
			{
				mouseDownPt.X = e.X;
				mouseDownPt.Y = e.Y;
			}
		}

		private void Form1_MouseUp(object sender, 
			System.Windows.Forms.MouseEventArgs e)
		{
			if(!zoomMode)
				return;
		}

		private void Form1_Resize(object sender, 
			System.EventArgs e)
		{
				this.Invalidate();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
