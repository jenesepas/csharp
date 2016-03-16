using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FAQSamp
{
	/// <summary>
	/// Summary description for ImagePropertyForm.
	/// </summary>
	public class ImagePropertyForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;

		public float imgHeight;
		public float imgWidht;
		public short imgColorDepth;
		public string imgFormat;
		public string imgCompression;
		public string imgTransformation;
		private System.Windows.Forms.Button OkBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox3;



		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ImagePropertyForm()
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.OkBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Width:";
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(128, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(96, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(128, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(96, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Height:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Format:";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(128, 80);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(96, 21);
			this.comboBox1.TabIndex = 5;
			// 
			// textBox3
			// 
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox3.Location = new System.Drawing.Point(128, 112);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(96, 20);
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Color Depth:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Compression:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 176);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 16);
			this.label6.TabIndex = 9;
			this.label6.Text = "Transformation:";
			// 
			// OkBtn
			// 
			this.OkBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OkBtn.Location = new System.Drawing.Point(16, 336);
			this.OkBtn.Name = "OkBtn";
			this.OkBtn.Size = new System.Drawing.Size(104, 24);
			this.OkBtn.TabIndex = 10;
			this.OkBtn.Text = "Save Settings";
			this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0)));
			this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CancelBtn.Location = new System.Drawing.Point(144, 336);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(80, 24);
			this.CancelBtn.TabIndex = 11;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
			// 
			// comboBox2
			// 
			this.comboBox2.Location = new System.Drawing.Point(128, 144);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(96, 21);
			this.comboBox2.TabIndex = 12;
			// 
			// comboBox3
			// 
			this.comboBox3.Location = new System.Drawing.Point(128, 176);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(96, 21);
			this.comboBox3.TabIndex = 13;
			// 
			// ImagePropertyForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(264, 373);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.comboBox3,
																		  this.comboBox2,
																		  this.CancelBtn,
																		  this.OkBtn,
																		  this.label6,
																		  this.label5,
																		  this.textBox3,
																		  this.label4,
																		  this.comboBox1,
																		  this.label3,
																		  this.textBox2,
																		  this.label2,
																		  this.textBox1,
																		  this.label1});
			this.Font = new System.Drawing.Font("Verdana", 8F);
			this.Name = "ImagePropertyForm";
			this.Text = "ImagePropertyForm";
			this.Load += new System.EventHandler(this.ImagePropertyForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void OkBtn_Click(object sender, System.EventArgs e)
		{
			imgHeight = Convert.ToInt16(textBox2.Text.ToString());
			imgWidht = Convert.ToInt16(textBox1.Text.ToString());
			imgColorDepth = Convert.ToInt16(textBox3.Text.ToString());
			imgFormat = comboBox1.SelectedText;
			imgCompression = comboBox2.SelectedText;
			imgTransformation = comboBox3.SelectedText;			
		}

		private void CancelBtn_Click(object sender, System.EventArgs e)
		{
		
		}

		private void ImagePropertyForm_Load(object sender, System.EventArgs e)
		{
			// Add items to file types combo
			comboBox1.Items.Add("bmp");
			comboBox1.Items.Add("gif");
			comboBox1.Items.Add("tif");
			comboBox1.Items.Add("png");
			comboBox1.Items.Add("jpg");
			// Add items to compression combo
			comboBox2.Items.Add("CCITT3");
			comboBox2.Items.Add("CCITT4");
			comboBox2.Items.Add("LGW");
			comboBox2.Items.Add("None");
			comboBox2.Items.Add("Rle");
			// Adding items to transformation combo
			comboBox3.Items.Add("90");
			comboBox3.Items.Add("180");
			comboBox3.Items.Add("270");
			comboBox3.Items.Add("Flip HRZ");
			comboBox3.Items.Add("Flip VERT");
		}
	}
}
