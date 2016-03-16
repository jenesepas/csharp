using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;

namespace PrintControllerSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem StandardPrintControllerMenu;
		private System.Windows.Forms.StatusBar statusBar1;
		
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
			this.StandardPrintControllerMenu = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
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
																					  this.StandardPrintControllerMenu});
			this.menuItem1.Text = "PrintController";
			// 
			// StandardPrintControllerMenu
			// 
			this.StandardPrintControllerMenu.Index = 0;
			this.StandardPrintControllerMenu.Text = "Standard Print Controller";
			this.StandardPrintControllerMenu.Click += new System.EventHandler(this.StandardPrintControllerMenu_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 251);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(292, 22);
			this.statusBar1.TabIndex = 0;
			this.statusBar1.Text = "statusBar1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void StandardPrintControllerMenu_Click(
			object sender, System.EventArgs e)
		{
			PrintDocument printDoc = new PrintDocument();
			printDoc.DocumentName = 
				"PrintController Document";
			printDoc.PrintController = 
				new MyPrintController(statusBar1);
			printDoc.PrintPage += 
				new PrintPageEventHandler(PringPageHandler);
			printDoc.Print();			
		}

		void PringPageHandler(object obj,
			PrintPageEventArgs ppeArgs)
		{
			Graphics g  = ppeArgs.Graphics;
			SolidBrush brush =
				new SolidBrush(Color.Red);
			Font verdana20Font = 
				new Font("Verdana", 20);
			g.DrawString("Pring Controller Test",
				verdana20Font,
				brush, 20, 20);
		}
	}


// Print Controller Class
class MyPrintController: StandardPrintController
{
    private StatusBar statusBar;
    private string str = string.Empty;

    public MyPrintController(StatusBar sBar): base()
    {
        statusBar = sBar;
    }
    public override void OnStartPrint
        (PrintDocument printDoc, 
        PrintEventArgs peArgs)
    {
        statusBar.Text = "OnStartPrint Called";
		MessageBox.Show("Wait");
        base.OnStartPrint(printDoc, peArgs);
    }
    public override Graphics OnStartPage
        (PrintDocument printDoc, 
        PrintPageEventArgs ppea)
    {
        statusBar.Text = "OnStartPage Called";
        return base.OnStartPage(printDoc, ppea);
    }
    public override void OnEndPage
        (PrintDocument printDoc, 
        PrintPageEventArgs ppeArgs)
    {
        statusBar.Text = "OnEndPage Called";
        base.OnEndPage(printDoc, ppeArgs);
    }
    public override void OnEndPrint
        (PrintDocument printDoc, 
        PrintEventArgs peArgs)
    {
        statusBar.Text = "OnEndPrint Called";
        statusBar.Text = str;
        base.OnEndPrint(printDoc, peArgs);
    }
}
}

