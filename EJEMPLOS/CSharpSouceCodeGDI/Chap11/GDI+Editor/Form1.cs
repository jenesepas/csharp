using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.IO;

namespace FontCollectionSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button button2;
		private Color textColor;
		private int textSize;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem OpenFile;
		private System.Windows.Forms.MenuItem SaveFileAs;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem PrintMenu;
		private System.Windows.Forms.MenuItem PrintPreviewMenu;
		private System.Windows.Forms.MenuItem PageSetupMenu;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.MenuItem UndoMenu;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem CutMenu;
		private System.Windows.Forms.MenuItem CopyMenu;
		private System.Windows.Forms.MenuItem PasteMenu;
		private System.Windows.Forms.MenuItem DeleteMenu;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem GotoMenu;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem SelectAllMenu;
		private System.Windows.Forms.MenuItem DeleteAllMenu;
		private System.IO.FileSystemWatcher fileSystemWatcher1;

		private static readonly string noFilename = "Untitled";
		private string curFilename = null;
		private bool dirty = false;
		private bool fileOnDiskModified = false;
		private PageSettings storedPageSettings = null ;


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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.OpenFile = new System.Windows.Forms.MenuItem();
			this.SaveFileAs = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.PrintMenu = new System.Windows.Forms.MenuItem();
			this.PrintPreviewMenu = new System.Windows.Forms.MenuItem();
			this.PageSetupMenu = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.UndoMenu = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.CutMenu = new System.Windows.Forms.MenuItem();
			this.CopyMenu = new System.Windows.Forms.MenuItem();
			this.PasteMenu = new System.Windows.Forms.MenuItem();
			this.DeleteMenu = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.GotoMenu = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.SelectAllMenu = new System.Windows.Forms.MenuItem();
			this.DeleteAllMenu = new System.Windows.Forms.MenuItem();
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(8, 112);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(152, 24);
			this.comboBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Available Fonts";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(184, 112);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(48, 24);
			this.numericUpDown1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(184, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "Size";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(240, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 6;
			this.button1.Text = "Color";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
			this.richTextBox1.Location = new System.Drawing.Point(8, 144);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(648, 248);
			this.richTextBox1.TabIndex = 7;
			this.richTextBox1.Text = "richTextBox1";
			this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.button2.Location = new System.Drawing.Point(408, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 32);
			this.button2.TabIndex = 8;
			this.button2.Text = "Apply";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.OpenFile,
																					  this.SaveFileAs,
																					  this.menuItem7,
																					  this.PrintMenu,
																					  this.PrintPreviewMenu,
																					  this.PageSetupMenu,
																					  this.menuItem11,
																					  this.ExitMenu});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.UndoMenu,
																					  this.menuItem14,
																					  this.CutMenu,
																					  this.CopyMenu,
																					  this.PasteMenu,
																					  this.DeleteMenu,
																					  this.menuItem19,
																					  this.GotoMenu,
																					  this.menuItem21,
																					  this.SelectAllMenu,
																					  this.DeleteAllMenu});
			this.menuItem2.Text = "&Edit";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "F&ormat";
			// 
			// OpenFile
			// 
			this.OpenFile.Index = 0;
			this.OpenFile.Text = "&Open File";
			this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
			// 
			// SaveFileAs
			// 
			this.SaveFileAs.Index = 1;
			this.SaveFileAs.Text = "&Save File As";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "-";
			// 
			// PrintMenu
			// 
			this.PrintMenu.Index = 3;
			this.PrintMenu.Text = "&Print";
			// 
			// PrintPreviewMenu
			// 
			this.PrintPreviewMenu.Index = 4;
			this.PrintPreviewMenu.Text = "Print Pre&view";
			// 
			// PageSetupMenu
			// 
			this.PageSetupMenu.Index = 5;
			this.PageSetupMenu.Text = "Page Setup";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 6;
			this.menuItem11.Text = "-";
			// 
			// ExitMenu
			// 
			this.ExitMenu.Index = 7;
			this.ExitMenu.Text = "E&xit";
			// 
			// UndoMenu
			// 
			this.UndoMenu.Index = 0;
			this.UndoMenu.Text = "&Undo";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 1;
			this.menuItem14.Text = "-";
			// 
			// CutMenu
			// 
			this.CutMenu.Index = 2;
			this.CutMenu.Text = "Cu&t";
			// 
			// CopyMenu
			// 
			this.CopyMenu.Index = 3;
			this.CopyMenu.Text = "&Copy";
			// 
			// PasteMenu
			// 
			this.PasteMenu.Index = 4;
			this.PasteMenu.Text = "&Paste";
			// 
			// DeleteMenu
			// 
			this.DeleteMenu.Index = 5;
			this.DeleteMenu.Text = "De&lete";
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 6;
			this.menuItem19.Text = "-";
			// 
			// GotoMenu
			// 
			this.GotoMenu.Index = 7;
			this.GotoMenu.Text = "&Go To";
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 8;
			this.menuItem21.Text = "-";
			// 
			// SelectAllMenu
			// 
			this.SelectAllMenu.Index = 9;
			this.SelectAllMenu.Text = "Select &All";
			// 
			// DeleteAllMenu
			// 
			this.DeleteAllMenu.Index = 10;
			this.DeleteAllMenu.Text = "&Delete All";
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.SynchronizingObject = this;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
			this.BackColor = System.Drawing.Color.Teal;
			this.ClientSize = new System.Drawing.Size(664, 397);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.richTextBox1,
																		  this.button1,
																		  this.label2,
																		  this.numericUpDown1,
																		  this.label1,
																		  this.comboBox1});
			this.Font = new System.Drawing.Font("Tahoma", 10F);
			this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "GDI+ Editor - A Simple Text Editor";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
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
			ColorDialog colorDlg = new ColorDialog();
			if(colorDlg.ShowDialog() == DialogResult.OK)
			{
				textColor = colorDlg.Color;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			textSize = (int)numericUpDown1.Value;
			string selFont = comboBox1.SelectedText;
			Font textFont = new Font(selFont, textSize);
			richTextBox1.ForeColor = textColor;
			richTextBox1.Font = textFont;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			numericUpDown1.Value = 10;

			// Create InstalledFontCollection object
			InstalledFontCollection 
				sysFontCollection = new InstalledFontCollection();

			// Get the array of FontFamily objects.
			FontFamily[] fontFamilies = sysFontCollection.Families;
			// Read all font familes and add to the combo box
			for(int i = 0; i < fontFamilies.Length; ++i)
			{
				comboBox1.Items.Add(fontFamilies[i].Name);
			}			
			comboBox1.Select(0, 20);
		}

		private void OpenFile_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();
			if (openDlg.ShowDialog() == DialogResult.OK) 
			{
				curFilename = openDlg.FileName;
				ReadTextFile();
			}
		}
		private void ReadTextFile() 
		{
			richTextBox1.TextChanged -= new System.EventHandler(this.richTextBox1_TextChanged);
			fileSystemWatcher1.EnableRaisingEvents = false;
			try 
			{
				// Open the file as a stream
				Stream fs = new FileStream(curFilename, FileMode.Open);
				FileInfo filInfo = new FileInfo(curFilename);
				// Get the file extension
				string extn = filInfo.Extension.ToUpper();
				// See if file is rich text format, Load it with 
				// RichText option. Otherwise PlainText
				if (extn.Equals(".RTF"))
					richTextBox1.LoadFile(fs, RichTextBoxStreamType.RichText);
				else
					richTextBox1.LoadFile(fs, RichTextBoxStreamType.PlainText);
				// Close stream
				fs.Close();
				fileSystemWatcher1.Path = filInfo.DirectoryName;
				fileSystemWatcher1.Filter = filInfo.Name;
		
			}
			catch(Exception exp)
			{
				MessageBox.Show(exp.Message.ToString());
			}
			finally 
			{
				richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
				fileSystemWatcher1.EnableRaisingEvents = true;
			}
		}

		
		
		private void richTextBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
