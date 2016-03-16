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

namespace GDIPainterSamp
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox lstAction;
		protected System.Web.UI.WebControls.ListBox lstColor;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.ImageButton ibtnCanvas;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				ibtnCanvas.ImageUrl = "PaintImage.aspx";
				lstColor.DataSource = System.Enum.GetValues( GetType( KnownColor ) );
				lstColor.SelectedIndex = 0;
				lstAction.SelectedIndex = 0;
				DataBind();
			}
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
