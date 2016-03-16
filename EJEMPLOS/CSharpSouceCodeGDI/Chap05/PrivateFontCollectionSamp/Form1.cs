using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Text;

namespace PrivateFontCollectionSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
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
			this.menuItem2 = new System.Windows.Forms.MenuItem();
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
																																							this.menuItem2});
			this.menuItem1.Text = "PFC";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Add";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 273);
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

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
	}

		private void menuItem2_Click(object sender,
      System.EventArgs e)
    {
      Graphics g = this.CreateGraphics();
      PointF pointF = new PointF(10, 20);   
      string fontName;    
      // Create a PrivateFontCollection
      PrivateFontCollection pfc = 
        new PrivateFontCollection();
      // Add font files to the private font collection
      pfc.AddFontFile("tekhead.ttf");
      pfc.AddFontFile("DELUSION.TTF");
      pfc.AddFontFile("HEMIHEAD.TTF");
      pfc.AddFontFile("C:\\WINNT\\Fonts\\Verdana.ttf");
      // Return all font families from the collection
      FontFamily[] fontFamilies = pfc.Families;
      // Get font families one by one, 
      // add new styles and draw 
      // text using DrawString
      for(int j = 0; j < fontFamilies.Length; ++j)
      {
        // Get the font family name.
        fontName = fontFamilies[j].Name;
      
        if(fontFamilies[j].IsStyleAvailable(
          FontStyle.Italic) &&
          fontFamilies[j].IsStyleAvailable(
          FontStyle.Bold) && 
          fontFamilies[j].IsStyleAvailable(
          FontStyle.Underline) &&
          fontFamilies[j].IsStyleAvailable(
          FontStyle.Strikeout) )
        {
          // Create a font from font name
          Font newFont = new Font(fontName,
            20, FontStyle.Italic | FontStyle.Bold 
            |FontStyle.Underline, GraphicsUnit.Pixel);
          // Draw string using the current font
          g.DrawString(fontName, newFont,
            new SolidBrush(Color.Red), pointF);
          // Set location
          pointF.Y += newFont.Height;
        }   
      } 
      // Dispose
      g.Dispose();
    }
		}
}


