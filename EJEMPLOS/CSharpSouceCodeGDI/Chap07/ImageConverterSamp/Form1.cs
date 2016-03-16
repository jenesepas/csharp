using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace ImageConverterSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button ViewImgBtn;
		private System.Windows.Forms.Button ConvertToBtn;
		private System.Windows.Forms.ComboBox SaveFormatCombo;

		private Image curImage;

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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.ViewImgBtn = new System.Windows.Forms.Button();
			this.ConvertToBtn = new System.Windows.Forms.Button();
			this.SaveFormatCombo = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(368, 328);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// ViewImgBtn
			// 
			this.ViewImgBtn.BackColor = System.Drawing.SystemColors.Desktop;
			this.ViewImgBtn.Location = new System.Drawing.Point(400, 16);
			this.ViewImgBtn.Name = "ViewImgBtn";
			this.ViewImgBtn.Size = new System.Drawing.Size(88, 24);
			this.ViewImgBtn.TabIndex = 1;
			this.ViewImgBtn.Text = "View Image";
			this.ViewImgBtn.Click += new System.EventHandler(this.ViewImgBtn_Click);
			// 
			// ConvertToBtn
			// 
			this.ConvertToBtn.BackColor = System.Drawing.SystemColors.Desktop;
			this.ConvertToBtn.Location = new System.Drawing.Point(400, 160);
			this.ConvertToBtn.Name = "ConvertToBtn";
			this.ConvertToBtn.Size = new System.Drawing.Size(96, 24);
			this.ConvertToBtn.TabIndex = 2;
			this.ConvertToBtn.Text = "Convert Now";
			this.ConvertToBtn.Click += new System.EventHandler(this.ConvertToBtn_Click);
			// 
			// SaveFormatCombo
			// 
			this.SaveFormatCombo.Items.AddRange(new object[] {
																 "bmp",
																 "jpg",
																 "wmf",
																 "gif",
																 "emf"});
			this.SaveFormatCombo.Location = new System.Drawing.Point(400, 192);
			this.SaveFormatCombo.Name = "SaveFormatCombo";
			this.SaveFormatCombo.Size = new System.Drawing.Size(96, 21);
			this.SaveFormatCombo.TabIndex = 3;
			this.SaveFormatCombo.Text = "bmp";
			this.SaveFormatCombo.SelectedIndexChanged += new System.EventHandler(this.SaveFormatCombo_SelectedIndexChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(504, 389);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.SaveFormatCombo,
																		  this.ConvertToBtn,
																		  this.ViewImgBtn,
																		  this.pictureBox1});
			this.Name = "Form1";
			this.Text = "GDI+ Image Converter";
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

		private void ViewImgBtn_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = "All Image files|*.bmp;*.gif;*.jpg;*.ico;*.emf,*.wmf|Bitmap Files(*.bmp;*.gif;*.jpg;*.ico)|*.bmp;*.gif;*.jpg;*.ico|Meta Files(*.emf;*.wmf)|*.emf;*.wmf";
			string filter = openDlg.Filter;
			openDlg.InitialDirectory = Environment.CurrentDirectory;
			openDlg.Title = "Open Image File";
			openDlg.ShowHelp = true;
			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				curImage = Image.FromFile(openDlg.FileName);
				pictureBox1.Width = curImage.Width;
				pictureBox1.Height = curImage.Height;
				pictureBox1.Image = curImage;
				pictureBox1.Visible = true;
			}
		}

		private void ConvertToBtn_Click(object sender, System.EventArgs e)
		{
			System.IO.MemoryStream imgStream = new System.IO.MemoryStream();
			ImageConverter imgConverter = new ImageConverter();
						
		}

		private void SaveFormatCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
