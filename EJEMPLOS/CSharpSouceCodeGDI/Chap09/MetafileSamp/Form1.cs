using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MetafileSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem ViewFile;
		private System.Windows.Forms.MenuItem CreateMetaFile;
		private System.Windows.Forms.MenuItem EnumerateMetaFile;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem EmfTypes;
		private System.Windows.Forms.MenuItem MetafileHeaderInfo;
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.ViewFile = new System.Windows.Forms.MenuItem();
			this.CreateMetaFile = new System.Windows.Forms.MenuItem();
			this.EnumerateMetaFile = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.EmfTypes = new System.Windows.Forms.MenuItem();
			this.MetafileHeaderInfo = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ViewFile,
																					  this.CreateMetaFile,
																					  this.EnumerateMetaFile});
			this.menuItem1.Text = "Metafile";
			// 
			// ViewFile
			// 
			this.ViewFile.Index = 0;
			this.ViewFile.Text = "View";
			this.ViewFile.Click += new System.EventHandler(this.ViewFile_Click);
			// 
			// CreateMetaFile
			// 
			this.CreateMetaFile.Index = 1;
			this.CreateMetaFile.Text = "Create a MetaFile";
			this.CreateMetaFile.Click += new System.EventHandler(this.CreateMetaFile_Click);
			// 
			// EnumerateMetaFile
			// 
			this.EnumerateMetaFile.Index = 2;
			this.EnumerateMetaFile.Text = "EnumerateMetaFile";
			this.EnumerateMetaFile.Click += new System.EventHandler(this.EnumerateMetaFile_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.EmfTypes,
																					  this.MetafileHeaderInfo});
			this.menuItem2.Text = "EMF";
			// 
			// EmfTypes
			// 
			this.EmfTypes.Index = 0;
			this.EmfTypes.Text = "EmfTypes";
			this.EmfTypes.Click += new System.EventHandler(this.EmfTypes_Click);
			// 
			// MetafileHeaderInfo
			// 
			this.MetafileHeaderInfo.Index = 1;
			this.MetafileHeaderInfo.Text = "Metafile Header Info";
			this.MetafileHeaderInfo.Click += new System.EventHandler(this.MetafileHeaderInfo_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 241);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

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

		private void ViewFile_Click(object sender, System.EventArgs e)
		{
			try
			{
				Graphics g = this.CreateGraphics();
				g.Clear(this.BackColor);
				Rectangle rect = new Rectangle(0, 0, 400, 400);
				Metafile curMetafile = new Metafile(@"f:\mtfile.wmf");
				g.DrawImage(curMetafile, 0, 0) ; 			
				g.Dispose();
			}
			catch(Exception exp)
			{
				MessageBox.Show("Message: "+ exp.Message.ToString() +
					", Source: "+exp.Source.ToString() );
			}

		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
					
		}

		private void CreateMetaFile_Click(object sender, System.EventArgs e)
		{
			try
			{
				Graphics g = this.CreateGraphics();
				IntPtr hdc = g.GetHdc();
				Rectangle rect = new Rectangle(20, 20, 200, 100);
				Metafile curMetafile = new Metafile(@"f:\mtfile.wmf", hdc);
				Graphics g1 = Graphics.FromImage(curMetafile);
				g1.SmoothingMode = SmoothingMode.HighQuality;
				g1.FillRectangle(Brushes.Red, rect);
				rect.Y += 110;
				g1.DrawEllipse(new Pen(Brushes.Green, 3), rect); 
				//Release objects
				g.ReleaseHdc(hdc);
				g1.Dispose();
				g.Dispose();	
			}
			catch(Exception exp)
			{
				MessageBox.Show("Message: "+ exp.Message.ToString() +
					", Source: "+exp.Source.ToString() );
			}
		}

		private bool EnumMetaCB(EmfPlusRecordType recordType, int flags, int dataSize,
			IntPtr data, PlayRecordCallback callbackData)
		{

			string str = "";
			// Play only EmfPlusRecordType.FillEllipse records.
			if (recordType == EmfPlusRecordType.FillEllipse
				|| recordType == EmfPlusRecordType.FillRects
				|| recordType == EmfPlusRecordType.DrawEllipse
				|| recordType == EmfPlusRecordType.DrawRects )
			{
				str = "Record type:"+ recordType.ToString()+
					", Flags:"+ flags.ToString()+
					", DataSize:"+ dataSize.ToString()+
					", Data:"+data.ToString() ;
				MessageBox.Show(str);
			}
			return true;
		}

		private void EnumerateMetaFile_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.Clear(this.BackColor);
			Metafile curMetafile = new Metafile(@"f:\mtfile.wmf");
			Graphics.EnumerateMetafileProc enumMetaCB = new
				Graphics.EnumerateMetafileProc(EnumMetaCB);
			g.EnumerateMetafile(curMetafile, new Point(0, 0), enumMetaCB);
			curMetafile.Dispose();
			g.Dispose();
		
		}

		private void EmfTypes_Click(object sender, System.EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			IntPtr hdc = g.GetHdc();
			Rectangle rect = new Rectangle(20, 20, 200, 100);
			Metafile curMetafile = 
				new Metafile(hdc, EmfType.EmfPlusDual, @"f:\emfPlusDual.emf");
			Graphics g1 = Graphics.FromImage(curMetafile);
			g1.SmoothingMode = SmoothingMode.HighQuality;
			g1.FillRectangle(Brushes.Red, rect);
			rect.Y += 110;
			g1.DrawEllipse(new Pen(Brushes.Green, 3), rect); 
			g1.DrawLine(Pens.Blue, new Point(20,20), 
				new Point(400, 200) );
					//Release objects
			g.ReleaseHdc(hdc);
			g1.Dispose();
			g.Dispose();	
		}

		private void MetafileHeaderInfo_Click(object sender, System.EventArgs e)
		{
			Metafile curMetafile = new Metafile(@"f:\mtfile.wmf");
			MetafileHeader header = curMetafile.GetMetafileHeader();
			string mfAttributes = "";
			mfAttributes += "Type :"+ header.Type.ToString();
			mfAttributes += ", Bounds:"+ header.Bounds.ToString();
			mfAttributes += ", Size:"+ header.MetafileSize.ToString();
			mfAttributes += ", Version:"+ header.Version.ToString();
			MessageBox.Show(mfAttributes);			
			curMetafile.Dispose();			
		}
	}
}



