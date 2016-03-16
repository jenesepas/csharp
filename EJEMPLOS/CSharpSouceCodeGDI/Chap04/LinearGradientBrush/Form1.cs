using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace LinearGradientBrushSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button StartClrBtn;
		private System.Windows.Forms.Button EndClrBtn;
		private System.Windows.Forms.Button ApplyBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private LinearGradientBrush lgBrush = null;
		private LinearGradientMode mode = 
			new LinearGradientMode(); 
		private Color startColor = Color.Red;
		private Color endColor = Color.Green;

		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Button button1;
	

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
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.StartClrBtn = new System.Windows.Forms.Button();
			this.EndClrBtn = new System.Windows.Forms.Button();
			this.ApplyBtn = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Linear Gradient Mode:";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(136, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(152, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Text = "comboBox1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Starting Color:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 80);
			this.label3.Name = "label3";
			this.label3.TabIndex = 3;
			this.label3.Text = "Ending Color:";
			// 
			// textBox1
			// 
			this.textBox1.AutoSize = false;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(120, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(32, 24);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.AutoSize = false;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(120, 80);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(32, 24);
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "";
			// 
			// StartClrBtn
			// 
			this.StartClrBtn.Location = new System.Drawing.Point(168, 48);
			this.StartClrBtn.Name = "StartClrBtn";
			this.StartClrBtn.Size = new System.Drawing.Size(56, 24);
			this.StartClrBtn.TabIndex = 6;
			this.StartClrBtn.Text = "Pick...";
			this.StartClrBtn.Click += new System.EventHandler(this.StartClrBtn_Click);
			// 
			// EndClrBtn
			// 
			this.EndClrBtn.Location = new System.Drawing.Point(168, 80);
			this.EndClrBtn.Name = "EndClrBtn";
			this.EndClrBtn.Size = new System.Drawing.Size(56, 23);
			this.EndClrBtn.TabIndex = 7;
			this.EndClrBtn.Text = "Pick...";
			this.EndClrBtn.Click += new System.EventHandler(this.EndClrBtn_Click);
			// 
			// ApplyBtn
			// 
			this.ApplyBtn.Location = new System.Drawing.Point(248, 72);
			this.ApplyBtn.Name = "ApplyBtn";
			this.ApplyBtn.Size = new System.Drawing.Size(104, 32);
			this.ApplyBtn.TabIndex = 8;
			this.ApplyBtn.Text = "Apply Settings";
			this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(312, 8);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(136, 24);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "Other Rectangle";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(312, 40);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(136, 24);
			this.checkBox2.TabIndex = 10;
			this.checkBox2.Text = "Gamma Correction";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(376, 72);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 11;
			this.button1.Text = "Properties";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 389);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.button1,
																																	this.checkBox2,
																																	this.checkBox1,
																																	this.ApplyBtn,
																																	this.EndClrBtn,
																																	this.StartClrBtn,
																																	this.textBox2,
																																	this.textBox1,
																																	this.label3,
																																	this.label2,
																																	this.comboBox1,
																																	this.label1});
			this.Name = "Form1";
			this.Text = "Linear Gradient Brush";
			this.Load += new System.EventHandler(this.Form1_Load);
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

	  private void StartClrBtn_Click(object sender,
      System.EventArgs e)
    {
      // Use Color dialog to select a color
      ColorDialog clrDlg = new ColorDialog();
      if (clrDlg.ShowDialog() == DialogResult.OK)
      {
        // Save color as foreground color
        // fill text box as this color
        startColor = clrDlg.Color;
        textBox1.BackColor = startColor;
      }       
    }

    private void EndClrBtn_Click(object sender,
      System.EventArgs e)
    {
      // Use Color dialog to select a color
      ColorDialog clrDlg = new ColorDialog();
      if (clrDlg.ShowDialog() == DialogResult.OK)
      {
        // Save color as background color
        // fill text box as this color
        endColor = clrDlg.Color;
        textBox2.BackColor = endColor;
      }       
    }

	  private void ApplyBtn_Click(object sender,
      System.EventArgs e)
    {
      Graphics g = this.CreateGraphics(); 
      g.Clear(this.BackColor);
      // Read curretnt style from combo box
      string str = comboBox1.Text;
      // Find out the mode and set it as the 
      // current mode
      switch(str)   
      {         
        case "BackwardDiagonal":   
          mode = LinearGradientMode.BackwardDiagonal; 
          break;
        case "ForwardDiagonal":   
        mode = LinearGradientMode.ForwardDiagonal; 
          break;
        case "Horizontal":      
          mode = LinearGradientMode.Horizontal; 
          break;
        case "Vertical":
          mode = LinearGradientMode.Vertical; 
          break;
      default:            
          break;      
      }
      // Create a rectangle
      Rectangle rect = new Rectangle(50, 140, 200, 220);
    
      // Create linear gradient brush and set mode
      if(checkBox1.Checked)
      {
        Rectangle rect1 = new Rectangle(20, 20, 50, 50);
        lgBrush = new LinearGradientBrush
          (rect1, startColor, endColor, mode);  
      }
      else
      {
        lgBrush = new LinearGradientBrush
          (rect, startColor, endColor, mode);  
      }
      // Gamma correction check box is checked
      if(checkBox1.Checked)
      {
        lgBrush.GammaCorrection = true;
      }
      
      // Fill rectangle
      g.FillRectangle(lgBrush, rect);       
      // Dispose
      lgBrush.Dispose();
      g.Dispose();
    }

		private void Form1_Load(object sender,
			System.EventArgs e)
		{
			AddGradientMode();
			textBox1.BackColor = startColor;
			textBox2.BackColor = endColor;			
		}
		private void AddGradientMode()
		{
			// Adds linear gradient mode styles to the 
			// combo box
			comboBox1.Items.Add(
				LinearGradientMode.BackwardDiagonal);
			comboBox1.Items.Add(
				LinearGradientMode.ForwardDiagonal);
			comboBox1.Items.Add(LinearGradientMode.Horizontal);
			comboBox1.Items.Add(LinearGradientMode.Vertical);		
			comboBox1.Text = 
				LinearGradientMode.BackwardDiagonal.ToString();
		}

		private void button1_Click(object sender,
      System.EventArgs e)
    {
      Graphics g = this.CreateGraphics();
      // Create points
      Point pt1 = new Point(40, 30);
      Point pt2 = new Point(80, 100);
      Color [] lnColors = {Color.Black, Color.Red};
      // Create a linear gradient brush 
      LinearGradientBrush lgBrush = new LinearGradientBrush
        (pt1, pt2, Color.Red, Color.Green);  
      // Set linear colors and gamma correction
      lgBrush.LinearColors = lnColors;
      lgBrush.GammaCorrection = true;
      // Draw rectangle
      g.FillRectangle(lgBrush, 50, 140, 200, 200); 
      // Dispose
      lgBrush.Dispose();
      g.Dispose();
    }
	}
}

