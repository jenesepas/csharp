using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace QualityRevisitedSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem AntiAliasMenu;
		private System.Windows.Forms.MenuItem GeneralMenu;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.MenuItem PixelOffsetModeMenu;
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
			this.GeneralMenu = new System.Windows.Forms.MenuItem();
			this.AntiAliasMenu = new System.Windows.Forms.MenuItem();
			this.PixelOffsetModeMenu = new System.Windows.Forms.MenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
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
																					  this.GeneralMenu,
																					  this.AntiAliasMenu,
																					  this.PixelOffsetModeMenu});
			this.menuItem1.Text = "Drawing Quality";
			// 
			// GeneralMenu
			// 
			this.GeneralMenu.Index = 0;
			this.GeneralMenu.Text = "General";
			this.GeneralMenu.Click += new System.EventHandler(this.GeneralMenu_Click);
			// 
			// AntiAliasMenu
			// 
			this.AntiAliasMenu.Index = 1;
			this.AntiAliasMenu.Text = "Anti Aliasing";
			this.AntiAliasMenu.Click += new System.EventHandler(this.AntiAliasMenu_Click);
			// 
			// PixelOffsetModeMenu
			// 
			this.PixelOffsetModeMenu.Index = 2;
			this.PixelOffsetModeMenu.Text = "PixelOffsetMode";
			this.PixelOffsetModeMenu.Click += new System.EventHandler(this.PixelOffsetMode_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.radioButton6,
																					this.radioButton5,
																					this.radioButton4,
																					this.radioButton3,
																					this.radioButton2,
																					this.radioButton1});
			this.groupBox1.Location = new System.Drawing.Point(272, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(120, 176);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "PixelOffsetMode";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(24, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(80, 16);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Default";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(24, 48);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(72, 16);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Half";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(24, 72);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(80, 16);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "HighQuality";
			
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(24, 96);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(80, 16);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "HighSpeed";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(24, 120);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(72, 16);
			this.radioButton5.TabIndex = 4;
			this.radioButton5.Text = "Invalid";
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(24, 144);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(72, 16);
			this.radioButton6.TabIndex = 5;
			this.radioButton6.Text = "None";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 313);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void GeneralMenu_Click(object sender,
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create three pens
			Pen redPen = new Pen(Color.Red, 6);
			Pen bluePen = new Pen(Color.Blue, 10);
			Pen blackPen = new Pen(Color.Black, 5);
			// Set smoothing mode
			//g.SmoothingMode = SmoothingMode.AntiAlias;
			// Draw a rectanlge, an ellipse, and a line
			g.DrawRectangle(bluePen, 10, 20, 100, 50);
			g.DrawEllipse(redPen, 10, 150, 100, 50);
			g.DrawLine(blackPen, 150, 100, 250, 220);
			// Dispose
			redPen.Dispose();
			bluePen.Dispose();
			blackPen.Dispose();
			g.Dispose();
		}

		private void AntiAliasMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Pen redPen = new Pen(Color.Red, 6);
			Pen bluePen = new Pen(Color.Blue, 10);
			Pen blackPen = new Pen(Color.Black, 5);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.DrawRectangle(bluePen, 10, 20, 100, 50);
			g.DrawEllipse(redPen, 10, 150, 100, 50);
			g.DrawLine(blackPen, 150, 100, 250, 220);
			g.Dispose();
		}

		private void PixelOffsetMode_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Pen redPen = new Pen(Color.Red, 6);
			Pen bluePen = new Pen(Color.Blue, 10);
			Pen blackPen = new Pen(Color.Black, 5);
			g.PixelOffsetMode = PixelOffsetMode.Half;
				g.DrawRectangle(bluePen, 10, 20, 100, 50);
			g.DrawEllipse(redPen, 10, 150, 100, 50);
			g.DrawLine(blackPen, 150, 100, 250, 220);
			g.Dispose();		
		}		
	}
}

