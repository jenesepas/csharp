using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AnimatorSamp
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

		private Bitmap img; 
		bool currentlyAnimating = false;
		


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
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 349);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

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

		public void AnimateImage() 
		{
			if (!currentlyAnimating) 
			{
				ImageAnimator.Animate(img, 
					new EventHandler(this.OnFrameChanged));
				currentlyAnimating = true;
			}
		
		}
		private void OnFrameChanged(object o, EventArgs e) 
		{
			this.Invalidate();
		}
		protected override void OnPaint(PaintEventArgs e) 
		{
			AnimateImage();
			ImageAnimator.UpdateFrames();
			e.Graphics.DrawImage(this.img, new Point(0, 0));
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			 img = new Bitmap("C:\\Devex1.gif");
		}
		

	}
}
