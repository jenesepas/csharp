using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace DrawGDIObjsSamp
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
		
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, 
			System.EventArgs e)
		{
			// Construct brush and pens
			Pen redPen = new Pen(Color.Red, 3);
			HatchBrush brush =
				new HatchBrush(HatchStyle.Cross,
				Color.Yellow, Color.Green);
			Pen hatchPen = new Pen(brush, 2);
			Pen bluePen = new Pen(Color.Blue, 3);
			Bitmap curBitmap = new Bitmap(300, 200);
			Graphics g = Graphics.FromImage(curBitmap);
			g.SmoothingMode = SmoothingMode.AntiAlias;
      string testString = 
				"Hello GDI+ On the Web";
			Font verdana14 = new Font("Verdana", 14);
			Font tahoma18 = new Font("Tahoma", 18);					
			int nChars;
			int nLines;          
			// Call MeasureString to measure a string
			SizeF sz = g.MeasureString(testString, verdana14);
			string stringDetails = 
					"Height: "+sz.Height.ToString() 
				+ ", Width: "+sz.Width.ToString();
			g.DrawString(testString, verdana14,
				Brushes.Wheat, new PointF(40, 70));
			g.DrawRectangle(new Pen(Color.Red, 2), 
				40.0F, 70.0F, sz.Width, sz.Height);
			sz = g.MeasureString("Ellipse", tahoma18, 
				new SizeF(0.0F, 100.0F), 
				new StringFormat(),
				out nChars, out nLines);
			stringDetails = 
				"Height: "+sz.Height.ToString() 
				+ ", Width: "+sz.Width.ToString()
				+ ", Lines: "+nLines.ToString()
				+ ", Chars: "+nChars.ToString();				
			// Draw Lines
			g.DrawLine(Pens.WhiteSmoke, 10, 20, 180, 20);
			g.DrawLine(Pens.White, 20, 10, 20, 180);
			// Fill Ellipse
			g.FillEllipse(brush, 120, 100, 100, 100);
			// Draw String
			g.DrawString("Ellipse", tahoma18,
				Brushes.Beige, new PointF(40, 20));
			// Draw Ellipse
			g.DrawEllipse( new Pen(Color.Yellow, 3),
				40, 20, sz.Width, sz.Height);
			// Send output to the Browser and
			// dispose objects
			curBitmap.Save(this.Response.OutputStream,
				ImageFormat.Jpeg);
			g.Dispose();		
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			// Create a Bitmap object from a file
			Bitmap curBitmap =
				new Bitmap("d:\\white_salvia.jpg");
			// Create a Graphics from Bitmap
			Graphics g = Graphics.FromImage(curBitmap);		
			// Set modes
			g.SmoothingMode = SmoothingMode.AntiAlias;
			// Send output to the browser
			curBitmap.Save(this.Response.OutputStream, 
				ImageFormat.Jpeg);
			// Dispose
			g.Dispose();
		}
	}
}


