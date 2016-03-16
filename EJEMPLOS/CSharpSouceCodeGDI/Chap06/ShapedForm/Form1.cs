using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace ShapedForms
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem CircleMenu;
		private System.Windows.Forms.MenuItem RectMenu;
		private System.Windows.Forms.MenuItem TriangleMenu;
		private System.Windows.Forms.MenuItem CloseMenu;

		private Size originalSize;
		private System.Windows.Forms.Button AudioBtn;
		private System.Windows.Forms.Button VideoBtn;
		private System.Windows.Forms.Button AnimationBtn;

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
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.CircleMenu = new System.Windows.Forms.MenuItem();
			this.RectMenu = new System.Windows.Forms.MenuItem();
			this.TriangleMenu = new System.Windows.Forms.MenuItem();
			this.CloseMenu = new System.Windows.Forms.MenuItem();
			this.AudioBtn = new System.Windows.Forms.Button();
			this.VideoBtn = new System.Windows.Forms.Button();
			this.AnimationBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.CircleMenu,
																						 this.RectMenu,
																						 this.TriangleMenu,
																						 this.CloseMenu});
			// 
			// CircleMenu
			// 
			this.CircleMenu.Index = 0;
			this.CircleMenu.Text = "Circle";
			this.CircleMenu.Click += new System.EventHandler(this.CircleMenu_Click);
			// 
			// RectMenu
			// 
			this.RectMenu.Index = 1;
			this.RectMenu.Text = "Original";
			this.RectMenu.Click += new System.EventHandler(this.RectMenu_Click);
			// 
			// TriangleMenu
			// 
			this.TriangleMenu.Index = 2;
			this.TriangleMenu.Text = "Triangle";
			this.TriangleMenu.Click += new System.EventHandler(this.TriangleMenu_Click);
			// 
			// CloseMenu
			// 
			this.CloseMenu.Index = 3;
			this.CloseMenu.Text = "Close";
			this.CloseMenu.Click += new System.EventHandler(this.CloseMenu_Click);
			// 
			// AudioBtn
			// 
			this.AudioBtn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0)));
			this.AudioBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.AudioBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.AudioBtn.Location = new System.Drawing.Point(64, 0);
			this.AudioBtn.Name = "AudioBtn";
			this.AudioBtn.Size = new System.Drawing.Size(160, 96);
			this.AudioBtn.TabIndex = 1;
			this.AudioBtn.Text = "Play Audio";
			this.AudioBtn.Click += new System.EventHandler(this.AudioBtn_Click);
			// 
			// VideoBtn
			// 
			this.VideoBtn.BackColor = System.Drawing.Color.Green;
			this.VideoBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.VideoBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.VideoBtn.Location = new System.Drawing.Point(176, 0);
			this.VideoBtn.Name = "VideoBtn";
			this.VideoBtn.Size = new System.Drawing.Size(160, 96);
			this.VideoBtn.TabIndex = 2;
			this.VideoBtn.Text = "Play Video";
			this.VideoBtn.Click += new System.EventHandler(this.VideoBtn_Click);
			// 
			// AnimationBtn
			// 
			this.AnimationBtn.BackColor = System.Drawing.Color.Blue;
			this.AnimationBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.AnimationBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.AnimationBtn.Location = new System.Drawing.Point(88, 120);
			this.AnimationBtn.Name = "AnimationBtn";
			this.AnimationBtn.Size = new System.Drawing.Size(152, 104);
			this.AnimationBtn.TabIndex = 3;
			this.AnimationBtn.Text = "Animation";
			this.AnimationBtn.Click += new System.EventHandler(this.AnimationBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 277);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.AnimationBtn,
																		  this.VideoBtn,
																		  this.AudioBtn});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void CircleMenu_Click(object sender, 
			System.EventArgs e)
		{
			// Create a rectangle
			Rectangle rect = 
				new Rectangle(50, 0, 300, 300);
			// Create a Shape object and call 
			// GetRectRegion method 
			Shape shp = new Shape();
			this.Region = shp.GetRectRegion(rect);	
			this.BackColor = Color.BurlyWood;
		}

		private void RectMenu_Click(object sender,
			System.EventArgs e)
		{
			// A Points array for a rectangle
			// Same points as the original form
			Point[] pts = 
			{
				new Point(0, 0),
				new Point(0, originalSize.Height), 
				new Point(originalSize.Width, originalSize.Height),
				new Point(originalSize.Width, 0)
			};
			// Create a Shape object and call 
			// GetPolyRegion method 
			Shape shp = new Shape();
			this.Region = shp.GetPolyRegion(pts);	
			// Set background color
			this.BackColor = Color.DarkGoldenrod;
					
		}

		private void TriangleMenu_Click(object sender, 
			System.EventArgs e)
		{
			// Add three lines to the path representing
			// three sides of a triangle
			Point[] pts = 
			{
				new Point(50, 0),
				new Point(0,300), 
				new Point(300, 300),
				new Point(50, 0) 
			};
			this.BackColor = Color.CornflowerBlue;
			// Create a Shape object and call 
			// GetPolyRegion method 
			Shape shp = new Shape();
			this.Region = shp.GetPolyRegion(pts);		
		}

		private void Form1_Load(object sender, 
			System.EventArgs e)
		{
			originalSize = this.Size;
			// Create a Region object from the path
			GraphicsPath path1 = 
				new GraphicsPath(FillMode.Alternate);			
			path1.AddEllipse(new Rectangle(30, 30, 
				AudioBtn.Width -60, AudioBtn.Height-60));
			AudioBtn.Region = new Region(path1);		

			GraphicsPath path2 = 
				new GraphicsPath(FillMode.Alternate);			
			path2.AddEllipse(new Rectangle(30, 30, 
				VideoBtn.Width -60, VideoBtn.Height-60));
			VideoBtn.Region = new Region(path2);	

			GraphicsPath path3 = 
				new GraphicsPath(FillMode.Alternate);			
			path3.AddEllipse(new Rectangle(20, 20, 
				VideoBtn.Width -40, VideoBtn.Height-40));
			AnimationBtn.Region = new Region(path3);	
		}

		private void Form1_MouseDown(object sender, 
			System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				this.ContextMenu = this.contextMenu1;
			}
		}

		private void CloseMenu_Click(object sender,
			System.EventArgs e)
		{
			this.Close();
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
				originalSize = this.Size;		
		}

		private void AudioBtn_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Play Audio Button clicked!");
		}

		private void VideoBtn_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Play Video Button clicked!");
		}

		private void AnimationBtn_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Play Animation Button clicked!");
		}		
	}

// Shape class contains the functionality of 
// shaped controls
public class Shape 
{       
    public Shape()
    {
    }
    public Region GetPolyRegion(Point[] pts)
    {
        // Create a graphics path
        GraphicsPath path = 
            new GraphicsPath(FillMode.Alternate);
        path.AddPolygon(pts);
        // Create a Region object from the path
        // and set it as the form's region
        Region rgn = new Region(path);  
        return rgn;
    }
    public Region GetRectRegion(Rectangle rct)
    {
        // Create a graphics path
        GraphicsPath path = 
            new GraphicsPath(FillMode.Alternate);
        path.AddEllipse(rct); 
        // Create a Region object from the path
        // and set it as the form's region
        Region rgn = new Region(path);  
        return rgn;
    }
    }
	
}

   
