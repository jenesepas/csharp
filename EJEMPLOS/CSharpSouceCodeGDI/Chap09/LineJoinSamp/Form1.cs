using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace LineJoinSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button ApplyJoin;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton BevelRadBtn;
		private System.Windows.Forms.RadioButton MiterRadBtn;
		private System.Windows.Forms.RadioButton MiterClippedRadBtn;
		private System.Windows.Forms.RadioButton RoundRadBtn;
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
			this.ApplyJoin = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.BevelRadBtn = new System.Windows.Forms.RadioButton();
			this.MiterRadBtn = new System.Windows.Forms.RadioButton();
			this.MiterClippedRadBtn = new System.Windows.Forms.RadioButton();
			this.RoundRadBtn = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ApplyJoin
			// 
			this.ApplyJoin.Location = new System.Drawing.Point(352, 192);
			this.ApplyJoin.Name = "ApplyJoin";
			this.ApplyJoin.Size = new System.Drawing.Size(112, 32);
			this.ApplyJoin.TabIndex = 0;
			this.ApplyJoin.Text = "Apply LineJoin";
			this.ApplyJoin.Click += new System.EventHandler(this.ApplyJoin_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.MiterClippedRadBtn,
																					this.RoundRadBtn,
																					this.MiterRadBtn,
																					this.BevelRadBtn});
			this.groupBox1.Location = new System.Drawing.Point(328, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(152, 152);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Line Join";
			// 
			// BevelRadBtn
			// 
			this.BevelRadBtn.Checked = true;
			this.BevelRadBtn.Location = new System.Drawing.Point(16, 24);
			this.BevelRadBtn.Name = "BevelRadBtn";
			this.BevelRadBtn.Size = new System.Drawing.Size(112, 24);
			this.BevelRadBtn.TabIndex = 0;
			this.BevelRadBtn.TabStop = true;
			this.BevelRadBtn.Text = "Bevel";
			// 
			// MiterRadBtn
			// 
			this.MiterRadBtn.Location = new System.Drawing.Point(16, 56);
			this.MiterRadBtn.Name = "MiterRadBtn";
			this.MiterRadBtn.Size = new System.Drawing.Size(120, 24);
			this.MiterRadBtn.TabIndex = 1;
			this.MiterRadBtn.Text = "Miter";
			// 
			// MiterClippedRadBtn
			// 
			this.MiterClippedRadBtn.Location = new System.Drawing.Point(16, 88);
			this.MiterClippedRadBtn.Name = "MiterClippedRadBtn";
			this.MiterClippedRadBtn.Size = new System.Drawing.Size(120, 24);
			this.MiterClippedRadBtn.TabIndex = 3;
			this.MiterClippedRadBtn.Text = "Miter Clipped";
			// 
			// RoundRadBtn
			// 
			this.RoundRadBtn.Location = new System.Drawing.Point(16, 120);
			this.RoundRadBtn.Name = "RoundRadBtn";
			this.RoundRadBtn.Size = new System.Drawing.Size(112, 24);
			this.RoundRadBtn.TabIndex = 2;
			this.RoundRadBtn.Text = "Round";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 245);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox1,
																		  this.ApplyJoin});
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
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

		private void ApplyJoin_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Line join type
			if(BevelRadBtn.Checked)
			{
				DrawJoinedLines(g, LineJoin.Bevel);
			}
			if(MiterRadBtn.Checked)
			{
				DrawJoinedLines(g, LineJoin.Miter);
			}
			if(MiterClippedRadBtn.Checked)
			{
				DrawJoinedLines(g, LineJoin.MiterClipped);
			}
			if(RoundRadBtn.Checked)
			{
				DrawJoinedLines(g, LineJoin.Round);
			}
			// Dispose
			g.Dispose();		
		}

		private void DrawJoinedLines(Graphics g,
			LineJoin joinType)
		{
			// Set smoothing mode
			g.SmoothingMode = SmoothingMode.AntiAlias;
			// Create a pen with widht 20
			Pen redPen = new Pen(Color.Red, 20); 
			// Set line join
			redPen.LineJoin = joinType;
			// Create an array of points
			Point[] pts = 
				{
					new Point(150, 20), 
					new Point(50, 20), 
					new Point(80, 60), 
					new Point(50, 150), 
					new Point(150, 150)
				}; 
			// Create a rectangle using lines
			Point[] pts1 = 
				{
					new Point(200, 20), 
					new Point(300, 20),
					new Point(300, 120),
					new Point(200, 120),
					new Point(200, 20)
					
				}; 
			// Draw lines
			g.DrawLines(redPen, pts); 
			g.DrawLines(redPen, pts1);	
			// Dispose
			redPen.Dispose();
		}
	}
}


