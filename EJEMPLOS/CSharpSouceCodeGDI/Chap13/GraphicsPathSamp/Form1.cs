using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace GraphicsPathSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button NormalBtn;
		private System.Windows.Forms.Button GraphicsPathBtn;
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
			this.NormalBtn = new System.Windows.Forms.Button();
			this.GraphicsPathBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// NormalBtn
			// 
			this.NormalBtn.Location = new System.Drawing.Point(16, 8);
			this.NormalBtn.Name = "NormalBtn";
			this.NormalBtn.Size = new System.Drawing.Size(120, 32);
			this.NormalBtn.TabIndex = 0;
			this.NormalBtn.Text = "Normal Drawing";
			this.NormalBtn.Click += new System.EventHandler(this.NormalBtn_Click);
			// 
			// GraphicsPathBtn
			// 
			this.GraphicsPathBtn.Location = new System.Drawing.Point(192, 8);
			this.GraphicsPathBtn.Name = "GraphicsPathBtn";
			this.GraphicsPathBtn.Size = new System.Drawing.Size(160, 32);
			this.GraphicsPathBtn.TabIndex = 1;
			this.GraphicsPathBtn.Text = "Draw Using Graphics Path";
			this.GraphicsPathBtn.Click += new System.EventHandler(this.GraphicsPathBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 357);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.GraphicsPathBtn,
																		  this.NormalBtn});
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void NormalBtn_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Creating a black pen
			Pen blackPen = new Pen(Color.Black, 2);
			// Draw objects
			g.DrawLine(blackPen, 50, 50, 200, 50);
			g.DrawLine(blackPen, 50, 50, 50, 200);
			g.DrawRectangle(blackPen, 60, 60, 150, 150);
			g.DrawRectangle(blackPen, 70, 70, 100, 100);
			g.DrawEllipse(blackPen, 90, 90, 50, 50);
			// Dispose
			blackPen.Dispose();		
			g.Dispose();
		}

		private void GraphicsPathBtn_Click(object sender,
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Creating a black pen
			Pen blackPen = new Pen(Color.Black, 2);
			// Create a graphics path
			GraphicsPath path = new GraphicsPath();
			path.AddLine(50, 50, 200, 50);
			path.AddLine(50, 50, 50, 200);
			path.AddRectangle(new Rectangle(60, 60, 150, 150));
			path.AddRectangle(new Rectangle(70, 70, 100, 100));
			path.AddEllipse(90, 90, 50, 50);
			g.DrawPath(blackPen, path);
			// Dispose
			blackPen.Dispose();		
			g.Dispose();		
		}
	}
}



