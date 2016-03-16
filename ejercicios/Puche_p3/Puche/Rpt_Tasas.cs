using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace Puche
{
    public partial class Rpt_Tasas : Form
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
        //private String line = null;
        short pos_reg = 0;
        short n_pag = 0;
        public List<Tasa> _tasas = new List<Tasa>();
        
        public Rpt_Tasas()
        {
            InitializeComponent();
        }

        public void lanza_ltasas()
        {
            try
            {
                
                _tasas.Clear();
                _tasas.AddRange(Tasas_Opera.Buscar_ltasas(tb_d_ej.Text, tb_h_ej.Text,tb_d_cod.Text, tb_h_cod.Text));                

                if (_tasas.Count == 0)
                    MessageBox.Show("No se obtuvo ningún registro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    printDocument1.PrintPage -= new PrintPageEventHandler(printDocument1_PrintPage);
                    printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;

                    DialogResult respuesta = MessageBox.Show("¿Desea entrar en la vista previa del impreso?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (respuesta == DialogResult.Yes)
                    {
                        printPreviewDialog1.ShowDialog();
                    }
                    else
                    {

                        PrintDialog printDialog1 = new PrintDialog();
                        printDialog1.Document = printDocument1;

                        if (printDialog1.ShowDialog().Equals(DialogResult.OK))
                            printDialog1.Document.Print();
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("No se seleccionó ningún registro.", e1.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // The PrintPage event is raised for each page to be printed.
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs ev)
        {
            printFont = new Font("Arial", 11);
            leftMargin = 50;//ev.MarginBounds.Left;
            topMargin = 50;//ev.MarginBounds.Top;
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Far; 
            // Calculate the number of lines per page.
            linesPerPage = 60; //Convert.ToInt32(ev.MarginBounds.Height /printFont.GetHeight(ev.Graphics));
            n_pag++;
            n_lineas = 0;
            
            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (n_lineas * printFont.GetHeight(ev.Graphics));

            ev.Graphics.DrawRectangle(new Pen(Color.Black, 1), xPos, yPos, xPos + 60, yPos + 50);
            printFont = new Font("Arial", 16, FontStyle.Bold);
            ev.Graphics.DrawString("ASEGEST", printFont, Brushes.Black, xPos, yPos + 30);
            ev.Graphics.DrawString("YECMUR", printFont, Brushes.Black, xPos, yPos + 60);
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 100, xPos + 750, yPos + 100);

            printFont = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            ev.Graphics.DrawString("LISTADO DE TASAS:", printFont, Brushes.Black, xPos + 260, yPos + 120);

            n_lineas = n_lineas + 5;
            yPos = yPos + 120;

            //cabecera
            printFont = new Font("Arial", 12, FontStyle.Bold);

            ev.Graphics.DrawString("EJERCICIO", printFont, Brushes.Black, xPos, yPos + 40);
            ev.Graphics.DrawString("CODIGO", printFont, Brushes.Black, xPos + 100, yPos + 40);
            ev.Graphics.DrawString("DESCRIPCION", printFont, Brushes.Black, xPos + 200, yPos + 40);
            ev.Graphics.DrawString("IMPORTE", printFont, Brushes.Black, xPos + 600, yPos + 40);
            ev.Graphics.DrawLine(new Pen(Color.Black, 2), xPos, yPos + 60, xPos + 750, yPos + 60);

            n_lineas = n_lineas + 2;
            yPos = yPos + 70;        

            while ((pos_reg < _tasas.Count) && (n_lineas < linesPerPage))
            {             
                //lineas
                
                printFont = new Font("Arial", 12, FontStyle.Regular);
                ev.Graphics.DrawString(Convert.ToString(_tasas.ElementAt(pos_reg).ejercicio), printFont, Brushes.Black, xPos+20, yPos + 10);
                ev.Graphics.DrawString(_tasas.ElementAt(pos_reg).codigo, printFont, Brushes.Black, xPos + 120, yPos + 10);
                ev.Graphics.DrawString(_tasas.ElementAt(pos_reg).descripcion.Substring(0, 19), printFont, Brushes.Black, xPos + 200, yPos + 10);
                ev.Graphics.DrawString(string.Format("{0:###,##0.00}", _tasas.ElementAt(pos_reg).importe), printFont, Brushes.Black, xPos + 700, yPos + 10,drawFormat);

                
                yPos = yPos + 30;
                pos_reg++;
                n_lineas = n_lineas + 2;
            }

            //pie
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, 1120, xPos + 750, 1120);
            string line = "Pag. " + Convert.ToString(n_pag);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 350, 1125);

            // If more lines exist, print another page.
            if (pos_reg < _tasas.Count)//(line != null)
                ev.HasMorePages = true;
            else
            {
                ev.HasMorePages = false;
                pos_reg = 0; //reinicio para la impresion en papel
                n_pag = 0;
            }
        }

        

        private void btt_imp_lrg_Click(object sender, EventArgs e)
        {
            lanza_ltasas();
        }

        private void btt_cancelar_ts_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rpt_Tasas_Load(object sender, EventArgs e)
        {
            Iniciar_ltasas();
        }

        void Iniciar_ltasas()
        {
            tb_d_ej.Text = "0";
            tb_h_ej.Text = "9999";
            tb_d_cod.Text = "";
            tb_h_cod.Text = "ZZZZZ";

        }
    }
}
