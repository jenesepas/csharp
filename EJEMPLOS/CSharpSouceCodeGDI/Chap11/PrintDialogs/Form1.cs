using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace PrintDialogs
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem PrintPreview;
		private System.Windows.Forms.MenuItem PrintSetup;
		private System.Windows.Forms.MenuItem PrintDialog;
	private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem OpenFile;


		//Variables
		private Image curImage = null;
		private string curFileName = null;
		private PrintPreviewDialog previewDlg = null;
		private PageSetupDialog setupDlg = null;
		private PrintDocument printDoc = null;
		private PrintDialog printDlg = null;
		private System.Windows.Forms.PrintDialog printDialog1;




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
			this.OpenFile = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.PrintPreview = new System.Windows.Forms.MenuItem();
			this.PrintSetup = new System.Windows.Forms.MenuItem();
			this.PrintDialog = new System.Windows.Forms.MenuItem();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
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
																					  this.OpenFile,
																					  this.menuItem2,
																					  this.PrintPreview,
																					  this.PrintSetup,
																					  this.PrintDialog});
			this.menuItem1.Text = "Print Dialog";
			// 
			// OpenFile
			// 
			this.OpenFile.Index = 0;
			this.OpenFile.Text = "Open File";
			this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// PrintPreview
			// 
			this.PrintPreview.Index = 2;
			this.PrintPreview.Text = "Print Preview Dialog";
			this.PrintPreview.Click += new System.EventHandler(this.PrintPreview_Click);
			// 
			// PrintSetup
			// 
			this.PrintSetup.Index = 3;
			this.PrintSetup.Text = "Page Setup Dialog";
			this.PrintSetup.Click += new System.EventHandler(this.PageSetupDialog_Click);
			// 
			// PrintDialog
			// 
			this.PrintDialog.Index = 4;
			this.PrintDialog.Text = "Print Dialog";
			this.PrintDialog.Click += new System.EventHandler(this.PrintDialog_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 353);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

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

		private void OpenFile_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
	
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = 
				"All Image files|*.bmp;*.gif;*.jpg;*.ico;"+
				"*.emf,*.wmf|Bitmap Files(*.bmp;*.gif;*.jpg;"+
				"*.ico)|*.bmp;*.gif;*.jpg;*.ico|"+
				"Meta Files(*.emf;*.wmf)|*.emf;*.wmf";
			string filter = openDlg.Filter;
			openDlg.InitialDirectory =
				Environment.CurrentDirectory;
			openDlg.Title = "Open Image File";
			openDlg.ShowHelp = true;
			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				curFileName = openDlg.FileName; 	
				curImage = Image.FromFile(curFileName);				
			}
			Invalidate();
		}

		private void Form1_Load(object sender, 
			System.EventArgs e)
		{
			// Create print preview dialog
			// and other dialogs 
			previewDlg = new PrintPreviewDialog();
			setupDlg = new PageSetupDialog();
			printDlg = new PrintDialog();
			printDoc = new PrintDocument();
			// Set document name
			printDoc.DocumentName = "Print Document";
			// PrintPreviewDialog Settings
			previewDlg.Document = printDoc;
			// PageSetupDialog Settings
			setupDlg.Document = printDoc;
			// PrintDialog settings
			printDlg.Document = printDoc;
			printDlg.AllowSelection = true;
			printDlg.AllowSomePages = true; 
			// Create a PringPage Event Handler
			printDoc.PrintPage += 
				new PrintPageEventHandler(this.pd_Print);
		}

		private void Form1_Paint(object sender, 
			System.Windows.Forms.PaintEventArgs e)
		{
			  DrawGraphicsItems(e.Graphics);
		}

		private void DrawGraphicsItems(Graphics gObj)
		{
			// Setting text and images quality
			gObj.SmoothingMode = 
				SmoothingMode.AntiAlias;
			gObj.TextRenderingHint = 
				TextRenderingHint.AntiAlias;
			if(curImage != null)
			{
				// Draw Image using the DrawImage method 
				gObj.DrawImage(curImage, 
					AutoScrollPosition.X,
					AutoScrollPosition.Y,
					curImage.Width, curImage.Height );				
			}
			// Draw a string     

			gObj.DrawString("Printing Dialogs Test", 
				new Font("Verdana", 14),
				new SolidBrush(Color.Blue), 0, 0); 
		}
		private void pd_Print(object sender, 
			PrintPageEventArgs ppeArgs)
		{
			DrawGraphicsItems(ppeArgs.Graphics);
		}


		private void PrintDialog_Click(object sender, 
			System.EventArgs e)
		{
			if (printDlg.ShowDialog() == DialogResult.OK)
			 printDoc.Print();
			      
		}
		private void PageSetupDialog_Click(object sender, 
			System.EventArgs e)
		{
			if (setupDlg.ShowDialog() == DialogResult.OK)
			{
				printDoc.DefaultPageSettings = 
					setupDlg.PageSettings;
				printDoc.PrinterSettings = 
					setupDlg.PrinterSettings;
			}
		}
		private void PrintPreview_Click(object sender, 
			System.EventArgs e)
		{
			previewDlg.UseAntiAlias = true;
			previewDlg.WindowState = FormWindowState.Normal;
			previewDlg.ShowDialog();		
		}
	}
}




