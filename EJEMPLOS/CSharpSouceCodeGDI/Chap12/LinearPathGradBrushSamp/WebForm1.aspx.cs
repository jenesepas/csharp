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

namespace LinearPathGradBrushSamp
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		private void Page_Load(object sender, 
			System.EventArgs e)
		{
			// Create a linear gradeient brush
			LinearGradientBrush lgBrush = 
				new LinearGradientBrush(
				new Rectangle(0, 0, 10, 10), 
				Color.Yellow, Color.Blue, 
				LinearGradientMode.ForwardDiagonal); 
			// Create a path 
			GraphicsPath path = new GraphicsPath();
			path.AddEllipse(50, 50, 150, 150);
			path.AddEllipse(10, 10, 50, 50);
			// Create a path gradient brush
      PathGradientBrush pgBrush = 
				new PathGradientBrush(path);
			pgBrush.CenterColor = Color.Red;
			// Create Bitmap and Graphics objects
			Bitmap curBitmap = new Bitmap(500, 300);
			Graphics g = Graphics.FromImage(curBitmap);
			g.SmoothingMode = SmoothingMode.AntiAlias;	
			g.FillPath(pgBrush, path);
			g.FillRectangle(lgBrush, 250, 20, 100, 100);
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

