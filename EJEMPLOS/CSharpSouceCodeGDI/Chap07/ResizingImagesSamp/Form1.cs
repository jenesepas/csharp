using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace ResizingImagesSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem OpenFileMenu;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.Button SaveImageBtn;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Image curImage;
		private string curFileName ;
		private float imgHeight;
		private System.Windows.Forms.Panel panel1;
		private float imgWidth;


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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.OpenFileMenu = new System.Windows.Forms.MenuItem();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.SaveImageBtn = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.OpenFileMenu,
																					  this.ExitMenu});
			this.menuItem1.Text = "File";
			// 
			// OpenFileMenu
			// 
			this.OpenFileMenu.Index = 0;
			this.OpenFileMenu.Text = "Open a File";
			this.OpenFileMenu.Click += new System.EventHandler(this.OpenFileMenu_Click);
			// 
			// ExitMenu
			// 
			this.ExitMenu.Index = 1;
			this.ExitMenu.Text = "Exit";
			this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
			// 
			// SaveImageBtn
			// 
			this.SaveImageBtn.Location = new System.Drawing.Point(200, 8);
			this.SaveImageBtn.Name = "SaveImageBtn";
			this.SaveImageBtn.Size = new System.Drawing.Size(104, 32);
			this.SaveImageBtn.TabIndex = 0;
			this.SaveImageBtn.Text = "Save Image ";
			this.SaveImageBtn.Click += new System.EventHandler(this.SaveImageBtn_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(88, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(64, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "New Width";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(88, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "New Height";
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label1,
																				 this.textBox2,
																				 this.label2,
																				 this.textBox1,
																				 this.SaveImageBtn});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 297);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(384, 48);
			this.panel1.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 345);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Resizing Images Sample";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.panel1.ResumeLayout(false);
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

		private void OpenFileMenu_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = "All Image files|*.bmp;*.gif;*.jpg;*.ico;"+
				"*.emf,*.wmf|Bitmap Files(*.bmp;*.gif;*.jpg;"+
				"*.ico)|*.bmp;*.gif;*.jpg;*.ico|"+
				"Meta Files(*.emf;*.wmf)|*.emf;*.wmf";
			string filter = openDlg.Filter;
			openDlg.InitialDirectory = Environment.CurrentDirectory;
			openDlg.Title = "Open Image File";
			openDlg.ShowHelp = true;
			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				curFileName = openDlg.FileName; 	
				curImage = Image.FromFile(curFileName);
				imgHeight = curImage.Height;
				imgWidth = curImage.Width;	
			}		
			Invalidate();
		}

		private void ExitMenu_Click(object sender, System.EventArgs e)
		{
		
		}

		private void SaveImageBtn_Click(object sender, System.EventArgs e)
		{
			if(curImage == null)
				return;
			int height = Convert.ToInt16(textBox1.Text);
			int width = Convert.ToInt16(textBox2.Text);

			SaveFileDialog saveDlg = new SaveFileDialog();
			saveDlg.Title = "Save Image As";
			saveDlg.OverwritePrompt = true;
			saveDlg.CheckPathExists = true;
			saveDlg.Filter = "Bitmap File(*.bmp)|*.bmp|Gif File(*.gif)|*.gif| " +
				"JPEG File(*.jpg)|*.jpg";
			saveDlg.ShowHelp = true;
			if(saveDlg.ShowDialog() == DialogResult.OK)
			{
				string fileName = saveDlg.FileName;
				string extn = 
					fileName.Substring(fileName.Length - 3, 3);
				Bitmap newImage = new Bitmap(curImage, 
					new Size(width, height));
				if(extn.Equals("bmp"))
                    newImage.Save(fileName,ImageFormat.Bmp);	
				else if(extn.Equals("gif"))
					newImage.Save(fileName,ImageFormat.Gif);
				else if(extn.Equals("jpg"))
					newImage.Save(fileName,ImageFormat.Jpeg);
			}		
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawImage(curImage, AutoScrollPosition.X, AutoScrollPosition.Y,
					curImage.Width, curImage.Height );				
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
				curImage = Image.FromFile("roses.jpg");		
		}
	}
}

	