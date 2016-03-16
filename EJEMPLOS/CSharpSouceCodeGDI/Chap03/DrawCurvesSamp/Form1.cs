using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace DrawCurvesSamp
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button ApplyBtn;

		private float tension = 0.5F;

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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.ApplyBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(264, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter Tension:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(360, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// ApplyBtn
			// 
			this.ApplyBtn.Location = new System.Drawing.Point(336, 88);
			this.ApplyBtn.Name = "ApplyBtn";
			this.ApplyBtn.Size = new System.Drawing.Size(88, 32);
			this.ApplyBtn.TabIndex = 2;
			this.ApplyBtn.Text = "Apply";
			this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 301);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.ApplyBtn,
																																	this.textBox1,
																																	this.label1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
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

		private void Form1_Paint(object sender,
      System.Windows.Forms.PaintEventArgs e)
    {
      // Create a pen
      Pen bluePen = new Pen(Color.Blue, 1);
      // Create an array of points
      PointF pt1 = new PointF( 40.0F,  50.0F);
      PointF pt2 = new PointF(50.0F,  75.0F);
      PointF pt3 = new PointF(100.0F,  115.0F);
      PointF pt4 = new PointF(200.0F,  180.0F);
      PointF pt5 = new PointF(200.0F, 90.0F);
      PointF[] ptsArray =
      {
        pt1, pt2, pt3, pt4, pt5
      };  
      // Draw curve
		  int offset = 1;
      int segments = 3;
      e.Graphics.DrawCurve(bluePen, ptsArray, 
        offset, segments, tension);
      // Dispose
      bluePen.Dispose();
    }

		private void ApplyBtn_Click(object sender,
			System.EventArgs e)
		{
			tension = (float)Convert.ToDouble(textBox1.Text);
			Invalidate();
		}
	}
}
