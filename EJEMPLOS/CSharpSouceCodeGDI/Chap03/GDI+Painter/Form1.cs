using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace GDIPainter
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Panel panel1;

		// Varialbes 
		private Bitmap bitmap = null;
		private Bitmap curBitmap = null;
		private bool dragMode = false;
		private int drawIndex = 1;
		private int curX, curY, x, y;
		private int diffX, diffY;
		private Graphics curGraphics;
		public Pen curPen;
		private SolidBrush curBrush;
		private Size fullSize;
		private TextReader penReader = null;
		private TextReader brushReader = null;

		private System.Windows.Forms.Button SaveBtn;
		private System.Windows.Forms.Button DrawEllipse;
		private System.Windows.Forms.Button DrawLine;
		private System.Windows.Forms.Button DrawRect;
		private System.Windows.Forms.Button FilledEllipse;
		private System.Windows.Forms.Button FilledRect;
		


		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(penReader != null)
			{
				penReader.Close();				
			}
			if(brushReader != null)
			{
				penReader.Close();				
			}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.panel1 = new System.Windows.Forms.Panel();
			this.FilledEllipse = new System.Windows.Forms.Button();
			this.FilledRect = new System.Windows.Forms.Button();
			this.SaveBtn = new System.Windows.Forms.Button();
			this.DrawRect = new System.Windows.Forms.Button();
			this.DrawEllipse = new System.Windows.Forms.Button();
			this.DrawLine = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				 this.FilledEllipse,
																																				 this.FilledRect,
																																				 this.SaveBtn,
																																				 this.DrawRect,
																																				 this.DrawEllipse,
																																				 this.DrawLine});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(640, 32);
			this.panel1.TabIndex = 0;
			// 
			// FilledEllipse
			// 
			this.FilledEllipse.BackColor = System.Drawing.Color.Yellow;
			this.FilledEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.FilledEllipse.ForeColor = System.Drawing.Color.Green;
			this.FilledEllipse.Image = ((System.Drawing.Bitmap)(resources.GetObject("FilledEllipse.Image")));
			this.FilledEllipse.Location = new System.Drawing.Point(128, 2);
			this.FilledEllipse.Name = "FilledEllipse";
			this.FilledEllipse.Size = new System.Drawing.Size(32, 30);
			this.FilledEllipse.TabIndex = 4;
			this.FilledEllipse.Click += new System.EventHandler(this.FilledEllipse_Click);
			// 
			// FilledRect
			// 
			this.FilledRect.BackColor = System.Drawing.Color.Yellow;
			this.FilledRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.FilledRect.ForeColor = System.Drawing.Color.DarkGreen;
			this.FilledRect.Image = ((System.Drawing.Bitmap)(resources.GetObject("FilledRect.Image")));
			this.FilledRect.Location = new System.Drawing.Point(96, 2);
			this.FilledRect.Name = "FilledRect";
			this.FilledRect.Size = new System.Drawing.Size(32, 30);
			this.FilledRect.TabIndex = 3;
			this.FilledRect.Click += new System.EventHandler(this.FilledRect_Click);
			// 
			// SaveBtn
			// 
			this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0)));
			this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveBtn.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.SaveBtn.ForeColor = System.Drawing.Color.White;
			this.SaveBtn.Location = new System.Drawing.Point(536, 0);
			this.SaveBtn.Name = "SaveBtn";
			this.SaveBtn.Size = new System.Drawing.Size(104, 30);
			this.SaveBtn.TabIndex = 2;
			this.SaveBtn.Text = "&Save Image";
			this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
			// 
			// DrawRect
			// 
			this.DrawRect.BackColor = System.Drawing.Color.Yellow;
			this.DrawRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DrawRect.ForeColor = System.Drawing.Color.Green;
			this.DrawRect.Image = ((System.Drawing.Bitmap)(resources.GetObject("DrawRect.Image")));
			this.DrawRect.Location = new System.Drawing.Point(64, 2);
			this.DrawRect.Name = "DrawRect";
			this.DrawRect.Size = new System.Drawing.Size(32, 30);
			this.DrawRect.TabIndex = 0;
			this.DrawRect.Click += new System.EventHandler(this.EllipseDraw_Click);
			// 
			// DrawEllipse
			// 
			this.DrawEllipse.BackColor = System.Drawing.Color.Yellow;
			this.DrawEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DrawEllipse.ForeColor = System.Drawing.Color.Green;
			this.DrawEllipse.Image = ((System.Drawing.Bitmap)(resources.GetObject("DrawEllipse.Image")));
			this.DrawEllipse.Location = new System.Drawing.Point(32, 2);
			this.DrawEllipse.Name = "DrawEllipse";
			this.DrawEllipse.Size = new System.Drawing.Size(32, 30);
			this.DrawEllipse.TabIndex = 0;
			this.DrawEllipse.Click += new System.EventHandler(this.RectDraw_Click);
			// 
			// DrawLine
			// 
			this.DrawLine.BackColor = System.Drawing.Color.Yellow;
			this.DrawLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DrawLine.ForeColor = System.Drawing.Color.DarkGreen;
			this.DrawLine.Image = ((System.Drawing.Bitmap)(resources.GetObject("DrawLine.Image")));
			this.DrawLine.Location = new System.Drawing.Point(0, 2);
			this.DrawLine.Name = "DrawLine";
			this.DrawLine.Size = new System.Drawing.Size(32, 30);
			this.DrawLine.TabIndex = 0;
			this.DrawLine.Click += new System.EventHandler(this.LineDraw_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(640, 461);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.panel1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "GDI+Painter ";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.Closed += new System.EventHandler(this.Form1_Closed);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.panel1.ResumeLayout(false);
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

		private void Form1_Load(object sender, 
      System.EventArgs e)
    {
      // Get the full size of the form
      fullSize = SystemInformation
        .PrimaryMonitorMaximizedWindowSize;
      // Create a bitmap using full size
      bitmap = new Bitmap(fullSize.Width, 
        fullSize.Height);
      // Create a Graphics object from Bitmap
      curGraphics = Graphics.FromImage(bitmap);
      // Set background color as form's color
      curGraphics.Clear(this.BackColor);
      // Create a new pen and brush as 
      // default pen and brush
      curPen = new Pen(Color.Black);
      curBrush = new SolidBrush(Color.Black);
    }

		private void Form1_MouseDown(object sender,
      System.Windows.Forms.MouseEventArgs e)
    {
      // Store the starting point of 
      // the rectangle and set the drag mode
      // to true
      curX = e.X;
      curY = e.Y;
      dragMode = true;
    }

    private void Form1_MouseMove(object sender,
      System.Windows.Forms.MouseEventArgs e)
    {
      // Find out the ending point of 
      // the rectangle and calculate the 
      // difference of starting and ending
      // points to find out the height and width 
      // of the rectangle
      x = e.X;
      y = e.Y;
      diffX = e.X - curX;
      diffY = e.Y - curY;
      // If drag mode is true, call refresh
      // that forces window to repaint
      if (dragMode)
      {
        this.Refresh();
      }
    }

    private void Form1_MouseUp(object sender, 
      System.Windows.Forms.MouseEventArgs e)
    {     
      diffX = x - curX;
      diffY = y - curY;
      switch (drawIndex)
      {
        case 1:
        {
          // Draw a line
          curGraphics.DrawLine(curPen, 
            curX, curY, x, y);
          break;
        }
        case 2:
        {
          // Draw an ellipse
          curGraphics.DrawEllipse(curPen,
            curX, curY, diffX, diffY);
          break;
        }
        case 3:
        {
          // Draw rectangle
          curGraphics.DrawRectangle(curPen,
            curX, curY, diffX, diffY);
          break;
        }
        case 4:
        {
          // Fill rectangle
          curGraphics.FillRectangle(curBrush,
           curX, curY, diffX, diffY);
          break;
        }
        case 5:
        {
          // Fill ellipse
          curGraphics.FillEllipse(curBrush, 
            curX, curY, diffX, diffY);
          break;
        }       
      }
      // Refresh 
      RefreshFormBackground();
      // Set drag mode to false
      dragMode = false;
    }

		private void LineDraw_Click(object sender,
      System.EventArgs e)
    {
      drawIndex = 1;
    }

    private void RectDraw_Click(object sender, 
      System.EventArgs e)
    {
        drawIndex = 2;
    }

    private void EllipseDraw_Click(object sender, 
      System.EventArgs e)
    {
      drawIndex = 3;
    }
    private void FilledEllipse_Click(object sender,
      System.EventArgs e)
    {
      drawIndex = 5;
    }

    private void FilledRect_Click(object sender,
      System.EventArgs e)
    {
      drawIndex = 4;
    }
		private void Form1_SizeChanged(object sender,
			System.EventArgs e)
		{
			RefreshFormBackground();
		}

		private void RefreshFormBackground()
    {
      curBitmap = bitmap.Clone(
        new Rectangle(0, 0, this.Width, this.Height),
        bitmap.PixelFormat);
      this.BackgroundImage = curBitmap;
    }

		private void Form1_Closed(object sender,
			System.EventArgs e)
		{
			// Dispose all public objects
			curPen.Dispose();
			curBrush.Dispose();		
			curGraphics.Dispose();
		}

		private void SaveBtn_Click(object sender,
      System.EventArgs e)
    {
      // Save file dialog
      SaveFileDialog saveFileDlg = new SaveFileDialog();
      saveFileDlg.Filter = 
      "Image files (*.bmp)|*.bmp|All files (*.*)|*.*" ;
      if(saveFileDlg.ShowDialog() == DialogResult.OK)
      {
        // Create bitmap and call Save method 
        // to save it 
        Bitmap tmpBitmap = bitmap.Clone
          (new Rectangle(0, 0, 
          this.Width, this.Height),
          bitmap.PixelFormat);
        tmpBitmap.Save(saveFileDlg.FileName,
          ImageFormat.Bmp); 
      }     
    }

			

		private void Form1_Paint(object sender, 
      System.Windows.Forms.PaintEventArgs e)
    {
      
      Graphics g = e.Graphics;
      // If dragmode is true, draw selected
      // graphics shape
      if (dragMode)
      {
        switch (drawIndex)
        {
          case 1:
          {
            g.DrawLine(curPen, curX, curY, x, y);
            break;
          }
          case 2:
          {
            g.DrawEllipse(curPen, 
              curX, curY, diffX, diffY);
            break;
          }
          case 3:
          {
            g.DrawRectangle(curPen, 
              curX, curY, diffX, diffY);
            break;
          }
          case 4:
          {       
            g.FillRectangle(curBrush, 
              curX, curY, diffX, diffY);            
            break;
          }
          case 5:
          {
            g.FillEllipse(curBrush, 
              curX, curY, diffX, diffY);
            break;
          }       
        }
      }
    }   

	
	}
}
