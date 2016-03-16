using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SystemPensBrushesSamp
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
			this.ClientSize = new System.Drawing.Size(416, 285);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

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

		private void Form1_Paint(object sender,
            System.Windows.Forms.PaintEventArgs e)
        {       
            Graphics g = e.Graphics;
            // AVOID 
            /*SolidBrush brush = 
                (SolidBrush)SystemBrushes.FromSystemColor
                (SystemColors.ActiveCaption);
             Pen pn = SystemPens.FromSystemColor
                 (SystemColors.ControlDarkDark);
                 */
            SolidBrush brush = 
                (SolidBrush)SystemBrushes.ActiveCaption;
            Pen pn = SystemPens.ControlDarkDark;
            g.DrawLine(pn, 20, 20, 20, 100);
            g.DrawLine(pn, 20, 20, 100, 20);
            g.FillRectangle(brush, 30, 30, 50, 50);
            // DON'T
            //pn.Dispose();
            //brush.Dispose();
        }
	}
}
