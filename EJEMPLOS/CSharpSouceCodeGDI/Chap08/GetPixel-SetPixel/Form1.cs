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
																					  this.GrayScaleMenu});
			this.menuItem1.Text = "Bitmap";
			// 
			// GrayScaleMenu
			// 
			this.GrayScaleMenu.Index = 0;
			this.GrayScaleMenu.Text = "GrayScale - GetPixel SetPixel";
			this.GrayScaleMenu.Click += new System.EventHandler(this.GrayScaleMenu_Click);
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

		private void GrayScaleMenu_Click(object sender,
			System.EventArgs e)
		{
			// Create a Graphics object from a button
			// or menu click event handler
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Bitmap object 
			Bitmap curBitmap = new Bitmap("roses.jpg");
			// Draw bitmap in its original color 
			g.DrawImage(curBitmap, 0, 0, curBitmap.Width,
				curBitmap.Height);
			// Find out how much time it takes
			DateTime startTime = DateTime.Now;
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
			g.DrawImage(curBitmap, 0, 0, curBitmap.Width, 
				curBitmap.Height);
			DateTime endTime = DateTime.Now;
			TimeSpan diffTime = endTime - startTime;
			MessageBox.Show("Conversion time:" +
				diffTime.TotalMilliseconds.ToString());
			//Dispose
			g.Dispose();		
		}
		
	}
}
