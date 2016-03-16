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
		private System.Windows.Forms.MenuItem Second;
		private System.Windows.Forms.MenuItem Third;
		private System.Windows.Forms.MenuItem First;
		private System.Windows.Forms.MenuItem MatrixOrderMenu;
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
			this.MatrixOrderMenu = new System.Windows.Forms.MenuItem();
			this.First = new System.Windows.Forms.MenuItem();
			this.Second = new System.Windows.Forms.MenuItem();
			this.Third = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.MatrixOrderMenu});
			// 
			// MatrixOrderMenu
			// 
			this.MatrixOrderMenu.Index = 0;
			this.MatrixOrderMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.First,
																							this.Second,
																							this.Third});
			this.MatrixOrderMenu.Text = "MatrixOrder";
			// 
			// First
			// 
			this.First.Index = 0;
			this.First.Text = "First";
			this.First.Click += new System.EventHandler(this.First_Click);
			// 
			// Second
			// 
			this.Second.Index = 1;
			this.Second.Text = "Second";
			this.Second.Click += new System.EventHandler(this.Second_Click);
			// 
			// Third
			// 
			this.Third.Index = 2;
			this.Third.Text = "Third";
			this.Third.Click += new System.EventHandler(this.Third_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 313);
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

		private void First_Click(object sender,
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Rectangle
			Rectangle rect = 
				new Rectangle(20, 20, 100, 100);
			// Create a solid brush
			SolidBrush brush =
				new SolidBrush(Color.Red);
			// Fill rectangle
			g.FillRectangle(brush, rect);
			// Scale
			g.ScaleTransform(1.75f, 0.5f);
			// Rotate
			g.RotateTransform(45.0f, MatrixOrder.Append);
			// Translate
			g.TranslateTransform(150.0f, 50.0f, 
				MatrixOrder.Append);
			// Fill rectangle again
			g.FillRectangle(brush, rect);
			// Dispose
			brush.Dispose();
			g.Dispose();		
		}

		private void Second_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Rectangle
			Rectangle rect = 
				new Rectangle(20, 20, 100, 100);
			// Create a solid brush
			SolidBrush brush =
				new SolidBrush(Color.Red);
			// Fill rectangle
			g.FillRectangle(brush, rect);
			// Translate
			g.TranslateTransform(100.0f, 50.0f,
				MatrixOrder.Append);
			// Scale
			g.ScaleTransform(1.75f, 0.5f);    
			// Rotate
			g.RotateTransform(45.0f,
				MatrixOrder.Append);
			// Fill rectangle again
			g.FillRectangle(brush, rect);
			// Dispose
			brush.Dispose();
			g.Dispose();
		}

		private void Third_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Rectangle
			Rectangle rect = 
				new Rectangle(20, 20, 100, 100);
			// Create a solid brush
			SolidBrush brush =
				new SolidBrush(Color.Red);
			// Fill rectangle
			g.FillRectangle(brush, rect);
			// Translate
			g.TranslateTransform(100.0f, 50.0f, 
				MatrixOrder.Prepend);
			// Rotate
			g.RotateTransform(45.0f,
				MatrixOrder.Prepend);
			// Scale
			g.ScaleTransform(1.75f, 0.5f);          
			// Fill rectangle again
			g.FillRectangle(brush, rect);
			// Dispose
			brush.Dispose();
			g.Dispose();		
		}		
	}
}





