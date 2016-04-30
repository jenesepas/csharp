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
    class LRegistros
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

        public LRegistros() {}

        // Print the file.
        public LRegistros(Registro pRegAct)
        {
            
                try
                {
                    char deleg = pRegAct.delegacion; //salta exception si registro vacio

                    RegAct = pRegAct;                    
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
        	printFont = new Font("Arial", 12);
            //pintamos en la parte dcha del apaisado, para poder doblar el folio.
            leftMargin = 600;//ev.MarginBounds.Left;
            topMargin = 50;//ev.MarginBounds.Top;
            StringFormat drawFormat = new StringFormat();            
            // Calculate the number of lines per page.
            linesPerPage = Convert.ToInt32(ev.MarginBounds.Height /printFont.GetHeight(ev.Graphics));


            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (count * printFont.GetHeight(ev.Graphics));

            while (count < linesPerPage)
            {

                string n_deleg = "";
                if (RegAct.delegacion == 'Y')
                    n_deleg = "YECLA";
                else
                {
                    if (RegAct.delegacion == 'M')
                        n_deleg = "MURCIA";
                    else
                        n_deleg = "ALBACETE";
                }

                ev.Graphics.DrawRectangle(new Pen(Color.Black, 1),xPos, yPos, 110, 100);
            	printFont = new Font("Arial", 16,FontStyle.Bold);
            	ev.Graphics.DrawString("ASEGEST", printFont, Brushes.Black, xPos, yPos + 30);
            	ev.Graphics.DrawString("YECMUR", printFont, Brushes.Black, xPos, yPos + 60);
                ev.Graphics.DrawString("Delegación:", printFont, Brushes.Black, xPos + 200, yPos + 60);
                ev.Graphics.DrawString(n_deleg, printFont, Brushes.Black, xPos + 350, yPos + 60);
            	yPos=yPos+100;               
            	ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos, xPos + 550, yPos);
                count=count + 3;

                
                printFont = new Font("Arial", 14,FontStyle.Bold);                                
                line = "Nº Registro:   " + Convert.ToString(RegAct.n_reg);                
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos, yPos + 15);
                line = "Fecha Ent.:   " + RegAct.fec_ent.ToString("dd/MM/yyyy");
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 300, yPos + 15);                
                count++;
                line = "Matrícula:   " + Convert.ToString(RegAct.matricula);
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos, yPos + 45);

                printFont = new Font("Arial", 12, FontStyle.Bold);
                line = Convert.ToString(RegAct.vehiculo).Trim();
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 230, yPos + 47);
                count++;

                printFont = new Font("Arial", 12, FontStyle.Regular);
                ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 80, xPos + 550, yPos + 80);				
				count++;
				
                string n_cte = Reg_Opera.Calcular_nom_cte(Convert.ToString(RegAct.id_cte), 'C');             
                ev.Graphics.DrawString("Cliente:", printFont, Brushes.Black, xPos, yPos + 100);
                ev.Graphics.DrawString(Convert.ToString(RegAct.id_cte), printFont, Brushes.Black, xPos + 120, yPos + 100);                
                ev.Graphics.DrawString(n_cte.Trim(), printFont, Brushes.Black, xPos+ 180, yPos + 100);
                string tlfnos = Reg_Opera.Sacar_tlfos_cte(Convert.ToString(RegAct.id_cte), 'C');
                ev.Graphics.DrawString(tlfnos.Trim(), printFont, Brushes.Black, xPos + 180, yPos + 130);
                count++;
                
                string n_tit = Reg_Opera.Calcular_nom_cte(Convert.ToString(RegAct.id_titular), 'T');
                ev.Graphics.DrawString("Titular:", printFont, Brushes.Black, xPos, yPos + 170);
				ev.Graphics.DrawString(Convert.ToString(RegAct.id_titular), printFont, Brushes.Black, xPos + 120, yPos + 170);                
                ev.Graphics.DrawString(n_tit.Trim(), printFont, Brushes.Black, xPos + 180, yPos + 170);
                string tlfnos2 = Reg_Opera.Sacar_tlfos_cte(Convert.ToString(RegAct.id_titular), 'T');
                ev.Graphics.DrawString(tlfnos2.Trim(), printFont, Brushes.Black, xPos + 180, yPos + 200);
                count++;

                if (RegAct.id_colabora > 0)
                {
                    string n_col = Reg_Opera.Calcular_nom_cte(Convert.ToString(RegAct.id_colabora), 'B');
                    ev.Graphics.DrawString("Colaborador:", printFont, Brushes.Black, xPos, yPos + 240);
                    ev.Graphics.DrawString(Convert.ToString(RegAct.id_colabora), printFont, Brushes.Black, xPos + 120, yPos + 240);
                    ev.Graphics.DrawString(n_col.Trim(), printFont, Brushes.Black, xPos + 180, yPos + 240);                    
                    string tlfnos3 = Reg_Opera.Sacar_tlfos_cte(Convert.ToString(RegAct.id_colabora), 'B');
                    ev.Graphics.DrawString(tlfnos3.Trim(), printFont, Brushes.Black, xPos + 180, yPos + 270);
                    count++;
                    yPos = yPos + 90; //60
                }

                ev.Graphics.DrawString("Sección:", printFont, Brushes.Black, xPos, yPos + 240);
				ev.Graphics.DrawString(RegAct.seccion, printFont, Brushes.Black, xPos+120, yPos + 240);                
                count++;
                
                ev.Graphics.DrawString("Trámite:", printFont, Brushes.Black, xPos, yPos + 300);
                ev.Graphics.DrawString(RegAct.t_tramite, printFont, Brushes.Black, xPos+120, yPos + 300);
                count++;
                                		
                ev.Graphics.DrawString("Enviar por:", printFont, Brushes.Black, xPos, yPos + 360);
                ev.Graphics.DrawString(RegAct.enviado, printFont, Brushes.Black, xPos + 120, yPos + 360);
                count++;
                
                ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 410, xPos + 550, yPos + 410);				
				count++;
				
				printFont = new Font("Arial", 14,FontStyle.Bold);
                ev.Graphics.DrawString("Exped.:", printFont, Brushes.Black, xPos, yPos + 420);
				string n_exp=Convert.ToString(RegAct.exp_tl);
				if (n_exp.Length > 16)
					n_exp=n_exp.Substring(0,17);
                ev.Graphics.DrawString(n_exp, printFont, Brushes.Black, xPos + 80, yPos + 420);
                //string.Format("{0:dd/MM/yyyy}",RegAct.fec_pre_exp)
                                
                ev.Graphics.DrawString("Fec.Pres.:", printFont, Brushes.Black, xPos + 300, yPos + 420);
                if (!string.IsNullOrWhiteSpace(n_exp))    
                    ev.Graphics.DrawString(RegAct.fec_pre_exp.ToString("dd/MM/yyyy"), printFont, Brushes.Black, xPos + 415, yPos + 420);                
                count++;                
                
				printFont = new Font("Arial", 12,FontStyle.Bold);
                ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 460, xPos + 550, yPos + 460);				
				count++;

                ev.Graphics.DrawString("Observ.:", printFont, Brushes.Black, xPos, yPos + 480);
                if (!string.IsNullOrWhiteSpace(RegAct.observacion))
                {                    
                    string observ = RegAct.observacion.Trim();
                    printFont = new Font("Arial", 11, FontStyle.Regular);
                    if (observ.Length > 50)
                    {
                        ev.Graphics.DrawString(observ.Substring(0, 50), printFont, Brushes.Black, xPos + 70, yPos + 480);
                        count++;
                        if (observ.Length > 100)
                        {
                            ev.Graphics.DrawString(observ.Substring(50, 50), printFont, Brushes.Black, xPos + 70, yPos + 500);
                            count++;

                            if (observ.Length > 150)
                            {
                                ev.Graphics.DrawString(observ.Substring(100,50), printFont, Brushes.Black, xPos + 70, yPos + 520);
                                count++;

                                ev.Graphics.DrawString(observ.Substring(150), printFont, Brushes.Black, xPos + 70, yPos + 540);
                                count++;                                        
                            }
                            else
                            {
                                ev.Graphics.DrawString(observ.Substring(100), printFont, Brushes.Black, xPos + 70, yPos + 520);
                                count++;
                            } 
                        }
                        else
                        {
                            ev.Graphics.DrawString(observ.Substring(50), printFont, Brushes.Black, xPos + 70, yPos + 500);
                            count++;
                        }                                                
                    }
                    else
                    {
                        ev.Graphics.DrawString(observ.Substring(0), printFont, Brushes.Black, xPos + 70, yPos + 480);
                        count++;

                    }

                }

				
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
        }

        

    }
}
