using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;

namespace PrintingImages
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem PrintImage;
		private System.Windows.Forms.MenuItem PrintGraphicsItems;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem ViewImage;
		private System.Windows.Forms.MenuItem DrawItems;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		private Image curImage = null;
		private string curFileName = null;
		


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
			this.PrintImage = new System.Windows.Forms.MenuItem();
			this.PrintGraphicsItems = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.ViewImage = new System.Windows.Forms.MenuItem();
			this.DrawItems = new System.Windows.Forms.MenuItem();
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
																					  this.DrawItems,
																					  this.ViewImage,
																					  this.menuItem2,
																					  this.PrintImage,
																					  this.PrintGraphicsItems});
			this.menuItem1.Text = "Printing ";
			// 
			// PrintImage
			// 
			this.PrintImage.Index = 3;
			this.PrintImage.Text = "Print Image";
			this.PrintImage.Click += new System.EventHandler(this.PrintImage_Click);
			// 
			// PrintGraphicsItems
			// 
			this.PrintGraphicsItems.Index = 4;
			this.PrintGraphicsItems.Text = "Print Graphics Items";
			this.PrintGraphicsItems.Click += new System.EventHandler(this.PrintGraphicsItems_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "-";
			// 
			// ViewImage
			// 
			this.ViewImage.Index = 1;
			this.ViewImage.Text = "View Image";
			this.ViewImage.Click += new System.EventHandler(this.ViewImage_Click);
			// 
			// DrawItems
			// 
			this.DrawItems.Index = 0;
			this.DrawItems.Text = "Draw Items";
			this.DrawItems.Click += new System.EventHandler(this.DrawItems_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 349);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";

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

		private void PrintImage_Click(object sender, 
			System.EventArgs e)
		{
			PrintDocument pd = new PrintDocument();
			pd.PrintPage += new PrintPageEventHandler
				(this.PrintImageHandler);
			pd.Print();
		}
		private void PrintImageHandler(object sender, 
			PrintPageEventArgs ppeArgs) 
		{
			Graphics g = ppeArgs.Graphics;
			if(curImage != null)
			{
				// Draw Image using the DrawImage method 
				g.DrawImage(curImage, 0, 0,
					curImage.Width, curImage.Height );				
			}			
		}


		private void PrintGraphicsItems_Click(object sender, 
			System.EventArgs e)
		{
			PrintDocument pd = new PrintDocument();
			pd.PrintPage += new PrintPageEventHandler
				(this.PrintGraphicsItemsHandler);
			pd.Print();		
		}
		private void PrintGraphicsItemsHandler(object sender, 
			PrintPageEventArgs ppeArgs) 
		{
			Graphics g = ppeArgs.Graphics;
			// Draw graphics items
			g.DrawLine(Pens.Blue, 10, 10, 10, 100);
			g.DrawLine(Pens.Blue, 10, 10, 100, 10);
			g.DrawRectangle(Pens.Yellow, 20, 20, 200, 200);
			g.FillEllipse(Brushes.Gray, 40, 40, 100, 100);
		}

		private void DrawItems_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Draw graphics items
			g.DrawLine(Pens.Blue, 10, 10, 10, 100);
			g.DrawLine(Pens.Blue, 10, 10, 100, 10);
			g.DrawRectangle(Pens.Yellow, 20, 20, 200, 200);
			g.FillEllipse(Brushes.Gray, 40, 40, 100, 100);
			// Dispose
			g.Dispose();
		}

		private void ViewImage_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = "All Image files|*.bmp;*.gif;*.jpg;*.ico;"+
				"*.emf,*.wmf|Bitmap Files(*.bmp;*.gif;*.jpg;"+
				"*.ico)|*.bmp;*.gif;*.jpg;*.ico|"+
				"Meta Files(*.emf;*.wmf)|*.emf;*.wmf";
			string filter = openDlg.Filter;
			openDlg.InitialDirectory = Environment.CurrentDirectory;
			openDlg.Title = "Open Image File";
			openDlg.ShowHelp = true;
			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				curFileName = openDlg.FileName; 	
				curImage = Image.FromFile(curFileName);
			}
			if(curImage != null)
			{
				// Draw Image using the DrawImage method 
				g.DrawImage(curImage, AutoScrollPosition.X,
					AutoScrollPosition.Y,
					curImage.Width, curImage.Height );				
			}
			// Dispose
			g.Dispose();		
		}
	}
}
