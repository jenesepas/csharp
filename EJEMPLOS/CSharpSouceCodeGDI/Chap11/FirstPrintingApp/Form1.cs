using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;

namespace FirstPrintingApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ComboBox PrintersList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button GetProperties;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.ListBox ResolutionsList;
		private System.Windows.Forms.ListBox PaperSizesList;
		private System.Windows.Forms.CheckBox SuppColorsChkBox;
		private System.Windows.Forms.CheckBox IsValidChkBox;
		private System.Windows.Forms.CheckBox CollateChkBox;
		private System.Windows.Forms.CheckBox CanDuplexChkBox;
		private System.Windows.Forms.CheckBox IsPlotterChkBox;
		private System.Windows.Forms.CheckBox IsDefPrinterChkBox;
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
			this.button2 = new System.Windows.Forms.Button();
			this.ResolutionsList = new System.Windows.Forms.ListBox();
			this.button3 = new System.Windows.Forms.Button();
			this.PrintersList = new System.Windows.Forms.ComboBox();
			this.PaperSizesList = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuppColorsChkBox = new System.Windows.Forms.CheckBox();
			this.IsValidChkBox = new System.Windows.Forms.CheckBox();
			this.CollateChkBox = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.CanDuplexChkBox = new System.Windows.Forms.CheckBox();
			this.IsPlotterChkBox = new System.Windows.Forms.CheckBox();
			this.IsDefPrinterChkBox = new System.Windows.Forms.CheckBox();
			this.GetProperties = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(336, 72);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(144, 24);
			this.button2.TabIndex = 2;
			this.button2.Text = "Get Printer Resolution";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// ResolutionsList
			// 
			this.ResolutionsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ResolutionsList.Location = new System.Drawing.Point(304, 104);
			this.ResolutionsList.Name = "ResolutionsList";
			this.ResolutionsList.Size = new System.Drawing.Size(224, 93);
			this.ResolutionsList.TabIndex = 3;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 64);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(136, 32);
			this.button3.TabIndex = 4;
			this.button3.Text = "Get Paper Size";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// PrintersList
			// 
			this.PrintersList.Location = new System.Drawing.Point(8, 32);
			this.PrintersList.Name = "PrintersList";
			this.PrintersList.Size = new System.Drawing.Size(200, 21);
			this.PrintersList.TabIndex = 6;
			// 
			// PaperSizesList
			// 
			this.PaperSizesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PaperSizesList.Location = new System.Drawing.Point(8, 104);
			this.PaperSizesList.Name = "PaperSizesList";
			this.PaperSizesList.Size = new System.Drawing.Size(288, 93);
			this.PaperSizesList.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Available Printers";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.textBox2,
																					this.label3,
																					this.SuppColorsChkBox,
																					this.IsValidChkBox,
																					this.CollateChkBox,
																					this.textBox1,
																					this.label2,
																					this.CanDuplexChkBox,
																					this.IsPlotterChkBox,
																					this.IsDefPrinterChkBox});
			this.groupBox1.Location = new System.Drawing.Point(8, 248);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(496, 168);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Printer Properties";
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(216, 56);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(96, 20);
			this.textBox2.TabIndex = 9;
			this.textBox2.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(152, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Copies:";
			// 
			// SuppColorsChkBox
			// 
			this.SuppColorsChkBox.Location = new System.Drawing.Point(152, 112);
			this.SuppColorsChkBox.Name = "SuppColorsChkBox";
			this.SuppColorsChkBox.Size = new System.Drawing.Size(152, 24);
			this.SuppColorsChkBox.TabIndex = 7;
			this.SuppColorsChkBox.Text = "Supports Colors";
			// 
			// IsValidChkBox
			// 
			this.IsValidChkBox.Location = new System.Drawing.Point(152, 88);
			this.IsValidChkBox.Name = "IsValidChkBox";
			this.IsValidChkBox.Size = new System.Drawing.Size(136, 16);
			this.IsValidChkBox.TabIndex = 6;
			this.IsValidChkBox.Text = "IsValid";
			// 
			// CollateChkBox
			// 
			this.CollateChkBox.Location = new System.Drawing.Point(16, 136);
			this.CollateChkBox.Name = "CollateChkBox";
			this.CollateChkBox.Size = new System.Drawing.Size(80, 24);
			this.CollateChkBox.TabIndex = 5;
			this.CollateChkBox.Text = "Collate";
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(104, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(280, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "Printer Name:";
			// 
			// CanDuplexChkBox
			// 
			this.CanDuplexChkBox.Location = new System.Drawing.Point(16, 104);
			this.CanDuplexChkBox.Name = "CanDuplexChkBox";
			this.CanDuplexChkBox.Size = new System.Drawing.Size(80, 32);
			this.CanDuplexChkBox.TabIndex = 2;
			this.CanDuplexChkBox.Text = "CanDuplex";
			// 
			// IsPlotterChkBox
			// 
			this.IsPlotterChkBox.Location = new System.Drawing.Point(16, 72);
			this.IsPlotterChkBox.Name = "IsPlotterChkBox";
			this.IsPlotterChkBox.Size = new System.Drawing.Size(80, 32);
			this.IsPlotterChkBox.TabIndex = 1;
			this.IsPlotterChkBox.Text = "IsPlotter";
			// 
			// IsDefPrinterChkBox
			// 
			this.IsDefPrinterChkBox.Location = new System.Drawing.Point(16, 40);
			this.IsDefPrinterChkBox.Name = "IsDefPrinterChkBox";
			this.IsDefPrinterChkBox.Size = new System.Drawing.Size(104, 32);
			this.IsDefPrinterChkBox.TabIndex = 0;
			this.IsDefPrinterChkBox.Text = "IsDefaultPrinter";
			// 
			// GetProperties
			// 
			this.GetProperties.Location = new System.Drawing.Point(8, 208);
			this.GetProperties.Name = "GetProperties";
			this.GetProperties.Size = new System.Drawing.Size(152, 32);
			this.GetProperties.TabIndex = 9;
			this.GetProperties.Text = "Get Printer Properties";
			this.GetProperties.Click += new System.EventHandler(this.GetProperties_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 429);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.GetProperties,
																		  this.groupBox1,
																		  this.label1,
																		  this.PrintersList,
																		  this.PaperSizesList,
																		  this.button3,
																		  this.ResolutionsList,
																		  this.button2});
			this.Name = "Form1";
			this.Text = "Printer Settings";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
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
			
		}

		private void button2_Click(object sender,
			System.EventArgs e)
		{
			// If there is no printer selected
			if(PrintersList.Text == string.Empty)
			{
				MessageBox.Show("Select a printer from the list");
				return;
			}
			// Get the current selected printer from the 
			// printers list
			string str = PrintersList.SelectedItem.ToString();	
			// Create a PrinterSetting object
			PrinterSettings ps = new PrinterSettings();
			// Set the current printer 
			ps.PrinterName = str;
			// Read all printer resolutions and add
			// the the listBox
			foreach(PrinterResolution pr 
						in ps.PrinterResolutions)
			{
				ResolutionsList.Items.Add(pr.ToString());
			}
		}

		private void button3_Click(object sender,
			System.EventArgs e)
		{
			// If there is no printer selected
			if(PrintersList.Text == string.Empty)
			{
				MessageBox.Show("Select a printer from the list");
				return;
			}
			// Create Printer Settings
			PrinterSettings prs = new PrinterSettings();
			// Get the current selected printer from the 
			// printers list
			string str = PrintersList.SelectedItem.ToString();	
			prs.PrinterName = str;
			// Read paper sizes and add to the ListBox
			foreach(PaperSize ps in prs.PaperSizes)
			{
				PaperSizesList.Items.Add(ps.ToString());
			}
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
				PrintersList.Items.Add(printer.ToString());
			}
		}

		private void GetProperties_Click(object sender,
            System.EventArgs e)
        {
			// If there is no printer selected
			if(PrintersList.Text == string.Empty)
			{
				MessageBox.Show("Select a printer from the list");
				return;
			}

            PrinterSettings ps = new PrinterSettings();
            string str = PrintersList.SelectedItem.ToString();  
			ps.PrinterName = str;
			// Check if its a valid printer
			if(!ps.IsValid)
			{
				MessageBox.Show("Not a valid printer");
				return;
			}          
			// Set printer name and copies
            textBox1.Text = ps.PrinterName.ToString();
            textBox2.Text = ps.Copies.ToString();
                        
            // If priter is the default printer
            if (ps.IsDefaultPrinter == true)
                IsDefPrinterChkBox.Checked = true;
            else
                IsDefPrinterChkBox.Checked = false;      
            // If priter is a plotter
            if (ps.IsPlotter)
                IsPlotterChkBox.Checked = true;
            else
                IsPlotterChkBox.Checked = false;
            // Can Duplex?
            if (ps.CanDuplex)
                CanDuplexChkBox.Checked = true;
            else
                CanDuplexChkBox.Checked = false;
            // Collate?
            if (ps.Collate)
                CollateChkBox.Checked = true;
            else
                CollateChkBox.Checked = false;
            // Printer is valid or not
            if (ps.IsValid)
                IsValidChkBox.Checked = true;
            else
                IsValidChkBox.Checked = false;
            // Color printer or not?
            if (ps.SupportsColor)
                SuppColorsChkBox.Checked = true;
            else
                SuppColorsChkBox.Checked = false;
        }
	}
}
