using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace MultipleImagesSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button SaveImgBtn;

		float tpVal = 1.0f;
		private Image curImage ;


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
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.SaveImgBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar1
			// 
			this.trackBar1.LargeChange = 1;
			this.trackBar1.Location = new System.Drawing.Point(344, 64);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.TabIndex = 0;
			this.trackBar1.Value = 1;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(352, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Transparency";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(352, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "New Width:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(448, 144);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(64, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(352, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "New Height:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(448, 176);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(64, 20);
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "";
			// 
			// SaveImgBtn
			// 
			this.SaveImgBtn.Location = new System.Drawing.Point(384, 224);
			this.SaveImgBtn.Name = "SaveImgBtn";
			this.SaveImgBtn.Size = new System.Drawing.Size(120, 32);
			this.SaveImgBtn.TabIndex = 6;
			this.SaveImgBtn.Text = "Save Image";
			this.SaveImgBtn.Click += new System.EventHandler(this.SaveImgBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 341);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.SaveImgBtn,
																		  this.textBox2,
																		  this.label3,
																		  this.textBox1,
																		  this.label2,
																		  this.label1,
																		  this.trackBar1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void Form1_Paint(object sender, 
			System.Windows.Forms.PaintEventArgs e)
		{
			// Create an Image (first image) from a file
			curImage = Image.FromFile("roses.jpg");
			// Draw first image
			e.Graphics.DrawImage(curImage,
				AutoScrollPosition.X, AutoScrollPosition.Y,
				curImage.Width, curImage.Height );		
			// Create an array of ColorMatrix points
			float[][] ptsArray =
			{ 
				new float[] {1, 0, 0, 0, 0},
				new float[] {0, 1, 0, 0, 0},
				new float[] {0, 0, 1, 0, 0},
				new float[] {0, 0, 0, tpVal, 0}, 
				new float[] {0, 0, 0, 0, 1}
			}; 
			// Create a ColorMatrix object
			ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
			// Create ImageAttributes
			ImageAttributes imgAttributes = new ImageAttributes();
			// Set ColorMatrix 
			imgAttributes.SetColorMatrix(clrMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap);
			// Create second Image object from a file
			Image smallImage = Image.FromFile("smallRoses.gif");
			// Draw second image with image attributes
			e.Graphics.DrawImage(smallImage, 
				new Rectangle(100, 100, 100, 100),
				0, 0, smallImage.Width, smallImage.Height, 
				GraphicsUnit.Pixel, imgAttributes );	
		}

		private void trackBar1_Scroll(object sender, System.EventArgs e)
		{
			tpVal = (float)trackBar1.Value/10;
			this.Invalidate();	
		}

		private void SaveImgBtn_Click(object sender, System.EventArgs e)
		{
			if(curImage == null)
				return;
			int height = Convert.ToInt16(textBox1.Text);
			int width = Convert.ToInt16(textBox2.Text);
			SaveFileDialog saveDlg = new SaveFileDialog();
			saveDlg.Title = "Save Image As";
			saveDlg.OverwritePrompt = true;
			saveDlg.CheckPathExists = true;
			saveDlg.Filter = 
				"Bitmap File(*.bmp)|*.bmp|Gif File(*.gif)|*.gif| " +
				"JPEG File(*.jpg)|*.jpg";
			saveDlg.ShowHelp = true;
			if(saveDlg.ShowDialog() == DialogResult.OK)
			{
				string fileName = saveDlg.FileName;
				Bitmap newImage = new Bitmap(curImage,
					new Size(width, height));
				newImage.Save(fileName,ImageFormat.Bmp);            
			}       
		}
	}
}


