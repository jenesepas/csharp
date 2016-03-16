using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace Formulario1
{
	/// <summary>
	/// Description of Form2.
	/// </summary>
	public partial class Rpt_Imp2 : Form
	{
		private PrintPreviewControl ppc;
		private PrintDocument docToPrint = new PrintDocument();
		
		public Rpt_Imp2()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			CreatePrintPreviewControl();
			// Add PrintDocument PrintPage event handler
			docToPrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintPage);
		}
		
		private void CreatePrintPreviewControl()
		{
			ppc = new PrintPreviewControl();               
			    ppc.Name = "PrintPreviewControl1";
			    ppc.Dock = DockStyle.Fill;
			    ppc.Location = new Point(88, 80);           
			    ppc.Document = docToPrint;
			    ppc.Zoom = 0.25;
			    ppc.Document.DocumentName = "c:\\";
			    ppc.UseAntiAlias = true;
			 
			    // Add PrintPreviewControl to Form
			    Controls.Add(this.ppc);           
		} 

		private void PrintPage(object sender, PrintPageEventArgs e)
		{
			string text = "This text to be printed. ";
			e.Graphics.DrawString(text, new Font("Georgia", 35, FontStyle.Bold),
			        Brushes.Black, 10, 10);
		}		
		
		
	}
}
