using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace TransformationOrderSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem DefMenu;
		private System.Windows.Forms.MenuItem FirstMenu;
		private System.Windows.Forms.MenuItem SecMenu;
		private System.Windows.Forms.MenuItem ThirdMenu;
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
			this.DefMenu = new System.Windows.Forms.MenuItem();
			this.FirstMenu = new System.Windows.Forms.MenuItem();
			this.SecMenu = new System.Windows.Forms.MenuItem();
			this.ThirdMenu = new System.Windows.Forms.MenuItem();
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
																					  this.DefMenu,
																					  this.FirstMenu,
																					  this.SecMenu,
																					  this.ThirdMenu});
			this.menuItem1.Text = "Transformation Order";
			// 
			// DefMenu
			// 
			this.DefMenu.Index = 0;
			this.DefMenu.Text = "Default";
			this.DefMenu.Click += new System.EventHandler(this.DefMenu_Click);
			// 
			// FirstMenu
			// 
			this.FirstMenu.Index = 1;
			this.FirstMenu.Text = "First Change";
			this.FirstMenu.Click += new System.EventHandler(this.FirstMenu_Click);
			// 
			// SecMenu
			// 
			this.SecMenu.Index = 2;
			this.SecMenu.Text = "Second Change";
			this.SecMenu.Click += new System.EventHandler(this.SecMenu_Click);
			// 
			// ThirdMenu
			// 
			this.ThirdMenu.Index = 3;
			this.ThirdMenu.Text = "Third Change";
			this.ThirdMenu.Click += new System.EventHandler(this.ThirdMenu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 365);
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

		private void DefMenu_Click(object sender, System.EventArgs e)
		{
			
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Rectangle rect = 
				new Rectangle(20, 20, 100, 100);
			SolidBrush brush = new SolidBrush(Color.Red);
			g.FillRectangle(brush, rect);
			g.ScaleTransform(1.75f, 0.5f);
			g.RotateTransform(45.0f, 
				MatrixOrder.Append);
			g.TranslateTransform(150.0f, 
				50.0f, MatrixOrder.Append);
			g.FillRectangle(brush, rect);

			g.Dispose();
		
			
		}

		private void FirstMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Rectangle rect = 
				new Rectangle(20, 20, 100, 100);
			SolidBrush brush = 
				new SolidBrush(Color.Red);
			g.FillRectangle(brush, rect);
			g.TranslateTransform(100.0f, 50.0f,
				MatrixOrder.Append);
			g.RotateTransform(45.0f,
				MatrixOrder.Append);
			g.ScaleTransform(1.75f, 0.5f);			
			g.FillRectangle(brush, rect);

			g.Dispose();
		
		}

		private void SecMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Rectangle rect = 
				new Rectangle(20, 20, 100, 100);
			SolidBrush brush = new SolidBrush(Color.Red);
			g.FillRectangle(brush, rect);
			g.TranslateTransform(100.0f, 50.0f, 
				MatrixOrder.Prepend);
			g.RotateTransform(45.0f, MatrixOrder.Prepend);
			g.ScaleTransform(1.75f, 0.5f);			
			g.FillRectangle(brush, rect);

			g.Dispose();
		}

		private void ThirdMenu_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);


			g.Dispose();
		
		}
	}
}



