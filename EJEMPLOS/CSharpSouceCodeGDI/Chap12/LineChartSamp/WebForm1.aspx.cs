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

namespace LineChartSamp
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox TextBox5;
		protected System.Web.UI.WebControls.TextBox TextBox6;
		protected System.Web.UI.WebControls.TextBox TextBox7;
		protected System.Web.UI.WebControls.TextBox TextBox8;
		protected System.Web.UI.WebControls.TextBox TextBox9;
		protected System.Web.UI.WebControls.TextBox TextBox10;
		protected System.Web.UI.WebControls.TextBox TextBox11;
		protected System.Web.UI.WebControls.TextBox TextBox12;
		protected System.Web.UI.WebControls.TextBox TextBox13;
		protected System.Web.UI.WebControls.TextBox TextBox14;
		protected System.Web.UI.WebControls.TextBox TextBox15;
		protected System.Web.UI.WebControls.TextBox TextBox16;
		protected System.Web.UI.WebControls.TextBox TextBox17;
		protected System.Web.UI.WebControls.TextBox TextBox18;
		protected System.Web.UI.WebControls.Button Button1;
	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, 
			System.EventArgs e)
		{
			// Get the Chart background color
			Color clr = Color.FromName(TextBox3.Text);
			// Create a ChartComp object
			ChartComp chart = 
				new ChartComp(1, clr, 400, 300, this.Page);
			chart.X0 = 0; 
			chart.Y0= 0; 
			chart.chartX = Convert.ToInt16(TextBox1.Text);
			chart.chartY = Convert.ToInt16(TextBox2.Text);
			// Add points to the chart
			chart.InsertPoint(Convert.ToInt16(TextBox4.Text),
				Convert.ToInt16(TextBox5.Text), 
				Color.FromName(TextBox6.Text) );
			chart.InsertPoint(Convert.ToInt16(TextBox7.Text),
				Convert.ToInt16(TextBox8.Text), 
				Color.FromName(TextBox9.Text) );
			chart.InsertPoint(Convert.ToInt16(TextBox10.Text),
				Convert.ToInt16(TextBox11.Text), 
				Color.FromName(TextBox12.Text) );
			chart.InsertPoint(Convert.ToInt16(TextBox13.Text),
				Convert.ToInt16(TextBox14.Text), 
				Color.FromName(TextBox15.Text) );
			chart.InsertPoint(Convert.ToInt16(TextBox16.Text),
				Convert.ToInt16(TextBox17.Text),
				Color.FromName(TextBox18.Text) );
			// Draw chart
			chart.DrawChart();		
		}
	}

  // Chart Component 
  class ChartComp
  {
    public Bitmap curBitmap;
    public ArrayList ptsArrayList =
      new ArrayList();
    public float X0 = 0, Y0 = 0;
    public float chartX, chartY;
    public Color chartColor = Color.Gray;
    // ChartType: 1=Line, 2=Pie, 3=Bar. 
    // For future use only
    public int chartType = 1;
    private int Width, Height;
    private Graphics g;
    private Page curPage;
    struct ptStructure 
    {
      public float x;
      public float y;
      public Color clr;
    }
    //ChartComp Constructor
    public ChartComp(int cType, Color cColor, 
      int cWidth, int cHeight, Page cPage) 
    {
      Width = cWidth; 
      Height = cHeight;
      chartX = cWidth; 
      chartY = cHeight;
      curPage = cPage;
      chartType = cType;
      chartColor = cColor;
      curBitmap = new Bitmap(Width, Height);
      g = Graphics.FromImage(curBitmap);            
    }
    // Descructor. Dispose objects
    ~ChartComp() 
    {
      curBitmap.Dispose();
      g.Dispose();    
    }
    // InsertPoint methods. Adds a point 
    // to the array
    public void InsertPoint(int xPos,
      int yPos, Color clr) 
    {
      ptStructure pt;
      pt.x = xPos;
      pt.y = yPos;
      pt.clr = clr;
      // Add the point to the array
      ptsArrayList.Add(pt);
    }
    public void InsertPoint(int position, 
      int xPos, int yPos, Color clr) 
    {
      ptStructure pt;
      pt.x = xPos;
      pt.y = yPos;
      pt.clr = clr;
      // Add the point to the array
      ptsArrayList.Insert(position, pt);
    }
    // Draw methods
    public void DrawChart() 
    {
      int i;
      float x, y, x0, y0;     
      curPage.Response.ContentType="image/jpeg";
      g.SmoothingMode = SmoothingMode.HighQuality;
      g.FillRectangle(new SolidBrush(chartColor),
        0, 0, Width, Height);
      int chWidth = Width-80;
      int chHeight = Height-80;
      g.DrawRectangle(Pens.Black, 
        40, 40, chWidth, chHeight); 
      g.DrawString("GDI+ Chart", new Font("arial",14),
        Brushes.Black, Width/3, 10);
      //Draw X and Y axis line, points, positions
      for(i=0; i<=5; i++) 
      {
        x = 40+(i*chWidth)/5;
        y = chHeight+40;
        string str = (X0 + (chartX*i/5)).ToString();
        g.DrawString(str, new Font("Verdana",10),
          Brushes.Blue, x-4, y+10);
        g.DrawLine(Pens.Black, x, y+2, x, y-2);
      }
      for(i=0; i<=5; i++) 
      {
        x = 40;
        y = chHeight+40-(i*chHeight/5);
        string str = (Y0 + (chartY*i/5)).ToString();
        g.DrawString(str, new Font("Verdana",10), 
          Brushes.Blue, 5, y-6);
        g.DrawLine(Pens.Black, x+2, y, x-2, y);
      }
      //Transform coordinates so (0,0) point starts from
      // the lower left corner. 
      g.RotateTransform(180);
      g.TranslateTransform(-40, 40);
      g.ScaleTransform(-1, 1);
      g.TranslateTransform(0, -(Height));
      // Draw all points from the array
      ptStructure prevPoint = new ptStructure();
      foreach(ptStructure pt in ptsArrayList) 
      {
        x0 = chWidth*(prevPoint.x-X0)/chartX;
        y0 = chHeight*(prevPoint.y-Y0)/chartY;
        x = chWidth*(pt.x-X0)/chartX;
        y = chHeight*(pt.y-Y0)/chartY;
        g.DrawLine(Pens.Black, x0, y0, x, y);
        g.FillEllipse(new SolidBrush(pt.clr),
          x0-5, y0-5, 10, 10);
        g.FillEllipse(new SolidBrush(pt.clr),
          x-5, y-5, 10, 10);
        prevPoint = pt;
      }
      curBitmap.Save(curPage.Response.OutputStream, 
        ImageFormat.Jpeg);
    }   
  }

}


