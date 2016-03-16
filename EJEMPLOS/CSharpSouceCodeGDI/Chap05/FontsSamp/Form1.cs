using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Text;


namespace FontsSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 

	public class Form1 : System.Windows.Forms.Form
	{

		[System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
		private static extern IntPtr GetStockObject(int fnObj);

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem CreateFontsMenu;
		private System.Windows.Forms.MenuItem FromHfontMenu;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem DrawText;
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
			this.CreateFontsMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.FromHfontMenu = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.DrawText = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuItem1,
																																							this.menuItem10,
																																							this.menuItem14});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.CreateFontsMenu,
																																							this.menuItem2,
																																							this.menuItem3,
																																							this.menuItem6,
																																							this.menuItem9});
			this.menuItem1.Text = "Fonts";
			// 
			// CreateFontsMenu
			// 
			this.CreateFontsMenu.Index = 0;
			this.CreateFontsMenu.Text = "Create Fonts";
			this.CreateFontsMenu.Click += new System.EventHandler(this.CreateFontsMenu_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "System Fonts";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "GetFamilies";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 3;
			this.menuItem6.Text = "Formatting Text";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 4;
			this.menuItem9.Text = "Private Font Collection";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 1;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.DrawText,
																																							 this.menuItem11,
																																							 this.menuItem12,
																																							 this.menuItem13,
																																							 this.menuItem16,
																																							 this.menuItem17});
			this.menuItem10.Text = "Text";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 1;
			this.menuItem11.Text = "Alignment & Trimming";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.Text = "Tab Stops";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 3;
			this.menuItem13.Text = "Digital Substitution";
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 4;
			this.menuItem16.Text = "String Format Flags";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 5;
			this.menuItem17.Text = "Anti Aliasing Text";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 2;
			this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuItem4,
																																							 this.menuItem15,
																																							 this.FromHfontMenu});
			this.menuItem14.Text = "Font";
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 1;
			this.menuItem15.Text = "Font Members";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// FromHfontMenu
			// 
			this.FromHfontMenu.Index = 2;
			this.FromHfontMenu.Text = "FromHfont";
			this.FromHfontMenu.Click += new System.EventHandler(this.FromHfontMenu_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "";
			// 
			// DrawText
			// 
			this.DrawText.Index = 0;
			this.DrawText.Text = "Draw Text";
			this.DrawText.Click += new System.EventHandler(this.DrawText_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 345);
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

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			/*InstalledFontCollection ifc = new InstalledFontCollection();
			FontFamily[] ffs = ifc.Families;
			Font f;
			richTextBox1.Clear();
			foreach(FontFamily ff in ffs)
			{
				if (ff.IsStyleAvailable(FontStyle.Regular))  
					f = new Font(ff.GetName(1),12,FontStyle.Regular); 

				else if(ff.IsStyleAvailable(FontStyle.Bold)) 

					f = new Font(ff.GetName(1),12, FontStyle.Bold);
				else if (ff.IsStyleAvailable(FontStyle.Italic))
					f = new Font(ff.GetName(1),12, FontStyle.Italic);
				else
					f = new Font(ff.GetName(1),12, FontStyle.Underline);

				richTextBox1.SelectionFont=f;
				richTextBox1.AppendText(ff.GetName(1)+"\r\n");
				richTextBox1.SelectionFont=f;
				richTextBox1.AppendText("abcdefghijklmnopqrstuvwxyz\r\n");
				richTextBox1.SelectionFont=f;
				richTextBox1.AppendText("ABCDEFGHIJKLMNOPQRSTUVWXYZ\r\n");
				richTextBox1.AppendText("===================================================\r\n"); 

			} 

			MessageBox.Show("finished adding fonts to window","DisplayFonts");   
			*/ 

		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);

			// Get an array of the available font families.
			FontFamily[] families = FontFamily.GetFamilies(g);
			// Draw text using each of the font families.
			Font familiesFont;
			string familyString;
			float spacing = 0;
			foreach (FontFamily family in families)
			{
				familiesFont = new Font(family, 16, FontStyle.Bold);
				familyString = "This is the " + family.Name + "family.";
				g.DrawString(
					familyString,
					familiesFont,
					Brushes.Black,
					new PointF(0, spacing));
				spacing += familiesFont.Height;
			}

			// Dispose GDI+ objects
			g.Dispose();
		}

		private void menuItem9_Click(object sender, 
			System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create font fa

			FontFamily verdanaFamily = new FontFamily("Verdana");
			FontFamily arialFamily = new FontFamily("Arial");

			Font verdanaFont = new Font( verdanaFamily, 14,
				FontStyle.Regular, GraphicsUnit.Pixel);
			Font tahomaFont = new Font( new FontFamily("Tahoma"), 10,
				FontStyle.Bold|FontStyle.Italic, GraphicsUnit.Pixel);
			
			Font arialFont = new Font(arialFamily, 16, FontStyle.Bold,
                GraphicsUnit.Point);

			PointF pointF = new PointF(30, 10);
			SolidBrush solidBrush = 
				new SolidBrush(Color.FromArgb(255, 0, 0, 255));

			g.DrawString("Drawing Text", verdanaFont, 
				new SolidBrush(Color.Red), new PointF(20,20) ); 

			g.DrawString("Drawing Text", tahomaFont, 
				new SolidBrush(Color.Blue), new PointF(50, 20) ); 

			g.DrawString("Drawing Text", arialFont, 
				new SolidBrush(Color.Green), new PointF(80, 20) ); 

			// Dispose GDI+ objects
			g.Dispose();

		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		

	  private void menuItem11_Click(object sender,
      System.EventArgs e)
    {
      // Create a Graphics object
      Graphics g = this.CreateGraphics();
      g.Clear(this.BackColor);

      string text = "Testing GDI+ Text and Font" +
        " functioanlity for alignment and trimming.";     
      // Create Font Families
      FontFamily verdanaFamily = new FontFamily("Verdana");
      FontFamily arialFamily = new FontFamily("Arial");
      // Construct Font objects
      Font verdanaFont = 
        new Font( "Verdana", 10, FontStyle.Bold);
      Font arialFont = new Font( arialFamily, 16);
      // Creating rectangles
      Rectangle rect1 = new Rectangle(10, 10, 150, 150);  
      Rectangle rect2 = new Rectangle(10, 165, 150, 100);
      // Construct StringFormat and alignment 
      StringFormat strFormat1 = new StringFormat();
      StringFormat strFormat2 = new StringFormat();
      // Set alignment, line triming, and trimming 
      // propertoes of string format
      strFormat1.Alignment = StringAlignment.Center;
      strFormat1.LineAlignment = StringAlignment.Center;
      strFormat1.Trimming = 
        StringTrimming.EllipsisCharacter;
      strFormat2.Alignment = StringAlignment.Far;
      strFormat2.LineAlignment = StringAlignment.Near;
      strFormat2.Trimming = StringTrimming.Character;
      // Draw GDI+ objects
      g.FillEllipse(new SolidBrush(Color.Blue), rect1);
      g.DrawRectangle( new Pen(Color.Black), rect2);      
      g.DrawString(text, verdanaFont, 
        new SolidBrush(Color.White) , rect1,  strFormat1);
      g.DrawString(text, arialFont, 
        new SolidBrush(Color.Red), rect2, strFormat2);
      // Dispose objects
      g.Dispose();
    }

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);

			// Create Font Families
			FontFamily verdanaFamily = new FontFamily("Verdana");
			FontFamily arialFamily = new FontFamily("Arial");
			// Construct Font objects
			Font verdanaFont = new Font( "Verdana", 10);
			Font arialFont = new Font( arialFamily, 16, FontStyle.Bold);
			Font tahomaFont = new Font( "Tahoma", 24, 
				FontStyle.Underline|FontStyle.Italic);
			
			// Create Brush and other objects
			PointF pointF = new PointF(30, 10);
			SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
			// Drawing text using DrawString
			g.DrawString("Drawing Text", verdanaFont, 
				new SolidBrush(Color.Red), new PointF(20,20) ); 
			g.DrawString("Drawing Text", arialFont, 
				new SolidBrush(Color.Blue), new PointF(20, 50) ); 
			g.DrawString("Drawing Text", tahomaFont, 
				new SolidBrush(Color.Green), new PointF(20, 80) ); 
			// Dispose GDI+ objects
			g.Dispose();
		}

		private void menuItem12_Click(object sender, 
      System.EventArgs e)
    {
      // Create a Graphics object
      Graphics g = this.CreateGraphics();
      g.Clear(this.BackColor);
      // Some text data
      string text = "ID\tMaths\tPhysics\tChemistry \n";
      text = text +
        "---------\t---------\t---------\t---------\n";
      text = text + "1002\t76\t89\t92\n";
      text = text + "1003\t53\t98\t90\n";
      text = text + "1008\t99\t78\t65\n";
      // Create a font 
      Font verdanaFont = 
        new Font( "Verdana", 10, FontStyle.Bold);
      // Create a rectangle
      Rectangle rect = new Rectangle(10, 50, 350, 250);  
      // Create StringFormat
      StringFormat strFormat = new StringFormat();
      // Set tab stops of string format
      strFormat.SetTabStops(5, new float[]
          {80, 100, 80, 80});
      // Draw string 
      g.DrawString("Students Marks Table", 
        new Font("Tahoma", 16), 
        new SolidBrush(Color.Black), new Rectangle
        (10, 10, 300, 100));
      g.DrawString("=============", 
        new Font("Tahoma", 16), 
        new SolidBrush(Color.Black), 
        new Rectangle(10, 23, 300, 100));
      // Draw string with tab stops
      g.DrawString(text, verdanaFont, 
        new SolidBrush(Color.Red), rect, strFormat);
        // Dispose GDI+ objects
      g.Dispose();  
    }

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);

			Font arialFont = new Font( "Arial", 16, 
				FontStyle.Bold|FontStyle.Underline|FontStyle.Italic);
            MessageBox.Show("Font Properties = Name:"+arialFont.Name
				+" Size:"+arialFont.Size.ToString()
				+" Style:"+ arialFont.Style.ToString()
				+" Default Unit:"+ arialFont.Unit.ToString()
				+" Size in Points:"+ arialFont.SizeInPoints.ToString());	

			// Dispose GDI+ objects
			g.Dispose();		
		}

	  private void menuItem16_Click(object sender, 
      System.EventArgs e)
    {
      // Creat a Graphics object
      Graphics g = this.CreateGraphics();
          // Create a rectangle
      Rectangle rect = new Rectangle(50, 50, 350, 250);  
      // Create two StringFormat objects
      StringFormat strFormat1 = new StringFormat(); 
      StringFormat strFormat2 = new StringFormat(); 
      // Set Format flags of StringFormat objects
      // with direction right to left
      strFormat1.FormatFlags = 
        StringFormatFlags.DirectionRightToLeft;
      // Direction vertical
      strFormat2.FormatFlags = 
        StringFormatFlags.DirectionVertical; 
      // Set alignment
      strFormat2.Alignment = StringAlignment.Far;
      // Draw rectangle
      g.DrawRectangle(new Pen(Color.Blue), rect); 
      string str = 
            "Horizontal Text: This is horizontal"
            + "text inside a rectangle";
      // Draw strings
      g.DrawString(str, 
        new Font("Verdana", 10, FontStyle.Bold), 
        new SolidBrush(Color.Green), 
        rect, strFormat1);
      g.DrawString("Vertical: Text String", 
        new Font("Arial", 14), 
        new SolidBrush(Color.Red), 
        rect, strFormat2);
        // Dispose GDI+ objects
      g.Dispose();  
    }

		private void menuItem17_Click(object sender,
      System.EventArgs e)
    {
      Graphics g = this.CreateGraphics();
      g.Clear(this.BackColor);
      
      SolidBrush redBrush = new SolidBrush(Color.Red);
      Font verdana16 = new Font("Verdana", 16);
      string text1 = "Text with SingleBitPerPixel";
      string text2 = "Text with ClearTypeGridFit";
      string text3 = "Text with AntiAliasing";      
      string text4 = "Text with SystemDefault";
      // Set TextRenderingHint property of surface
      // to single bit per pixel
      g.TextRenderingHint = 
        TextRenderingHint.SingleBitPerPixel;
      // Draw string
      g.DrawString(text1, verdana16, redBrush, 
        new PointF(10, 10));
      // Set TextRenderingHint property of surface
      // to clear type grid fit
      g.TextRenderingHint = 
        TextRenderingHint.ClearTypeGridFit;
      // Draw string 
      g.DrawString(text2, verdana16, redBrush, 
        new PointF(10, 60));
      // Set TextRenderingHint property of surface
      // to anti alias
      g.TextRenderingHint = TextRenderingHint.AntiAlias;
      // Draw string
      g.DrawString(text3, verdana16, redBrush, 
        new PointF(10, 100));
      // Set TextRenderingHint property of surface
      // to system default
      g.TextRenderingHint = 
        TextRenderingHint.SystemDefault;
      // Draw string
      g.DrawString(text4, verdana16, redBrush, 
        new PointF(10, 150));
      // Dispose
      redBrush.Dispose();
      g.Dispose();
    }

		private void CreateFontsMenu_Click(object sender, System.EventArgs e)
		{
			// Create Font Families
			FontFamily verdanaFamily = new FontFamily("Verdana");
			FontFamily arialFamily = new FontFamily("Arial");
			// Construct Font objects
			Font verdanaFont = new Font( verdanaFamily, 14,
				FontStyle.Regular, GraphicsUnit.Pixel);
			Font tahomaFont = new Font( new FontFamily("Tahoma"), 10,
				FontStyle.Bold|FontStyle.Italic, GraphicsUnit.Pixel);			
			Font arialFont = new Font(arialFamily, 16, FontStyle.Bold, 
				GraphicsUnit.Point);
			Font tnwFont = new Font("Times New Roman", 12);
		}

		private void FromHfontMenu_Click(object sender,
      System.EventArgs e)
    {
      // Greate the Graphics object
      Graphics g = this.CreateGraphics();
      // Create a brush
      SolidBrush brush = new SolidBrush(Color.Red);
      // Get a handle 
      IntPtr hFont = GetStockObject(0);
      // Create a font from handle
      Font hfontFont = Font.FromHfont(hFont);
      // Draw text 
      g.DrawString("GDI HFONT", hfontFont,
        brush, 20, 20);
      // Dispose
      brush.Dispose();
      g.Dispose();
    }

		private void Properties_Click(object sender, System.EventArgs e)
		{
				// Create a Graphics object
				Graphics g = this.CreateGraphics();
				// Create a Font
				Font fnt = new Font("Verdana", 10);
				// Get height
				float lnSpace = fnt.GetHeight(g);
				// Line spacing
				int cellSpace = 
					fnt.FontFamily.GetLineSpacing(fnt.Style);
				// cell ascent
				int cellAscent = 
					fnt.FontFamily.GetCellAscent(fnt.Style);
				// cell descent
				int cellDescent =
					fnt.FontFamily.GetCellDescent(fnt.Style);
				// Font height
				int emHeight = 
					fnt.FontFamily.GetEmHeight(fnt.Style);
				// Free space
				float free = cellSpace - (cellAscent + cellDescent);
				// Display values
				string str = "Cell Height:" + lnSpace.ToString() +
					", Line Spacing: "+cellSpace.ToString() +
					", Ascent:"+ cellAscent.ToString() +
					", Descent:"+ cellDescent.ToString() +
					", Free:"+free.ToString() +
					", EM Height:"+ emHeight.ToString() ;
				MessageBox.Show(str.ToString());    
				// Dispose
				g.Dispose();
	
		}

		private void DrawText_Click(object sender,
      System.EventArgs e)
    {
      // Create a Graphics object
      Graphics g = this.CreateGraphics();
      // Create Font Families
      FontFamily verdanaFamily = new FontFamily("Verdana");
      FontFamily arialFamily = new FontFamily("Arial");
      // Construct Font objects
      Font verdanaFont = new Font( "Verdana", 10);
      Font arialFont = 
        new Font( arialFamily, 16, FontStyle.Bold);
      Font tahomaFont = new Font( "Tahoma", 24, 
        FontStyle.Underline|FontStyle.Italic);
      // Create Brush and other objects
      PointF pointF = new PointF(30, 10);
      SolidBrush solidBrush = 
        new SolidBrush(Color.FromArgb(255, 0, 0, 255));
      // Drawing text using DrawString
      g.DrawString("Drawing Text", verdanaFont, 
        new SolidBrush(Color.Red), new PointF(20,20) ); 
      g.DrawString("Drawing Text", arialFont, 
        new SolidBrush(Color.Blue), new PointF(20, 50) ); 
      g.DrawString("Drawing Text", tahomaFont, 
        new SolidBrush(Color.Green), new PointF(20, 80) );
      // Dispose
      solidBrush.Dispose();
      g.Dispose();
    }

	
	}
}




