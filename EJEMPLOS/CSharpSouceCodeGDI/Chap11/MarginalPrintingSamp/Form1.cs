using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;

namespace MarginalPrintingSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button NormalBtn;
		private System.Windows.Forms.Button MarginalBtn;
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
			this.MarginalBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// NormalBtn
			// 
			this.NormalBtn.Location = new System.Drawing.Point(32, 24);
			this.NormalBtn.Name = "NormalBtn";
			this.NormalBtn.Size = new System.Drawing.Size(104, 23);
			this.NormalBtn.TabIndex = 0;
			this.NormalBtn.Text = "Normal Printing";
			this.NormalBtn.Click += new System.EventHandler(this.NormalBtn_Click);
			// 
			// MarginalBtn
			// 
			this.MarginalBtn.Location = new System.Drawing.Point(32, 64);
			this.MarginalBtn.Name = "MarginalBtn";
			this.MarginalBtn.Size = new System.Drawing.Size(104, 23);
			this.MarginalBtn.TabIndex = 1;
			this.MarginalBtn.Text = "Marginal Printing";
			this.MarginalBtn.Click += new System.EventHandler(this.MarginalBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.MarginalBtn,
																		  this.NormalBtn});
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void NormalBtn_Click(object sender,
			System.EventArgs e)
		{
			// Create a PrintDocument
			PrintDocument pd = new PrintDocument(); 
			// Add PrintPage event handler
			pd.PrintPage += 
				new PrintPageEventHandler(NormalPrinting);
			// Print
			pd.Print();     		
		}
		private void MarginalBtn_Click(object sender,
			System.EventArgs e)
		{
			// Create a PrintDocument
			PrintDocument pd = new PrintDocument(); 
			// Add PrintPage event handler
			pd.PrintPage += 
				new PrintPageEventHandler(MarginPrinting);
			// Print
			pd.Print();             		
		}

		//All code in pd_PrintPage is used to
		// print just one page          
		public void NormalPrinting(object sender, 
			PrintPageEventArgs ev) 
		{
			// Set the top position as 1
			float ypos =  1;
			// Get the default left margin
			float leftMargin = ev.MarginBounds.Left;      
			//Create a font
			Font font = new Font("Arial",16);  
			// Get font's height
			float fontheight = font.GetHeight(ev.Graphics);
			// Draw four strings
			ev.Graphics.DrawString("Top Margin = " 
				+ ev.MarginBounds.Top.ToString(),
				font, Brushes.Black, 
				leftMargin, ypos);
			ypos = ypos + fontheight;
			ev.Graphics.DrawString("Bottom Margin = " 
				+ ev.MarginBounds.Bottom.ToString(),
				font, Brushes.Black, 
				leftMargin, ypos);
			ypos = ypos + fontheight;
			ev.Graphics.DrawString ("Left Margin = " 
				+ ev.MarginBounds.Left.ToString(),
				font, Brushes.Black,
				leftMargin, ypos);
			ypos = ypos + fontheight;
			ev.Graphics.DrawString ("Right Margin = " 
				+ ev.MarginBounds.Right.ToString(),
				font, Brushes.Black, 
				leftMargin, ypos);
			ypos = ypos + fontheight;
			// Draw a rectangle with default margins
			ev.Graphics.DrawRectangle(
				new Pen(Color.Black),
				ev.MarginBounds.X, 
				ev.MarginBounds.Y,
				ev.MarginBounds.Width, 
				ev.MarginBounds.Height);
		}

		
		public void MarginPrinting(object sender, 
			PrintPageEventArgs ev) 
		{
			// Set the top position as the default margin
			float ypos =  ev.MarginBounds.Top;
			// Get the default left margin
			float leftMargin = ev.MarginBounds.Left;  
			//Create a font
			Font font = new Font("Arial",16);   
			// Get font's height
			float fontheight = font.GetHeight(ev.Graphics);
			// Draw four strings
			ev.Graphics.DrawString("Top Margin = " + 
				ev.MarginBounds.Top.ToString(),
				font, Brushes.Black, 
				leftMargin, ypos);
			ypos = ypos + fontheight;
			ev.Graphics.DrawString("Bottom Margin = " + 
				ev.MarginBounds.Bottom.ToString(),
				font, Brushes.Black, 
				leftMargin, ypos);
			ypos = ypos + fontheight;
			ev.Graphics.DrawString ("Left Margin = " + 
				ev.MarginBounds.Left.ToString(),
				font, Brushes.Black, 
				leftMargin, ypos);
			ypos = ypos + fontheight;
			ev.Graphics.DrawString ("Right Margin = " 
				+ ev.MarginBounds.Right.ToString(),
				font,Brushes.Black, 
				leftMargin, ypos);
			ypos = ypos + fontheight;
			// Draw a rectangle with default margins
			ev.Graphics.DrawRectangle(
				new Pen(Color.Black),
				ev.MarginBounds.X,
				ev.MarginBounds.Y,
				ev.MarginBounds.Width,
				ev.MarginBounds.Height);
		}

	}
}



