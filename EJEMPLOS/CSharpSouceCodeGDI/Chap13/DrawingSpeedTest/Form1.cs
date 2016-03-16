using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace DrawingSpeedTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button BitmapDraw;
		private System.Windows.Forms.Button DoubleBuff;
		private System.Windows.Forms.Button RectBtn;
		private System.Windows.Forms.Button GraphicsDraw;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private bool drawing = false;
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
			this.button1 = new System.Windows.Forms.Button();
			this.BitmapDraw = new System.Windows.Forms.Button();
			this.DoubleBuff = new System.Windows.Forms.Button();
			this.RectBtn = new System.Windows.Forms.Button();
			this.GraphicsDraw = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(376, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "Simple Draw";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// BitmapDraw
			// 
			this.BitmapDraw.Location = new System.Drawing.Point(376, 40);
			this.BitmapDraw.Name = "BitmapDraw";
			this.BitmapDraw.Size = new System.Drawing.Size(96, 24);
			this.BitmapDraw.TabIndex = 1;
			this.BitmapDraw.Text = "Bitmap Draw";
			this.BitmapDraw.Click += new System.EventHandler(this.BitmapDraw_Click);
			// 
			// DoubleBuff
			// 
			this.DoubleBuff.Location = new System.Drawing.Point(376, 72);
			this.DoubleBuff.Name = "DoubleBuff";
			this.DoubleBuff.Size = new System.Drawing.Size(96, 24);
			this.DoubleBuff.TabIndex = 2;
			this.DoubleBuff.Text = "Anti Alias";
			this.DoubleBuff.Click += new System.EventHandler(this.DoubleBuff_Click);
			// 
			// RectBtn
			// 
			this.RectBtn.Location = new System.Drawing.Point(376, 208);
			this.RectBtn.Name = "RectBtn";
			this.RectBtn.Size = new System.Drawing.Size(96, 32);
			this.RectBtn.TabIndex = 3;
			this.RectBtn.Text = "Rectangle Speed";
			this.RectBtn.Click += new System.EventHandler(this.RectBtn_Click);
			// 
			// GraphicsDraw
			// 
			this.GraphicsDraw.Location = new System.Drawing.Point(376, 168);
			this.GraphicsDraw.Name = "GraphicsDraw";
			this.GraphicsDraw.Size = new System.Drawing.Size(96, 32);
			this.GraphicsDraw.TabIndex = 4;
			this.GraphicsDraw.Text = "Graphics Draw";
			this.GraphicsDraw.Click += new System.EventHandler(this.GraphicsDraw_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 357);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.GraphicsDraw,
																		  this.RectBtn,
																		  this.DoubleBuff,
																		  this.BitmapDraw,
																		  this.button1});
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

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		private void DrawLines(Graphics g) 
		{
			float width = ClientRectangle.Width;
			float height = ClientRectangle.Height;
			float partX = width / 1000;
			float partY = height / 1000;
			for (int i = 0; i < 1000; i++) 
			{

				g.DrawLine(Pens.Blue, 
					0, height - (partY * i), 
					partX * i, 0);				
				g.DrawLine(Pens.Green,
					0, 
					height - (partY * i), 
					(width) - partX * i, 
					0);
				g.DrawLine(Pens.Red, 0,
					partY * i, 
					(width) - partX * i, 
					0);
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			// Create a Graphics object for "this"
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Draw lines
			DrawLines(g);
			// Garbage Disposal
			g.Dispose();
		}
		private void BitmapDraw_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create a Bitmap object with the size of Form
			Bitmap curBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
			// Create a temp Graphics object from the bitmap
			Graphics g1 = Graphics.FromImage(curBitmap);
			// Draw lines on temp Graphics
			DrawLines(g1);
			// Call DrawImage of Graphics and draw bitmap
			g.DrawImage(curBitmap, 0, 0);
			// Garbage Disposal
			g1.Dispose();
			curBitmap.Dispose();
			g.Dispose();
		}

		private void DoubleBuff_Click(object sender, System.EventArgs e)
		{
			// Activates double buffering
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true); 

			//SetStyle(ControlStyles.ResizeRedraw | ControlStyles.Opaque, true);

			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);						
			// Create a Bitmap object with the size of Form
			Bitmap curBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
			// Create a temp Graphics object from the bitmap
			Graphics g1 = Graphics.FromImage(curBitmap);
			// Set smoothing mode to AntiAlias
			g1.SmoothingMode = SmoothingMode.AntiAlias;
			// Draw lines on temp Graphics
			DrawLines(g1);
			// Call DrawImage of Graphics and draw bitmap
			g.DrawImage(curBitmap, 0, 0);
			// Garbage Disposal
			g1.Dispose();
			curBitmap.Dispose();
			g.Dispose(); 
		}

		private void ResizeRedraw_Click(object sender, System.EventArgs e)
		{
			this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.Opaque, true);
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);						
			// Create a Bitmap object with the size of Form
			Bitmap curBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
			// Create a temp Graphics object from the bitmap
			Graphics g1 = Graphics.FromImage(curBitmap);
			// Set smoothing mode to AntiAlias
			g1.SmoothingMode = SmoothingMode.AntiAlias;
			// Draw lines on temp Graphics
			DrawLines(g1);
			// Call DrawImage of Graphics and draw bitmap
			g.DrawImage(curBitmap, 0, 0);
			// Garbage Disposal
			g1.Dispose();
			curBitmap.Dispose();
			g.Dispose(); 
		}

		private void RectBtn_Click(object sender, System.EventArgs e)
		{
			// Activates double buffering
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true); 

			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Pen bluePen = new Pen(Color.Blue);			
			int k = 0;
			int ch = 250;
			int cw = 250;
			for(int i=0; i<=10000; i++)
			{
				cw = cw-2;
				ch = ch-2;				k = k+4;
				g.DrawRectangle(bluePen, new Rectangle(cw, ch, k, k));				
				this.Text = i.ToString();
			}		

			bluePen.Dispose();
			g.Dispose(); 
		}

		private void GraphicsDraw_Click(object sender, System.EventArgs e)
		{	
			// Create a Graphics object for "this"
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Draw lines
			DrawLines(g);
			// Garbage Disposal
			g.Dispose();
			
		}	
	}
}



