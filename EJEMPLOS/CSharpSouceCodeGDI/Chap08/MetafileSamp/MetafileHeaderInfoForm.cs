using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MetafileSamp
{
	/// <summary>
	/// Summary description for MetafileHeaderInfoForm.
	/// </summary>
	public class MetafileHeaderInfoForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MetafileHeaderInfoForm()
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
				if(components != null)
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
			// MetafileHeaderInfoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "MetafileHeaderInfoForm";
			this.Text = "MetafileHeaderInfoForm";
			this.Load += new System.EventHandler(this.MetafileHeaderInfoForm_Load);

		}
		#endregion

		private void MetafileHeaderInfoForm_Load(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			IntPtr hdc = g.GetHdc();
			Rectangle rect = new Rectangle(20, 20, 200, 100);
			Metafile curMetafile = 
				new Metafile(hdc, EmfType.EmfPlusDual, @"f:\emfPlusDual.emf");
			Graphics g1 = Graphics.FromImage(curMetafile);
			g1.SmoothingMode = SmoothingMode.HighQuality;
			g1.FillRectangle(Brushes.Red, rect);
			rect.Y += 110;
			g1.DrawEllipse(new Pen(Brushes.Green, 3), rect); 
			g1.DrawLine(Pens.Blue, new Point(20,20), 
				new Point(400, 200) );
			//Release objects
			g.ReleaseHdc(hdc);
			g1.Dispose();
			g.Dispose();	
		}
	}
}
