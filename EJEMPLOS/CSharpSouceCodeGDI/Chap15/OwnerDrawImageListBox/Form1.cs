using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OwnerDrawImageListBox
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		private Image [] imgArray = null;
		private string [] textArray = null;

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

			textArray = new String[5]
					{
						"Black Item", "Blue Item",
						"Red Item", "Green Item",
						"Yellow Item",
					};

			imgArray = new Image[5]
				{
					Image.FromFile("Img1.jpg"),
					Image.FromFile("Img2.jpg"),
					Image.FromFile("Img3.jpg"),
					Image.FromFile("Img4.jpg"),
					Image.FromFile("Img5.jpg")
				};

			// Bind text array to ListBox
			listBox1.DataSource = textArray;




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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.listBox1.Location = new System.Drawing.Point(0, 8);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(328, 440);
			this.listBox1.TabIndex = 0;
			this.listBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListBoxMeasureItem);
			this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxDrawItem);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 453);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listBox1});
			this.Name = "Form1";
			this.Text = "Owner Draw Image ListBox";
			this.ResumeLayout(false);

		}
		#endregion


		private void ListBoxDrawItem(object sender, 
			DrawItemEventArgs e)
		{
			SizeF curImgSize = 
				imgArray[e.Index].PhysicalDimension;
			e.Graphics.DrawImage(imgArray[e.Index], 
				e.Bounds.X+5 , 
				( e.Bounds.Bottom + e.Bounds.Top ) /2 
					- curImgSize.Height/2);
		}

		private void ListBoxMeasureItem(object sender,
			MeasureItemEventArgs e)
		{
			e.ItemHeight= 150;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}


