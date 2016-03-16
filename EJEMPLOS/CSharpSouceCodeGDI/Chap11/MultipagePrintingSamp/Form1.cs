using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Collections;
//using System.ComponentModel;
using System.Windows.Forms;

namespace PrintingExample26
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private int fontcount;
		private int fontposition = 1;
		private float ypos = 1;
		private PrintPreviewDialog previewDlg = null;
      

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;

		
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem DisplayFonts;

		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.DisplayFonts = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.SuspendLayout();
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
																					  this.DisplayFonts,
																					  this.menuItem5,
																					  this.menuItem2,
																					  this.menuItem3});
			this.menuItem1.Text = "File";
			// 
			// DisplayFonts
			// 
			this.DisplayFonts.Index = 0;
			this.DisplayFonts.Text = "Display Fonts";
			this.DisplayFonts.Click += new System.EventHandler(this.DisplayFonts_Click_1);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "-";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "Print";
			this.menuItem2.Click += new System.EventHandler(this.PrintMenuClick);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "Print Preview";
			this.menuItem3.Click += new System.EventHandler(this.PrintPreviewMenuClick);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(8, 0);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(424, 264);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "richTextBox1";
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Location = new System.Drawing.Point(17, 17);
			this.printPreviewDialog1.MaximumSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Opacity = 1;
			this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog1.Visible = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.richTextBox1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Multiple Page Printing";
			this.ResumeLayout(false);

		}
		#endregion

		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void DisplayFonts_Click(object sender, System.EventArgs e)
		{
			InstalledFontCollection ifc = new InstalledFontCollection();
			FontFamily[] ffs = ifc.Families;
			Font f;
			richTextBox1.Clear();
			fontcount=ffs.Length;
					
			foreach(FontFamily ff in ffs)
			{
				if (ff.IsStyleAvailable(System.Drawing.FontStyle.Regular))		
				{
					f = new Font(ff.GetName(1),12, FontStyle.Regular);
				}
				else if(ff.IsStyleAvailable(FontStyle.Bold))
				{
					f = new Font(ff.GetName(1),12, FontStyle.Bold);
				}
				else if (ff.IsStyleAvailable(FontStyle.Italic))
				{
					f = new Font(ff.GetName(1),12, FontStyle.Italic);
				}
				else
				{
					f = new Font(ff.GetName(1),12, FontStyle.Underline);
				}
							
				//Write text to window using selected
				richTextBox1.SelectionFont=f;
				richTextBox1.AppendText(ff.GetName(1)+"\r\n");
				richTextBox1.SelectionFont=f;
				richTextBox1.AppendText("abcdefghijklmnopqrstuvwxyz\r\n");
				richTextBox1.SelectionFont=f;
				richTextBox1.AppendText("ABCDEFGHIJKLMNOPQRSTUVWXYZ\r\n");
				richTextBox1.AppendText("=================================\r\n");
			}
		}	
			
		public void pd_PrintPage(object sender, 
			PrintPageEventArgs ev) 
		{				
			ypos = 1;
			float pageheight = ev.MarginBounds.Height;
			// Create a Graphics object
			Graphics g = ev.Graphics;	   
			// Get installed fonts
			InstalledFontCollection ifc = 
				new InstalledFontCollection();
			// Get font families
			FontFamily[] ffs = ifc.Families;
			// Draw string on the paper
			while(ypos+60 < pageheight && 
				fontposition < ffs.GetLength(0))
			{	
				// Get the font name
				Font f = 
					new Font(ffs[fontposition].GetName(0),25);	
				// Draw string
				g.DrawString(ffs[fontposition].GetName(0), f, 
					new SolidBrush(Color.Black),1,ypos);
				fontposition = fontposition+1;
				ypos = ypos + 60;
			}
			if (fontposition < ffs.GetLength(0))
			{
				// Has more pages??
				ev.HasMorePages = true;
			}
		}	

		private void PrintPreviewMenuClick(object sender, 
			System.EventArgs e)
		{
			// Create a PrintPreviewDialog
			previewDlg = new PrintPreviewDialog();
			// Create a PrintDocument
			PrintDocument pd = new PrintDocument(); 
			// Add print page event hanlder
			pd.PrintPage += 
				new PrintPageEventHandler(pd_PrintPage);
			// Set Document property of PrintPreviewDlg
			previewDlg.Document = pd;		
			// Display dialog
			previewDlg.Show();					
		}

		private void PrintMenuClick(object sender,
			System.EventArgs e)
		{
			// Create a PrintPreviewDialog
			previewDlg = new PrintPreviewDialog();
			// Create a PrintDocument
			PrintDocument pd = new PrintDocument(); 
			pd.DocumentName = "A Test Document";
			// Add print page event hanlder
			pd.PrintPage += 
				new PrintPageEventHandler(pd_PrintPage);
			// Print
			pd.Print();			
		}

		private void DisplayFonts_Click_1(object sender,
			System.EventArgs e)
		{
			// Create InstalledFontCollection object
			InstalledFontCollection ifc = 
				new InstalledFontCollection();
			// Get font families
			FontFamily[] ffs = ifc.Families;
			Font f;
			// Make sure tich text box is empty
			richTextBox1.Clear();
			// Read font families one by one and 
			// set font to some text
			// and add text to the text box
			foreach(FontFamily ff in ffs)
			{
				if (ff.IsStyleAvailable(FontStyle.Regular))		
					f = new Font(ff.GetName(1),
						12, FontStyle.Regular);
				else if(ff.IsStyleAvailable(FontStyle.Bold))
					f = new Font(ff.GetName(1),
						12, FontStyle.Bold);
				else if (ff.IsStyleAvailable(FontStyle.Italic))
					f = new Font(ff.GetName(1),
						12, FontStyle.Italic);
				else 
					f = new Font(ff.GetName(1),
						12, FontStyle.Underline);
				richTextBox1.SelectionFont=f;
				richTextBox1.AppendText(
					ff.GetName(1)+"\r\n");
				richTextBox1.SelectionFont=f;
				richTextBox1.AppendText(
					"abcdefghijklmnopqrstuvwxyz\r\n");
				richTextBox1.SelectionFont=f;
				richTextBox1.AppendText(
					"ABCDEFGHIJKLMNOPQRSTUVWXYZ\r\n");
				richTextBox1.AppendText(
					"==============================\r\n");
			}
		}
	}
}


