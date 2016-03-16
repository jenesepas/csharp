using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ImageAttributesSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem SetColorKey;

        private System.Windows.Forms.MenuItem ClearColorKey;
		private System.Windows.Forms.MenuItem SetWrapMode;
		private System.Windows.Forms.MenuItem SetColorMatrix;
		private System.Windows.Forms.MenuItem SetNoOp;
		private System.Windows.Forms.MenuItem SetGamma;
		private System.Windows.Forms.MenuItem SetThreashold;
		private System.Windows.Forms.MenuItem SetRemapTable;
		private System.Windows.Forms.MenuItem SetBrushRemapTable; 

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
			this.SetColorKey = new System.Windows.Forms.MenuItem();
			this.ClearColorKey = new System.Windows.Forms.MenuItem();
			this.SetWrapMode = new System.Windows.Forms.MenuItem();
			this.SetColorMatrix = new System.Windows.Forms.MenuItem();
			this.SetNoOp = new System.Windows.Forms.MenuItem();
			this.SetGamma = new System.Windows.Forms.MenuItem();
			this.SetThreashold = new System.Windows.Forms.MenuItem();
			this.SetRemapTable = new System.Windows.Forms.MenuItem();
			this.SetBrushRemapTable = new System.Windows.Forms.MenuItem();
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
																					  this.SetColorKey,
																					  this.ClearColorKey,
																					  this.SetWrapMode,
																					  this.SetColorMatrix,
																					  this.SetNoOp,
																					  this.SetGamma,
																					  this.SetThreashold,
																					  this.SetRemapTable,
																					  this.SetBrushRemapTable});
			this.menuItem1.Text = "ImageAttributes";
			// 
			// SetColorKey
			// 
			this.SetColorKey.Index = 0;
			this.SetColorKey.Text = "SetColorKey";
			this.SetColorKey.Click += new System.EventHandler(this.SetColorKey_Click);
			// 
			// ClearColorKey
			// 
			this.ClearColorKey.Index = 1;
			this.ClearColorKey.Text = "ClearColorKey";
			this.ClearColorKey.Click += new System.EventHandler(this.ClearColorKey_Click);
			// 
			// SetWrapMode
			// 
			this.SetWrapMode.Index = 2;
			this.SetWrapMode.Text = "SetWrapMode";
			this.SetWrapMode.Click += new System.EventHandler(this.SetWrapMode_Click);
			// 
			// SetColorMatrix
			// 
			this.SetColorMatrix.Index = 3;
			this.SetColorMatrix.Text = "SetColorMatrix";
			this.SetColorMatrix.Click += new System.EventHandler(this.SetColorMatrix_Click);
			// 
			// SetNoOp
			// 
			this.SetNoOp.Index = 4;
			this.SetNoOp.Text = "SetNoOp";
			this.SetNoOp.Click += new System.EventHandler(this.SetNoOp_Click);
			// 
			// SetGamma
			// 
			this.SetGamma.Index = 5;
			this.SetGamma.Text = "SetGamma";
			this.SetGamma.Click += new System.EventHandler(this.SetGamma_Click);
			// 
			// SetThreashold
			// 
			this.SetThreashold.Index = 6;
			this.SetThreashold.Text = "SetThreashold";
			this.SetThreashold.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// SetRemapTable
			// 
			this.SetRemapTable.Index = 7;
			this.SetRemapTable.Text = "SetRemapTable";
			this.SetRemapTable.Click += new System.EventHandler(this.SetRemapTable_Click);
			// 
			// SetBrushRemapTable
			// 
			this.SetBrushRemapTable.Index = 8;
			this.SetBrushRemapTable.Text = "SetBrushRemapTable";
			this.SetBrushRemapTable.Click += new System.EventHandler(this.SetBrushRemapTable_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 325);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void SetColorKey_Click(object sender, System.EventArgs e)
		{		
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);

			Color lClr = Color.FromArgb(245,0,0);
			Color uClr = Color.FromArgb(255,0,0);
			ImageAttributes ImgAttr = new ImageAttributes();
			ImgAttr.SetColorKey(lClr, uClr, ColorAdjustType.Default);
					
			// Open an Image file and draw it to the screen.
			Image curImage = Image.FromFile(@"f:\dnWatcher.gif");
			g.DrawImage(curImage, 0, 0);
			// Draw the image with the color key set.
			Rectangle rect = new Rectangle(0, 0, 400, 400);
			g.DrawImage(curImage, rect, 0, 0, 400, 400,
				GraphicsUnit.Pixel, ImgAttr);
			
			// Dispose
			g.Dispose();			
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		private void ClearColorKey_Click(object sender, System.EventArgs e)
		{
			ImageAttributes ImgAttr = new ImageAttributes();
			ImgAttr.ClearColorKey(ColorAdjustType.Default);	
		}

		private void SetWrapMode_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);

			Color lClr = Color.FromArgb(245,0,0);
			Color uClr = Color.FromArgb(255,0,0);
			ImageAttributes ImgAttr = new ImageAttributes();
			ImgAttr.SetWrapMode(WrapMode.Tile, Color.Blue, true);
			Image curImage = Image.FromFile(@"f:\dnWatcher.gif");
			g.DrawImage(curImage, 0, 0);
			Rectangle rect = new Rectangle(0, 0, 400, 400);
			g.DrawImage(curImage, rect, 0, 0, 400, 400,
				GraphicsUnit.Pixel, ImgAttr);
			
			// Dispose
			g.Dispose();
		
		}

		private void SetColorMatrix_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);

			Rectangle rect = new Rectangle(20, 20, 200, 100);
			Bitmap bitmap = new Bitmap(@"F:\MyPhoto.jpg");
			float[][] ptsArray ={ 
									new float[] {1, 0, 0, 0, 0},
									new float[] {0, 1, 0, 0, 0},
									new float[] {0, 0, 1, 0, 0},
									new float[] {0, 0, 0, 0.5f, 0}, 
									new float[] {0, 0, 0, 0, 1}}; 
			ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
			if( clrMatrix.Matrix34 <= 0.5)
			{
				clrMatrix.Matrix34 = 0.8f;
				clrMatrix.Matrix11 = 0.3f;
			}
            ImageAttributes imgAttributes = new ImageAttributes();
			imgAttributes.SetColorMatrix(clrMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap);
			g.FillRectangle(Brushes.Red, rect);
			rect.Y += 120;
			g.FillEllipse(Brushes.Black, rect);
			g.DrawImage(bitmap, 
				new Rectangle(0, 0, bitmap.Width, bitmap.Height),  
				0, 0, bitmap.Width, bitmap.Height,
				GraphicsUnit.Pixel, imgAttributes);

			// Dispose
			g.Dispose();

		}

		private void SetNoOp_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);

			Color lClr = Color.FromArgb(245,0,0);
			Color uClr = Color.FromArgb(255,0,0);
			ImageAttributes ImgAttr = new ImageAttributes();
			ImgAttr.SetColorKey(lClr, uClr, ColorAdjustType.Default);
			ImgAttr.SetGamma(2.0f, ColorAdjustType.Default);
			ImgAttr.SetNoOp(ColorAdjustType.Default);
			Image curImage = Image.FromFile(@"f:\dnWatcher.gif");
			g.DrawImage(curImage, 0, 0);
			Rectangle rect = new Rectangle(0, 0, 400, 400);
			g.DrawImage(curImage, rect, 0, 0, 400, 400,
				GraphicsUnit.Pixel, ImgAttr);
			
			// Dispose
			g.Dispose();
		
		}

		private void SetGamma_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);
			Color lClr = Color.FromArgb(245,0,0);
			Color uClr = Color.FromArgb(255,0,0);
			ImageAttributes ImgAttr = new ImageAttributes();
			ImgAttr.SetGamma(2.0f, ColorAdjustType.Default);
			Image curImage = Image.FromFile(@"f:\dnWatcher.gif");
			g.DrawImage(curImage, 0, 0);
			Rectangle rect = new Rectangle(0, 0, 400, 400);
			g.DrawImage(curImage, rect, 0, 0, 400, 400,
				GraphicsUnit.Pixel, ImgAttr);			
			// Dispose
			g.Dispose();			
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);
			Color lClr = Color.FromArgb(245,0,0);
			Color uClr = Color.FromArgb(255,0,0);
			ImageAttributes ImgAttr = new ImageAttributes();
			ImgAttr.SetThreshold(0.7f, ColorAdjustType.Default);
			Image curImage = Image.FromFile(@"f:\dnWatcher.gif");
			g.DrawImage(curImage, 0, 0);
			Rectangle rect = new Rectangle(0, 0, 400, 400);
			g.DrawImage(curImage, rect, 0, 0, 400, 400,
				GraphicsUnit.Pixel, ImgAttr);			
			// Dispose
			g.Dispose();	
		}

		private void SetBrushRemapTable_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);
			
			Color lClr = Color.FromArgb(245,0,0);
			Color uClr = Color.FromArgb(255,0,0);
			ColorMap[] clrMapTable = new ColorMap[1];
			clrMapTable[0] = new ColorMap();
			clrMapTable[0].OldColor = lClr; 
			clrMapTable[0].NewColor = uClr;
			ImageAttributes ImgAttr = new ImageAttributes();
			ImgAttr.SetBrushRemapTable(clrMapTable);

			Image curImage = Image.FromFile(@"f:\dnWatcher.gif");
			g.DrawImage(curImage, 0, 0);
			Rectangle rect = new Rectangle(0, 0, 400, 400);
			g.DrawImage(curImage, rect, 0, 0, 400, 400,
				GraphicsUnit.Pixel, ImgAttr);		

			// Dispose
			g.Dispose();	

		}

		private void SetRemapTable_Click(object sender, System.EventArgs e)
		{
		
		}

		
		
	}
}
