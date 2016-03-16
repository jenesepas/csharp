using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Text;

namespace FontCollectionSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button button2;
		
		private Color textColor;
		private int textSize;

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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(8, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(152, 24);
			this.comboBox1.TabIndex = 0;
			
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Available Fonts";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(184, 32);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(48, 24);
			this.numericUpDown1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(184, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "Size";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(240, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 6;
			this.button1.Text = "Color";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(8, 96);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(480, 304);
			this.richTextBox1.TabIndex = 7;
			this.richTextBox1.Text = "richTextBox1";
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.button2.Location = new System.Drawing.Point(408, 32);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 32);
			this.button2.TabIndex = 8;
			this.button2.Text = "Apply";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
			this.BackColor = System.Drawing.Color.Teal;
			this.ClientSize = new System.Drawing.Size(496, 413);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.button2,
																																	this.richTextBox1,
																																	this.button1,
																																	this.label2,
																																	this.numericUpDown1,
																																	this.label1,
																																	this.comboBox1});
			this.Font = new System.Drawing.Font("Tahoma", 10F);
			this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Name = "Form1";
			this.Text = "A Simple Text Editor";
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

		private void button1_Click(object sender, 
      System.EventArgs e)
    {
      // Create a Color dialog and let
      // the user select a color 
      // Save the selected color
      ColorDialog colorDlg = new ColorDialog();
      if(colorDlg.ShowDialog() == DialogResult.OK)
      {
        textColor = colorDlg.Color;
      }
    }

    private void button2_Click(object sender,
      System.EventArgs e)
    {
      // Get the size of text from 
      // numeric up down control
      textSize = (int)numericUpDown1.Value;
      // Get current font name from the list
      string selFont = comboBox1.Text;
      // Create a new font from the current selection
      Font textFont = new Font(selFont, textSize);
      // Set color and font of richtext box
      richTextBox1.ForeColor = textColor;
      richTextBox1.Font = textFont;
    }

		private void Form1_Load(object sender, 
      System.EventArgs e)
    {
      numericUpDown1.Value = 10;
      // Create InstalledFontCollection object
      InstalledFontCollection 
        sysFontCollection = 
        new InstalledFontCollection();
      // Get the array of FontFamily objects.
      FontFamily[] fontFamilies = 
        sysFontCollection.Families;
      // Read all font familes and 
      // add to the combo box
      foreach (FontFamily ff in fontFamilies)
      {
        comboBox1.Items.Add(ff.Name);
      }     
      comboBox1.Text = fontFamilies[0].Name;
    }

	}
}
