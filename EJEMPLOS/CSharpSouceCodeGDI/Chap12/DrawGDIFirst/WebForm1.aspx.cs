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



namespace DrawGDIFirst
{
	public class WebForm1 : System.Web.UI.Page
	{
		private void Page_Load(object sender,
      System.EventArgs e)
    {
      // Create pens and bruses
      Pen redPen = new Pen(Color.Red, 3);
      HatchBrush brush = 
        new HatchBrush(HatchStyle.Cross,
        Color.Red, Color.Yellow);
      // Create a Bitmap
      Bitmap curBitmap = new Bitmap(200, 200);
      // Create a Graphics object from Bitmap
      Graphics g = Graphics.FromImage(curBitmap);
      // Dra and fill rectangles
      g.FillRectangle(brush, 50, 50, 100, 100);
      g.DrawLine(Pens.WhiteSmoke, 10, 10, 180, 10);
      g.DrawLine(Pens.White, 10, 10, 10, 180);
      // Save the Bitmap and send response to the 
      // browser
      curBitmap.Save(Response.OutputStream,
        ImageFormat.Jpeg);
      // Dispose Graphics and Bitmap
      curBitmap.Dispose();
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
