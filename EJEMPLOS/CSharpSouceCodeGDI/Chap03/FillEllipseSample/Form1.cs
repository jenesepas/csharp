using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FillEllipseSample
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
			this.ClientSize = new System.Drawing.Size(292, 273);
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
			Graphics g = e.Graphics ; 
			// Create brushes
			SolidBrush redBrush = new SolidBrush(Color.Red);
			SolidBrush blueBrush = new SolidBrush(Color.Blue);
			SolidBrush greenBrush = new SolidBrush(Color.Green);
			// Create a rectangle
			Rectangle rect = 
				new Rectangle(80, 80, 50, 50); 
			// Fill ellipses
			g.FillEllipse(greenBrush, 
				40.0F, 40.0F, 130.0F, 130.0F );  			     
			g.FillEllipse(blueBrush, 60, 60, 90, 90);   
			g.FillEllipse(redBrush, rect );  
			g.FillEllipse(greenBrush, 
				100.0F, 90.0F, 10.0F, 30.0F ); 
		 	// Dispose
			blueBrush.Dispose();
			redBrush.Dispose();
			greenBrush.Dispose();		
		}
	}
}

