using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;

namespace HelloPrinterSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button HelloPrinterBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox printersList;
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
			this.HelloPrinterBtn = new System.Windows.Forms.Button();
			this.printersList = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// HelloPrinterBtn
			// 
			this.HelloPrinterBtn.Location = new System.Drawing.Point(104, 112);
			this.HelloPrinterBtn.Name = "HelloPrinterBtn";
			this.HelloPrinterBtn.Size = new System.Drawing.Size(112, 32);
			this.HelloPrinterBtn.TabIndex = 0;
			this.HelloPrinterBtn.Text = "Hello Printer";
			this.HelloPrinterBtn.Click += new System.EventHandler(this.HelloPrinterBtn_Click);
			// 
			// printersList
			// 
			this.printersList.Location = new System.Drawing.Point(128, 16);
			this.printersList.Name = "printersList";
			this.printersList.Size = new System.Drawing.Size(136, 21);
			this.printersList.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Available Printers:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 221);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.printersList,
																		  this.HelloPrinterBtn});
			this.Name = "Form1";
			this.Text = "My First Printing Application";
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

		// The PrintPage event handler
		public void pd_PrintPage(object sender,
			PrintPageEventArgs ev) 
		{
			// Get the Graphics object 
			Graphics g = ev.Graphics;
			//Create a font arial with size 16
			Font font = new Font("Arial", 16);	
			// Create a solid brush with black color
			SolidBrush brush = 
				new SolidBrush(Color.Black);		
			// Draw Hello Printer! 
			g.DrawString("Hello Printer!",
				font, brush, 
				new Rectangle(20, 20, 200, 100));
		}

		private void HelloPrinterBtn_Click(object sender,
			System.EventArgs e)
		{
			// Create a PrintDocumet
			PrintDocument pd = new PrintDocument(); 
			// Set PrinterName as the selected printer
			// in the printers list
			pd.PrinterSettings.PrinterName = 
				printersList.SelectedItem.ToString();
			// Add PrintPage event handler
			pd.PrintPage += 
				new PrintPageEventHandler(pd_PrintPage);
			// Print the document.
			pd.Print();		
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


	