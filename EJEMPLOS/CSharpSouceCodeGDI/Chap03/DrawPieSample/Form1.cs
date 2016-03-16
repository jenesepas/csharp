using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DrawPieSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button DrawPieBtn;
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.DrawPieBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(288, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Start Angle:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(288, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Sweep Angle:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(368, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(64, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(368, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(64, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			// 
			// DrawPieBtn
			// 
			this.DrawPieBtn.Location = new System.Drawing.Point(328, 88);
			this.DrawPieBtn.Name = "DrawPieBtn";
			this.DrawPieBtn.Size = new System.Drawing.Size(88, 24);
			this.DrawPieBtn.TabIndex = 4;
			this.DrawPieBtn.Text = "Draw Pie";
			this.DrawPieBtn.Click += new System.EventHandler(this.DrawPieBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 293);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.DrawPieBtn,
																																	this.textBox2,
																																	this.textBox1,
																																	this.label2,
																																	this.label1});
			this.Name = "Form1";
			this.Text = "Pie Shapes";
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

		private void DrawPieBtn_Click(object sender, 
      System.EventArgs e)
    {
      // Create a Graphics object
      Graphics g = this.CreateGraphics();
      g.Clear(this.BackColor);  
      // Get the current value of start and sweep 
      // angles
      float startAngle =
        (float)Convert.ToDouble(textBox1.Text);
      float sweepAngle = 
        (float)Convert.ToDouble(textBox2.Text);
      // Create a pen
      Pen bluePen = new Pen(Color.Blue, 1);
      // Draw pie
      g.DrawPie( bluePen, 20, 20, 100, 100,
        startAngle, sweepAngle);
      // Dispose
      bluePen.Dispose();
      g.Dispose();    
    }
	}
}
