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

namespace WebDrawSamp
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Pen redPen = new Pen(Color.Red, 3);
			HatchBrush brush = new HatchBrush(HatchStyle.Cross,
				Color.Red, Color.Yellow);
			Pen hatchPen = new Pen(brush, 2);
			Bitmap curBitmap = new Bitmap(200, 200);
			Graphics g = Graphics.FromImage(curBitmap);
			g.FillRectangle(brush, 50, 50, 100, 100);
			g.DrawLine(Pens.WhiteSmoke, 10, 10, 180, 10);
			g.DrawLine(Pens.White, 10, 10, 10, 180);
			curBitmap.Save(this.Response.OutputStream, ImageFormat.Gif);
			g.Dispose();
		}
	}
}
