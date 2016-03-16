using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PaintEventSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid dataGrid1;
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
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(248, 144);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.TheButtonPaintEventHandler);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 144);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(304, 136);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.TheDataGridPaintEventHandler);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 285);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.dataGrid1,
																																	this.button1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyPaintEventHandler);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

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

				private void MyPaintEventHandler(object sender, 
				System.Windows.Forms.PaintEventArgs args)
			{
				// Drawing a rectangle
				args.Graphics.DrawRectangle(
					new Pen(Color.Blue, 3),
					new Rectangle(10, 10, 50, 50));
				// Drawing an ellipse
				args.Graphics.FillEllipse(
					Brushes.Red, 
					new Rectangle(60, 60, 100, 100));
				// Drawing text
				args.Graphics.DrawString(
					"Text", 
					new Font("Verdana", 14), 
					new SolidBrush(Color.Green), 200, 200) ;
			}
		
		private void TheButtonPaintEventHandler(object sender, 
			System.Windows.Forms.PaintEventArgs btnArgs)
		{
			btnArgs.Graphics.FillEllipse(
				Brushes.Blue, 
				10, 10, 100, 100);
		}

		private void TheDataGridPaintEventHandler(object sender,
			System.Windows.Forms.PaintEventArgs dtGridArgs)
		{
			dtGridArgs.Graphics.FillEllipse(
				Brushes.Blue, 
				10, 10, 100, 100);
		}	
	}
}






