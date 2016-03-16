using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BitBltSamp
{
	
	public class Form1 : System.Windows.Forms.Form
	{
		[System.Runtime.InteropServices.DllImportAttribute
			 ("Gdi32.dll")]
		public static extern bool BitBlt(
			IntPtr hdcDest, // handle to destination DC
			int nXDest, // x-coord of destination upper-left corner
			int nYDest, // y-coord of destination upper-left corner
			int nWidth, // width of destination rectangle
			int nHeight, // height of destination rectangle
			IntPtr hdcSrc, // handle to source DC
			int nXSrc, // x-coordinate of source upper-left corner
			int nYSrc, // y-coordinate of source upper-left corner
			System.Int32 dwRop // raster operation code
			);



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
			this.ClientSize = new System.Drawing.Size(328, 273);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

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

		private void Form1_Load(object sender, 
			System.EventArgs e)
		{
			Graphics g1 = this.CreateGraphics();
			Graphics g2 = null;
			try
			{
				g1.SmoothingMode = 
					SmoothingMode.AntiAlias;
				g1.DrawLine(new Pen(Color.Black, 2), 
					10, 10, 150, 10);
				g1.DrawLine(new Pen(Color.Black, 2), 
					10, 10, 10, 150);
				g1.FillRectangle(Brushes.Blue, 
					30, 30, 70, 70);
				g1.FillEllipse(new HatchBrush
					(HatchStyle.DashedDownwardDiagonal, 
					Color.Red, Color.Green), 
					110, 110, 100, 100 );
				Bitmap curBitmap = new Bitmap(
					this.ClientRectangle.Width, 
					this.ClientRectangle.Height, g1);
				g2 = Graphics.FromImage(curBitmap);
				IntPtr hdc1 = g1.GetHdc();
				IntPtr hdc2 = g2.GetHdc();
				BitBlt(hdc2, 0, 0, 
					this.ClientRectangle.Width, 
					this.ClientRectangle.Height, 
					hdc1, 0, 0, 13369376);
				g1.ReleaseHdc(hdc1);
				g2.ReleaseHdc(hdc2);
				curBitmap.Save("f:\\BitBltImg.jpg", 
					ImageFormat.Jpeg);
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message.ToString());
			}
			finally
			{
				g2.Dispose();
				g1.Dispose();
			}
		}		
	}
}


