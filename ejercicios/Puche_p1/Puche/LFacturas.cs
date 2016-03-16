/*
 * Created by SharpDevelop.
 * User: juanan
 * Date: 04/01/2015
 * Time: 9:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Puche
{
	/// <summary>
	/// Description of LFacturas.
	/// </summary>
	public class LFacturas
	{
		
		private Font printFont;
        //private StreamReader streamToPrint;
        //static string filePath;
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();

        private int linesPerPage = 0;
        private int xPos = 0;
        private int yPos = 0;
        private int count = 0;
        private float leftMargin = 0;
        private float topMargin = 0;
        private String line = null;
        private Registro RegAct = new Registro();
        private Cliente ClienteFacturado = new Cliente();
        
        public LFacturas() {}
        
        public LFacturas(Registro pRegAct)
		{
			try
                {
                    char deleg = pRegAct.delegacion; //salta exception si registro vacio

                    RegAct = pRegAct;                    
                    //PrintDocument pd = new PrintDocument();
                    //printDocument1.DefaultPageSettings.Landscape = true;
                    printDocument1.PrintPage -= new PrintPageEventHandler(printDocument1_PrintPage);
                    printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                    // Print the document.
                    //printDocument1.Print();                    
                   
					
					//DirectCast((printPreviewDialog1.Controls(1)), ToolStrip).Items.RemoveAt(0);
                    
					DialogResult respuesta = MessageBox.Show("¿Desea entrar en la vista previa del impreso?","Atención",
					                         MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
					if (respuesta == DialogResult.Yes )
					{
						printPreviewDialog1.Document = printDocument1;
                    	printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
						printPreviewDialog1.WindowState = FormWindowState.Maximized;
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
        	printFont = new Font("Arial", 12);
            leftMargin = 50;//ev.MarginBounds.Left;
            topMargin = 50;//ev.MarginBounds.Top;
            StringFormat drawFormat = new StringFormat();
			drawFormat.Alignment = StringAlignment.Far;            
            // Calculate the number of lines per page.
            linesPerPage = Convert.ToInt32(ev.MarginBounds.Height /printFont.GetHeight(ev.Graphics));
			string dg_direc=" ";
			string dg_pob=" ";
			string dg_cif=" ";
			string dg_tel=" ";
						
            if (RegAct.delegacion == 'Y')
            {
             	dg_direc = "PASCUAL AMAT, Nº 7";
             	dg_pob = "30510  YECLA  MURCIA";
             	dg_cif = "CIF:  B7382125";
             	dg_tel = "Tel.: 968752917";
            }
            else
            {
               	if (RegAct.delegacion == 'M')
               	{
               		dg_pob = "MURCIA";
               	}
                else
                    dg_pob = "ALBACETE";
                }

            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (count * printFont.GetHeight(ev.Graphics));
				
            if (RegAct.t_cte_fra == 'C') //facturar a cte.
                    ClienteFacturado = Ctes_Opera.ObtenerCliente(RegAct.id_cte);
            else
                    ClienteFacturado = Ctes_Opera.ObtenerCliente(RegAct.id_titular);
            
            while (count < linesPerPage)
            {
                //CABECERA
            	printFont = new Font("Arial", 16,FontStyle.Bold);
            	ev.Graphics.DrawString("ASEGEST YECMUR, SLP.", printFont, Brushes.Black, xPos, yPos + 20);
            	printFont = new Font("Arial", 10,FontStyle.Regular);
            	ev.Graphics.DrawString(dg_direc, printFont, Brushes.Black, xPos, yPos + 50);
            	ev.Graphics.DrawString(dg_pob, printFont, Brushes.Black, xPos, yPos + 70);
            	ev.Graphics.DrawString(dg_cif, printFont, Brushes.Black, xPos, yPos + 90);
            	ev.Graphics.DrawString(dg_tel, printFont, Brushes.Black, xPos, yPos + 110);
            	count= count + 5;
            	
            	printFont = new Font("Arial", 16,FontStyle.Bold | FontStyle.Italic);
            	ev.Graphics.DrawString("F A C T U R A", printFont, Brushes.Black, xPos + 60, yPos + 150);
            	printFont = new Font("Arial", 8,FontStyle.Regular);
            	ev.Graphics.DrawString("Datos Cliente", printFont, Brushes.Black, xPos + 380, yPos + 140);
            	count= count + 2;
            	            	
            	//Atencion line: coord. ini y coord. final // rectangle: coord. ini y width y height.
            	printFont = new Font("Arial", 12,FontStyle.Regular);            	
            	ev.Graphics.DrawRectangle(new Pen(Color.Black, 1),xPos + 380, yPos + 160, 350, 160);
            	
            	ev.Graphics.DrawString(Convert.ToString(ClienteFacturado.Id_Cliente).Trim(), printFont, Brushes.Black, xPos+400, yPos+165);
            	printFont = new Font("Arial", 13,FontStyle.Bold);
            	ev.Graphics.DrawString(ClienteFacturado.Nombre, printFont, Brushes.Black, xPos+400, yPos+190);
            	printFont = new Font("Arial", 12,FontStyle.Regular);
            	ev.Graphics.DrawString(ClienteFacturado.Direccion, printFont, Brushes.Black, xPos+400, yPos+215);
            	ev.Graphics.DrawString(ClienteFacturado.Cpostal, printFont, Brushes.Black, xPos+400, yPos+235);
            	ev.Graphics.DrawString(ClienteFacturado.Ciudad, printFont, Brushes.Black, xPos+460, yPos+235);
            	ev.Graphics.DrawString(ClienteFacturado.Provin, printFont, Brushes.Black, xPos+400, yPos+255);
            	ev.Graphics.DrawString(ClienteFacturado.Telf1, printFont, Brushes.Black, xPos+400, yPos+275);
            	ev.Graphics.DrawString(ClienteFacturado.Telf2, printFont, Brushes.Black, xPos+530, yPos+275);            	
            	string docu=ClienteFacturado.Tipo_docu.Trim() + ": "+ ClienteFacturado.Documento.Trim() + ClienteFacturado.Letra;
            	ev.Graphics.DrawString(docu, printFont, Brushes.Black, xPos+400, yPos+295);
            	
            	ev.Graphics.DrawRectangle(new Pen(Color.Black, 1),xPos + 30, yPos + 210, 120, 60);
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+30, yPos+240, xPos + 150, yPos+240);
            	ev.Graphics.DrawString("Nº de Factura", printFont, Brushes.Black, xPos+35, yPos+220);            	
            	ev.Graphics.DrawString(string.Format("{0:#######0}",RegAct.factura), printFont, Brushes.Black, xPos+125, yPos+250,drawFormat);
            	
            	ev.Graphics.DrawRectangle(new Pen(Color.Black, 1),xPos + 180, yPos + 210, 120, 60);
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+180, yPos+240, xPos+300, yPos+240);
            	ev.Graphics.DrawString("Fecha", printFont, Brushes.Black, xPos+215, yPos+220);            	
            	ev.Graphics.DrawString(RegAct.fec_fra.ToString("dd/MM/yyyy"), printFont, Brushes.Black, xPos+195, yPos+250);
            	
            	count= count + 6;
            	
            	//LINEAS
            	ev.Graphics.DrawRectangle(new Pen(Color.Black, 1),xPos + 30, yPos + 340, 700, 550);
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+30, yPos+380, xPos+730, yPos+380);
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+480, yPos+340, xPos+480, yPos+890);
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+600, yPos+340, xPos+600, yPos+890);
            	printFont = new Font("Arial", 14,FontStyle.Bold);
            	ev.Graphics.DrawString("CONCEPTO", printFont, Brushes.Black, xPos+150, yPos+350);
            	ev.Graphics.DrawString("IMPORTE", printFont, Brushes.Black, xPos+495, yPos+350);            	
            	ev.Graphics.DrawString("TOTAL", printFont, Brushes.Black, xPos+630, yPos+350);            	
            	
           		
            	printFont = new Font("Arial", 12,FontStyle.Regular);            	
            	ev.Graphics.DrawString(RegAct.observacion.Substring(0,45).ToUpper(), printFont, Brushes.Black, xPos+40, yPos+400);            	
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}","0,00"), printFont, Brushes.Black, xPos+590, yPos+400,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}","0,00"), printFont, Brushes.Black, xPos+720, yPos+400,drawFormat);            
            	if (RegAct.observacion.Trim().Length > 46)
            	{
            		ev.Graphics.DrawString(RegAct.observacion.Substring(46).ToUpper(), printFont, Brushes.Black, xPos+40, yPos+420);            	
            		yPos=yPos + 20;
            	}
            	
            	ev.Graphics.DrawString("TASA TRAFICO", printFont, Brushes.Black, xPos+40, yPos+420);            	
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.tasa), printFont, Brushes.Black, xPos+590, yPos+420,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.tasa), printFont, Brushes.Black, xPos+720, yPos+420,drawFormat);
            	
            	ev.Graphics.DrawString("DERECHOS DE COLEGIO", printFont, Brushes.Black, xPos+40, yPos+440);            	
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.dcho_col), printFont, Brushes.Black, xPos+590, yPos+440,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.dcho_col), printFont, Brushes.Black, xPos+720, yPos+440,drawFormat);
            	
            	ev.Graphics.DrawString("HONORARIOS", printFont, Brushes.Black, xPos+40, yPos+460);            	
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.base_imp), printFont, Brushes.Black, xPos+590, yPos+460,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.base_imp), printFont, Brushes.Black, xPos+720, yPos+460,drawFormat);
            	
            	count= count + 20;
            	
            	//PIE            	
            	ev.Graphics.DrawRectangle(new Pen(Color.Black, 1),xPos + 30, yPos + 920, 400, 80);
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+30, yPos+950, xPos+430, yPos+950);
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+130, yPos+920, xPos+130, yPos+1000);
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+230, yPos+920, xPos+230, yPos+1000);
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+330, yPos+920, xPos+330, yPos+1000);
            	printFont = new Font("Arial", 12,FontStyle.Bold);
            	ev.Graphics.DrawString("Total Bruto", printFont, Brushes.Black, xPos+33, yPos+930);
            	ev.Graphics.DrawString("Base Imp.", printFont, Brushes.Black, xPos+140, yPos+930);            	
            	ev.Graphics.DrawString("% I.V.A.", printFont, Brushes.Black, xPos+250, yPos+930);            	
            	ev.Graphics.DrawString("Cuota", printFont, Brushes.Black, xPos+350, yPos+930);            	
            	printFont = new Font("Arial", 12,FontStyle.Regular);
            	decimal tot_b=RegAct.dcho_col + RegAct.base_imp + RegAct.tasa;
            	decimal base_imp=RegAct.dcho_col + RegAct.base_imp;
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",tot_b), printFont, Brushes.Black, xPos+120, yPos+960,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",base_imp), printFont, Brushes.Black, xPos+220, yPos+960,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:##0}",RegAct.p_iva), printFont, Brushes.Black, xPos+300, yPos+960,drawFormat);
            	decimal imp_iva = ((base_imp * RegAct.p_iva)/100);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",imp_iva.ToString("N2")), printFont, Brushes.Black, xPos+420, yPos+960,drawFormat);
            	
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.tasa), printFont, Brushes.Black, xPos+220, yPos+980,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:##0}","0"), printFont, Brushes.Black, xPos+300, yPos+980,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}","0,00"), printFont, Brushes.Black, xPos+420, yPos+980,drawFormat);
            	
            	printFont = new Font("Arial", 14,FontStyle.Bold);
            	ev.Graphics.DrawRectangle(new Pen(Color.Black, 2),xPos + 530, yPos + 940, 200, 60);
            	ev.Graphics.DrawString("TOTAL FACTURA", printFont, Brushes.Black, xPos+540, yPos+945);
            	decimal tot_fra = tot_b + imp_iva;
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",tot_fra.ToString("N2")) + " €", printFont, Brushes.Black, xPos+710, yPos+970,drawFormat);
            	
            	count= count + 10;
                //salir del while y no imprimir + pgs.                
                count = 100;
                line = null;

            }

            // If more lines exist, print another page.
            
            if (line != null)
                ev.HasMorePages = true;
            else 
            {
                ev.HasMorePages = false;
                count = 0; //reinicio para la impresion en papel
            }
            
            // If there are no more pages, reset the string to be printed.
			 //if (!ev.HasMorePages)			 
             //  streamToPrint = new StreamReader (filePath);
            
        }

		
		
	}
}
