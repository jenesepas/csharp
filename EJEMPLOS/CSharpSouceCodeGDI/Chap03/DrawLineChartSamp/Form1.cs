using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace DrawChartSamp
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
		private Point startPoint = new Point(50, 217);
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox1;
		private Point endPoint = new Point(50, 217);

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
			this.button1 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Desktop;
			this.button1.Location = new System.Drawing.Point(360, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "Clear All";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(368, 48);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(88, 24);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Rectangle";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(480, 317);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.checkBox1,
																																	this.button1});
			this.Name = "Form1";
			this.Text = "GDI+ Line Chart";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
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

    private void Form1_Paint(object sender, 
      System.Windows.Forms.PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      Font vertFont = 
        new Font("Verdana", 10, FontStyle.Bold);
      Font horzFont = 
        new Font("Verdana", 10, FontStyle.Bold);
      SolidBrush vertBrush = new SolidBrush(Color.Black);
      SolidBrush horzBrush = new SolidBrush(Color.Blue);
      Pen blackPen = new Pen(Color.Black, 2);
      Pen bluePen = new Pen(Color.Blue, 2);
      // Drawing a vertical and a horizontal line
      g.DrawLine(blackPen,50,220,50, 25);
      g.DrawLine(bluePen,50,220,250,220);
      //X axis drawing
      g.DrawString("0",horzFont,horzBrush,30, 220);
      g.DrawString("1",horzFont,horzBrush,50,220);
      g.DrawString("2",horzFont,horzBrush,70,220);
      g.DrawString("3",horzFont,horzBrush,90,220);
      g.DrawString("4",horzFont,horzBrush,110,220);
      g.DrawString("5",horzFont,horzBrush,130,220);
      g.DrawString("6",horzFont,horzBrush,150,220);
      g.DrawString("7",horzFont,horzBrush,170,220);
      g.DrawString("8",horzFont,horzBrush,190,220);
      g.DrawString("9",horzFont,horzBrush,210,220);
      g.DrawString("10",horzFont,horzBrush,230,220);
      // Drawing vertical strings
      StringFormat vertStrFormat = new StringFormat();
      vertStrFormat.FormatFlags = 
        StringFormatFlags.DirectionVertical;

      g.DrawString("-",horzFont,horzBrush, 
        50, 212, vertStrFormat);
      g.DrawString("-",horzFont,horzBrush,
        70, 212, vertStrFormat);
      g.DrawString("-",horzFont,horzBrush,
        90, 212, vertStrFormat);
      g.DrawString("-",horzFont,horzBrush,
        110, 212, vertStrFormat);
      g.DrawString("-",horzFont,horzBrush,
        130, 212, vertStrFormat);
      g.DrawString("-",horzFont,horzBrush,
        150, 212, vertStrFormat);
      g.DrawString("-",horzFont,horzBrush,
        170, 212, vertStrFormat);
      g.DrawString("-",horzFont,horzBrush,
        190, 212, vertStrFormat);
      g.DrawString("-",horzFont,horzBrush,
        210, 212, vertStrFormat);
      g.DrawString("-",horzFont,horzBrush,
        230, 212, vertStrFormat);
      //Y axis drawing
      g.DrawString("100-",vertFont,vertBrush, 20,20);
      g.DrawString("90 -",vertFont,vertBrush, 25,40);
      g.DrawString("80 -",vertFont,vertBrush, 25,60);
      g.DrawString("70 -",vertFont,vertBrush, 25,80);
      g.DrawString("60 -",vertFont,vertBrush, 25,100);
      g.DrawString("50 -",vertFont,vertBrush, 25,120);
      g.DrawString("40 -",vertFont,vertBrush, 25,140);
      g.DrawString("30 -",vertFont,vertBrush, 25,160);
      g.DrawString("20 -",vertFont,vertBrush, 25,180);
      g.DrawString("10 -",vertFont,vertBrush, 25,200);      
      // Dispose
      vertFont.Dispose();
      horzFont.Dispose();
      vertBrush.Dispose();
      horzBrush.Dispose();
      blackPen.Dispose();
      bluePen.Dispose();
    }

	  private void Form1_MouseDown(object sender, 
      System.Windows.Forms.MouseEventArgs e)
    {
     
      if (e.Button == MouseButtons.Left)
      {
		  // Create a Graphics object 
		  Graphics g1 = this.CreateGraphics();
		  // Create two pens
		  Pen linePen = new Pen(Color.Green, 1);
		  Pen ellipsePen = new Pen(Color.Red, 1);
        startPoint = endPoint;
        endPoint = new Point(e.X, e.Y);
        // Draw the line from the current point
        // to the new point
        g1.DrawLine(linePen, startPoint, endPoint);
        // If rectangle check box is cheked
        // Draw a rectangle to represent the point
        if(checkBox1.Checked)
        {
          g1.DrawRectangle(ellipsePen, 
            e.X-2, e.Y-2, 4, 4); 
        }
        // Draw a circle to represent the point
        else 
        {
          g1.DrawEllipse(ellipsePen,
            e.X-2, e.Y-2, 4, 4); 
        }
		  // Dispose
		  linePen.Dispose();
		  ellipsePen.Dispose();
		  g1.Dispose();
      }
		
    
    }

		private void button1_Click(object sender, 
      System.EventArgs e)
    {
      startPoint.X = 50;
      startPoint.Y = 217; 
      endPoint.X = 50;
      endPoint.Y = 217; 
      this.Invalidate(this.ClientRectangle);
    }
	}
}


