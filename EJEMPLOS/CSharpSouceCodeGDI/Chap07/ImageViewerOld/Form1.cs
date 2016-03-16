using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace ImageViewer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem FileMenu;
		private System.Windows.Forms.MenuItem SaveFileMenu;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.MenuItem OpenFileMenu;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem PropertiesMenu;
		private System.Windows.Forms.MenuItem ThumbnailMenu;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem FitWidthMenu;
		private System.Windows.Forms.MenuItem FitHeightMenu;
		private System.Windows.Forms.MenuItem FitOriginalMenu;
		private System.Windows.Forms.MenuItem FitAllMenu;
		private System.Windows.Forms.MenuItem FlipXMenu;
		private System.Windows.Forms.MenuItem FlipYMenu;
		private System.Windows.Forms.MenuItem FlipXYMenu;
		private System.Windows.Forms.MenuItem Zoom25;
		private System.Windows.Forms.MenuItem Zoom50;
		private System.Windows.Forms.MenuItem Zoom100;
		private System.Windows.Forms.MenuItem Zoom200;
		private System.Windows.Forms.MenuItem Zoom500;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem Rotate90Menu;
		private System.Windows.Forms.MenuItem Rotate180Menu;
		private System.Windows.Forms.MenuItem Rotate270Menu;
		private System.Windows.Forms.MenuItem NoRotateMenu;


		// User defined variables
		private string curFileName = null;
		private Image curImage = null;
		private Rectangle curRect;
		private Size originalSize = new Size(0,0);
		private double curZoom = 1.0;
		private Point mouseDownPt = new Point(0,0);
		private Point mouseUpPt = new Point(0,0);
		


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
			this.FileMenu = new System.Windows.Forms.MenuItem();
			this.OpenFileMenu = new System.Windows.Forms.MenuItem();
			this.SaveFileMenu = new System.Windows.Forms.MenuItem();
			this.PropertiesMenu = new System.Windows.Forms.MenuItem();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.ThumbnailMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.Rotate90Menu = new System.Windows.Forms.MenuItem();
			this.Rotate180Menu = new System.Windows.Forms.MenuItem();
			this.Rotate270Menu = new System.Windows.Forms.MenuItem();
			this.NoRotateMenu = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.FlipXMenu = new System.Windows.Forms.MenuItem();
			this.FlipYMenu = new System.Windows.Forms.MenuItem();
			this.FlipXYMenu = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.FitWidthMenu = new System.Windows.Forms.MenuItem();
			this.FitHeightMenu = new System.Windows.Forms.MenuItem();
			this.FitOriginalMenu = new System.Windows.Forms.MenuItem();
			this.FitAllMenu = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.Zoom25 = new System.Windows.Forms.MenuItem();
			this.Zoom50 = new System.Windows.Forms.MenuItem();
			this.Zoom100 = new System.Windows.Forms.MenuItem();
			this.Zoom200 = new System.Windows.Forms.MenuItem();
			this.Zoom500 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.FileMenu,
																					  this.menuItem1});
			// 
			// FileMenu
			// 
			this.FileMenu.Index = 0;
			this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.OpenFileMenu,
																					 this.SaveFileMenu,
																					 this.PropertiesMenu,
																					 this.ExitMenu});
			this.FileMenu.Text = "File";
			// 
			// OpenFileMenu
			// 
			this.OpenFileMenu.Index = 0;
			this.OpenFileMenu.Text = "Open File";
			this.OpenFileMenu.Click += new System.EventHandler(this.OpenFileMenu_Click);
			// 
			// SaveFileMenu
			// 
			this.SaveFileMenu.Index = 1;
			this.SaveFileMenu.Text = "Save File";
			this.SaveFileMenu.Click += new System.EventHandler(this.SaveFileMenu_Click);
			// 
			// PropertiesMenu
			// 
			this.PropertiesMenu.Index = 2;
			this.PropertiesMenu.Text = "Properties";
			this.PropertiesMenu.Click += new System.EventHandler(this.PropertiesMenu_Click);
			// 
			// ExitMenu
			// 
			this.ExitMenu.Index = 3;
			this.ExitMenu.Text = "Exit";
			this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ThumbnailMenu,
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5});
			this.menuItem1.Text = "Options";
			// 
			// ThumbnailMenu
			// 
			this.ThumbnailMenu.Index = 0;
			this.ThumbnailMenu.Text = "Create Thumbnail";
			this.ThumbnailMenu.Click += new System.EventHandler(this.ThumbnailMenu_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Rotate90Menu,
																					  this.Rotate180Menu,
																					  this.Rotate270Menu,
																					  this.NoRotateMenu});
			this.menuItem2.Text = "Rotate";
			// 
			// Rotate90Menu
			// 
			this.Rotate90Menu.Index = 0;
			this.Rotate90Menu.Text = "90";
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
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.FlipXMenu,
																					  this.FlipYMenu,
																					  this.FlipXYMenu});
			this.menuItem3.Text = "Flip";
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
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.FitWidthMenu,
																					  this.FitHeightMenu,
																					  this.FitOriginalMenu,
																					  this.FitAllMenu});
			this.menuItem4.Text = "Fit ";
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
			this.FitOriginalMenu.Text = "Fit Original";
			this.FitOriginalMenu.Click += new System.EventHandler(this.FitOriginalMenu_Click);
			// 
			// FitAllMenu
			// 
			this.FitAllMenu.Index = 3;
			this.FitAllMenu.Text = "Fit All";
			this.FitAllMenu.Click += new System.EventHandler(this.FitAllMenu_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 4;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Zoom25,
																					  this.Zoom50,
																					  this.Zoom100,
																					  this.Zoom200,
																					  this.Zoom500});
			this.menuItem5.Text = "Zoom";
			// 
			// Zoom25
			// 
			this.Zoom25.Index = 0;
			this.Zoom25.Text = "25";
			this.Zoom25.Click += new System.EventHandler(this.Zoom25_Click);
			// 
			// Zoom50
			// 
			this.Zoom50.Index = 1;
			this.Zoom50.Text = "50";
			this.Zoom50.Click += new System.EventHandler(this.Zoom50_Click);
			// 
			// Zoom100
			// 
			this.Zoom100.Index = 2;
			this.Zoom100.Text = "100";
			this.Zoom100.Click += new System.EventHandler(this.Zoom100_Click);
			// 
			// Zoom200
			// 
			this.Zoom200.Index = 3;
			this.Zoom200.Text = "200";
			this.Zoom200.Click += new System.EventHandler(this.Zoom200_Click);
			// 
			// Zoom500
			// 
			this.Zoom500.Index = 4;
			this.Zoom500.Text = "500";
			this.Zoom500.Click += new System.EventHandler(this.Zoom500_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 409);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Image Viewer";
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

		private void OpenFileMenu_Click(object sender,
			System.EventArgs e)
		{
			// Create OpenFileDialog
			OpenFileDialog opnDlg = new OpenFileDialog();
			// Set a filter for images
			opnDlg.Filter =
				"All Image files|*.bmp;*.gif;*.jpg;*.ico;"+
				"*.emf;,*.wmf|Bitmap Files(*.bmp;*.gif;*.jpg;"+
				"*.ico)|*.bmp;*.gif;*.jpg;*.ico|"+
				"Meta Files(*.emf;*.wmf)|*.emf;*.wmf";
			opnDlg.Title = "ImageViewer: Open Image File";
			opnDlg.ShowHelp = true;
			// If OK selected
			if(opnDlg.ShowDialog() == DialogResult.OK)
			{
				// Read current selected file name
				curFileName = opnDlg.FileName;	
				// Create the Image object using 
				// Image.FromFile
				curImage = Image.FromFile(curFileName);
				// Activate scrolling
				this.AutoScroll = true;
				this.AutoScrollMinSize = new Size 
					((int)(curImage.Width * curZoom), 
					(int)(curImage.Height * curZoom));
				// Repaint the form, which forces the Paint
				// event hanlder
				this.Invalidate();
				zoomMode = true;
			}		
			// Create current rectangle
			curRect = new Rectangle(0, 0, 
				curImage.Width, curImage.Height);
			// Save origianl size of the image
			originalSize.Width = curImage.Width;
			originalSize.Height = curImage.Height;	
		}

		private void SaveFileMenu_Click(object sender,
			System.EventArgs e)
		{
			// If Image is created
			if(curImage == null)
				return;
			// SaveFileDialog
			SaveFileDialog saveDlg = new SaveFileDialog();
			saveDlg.Title = "Save Image As";
			saveDlg.OverwritePrompt = true;
			saveDlg.CheckPathExists = true;
			saveDlg.Filter = 
				"Bitmap File(*.bmp)|*.bmp|" +
				"Gif File(*.gif)|*.gif|JPEG File(*.jpg)|*.jpg";
			saveDlg.ShowHelp = true;
			// If selected Save
			if(saveDlg.ShowDialog() == DialogResult.OK)
			{
				// Get the user selected file name
				string fileName = saveDlg.FileName;
				// Get the extension
				string strFilExtn = 
					fileName.Remove(0, fileName.Length - 3);
				// Save file
				switch(strFilExtn)
				{
					case "bmp":
						curImage.Save(fileName, ImageFormat.Bmp);
						break;
					case "jpg":
						curImage.Save(fileName, ImageFormat.Jpeg);
						break;
					case "gif":
						curImage.Save(fileName, ImageFormat.Gif);
						break;
					case "tif":
						curImage.Save(fileName, ImageFormat.Tiff);
						break;
				}
			}   		
		}

		private void ExitMenu_Click(object sender,
			System.EventArgs e)
		{
			this.Close();		
		}

		private void Form1_Paint(object sender,
			System.Windows.Forms.PaintEventArgs e)
		{			
			Graphics g = e.Graphics;
			if(curImage != null)
			{
				// Draw Image using the DrawImage method 
				g.DrawImage(curImage, new Rectangle
					(this.AutoScrollPosition.X, 
					this.AutoScrollPosition.Y,
					(int)(curRect.Width * curZoom), 
					(int)(curRect.Height * curZoom)));  
			}		
		}

		private void PropertiesMenu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				// Viewing Image properties
				string imageProperties = "Size:"+ curImage.Size; 
				imageProperties += ",\n RawFormat:"+ 
					curImage.RawFormat.ToString();
				imageProperties += ",\n Vertical Resolution:"
					+ curImage.VerticalResolution.ToString();
				imageProperties += ",\n Horizontal Resolution:"
					+ curImage.HorizontalResolution.ToString();
				imageProperties += ",\n PixelFormat:"+ 
					curImage.PixelFormat.ToString();
				MessageBox.Show(imageProperties);
			}
		}

		private void ThumbnailMenu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				// Callback
				Image.GetThumbnailImageAbort tnCallBack =
					new Image.GetThumbnailImageAbort(tnCallbackMethod);
				// Get the thumbnail image
				Image thumbNailImage = curImage.GetThumbnailImage
					(100, 100, tnCallBack, IntPtr.Zero);
				// Create a Graphics object
				Graphics tmpg = this.CreateGraphics();
				tmpg.Clear(this.BackColor);
				// Draw thumbnail image
				tmpg.DrawImage(thumbNailImage, 40, 20);
				// Dispose Graphics
				tmpg.Dispose();
			}		
		}
		// Must be called, but not used
		public bool tnCallbackMethod()
		{
			return false;
		}

		private void Rotate90Menu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curImage.RotateFlip(
					RotateFlipType.Rotate90FlipNone);
				Invalidate();
			}	
		}
		private void Rotate180Menu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curImage.RotateFlip(
					RotateFlipType.Rotate180FlipNone);
				Invalidate();
			}	
		}
		private void Rotate270Menu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curImage.RotateFlip(
					RotateFlipType.Rotate270FlipNone);
				Invalidate();
			}	
		}
		private void NoRotateMenu_Click(object sender, 
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curImage.RotateFlip(
					RotateFlipType.RotateNoneFlipNone);
				Invalidate();
			}	
		}

		private void FlipXMenu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curImage.RotateFlip(
					RotateFlipType.RotateNoneFlipX);
				Invalidate();
			}	
		}

		private void FlipYMenu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curImage.RotateFlip(
					RotateFlipType.RotateNoneFlipY);
				Invalidate();
			}	
		
		}

		private void FlipXYMenu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curImage.RotateFlip(
					RotateFlipType.RotateNoneFlipXY);
				Invalidate();
			}			
		}

		private void FitWidthMenu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curRect.Width = this.Width;
				Invalidate();
			}		
		
		}

		private void FitHeightMenu_Click(object sender, 
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curRect.Height = this.Height;
				Invalidate();
			}		
		}

		private void FitOriginalMenu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curRect.Height = originalSize.Height;
				curRect.Width = originalSize.Width;
				Invalidate();
			}			
		}

		private void FitAllMenu_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curRect.Height = this.Height;
				curRect.Width = this.Width;
				Invalidate();
			}				
		}

		private void Zoom25_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curZoom = (double)25/100;
				Invalidate();
			}				
		}

		private void Zoom50_Click(object sender, 
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curZoom = (double)50/100;
				Invalidate();
			}				
		}

		private void Zoom100_Click(object sender, 
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curZoom = (double)100/100;
				Invalidate();
			}		
		}

		private void Zoom200_Click(object sender, 
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curZoom = (double)200/100;
				Invalidate();
			}		
		}

		private void Zoom500_Click(object sender,
			System.EventArgs e)
		{
			if(curImage != null)
			{
				curZoom = (double)500/100;
				Invalidate();
			}				
		}
	}
}
