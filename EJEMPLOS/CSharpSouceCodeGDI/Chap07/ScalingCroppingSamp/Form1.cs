using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ScalingCroppingSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Image curImage;	
		private float imgHeight; 
		private float imgWidth;
		private System.Windows.Forms.MenuItem menuItem12; 
		private string curFileName;

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
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem10,
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 0;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem11});
			this.menuItem10.Text = "File";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 0;
			this.menuItem11.Text = "Open File";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5,
																					  this.menuItem6,
																					  this.menuItem7});
			this.menuItem1.Text = "Zoom";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "25%";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "50%";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.Text = "100%";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 3;
			this.menuItem6.Text = "200%";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 4;
			this.menuItem7.Text = "500%";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem8,
																					  this.menuItem9,
																					  this.menuItem12});
			this.menuItem2.Text = "Skewing";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 0;
			this.menuItem8.Text = "25%";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.Text = "50%";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 357);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Scaling ";
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

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			imgHeight = imgHeight*25/100;
			imgWidth = imgWidth*25/100;
			Invalidate();
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = "All Bitmap files|*.bmp;*.gif;*.jpg;";
			string filter = openDlg.Filter;
			openDlg.InitialDirectory = Environment.CurrentDirectory;
			openDlg.Title = "Open Bitmap File";
			openDlg.ShowHelp = true;
			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				curFileName = openDlg.FileName; 	
				curImage = Image.FromFile(curFileName);
				imgHeight = curImage.Height;
				imgWidth = curImage.Width;
			}
			Invalidate();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{			
			imgHeight = imgHeight*50/100;
			imgWidth = imgWidth*50/100;
			Invalidate();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			imgHeight = imgHeight;
			imgWidth = imgWidth;
			Invalidate();		
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			
			imgHeight = imgHeight*200/100;
			imgWidth = imgWidth*200/100;
			Invalidate();
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			imgHeight = imgHeight*500/100;
			imgWidth = imgWidth*500/100;
			Invalidate();		
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (curImage != null)
			{
				e.Graphics.DrawImage(curImage, AutoScrollPosition.X, 
					AutoScrollPosition.Y,
					imgWidth, imgHeight);		

			}
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);

			Point[] pts = {
				new Point(150, 20),   
				new Point(20, 50),  
				new Point(150, 300)};  

			g.DrawImage(curImage, pts);
			g.Dispose();

		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
