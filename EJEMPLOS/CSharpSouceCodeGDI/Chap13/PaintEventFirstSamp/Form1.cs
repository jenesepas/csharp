using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PaintEventFirstSamp
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
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "Form1";

			this.Paint += 
				new System.Windows.Forms.PaintEventHandler
				(this.MyPaintEventHandler);

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

		private void MyPaintEventHandler(object sender, 
			System.Windows.Forms.PaintEventArgs args)
		{
			// Drawing a rectangle
			args.Graphics.DrawRectangle(
				new Pen(Color.Blue, 3),
				new Rectangle(10, 10, 50, 50));
			// Drawing an ellipse
			args.Graphics.FillEllipse(
				Brushes.Red, 
				new Rectangle(60, 60, 100, 100));
			// Drawing text
			args.Graphics.DrawString(
				"Text", 
				new Font("Verdana", 14), 
				new SolidBrush(Color.Green), 200, 200) ;
		}

	}
}



