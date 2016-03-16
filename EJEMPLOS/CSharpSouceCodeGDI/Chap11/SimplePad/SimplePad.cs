//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>
///    Copyright (c) Microsoft Corporation. All Rights Reserved.
///
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.SimplePad 
{

	using System;
	using System.Drawing;
	using System.Drawing.Printing;
	using System.Collections;
	using System.IO;
	using System.ComponentModel;
	using System.Windows.Forms;

	public class SimplePad : System.Windows.Forms.Form 
	{
		/// <summary>
		///    Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
		protected internal System.Windows.Forms.MenuItem menuItem22;
		protected internal System.Windows.Forms.MenuItem selectAllMenu;
		protected internal System.Windows.Forms.MenuItem menuItem20;
		protected internal System.Windows.Forms.MenuItem gotoMenu;
		protected internal System.Windows.Forms.MenuItem menuItem18;
		protected internal System.Windows.Forms.MenuItem menuItem17;
		protected internal System.Windows.Forms.MenuItem menuItem16;
		protected internal System.Windows.Forms.MenuItem menuItem15;
		protected internal System.Windows.Forms.MenuItem DeleteMenu;
		protected internal System.Windows.Forms.MenuItem pasteMenu;
		protected internal System.Windows.Forms.MenuItem copyMenu;
		protected internal System.Windows.Forms.MenuItem CutMenu;
		protected internal System.Windows.Forms.MenuItem menuItem8;
		protected internal System.Windows.Forms.MenuItem UndoMenu;
		protected internal System.Windows.Forms.MenuItem optionsMenu;
		protected internal System.Windows.Forms.MenuItem menuItem7;
		protected internal System.Windows.Forms.MenuItem fontMenu;
		protected internal System.Windows.Forms.MenuItem wordWrapMenu;
		protected internal System.Windows.Forms.PrintDialog printDialog1;
		protected internal System.Windows.Forms.FontDialog fontDialog1;
		protected internal System.Windows.Forms.SaveFileDialog saveFileDialog1;
		protected internal System.Windows.Forms.OpenFileDialog openFileDialog1;
		protected internal System.Windows.Forms.StatusBarPanel linePanel;
		protected internal System.Windows.Forms.StatusBarPanel statusPanel;
		protected internal System.Windows.Forms.StatusBar statusBar1;
		protected internal System.Windows.Forms.RichTextBox textArea;
		protected internal System.Windows.Forms.MenuItem exitMenu;
		protected internal System.Windows.Forms.MenuItem menuItem12;
		protected internal System.Windows.Forms.MenuItem printMenu;
		protected internal System.Windows.Forms.MenuItem pageSetupMenu;
		protected internal System.Windows.Forms.MenuItem menuItem9;
		protected internal System.Windows.Forms.MenuItem saveAsMenu;
		protected internal System.Windows.Forms.MenuItem saveMenu;
		protected internal System.Windows.Forms.MenuItem openMenu;
		protected internal System.Windows.Forms.MenuItem newMenu;
		protected internal System.Windows.Forms.MenuItem menuItem4;
		protected internal System.Windows.Forms.MenuItem menuItem3;
		protected internal System.Windows.Forms.MenuItem menuItem2;
		protected internal System.Windows.Forms.MenuItem menuItem1;
		protected internal System.Windows.Forms.MainMenu mainMenu;
		protected internal System.Windows.Forms.MenuItem printPreviewMenu;
		protected internal System.IO.FileSystemWatcher dirWatcher;

		private static readonly string noFilename = "Untitled";
		private static readonly string notDirtyCaptionFormat = "{0} - SimplePad+";
		private static readonly string dirtyCaptionFormat = "{0}* - SimplePad+";
		private string editingFileName = null;
		private bool dirty = false;
		private bool fileOnDiskModified = false;
		private PageSettings storedPageSettings = null ;

		public SimplePad() 
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			UpdateFormText();
		}

		/// <summary>
		///    Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing) 
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///    Required method for Designer support - do not modify
		///    the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() 
		{
			this.wordWrapMenu = new System.Windows.Forms.MenuItem();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.newMenu = new System.Windows.Forms.MenuItem();
			this.openMenu = new System.Windows.Forms.MenuItem();
			this.saveMenu = new System.Windows.Forms.MenuItem();
			this.saveAsMenu = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.printMenu = new System.Windows.Forms.MenuItem();
			this.printPreviewMenu = new System.Windows.Forms.MenuItem();
			this.pageSetupMenu = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.exitMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.UndoMenu = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.CutMenu = new System.Windows.Forms.MenuItem();
			this.copyMenu = new System.Windows.Forms.MenuItem();
			this.pasteMenu = new System.Windows.Forms.MenuItem();
			this.DeleteMenu = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.gotoMenu = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.selectAllMenu = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.fontMenu = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.optionsMenu = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusPanel = new System.Windows.Forms.StatusBarPanel();
			this.linePanel = new System.Windows.Forms.StatusBarPanel();
			this.textArea = new System.Windows.Forms.RichTextBox();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.dirWatcher = new System.IO.FileSystemWatcher();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.statusPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.linePanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dirWatcher)).BeginInit();
			this.SuspendLayout();
			// 
			// wordWrapMenu
			// 
			this.wordWrapMenu.Index = 0;
			this.wordWrapMenu.Text = "&Word Wrap";
			this.wordWrapMenu.Click += new System.EventHandler(this.WordWrapMenu_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem1,
																					 this.menuItem2,
																					 this.menuItem3,
																					 this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.newMenu,
																					  this.openMenu,
																					  this.saveMenu,
																					  this.saveAsMenu,
																					  this.menuItem9,
																					  this.printMenu,
																					  this.printPreviewMenu,
																					  this.pageSetupMenu,
																					  this.menuItem12,
																					  this.exitMenu});
			this.menuItem1.Text = "&File";
			// 
			// newMenu
			// 
			this.newMenu.Index = 0;
			this.newMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.newMenu.Text = "&New";
			this.newMenu.Click += new System.EventHandler(this.NewMenu_Click);
			// 
			// openMenu
			// 
			this.openMenu.Index = 1;
			this.openMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.openMenu.Text = "&Open...";
			this.openMenu.Click += new System.EventHandler(this.OpenMenu_Click);
			// 
			// saveMenu
			// 
			this.saveMenu.Index = 2;
			this.saveMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.saveMenu.Text = "&Save";
			this.saveMenu.Click += new System.EventHandler(this.SaveMenu_Click);
			// 
			// saveAsMenu
			// 
			this.saveAsMenu.Index = 3;
			this.saveAsMenu.Text = "Save &As...";
			this.saveAsMenu.Click += new System.EventHandler(this.SaveAsMenu_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 4;
			this.menuItem9.Text = "-";
			// 
			// printMenu
			// 
			this.printMenu.Index = 5;
			this.printMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.printMenu.Text = "&Print...";
			this.printMenu.Click += new System.EventHandler(this.PrintMenu_Click);
			// 
			// printPreviewMenu
			// 
			this.printPreviewMenu.Index = 6;
			this.printPreviewMenu.Text = "Print Pre&view...";
			this.printPreviewMenu.Click += new System.EventHandler(this.PrintPreviewMenu_Click);
			// 
			// pageSetupMenu
			// 
			this.pageSetupMenu.Index = 7;
			this.pageSetupMenu.Text = "Page Set&up...";
			this.pageSetupMenu.Click += new System.EventHandler(this.PageSetupMenu_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 8;
			this.menuItem12.Text = "-";
			// 
			// exitMenu
			// 
			this.exitMenu.Index = 9;
			this.exitMenu.Text = "E&xit";
			this.exitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.UndoMenu,
																					  this.menuItem8,
																					  this.CutMenu,
																					  this.copyMenu,
																					  this.pasteMenu,
																					  this.DeleteMenu,
																					  this.menuItem15,
																					  this.gotoMenu,
																					  this.menuItem20,
																					  this.selectAllMenu});
			this.menuItem2.Text = "&Edit";
			// 
			// UndoMenu
			// 
			this.UndoMenu.Index = 0;
			this.UndoMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
			this.UndoMenu.Text = "&Undo";
			this.UndoMenu.Click += new System.EventHandler(this.UndoMenu_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.Text = "-";
			// 
			// CutMenu
			// 
			this.CutMenu.Index = 2;
			this.CutMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.CutMenu.Text = "Cu&t";
			this.CutMenu.Click += new System.EventHandler(this.CutMenu_Click);
			// 
			// copyMenu
			// 
			this.copyMenu.Index = 3;
			this.copyMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.copyMenu.Text = "&Copy";
			this.copyMenu.Click += new System.EventHandler(this.CopyMenu_Click);
			// 
			// pasteMenu
			// 
			this.pasteMenu.Index = 4;
			this.pasteMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.pasteMenu.Text = "&Paste";
			this.pasteMenu.Click += new System.EventHandler(this.PasteMenu_Click);
			// 
			// DeleteMenu
			// 
			this.DeleteMenu.Index = 5;
			this.DeleteMenu.Text = "De&lete";
			this.DeleteMenu.Click += new System.EventHandler(this.DeleteMenu_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 6;
			this.menuItem15.Text = "-";
			// 
			// gotoMenu
			// 
			this.gotoMenu.Index = 7;
			this.gotoMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
			this.gotoMenu.Text = "&Go To...";
			this.gotoMenu.Click += new System.EventHandler(this.GotoMenu_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 8;
			this.menuItem20.Text = "-";
			// 
			// selectAllMenu
			// 
			this.selectAllMenu.Index = 9;
			this.selectAllMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.selectAllMenu.Text = "Select &All";
			this.selectAllMenu.Click += new System.EventHandler(this.SelectAllMenu_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.wordWrapMenu,
																					  this.fontMenu,
																					  this.menuItem7,
																					  this.optionsMenu});
			this.menuItem3.Text = "F&ormat";
			// 
			// fontMenu
			// 
			this.fontMenu.Index = 1;
			this.fontMenu.Text = "&Font...";
			this.fontMenu.Click += new System.EventHandler(this.FontMenu_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "-";
			// 
			// optionsMenu
			// 
			this.optionsMenu.Index = 3;
			this.optionsMenu.Text = "&Options...";
			this.optionsMenu.Click += new System.EventHandler(this.OptionsMenu_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "&Help";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 338);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusPanel,
																						  this.linePanel});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(467, 18);
			this.statusBar1.TabIndex = 1;
			this.statusBar1.Text = "statusBar1";
			// 
			// statusPanel
			// 
			this.statusPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusPanel.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.statusPanel.Text = "Ready";
			this.statusPanel.Width = 351;
			// 
			// textArea
			// 
			this.textArea.AcceptsTab = true;
			this.textArea.AutoSize = true;
			this.textArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textArea.Name = "textArea";
			this.textArea.Size = new System.Drawing.Size(467, 356);
			this.textArea.TabIndex = 0;
			this.textArea.Text = "";
			this.textArea.WordWrap = false;
			this.textArea.TextChanged += new System.EventHandler(this.TextArea_TextChanged);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = -1;
			this.menuItem18.Text = "";
			// 
			// menuItem17
			// 
			this.menuItem17.Index = -1;
			this.menuItem17.Text = "";
			// 
			// menuItem16
			// 
			this.menuItem16.Index = -1;
			this.menuItem16.Text = "";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*";
			this.saveFileDialog1.Title = "Save As";
			// 
			// menuItem22
			// 
			this.menuItem22.Index = -1;
			this.menuItem22.Text = "";
			// 
			// dirWatcher
			// 
			this.dirWatcher.EnableRaisingEvents = true;
			this.dirWatcher.SynchronizingObject = this;
			this.dirWatcher.Changed += new System.IO.FileSystemEventHandler(this.DirWatcher_Changed);
			// 
			// fontDialog1
			// 
			this.fontDialog1.ShowColor = true;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "rtf";
			this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*";
			this.openFileDialog1.Title = "Open";
			// 
			// SimplePad
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(467, 356);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar1,
																		  this.textArea});
			this.Menu = this.mainMenu;
			this.Name = "SimplePad";
			this.Text = "SimplePad+";
			((System.ComponentModel.ISupportInitialize)(this.statusPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.linePanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dirWatcher)).EndInit();
			this.ResumeLayout(false);

		}

		private void PromptForReload() 
		{
			fileOnDiskModified = false;

			System.Windows.Forms.DialogResult dr = MessageBox.Show(this,
				"The current file has been changed, do you want to reload it?",
				"File Change Notification",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dr == System.Windows.Forms.DialogResult.Yes) 
			{

				ReadEditingFile();
			}
		}

		protected override void OnActivated(EventArgs e) 
		{
			base.OnActivated(e);

			if (fileOnDiskModified) 
			{
				PromptForReload();
			}
		}

		protected override void OnClosing(CancelEventArgs e) 
		{
			base.OnClosing(e);

			if (dirty) 
			{
				System.Windows.Forms.DialogResult dr = MessageBox.Show(this,
					"Do you want to save the current changes?",
					"Save Changes?",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				switch (dr) 
				{
					case System.Windows.Forms.DialogResult.Yes:
						Save();
						break;
					case System.Windows.Forms.DialogResult.No:
						break;
					case System.Windows.Forms.DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}
		}

		private void DirWatcher_Changed(object sender, FileSystemEventArgs e) 
		{
			if (this.ContainsFocus) 
			{
				PromptForReload();
			}
			else 
			{
				fileOnDiskModified = true;
			}
		}

		private void TextArea_TextChanged(object sender, EventArgs e) 
		{
			if (!dirty) 
			{
				dirty = true;
				UpdateFormText();
			}
		}

		private void SaveAs() 
		{
			System.Windows.Forms.DialogResult dr = saveFileDialog1.ShowDialog();
			if (dr == System.Windows.Forms.DialogResult.OK) 
			{
				editingFileName = saveFileDialog1.FileName;
				FileInfo efInfo = new FileInfo(editingFileName);
				dirWatcher.EnableRaisingEvents = false;
				dirWatcher.Path = efInfo.DirectoryName;
				dirWatcher.Filter = efInfo.Name;
				Save();
				UpdateFormText();
			}
		}

		private void Save() 
		{

			if (editingFileName == null || editingFileName.Length < 1) 
			{
				SaveAs();
				return;
			}

			dirWatcher.EnableRaisingEvents = false;
			FileStream fs = null;
			try 
			{
				if (File.Exists(editingFileName)) 
				{
					fs = new FileStream(editingFileName, FileMode.Open);
				}
				else 
				{
					fs = new FileStream(editingFileName, FileMode.Create);
				}

				string fext = (new FileInfo(editingFileName)).Extension.ToUpper();

				Console.WriteLine(editingFileName);

				if (fext.Equals(".RTF"))
					textArea.SaveFile(fs, RichTextBoxStreamType.RichText);
				else
					textArea.SaveFile(fs, RichTextBoxStreamType.PlainText);

			}
			finally 
			{
				if (fs != null) 
				{
					fs.Flush();
					fs.Close();
					dirty = false;
				}
				dirWatcher.EnableRaisingEvents = true;
			}
		}

		private void ExitMenu_Click(object sender, EventArgs e) 
		{
			this.Close();
		}



		private void SaveMenu_Click(object sender, EventArgs e) 
		{
			Save();
		}

		private void Goto(int line) 
		{
			string text = textArea.Text;
			int cur = 0;
			for (int i=1; i<line; i++) 
			{
				int next = text.IndexOf("\n", cur + 1);
				if (next == -1) 
				{
					break;
				}
				cur = next;
			}
			if (line > 1) 
			{
				textArea.Select(cur - (line - 2), 0);
			}
			else 
			{
				textArea.Select(cur, 0);
			}
		}

		private int GetCurrentLine() 
		{
			char[] text = textArea.Text.ToCharArray();
			int cur = textArea.SelectionStart;
			int line = 1;
			for (int i=0; i<cur; i++) 
			{
				if (text[i] == '\n') 
				{
					cur++;
					line++;
				}
			}
			return line;
		}

		private void GotoMenu_Click(object sender, EventArgs e) 
		{
			System.Windows.Forms.DialogResult dr;
			GotoForm f = new GotoForm();
			f.Line = GetCurrentLine();
			dr = f.ShowDialog(this);
			if (dr == System.Windows.Forms.DialogResult.OK) 
			{
				Goto(f.Line);
			}
		}

		private void SaveAsMenu_Click(object sender, EventArgs e) 
		{
			SaveAs();
		}

		private void WordWrapMenu_Click(object sender, EventArgs e) 
		{
			wordWrapMenu.Checked = !wordWrapMenu.Checked;
			textArea.WordWrap = wordWrapMenu.Checked;
		}

		private void NewMenu_Click(object sender, EventArgs e) 
		{
			MessageBox.Show("Not implemented");
		}

		private void OpenMenu_Click(object sender, EventArgs e) 
		{
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
			{
				editingFileName = openFileDialog1.FileName;
				ReadEditingFile();
			}
		}

		private void FontMenu_Click(object sender, EventArgs e) 
		{
			if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
			{
				textArea.SelectionFont = fontDialog1.Font;
				textArea.SelectionColor = fontDialog1.Color;
			}
		}

		private void OptionsMenu_Click(object sender, EventArgs e) 
		{
			OptionsForm f = new OptionsForm(new SimplePadOptions(this));
			f.ShowDialog(this);
		}

		private void CutMenu_Click(object sender, EventArgs e) 
		{
			if (textArea.SelectedText.Equals("")) return;
			Clipboard.SetDataObject(textArea.SelectedRtf,true);
			textArea.SelectedRtf = "" ;
		}

		private void UndoMenu_Click(object sender, EventArgs e) 
		{
			textArea.Undo();
		}

		private void CopyMenu_Click(object sender, EventArgs e) 
		{
			if (textArea.SelectedText.Equals("")) return;
			Clipboard.SetDataObject(textArea.SelectedRtf,true);
		}

		private void SelectAllMenu_Click(object sender, EventArgs e) 
		{
			textArea.SelectAll();
		}

		private void DeleteMenu_Click(object sender, EventArgs e) 
		{
			textArea.SelectedRtf = "" ;
		}

		private void PasteMenu_Click(object sender, EventArgs e) 
		{
			try 
			{
				DataObject data = (DataObject)Clipboard.GetDataObject();
				if (data.GetDataPresent(DataFormats.Rtf)) 
				{
					string text = (string)data.GetData(DataFormats.Rtf);
					if (!text.Equals("")) textArea.SelectedRtf = text;
				}
				else if (data.GetDataPresent(DataFormats.Text)) 
				{
					string text = (string)data.GetData(DataFormats.Text);
					if (!text.Equals("")) textArea.SelectedText = text;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}
		}


		private void PrintMenu_Click(object sender, EventArgs e) 
		{
			StringReader streamToPrint = new StringReader (textArea.Text);

			//Assumes the default printer
			TextPrintDocument pd = new TextPrintDocument(streamToPrint,textArea.Font);

			if (storedPageSettings != null) 
			{
				pd.DefaultPageSettings = storedPageSettings ;
			}

			PrintDialog dlg = new PrintDialog() ;
			dlg.Document = pd;
			DialogResult result = dlg.ShowDialog();

			if (result == DialogResult.OK) 
			{
				pd.Print();
			}
		}

		private void PageSetupMenu_Click(object sender, EventArgs e) 
		{
			try 
			{
				PageSetupDialog psDlg = new PageSetupDialog() ;

				if (storedPageSettings == null) 
				{
					storedPageSettings =  new PageSettings();
				}

				psDlg.PageSettings = storedPageSettings ;
				psDlg.ShowDialog();

			} 
			catch(Exception ex) 
			{
				MessageBox.Show("An error occurred - " + ex.Message);
			}
		}

		private void PrintPreviewMenu_Click(object sender, EventArgs e) 
		{

			try 
			{
				StringReader streamToPrint = new StringReader (textArea.Text);

				//Assumes the default printer
				TextPrintDocument pd = new TextPrintDocument(streamToPrint,textArea.Font);

				if (storedPageSettings != null) 
				{
					pd.DefaultPageSettings = storedPageSettings ;
				}

				PrintPreviewDialog dlg = new PrintPreviewDialog() ;
				dlg.Document = pd;
				dlg.ShowDialog();
			} 
			catch(Exception ex) 
			{
				MessageBox.Show("An error occurred attempting to preview the file to print - " + ex.Message);
			}

		}


		private void ReadEditingFile() 
		{
			textArea.TextChanged -= new System.EventHandler(this.TextArea_TextChanged);
			dirWatcher.EnableRaisingEvents = false;
			try 
			{

				Stream s = new FileStream(editingFileName, FileMode.Open);
				FileInfo efInfo = new FileInfo(editingFileName);

				string fext = efInfo.Extension.ToUpper();

				if (fext.Equals(".RTF"))
					textArea.LoadFile(s, RichTextBoxStreamType.RichText);
				else
					textArea.LoadFile(s, RichTextBoxStreamType.PlainText);

				s.Close();

				dirWatcher.Path = efInfo.DirectoryName;
				dirWatcher.Filter = efInfo.Name;

				dirty = false;
				UpdateFormText();
			}
			finally 
			{
				textArea.TextChanged += new System.EventHandler(this.TextArea_TextChanged);
				dirWatcher.EnableRaisingEvents = true;
			}
		}

		private void UpdateFormText() 
		{
			string file = noFilename;
			if (editingFileName != null && editingFileName.Length > 1) 
			{
				file = editingFileName;
			}

			if (dirty) 
			{
				this.Text = string.Format(dirtyCaptionFormat, file);
			}
			else 
			{
				this.Text = string.Format(notDirtyCaptionFormat, file);
			}
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args) 
		{
			Application.Run(new SimplePad());
		}

		internal class SimplePadOptions 
		{
			private SimplePad owner;

			public SimplePadOptions(SimplePad owner) 
			{
				this.owner = owner;
			}

			[
			Description("Color used for the background of the text"),
			Category("Text Display")
			]
			public Color BackColor 
			{
				get 
				{
					return owner.textArea.BackColor;
				}
				set 
				{
					owner.textArea.BackColor = value;
				}
			}

			[
			Description("Color used for the forecolor of the text"),
			Category("Text Display")
			]
			public Color ForeColor 
			{
				get 
				{
					return owner.textArea.ForeColor;
				}
				set 
				{
					owner.textArea.ForeColor = value;
				}
			}

			[
			Description("Adjusts the font used to display text in SimplePad+"),
			Category("Text Display")
			]
			public Font DefaultFont 
			{
				get 
				{
					return owner.textArea.Font;
				}
				set 
				{
					owner.textArea.Font = value;
				}
			}

			[
			Description("Determines if text will word wrap"),
			Category("Text Display"),
			DefaultValue(false)
			]
			public bool WordWrap 
			{
				get 
				{
					return owner.wordWrapMenu.Checked;
				}
				set 
				{
					owner.wordWrapMenu.Checked = owner.textArea.WordWrap = value;
				}
			}

			[
			Description("Modifies the opacity of SimplePad+. Windows 2000 only."),
			Category("Application"),
			TypeConverterAttribute(typeof(OpacityConverter)),
			DefaultValue(1.0)
			]
			public double Opacity 
			{
				get 
				{
					return owner.Opacity;
				}
				set 
				{
					owner.Opacity = value;
				}
			}
		}
	}
}

