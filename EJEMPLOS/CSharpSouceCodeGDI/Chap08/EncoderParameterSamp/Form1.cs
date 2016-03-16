using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;


namespace EncoderParameterSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem JpegCompression;
		private System.Windows.Forms.MenuItem ConvertToPNG;
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
			this.button1 = new System.Windows.Forms.Button();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.JpegCompression = new System.Windows.Forms.MenuItem();
			this.ConvertToPNG = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(32, 232);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Save Image";
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
																					  this.JpegCompression,
																					  this.ConvertToPNG});
			this.menuItem1.Text = "Encoder/Decoder";
			// 
			// JpegCompression
			// 
			this.JpegCompression.Index = 0;
			this.JpegCompression.Text = "JPEG Compression";
			this.JpegCompression.Click += new System.EventHandler(this.JpegCompression_Click);
			// 
			// ConvertToPNG
			// 
			this.ConvertToPNG.Index = 1;
			this.ConvertToPNG.Text = "Convert to PNG";
			this.ConvertToPNG.Click += new System.EventHandler(this.ConvertToPNG_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

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

		private void button1_Click(object sender, 
			System.EventArgs e)
		{
			ImageCodecInfo imgCodecInfo = null;
			Encoder encoder = null;
			EncoderParameter encoderParam = null;
			EncoderParameters encoderParams = 
				new EncoderParameters(3);
			// Create a Bitmap object from a file.
			Bitmap curBitmap = new Bitmap("roses.jpg");
			// Define mimeType		   
			string mimeType = "image/tiff";
			ImageCodecInfo[] encoders;
			encoders = ImageCodecInfo.GetImageEncoders();
			for(int i = 0; i < encoders.Length; ++i)
			{
				if(encoders[i].MimeType == mimeType)
					imgCodecInfo = encoders[i];
			}
			// Set color depth to 24 pixels
			encoder = Encoder.ColorDepth;
			encoderParam = new EncoderParameter(encoder, 24L);
			encoderParams.Param[0] = encoderParam;
			// Compression mode LZW
			encoder = Encoder.Compression;
			encoderParam = new EncoderParameter(encoder, 
				(long)EncoderValue.CompressionLZW);
			encoderParams.Param[1] = encoderParam;
			// Set transformation 180 degrees
			encoder = Encoder.Transformation;
			encoderParam = new EncoderParameter(encoder, 
				(long)EncoderValue.TransformRotate180);
			encoderParams.Param[2] = encoderParam;		
			// Save file as a tif file
			curBitmap.Save("newFile.tif", imgCodecInfo,
				encoderParams);
			// Dispose
			curBitmap.Dispose();
		}

		private void JpegCompression_Click(object sender, System.EventArgs e)
		{
			Bitmap curBitmap;
			ImageCodecInfo imgCodecInfo = null;
			Encoder encoder;
			EncoderParameter encoderParam;
			EncoderParameters encoderParams = new EncoderParameters(1);
			// Create a Bitmap object based on a BMP file.
			curBitmap = new Bitmap("f:\\Shapes.bmp");
		
			int j;
			string mimeType = "image/jpeg";
			ImageCodecInfo[] encoders;
			encoders = ImageCodecInfo.GetImageEncoders();
			for(j = 0; j < encoders.Length; ++j)
			{
				if(encoders[j].MimeType == mimeType)
					imgCodecInfo = encoders[j];
			}
			// Jpeg Compression 
			encoder = Encoder.Compression;
			encoderParam = new EncoderParameter(encoder, 1, 
				(int)EncoderParameterValueType.ValueTypeLong, 
				0);
			encoderParams.Param[0] = encoderParam;
			curBitmap.Save("Shape0.jpg", imgCodecInfo, encoderParams);
		
		}

		private void ConvertToPNG_Click(object sender, 
			System.EventArgs e)
		{
			ImageCodecInfo imgCodecInfo = null;
			// Create a Bitmap from a file
			Bitmap curBitmap = new Bitmap("Shapes.bmp");		
			int j;
			// Set mime type. This defines the format of
			// the new file
			string mimeType = "image/png";
			ImageCodecInfo[] encoders;
			// Get GDI+ built in image encoders 
			encoders = ImageCodecInfo.GetImageEncoders();
			// Compare with our mime type and copy it to 
			// ImageCodecInfo
			for(j = 0; j < encoders.Length; ++j)
			{
				if(encoders[j].MimeType == mimeType)
					imgCodecInfo = encoders[j];
			}		
			// Save as png
			curBitmap.Save("Shape0.png",
				imgCodecInfo, null);	
			// Dispose
			curBitmap.Dispose();
		}		
	}
}






