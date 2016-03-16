using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Formulario1
{
    class Print
    {
        private Font printFont;
        private StreamReader streamToPrint;
        static string filePath;
        public PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        public PrintDocument printDocument3 = new PrintDocument();     

        public Print() 
        {         	                  
        	Printing();        			     
        }

         // The PrintPage event is raised for each page to be printed.
        private void printDocument3_PrintPage(object sender, PrintPageEventArgs ev) 
         {
             float linesPerPage = 0;
             float yPos =  0;
             int count = 0;
             float leftMargin = ev.MarginBounds.Left;
             float topMargin = ev.MarginBounds.Top;
             String line=null;
             printFont = new Font("Arial", 10);

             // Calculate the number of lines per page.
             linesPerPage = ev.MarginBounds.Height  / 
                printFont.GetHeight(ev.Graphics) ;

             // Iterate over the file, printing each line.
             while (count < linesPerPage && 
                ((line=streamToPrint.ReadLine()) != null)) 
             {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString (line, printFont, Brushes.Black, 
                   leftMargin, yPos, new StringFormat());
                count++;
             }

             // If more lines exist, print another page.
             
             if (line != null)
                ev.HasMorePages = true;
             else             
                ev.HasMorePages = false;
             
             // If there are no more pages, reset the string to be printed.
			 if (!ev.HasMorePages)			 
               streamToPrint = new StreamReader (filePath);
			 
         }
		
         
       
         // Print the file.
         public void Printing()
         {
             filePath = @"e:\tmp\rejilla.txt";            
             try 
             {
                streamToPrint = new StreamReader (filePath);
               	   
                                   
                printDocument3.PrintPage += new PrintPageEventHandler(printDocument3_PrintPage);
                   // Print the document.
                   //pd.Print();
                printPreviewDialog1.Document = printDocument3;
                printPreviewDialog1.ShowDialog();
                   
               
                /*
                finally
                {
                   streamToPrint.Close() ;
                }
                */
            } 
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
         }

    }
}
