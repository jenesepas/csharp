using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListingA5
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button TestExpBtn;
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
			this.TestExpBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TestExpBtn
			// 
			this.TestExpBtn.Location = new System.Drawing.Point(16, 8);
			this.TestExpBtn.Name = "TestExpBtn";
			this.TestExpBtn.Size = new System.Drawing.Size(128, 32);
			this.TestExpBtn.TabIndex = 0;
			this.TestExpBtn.Text = "Test Exception";
			this.TestExpBtn.Click += new System.EventHandler(this.TestExpBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 341);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.TestExpBtn});
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void TestExpBtn_Click(object sender, 
			System.EventArgs e)
		{
			
			// Create a Graphics object
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			// Create pens and brushes
			Pen redPen = new Pen(Color.Red, 1);
			Pen bluePen = new Pen(Color.Blue, 2);
			Pen greenPen = new Pen(Color.Green, 3);
			SolidBrush greenBrush =
				new SolidBrush(Color.Green);

			// Put whatever code do you think may cause
			// the error within this block
			try
			{
				// Using Point structure to draw lines
				Point pt1 = new Point(30, 40);
				Point pt2 = new Point(250, 60);
				g.DrawLine(redPen, pt1, pt2);
				// Draw Rectangle
				Rectangle rect = 
					new Rectangle(20,20, 80, 40); 
				g.DrawRectangle(bluePen, rect);

				// Create points for curve.
				PointF p1 = new PointF(40.0F, 50.0F);
				PointF p2 = new PointF(60.0F, 70.0F);
				PointF p3 = new PointF(80.0F, 34.0F);
				PointF p4 = new PointF(120.0F, 180.0F);
				PointF p5 = new PointF(200.0F, 150.0F);
				PointF p6 = new PointF(350.0F, 250.0F);
				PointF p7 = new PointF(200.0F, 200.0F);
				PointF[] ptsArray =
				{
					// Comment the correct array
					 p1, p2, p3, p4, p5, p6, p7
					
				};
				// Draw Bezier
				g.DrawBeziers(redPen, ptsArray);
		
			}
			catch(Exception exp)
			{
				string errMsg = "Message: " + exp.Message;
				errMsg += "Source: "+ exp.Source.ToString();
				errMsg += "TargetSite: "+ exp.TargetSite;
				errMsg += "HelpLink: "
					+ exp.HelpLink.ToString();
				errMsg += "StackTrace: " 
					+ exp.StackTrace.ToString();
				MessageBox.Show(errMsg);
			}
			finally
			{
				// Release resources
				// Dispose objects
				redPen.Dispose();
				bluePen.Dispose();
				greenPen.Dispose();
				greenBrush.Dispose();
				g.Dispose();
			}

		}
	}
}



