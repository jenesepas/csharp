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
using System.Data;

namespace Asegest
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
        private DataTable linfac;
        decimal[] importes = new decimal[2];
        
        public LFacturas() {}
        
        public LFacturas(Registro pRegAct, DataTable plinfac)
		{
			try
                {
                    char deleg = pRegAct.delegacion; //salta exception si registro vacio

                    if (pRegAct.estado_fac == ' ' & Reg_Opera.Fra_listada_enlazada(pRegAct.factura,0) > 0)
                    { //actualiza estado factura
                    }
                
                    RegAct = pRegAct;
                    linfac = plinfac;    
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
            leftMargin = 30;//ev.MarginBounds.Left;
            topMargin = 50;//ev.MarginBounds.Top;
            StringFormat drawFormat = new StringFormat();
			drawFormat.Alignment = StringAlignment.Far;            
            // Calculate the number of lines per page.
            linesPerPage = Convert.ToInt32(ev.MarginBounds.Height /printFont.GetHeight(ev.Graphics));
			string dg_direc=" ";
			string dg_pob=" ";
			string dg_cif=" ";
			string dg_tel=" ";
						
            if (RegAct.delegacion == 'M')
            {
                dg_direc = "C/ RONDA SUR, 32 1ºB";
                dg_pob = "30012  MURCIA";
                dg_cif = "CIF:  B73821225";
                dg_tel = "Tel./Fax: 868078844 /Mov.: 636205206 - 690263439";
            }
            else //yecla y alb la misma direccion
            {
                dg_direc = "PASCUAL AMAT, Nº 7";
                dg_pob = "30510  YECLA  MURCIA";
                dg_cif = "CIF:  B73821225";
                dg_tel = "Tel.: 968752917";                           	
            }

            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (count * printFont.GetHeight(ev.Graphics));

            if (RegAct.t_cte_fra == 'C') //facturar a cte.
                ClienteFacturado = Ctes_Opera.ObtenerCliente(RegAct.id_cte);
            else
            {
                if (RegAct.t_cte_fra == 'T') //facturar a titular.
                    ClienteFacturado = Ctes_Opera.ObtenerCliente(RegAct.id_titular);
                else //facturar a colaborador.
                    ClienteFacturado = Ctes_Opera.ObtenerCliente(RegAct.id_colabora);
            }

            while (count < linesPerPage)
            {
                //CABECERA
                string titulo="ASEGEST YECMUR, SLP.";
                if (RegAct.delegacion == 'A')
                    titulo = titulo + " - ALBACETE";
            	printFont = new Font("Arial", 16,FontStyle.Bold);
            	ev.Graphics.DrawString(titulo, printFont, Brushes.Black, xPos, yPos + 20);
            	printFont = new Font("Arial", 10,FontStyle.Regular);
            	ev.Graphics.DrawString(dg_direc, printFont, Brushes.Black, xPos, yPos + 50);
            	ev.Graphics.DrawString(dg_pob, printFont, Brushes.Black, xPos, yPos + 70);
            	ev.Graphics.DrawString(dg_cif, printFont, Brushes.Black, xPos, yPos + 90);
            	ev.Graphics.DrawString(dg_tel, printFont, Brushes.Black, xPos, yPos + 110);
            	count= count + 5;
            	
            	printFont = new Font("Arial", 16,FontStyle.Bold | FontStyle.Italic);
            	ev.Graphics.DrawString("F A C T U R A", printFont, Brushes.Black, xPos + 60, yPos + 150);
            	printFont = new Font("Arial", 8,FontStyle.Regular);
            	ev.Graphics.DrawString("Datos Cliente", printFont, Brushes.Black, xPos + 330, yPos + 140);
            	count= count + 2;
            	            	
            	//Atencion line: coord. ini y coord. final // rectangle: coord. ini y width y height.
            	printFont = new Font("Arial", 12,FontStyle.Regular);            	
            	ev.Graphics.DrawRectangle(new Pen(Color.Black, 1),xPos + 330, yPos + 160, 400, 160);
            	
            	ev.Graphics.DrawString(Convert.ToString(ClienteFacturado.Id_Cliente).Trim(), printFont, Brushes.Black, xPos+340, yPos+165);
            	printFont = new Font("Arial", 13,FontStyle.Bold);
            	ev.Graphics.DrawString(ClienteFacturado.Nombre, printFont, Brushes.Black, xPos+340, yPos+190);
            	printFont = new Font("Arial", 12,FontStyle.Regular);
            	ev.Graphics.DrawString(ClienteFacturado.Direccion, printFont, Brushes.Black, xPos+340, yPos+215);
            	ev.Graphics.DrawString(ClienteFacturado.Cpostal, printFont, Brushes.Black, xPos+340, yPos+235);
            	ev.Graphics.DrawString(ClienteFacturado.Ciudad, printFont, Brushes.Black, xPos+400, yPos+235);
            	ev.Graphics.DrawString(ClienteFacturado.Provin, printFont, Brushes.Black, xPos+340, yPos+255);
            	ev.Graphics.DrawString(ClienteFacturado.Telf1, printFont, Brushes.Black, xPos+340, yPos+275);
            	ev.Graphics.DrawString(ClienteFacturado.Telf2, printFont, Brushes.Black, xPos+470, yPos+275);            	
            	string docu=ClienteFacturado.Tipo_docu.Trim() + ": "+ ClienteFacturado.Documento.Trim() + ClienteFacturado.Letra;
            	ev.Graphics.DrawString(docu, printFont, Brushes.Black, xPos+340, yPos+295);
            	
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
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+490, yPos+340, xPos+490, yPos+890);
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos+610, yPos+340, xPos+610, yPos+890);
            	printFont = new Font("Arial", 14,FontStyle.Bold);
            	ev.Graphics.DrawString("CONCEPTO", printFont, Brushes.Black, xPos+150, yPos+350);
            	ev.Graphics.DrawString("IMPORTE", printFont, Brushes.Black, xPos+510, yPos+350);            	
            	ev.Graphics.DrawString("TOTAL", printFont, Brushes.Black, xPos+630, yPos+350);

                count = count + 3;
           		
                string descrip2=RegAct.descripcion.Trim();
            	if (descrip2.Length > 42)
					descrip2=descrip2.Substring(0,43);

            	printFont = new Font("Arial", 12,FontStyle.Regular);            	
            	ev.Graphics.DrawString(descrip2.ToUpper(), printFont, Brushes.Black, xPos+40, yPos+400);            	
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}","0,00"), printFont, Brushes.Black, xPos+600, yPos+400,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}","0,00"), printFont, Brushes.Black, xPos+720, yPos+400,drawFormat);
                if (RegAct.descripcion.Trim().Length > 42)
            	{
                    if (RegAct.descripcion.Trim().Length > 87)
                        descrip2 = RegAct.descripcion.Trim().Substring(43, 45);
                    else descrip2 = RegAct.descripcion.Trim().Substring(43);

            		ev.Graphics.DrawString(descrip2.ToUpper(), printFont, Brushes.Black, xPos+40, yPos+420);
            		yPos=yPos + 20;
                    count = count + 1;
            	}
                if (RegAct.descripcion.Trim().Length > 87)
                {
                    descrip2 = RegAct.descripcion.Trim().Substring(88);
                    ev.Graphics.DrawString(descrip2.ToUpper(), printFont, Brushes.Black, xPos + 40, yPos + 420);
                    yPos = yPos + 20;
                    count = count + 1;
                }

                importes[0] = 0; //sin iva
                importes[1] = 0; //con iva
                //sacamos los importes con iva de linfac a simpor1; los sin iva ya estan acumulados en campo tasa,
                //pero debemos restarlos en tasa, pues luego le pondremos el detalle.               
                importes = Linfac_Opera.Calcular_importes_linfac(RegAct.factura);

                //sergio: linea  de separacion
                yPos = yPos + 20;
            	ev.Graphics.DrawString("TASA TRAFICO", printFont, Brushes.Black, xPos+40, yPos+420);            	
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.tasa - importes[0]), printFont, Brushes.Black, xPos+600, yPos+420,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.tasa - importes[0]), printFont, Brushes.Black, xPos+720, yPos+420,drawFormat);
            	
            	ev.Graphics.DrawString("DERECHOS DE COLEGIO", printFont, Brushes.Black, xPos+40, yPos+440);            	
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.dcho_col), printFont, Brushes.Black, xPos+600, yPos+440,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.dcho_col), printFont, Brushes.Black, xPos+720, yPos+440,drawFormat);
            	
            	ev.Graphics.DrawString("HONORARIOS", printFont, Brushes.Black, xPos+40, yPos+460);            	
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.honorarios), printFont, Brushes.Black, xPos+600, yPos+460,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",RegAct.honorarios), printFont, Brushes.Black, xPos+720, yPos+460,drawFormat);

                count = count + 4;

                decimal simpor0 = 0;//sin iva
                decimal simpor1 = 0;//con iva

                //Detalle de lineas
                if (linfac.Rows.Count > 0)
                {
                    foreach (DataRow linea in linfac.Rows)
                    {                                                
                        ev.Graphics.DrawString(linea[2].ToString().Substring(0, 43).ToUpper(), printFont, Brushes.Black, xPos + 40, yPos + 480);
                        ev.Graphics.DrawString(string.Format("{0:###,##0.00}", linea[3]), printFont, Brushes.Black, xPos + 600, yPos + 480, drawFormat);
                        ev.Graphics.DrawString(string.Format("{0:###,##0.00}", linea[3]), printFont, Brushes.Black, xPos + 720, yPos + 480, drawFormat);
                        if (linea[2].ToString().Trim().Length > 42)
                        {
                            ev.Graphics.DrawString(linea[2].ToString().Substring(43, 45).ToUpper(), printFont, Brushes.Black, xPos + 40, yPos + 500);
                            yPos = yPos + 20;
                            count = count + 1;
                        }
                        if (linea[2].ToString().Trim().Length > 87)
                        {
                            ev.Graphics.DrawString(linea[2].ToString().Substring(88).ToUpper(), printFont, Brushes.Black, xPos + 40, yPos + 500);
                            yPos = yPos + 20;
                            count = count + 1;
                        }

                        yPos = yPos + 20;
                        count = count + 1;
                        //vemos si esta exento de iva el importe: importe[4] columna de piva.
                        if (linea[4].ToString() == "0")
                            simpor0 = simpor0 + Convert.ToDecimal(linea[3].ToString());
                        else
                            simpor1 = simpor1 + Convert.ToDecimal(linea[3].ToString());

                    }
                }

                
            	
            	//PIE

                ev.Graphics.DrawRectangle(new Pen(Color.Black, 1), xPos + 30, 950, 400, 80);
                ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos + 30, 980, xPos + 430, 980);
                ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos + 130, 950, xPos + 130, 1030);
                ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos + 230, 950, xPos + 230, 1030);
                ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos + 330, 950, xPos + 330, 1030);
                printFont = new Font("Arial", 12, FontStyle.Bold);
                ev.Graphics.DrawString("Total Bruto", printFont, Brushes.Black, xPos + 33, 960);
                ev.Graphics.DrawString("Base Imp.", printFont, Brushes.Black, xPos + 140, 960);
                ev.Graphics.DrawString("% I.V.A.", printFont, Brushes.Black, xPos + 250, 960);
                ev.Graphics.DrawString("Cuota", printFont, Brushes.Black, xPos + 350, 960);
                printFont = new Font("Arial", 12, FontStyle.Regular);

                
                
                decimal base_imp = RegAct.dcho_col + RegAct.honorarios + simpor1;
                decimal tot_tasas = RegAct.tasa; //+ simpor0; regact.tasas ya guarda el impor d linfac q sea sin iva
                decimal tot_b = base_imp + tot_tasas;

            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",tot_b), printFont, Brushes.Black, xPos+120, 990,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",base_imp), printFont, Brushes.Black, xPos+220, 990,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:##0}",RegAct.p_iva), printFont, Brushes.Black, xPos+300, 990,drawFormat);
            	decimal imp_iva = ((base_imp * RegAct.p_iva)/100);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",imp_iva.ToString("N2")), printFont, Brushes.Black, xPos+420, 990,drawFormat);

                ev.Graphics.DrawString(string.Format("{0:###,##0.00}", tot_tasas), printFont, Brushes.Black, xPos + 220, 1010, drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:##0}","0"), printFont, Brushes.Black, xPos+300, 1010,drawFormat);
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}","0,00"), printFont, Brushes.Black, xPos+420, 1010,drawFormat);
            	
            	printFont = new Font("Arial", 14,FontStyle.Bold);
            	ev.Graphics.DrawRectangle(new Pen(Color.Black, 2),xPos + 530, 970, 200, 60);
            	ev.Graphics.DrawString("TOTAL FACTURA", printFont, Brushes.Black, xPos+540, 975);
            	decimal tot_fra = tot_b + imp_iva;
            	ev.Graphics.DrawString(string.Format("{0:###,##0.00}",tot_fra.ToString("N2")) + " €", printFont, Brushes.Black, xPos+710, 1000,drawFormat);
            	
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
