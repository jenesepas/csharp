using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace PenTypesSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button DrawBtn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button ColorBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Color penColor = Color.Red;
		int penWidth = 5;

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
			this.label1 = new System.Windows.Forms.Label();
			this.DrawBtn = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.ColorBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(104, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Pen Alignment:";
			// 
			// DrawBtn
			// 
			this.DrawBtn.Location = new System.Drawing.Point(40, 88);
			this.DrawBtn.Name = "DrawBtn";
			this.DrawBtn.Size = new System.Drawing.Size(112, 32);
			this.DrawBtn.TabIndex = 4;
			this.DrawBtn.Text = "Draw Graphics";
			this.DrawBtn.Click += new System.EventHandler(this.DrawBtn_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Pen Width:";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(96, 40);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(32, 20);
			this.numericUpDown1.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(144, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Pen Color:";
			// 
			// ColorBtn
			// 
			this.ColorBtn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ColorBtn.Location = new System.Drawing.Point(208, 48);
			this.ColorBtn.Name = "ColorBtn";
			this.ColorBtn.Size = new System.Drawing.Size(24, 16);
			this.ColorBtn.TabIndex = 8;
			this.ColorBtn.Click += new System.EventHandler(this.ColorBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(360, 349);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.ColorBtn,
																																	this.label4,
																																	this.numericUpDown1,
																																	this.label3,
																																	this.DrawBtn,
																																	this.label1,
																																	this.comboBox1});
			this.Name = "Form1";
			this.Text = "Pen Alignment and Pen Types Sample";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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

		private void Form1_Load(object sender,
      System.EventArgs e)
    {
      AddPenAlignments();   
    }
    
    private void AddPenAlignments()
    {
      // Add pen alignment 
      comboBox1.Items.Add(PenAlignment.Center);
      comboBox1.Text = 
        PenAlignment.Center.ToString();
      comboBox1.Items.Add(PenAlignment.Inset);
      comboBox1.Items.Add(PenAlignment.Left);
      comboBox1.Items.Add(PenAlignment.Outset);
      comboBox1.Items.Add(PenAlignment.Right);
    }

		private void DrawBtn_Click(object sender, 
      System.EventArgs e)
    {
      // Create a Graphics object and set it clear
      Graphics g = this.CreateGraphics(); 
      g.Clear(this.BackColor);
      // Create a solid and hatch brush
      Pen pn1 = new Pen(Color.Blue, 3);
      pn1.Width = (float)numericUpDown1.Value;
      pn1.Color = ColorBtn.BackColor;
      // Find out current pen alignment
      string str = comboBox1.Text;
      switch(str)   
      {         
        case "Center":   
          pn1.Alignment = PenAlignment.Center; 
          break;
        case "Inset":   
          pn1.Alignment = PenAlignment.Inset; 
          break;
        case "Left":      
          pn1.Alignment = PenAlignment.Left; 
          break;
        case "Outset":
          pn1.Alignment = PenAlignment.Outset; 
          break;
        case "Right":
          pn1.Alignment = PenAlignment.Right; 
          break;
        default:            
          break;      
      }
      // Create a pen from a hatch brush
      // Draw a rectangle
      g.DrawRectangle(pn1, 80, 150, 150, 150);
      // Create a brush
      LinearGradientBrush brush = 
        new LinearGradientBrush(
        new Rectangle(10, 10, 20, 20), Color.Blue, 
        Color.Green, 45.0f);
      g.FillRectangle(brush, 90, 160, 130, 130);
      // Dispose
      pn1.Dispose();
      g.Dispose();
    }

		private void ColorBtn_Click(object sender,
      System.EventArgs e)
    {
      // Use Color dialog to select a color
      ColorDialog clrDlg = new ColorDialog();
      if (clrDlg.ShowDialog() == DialogResult.OK)
      {
        // Save color as background color
        // fill text box as this color
        penColor = clrDlg.Color;
        ColorBtn.BackColor = penColor;
      }       
    }
	}
}
