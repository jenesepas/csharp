using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ImageAnimatorSamp
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
		private System.Windows.Forms.Button StartAnimationBtn;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem FileMenu;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.MenuItem OpenFileMenu;
		private System.Windows.Forms.Button StopAnimationBtn;


		private Image curImage = null;
		private string curFileName = null;
		
	
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
			this.StartAnimationBtn = new System.Windows.Forms.Button();
			this.StopAnimationBtn = new System.Windows.Forms.Button();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.FileMenu = new System.Windows.Forms.MenuItem();
			this.OpenFileMenu = new System.Windows.Forms.MenuItem();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// StartAnimationBtn
			// 
			this.StartAnimationBtn.Location = new System.Drawing.Point(80, 264);
			this.StartAnimationBtn.Name = "StartAnimationBtn";
			this.StartAnimationBtn.Size = new System.Drawing.Size(104, 24);
			this.StartAnimationBtn.TabIndex = 0;
			this.StartAnimationBtn.Text = "Start Animation";
			this.StartAnimationBtn.Click += new System.EventHandler(this.StartAnimationBtn_Click);
			// 
			// StopAnimationBtn
			// 
			this.StopAnimationBtn.Location = new System.Drawing.Point(200, 264);
			this.StopAnimationBtn.Name = "StopAnimationBtn";
			this.StopAnimationBtn.Size = new System.Drawing.Size(104, 24);
			this.StopAnimationBtn.TabIndex = 1;
			this.StopAnimationBtn.Text = "Stop Animation";
			this.StopAnimationBtn.Click += new System.EventHandler(this.StopAnimationBtn_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.FileMenu});
			// 
			// FileMenu
			// 
			this.FileMenu.Index = 0;
			this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.OpenFileMenu,
																					 this.ExitMenu});
			this.FileMenu.Text = "File";
			// 
			// OpenFileMenu
			// 
			this.OpenFileMenu.Index = 0;
			this.OpenFileMenu.Text = "Open File";
			this.OpenFileMenu.Click += new System.EventHandler(this.OpenFileMenu_Click);
			// 
			// ExitMenu
			// 
			this.ExitMenu.Index = 1;
			this.ExitMenu.Text = "Exit";
			this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 301);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.StopAnimationBtn,
																		  this.StartAnimationBtn});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Image Animation Sample";
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

		protected override void OnPaint(PaintEventArgs e) 
		{
			if(curImage != null)
			{
				ImageAnimator.UpdateFrames();
				e.Graphics.DrawImage(curImage, new Point(0, 0));		
			}
		}
		private void OnFrameChanged(object o, EventArgs e) 
		{
			this.Invalidate();
		}

		private void StartAnimationBtn_Click(object sender, System.EventArgs e)
		{
			curImage = Image.FromFile(curFileName);
			if( ImageAnimator.CanAnimate(curImage) )
			{
				ImageAnimator.Animate(curImage, 
					new EventHandler(this.OnFrameChanged));
			}
			else
				MessageBox.Show("Image doesn't have frames");
		}

		private void StopAnimationBtn_Click(object sender, System.EventArgs e)
		{
			if(curImage != null)
			{
				ImageAnimator.StopAnimate(curImage, 
					new EventHandler(this.OnFrameChanged));
			}		
		}

		private void OpenFileMenu_Click(object sender, 
			System.EventArgs e)
		{
			// Create OpenFileDialog
			OpenFileDialog opnDlg = new OpenFileDialog();
			opnDlg.Filter = "Animated Gifs|*.gif;";
			// If OK selected
			if(opnDlg.ShowDialog() == DialogResult.OK)
			{
				// Read current selected file name
				curFileName = opnDlg.FileName;  
			}       
		}

		private void ExitMenu_Click(object sender, 
			System.EventArgs e)
		{
			this.Close();		
		}
	}
}


