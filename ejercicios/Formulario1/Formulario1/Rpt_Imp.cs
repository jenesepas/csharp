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
    public partial class Rpt_Imp : Form
    {
        
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();
        public PrintDocument printDocument2 = new PrintDocument();
        Bitmap memoryImage;

        // Declare a string to hold the entire document contents.
        private string documentContents;

        // Declare a variable to hold the portion of the document that
        // is not printed.
        private string stringToPrint;
        
        public Rpt_Imp()
        {
            //InitializeComponent();
            printDocument1.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument2.PrintPage +=
                new PrintPageEventHandler(printDocument2_PrintPage);
            /*
            ReadDocument();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
             */            
        }

        private void ReadDocument()
        {
            string docName = "reports.txt";
            string docPath = @"e:\tmp\";
            printDocument1.DocumentName = docName;
            using (FileStream stream = new FileStream(docPath + docName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }
            stringToPrint = documentContents;
        }

        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;
        }

        public void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        public void printDocument2_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }


    }
}
