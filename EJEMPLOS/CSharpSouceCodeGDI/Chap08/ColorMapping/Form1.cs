using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace ColorMapping
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem ColorMatrix;
		private System.Windows.Forms.MenuItem ColorMap;
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
			this.ColorMap = new System.Windows.Forms.MenuItem();
			this.ColorMatrix = new System.Windows.Forms.MenuItem();
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
																					  this.ColorMap,
																					  this.ColorMatrix});
			this.menuItem1.Text = "Color Objects";
			// 
			// ColorMap
			// 
			this.ColorMap.Index = 0;
			this.ColorMap.Text = "Color Map";
			this.ColorMap.Click += new System.EventHandler(this.ColorMap_Click);
			// 
			// ColorMatrix
			// 
			this.ColorMatrix.Index = 1;
			this.ColorMatrix.Text = "Color Matrix";
			this.ColorMatrix.Click += new System.EventHandler(this.ColorMatrix_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 285);
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

		private void ColorMap_Click(object sender, 
			System.EventArgs e)
		{
			// Create a Graphics
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create an Image object
			Image image = new Bitmap("Sample.bmp");
			// Create ImageAttributes
			ImageAttributes  imageAttributes = 
				new ImageAttributes();		
			// Create three ColorMap objects
			ColorMap colorMap1 = new ColorMap();
			ColorMap colorMap2 = new ColorMap();
			ColorMap colorMap3 = new ColorMap();
			// Set ColorMap objects properties
			colorMap1.OldColor = Color.Red;
			colorMap1.NewColor = Color.Green; 
			colorMap2.OldColor = Color.Yellow;
			colorMap2.NewColor = Color.Navy; 
			colorMap3.OldColor = Color.Blue;
			colorMap3.NewColor = Color.Aqua; 
			// Create an array of ColorMap objects
			// because SetRemapTable takes an array
			ColorMap[] remapTable = 
			{
				colorMap1, 
				colorMap2,
				colorMap3
			};
			imageAttributes.SetRemapTable(remapTable,
				ColorAdjustType.Bitmap);
			// Draw Image
			g.DrawImage(image, 10, 10, image.Width, image.Height);
			// Draw Image with color map
			g.DrawImage(
				image, 
				new Rectangle(150, 10, image.Width, image.Height),  
				0, 0, image.Width, image.Height,     
				GraphicsUnit.Pixel,
				imageAttributes);	
			// Dispose
			image.Dispose();
			g.Dispose();
		}

		private void ColorMatrix_Click(object sender, 
			System.EventArgs e)
		{
		
		}

		
	}
}

