using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace BitmapSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem OpenBmpMenu;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button ApplyBtn;

		// Variables
		private Bitmap curBitmap; 
		private float imgHeight;
		private float imgWidth;
		private string curFileName;
		private System.Windows.Forms.MenuItem PropertiesMenu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.MenuItem GrayScaleMenu;
		private System.Windows.Forms.MenuItem GrayScaleUsingLockBitsMenu;
		private System.Windows.Forms.MenuItem SaveBmpMenu;


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
			this.OpenBmpMenu = new System.Windows.Forms.MenuItem();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.PropertiesMenu = new System.Windows.Forms.MenuItem();
			this.GrayScaleMenu = new System.Windows.Forms.MenuItem();
			this.GrayScaleUsingLockBitsMenu = new System.Windows.Forms.MenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ApplyBtn = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SaveBmpMenu = new System.Windows.Forms.MenuItem();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.OpenBmpMenu,
																					  this.ExitMenu});
			this.menuItem1.Text = "Bitmap";
			// 
			// OpenBmpMenu
			// 
			this.OpenBmpMenu.Index = 0;
			this.OpenBmpMenu.Text = "Open Bitmap";
			this.OpenBmpMenu.Click += new System.EventHandler(this.OpenBmpMenu_Click);
			// 
			// ExitMenu
			// 
			this.ExitMenu.Index = 1;
			this.ExitMenu.Text = "Exit";
			this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.PropertiesMenu,
																					  this.GrayScaleMenu,
																					  this.GrayScaleUsingLockBitsMenu});
			this.menuItem4.Text = "Methods";
			// 
			// PropertiesMenu
			// 
			this.PropertiesMenu.Index = 0;
			this.PropertiesMenu.Text = "Bitmap Properties";
			this.PropertiesMenu.Click += new System.EventHandler(this.PropertiesMenu_Click);
			// 
			// GrayScaleMenu
			// 
			this.GrayScaleMenu.Index = 1;
			this.GrayScaleMenu.Text = "Gray Scale";
			this.GrayScaleMenu.Click += new System.EventHandler(this.GrayScaleMenu_Click);
			// 
			// GrayScaleUsingLockBitsMenu
			// 
			this.GrayScaleUsingLockBitsMenu.Index = 2;
			this.GrayScaleUsingLockBitsMenu.Text = "GrayScaleUsingLockBits";
			this.GrayScaleUsingLockBitsMenu.Click += new System.EventHandler(this.GrayScaleUsingLockBitsMenu_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.Desktop;
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.ApplyBtn,
																					this.checkBox1,
																					this.textBox2,
																					this.label2,
																					this.textBox1,
																					this.label1});
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.groupBox1.Location = new System.Drawing.Point(384, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(184, 360);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bitmap Properties";
			this.groupBox1.Visible = false;
			// 
			// ApplyBtn
			// 
			this.ApplyBtn.Location = new System.Drawing.Point(40, 256);
			this.ApplyBtn.Name = "ApplyBtn";
			this.ApplyBtn.Size = new System.Drawing.Size(128, 32);
			this.ApplyBtn.TabIndex = 5;
			this.ApplyBtn.Text = "Apply Settings";
			this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.checkBox1.Location = new System.Drawing.Point(16, 152);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(144, 24);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.Text = "Transparent";
			// 
			// textBox2
			// 
			this.textBox2.AutoSize = false;
			this.textBox2.BackColor = System.Drawing.SystemColors.Info;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(16, 104);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(120, 24);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.Desktop;
			this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label2.Location = new System.Drawing.Point(16, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Vert Resolution (DPI)";
			// 
			// textBox1
			// 
			this.textBox1.AutoSize = false;
			this.textBox1.BackColor = System.Drawing.SystemColors.Info;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(16, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 24);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Horz Resolution (DPI)";
			// 
			// SaveBmpMenu
			// 
			this.SaveBmpMenu.Index = -1;
			this.SaveBmpMenu.Text = "Save Bitmap";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(568, 381);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			/*
			 * Image curImage = Image.FromFile(@"f:\myfile.gif");
			Bitmap curBitmap1 = new Bitmap(@"f:\myfile.gif");
			Bitmap curBitmap2 = new Bitmap(curImage);
			Bitmap curBitmap3 = new Bitmap(curImage, new Size(200, 100) );
			Bitmap curBitmap4 = new Bitmap(200, 100);
			*/
		}

		private void OpenBmpMenu_Click(object sender, 
			System.EventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = 
				"All Bitmap files|*.bmp;*.gif;*.jpg;";
			string filter = openDlg.Filter;
			openDlg.Title = "Open Bitmap File";
			openDlg.ShowHelp = true;
			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				curFileName = openDlg.FileName; 	
				curBitmap = new Bitmap(curFileName);
				imgHeight = curBitmap.Height;
				imgWidth = curBitmap.Width;
			}
			Invalidate();
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
			if(curBitmap != null)
			{
				g.DrawImage(curBitmap, 
					AutoScrollPosition.X, AutoScrollPosition.Y,
					imgWidth, imgHeight);	
			}
			g.Dispose(); 
		}

		private void PropertiesMenu_Click(object sender,
			System.EventArgs e)
		{
			groupBox1.Visible = true;
		}

		private void ApplyBtn_Click(object sender, 
			System.EventArgs e)
		{
			if(curBitmap == null)
				return;			
			float hDpi = 90;
			float vDpi = 90;
			if(textBox1.Text.ToString() != "")
                hDpi = Convert.ToInt32(textBox1.Text);
			if(textBox1.Text.ToString() != "")
				 vDpi = Convert.ToInt32(textBox2.Text);
			curBitmap.SetResolution(hDpi, vDpi);				

			if(checkBox1.Checked)
			{
				Color curColor = curBitmap.GetPixel(10, 10);
				curBitmap.MakeTransparent();
			}

			for (int i = 50; i < 60; i++)
			{
				for (int j = 50; j < 60; j++)
				{
					curBitmap.SetPixel(i, j, Color.Red);
				}
			}
            Invalidate();
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

		private void GrayScaleUsingLockBitsMenu_Click(object sender,
			System.EventArgs e)
		{
		
			/*
			 * // Create a Graphics object from a button
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

			BitmapData bmpData = curBitmap.LockBits(
				new Rectangle(0, 0, curBitmap.Width, curBitmap.Height), 
				ImageLockMode.ReadWrite, PixelFormat.Extended);
			for (int i = 0; i < curBitmap.Width; i++)
			{
				for (int j = 0; j < curBitmap.Height; j++)
				{
					PixelData* pPixel = PixelAt(x, y);
					int ret = (pPixel->red + pPixel->green + pPixel->blue) / 3;
					pPixel->red = (byte) ret;
					pPixel->green = (byte) ret;
					pPixel->blue = (byte) ret;
				}
			}
			curBitmap.UnlockBits(bmpData);
			// Draw bitmap again with gray settings
			g.DrawImage(curBitmap, 0, 0, curBitmap.Width, curBitmap.Height);
			//Dispose
			g.Dispose();
			*/		
		}
	}
}






