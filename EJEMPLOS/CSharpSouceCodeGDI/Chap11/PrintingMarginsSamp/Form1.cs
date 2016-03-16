using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;

namespace PrintingMarginsSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem Normal;
		private System.Windows.Forms.MenuItem Margins;
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
			this.Normal = new System.Windows.Forms.MenuItem();
			this.Margins = new System.Windows.Forms.MenuItem();
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
																					  this.Normal,
																					  this.Margins});
			this.menuItem1.Text = "Printing";
			// 
			// Normal
			// 
			this.Normal.Index = 0;
			this.Normal.Text = "Normal";
			this.Normal.Click += new System.EventHandler(this.Normal_Click);
			// 
			// Margins
			// 
			this.Margins.Index = 1;
			this.Margins.Text = "Margins";
			this.Margins.Click += new System.EventHandler(this.Margins_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 285);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Printing Margins Sample";

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

		private void Normal_Click(object sender, 
			System.EventArgs e)
		{
			PrintDocument pd = new PrintDocument(); 
			pd.PrintPage += 
				new PrintPageEventHandler(NormalPrinting);
			pd.Print();		
		}

		//All code in pd_PrintPage is used to
		// print just one page			
		public void NormalPrinting(object sender, 
			PrintPageEventArgs ev) 
		{
			float ypos =  1;
			float leftMargin = ev.MarginBounds.Left;      
			//Create a font
			Font font = new Font("Arial",16);			
			float fontheight=font.GetHeight(ev.Graphics);
			ev.Graphics.DrawString("Top Margin = " 
				+ ev.MarginBounds.Top.ToString(),
				font,Brushes.Black, 
				leftMargin, ypos);
			ypos=ypos+fontheight;
			ev.Graphics.DrawString("Bottom Margin = " 
				+ ev.MarginBounds.Bottom.ToString(),
				font,Brushes.Black, 
				leftMargin, ypos);
			ypos=ypos+fontheight;
			ev.Graphics.DrawString ("Left Margin = " 
				+ ev.MarginBounds.Left.ToString(),
				font,Brushes.Black,
				leftMargin, ypos);
			ypos=ypos+fontheight;
			ev.Graphics.DrawString ("Right Margin = " 
				+ ev.MarginBounds.Right.ToString(),
				font,Brushes.Black, 
				leftMargin, ypos);
			ypos=ypos+fontheight;
			ev.Graphics.DrawRectangle(new Pen(Color.Black),
				ev.MarginBounds.X, 
				ev.MarginBounds.Y,
				ev.MarginBounds.Width, 
				ev.MarginBounds.Height);
		}

			
		public void MarginPrinting(object sender, 
			PrintPageEventArgs ev) 
		{
			float ypos =  ev.MarginBounds.Top;
			float leftMargin = ev.MarginBounds.Left;
     
			//Create a font
			Font font = new Font("Arial",16);	
		
			float fontheight=font.GetHeight(ev.Graphics);
			ev.Graphics.DrawString("Top Margin = " + 
				ev.MarginBounds.Top.ToString(),
				font,Brushes.Black, 
				leftMargin, ypos);
			ypos=ypos+fontheight;
			ev.Graphics.DrawString("Bottom Margin = " + 
				ev.MarginBounds.Bottom.ToString(),
				font,Brushes.Black, 
				leftMargin, ypos);
			ypos=ypos+fontheight;
			ev.Graphics.DrawString ("Left Margin = " + 
				ev.MarginBounds.Left.ToString(),
				font,Brushes.Black, 
				leftMargin, ypos);
			ypos=ypos+fontheight;
			ev.Graphics.DrawString ("Right Margin = " 
				+ ev.MarginBounds.Right.ToString(),
				font,Brushes.Black, 
				leftMargin, ypos);
			ypos=ypos+fontheight;
			ev.Graphics.DrawRectangle(new Pen(Color.Black),
				ev.MarginBounds.X,ev.MarginBounds.Y,
				ev.MarginBounds.Width,
				ev.MarginBounds.Height);
		}


		private void Margins_Click(object sender, 
			System.EventArgs e)
		{
			PrintDocument pd = new PrintDocument(); 
			pd.PrintPage += 
				new PrintPageEventHandler(MarginPrinting);
			pd.Print();				
		}
	}
}



