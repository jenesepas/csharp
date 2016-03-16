using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;


namespace ImageClassSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem ViewFileMenu;
		private System.Windows.Forms.MenuItem SaveFileMenu;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.MenuItem SaveAddMenu;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem Rotate90Menu;
		private System.Windows.Forms.MenuItem Rotate180Menu;
		private System.Windows.Forms.MenuItem Rotate270Menu;
		private System.Windows.Forms.MenuItem RotateNoneMenu;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem ThumbnailMenu;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem FitHeightMenu;
		private System.Windows.Forms.MenuItem FitWidthMenu;
		private System.Windows.Forms.MenuItem FitOriginalMenu;

		// Variables
		private Image curImage;
		private string curFileName ;
		private float imgHeight;
		private float imgWidth;
		private System.Windows.Forms.MenuItem FlipXMenu;
		private System.Windows.Forms.MenuItem FlipYMenu;
		private System.Windows.Forms.MenuItem FlipXYMenu;
		

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
			this.ViewFileMenu = new System.Windows.Forms.MenuItem();
			this.SaveFileMenu = new System.Windows.Forms.MenuItem();
			this.SaveAddMenu = new System.Windows.Forms.MenuItem();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.Rotate90Menu = new System.Windows.Forms.MenuItem();
			this.Rotate180Menu = new System.Windows.Forms.MenuItem();
			this.Rotate270Menu = new System.Windows.Forms.MenuItem();
			this.RotateNoneMenu = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.FitHeightMenu = new System.Windows.Forms.MenuItem();
			this.FitWidthMenu = new System.Windows.Forms.MenuItem();
			this.FitOriginalMenu = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.ThumbnailMenu = new System.Windows.Forms.MenuItem();
			this.FlipXMenu = new System.Windows.Forms.MenuItem();
			this.FlipYMenu = new System.Windows.Forms.MenuItem();
			this.FlipXYMenu = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem5});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ViewFileMenu,
																					  this.SaveFileMenu,
																					  this.SaveAddMenu,
																					  this.ExitMenu});
			this.menuItem1.Text = "File";
			// 
			// ViewFileMenu
			// 
			this.ViewFileMenu.Index = 0;
			this.ViewFileMenu.Text = "View Image";
			this.ViewFileMenu.Click += new System.EventHandler(this.ViewFileMenu_Click);
			// 
			// SaveFileMenu
			// 
			this.SaveFileMenu.Index = 1;
			this.SaveFileMenu.Text = "Save As";
			this.SaveFileMenu.Click += new System.EventHandler(this.SaveFileMenu_Click);
			// 
			// SaveAddMenu
			// 
			this.SaveAddMenu.Index = 2;
			this.SaveAddMenu.Text = "Save Add";
			this.SaveAddMenu.Click += new System.EventHandler(this.SaveAddMenu_Click);
			// 
			// ExitMenu
			// 
			this.ExitMenu.Index = 3;
			this.ExitMenu.Text = "Exit";
			this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem6});
			this.menuItem2.Text = "Options";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Rotate90Menu,
																					  this.Rotate180Menu,
																					  this.Rotate270Menu,
																					  this.RotateNoneMenu});
			this.menuItem3.Text = "Rotate";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// Rotate90Menu
			// 
			this.Rotate90Menu.Index = 0;
			this.Rotate90Menu.Text = "Rotate 90";
			this.Rotate90Menu.Click += new System.EventHandler(this.Rotate90Menu_Click);
			// 
			// Rotate180Menu
			// 
			this.Rotate180Menu.Index = 1;
			this.Rotate180Menu.Text = "Rotate 180";
			this.Rotate180Menu.Click += new System.EventHandler(this.Rotate180Menu_Click);
			// 
			// Rotate270Menu
			// 
			this.Rotate270Menu.Index = 2;
			this.Rotate270Menu.Text = "Rotate 270";
			this.Rotate270Menu.Click += new System.EventHandler(this.Rotate270Menu_Click);
			// 
			// RotateNoneMenu
			// 
			this.RotateNoneMenu.Index = 3;
			this.RotateNoneMenu.Text = "Rotate None";
			this.RotateNoneMenu.Click += new System.EventHandler(this.RotateNoneMenu_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.FlipXMenu,
																					  this.FlipYMenu,
																					  this.FlipXYMenu});
			this.menuItem4.Text = "Flip";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.FitHeightMenu,
																					  this.FitWidthMenu,
																					  this.FitOriginalMenu});
			this.menuItem6.Text = "Fit";
			// 
			// FitHeightMenu
			// 
			this.FitHeightMenu.Index = 0;
			this.FitHeightMenu.Text = "Fit Height";
			this.FitHeightMenu.Click += new System.EventHandler(this.FitHeightMenu_Click);
			// 
			// FitWidthMenu
			// 
			this.FitWidthMenu.Index = 1;
			this.FitWidthMenu.Text = "Fit Width";
			this.FitWidthMenu.Click += new System.EventHandler(this.FitWidthMenu_Click);
			// 
			// FitOriginalMenu
			// 
			this.FitOriginalMenu.Index = 2;
			this.FitOriginalMenu.Text = "Fit All";
			this.FitOriginalMenu.Click += new System.EventHandler(this.FitOriginalMenu_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ThumbnailMenu});
			this.menuItem5.Text = "Others";
			// 
			// ThumbnailMenu
			// 
			this.ThumbnailMenu.Index = 0;
			this.ThumbnailMenu.Text = "Show Thumbnail";
			this.ThumbnailMenu.Click += new System.EventHandler(this.ThumbnailMenu_Click);
			// 
			// FlipXMenu
			// 
			this.FlipXMenu.Index = 0;
			this.FlipXMenu.Text = "X";
			this.FlipXMenu.Click += new System.EventHandler(this.FlipXMenu_Click);
			// 
			// FlipYMenu
			// 
			this.FlipYMenu.Index = 1;
			this.FlipYMenu.Text = "Y";
			this.FlipYMenu.Click += new System.EventHandler(this.FlipYMenu_Click);
			// 
			// FlipXYMenu
			// 
			this.FlipXYMenu.Index = 2;
			this.FlipXYMenu.Text = "XY";
			this.FlipXYMenu.Click += new System.EventHandler(this.FlipXYMenu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(488, 417);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Image Class Functionality";
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

		private void ViewFileMenu_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = "All Image files|*.bmp;*.gif;*.jpg;*.ico;"+
				"*.emf,*.wmf|Bitmap Files(*.bmp;*.gif;*.jpg;"+
				"*.ico)|*.bmp;*.gif;*.jpg;*.ico|"+
				"Meta Files(*.emf;*.wmf)|*.emf;*.wmf";
			string filter = openDlg.Filter;
			openDlg.InitialDirectory = Environment.CurrentDirectory;
			openDlg.Title = "Open Image File";
			openDlg.ShowHelp = true;
			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				curFileName = openDlg.FileName; 	
				curImage = Image.FromFile(curFileName);
			}
			if(curImage != null)
			{
				// Construct a Graphics object and clear
				// the background
				Graphics g = this.CreateGraphics();		
				g.Clear(this.BackColor);
				// Draw Image using the DrawImage method 
				g.DrawImage(curImage, AutoScrollPosition.X, AutoScrollPosition.Y,
					curImage.Width, curImage.Height );				
				// g.DrawImage(curImage, this.ClientRectangle);	
				
				imgHeight = curImage.Height;
				imgWidth = curImage.Width;

				// Viewing Image properties
				string imageProperties = "Size:"+ curImage.Size; 
				imageProperties += ",\n RawFormat:"+ curImage.RawFormat.ToString();
				imageProperties += ",\n Vertical Resolution:"
					+ curImage.VerticalResolution.ToString();
				imageProperties += ",\n Horizontal Resolution:"
					+ curImage.HorizontalResolution.ToString();
				imageProperties += ",\n PixelFormat:"+ curImage.PixelFormat.ToString();
				imageProperties += ",\n Flags:"+ curImage.Flags.ToString();
				MessageBox.Show(imageProperties);	
				//Dispose
				g.Dispose();
			}			
		
		}

		private void SaveFileMenu_Click(object sender, System.EventArgs e)
		{
			if(curImage == null)
				return;

			SaveFileDialog saveDlg = new SaveFileDialog();
			saveDlg.Title = "Save Image As";
			saveDlg.OverwritePrompt = true;
			saveDlg.CheckPathExists = true;
			saveDlg.Filter = "Bitmap File(*.bmp)|*.bmp|Gif File(*.gif)|*.gif|JPEG File(*.jpg)|*.jpg";
			saveDlg.ShowHelp = true;
			if(saveDlg.ShowDialog() == DialogResult.OK)
			{
				string fileName = saveDlg.FileName;
				string strFilExtn = fileName.Remove(0, fileName.Length - 3);
				
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

		private void ExitMenu_Click(object sender, System.EventArgs e)
		{
		
		}

		private void SaveAddMenu_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
		
		}

		private void Rotate90Menu_Click(object sender, System.EventArgs e)
		{
			curImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
			Invalidate();
		}

		private void Rotate180Menu_Click(object sender, System.EventArgs e)
		{
			curImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
			Invalidate();
		
		}

		private void Rotate270Menu_Click(object sender, System.EventArgs e)
		{
			curImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
			Invalidate();		
		}

		private void RotateNoneMenu_Click(object sender, System.EventArgs e)
		{
			curImage.RotateFlip(RotateFlipType.RotateNoneFlipNone);
			Invalidate();		
		}

		private void ThumbnailMenu_Click(object sender, System.EventArgs e)
		{	
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = "All Image files|*.bmp;*.gif;*.jpg;*.ico;"+
				"*.emf,*.wmf|Bitmap Files(*.bmp;*.gif;*.jpg;"+
				"*.ico)|*.bmp;*.gif;*.jpg;*.ico|"+
				"Meta Files(*.emf;*.wmf)|*.emf;*.wmf";
			string filter = openDlg.Filter;
			openDlg.InitialDirectory = Environment.CurrentDirectory;
			openDlg.Title = "Open Image File";
			openDlg.ShowHelp = true;
			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				curFileName = openDlg.FileName; 	
				curImage = Image.FromFile(curFileName);
			}

			Graphics g = this.CreateGraphics();		
			g.Clear(this.BackColor);
			// Draw Image using the DrawImage method 
			Image.GetThumbnailImageAbort tnCallBack =
				new Image.GetThumbnailImageAbort(tnCallbackMethod);
			Image thumbNailImage = curImage.GetThumbnailImage(100, 100, tnCallBack, IntPtr.Zero);
			g.DrawImage(thumbNailImage, 40, 20);			
			g.Dispose();
		}

		private bool tnCallbackMethod()
		{
			return false;
		}


		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(curImage != null)
			{
				e.Graphics.DrawImage(curImage, AutoScrollPosition.X, AutoScrollPosition.Y,
					imgWidth, imgHeight );				
			}
		}

		private void FitHeightMenu_Click
			(object sender, System.EventArgs e)
		{
			imgHeight = this.Height;
			Invalidate();		
		}

		private void FitWidthMenu_Click
			(object sender, System.EventArgs e)
		{
			imgWidth = this.Width;
			Invalidate();
		}

		private void FitOriginalMenu_Click
			(object sender, System.EventArgs e)
		{
			imgWidth = this.Width;
			imgHeight = this.Height;
			Invalidate();	
		}

		private void FlipXMenu_Click(object sender, System.EventArgs e)
		{
			curImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
			Invalidate();		
		}

		private void FlipYMenu_Click(object sender, System.EventArgs e)
		{
			curImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
			Invalidate();
		
		}

		private void FlipXYMenu_Click(object sender, System.EventArgs e)
		{
			curImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
			Invalidate();
		}
	}
}










			






