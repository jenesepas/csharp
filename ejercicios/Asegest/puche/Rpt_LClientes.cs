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

namespace Asegest
{
    public partial class Rpt_Ctes : Form
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
        short pos_reg = 0;
        short n_pag = 0;
        public List<Cliente> _ctes = new List<Cliente>();
        
        public Rpt_Ctes()
        {
            InitializeComponent();
        }

        public void lanza_lctes()
        {
            try
            {

                char t_cte = ' ';
                if (rb_cte_lrg.Checked == true)
                    t_cte = 'C';
                else
                {
                    if (rb_titular_lrg.Checked == true)
                        t_cte = 'T';
                    else if (rb_colab_lrg.Checked == true)
                        t_cte = 'B';
                }

                _ctes.Clear();
                _ctes.AddRange(Ctes_Opera.Buscar_LCte(t_cte, Convert.ToInt32(tb_d_cte.Text), Convert.ToInt32(tb_h_cte.Text)));        //obtengo todos los ctes en ctes_opera.buscar y se lo paso a la lista			
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

                DialogResult respuesta = MessageBox.Show("¿Desea entrar en la vista previa del impreso?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (respuesta == DialogResult.Yes)
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
                MessageBox.Show("No se seleccionó ningún registro.", e1.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // The PrintPage event is raised for each page to be printed.
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs ev)
        {
            printFont = new Font("Arial", 11);
            leftMargin = 50;//ev.MarginBounds.Left;
            topMargin = 20;//ev.MarginBounds.Top;
            StringFormat drawFormat = new StringFormat();
            // Calculate the number of lines per page.
            linesPerPage = 43; //Convert.ToInt32(ev.MarginBounds.Height /printFont.GetHeight(ev.Graphics));
            n_pag++;
            n_lineas = 0;

            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (n_lineas * printFont.GetHeight(ev.Graphics));

            ev.Graphics.DrawRectangle(new Pen(Color.Black, 1), xPos, yPos, xPos + 60, yPos + 50);
            printFont = new Font("Arial", 16, FontStyle.Bold);
            ev.Graphics.DrawString("ASEGEST", printFont, Brushes.Black, xPos, yPos + 10);
            ev.Graphics.DrawString("YECMUR", printFont, Brushes.Black, xPos, yPos + 40);
            //yPos = yPos + 100;
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos+70, xPos + 1050, yPos+70);//750 vert.
            n_lineas = n_lineas + 3;



            printFont = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            ev.Graphics.DrawString("LISTADO DE CLIENTES:", printFont, Brushes.Black, xPos + 400, yPos + 85);

            //cabecera
            printFont = new Font("Arial", 10, FontStyle.Bold);
            ev.Graphics.DrawString("C/T/B", printFont, Brushes.Black, xPos, yPos + 120);
            ev.Graphics.DrawString("CODIGO", printFont, Brushes.Black, xPos + 40, yPos + 120);
            ev.Graphics.DrawString("NOMBRE", printFont, Brushes.Black, xPos + 100, yPos + 120);
            ev.Graphics.DrawString("DOCUMENTO", printFont, Brushes.Black, xPos + 400, yPos + 120);
            ev.Graphics.DrawString("DIRECCION", printFont, Brushes.Black, xPos + 600, yPos + 120);
            ev.Graphics.DrawString("C.P.", printFont, Brushes.Black, xPos + 880, yPos + 120);
            ev.Graphics.DrawString("CIUDAD", printFont, Brushes.Black, xPos + 920, yPos + 120);


            ev.Graphics.DrawString("TFNO1", printFont, Brushes.Black, xPos, yPos + 140);
            ev.Graphics.DrawString("TFNO2", printFont, Brushes.Black, xPos + 100, yPos + 140);
            ev.Graphics.DrawString("CTA.CBLE.", printFont, Brushes.Black, xPos + 200, yPos + 140);
            ev.Graphics.DrawString("P.CONTACTO", printFont, Brushes.Black, xPos + 400, yPos + 140);
            ev.Graphics.DrawString("EMAIL", printFont, Brushes.Black, xPos + 600, yPos + 140);
            ev.Graphics.DrawString("PROVINCIA", printFont, Brushes.Black, xPos + 920, yPos + 140);
            ev.Graphics.DrawLine(new Pen(Color.Black, 2), xPos, yPos + 160, xPos + 1050, yPos + 160);

            n_lineas = n_lineas + 5;

            yPos = yPos + 170;
            //lineas

            printFont = new Font("Arial", 10, FontStyle.Regular);
            while ((pos_reg < _ctes.Count) && (n_lineas < linesPerPage))
            {
                ev.Graphics.DrawString(Convert.ToString(_ctes.ElementAt(pos_reg).Tipo_cte), printFont, Brushes.Black, xPos + 10, yPos);
                ev.Graphics.DrawString(Convert.ToString(_ctes.ElementAt(pos_reg).Id_Cliente), printFont, Brushes.Black, xPos + 30, yPos);
                ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Nombre, printFont, Brushes.Black, xPos + 100, yPos);
                line = _ctes.ElementAt(pos_reg).Tipo_docu.Trim() + ": " + _ctes.ElementAt(pos_reg).Documento.Trim() + _ctes.ElementAt(pos_reg).Letra;
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 400, yPos);
                ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Direccion, printFont, Brushes.Black, xPos + 600, yPos);
                ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Cpostal, printFont, Brushes.Black, xPos + 880, yPos);
                ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Ciudad, printFont, Brushes.Black, xPos + 920, yPos);

                ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Telf1, printFont, Brushes.Black, xPos, yPos + 20);
                ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Telf2, printFont, Brushes.Black, xPos + 100, yPos + 20);
                ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).cta_cble, printFont, Brushes.Black, xPos + 200, yPos + 20);
                ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Pers_cont, printFont, Brushes.Black, xPos + 400, yPos + 20);
                ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Email, printFont, Brushes.Black, xPos + 650, yPos + 20);
                ev.Graphics.DrawString(_ctes.ElementAt(pos_reg).Provin, printFont, Brushes.Black, xPos + 920, yPos + 20);

                ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 40, xPos + 1050, yPos + 40);
                yPos = yPos + 50;
                pos_reg++;
                n_lineas = n_lineas + 3;
            }

            //pie
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, 800, xPos + 1050, 800);
            line = "Pag. " + Convert.ToString(n_pag);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 500, 805);

            // If more lines exist, print another page.
            if (pos_reg < _ctes.Count)//(line != null)
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
            lanza_lctes();
            this.Close();
        }

        private void btt_cancelar_ts_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rpt_Ctes_Load(object sender, EventArgs e)
        {
            Iniciar_lctes();
        }

        void Iniciar_lctes()
        {
            rb_cte_lrg.Checked = false;
            rb_titular_lrg.Checked = false;
            rb_colab_lrg.Checked = false;            
            tb_d_cte.Text = "0";
            tb_h_cte.Text = "999999";

        }


        private void btt_buscar_lrg_Click(object sender, EventArgs e)
        {

            char t_cte = ' ';
            if (rb_cte_lrg.Checked == true)
                t_cte = 'C';
            else
            {
                if (rb_titular_lrg.Checked == true)
                    t_cte = 'T';
                else if (rb_colab_lrg.Checked == true)
                    t_cte = 'B';
            }
            Frm_busca_cte buscar = new Frm_busca_cte('R', t_cte);
            buscar.ShowDialog();

            if (buscar.id_cteSeleccionado != 0)
            {
                tb_d_cte.Text = Convert.ToString(buscar.id_cteSeleccionado);
                //tb_n_cte_rg.Text = Reg_Opera.Calcular_nom_cte(tb_cte_rg.Text, 'C');
            }
        }

        private void btt_buscar2_lrg_Click(object sender, EventArgs e)
        {
            char t_cte = ' ';
            if (rb_cte_lrg.Checked == true)
                t_cte = 'C';
            else
            {
                if (rb_titular_lrg.Checked == true)
                    t_cte = 'T';
                else if (rb_colab_lrg.Checked == true)
                    t_cte = 'B';
            }

            Frm_busca_cte buscar = new Frm_busca_cte('R', t_cte);
            buscar.ShowDialog();

            if (buscar.id_cteSeleccionado != 0)
            {
                tb_h_cte.Text = Convert.ToString(buscar.id_cteSeleccionado);
                //tb_n_cte_rg.Text = Reg_Opera.Calcular_nom_cte(tb_cte_rg.Text, 'C');
            }
        }

                



    }
}
