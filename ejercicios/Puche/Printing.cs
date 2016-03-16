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
    class Printing
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

        public Printing() {}

        // Print the file.
        public Printing(Registro pRegAct)
        {
            //filePath = @"e:\tmp\rejilla.txt";
            //try
            //{
                //streamToPrint = new StreamReader(filePath);                
            
            //if (pRegAct.delegacion != ' ')
            //{
                try
                {
                    char deleg = pRegAct.delegacion; //salta exception si registro vacio

                    RegAct = pRegAct;
                    printFont = new Font("Arial", 12);
                    //PrintDocument pd = new PrintDocument();
                    printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                    // Print the document.
                    //pd.Print();
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
                /*
                finally
                {
                    streamToPrint.Close();
                }
                  
                }*/
                catch (Exception) //ex
                {
                    MessageBox.Show("No se seleccionó ningún registro.", "Atención:",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            //}
            //else MessageBox.Show(ex.Message, "Atención:",MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        // The PrintPage event is raised for each page to be printed.
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs ev)
        {
            
            leftMargin = ev.MarginBounds.Left;
            topMargin = ev.MarginBounds.Top;
            // Calculate the number of lines per page.
            linesPerPage = Convert.ToInt32(ev.MarginBounds.Height /printFont.GetHeight(ev.Graphics));

            print_cab(ev);

            // Iterate over the file, printing each line.
            /*
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }
            */
            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        private void print_cab(PrintPageEventArgs ev)
        {
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin) + 50; //+ (count * printFont.GetHeight(ev.Graphics));

            while (count < linesPerPage)
            {
                ev.Graphics.DrawLine(new Pen(Color.Black,2), new Point(xPos, yPos), new Point(xPos + 800, yPos));
                count++;

                string n_deleg="";
                if (RegAct.delegacion == 'Y')
                    n_deleg = "YECLA";
                else
                {
                    if (RegAct.delegacion == 'M')
                        n_deleg = "MURCIA";
                    else
                        n_deleg = "ALBACETE";
                }

                line = "Delegación: " + n_deleg;
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos, yPos + 50, new StringFormat());
                line = "Nº Expediente: " + Convert.ToString(RegAct.n_reg);
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos+ 300, yPos + 50, new StringFormat());
                count++;
                
                string n_cte = Reg_Opera.Calcular_nom_cte(Convert.ToString(RegAct.id_cte), 'C');
                line = "Cliente: " + RegAct.id_cte;
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos, yPos + 100, new StringFormat());
                line = n_cte;
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 300, yPos + 100, new StringFormat());
                count++;

                string n_tit = Reg_Opera.Calcular_nom_cte(Convert.ToString(RegAct.id_titular), 'T');
                line = "Titular: " + RegAct.id_titular;
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos, yPos + 150, new StringFormat());
                line = n_tit;
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 300 , yPos + 150, new StringFormat());
                count++;

                count = 100;
                line = null;

            }
            
        }

    }
}
