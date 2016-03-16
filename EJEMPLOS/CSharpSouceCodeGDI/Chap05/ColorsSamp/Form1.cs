using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ColorsSamp
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
		private System.Windows.Forms.MenuItem HSBMenu;
		private System.Windows.Forms.MenuItem SystemColorsMenu;
		private System.Windows.Forms.MenuItem ColorStructMenu;
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
			this.ColorStructMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.HSBMenu = new System.Windows.Forms.MenuItem();
			this.SystemColorsMenu = new System.Windows.Forms.MenuItem();
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
																																							this.ColorStructMenu,
																																							this.menuItem2,
																																							this.menuItem3,
																																							this.HSBMenu,
																																							this.SystemColorsMenu});
			this.menuItem1.Text = "Color Properties";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// ColorStructMenu
			// 
			this.ColorStructMenu.Index = 0;
			this.ColorStructMenu.Text = "Color Structure";
			this.ColorStructMenu.Click += new System.EventHandler(this.ColorStructMenu_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "ColorTranslator";
			this.menuItem2.Click += new System.EventHandler(this.ColorTranslator_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "ColorConverter";
			this.menuItem3.Click += new System.EventHandler(this.ColorConvert_Click);
			// 
			// HSBMenu
			// 
			this.HSBMenu.Index = 3;
			this.HSBMenu.Text = "HSB";
			this.HSBMenu.Click += new System.EventHandler(this.HSBMenu_Click);
			// 
			// SystemColorsMenu
			// 
			this.SystemColorsMenu.Index = 4;
			this.SystemColorsMenu.Text = "System Colors";
			this.SystemColorsMenu.Click += new System.EventHandler(this.SystemColorsMenu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 273);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

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

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.Invalidate(this.ClientRectangle);
		}

		private void ColorStructMenu_Click(object sender, 
      System.EventArgs e)
    {
      // Create Graphics object 
      Graphics g = this.CreateGraphics();
      // Create Color object from Argb
      Color redColor = Color.FromArgb(120, 255, 0, 0);
      // Create Color object form color name
      Color blueColor = Color.FromName("Blue"); 
      // Create Color object from known color
      Color greenColor = 
        Color.FromKnownColor(KnownColor.Green);
      // Create empty color
      Color tstColor = Color.Empty;   
      // See if a color is empty
      if(greenColor.IsEmpty)
      {
        tstColor = Color.DarkGoldenrod;     
      }
      // Create brushes and pens from colors
      SolidBrush redBrush = new SolidBrush(redColor);
      SolidBrush blueBrush = new SolidBrush(blueColor);
      SolidBrush greenBrush = new SolidBrush(greenColor);
      Pen greenPen = new Pen(greenBrush, 4);
      // Draw GDI+ ojbects
      g.FillEllipse(redBrush, 10, 10, 50, 50);
      g.FillRectangle(blueBrush, 60, 10, 50, 50);
      g.DrawLine(greenPen, 20, 60, 200, 60);  
      // Check properties values
      MessageBox.Show("Color Name :"+ blueColor.Name +
        ", A:"+blueColor.A.ToString() +
        ", R:"+blueColor.R.ToString() +
        ", B:"+blueColor.B.ToString() +
        ", G:"+blueColor.G.ToString() );
      // Dispose GDI+ objects
      redBrush.Dispose();
      blueBrush.Dispose();
			greenBrush.Dispose();
      greenPen.Dispose();
      g.Dispose();      
    }

	

		private void ColorConvert_Click(object sender, 
      System.EventArgs e)
    {
      Graphics g = this.CreateGraphics();
      // Translate colors
      Color win32Color = 
        ColorTranslator.FromWin32(0xFF0033);
      Color htmlColor = 
        ColorTranslator.FromHtml("#00AAFF");
      // Using colors
      SolidBrush redBrush = new SolidBrush(win32Color);
      SolidBrush blueBrush = new SolidBrush(htmlColor);
      // Drawing GDI+ objects
      g.FillEllipse(redBrush, 10, 10, 50, 50);
      g.FillRectangle(blueBrush, 60, 10, 50, 50);
      //Dispose
      redBrush.Dispose();
      blueBrush.Dispose();
      g.Dispose();
    }

		private void ColorTranslator_Click(object sender,
      System.EventArgs e)
    {
      Graphics g = this.CreateGraphics();
      g.Clear(this.BackColor);
      string str = "#FF00FF";
      ColorConverter clrConverter = new ColorConverter();
      Color clr1 = 
        (Color)clrConverter.ConvertFromString(str);
      // Using colors
      SolidBrush redBrush = new SolidBrush(clr1);
      SolidBrush blueBrush = new SolidBrush(clr1);
      // Drawing GDI+ objects
      g.FillEllipse(redBrush, 10, 10, 50, 50);
      g.FillRectangle(blueBrush, 60, 10, 50, 50);
      //Dispose
      redBrush.Dispose();
      blueBrush.Dispose();
      g.Dispose();      
    }

	  private void HSBMenu_Click(object sender, 
      System.EventArgs e)
    {
      // Create a Graphics object
      Graphics     g = this.CreateGraphics(); 
      // Create a color 
      Color clr = Color.FromArgb(255, 200, 0, 100);   
      // Get hue, saturation, and brightness components
      float h = clr.GetHue();
      float s = clr.GetSaturation();
      float v = clr.GetBrightness(); 
      string str = "Hue: "+ h.ToString() + "\n" +
              "Saturation: "+ s.ToString() + "\n" +
              "Brightness: "+ v.ToString();
      // Display data
      g.DrawString(str, new Font("verdana", 12), 
        Brushes.Blue, 50, 50);
      // Dispose
      g.Dispose();
    }

		private void SystemColorsMenu_Click(object sender,
      System.EventArgs e)
    {
      // Create a Graphics object
      Graphics     g = this.CreateGraphics(); 
      // Create brushes and pens
      SolidBrush brush1 = 
        (SolidBrush)SystemBrushes.FromSystemColor
        (SystemColors.ActiveCaption);
      Pen pn1 = SystemPens.FromSystemColor
        (SystemColors.HighlightText);
      Pen pn2 = SystemPens.FromSystemColor
        (SystemColors.ControlLightLight);
      Pen pn3 = SystemPens.FromSystemColor
        (SystemColors.ControlDarkDark);
      // Draw and fill graphics objects
      g.DrawLine(pn1, 10, 10, 10, 200);
      g.FillRectangle(brush1, 60, 60, 100, 100);
      g.DrawEllipse(pn3, 20, 20, 170, 170);
      g.DrawLine(pn2, 10, 10, 200, 10);
      // Dispose
      g.Dispose();    
    }   
	}
}



