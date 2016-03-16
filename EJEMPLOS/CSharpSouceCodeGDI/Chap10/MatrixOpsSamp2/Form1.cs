using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace MatrixOpsSamp2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem Rotate;
		private System.Windows.Forms.MenuItem Shear;
		private System.Windows.Forms.MenuItem Translate;
		private System.Windows.Forms.MenuItem ScaleMenu;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem InvertMenu;
		private System.Windows.Forms.MenuItem MultiplyMenu;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.MenuItem RotateAtMenu;
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
			this.Rotate = new System.Windows.Forms.MenuItem();
			this.ScaleMenu = new System.Windows.Forms.MenuItem();
			this.Shear = new System.Windows.Forms.MenuItem();
			this.Translate = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.InvertMenu = new System.Windows.Forms.MenuItem();
			this.MultiplyMenu = new System.Windows.Forms.MenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.RotateAtMenu = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Rotate,
																					  this.RotateAtMenu,
																					  this.ScaleMenu,
																					  this.Shear,
																					  this.Translate});
			this.menuItem1.Text = "Matrix Operations";
			// 
			// Rotate
			// 
			this.Rotate.Index = 0;
			this.Rotate.Text = "Rotate";
			this.Rotate.Click += new System.EventHandler(this.Rotate_Click);
			// 
			// ScaleMenu
			// 
			this.ScaleMenu.Index = 2;
			this.ScaleMenu.Text = "Scale";
			this.ScaleMenu.Click += new System.EventHandler(this.Scale_Click);
			// 
			// Shear
			// 
			this.Shear.Index = 3;
			this.Shear.Text = "Shear";
			this.Shear.Click += new System.EventHandler(this.Shear_Click);
			// 
			// Translate
			// 
			this.Translate.Index = 4;
			this.Translate.Text = "Translate";
			this.Translate.Click += new System.EventHandler(this.Translate_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.InvertMenu,
																					  this.MultiplyMenu});
			this.menuItem2.Text = "Matrix Class";
			// 
			// InvertMenu
			// 
			this.InvertMenu.Index = 0;
			this.InvertMenu.Text = "Invert";
			this.InvertMenu.Click += new System.EventHandler(this.InvertMenu_Click);
			// 
			// MultiplyMenu
			// 
			this.MultiplyMenu.Index = 1;
			this.MultiplyMenu.Text = "Multiply";
			this.MultiplyMenu.Click += new System.EventHandler(this.MultiplyMenu_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "doc1";
			// 
			// RotateAtMenu
			// 
			this.RotateAtMenu.Index = 1;
			this.RotateAtMenu.Text = "RotateAt";
			this.RotateAtMenu.Click += new System.EventHandler(this.RotateAtMenu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 305);
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

		private void Rotate_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create a Matrix object
            Matrix X = new Matrix();
            // Rotate by 45 degrees
            X.Rotate(45, MatrixOrder.Append);
            // Apply Matrix on the Graphics object
            // that means all the graphics items 
            // drawn on the Graphics object
            g.Transform = X;            
            // Draw a line
            g.DrawLine(new Pen(Color.Green, 3), 
                new Point(120, 50), 
                new Point(200, 50));
            // Fill a rectangle
            g.FillRectangle(Brushes.Blue, 
                200, 100, 100, 60);     
            // Dispose */
            g.Dispose();
		}

		private void RotateAtMenu_Click(object sender,
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Matrix object
			Matrix X = new Matrix();
			// a point
			PointF pt = new PointF(180.0f, 50.0f);
			// Rotate by 45 degrees
			X.RotateAt(45, pt, MatrixOrder.Append);
			// Reset the Matrix
			X.Reset();
			// Apply Matrix on the Graphics object
			// that means all the graphics items 
			// drawn on the Graphics object
			g.Transform = X;	
			// Draw a line
			g.DrawLine(new Pen(Color.Green, 3), 
				new Point(120, 50), 
				new Point(200, 50));
			// Fill a rectangle
			g.FillRectangle(Brushes.Blue, 
				200, 100, 100, 60);		
			// Dispose */
			g.Dispose();		
		}

		private void Scale_Click(object sender,
			System.EventArgs e)
		{
			// Create Graphics
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Draw a filled rectangle with 
			// height width 20 and height 30
			g.FillRectangle(Brushes.Blue, 
				20, 20, 20, 30);
			// Create a Matrix object
			Matrix X = new Matrix();
			// Apply 3 times scaling 
			X.Scale(3, 4, MatrixOrder.Append);
			// Apply transformation on the form
			g.Transform = X;
			// Draw a filled rectangle with 
			// widht = 20 and height = 30
			g.FillRectangle(Brushes.Blue, 
				20, 20, 20, 30);		
			// Dispose
			g.Dispose();		
		}

		private void Shear_Click(object sender,
			System.EventArgs e)
		{		
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Brush
			HatchBrush hBrush = new HatchBrush
				(HatchStyle.DarkVertical,
				Color.Green, Color.Yellow);
			// Fill a rectangle
			g.FillRectangle(hBrush,
				100, 50, 100, 60);
			// Create a Matrix object
			Matrix X = new Matrix();
			// Shear
			X.Shear(2, 1);
			// Apply transoformation
			g.Transform = X;
			// Fill rectangle
			g.FillRectangle(hBrush, 
				10, 100, 100, 60);		
			// Dispose
			hBrush.Dispose();
			g.Dispose();
		}

		private void Translate_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics obhect
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Draw a filled rectangle
			g.FillRectangle(Brushes.Blue,
				50, 50, 100, 60);
			// Create a Matrix
			Matrix X = new Matrix();
			// Translate 100 in x and 100 in 
			// y direction
			X.Translate(100, 100); 
			// Apply transformation
			g.Transform = X;
			// Draw a filled rectangle after 
			// translation
			g.FillRectangle(Brushes.Blue, 
				50, 50, 100, 60);		
			// Dispose
			g.Dispose();
		}

		private void InvertMenu_Click(object sender,
			System.EventArgs e)
		{
			string str = "Original values: ";
			// Create a Matrix object
			Matrix X = new Matrix(2, 1, 3, 1, 0, 4);
			// Write its values
			for(int i=0; i<X.Elements.Length; i++)
			{
				str += X.Elements[i].ToString();
				str += ", ";
			}
			str += "\n";
			str += "Inverted values: ";
			// Invert Matrix
			X.Invert();
			float[] pts = X.Elements;
			// Read inverted Matrix
			for(int i=0; i<pts.Length; i++)
			{
				str += pts[i].ToString();		
				str += ", ";
			}
			// Display result
			MessageBox.Show(str);
		}

		private void MultiplyMenu_Click(object sender,
			System.EventArgs e)
		{
			string str = null;
			// Create two Matrix objects
			Matrix X = 
				new Matrix(2.0f, 1.0f, 3.0f, 1.0f, 0.0f, 4.0f);  
			Matrix Y = 
				new Matrix(0.0f, 1.0f, -1.0f, 0.0f, 0.0f, 0.0f); 
			// Multiply two Matrices
			X.Multiply(Y, MatrixOrder.Append);
			// Read the result Matrix
			for(int i=0; i<X.Elements.Length; i++)
			{
				str += X.Elements[i].ToString();
				str += ", ";
			}
			// Display result
			MessageBox.Show(str);
		}

	}
}




