using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace RotationSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer timer2;
		public float f=0;
		private Pen pn = new Pen( new SolidBrush(Color.Red), 3);


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
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			// 
			// timer2
			// 
			this.timer2.Enabled = true;
			this.timer2.Interval = 1000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.ForeColor = System.Drawing.Color.Yellow;
			this.Name = "Form1";
			this.Text = "GDI+ Clock";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawEllipse(pn, 10, 10, 230, 230);
			GraphicsPath gp = new GraphicsPath();
			gp.AddLine(45, 45, 125, 125);
			Rectangle rect = new Rectangle(45, 45, 5, 5);
			gp.AddRectangle(rect);
			Matrix RotationTransform = new Matrix(1,0, 0,1,1,1);  
			//rotation matrix
			PointF TheRotationPoint = new PointF(125.0f, 125.0f);  
			
			//rotation point			
			RotationTransform.RotateAt(f, TheRotationPoint);
			gp.Transform(RotationTransform);
			e.Graphics.DrawPath(Pens.Blue, gp);
			f=f+10; 
			if (f==360)
				f=0;           
		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			this.Refresh();
		}
	}
}
