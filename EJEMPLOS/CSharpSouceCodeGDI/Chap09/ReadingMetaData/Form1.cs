using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace ReadingMetaData
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
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 293);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

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
			// Create a bitmap from a file
			Graphics g = this.CreateGraphics();
			Image curImage = Image.FromFile("roses.jpg");
			Rectangle rect = new Rectangle(20, 20, 100, 100);
			g.DrawImage(curImage, rect);
			// Create an array of PropertyItem and read 
			// items using PropertyItems 
			PropertyItem[] propItems = curImage.PropertyItems; 
			// Create values of PropertyItem members
			foreach (PropertyItem propItem in propItems)
			{
				System.Text.ASCIIEncoding encoder = 
					new System.Text.ASCIIEncoding();
				string str = "ID ="+propItem.Id.ToString("x");
				str += ", Type ="+ propItem.Type.ToString(); 
				str += ", Length = "+ propItem.Len.ToString(); 
				str += ", Value =" 
					+ encoder.GetString(propItem.Value); 
				MessageBox.Show(str);
			}
			// Dispose
			g.Dispose();
		}
	}
}


