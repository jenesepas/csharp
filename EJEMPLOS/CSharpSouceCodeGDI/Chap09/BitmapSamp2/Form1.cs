using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace BitmapSamp2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem GrayScaleMenu;
		private System.Windows.Forms.MenuItem GrayScaleBitmapDataMenu;
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
			this.GrayScaleMenu = new System.Windows.Forms.MenuItem();
			this.GrayScaleBitmapDataMenu = new System.Windows.Forms.MenuItem();
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
																					  this.GrayScaleMenu,
																					  this.GrayScaleBitmapDataMenu});
			this.menuItem1.Text = "Bitmap";
			// 
			// GrayScaleMenu
			// 
			this.GrayScaleMenu.Index = 0;
			this.GrayScaleMenu.Text = "GrayScale";
			this.GrayScaleMenu.Click += new System.EventHandler(this.GrayScaleMenu_Click);
			// 
			// GrayScaleBitmapDataMenu
			// 
			this.GrayScaleBitmapDataMenu.Index = 1;
			this.GrayScaleBitmapDataMenu.Text = "GrayScale with BitmapData";
			this.GrayScaleBitmapDataMenu.Click += new System.EventHandler(this.GrayScaleBitmapDataMenu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 329);
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

		private void GrayScaleMenu_Click(object sender, System.EventArgs e)
		{
			// Create a Graphics object from a button
			// or menu click event handler
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Bitmap object 
			Bitmap curBitmap = new Bitmap(@"f:\hott.jpg");
			// Draw bitmap in its original color 
			g.DrawImage(curBitmap, 0, 0, curBitmap.Width,
				curBitmap.Height);
			// Set each pixel to gray scale using GetPixel
			// and SetPixel
			for (int i = 0; i < curBitmap.Width; i++)
			{
				for (int j = 0; j < curBitmap.Height; j++)
				{
					Color curColor = curBitmap.GetPixel(i, j);
					int ret = (curColor.R + curColor.G + curColor.B) / 3;
					curBitmap.SetPixel(i, j, 
						Color.FromArgb(ret, ret, ret));
				}
			}
			// Draw bitmap again with gray settings
			g.DrawImage(curBitmap, 0, 0, curBitmap.Width, curBitmap.Height);
			//Dispose
			g.Dispose();
		}

		private void GrayScaleBitmapDataMenu_Click(object sender, System.EventArgs e)
		{
			// Create a Graphics object from a button
			// or menu click event handler
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Bitmap object 
			Bitmap curBitmap = new Bitmap(@"f:\hott.jpg");
			// Draw bitmap in its original color 
			g.DrawImage(curBitmap, 0, 0, curBitmap.Width,
				curBitmap.Height);

			// GDI+ still lies to us - the return format is BGR, NOT RGB.
			BitmapData bmData = curBitmap.LockBits(new Rectangle(0, 0, curBitmap.Width, curBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			unsafe
			{
				byte * p = (byte *)(void *)Scan0;

				int nOffset = stride - curBitmap.Width*3;

				byte red, green, blue;
	
				for(int y=0;y<curBitmap.Height;++y)
				{
					for(int x=0; x < curBitmap.Width; ++x )
					{
						blue = p[0];
						green = p[1];
						red = p[2];

						p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);

						p += 3;
					}
					p += nOffset;
				}
			}

			curBitmap.UnlockBits(bmData);

			// Draw bitmap again with gray settings
			g.DrawImage(curBitmap, 0, 0, curBitmap.Width, curBitmap.Height);
			//Dispose
			g.Dispose();
		}
	}
}
