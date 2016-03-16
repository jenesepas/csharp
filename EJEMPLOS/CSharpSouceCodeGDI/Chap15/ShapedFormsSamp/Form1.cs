using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;


namespace ShapedFormsSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
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
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 72);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Exit";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(112, 128);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(176, 160);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 301);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox1,
																		  this.button1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Form1_Load(object sender, 
			System.EventArgs e)
		{
			// Create a rectangle
			Rectangle rect = new Rectangle(0,0,100,100);
			// Create a graphics path 
			GraphicsPath path = new GraphicsPath(); 
			// Add an ellipse to graphics path
			path.AddEllipse(rect); 
			// Set region property of PictureBox
			// by creating a Region from path
			pictureBox1.Region = new Region(path);
			rect.Height += 200;
			rect.Width += 200;		
			path.Reset();
			path.AddEllipse(rect);	
			this.Region = new Region(path); 	
			// Create an Image from file and
			// set PictureBox's Image property
			Image bmp = Bitmap.FromFile("Neel02.jpg");
			pictureBox1.Image = bmp;
		}
	}
}
