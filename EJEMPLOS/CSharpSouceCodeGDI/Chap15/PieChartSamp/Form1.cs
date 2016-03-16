using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PieChartSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button DraPie;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button AddSliceBtn;
		private System.Windows.Forms.Button ColorBtn;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button FillChart;


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
		private System.Windows.Forms.Label label1;
	

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
			this.DraPie = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.AddSliceBtn = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.ColorBtn = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.FillChart = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// DraPie
			// 
			this.DraPie.Location = new System.Drawing.Point(24, 320);
			this.DraPie.Name = "DraPie";
			this.DraPie.Size = new System.Drawing.Size(88, 32);
			this.DraPie.TabIndex = 0;
			this.DraPie.Text = "Draw Chart";
			this.DraPie.Click += new System.EventHandler(this.DraPie_Click);
			// 
			// textBox1
			// 
			this.textBox1.AutoSize = false;
			this.textBox1.Location = new System.Drawing.Point(16, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 24);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "";
			// 
			// AddSliceBtn
			// 
			this.AddSliceBtn.Location = new System.Drawing.Point(264, 24);
			this.AddSliceBtn.Name = "AddSliceBtn";
			this.AddSliceBtn.Size = new System.Drawing.Size(88, 24);
			this.AddSliceBtn.TabIndex = 3;
			this.AddSliceBtn.Text = "Add Slice";
			this.AddSliceBtn.Click += new System.EventHandler(this.button1_Click);
			// 
			// ColorBtn
			// 
			this.ColorBtn.BackColor = System.Drawing.Color.Blue;
			this.ColorBtn.ForeColor = System.Drawing.Color.Yellow;
			this.ColorBtn.Location = new System.Drawing.Point(96, 24);
			this.ColorBtn.Name = "ColorBtn";
			this.ColorBtn.Size = new System.Drawing.Size(88, 24);
			this.ColorBtn.TabIndex = 4;
			this.ColorBtn.Text = "Select Color";
			this.ColorBtn.Click += new System.EventHandler(this.ColorBtn_Click);
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(16, 72);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(224, 225);
			this.listBox1.TabIndex = 5;
			// 
			// FillChart
			// 
			this.FillChart.Location = new System.Drawing.Point(136, 320);
			this.FillChart.Name = "FillChart";
			this.FillChart.Size = new System.Drawing.Size(88, 32);
			this.FillChart.TabIndex = 6;
			this.FillChart.Text = "Fill Chart";
			this.FillChart.Click += new System.EventHandler(this.FillChart_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Enter Share";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 373);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.label1,
																																	this.FillChart,
																																	this.listBox1,
																																	this.ColorBtn,
																																	this.AddSliceBtn,
																																	this.textBox1,
																																	this.DraPie});
			this.Name = "Form1";
			this.Text = "Pie Chart Application";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
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

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		private void DraPie_Click(object sender, System.EventArgs e)
		{
				DrawPieChart(false);
		}

		private void button1_Click(object sender, System.EventArgs e)
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

		private void ColorBtn_Click(object sender, System.EventArgs e)
		{
			ColorDialog clrDlg = new ColorDialog();
			if (clrDlg.ShowDialog() == DialogResult.OK)
			{
				curClr = clrDlg.Color;
			}
		}

		private void FillChart_Click(object sender, System.EventArgs e)
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
