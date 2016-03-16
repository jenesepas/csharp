using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DrawPieChartApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button ColorBtn;
		private System.Windows.Forms.Button AddSliceBtn;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button DrawChartBtn;
		private System.Windows.Forms.Button FillChartBtn;

		// user defined variables
		private Rectangle rect = 
			new Rectangle(250, 150, 200, 200);
		public ArrayList sliceList = new ArrayList();
		struct sliceData 
		{
			public int share;
			public Color clr;
		};
		private Color curClr = Color.Black;
		int shareTotal = 0;

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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.ColorBtn = new System.Windows.Forms.Button();
			this.AddSliceBtn = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.DrawChartBtn = new System.Windows.Forms.Button();
			this.FillChartBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// ColorBtn
			// 
			this.ColorBtn.BackColor = System.Drawing.Color.Blue;
			this.ColorBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ColorBtn.Location = new System.Drawing.Point(96, 8);
			this.ColorBtn.Name = "ColorBtn";
			this.ColorBtn.Size = new System.Drawing.Size(88, 24);
			this.ColorBtn.TabIndex = 1;
			this.ColorBtn.Text = "Select Color";
			this.ColorBtn.Click += new System.EventHandler(this.ColorBtn_Click);
			// 
			// AddSliceBtn
			// 
			this.AddSliceBtn.Location = new System.Drawing.Point(216, 8);
			this.AddSliceBtn.Name = "AddSliceBtn";
			this.AddSliceBtn.Size = new System.Drawing.Size(88, 24);
			this.AddSliceBtn.TabIndex = 2;
			this.AddSliceBtn.Text = "Add Slice";
			this.AddSliceBtn.Click += new System.EventHandler(this.AddSliceBtn_Click);
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(8, 56);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(200, 199);
			this.listBox1.TabIndex = 3;
			// 
			// DrawChartBtn
			// 
			this.DrawChartBtn.Location = new System.Drawing.Point(8, 280);
			this.DrawChartBtn.Name = "DrawChartBtn";
			this.DrawChartBtn.Size = new System.Drawing.Size(80, 24);
			this.DrawChartBtn.TabIndex = 4;
			this.DrawChartBtn.Text = "Draw Chart";
			this.DrawChartBtn.Click += new System.EventHandler(this.DrawChartBtn_Click);
			// 
			// FillChartBtn
			// 
			this.FillChartBtn.Location = new System.Drawing.Point(104, 280);
			this.FillChartBtn.Name = "FillChartBtn";
			this.FillChartBtn.TabIndex = 5;
			this.FillChartBtn.Text = "Fill Chart";
			this.FillChartBtn.Click += new System.EventHandler(this.FillChartBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 381);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.FillChartBtn,
																		  this.DrawChartBtn,
																		  this.listBox1,
																		  this.AddSliceBtn,
																		  this.ColorBtn,
																		  this.textBox1});
			this.Name = "Form1";
			this.Text = "Pie Chart Application";
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

		private void ColorBtn_Click(object sender, System.EventArgs e)
		{
			ColorDialog clrDlg = new ColorDialog();
			if (clrDlg.ShowDialog() == DialogResult.OK)
			{
				curClr = clrDlg.Color;
			}

		}

		private void AddSliceBtn_Click(object sender, System.EventArgs e)
		{
			int slice = Convert.ToInt32(textBox1.Text);
			shareTotal += slice;
			sliceData dt;
			dt.clr = curClr;
			dt.share = slice;
			sliceList.Add(dt);
			listBox1.Items.Add(
				"Share:"+slice.ToString()+" ," + curClr.ToString() );

		}

		private void DrawChartBtn_Click(object sender, System.EventArgs e)
		{
		 DrawPieChart(false);
		}

		private void FillChartBtn_Click(object sender, System.EventArgs e)
		{
			 DrawPieChart(true);
		}

		private void DrawPieChart(bool flMode)
		{
			Graphics g = this.CreateGraphics(); 
			g.Clear(this.BackColor);
			Rectangle rect = new Rectangle(250, 150, 200, 200);
			float angle = 0; 
			float sweep = 0; 		
			foreach(sliceData dt in sliceList) 
			{
				sweep = 360f * dt.share / shareTotal;
				if(flMode)
					g.FillPie(new SolidBrush(dt.clr), rect, angle, sweep);
				else 
					g.DrawPie(new Pen(dt.clr), rect, angle, sweep);
				angle += sweep;
			}
			g.Dispose();
		}

	}
}
