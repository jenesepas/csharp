using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OwnerDrawListBox
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		private string [] textArray = null;
		private int [] sizeArray = null;
		private Color [] colorArray = null;
		private Color [] backColorArray = null;

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
							"Black Item",
							"Blue Item",
							"Red Item",							
							"Green Item",
							"Yellow Item",
							
						};

			colorArray = new Color[5]
						{
							Color.Black,
							Color.Blue,
							Color.Red,
							Color.Green,
							Color.Yellow,							
						};

			backColorArray = new Color[5]
						{
							Color.Gray,
							Color.LightCyan,
							Color.LightPink,
							Color.Yellow,
							Color.Black,							
			};

			sizeArray = new int[5]
				{
					12, 14, 16, 18, 20
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
			this.listBox1.Location = new System.Drawing.Point(8, 8);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(432, 329);
			this.listBox1.TabIndex = 0;
			this.listBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListBoxMeasureItem);
			this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxDrawItem);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 349);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listBox1});
			this.Name = "Form1";
			this.Text = "Owner Draw ListBox";
			this.ResumeLayout(false);

		}
		#endregion

		private void ListBoxDrawItem(object sender, 
			DrawItemEventArgs e)
		{
			
			e.DrawFocusRectangle();
			e.DrawBackground();
			// Uncomment this code to set the background
			// color of items
			/*
			e.Graphics.FillRectangle(
				new SolidBrush(backColorArray[e.Index]), 
				new Rectangle (e.Bounds.Left, e.Bounds.Top,
				e.Bounds.Right, e.Bounds.Bottom) );
			*/

			e.Graphics.DrawString(textArray[e.Index], 
				new Font(FontFamily.GenericSansSerif,
				sizeArray[e.Index], FontStyle.Bold),
				new SolidBrush(colorArray[e.Index]),
				e.Bounds); 
			
		}

		private void ListBoxMeasureItem(object sender,
			MeasureItemEventArgs e)
		{
			e.ItemHeight= 24;
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



