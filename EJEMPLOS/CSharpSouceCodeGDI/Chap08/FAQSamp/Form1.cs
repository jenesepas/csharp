using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FAQSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem SetProperties;
		private System.Windows.Forms.MenuItem GetProperties;
		private System.Windows.Forms.MenuItem SaveImage;
		private System.Windows.Forms.MenuItem Exit;
		private System.Windows.Forms.MenuItem OpenImage;
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
			this.SetProperties = new System.Windows.Forms.MenuItem();
			this.GetProperties = new System.Windows.Forms.MenuItem();
			this.SaveImage = new System.Windows.Forms.MenuItem();
			this.Exit = new System.Windows.Forms.MenuItem();
			this.OpenImage = new System.Windows.Forms.MenuItem();
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
																					  this.OpenImage,
																					  this.SaveImage,
																					  this.SetProperties,
																					  this.GetProperties,
																					  this.Exit});
			this.menuItem1.Text = "Images";
			// 
			// SetProperties
			// 
			this.SetProperties.Index = 2;
			this.SetProperties.Text = "Set Properties";
			this.SetProperties.Click += new System.EventHandler(this.SetProperties_Click);
			// 
			// GetProperties
			// 
			this.GetProperties.Index = 3;
			this.GetProperties.Text = "Get Properties";
			this.GetProperties.Click += new System.EventHandler(this.GetProperties_Click);
			// 
			// SaveImage
			// 
			this.SaveImage.Index = 1;
			this.SaveImage.Text = "Save Image";
			this.SaveImage.Click += new System.EventHandler(this.SaveImage_Click);
			// 
			// Exit
			// 
			this.Exit.Index = 4;
			this.Exit.Text = "Exit";
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// OpenImage
			// 
			this.OpenImage.Index = 0;
			this.OpenImage.Text = "Open Image";
			this.OpenImage.Click += new System.EventHandler(this.OpenImage_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 305);
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

		private void OpenImage_Click(object sender, System.EventArgs e)
		{
		
		}
		private void GetProperties_Click(object sender, System.EventArgs e)
		{
		
		}
		private void SetProperties_Click(object sender, System.EventArgs e)
		{
			ImagePropertyForm propDlg = new ImagePropertyForm();
			propDlg.Show();		
		}
		private void SaveImage_Click(object sender, System.EventArgs e)
		{
			Image originalimage = System.Drawing.Image.FromFile("c:\\mm.bmp");
			Bitmap b=new Bitmap(originalimage,new Size(100,100));
			b.Save("c:\\mm1.bmp",ImageFormat.Bmp);		
		}
		private void Exit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
	
	}
}
