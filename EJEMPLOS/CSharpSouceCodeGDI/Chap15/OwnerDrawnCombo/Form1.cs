using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OwnerDrawnCombo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private OwnerComboBox comboBox1;

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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			comboBox1 = new OwnerComboBox();

			this.SuspendLayout();
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {  this.comboBox1 });
			
			this.Name = "Form1";
			this.Text = "Owner Drawn ComboBox";
			this.ResumeLayout(false);



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

	public class OwnerComboBox : System.Windows.Forms.ComboBox
	{
		private Rectangle oldSelectedRect;
		private int oldSelectedIndex = -1;
		public OwnerComboBox()
		{
			InitializeComponent();
		}

		public void ComboDropDown(object sender, System.EventArgs e)
		{
			oldSelectedIndex = -1;
			oldSelectedRect.Width = 0;
		}
		public void DrawComboItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			if( oldSelectedRect != e.Bounds &&
				oldSelectedIndex > -1 && oldSelectedIndex < Items.Count)
			{
				if(oldSelectedRect.Y != 3) //!=3 is hack to handle a drawing anomally
					e.Graphics.DrawRectangle(new Pen((Color) Items[oldSelectedIndex], 1), oldSelectedRect);
			}

			if( e.Index > -1 && e.Index < Items.Count)
				e.Graphics.FillRectangle(new SolidBrush( (Color)Items[e.Index] ), e.Bounds);
					
			if(SelectedIndex == e.Index)
			{
				e.Graphics.DrawRectangle(new Pen(Color.Black,1), e.Bounds);
				oldSelectedRect = e.Bounds;
				oldSelectedIndex = e.Index;
			}
		}

		private void InitializeComponent()
		{
			oldSelectedRect.X = -1;
			oldSelectedRect.Y = -1;
			oldSelectedRect.Width = 0;
			oldSelectedRect.Height = 0;

			this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ItemHeight = 20;
			Items.AddRange(new object[] {	Color.Blue,
											Color.Red,
											Color.Green,
											Color.Aqua,
											Color.Pink,
											Color.Lavender});
											
			Location = new System.Drawing.Point(80, 100);
			Name = "comboBox1";
			Size = new System.Drawing.Size(121, 21);
			TabIndex = 1;
			this.SelectedIndex = 2;
			this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(DrawComboItem);
		}
	}
}
