using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace BitmapDataSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 349);
			this.Name = "Form1";
			this.Text = "Bitmap Rendering Sample";
			this.Load += new System.EventHandler(this.Form1_Load);
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
			// Create an Image and Bitmap
			Image img = Image.FromFile("roses.jpg");
			Bitmap curImage = 
				new Bitmap(img, new Size(img.Width, img.Height));
			// Call LockBits, which returns a BitmapData
			//Rectangle lockedRect = new Rectangle(50,50,200,200);
			 Rectangle lockedRect = 
				new Rectangle(0,0,curImage.Width,curImage.Height);
			//Find out starting time
			//DateTime startTime = DateTime.Now;
			// Create a BitmapData 
            BitmapData bmpData = curImage.LockBits(lockedRect,
				ImageLockMode.ReadWrite, 
				PixelFormat.Format24bppRgb);
			// Set the format of BitmapData pixels
			bmpData.PixelFormat = PixelFormat.Max;
			// Unlock the locked bits
			curImage.UnlockBits(bmpData);
			// Draw Image with new pixel format
			e.Graphics.DrawImage(curImage, 0, 0, 
				curImage.Width, curImage.Height);
			// End time
			//DateTime endTime = DateTime.Now;
			// Time difference
			//TimeSpan diffTime = endTime - startTime;
			//MessageBox.Show(diffTime.TotalMilliseconds.ToString());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}
	}
}



