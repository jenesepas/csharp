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

namespace PieChartSamp
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button DrawChart;
		protected System.Web.UI.WebControls.Button FillChart;
	
		// user defined variables
		public Bitmap curBitmap;
	  private Rectangle rect = 
			new Rectangle(250, 150, 200, 200);
		public ArrayList sliceList = new ArrayList();
		private Color curClr = Color.Black;
		int[] valArray = {50, 25, 75, 100, 50};
		Color[] clrArray = {Color.Red, Color.Green,
					Color.Yellow, Color.Pink, Color.Aqua};
		int total = 0;


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
			this.DrawChart.Click += new System.EventHandler(this.DrawChart_Click);
			this.FillChart.Click += new System.EventHandler(this.FillChart_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		private void DrawChart_Click(object sender,
      System.EventArgs e)
    {
      DrawPieChart(false);
    }

    private void FillChart_Click(object sender,
      System.EventArgs e)
    {
        DrawPieChart(true);
    }

		private void DrawPieChart(bool flMode)
    {
      // Create Bitmap and Graphics objects
      Bitmap curBitmap = new Bitmap(500, 300);
      Graphics g = Graphics.FromImage(curBitmap);
      g.SmoothingMode = SmoothingMode.AntiAlias;  
      float angle = 0; 
      float sweep = 0;    
      // Total
      for (int i=0; i<valArray.Length; i++)
      {
        total += valArray[i];
      }     
      // Read color and value from array
      // and caulate sweep
      for (int i=0; i<valArray.Length; i++)
      {
        int val = valArray[i];
        Color clr = clrArray[i];
        sweep = 360f * val / total;
        // If fill mode, fill pie
        if(flMode)
        {
            SolidBrush brush = new SolidBrush(clr);
            g.FillPie(brush, 20.0F, 20.0F, 200,
              200, angle, sweep);
        }
        else // If draw mode, dra pie
        {
            Pen pn = new Pen(clr, 2);
            g.DrawPie(pn, 20.0F, 20.0F, 200, 
              200, angle, sweep);
        }
        angle += sweep; 
      }   
      // Send output to the browser
      curBitmap.Save(this.Response.OutputStream,
        ImageFormat.Jpeg);  
      // Dispose
      curBitmap.Dispose();
      g.Dispose();
    }

		
	}
}


