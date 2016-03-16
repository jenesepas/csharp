using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DrawArcSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private float startAngle = 45.0f;
		private System.Windows.Forms.Button ResetAnglesBtn;
		private float sweepAngle = 90.0f;


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
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.ResetAnglesBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(320, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Start Angle:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(392, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(312, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Sweep Angle:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(392, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(72, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			// 
			// ResetAnglesBtn
			// 
			this.ResetAnglesBtn.Location = new System.Drawing.Point(320, 80);
			this.ResetAnglesBtn.Name = "ResetAnglesBtn";
			this.ResetAnglesBtn.Size = new System.Drawing.Size(104, 32);
			this.ResetAnglesBtn.TabIndex = 4;
			this.ResetAnglesBtn.Text = "Reset Angles";
			this.ResetAnglesBtn.Click += new System.EventHandler(this.ResetAnglesBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 309);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.ResetAnglesBtn,
																																	this.textBox2,
																																	this.label2,
																																	this.textBox1,
																																	this.label1});
			this.Name = "Form1";
			this.Text = "Arc Sample";
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
            Pen redPen = new Pen(Color.Red, 3);
            Rectangle rect = 
              new Rectangle(20, 20, 200, 200);
           e.Graphics.DrawArc(redPen,
             rect, startAngle, sweepAngle);
          redPen.Dispose();           
    }

		private void ResetAnglesBtn_Click(object sender,
      System.EventArgs e)
    {
      startAngle = 
        (float)Convert.ToDouble(textBox1.Text);
      sweepAngle = 
        (float)Convert.ToDouble(textBox2.Text);
      Invalidate();
    }
	}
}



