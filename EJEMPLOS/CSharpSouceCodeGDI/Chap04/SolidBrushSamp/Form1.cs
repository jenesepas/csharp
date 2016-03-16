using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SolidBrushSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem SelectColorMenu;
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
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.SelectColorMenu = new System.Windows.Forms.MenuItem();
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																								 this.SelectColorMenu});
			
			// 
			// SelectColorMenu
			// 
			this.SelectColorMenu.Index = 0;
			this.SelectColorMenu.Text = "Select Color";
			
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 285);
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

		private void Form1_Paint(object sender,
			System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			// Creat three SolidBrush objects 
			// using red, green, and blue colors
			SolidBrush redBrush = new SolidBrush(Color.Red);
			SolidBrush greenBrush = new SolidBrush(Color.Green);
			SolidBrush blueBrush = new SolidBrush(Color.Blue);
			// Fill ellipse using red brush
			g.FillEllipse(redBrush, 20, 40, 100, 120);
			// Create a fill rectangle using blue brush
			Rectangle rect = new Rectangle(150, 80, 200, 140);
			g.FillRectangle(blueBrush, rect);
			// Fill pie using green brush
			g.FillPie(greenBrush, 
				40, 20, 200, 40, 0.0f, 60.0f );
			// Dispose
			redBrush.Dispose();
			greenBrush.Dispose();
			blueBrush.Dispose();
		}

	
	}
}

