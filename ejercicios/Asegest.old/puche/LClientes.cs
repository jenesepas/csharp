using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Asegest
{
	/// <summary>
	/// Description of LClientes. (No utilizado, sustituido x Rpt_LClientes)
	/// </summary>
	public class LClientes
	{
		private Font printFont;
        //private StreamReader streamToPrint;
        //static string filePath;
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();

        private int linesPerPage = 0;
        private int xPos = 0;
        private int yPos = 0;
        private int n_lineas = 0;
        private float leftMargin = 0;
        private float topMargin = 0;
        private String line = null;
		short pos_reg=0;
		short n_pag=0; 		
	    public List<Cliente> _ctes = new List<Cliente>();	
        
		public LClientes()
		{
			try
            {                    
				_ctes.Clear();
				_ctes.AddRange(Ctes_Opera.Buscar("","",' '));        //obtengo todos los ctes en ctes_opera.buscar y se lo paso a la lista			
				//PrintDocument pd = new PrintDocument();
				printDocument1.DefaultPageSettings.Landscape = true;
				printDocument1.PrintPage -= new PrintPageEventHandler(printDocument1_PrintPage);
				printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
				// Print the document.
				//printDocument1.Print();
				printPreviewDialog1.Document = printDocument1;
				printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
				printPreviewDialog1.WindowState = FormWindowState.Maximized;
				//printPreviewDialog1.ShowDialog();
				
				DialogResult respuesta = MessageBox.Show("¿Desea entrar en la vista previa del impreso?","Atención",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
				if (respuesta == DialogResult.Yes )
				{
					printPreviewDialog1.ShowDialog();
				}
				else
				{
					//PrinterSettings printerSettings1 = new PrinterSettings();
					PrintDialog printDialog1 = new PrintDialog();
					//printDialog1.PrinterSettings = printerSettings1;
					printDialog1.Document = printDocument1;
					//printDialog1.ShowDialog();
					//printDocument1.Print();
					if (printDialog1.ShowDialog().Equals(DialogResult.OK))
						printDialog1.Document.Print();
				}
        	}
            catch (Exception e1) 
            {
               	MessageBox.Show("No se seleccionó ningún registro.",e1.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}
		
		
		// The PrintPage event is raised for each page to be printed.
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs ev)
        {            
        	printFont = new Font("Arial", 11);
            leftMargin = 50;//ev.MarginBounds.Left;
            topMargin = 50;//ev.MarginBounds.Top;
            StringFormat drawFormat = new StringFormat();            
            // Calculate the number of lines per page.
            linesPerPage = 55; //Convert.ToInt32(ev.MarginBounds.Height /printFont.GetHeight(ev.Graphics));
			n_pag++;
			n_lineas=0;

            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (n_lineas * printFont.GetHeight(ev.Graphics));
			
            ev.Graphics.DrawRectangle(new Pen(Color.Black, 1),xPos, yPos, xPos+60, yPos+50);
            printFont = new Font("Arial", 16,FontStyle.Bold);
            ev.Graphics.DrawString("ASEGEST", printFont, Brushes.Black, xPos, yPos + 30);
            ev.Graphics.DrawString("YECMUR", printFont, Brushes.Black, xPos, yPos + 60);
            yPos=yPos+100;
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos, xPos + 1050, yPos);//750 vert.
            n_lineas=n_lineas + 3;


              			
            printFont = new Font("Arial", 14,FontStyle.Bold|FontStyle.Underline);
            ev.Graphics.DrawString("LISTADO DE CLIENTES:", printFont, Brushes.Black, xPos+400, yPos + 30);
            
            //cabecera
            printFont = new Font("Arial", 10,FontStyle.Bold);
            ev.Graphics.DrawString("C/T/B", printFont, Brushes.Black, xPos, yPos + 80);
            ev.Graphics.DrawString("CODIGO", printFont, Brushes.Black, xPos+40, yPos + 80);
            ev.Graphics.DrawString("NOMBRE", printFont, Brushes.Black, xPos+100, yPos + 80);
            ev.Graphics.DrawString("DOCUMENTO", printFont, Brushes.Black, xPos+400, yPos + 80);
            ev.Graphics.DrawString("DIRECCION", printFont, Brushes.Black, xPos+600, yPos + 80);
            ev.Graphics.DrawString("C.P.", printFont, Brushes.Black, xPos+880, yPos + 80);
            ev.Graphics.DrawString("CIUDAD", printFont, Brushes.Black, xPos+920, yPos + 80);
            
            
            ev.Graphics.DrawString("TFNO1", printFont, Brushes.Black, xPos, yPos + 100);
            ev.Graphics.DrawString("TFNO2", printFont, Brushes.Black, xPos+100, yPos + 100);
            ev.Graphics.DrawString("P.CONTACTO", printFont, Brushes.Black, xPos+400, yPos + 100);
            ev.Graphics.DrawString("EMAIL", printFont, Brushes.Black, xPos+600, yPos + 100);
            ev.Graphics.DrawString("PROVINCIA", printFont, Brushes.Black, xPos+920, yPos + 100);
            ev.Graphics.DrawLine(new Pen(Color.Black, 2), xPos, yPos+120, xPos + 1050, yPos+120);
            
            n_lineas=n_lineas + 5;
            
            yPos=yPos + 130;
            //lineas
            
            printFont = new Font("Arial", 10,FontStyle.Regular);
            while ((pos_reg < _ctes.Count) && (n_lineas < linesPerPage))
            {
            	ev.Graphics.DrawString(Convert.ToString(_ctes.ElementAt(pos_reg).Tipo_cte), printFont, Brushes.Black, xPos +10, yPos);
            	ev.Graphics.DrawString(Convert.ToString(_ctes.ElementAt(pos_reg).Id_Cliente), printFont, Brushes.Black, xPos +30, yPos);
            	ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Nombre, printFont, Brushes.Black, xPos +100, yPos);
            	line=_ctes.ElementAt(pos_reg).Tipo_docu.Trim() + ": "+ _ctes.ElementAt(pos_reg).Documento.Trim() + _ctes.ElementAt(pos_reg).Letra;
            	ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos+400, yPos);
            	ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Direccion, printFont, Brushes.Black, xPos+600, yPos);
            	ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Cpostal, printFont, Brushes.Black, xPos+880, yPos);
            	ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Ciudad, printFont, Brushes.Black, xPos+920, yPos);
            	
            	ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Telf1, printFont, Brushes.Black, xPos, yPos+20);
            	ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Telf2, printFont, Brushes.Black, xPos+100, yPos+20);
            	ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Pers_cont, printFont, Brushes.Black, xPos+400, yPos+20);
            	ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Email, printFont, Brushes.Black, xPos+650, yPos+20);
            	ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Provin, printFont, Brushes.Black, xPos+920, yPos+20);
            	
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos+40, xPos + 1050, yPos+40);
            	yPos=yPos + 50;
            	pos_reg++;
            	n_lineas=n_lineas+3;
            }
            
            //pie
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, 1120, xPos + 1050, 1120);
            line = "Pag. " + Convert.ToString(n_pag);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos +500, 1125);

            // If more lines exist, print another page.
            if (pos_reg < _ctes.Count)//(line != null)
                ev.HasMorePages = true;
            else
            {
                ev.HasMorePages = false;
                pos_reg =0; //reinicio para la impresion en papel
                n_pag=0;
            }
        }

		
	}
}
