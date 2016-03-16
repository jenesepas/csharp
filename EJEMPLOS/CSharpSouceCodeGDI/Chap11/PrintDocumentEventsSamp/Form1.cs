using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;

namespace PrintDocumentEventsSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button PrintEvents;
		private System.Windows.Forms.ComboBox printersList;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private SolidBrush redBrush = null; 
		private Pen bluePen = null; 

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
			this.PrintEvents = new System.Windows.Forms.Button();
			this.printersList = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// PrintEvents
			// 
			this.PrintEvents.Location = new System.Drawing.Point(80, 192);
			this.PrintEvents.Name = "PrintEvents";
			this.PrintEvents.Size = new System.Drawing.Size(136, 32);
			this.PrintEvents.TabIndex = 0;
			this.PrintEvents.Text = "PrintEvents Start";
			this.PrintEvents.Click += new System.EventHandler(this.PrintEvents_Click);
			// 
			// printersList
			// 
			this.printersList.Location = new System.Drawing.Point(16, 8);
			this.printersList.Name = "printersList";
			this.printersList.Size = new System.Drawing.Size(121, 21);
			this.printersList.TabIndex = 1;
			this.printersList.Text = "comboBox1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(360, 277);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.printersList,
																		  this.PrintEvents});
			this.Name = "Form1";
			this.Text = "PrintDocument Events Sample";
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

		private void PrintEvents_Click(object sender, 
			System.EventArgs e)
		{
			// Get the selected printer
			string printerName = 
			printersList.SelectedItem.ToString();
			// Create a PrintDocument and set the
			// current printer
			PrintDocument pd = new PrintDocument(); 
			pd.PrinterSettings.PrinterName = printerName;
			// BegingPaint event
			pd.BeginPrint += 
				new PrintEventHandler(BgnPrntEventHandler);
			// PrintPage event
			pd.PrintPage += 
				new PrintPageEventHandler(PrntPgEventHandler);
			// EndPaint event
			pd.EndPrint += 
				new PrintEventHandler(EndPrntEventHandler);
			// Print the document.
			pd.Print();		
		}

		public void BgnPrntEventHandler(object sender, 
			PrintEventArgs peaArgs) 
		{
			// Create a brush and a pen
			redBrush = new SolidBrush(Color.Red);
			bluePen = new Pen(Color.Blue, 3);
		}

		public void EndPrntEventHandler(object sender, 
			PrintEventArgs peaArgs) 
		{
			// Release brush and pen objects
			redBrush.Dispose();
			bluePen.Dispose();          
		}
    
		public void PrntPgEventHandler(object sender, 
			PrintPageEventArgs ppeArgs) 
		{
			// Create PrinterSettings
			PrinterSettings ps = new PrinterSettings();
			// Get the Graphics object
			Graphics g = ppeArgs.Graphics;
			// Create a PageSettings
			PageSettings pgSettings = new PageSettings(ps);
			// Set page margins
			ppeArgs.PageSettings.Margins.Left = 50;
			ppeArgs.PageSettings.Margins.Right = 100;
			ppeArgs.PageSettings.Margins.Top = 50;
			ppeArgs.PageSettings.Margins.Bottom = 100;
			// Create two rectangles
			Rectangle rect1 = new Rectangle(20, 20, 50, 50);
			Rectangle rect2 = 
				new Rectangle(100, 100, 50, 100);      
			// Draw and fill rectangles
			g.DrawRectangle(bluePen, rect1);            
			g.FillRectangle(redBrush, rect2);
		}

		private void Form1_Load(object sender, 
			System.EventArgs e)
		{
			// See if installed printers are 0
			if( PrinterSettings.InstalledPrinters.Count <= 0)
			{
				MessageBox.Show("Printer not found!");
				return;
			}
			// Get all the available printers and add to the 
			// ComboBox
			foreach(String printer in 
				PrinterSettings.InstalledPrinters)
			{
				printersList.Items.Add(printer.ToString());
			}
		}
	}
}


