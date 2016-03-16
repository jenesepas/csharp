using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DrawTextSamp
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
			this.ClientSize = new System.Drawing.Size(344, 333);
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
			SolidBrush blueBrush = new SolidBrush(Color.Blue);
			SolidBrush redBrush = new SolidBrush(Color.Red);
			SolidBrush greenBrush = new SolidBrush(Color.Green);

			Rectangle rect = new Rectangle(20, 20, 200, 100);
			
			String drawString = "Hello GDI+ World!";
			Font drawFont = new Font("Verdana", 14);
			float x = 100.0F;
			float y =  100.0F;
			StringFormat drawFormat = new StringFormat();
			drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
			e.Graphics.DrawString("Drawing text", 
				new Font("Tahoma", 14), greenBrush, rect);
			e.Graphics.DrawString(drawString, 
				new Font("Arial", 12), redBrush, 120, 140);

			e.Graphics.DrawString(drawString, drawFont,
				blueBrush, x, y, drawFormat);
		}
	}
}
