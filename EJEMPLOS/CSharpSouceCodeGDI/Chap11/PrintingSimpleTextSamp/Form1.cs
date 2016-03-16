using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.IO;

namespace PrintingSimpleTextSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button PrintingText;
		private System.Windows.Forms.ComboBox printersList;
		private System.Windows.Forms.Button PrintEvents;

		private SolidBrush redBrush;
		private Pen bluePen;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button BrowseBtn;
		private System.Windows.Forms.Button PrintTextFile;

		private Font verdana10Font;
		private StreamReader reader;

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
			this.PrintingText = new System.Windows.Forms.Button();
			this.printersList = new System.Windows.Forms.ComboBox();
			this.PrintEvents = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.BrowseBtn = new System.Windows.Forms.Button();
			this.PrintTextFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// PrintingText
			// 
			this.PrintingText.Location = new System.Drawing.Point(8, 280);
			this.PrintingText.Name = "PrintingText";
			this.PrintingText.Size = new System.Drawing.Size(88, 32);
			this.PrintingText.TabIndex = 0;
			this.PrintingText.Text = "Print Text";
			this.PrintingText.Click += new System.EventHandler(this.PrintingText_Click);
			// 
			// printersList
			// 
			this.printersList.Location = new System.Drawing.Point(16, 16);
			this.printersList.Name = "printersList";
			this.printersList.Size = new System.Drawing.Size(121, 21);
			this.printersList.TabIndex = 1;
			this.printersList.Text = "comboBox1";
			// 
			// PrintEvents
			// 
			this.PrintEvents.Location = new System.Drawing.Point(112, 280);
			this.PrintEvents.Name = "PrintEvents";
			this.PrintEvents.Size = new System.Drawing.Size(96, 32);
			this.PrintEvents.TabIndex = 2;
			this.PrintEvents.Text = "Print Events";
			this.PrintEvents.Click += new System.EventHandler(this.PrintEvents_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 136);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(208, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			// 
			// BrowseBtn
			// 
			this.BrowseBtn.Location = new System.Drawing.Point(240, 128);
			this.BrowseBtn.Name = "BrowseBtn";
			this.BrowseBtn.Size = new System.Drawing.Size(112, 32);
			this.BrowseBtn.TabIndex = 4;
			this.BrowseBtn.Text = "Browse Text File";
			this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
			// 
			// PrintTextFile
			// 
			this.PrintTextFile.Location = new System.Drawing.Point(240, 280);
			this.PrintTextFile.Name = "PrintTextFile";
			this.PrintTextFile.Size = new System.Drawing.Size(128, 32);
			this.PrintTextFile.TabIndex = 5;
			this.PrintTextFile.Text = "Print Text File";
			this.PrintTextFile.Click += new System.EventHandler(this.PrintTextFile_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.PrintTextFile,
																		  this.BrowseBtn,
																		  this.textBox1,
																		  this.PrintEvents,
																		  this.printersList,
																		  this.PrintingText});
			this.Name = "Form1";
			this.Text = "Printing Simple Text";
			this.Load += new System.EventHandler(this.Form1_Load);
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

	
		private void PrintingText_Click(object sender, System.EventArgs e)
		{
			string printerName = printersList.SelectedItem.ToString();
			PrintDocument pd = new PrintDocument(); 
			pd.PrinterSettings.PrinterName = printerName;
			pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
			// Print the document.
			pd.Print();
		}
		//All code in pd_PrintPage is used to print just one page			
		public void pd_PrintPage(object sender, PrintPageEventArgs ev) 
		{
			// Get the Graphics object attached to 
			// PrintPage event args
			Graphics g = ev.Graphics;

			float ypos =  1;
			float leftMargin = ev.MarginBounds.Left;      
			//Create a font
			Font font = new Font("Arial",16);	
			float fontheight=font.GetHeight(ev.Graphics);
			g.DrawString("Top Margin = " 
				+ ev.MarginBounds.Top.ToString(),
				font,Brushes.Black, leftMargin, ypos);
			ypos=ypos+fontheight;
			g.DrawString("Bottom Margin = " 
				+ ev.MarginBounds.Bottom.ToString(),
				font,Brushes.Black, leftMargin, ypos);
			ypos=ypos+fontheight;
			g.DrawString ("Left Margin = " 
				+ ev.MarginBounds.Left.ToString(),
				font,Brushes.Black, leftMargin, ypos);
			ypos=ypos+fontheight;
			g.DrawString ("Right Margin = " 
				+ ev.MarginBounds.Right.ToString(),
				font,Brushes.Black, leftMargin, ypos);
			ypos=ypos+fontheight;
			g.DrawRectangle(new Pen(Color.Black), 
				ev.MarginBounds.X,ev.MarginBounds.Y,
				ev.MarginBounds.Width,ev.MarginBounds.Height);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			foreach(String printer in PrinterSettings.InstalledPrinters)
			{
				printersList.Items.Add(printer.ToString());
			}
		}

		private void PrintEvents_Click(object sender, 
			System.EventArgs e)
		{
			try
			{

				string printerName = 
					printersList.SelectedItem.ToString();
				PrintDocument pd = new PrintDocument(); 
				pd.PrinterSettings.PrinterName = printerName;
				pd.BeginPrint += 
					new PrintEventHandler(BgnPrntEventHandler);
				pd.PrintPage += 
					new PrintPageEventHandler(PrntPgEventHandler);
				pd.EndPrint += 
					new PrintEventHandler(EndPrntEventHandler);
				// Print the document.
				pd.Print();
			}
			catch(Exception exp)
			{
				MessageBox.Show(exp.Message);
			}
			finally
			{
				// Use later
			}
		}
		
		public void BgnPrntEventHandler(object sender, 
			PrintEventArgs peaArgs) 
		{
			redBrush = new SolidBrush(Color.Red);
			bluePen = new Pen(Color.Blue, 3);
		}
		
		public void EndPrntEventHandler(object sender, 
			PrintEventArgs peaArgs) 
		{
			redBrush.Dispose();
			bluePen.Dispose();			
		}
		
		public void PrntPgEventHandler(object sender, 
			PrintPageEventArgs ppeArgs) 
		{
		try
		{
			PrinterSettings ps = new PrinterSettings();
			Graphics g = ppeArgs.Graphics;
			PageSettings pgSettings = new PageSettings(ps);
			ppeArgs.PageSettings.Margins.Left = 50;
			ppeArgs.PageSettings.Margins.Right = 100;
			ppeArgs.PageSettings.Margins.Top = 50;
			ppeArgs.PageSettings.Margins.Bottom = 100;
			Rectangle rect1 = ppeArgs.MarginBounds;
			Rectangle rect2 = ppeArgs.PageBounds;			
			g.DrawRectangle(bluePen, rect1);			
			g.FillRectangle(redBrush, rect2);
		}
		catch(Exception exp)
		{
			MessageBox.Show(exp.Message);
		}
		finally
		{
			// Use later
		}
		}

		private void PrintTextFile_Click(object sender, 
			System.EventArgs e)
		{
			// Get the file name
			string filename = textBox1.Text.ToString();
			// Check if its not empty
			if(filename.Equals(string.Empty))
			{
				MessageBox.Show("Enter a valid file name");
				textBox1.Focus();
				return;
			}
			// Create a StreamReader
			reader = new StreamReader(filename);
			// Create a verdana font with size 10
			verdana10Font = new Font("Verdana", 10);
			// Create a PrintDocument
			PrintDocument pd = new PrintDocument();
			// Add PrintPage event handler
			pd.PrintPage += new PrintPageEventHandler
				(this.PrintTextFileHandler);
			// Call Print method
			pd.Print();
			// Close the reader
			if(reader != null)
				reader.Close();
		}
		
		private void PrintTextFileHandler(object sender, 
			PrintPageEventArgs ppeArgs) 
		{
			// Get the Graphics object
			Graphics g = ppeArgs.Graphics;
            float linesPerPage = 0;
			float yPos = 0;
			int count = 0;
			// Read margins from the PrintPageEventArgs
			float leftMargin = ppeArgs.MarginBounds.Left;
			float topMargin = ppeArgs.MarginBounds.Top;
			string line = null;
			// Calculate the lines per page based on the 
			// height of the page and the height of the 
			// font
			linesPerPage = ppeArgs.MarginBounds.Height / 
				verdana10Font.GetHeight(g);
			// Now read lines one by one using StreamReader
			while(count < linesPerPage && 
				((line = reader.ReadLine()) != null)) 
			{
				// Calculate the starting position
				yPos = topMargin + (count * 
					verdana10Font.GetHeight(g));
				// Draw text
				g.DrawString(line, verdana10Font, Brushes.Black, 
					leftMargin, yPos, new StringFormat());
				// Move to next line
				count++;
			}
            // If PrintPageEventArgs has more pages 
			// to print
			if(line != null)
				ppeArgs.HasMorePages = true;
			else
				ppeArgs.HasMorePages = false;
		}


		private void BrowseBtn_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog fdlg = new OpenFileDialog(); 
			fdlg.Title = "C# Corner Open File Dialog" ; 
			fdlg.InitialDirectory = @"c:\" ; 
			fdlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*" ; 
			fdlg.FilterIndex = 2 ; 
			fdlg.RestoreDirectory = true ; 
			if(fdlg.ShowDialog() == DialogResult.OK) 
			{ 
				textBox1.Text = fdlg.FileName ; 
			} 
		}

		private void Form1_Paint(object sender, 
			System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			SolidBrush redBrush =
				new SolidBrush(Color.Red);
			Rectangle rect = 
				new Rectangle(150, 80, 200, 140); 
			g.FillPie(greenBrush, 40, 20, 200,
				40, 0.0f, 60.0f );
			g.FillRectangle(blueBrush, rect);
		}

	}
}




