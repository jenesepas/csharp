using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SkewImageSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem OpenFileMenu;

		
		private System.Windows.Forms.Button SkewImageBtn;
		private System.Windows.Forms.MainMenu mainMenu2;

		private Bitmap curBitmap = null;
		private bool skewImage = false;
		Point[] pts = 
		{
			new Point(150, 20),   
			new Point(20, 50),  
			new Point(150, 300)
		};

		


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
			this.OpenFileMenu = new System.Windows.Forms.MenuItem();
			this.SkewImageBtn = new System.Windows.Forms.Button();
			this.mainMenu2 = new System.Windows.Forms.MainMenu();
			this.SuspendLayout();
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
																					  this.OpenFileMenu});
			this.menuItem1.Text = "File";
			// 
			// OpenFileMenu
			// 
			this.OpenFileMenu.Index = 0;
			this.OpenFileMenu.Text = "Open File";
			this.OpenFileMenu.Click += new System.EventHandler(this.OpenFileMenu_Click);
			// 
			// SkewImageBtn
			// 
			this.SkewImageBtn.Location = new System.Drawing.Point(408, 0);
			this.SkewImageBtn.Name = "SkewImageBtn";
			this.SkewImageBtn.Size = new System.Drawing.Size(80, 23);
			this.SkewImageBtn.TabIndex = 0;
			this.SkewImageBtn.Text = "Skew Image";
			this.SkewImageBtn.Click += new System.EventHandler(this.SkewImageBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 313);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.SkewImageBtn});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
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

		private void OpenFileMenu_Click(object sender,
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
				curBitmap = new Bitmap(openDlg.FileName);
			}			
			Invalidate();
		}

		private void Form1_Paint(object sender, 
			System.Windows.Forms.PaintEventArgs e)
		{
			// Create a Graphics object
			Graphics g = e.Graphics;
			g.Clear(this.BackColor);
			
			
			if(curBitmap != null)
			{
				if(skewImage)
				{
					g.DrawImage(curBitmap, pts);
				}
				else
				{
					g.DrawImage(curBitmap, 0, 0);
				}
			}
			// Dispose
			g.Dispose(); 
		}

		private void SkewImageBtn_Click(object sender, 
			System.EventArgs e)
		{
			skewImage = true;
			Invalidate();
		}
	}
}



