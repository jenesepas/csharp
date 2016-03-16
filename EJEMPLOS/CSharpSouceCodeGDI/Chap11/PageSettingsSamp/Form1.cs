using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;

namespace PageSettingsSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox PaperSizeCombo;
		private System.Windows.Forms.ComboBox PaperSourceCombo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton portraitButton;
		private System.Windows.Forms.RadioButton landscapeButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TextBox leftMarginBox;
		private System.Windows.Forms.TextBox rightMarginBox;
		private System.Windows.Forms.TextBox bottomMarginBox;
		private System.Windows.Forms.TextBox topMarginBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox boundsTextBox;
		private System.Windows.Forms.CheckBox ColorPrintingBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox printersList;
		private System.Windows.Forms.Button SetPropertiesBtn;
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.PaperSourceCombo = new System.Windows.Forms.ComboBox();
			this.PaperSizeCombo = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.landscapeButton = new System.Windows.Forms.RadioButton();
			this.portraitButton = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.bottomMarginBox = new System.Windows.Forms.TextBox();
			this.topMarginBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.rightMarginBox = new System.Windows.Forms.TextBox();
			this.leftMarginBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SetPropertiesBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.boundsTextBox = new System.Windows.Forms.TextBox();
			this.ColorPrintingBox = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.printersList = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.Desktop;
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.PaperSourceCombo,
																					this.PaperSizeCombo,
																					this.label2,
																					this.label1});
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.groupBox1.Location = new System.Drawing.Point(8, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(416, 96);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Paper Properties";
			// 
			// PaperSourceCombo
			// 
			this.PaperSourceCombo.Font = new System.Drawing.Font("Tahoma", 8F);
			this.PaperSourceCombo.Location = new System.Drawing.Point(104, 56);
			this.PaperSourceCombo.Name = "PaperSourceCombo";
			this.PaperSourceCombo.Size = new System.Drawing.Size(272, 21);
			this.PaperSourceCombo.TabIndex = 3;
			// 
			// PaperSizeCombo
			// 
			this.PaperSizeCombo.Font = new System.Drawing.Font("Tahoma", 8F);
			this.PaperSizeCombo.Location = new System.Drawing.Point(104, 24);
			this.PaperSizeCombo.Name = "PaperSizeCombo";
			this.PaperSizeCombo.Size = new System.Drawing.Size(272, 21);
			this.PaperSizeCombo.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Source:";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Size:";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.landscapeButton,
																					this.portraitButton});
			this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.groupBox2.Location = new System.Drawing.Point(8, 168);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(144, 96);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Paper Orientation";
			// 
			// landscapeButton
			// 
			this.landscapeButton.Font = new System.Drawing.Font("Tahoma", 8F);
			this.landscapeButton.Location = new System.Drawing.Point(16, 56);
			this.landscapeButton.Name = "landscapeButton";
			this.landscapeButton.TabIndex = 1;
			this.landscapeButton.Text = "Landscape";
			// 
			// portraitButton
			// 
			this.portraitButton.Font = new System.Drawing.Font("Tahoma", 8F);
			this.portraitButton.Location = new System.Drawing.Point(16, 24);
			this.portraitButton.Name = "portraitButton";
			this.portraitButton.TabIndex = 0;
			this.portraitButton.Text = "Portrait";
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.bottomMarginBox,
																					this.topMarginBox,
																					this.label5,
																					this.label6,
																					this.rightMarginBox,
																					this.leftMarginBox,
																					this.label4,
																					this.label3});
			this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.groupBox3.Location = new System.Drawing.Point(168, 168);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(256, 96);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Paper Margins (In Inches)";
			// 
			// bottomMarginBox
			// 
			this.bottomMarginBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bottomMarginBox.Font = new System.Drawing.Font("Tahoma", 8F);
			this.bottomMarginBox.Location = new System.Drawing.Point(192, 60);
			this.bottomMarginBox.Name = "bottomMarginBox";
			this.bottomMarginBox.Size = new System.Drawing.Size(56, 20);
			this.bottomMarginBox.TabIndex = 7;
			this.bottomMarginBox.Text = "";
			// 
			// topMarginBox
			// 
			this.topMarginBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.topMarginBox.Font = new System.Drawing.Font("Tahoma", 8F);
			this.topMarginBox.Location = new System.Drawing.Point(56, 60);
			this.topMarginBox.Name = "topMarginBox";
			this.topMarginBox.Size = new System.Drawing.Size(56, 20);
			this.topMarginBox.TabIndex = 6;
			this.topMarginBox.Text = "";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
			this.label5.Location = new System.Drawing.Point(136, 60);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 24);
			this.label5.TabIndex = 5;
			this.label5.Text = "Bottom:";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
			this.label6.Location = new System.Drawing.Point(16, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 24);
			this.label6.TabIndex = 4;
			this.label6.Text = "Top:";
			// 
			// rightMarginBox
			// 
			this.rightMarginBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rightMarginBox.Font = new System.Drawing.Font("Tahoma", 8F);
			this.rightMarginBox.Location = new System.Drawing.Point(192, 24);
			this.rightMarginBox.Name = "rightMarginBox";
			this.rightMarginBox.Size = new System.Drawing.Size(56, 20);
			this.rightMarginBox.TabIndex = 3;
			this.rightMarginBox.Text = "";
			// 
			// leftMarginBox
			// 
			this.leftMarginBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.leftMarginBox.Font = new System.Drawing.Font("Tahoma", 8F);
			this.leftMarginBox.Location = new System.Drawing.Point(56, 24);
			this.leftMarginBox.Name = "leftMarginBox";
			this.leftMarginBox.Size = new System.Drawing.Size(56, 20);
			this.leftMarginBox.TabIndex = 2;
			this.leftMarginBox.Text = "";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
			this.label4.Location = new System.Drawing.Point(136, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 24);
			this.label4.TabIndex = 1;
			this.label4.Text = "Right:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
			this.label3.Location = new System.Drawing.Point(16, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 24);
			this.label3.TabIndex = 0;
			this.label3.Text = "Left:";
			// 
			// SetPropertiesBtn
			// 
			this.SetPropertiesBtn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.SetPropertiesBtn.Location = new System.Drawing.Point(160, 328);
			this.SetPropertiesBtn.Name = "SetPropertiesBtn";
			this.SetPropertiesBtn.Size = new System.Drawing.Size(96, 23);
			this.SetPropertiesBtn.TabIndex = 3;
			this.SetPropertiesBtn.Text = "Set Properties";
			this.SetPropertiesBtn.Click += new System.EventHandler(this.SetPropertiesBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.CancelBtn.Location = new System.Drawing.Point(280, 328);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 288);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 23);
			this.label7.TabIndex = 6;
			this.label7.Text = "Bounds (Rectangle):";
			// 
			// boundsTextBox
			// 
			this.boundsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.boundsTextBox.Enabled = false;
			this.boundsTextBox.Location = new System.Drawing.Point(144, 288);
			this.boundsTextBox.Name = "boundsTextBox";
			this.boundsTextBox.Size = new System.Drawing.Size(184, 20);
			this.boundsTextBox.TabIndex = 7;
			this.boundsTextBox.Text = "";
			this.boundsTextBox.TextChanged += new System.EventHandler(this.boundsTextBox_TextChanged);
			// 
			// ColorPrintingBox
			// 
			this.ColorPrintingBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.ColorPrintingBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ColorPrintingBox.Location = new System.Drawing.Point(16, 320);
			this.ColorPrintingBox.Name = "ColorPrintingBox";
			this.ColorPrintingBox.TabIndex = 10;
			this.ColorPrintingBox.Text = "Color Printing";
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.label8.Location = new System.Drawing.Point(8, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 24);
			this.label8.TabIndex = 11;
			this.label8.Text = "Available Printers:";
			// 
			// printersList
			// 
			this.printersList.Font = new System.Drawing.Font("Tahoma", 8F);
			this.printersList.Location = new System.Drawing.Point(184, 16);
			this.printersList.Name = "printersList";
			this.printersList.Size = new System.Drawing.Size(232, 21);
			this.printersList.TabIndex = 12;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ClientSize = new System.Drawing.Size(432, 357);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.printersList,
																		  this.label8,
																		  this.ColorPrintingBox,
																		  this.boundsTextBox,
																		  this.label7,
																		  this.CancelBtn,
																		  this.SetPropertiesBtn,
																		  this.groupBox3,
																		  this.groupBox2,
																		  this.groupBox1});
			this.Name = "Form1";
			this.Text = "PageSetupDialog Sample";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
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

		
		private void SetPropertiesBtn_Click(object sender, 
			System.EventArgs e)
		{
			// Set other default properties
			PrinterSettings settings = new PrinterSettings();
			PageSettings pgSettings = 
				settings.DefaultPageSettings;
			// Color printing
			if (ColorPrintingBox.Checked )
				pgSettings.Color = true;
			else 
				pgSettings.Color  = false;
					
			// Landscape or portrait
			if(landscapeButton.Checked )
				pgSettings.Landscape = true;
			else
				pgSettings.Landscape = false;
		}

		private void CancelBtn_Click(object sender, 
			System.EventArgs e)
		{
			this.Close();		
		}

		private void Form1_Load(object sender,
			System.EventArgs e)
		{
			// Load all available printers
			LoadPrinters();
			// Load Paper sizes
			LoadPaperSizes();
			// Load Paper sources
			LoadPaperSources();
			// Other Settings
			ReadOtherSettings();
		}
		private void LoadPaperSizes()
		{
			PaperSizeCombo.DisplayMember = "PaperName";
			PrinterSettings settings = new PrinterSettings();
			// Get all Paper sizes and add to combo list			
			foreach(PaperSize size in settings.PaperSizes)
			{
				PaperSizeCombo.Items.Add(size.Kind.ToString());
				// You can even read paper name and all PaperSize
				// Properperties by uncommenting these two lines
				//PaperSizeCombo.Items.Add
					//(size.PaperName.ToString());
				//PaperSizeCombo.Items.Add(size.ToString());
				
			}
			// Create a custom paper size and add to the list
			PaperSize customPaperSize = 
				new PaperSize("Custom Size", 50, 100);
			// You can also change properties
			customPaperSize.PaperName = "New Custom Size";
			customPaperSize.Height = 200;
			customPaperSize.Width = 100;
			// Don't assign Kind prop. It's read only
			// customPaperSize.Kind = PaperKind.A4;
			// Add CustomSize			
			PaperSizeCombo.Items.Add(customPaperSize);
		}
		private void LoadPaperSources()
		{
			PrinterSettings settings = new PrinterSettings();
			PaperSourceCombo.DisplayMember="SourceName";
			// Add all Paper sources to the combo
            foreach(PaperSource source in settings.PaperSources) 
			{
				PaperSourceCombo.Items.Add(source.ToString());
				// You can even add Kind and SourceName 
				//PaperSourceCombo.Items.Add
					//(source.Kind.ToString());
				//PaperSourceCombo.Items.Add
					//(source.SourceName.ToString());
            }
		}
		private void LoadPrinters()
		{
			// Load all available printers
			foreach(String printer in 
				PrinterSettings.InstalledPrinters)
			{
				printersList.Items.Add(printer.ToString());
			}
			printersList.Select(0, 1);
		}
		private void ReadOtherSettings()
		{
			// Set other default properties
			PrinterSettings settings = new PrinterSettings();
			PageSettings pgSettings = 
				settings.DefaultPageSettings;
			// Color printing
			if(pgSettings.Color)
				ColorPrintingBox.Checked = true;
			else 
				ColorPrintingBox.Checked = false;
			// Page Margins
			leftMarginBox.Text = 
				pgSettings.Bounds.Left.ToString();
			rightMarginBox.Text = 
				pgSettings.Bounds.Right.ToString();
			topMarginBox.Text = 
				pgSettings.Bounds.Top.ToString();
			bottomMarginBox.Text = 
				pgSettings.Bounds.Bottom.ToString();
			// Landscape or portrait
			if(pgSettings.Landscape)
				landscapeButton.Checked = true;
			else
				portraitButton.Checked = true;
			// Bounds
			boundsTextBox.Text = 
				pgSettings.Bounds.ToString();
		}

		private void boundsTextBox_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}





