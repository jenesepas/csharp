using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace TextShapedForm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem ShapedForm;
		private System.Windows.Forms.MenuItem FilledText;
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.ShapedForm = new System.Windows.Forms.MenuItem();
			this.FilledText = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ShapedForm,
																					  this.FilledText});
			this.menuItem1.Text = "Text Shapes";
			// 
			// ShapedForm
			// 
			this.ShapedForm.Index = 0;
			this.ShapedForm.Text = "Shaped Form";
			this.ShapedForm.Click += new System.EventHandler(this.ShapedForm_Click);
			// 
			// FilledText
			// 
			this.FilledText.Index = 1;
			this.FilledText.Text = "Filled Text";
			this.FilledText.Click += new System.EventHandler(this.FilledText_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 373);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Load += new System.EventHandler(this.Form1_Load);

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

		private void Form1_MouseDown(object sender, 
			System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
				this.Close();		
		}

		private void ShapedForm_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);

			#region This code sets Form as a text form
			GraphicsPath path = new GraphicsPath(FillMode.Alternate);
			path.AddString("Close? Right Click!", 
				new FontFamily("Verdana"), 
				(int)FontStyle.Bold, 50, new Point(0, 0),
				StringFormat.GenericDefault );
			path.AddRectangle(new Rectangle(20, 70, 100, 100));
		
			path.AddEllipse(new Rectangle(140, 70, 100, 100));
			path.AddEllipse(new Rectangle(260, 70, 100, 100));
			path.AddRectangle(new Rectangle(380, 70, 100, 100));
			Region rgn = new Region(path);
			this.Region = rgn;					
			#endregion
			this.BackColor = Color.Red;		
			g.Dispose();
		}

		private void FilledText_Click(object sender, System.EventArgs e)
		{		
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			GraphicsPath path = new GraphicsPath(FillMode.Alternate);
			path.AddString("Hello", 
				new FontFamily("Verdana"), 
				(int)FontStyle.Bold, 200, new Point(0, 0),
				StringFormat.GenericDefault );
			g.FillPath(new SolidBrush(Color.Green), path);
			Region rgn = new Region(path);
			g.SetClip(path);

			int h = this.Height;
			int clr = 255 / (this.Height/3);
			
			for(int i = 0; i<h; i+=3)
			{
				if(clr > 255)
					clr = clr % 255;
				g.DrawLine(new Pen(Color.FromArgb(255, clr, 0, 0), 2),
					0, i, this.Width , i);
				clr += i;
			}
			g.Dispose();
		}
	}
}

