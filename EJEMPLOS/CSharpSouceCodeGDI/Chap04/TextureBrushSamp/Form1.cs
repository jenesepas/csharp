using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace TextureBrushSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem Clamp;
		private System.Windows.Forms.MenuItem Tile;
		private System.Windows.Forms.MenuItem TileFlipX;
		private System.Windows.Forms.MenuItem TileFlipY;
		private System.Windows.Forms.MenuItem TileFlipXY;

		private TextureBrush txtrBrush = null;


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
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.Clamp = new System.Windows.Forms.MenuItem();
			this.Tile = new System.Windows.Forms.MenuItem();
			this.TileFlipX = new System.Windows.Forms.MenuItem();
			this.TileFlipY = new System.Windows.Forms.MenuItem();
			this.TileFlipXY = new System.Windows.Forms.MenuItem();
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																								 this.Clamp,
																																								 this.Tile,
																																								 this.TileFlipX,
																																								 this.TileFlipY,
																																								 this.TileFlipXY});
			// 
			// Clamp
			// 
			this.Clamp.Index = 0;
			this.Clamp.Text = "Clamp";
			this.Clamp.Click += new System.EventHandler(this.Clamp_Click);
			// 
			// Tile
			// 
			this.Tile.Index = 1;
			this.Tile.Text = "Tile";
			this.Tile.Click += new System.EventHandler(this.Tile_Click);
			// 
			// TileFlipX
			// 
			this.TileFlipX.Index = 2;
			this.TileFlipX.Text = "TileFlipX";
			this.TileFlipX.Click += new System.EventHandler(this.TileFlipX_Click);
			// 
			// TileFlipY
			// 
			this.TileFlipY.Index = 3;
			this.TileFlipY.Text = "TileFlipY";
			this.TileFlipY.Click += new System.EventHandler(this.TileFlipY_Click);
			// 
			// TileFlipXY
			// 
			this.TileFlipXY.Index = 4;
			this.TileFlipXY.Text = "TileFlipXY";
			this.TileFlipXY.Click += new System.EventHandler(this.TileFlipXY_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 293);
			this.Name = "Form1";
			this.Text = "Texture Brush ";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
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

		private void Form1_Load(object sender, 
      System.EventArgs e)
    {
      // Create an Image from a file
      Image img = new Bitmap("smallRoses.gif");   
      // Create a texture brush from an image
      txtrBrush = new TextureBrush(img);
		img.Dispose();
    }

    private void Form1_Paint(object sender, 
      System.Windows.Forms.PaintEventArgs e)
    {
        Graphics g = e.Graphics;    
        // Fill a rectangle with a texture brush
        g.FillRectangle(txtrBrush, ClientRectangle);
    }

		private void Clamp_Click(object sender, 
      System.EventArgs e)
    {
      txtrBrush.WrapMode = WrapMode.Clamp;
      this.Invalidate();
    }

    private void Tile_Click(object sender,
      System.EventArgs e)
    {
      txtrBrush.WrapMode = WrapMode.Tile; 
      this.Invalidate();
    }

    private void TileFlipX_Click(object sender, 
      System.EventArgs e)
    {
      txtrBrush.WrapMode = WrapMode.TileFlipX;    
      this.Invalidate();
    }

    private void TileFlipY_Click(object sender, 
      System.EventArgs e)
    {
      txtrBrush.WrapMode = WrapMode.TileFlipY;
      this.Invalidate();
    }

    private void TileFlipXY_Click(object sender, 
      System.EventArgs e)
    {
      txtrBrush.WrapMode = WrapMode.TileFlipXY;
      this.Invalidate();
    }

    private void Form1_MouseDown(object sender,
      System.Windows.Forms.MouseEventArgs e)
    {
      if(e.Button == MouseButtons.Right)
      {
        this.ContextMenu = contextMenu1;
      }   
    }
	}
}
