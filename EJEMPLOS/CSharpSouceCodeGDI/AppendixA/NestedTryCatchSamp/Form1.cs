using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace NestedTryCatchSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem NestedMenu;
		private System.Windows.Forms.MenuItem MultiCatchesMenu;
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
			this.NestedMenu = new System.Windows.Forms.MenuItem();
			this.MultiCatchesMenu = new System.Windows.Forms.MenuItem();
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
																					  this.NestedMenu,
																					  this.MultiCatchesMenu});
			this.menuItem1.Text = "Exceptions";
			// 
			// NestedMenu
			// 
			this.NestedMenu.Index = 0;
			this.NestedMenu.Text = "Nested";
			this.NestedMenu.Click += new System.EventHandler(this.NestedMenu_Click);
			// 
			// MultiCatchesMenu
			// 
			this.MultiCatchesMenu.Index = 1;
			this.MultiCatchesMenu.Text = "Multiple catches";
			this.MultiCatchesMenu.Click += new System.EventHandler(this.MultiCatchesMenu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 397);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void Form1_Paint(object sender, 
			System.Windows.Forms.PaintEventArgs e)
		{		
		}

		private void NestedMenu_Click(object sender,
			System.EventArgs e)
		{
			// Create Graphics object		
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			try
			{
				// Create an Image from a file
				Image curImage = Image.FromFile("roses.jpg");
				// Draw Image
				g.DrawImage(curImage, AutoScrollPosition.X,
					AutoScrollPosition.Y,
					curImage.Width, curImage.Height );					
				// Create second Image from a file
				Image smallImage = 
					Image.FromFile("smallRoses.gif");
				// Draw second image many times
				int x1, y1, x2, y2, w, h;
				x1 = x2 = AutoScrollPosition.X;
                y1 = AutoScrollPosition.Y;
				y2 = 300;
				w = 20;
				h = 20;
				// Make a look to draw second image
				// on top of the first image
				for(int i=0; i<=15; i++)
				{
					try
					{
						// Draw top left to bottom right
						g.DrawImage(smallImage, 
							new Rectangle(x1, y1, w, h),
							0, 0, smallImage.Width,
							smallImage.Height, 
							GraphicsUnit.Pixel );	
						// Draw top right to bottom left
						g.DrawImage(smallImage, 
							new Rectangle(x2, y2, w, h),
							0, 0, smallImage.Width,
							smallImage.Height, 
							GraphicsUnit.Pixel );	
						x1 += 20;
						y1 += 20;
						x2 += 20;
						y2 -= 20;
					}
					catch (OutOfMemoryException memExp)
					{
						MessageBox.Show(memExp.Message);
					}
				}
			}
			catch(Exception exp)
			{
				MessageBox.Show(exp.Message);
			}
			finally
			{
				// Dispose objects
				g.Dispose();
			}
		}

		private void MultiCatchesMenu_Click(object sender,
			System.EventArgs e)
		{
			// Create Graphics object		
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			try
			{
				// Create an Image from a file
				Image curImage = Image.FromFile("roses.jpg");
				// Draw Image
				g.DrawImage(curImage, AutoScrollPosition.X,
					AutoScrollPosition.Y,
					curImage.Width, curImage.Height );					
				// Create second Image from a file
				Image smallImage = 
					Image.FromFile("smallRoses.gif");
				// Draw second image many times
				int x1, y1, x2, y2, w, h;
				x1 = x2 = AutoScrollPosition.X;
				y1 = AutoScrollPosition.Y;
				y2 = 300;
				w = 20;
				h = 20;
				// Make a look to draw second image
				// on top of the first image
				for(int i=0; i<=15; i++)
				{
					// Draw top left to bottom right
					g.DrawImage(smallImage, 
						new Rectangle(x1, y1, w, h),
						0, 0, smallImage.Width,
						smallImage.Height, 
						GraphicsUnit.Pixel );	
					// Draw top right to bottom left
					g.DrawImage(smallImage, 
						new Rectangle(x2, y2, w, h),
						0, 0, smallImage.Width,
						smallImage.Height, 
						GraphicsUnit.Pixel );	
					x1 += 20;
					y1 += 20;
					x2 += 20;
					y2 -= 20;
				}
			}
			catch (OutOfMemoryException memExp)
			{
				MessageBox.Show(memExp.Message);
			}
			catch(Exception exp)
			{
				MessageBox.Show(exp.Message);
			}
			finally
			{
				// Dispose objects
				g.Dispose();
			}	
		}
	}
}




