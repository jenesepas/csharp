using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OnPaintMethodSamp
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

	
		protected override void OnPaint( PaintEventArgs args )
		{
			// Add your drawing code here
			Graphics g = args.Graphics;
			g.DrawRectangle(new Pen(Color.Blue, 3),
				new Rectangle(10, 10, 50, 50));
			g.FillEllipse(Brushes.Red, 
				new Rectangle(60, 60, 100, 100));
			g.DrawString("Text", new Font("Verdana", 14), 
				new SolidBrush(Color.Green), 200, 200) ;			
		}
		


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

		
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(280, 128);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 128);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(280, 144);
			this.dataGrid1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.dataGrid1,
																																	this.button1});
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		static void Main() 
		{
			Application.Run(new Form1());
		}

	

	}

	


}
