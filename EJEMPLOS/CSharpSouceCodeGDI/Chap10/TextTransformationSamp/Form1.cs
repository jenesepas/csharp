using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace TextTransformationSamp
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

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			string str = 
				"Colors, fonts, and text are common" +
				" elements of graphics programming." + 
				"In this chapter, you learned " +
				" about the colors, fonts, and text" +
				" representations in the "+
				".NET fFramework class library. "+ 
				"You learned how to create "+
				"these elements and use them in GDI+.";
		
			// Create a Matrix object

				
			//Matrix M = new Matrix(1, 0, 0.5f, 1, 0, 0);
			// Matrix M = new Matrix(1, 0.5f, 0, 1, 0, 0);
			Matrix M = new Matrix(1, 1, 1, -1, 0, 0);
			g.RotateTransform(45.0f, 
				System.Drawing.Drawing2D.MatrixOrder.Prepend);
			g.TranslateTransform(-20, -70);
			g.Transform = M;
				g.DrawString(str, new Font("Verdana", 10), 
				new SolidBrush(Color.Blue), new Rectangle(50,20,200,300) ); 
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
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 277);
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
	}
}