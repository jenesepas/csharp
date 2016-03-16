using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace HatchBrushSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button ApplyBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button ForeColorBtn;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;

		private HatchStyle style = new HatchStyle();
		private Color forClr = Color.Blue;
		private Color backClr = Color.Red;

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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.ApplyBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ForeColorBtn = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(112, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(144, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.Text = "comboBox1";
			// 
			// ApplyBtn
			// 
			this.ApplyBtn.Location = new System.Drawing.Point(272, 64);
			this.ApplyBtn.Name = "ApplyBtn";
			this.ApplyBtn.Size = new System.Drawing.Size(96, 24);
			this.ApplyBtn.TabIndex = 1;
			this.ApplyBtn.Text = "Apply Style";
			this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Select Style:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 32);
			this.label2.TabIndex = 3;
			this.label2.Text = "Foreground Color:";
			// 
			// ForeColorBtn
			// 
			this.ForeColorBtn.Location = new System.Drawing.Point(208, 40);
			this.ForeColorBtn.Name = "ForeColorBtn";
			this.ForeColorBtn.Size = new System.Drawing.Size(48, 24);
			this.ForeColorBtn.TabIndex = 4;
			this.ForeColorBtn.Text = "Pick...";
			this.ForeColorBtn.Click += new System.EventHandler(this.ForeColorBtn_Click);
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(144, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(32, 20);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(144, 64);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(32, 20);
			this.textBox2.TabIndex = 8;
			this.textBox2.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(208, 64);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(48, 24);
			this.button1.TabIndex = 7;
			this.button1.Text = "Pick...";
			this.button1.Click += new System.EventHandler(this.BackColorBtn_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 32);
			this.label3.TabIndex = 6;
			this.label3.Text = "Background Color:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.textBox2,
																																	this.button1,
																																	this.label3,
																																	this.textBox1,
																																	this.ForeColorBtn,
																																	this.label2,
																																	this.label1,
																																	this.ApplyBtn,
																																	this.comboBox1});
			this.Name = "Form1";
			this.Text = "Hatch Brushes";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void Form1_Paint(object sender, 
			System.Windows.Forms.PaintEventArgs e)
		{
		}

		private void Form1_Load(object sender,
      System.EventArgs e)
    {
      // Fill combo box with hatch styles
      FillHatchStyles();
      // Set foreground and background color
      // text boxes's backgrond color
      textBox1.BackColor = forClr;        
      textBox2.BackColor = backClr;
    }
		private void FillHatchStyles()
    {
      // Add hatch styles
      comboBox1.Items.Add(
        HatchStyle.BackwardDiagonal.ToString());
      comboBox1.Items.Add(
        HatchStyle.Cross.ToString());
      comboBox1.Items.Add(
        HatchStyle.DashedVertical.ToString());
      comboBox1.Items.Add(
        HatchStyle.DiagonalCross.ToString());
      comboBox1.Items.Add(
        HatchStyle.HorizontalBrick.ToString());
      comboBox1.Items.Add(
        HatchStyle.LightDownwardDiagonal.ToString());
      comboBox1.Items.Add(
        HatchStyle.LightUpwardDiagonal.ToString());
      comboBox1.Text = 
        HatchStyle.BackwardDiagonal.ToString();
    }

		private void ApplyBtn_Click(object sender,
      System.EventArgs e)
    {
      // Create a Graphics object
      Graphics g = this.CreateGraphics();
      g.Clear(this.BackColor);
      // Read curretnt style from combo box
      string str = comboBox1.Text;
      // Find out the style and set it as the 
      // current style
      switch(str)   
      {         
        case "BackwardDiagonal":   
          style = HatchStyle.BackwardDiagonal;
          break;
        case "DashedVertical":   
          style = HatchStyle.DashedVertical;
          break;
        case "Cross":      
          style = HatchStyle.Cross;
          break;
        case "DiagonalCross":
          style = HatchStyle.DiagonalCross;
          break;
        case "HorizontalBrick":
          style = HatchStyle.HorizontalBrick;
          break;
        case "LightDownwardDiagonal":
          style = HatchStyle.LightDownwardDiagonal;
          break;
        case "LightUpwardDiagonal":
          style = HatchStyle.LightUpwardDiagonal;
          break;
        default:            
          break;      
      }
      // Create a hatch brush with selected 
      // hatch style and colors
      HatchBrush brush = 
          new HatchBrush(style, forClr, backClr);
      // fill rectangle
      g.FillRectangle(brush, 50, 100, 200, 200);
      // Dispose
      brush.Dispose();
      g.Dispose();
    }

		private void ForeColorBtn_Click(object sender,
      System.EventArgs e)
    {
      // Use Color dialog to select a color
      ColorDialog clrDlg = new ColorDialog();
      if (clrDlg.ShowDialog() == DialogResult.OK)
      {
        // Save color as foreground color
        // fill text box as this color
        forClr = clrDlg.Color;
        textBox1.BackColor = forClr;
      }   
    }

    private void BackColorBtn_Click(object sender, 
      System.EventArgs e)
    {
      // Use Color dialog to select a color
      ColorDialog clrDlg = new ColorDialog();
      if (clrDlg.ShowDialog() == DialogResult.OK)
      {
        // Save color as background color
        // fill text box as this color
        backClr = clrDlg.Color;
        textBox2.BackColor = backClr;
      }   
    }
	}
}
