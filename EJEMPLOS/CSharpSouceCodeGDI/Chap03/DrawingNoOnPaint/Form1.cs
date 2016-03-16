using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CheckRadioTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.radioButton1,
																					this.radioButton2,
																					this.radioButton3});
			this.groupBox1.Location = new System.Drawing.Point(8, 160);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(80, 96);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Color";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(48, 24);
			this.radioButton1.TabIndex = 4;
			this.radioButton1.Text = "Red";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 40);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(64, 24);
			this.radioButton2.TabIndex = 5;
			this.radioButton2.Text = "Green";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(8, 64);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(56, 24);
			this.radioButton3.TabIndex = 6;
			this.radioButton3.Text = "Blue";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 304);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 32);
			this.button1.TabIndex = 4;
			this.button1.Text = "Draw";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.radioButton6,
																					this.radioButton5,
																					this.radioButton4});
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(88, 112);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Object";
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(8, 72);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(56, 24);
			this.radioButton6.TabIndex = 2;
			this.radioButton6.Text = "String";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(8, 40);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(72, 32);
			this.radioButton5.TabIndex = 1;
			this.radioButton5.Text = "Rectangle";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(8, 16);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(56, 24);
			this.radioButton4.TabIndex = 0;
			this.radioButton4.Text = "Circle";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 341);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox2,
																		  this.button1,
																		  this.groupBox1});
			this.Name = "Form1";
			this.Text = "Drawing with No OnPaint";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
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

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{

		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Graphics g = Graphics.FromHwnd(this.Handle);
			Pen pn = new Pen(Color.Blue, 10);
			SolidBrush br = new SolidBrush(Color.AliceBlue);
			Rectangle rc = new Rectangle(150, 50, 250, 250);
			
			if(radioButton1.Checked)
			{
				pn.Color = Color.Red;
				br.Color = Color.Red;
			}
			if(radioButton2.Checked)
			{
				pn.Color = Color.Green;
				br.Color = Color.Green;
			}
			if(radioButton3.Checked)
			{
				pn.Color = Color.Blue;
				br.Color = Color.Blue;
			}
			if (radioButton4.Checked)
			{
				g.FillEllipse(br, rc);
				g.DrawEllipse(pn, rc);
			}
			if (radioButton5.Checked)
			{
				g.DrawRectangle(pn, rc);
			}
			if (radioButton6.Checked)
			{
				g.DrawString("Test String", 
					new Font("Verdana", 14), 
					new SolidBrush(Color.Black), rc);
			}			
			pn.Dispose(); 
			br.Dispose();		

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			radioButton4.Checked = true;
			radioButton1.Checked = true;		
		}
	}
}
