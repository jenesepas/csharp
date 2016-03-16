using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace BrushesSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;

		private Brush txtrBrush ;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.Timer timer1;
		private short brushType = 0;
		private bool fireActive = false;
		private System.Windows.Forms.Button button1;
		private LinearGradientBrush fireBrush = null;

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
			this.components = new System.ComponentModel.Container();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5,
																					  this.menuItem6,
																					  this.menuItem7,
																					  this.menuItem8});
			this.menuItem1.Text = "Brushes";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "Solid Brush";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "Hatch Brush";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.Text = "Texture Brush";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 3;
			this.menuItem6.Text = "Gradiant Brush 1";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 4;
			this.menuItem7.Text = "Gradient Brush 2";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 5;
			this.menuItem8.Text = "Fire Show";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Pens";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(256, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "ON";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 305);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
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

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			brushType = 1;	
			this.Invalidate(this.ClientRectangle);
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			brushType = 2;
			this.Invalidate(this.ClientRectangle);
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Image img = new Bitmap(@"C:\BookCover1.jpg");	
			txtrBrush = new TextureBrush(img);
			brushType = 3;		
			this.Invalidate(this.ClientRectangle);
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			brushType = 4;		
			this.Invalidate(this.ClientRectangle);
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			if(brushType == 0)
				return;
			
			if(brushType == 1)
			{
				SolidBrush redBrush = new SolidBrush(Color.Red);			
				SolidBrush greenBrush = new SolidBrush(Color.Green);		
				SolidBrush blueBrush = new SolidBrush(Color.Blue);	

				g.FillEllipse(redBrush, 20, 40, 100, 120);			
				Rectangle rect = new Rectangle(150, 80, 200, 140);            
				g.FillPie(greenBrush, 40, 20, 200, 40, 0.0f, 60.0f );			
				g.FillRectangle(blueBrush, rect);	
			}

			if(brushType == 2)
			{
				HatchBrush hBrush1 = new HatchBrush
					(HatchStyle.DashedVertical, Color.Chocolate, Color.Red);
				HatchBrush hBrush2 = new HatchBrush
					(HatchStyle.DarkDownwardDiagonal, Color.Green, Color.Black);
				HatchBrush hBrush3 = new HatchBrush
					(HatchStyle.SmallCheckerBoard, Color.BlueViolet, Color.Blue);

				g.FillEllipse(hBrush1, 20, 40, 100, 120);			
				Rectangle rect = new Rectangle(150, 80, 200, 140);            
				g.FillPie(hBrush3, 40, 20, 200, 40, 0.0f, 60.0f );			
				g.FillRectangle(hBrush2, rect);	
			}

			if(brushType == 3)
			{
				g.FillRectangle(txtrBrush, ClientRectangle);
			}

			if(brushType == 4)
			{
				Rectangle rect1 = new Rectangle(20, 40, 100, 120);
				Rectangle rect2 = new Rectangle(150, 80, 200, 140);
				Rectangle rect3 = new Rectangle(0, 20, 200, 40);

				LinearGradientBrush lgBrush1 = new LinearGradientBrush
					(rect1, Color.Red, Color.Green,
					LinearGradientMode.BackwardDiagonal);  

				LinearGradientBrush lgBrush2 = new LinearGradientBrush
					(rect2, Color.Black, Color.Yellow,
					LinearGradientMode.Horizontal);  

				LinearGradientBrush lgBrush3 = new LinearGradientBrush
					(rect3, Color.Blue, Color.Gold,
					LinearGradientMode.Vertical);  

				g.FillEllipse(lgBrush1, 20, 40, 100, 120);			
				Rectangle rect = new Rectangle(150, 80, 200, 140);            
				g.FillPie(lgBrush2, 40, 20, 200, 40, 0.0f, 60.0f );			
				g.FillRectangle(lgBrush3, rect);	
			}		

			if(brushType == 5)
			{
				Point pt1 = new Point(40, 30);
				Point pt2 = new Point(80, 100);

				Color [] lnColors = {Color.Black, Color.Red};
				
				LinearGradientBrush lgBrush = new LinearGradientBrush
					(pt1, pt2, Color.Red, Color.Green);  
				lgBrush.LinearColors = lnColors;
				lgBrush.GammaCorrection = true;
				
				g.FillRectangle(lgBrush, 20, 20, 200, 200);	
			}		

			if(brushType == 6)
			{
				Rectangle rect3 = new Rectangle(0, 20, 100, 20);

				if( ! fireActive)
					fireBrush = new LinearGradientBrush
						(rect3, Color.Yellow, Color.Red,
						LinearGradientMode.Vertical);  
				else
				{
					fireBrush = new LinearGradientBrush
						(rect3, Color.Gold, Color.Red,
						LinearGradientMode.Vertical);  
				}
			
				Point pt1 = new Point(40, 30);
				Point pt2 = new Point(80, 100);

				Color [] lnColors = {Color.Black, Color.Red};
				
				LinearGradientBrush lgBrush = new LinearGradientBrush
					(pt1, pt2, Color.Red, Color.Green);  
				lgBrush.LinearColors = lnColors;
				lgBrush.GammaCorrection = true;				
				g.FillRectangle(lgBrush, this.ClientRectangle);	
				g.FillRectangle(fireBrush, 50, 50, 140, 100);	

			}		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			brushType = 0;
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			brushType = 5;	
			this.Invalidate(this.ClientRectangle);
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			brushType = 6;	
			this.Invalidate(this.ClientRectangle);		
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
				
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (fireActive)
			{
				fireActive = false;
				button1.Text = "OFF";
			}
			else 
			{
				fireActive = true;
				button1.Text = "ON";
			}
			this.Invalidate(this.ClientRectangle);			
		}
	}
}






