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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace AlphaValuesSamp
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Create a Bitmap and Graphics 
			Bitmap curBitmap =
				new Bitmap("d:\\flowers13.jpg");
			Graphics g = Graphics.FromImage(curBitmap);		
			g.SmoothingMode = SmoothingMode.AntiAlias;
			// Create brushes and pens with alpha values
			Color redColor = Color.FromArgb(120, 0, 0, 255);
			Pen alphaPen = new Pen(redColor, 5);
			SolidBrush alphaBrush = 
				new SolidBrush(Color.FromArgb(90, 0, 255, 0));
			// Draw a rectanle, ellipse, and text
			g.DrawRectangle(alphaPen, 10, 20, 180, 20);
			g.FillEllipse(alphaBrush, 50, 50, 100, 100);
			g.DrawString("Aplha String", 
				new Font("Tahoma", 18), 
				new SolidBrush(Color.FromArgb(150, 160, 0, 0)),
				new PointF(20, 20));		
			curBitmap.Save(this.Response.OutputStream,
				ImageFormat.Jpeg);
			g.Dispose();
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}


