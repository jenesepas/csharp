//GraphicsCopyright
//Written 24/09/01 by J O'Donnell - wincepro@hotmail.com
//Copyright 2001 J O'Donnell

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GraphicsCopyright
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		Image origImage;
		
		private System.Windows.Forms.OpenFileDialog fileDlg;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
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
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.fileDlg = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Add Copyright";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Open";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(160, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 100);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button1});
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(264, 128);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 169);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox1,
																		  this.groupBox1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Graphics Copyright";
			this.groupBox1.ResumeLayout(false);
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

		private void menuItem2_Click(object sender, 
			System.EventArgs e)
		{
			// Open file dialog. 
			OpenFileDialog fileDlg = new OpenFileDialog();
			fileDlg.InitialDirectory = "c:\\" ;
			fileDlg.Filter= "All files (*.*)|*.*";
			fileDlg.FilterIndex = 2 ;
			fileDlg.RestoreDirectory = true ;
			if(fileDlg.ShowDialog() == DialogResult.OK)
			{
				// Create image from file
				string fileName = fileDlg.FileName.ToString();
				origImage = Image.FromFile(fileName);
				// Create a thumbnail image
				Image thumbNail = 
					origImage.GetThumbnailImage(100, 100,
					null, new IntPtr());
				//View in PictureBox
				pictureBox1.Image = thumbNail;
			}

		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(origImage == null)
			{
				MessageBox.Show("Open a file");
				return;
			}
			int imgWidth;
			int imgHeight;
			int fntSize=300;
			int x,y;
			int a,re,gr,bl,x1,y1,z1;
			int size;
			Bitmap pattern;
			SizeF sizeofstring;
			bool foundfont;		
			imgWidth = origImage.Width;
			imgHeight = origImage.Height;
			size=imgWidth*imgHeight;
			pattern = new Bitmap(imgWidth,imgHeight);
			Bitmap temp = new Bitmap(origImage);
			Graphics g = Graphics.FromImage(pattern);
			Graphics tempg = Graphics.FromImage(origImage);
			//find a font size that will fit in the bitmap
			foundfont = false;
			g.Clear(Color.White);
			while(foundfont==false)
			{
				Font fc = new Font("Georgia", 
					fntSize, System.Drawing.FontStyle.Bold);
				sizeofstring = new SizeF(imgWidth,imgHeight);
				sizeofstring = 
					g.MeasureString("Add Copyright Info",fc);
				if (sizeofstring.Width<pattern.Width)
				{
					if (sizeofstring.Height<pattern.Height)
					{
						foundfont=true;
						g.DrawString("Add Copyright Info",
							fc, new SolidBrush(Color.Black), 
							1, 15);
					}
				}
				else
					fntSize = fntSize - 1;			
			}
			MessageBox.Show("Creating new graphic",
				"GraphicsCopyright");
			for(x=1;x<pattern.Width;x++)
			{
				for(y=1;y<pattern.Height;y++)//
				{
					if (pattern.GetPixel(x,y).ToArgb()
						== Color.Black.ToArgb())
					{
						a=temp.GetPixel(x,y).A;
						re=temp.GetPixel(x,y).R;
						gr=temp.GetPixel(x,y).G;
						bl=temp.GetPixel(x,y).B;
												
						x1=re;
						y1=gr;
						z1=bl;						
						
						if (bl+25<255)
							bl=bl+25;
					
						if (gr+25<255)
							gr=gr+25;
						
						if (re+25<255)
							re=re+25;

						if (x1-25>0)
							x1=x1-25;
					
						if (y1-25>0)
							y1=y1-25;
						
						if (z1-25>0)
							z1=z1-25;					
						
						tempg.DrawEllipse(new Pen(
							new SolidBrush(Color.Black)),
							x, y+1, 3, 3);
						tempg.DrawEllipse(new Pen(
							new SolidBrush(
							Color.FromArgb(a,x1,y1,z1))), 
							x, y, 1, 1);
					}				
				}		
			}
			MessageBox.Show("Output file is output.jpeg",
			"GraphicsCopyright");
			tempg.Save();
			origImage.Save("output.jpeg",
				ImageFormat.Jpeg);
		}
	}
}


