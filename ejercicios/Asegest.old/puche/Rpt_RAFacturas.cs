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
    public partial class Rpt_RAFacturas : Form
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
        //string secc_int;
        //string estado;
        public List<Fras_Ctes> _registros = new List<Fras_Ctes>();
        string ClienteFacturado;
        decimal base_imp = 0;
        decimal imp_iva = 0;
        decimal tot_fra = 0;
        decimal simpor1 = 0;
        decimal sc_base_imp = 0;
        decimal sc_imp_iva = 0;
        decimal sc_tasas = 0;
        decimal sc_tot_fra = 0;
        decimal sd_base_imp = 0;
        decimal sd_imp_iva = 0;
        decimal sd_tasas = 0;
        decimal sd_tot_fra = 0;
        decimal[] importes = new decimal[2];

        public Rpt_RAFacturas()
        {
            InitializeComponent();
        }

        public void lanza_lfra()
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
                char deleg = ' ';
                if (rb_y_lrg.Checked == true)
                    deleg = 'Y';
                else
                {
                    if (rb_m_lrg.Checked == true)
                        deleg = 'M';
                    else if (rb_a_lrg.Checked == true)
                        deleg = 'A';
                }
                //secc_int = cb_secc_lrg.Text.Trim();
                //estado = cb_estado_lrg.Text.Trim();

                _registros.Clear();
                _registros.AddRange(Reg_Opera.Buscar_rfra_cte(deleg, Convert.ToInt32(tb_d_fra.Text), Convert.ToInt32(tb_h_fra.Text),dtp_d_ffra.Value, dtp_h_ffra.Value,
                                    t_cte, Convert.ToInt32(tb_d_cte.Text), Convert.ToInt32(tb_h_cte.Text)));

                if (_registros.Count == 0)
                    MessageBox.Show("No se obtuvo ningún registro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    printDocument1.DefaultPageSettings.Landscape = true;
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
            topMargin = 20;//ev.MarginBounds.Top;
            StringFormat drawFormat = new StringFormat();            
            drawFormat.Alignment = StringAlignment.Far;
            string line;
            // Calculate the number of lines per page.
            linesPerPage = 43; //Convert.ToInt32(ev.MarginBounds.Height /printFont.GetHeight(ev.Graphics));
            n_pag++;
            n_lineas = 0;
            int id_new = 0;
            //char deleg_old = 'Z'; //para cambio de cab. de delegacion
            //char deleg_new = deleg_old;
            base_imp = 0;
            imp_iva = 0;
            tot_fra = 0;
            simpor1 = 0;
            sc_base_imp = 0;
            sc_imp_iva = 0;
            sc_tasas = 0;
            sc_tot_fra = 0;
            sd_base_imp = 0;
            sd_imp_iva = 0;
            sd_tasas = 0;
            sd_tot_fra = 0;
            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (n_lineas * printFont.GetHeight(ev.Graphics));

            ev.Graphics.DrawRectangle(new Pen(Color.Black, 1), xPos, yPos, xPos + 60, yPos + 50);
            printFont = new Font("Arial", 16, FontStyle.Bold);
            ev.Graphics.DrawString("ASEGEST", printFont, Brushes.Black, xPos, yPos + 10);
            ev.Graphics.DrawString("YECMUR", printFont, Brushes.Black, xPos, yPos + 40);
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 70, xPos + 1050, yPos + 70);

            string titulo = "REGISTRO DE FACTURAS X CLIENTE: ";
            /*
            if (secc_int != "")
                titulo = titulo + secc_int;
            if (estado != "")
                titulo = titulo + " " + estado;
            */
            printFont = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            ev.Graphics.DrawString(titulo, printFont, Brushes.Black, xPos + 350, yPos + 100);

            n_lineas = n_lineas + 2;
            yPos = yPos + 100;

            //printFont = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
            //ev.Graphics.DrawString("Delegación:   " + n_deleg, printFont, Brushes.Black, xPos, yPos + 30);

            printFont = new Font("Arial", 10, FontStyle.Bold);
            ev.Graphics.DrawString("T", printFont, Brushes.Black, xPos, yPos + 50);
            ev.Graphics.DrawString("ID_CTE", printFont, Brushes.Black, xPos + 20, yPos + 50);
            ev.Graphics.DrawString("NOMBRE CLIENTE", printFont, Brushes.Black, xPos + 70, yPos + 50);
            ev.Graphics.DrawString("BASE", printFont, Brushes.Black, xPos + 560, yPos + 50);
            ev.Graphics.DrawString("%IVA", printFont, Brushes.Black, xPos + 650, yPos + 50);
            ev.Graphics.DrawString("IMP.IVA", printFont, Brushes.Black, xPos + 720, yPos + 50);
            ev.Graphics.DrawString("TASAS", printFont, Brushes.Black, xPos + 830, yPos + 50);
            ev.Graphics.DrawString("TOTAL FRA.", printFont, Brushes.Black, xPos + 930, yPos + 50);

            ev.Graphics.DrawLine(new Pen(Color.Black, 2), xPos, yPos + 70, xPos + 1050, yPos + 70);

            n_lineas = n_lineas + 2;
            yPos = yPos + 70;
            

            while ((pos_reg < _registros.Count) && (n_lineas < linesPerPage))
            {                                                
                //lineas                
                ClienteFacturado = Reg_Opera.Calcular_nom_cte(Convert.ToString(_registros.ElementAt(pos_reg).id), _registros.ElementAt(pos_reg).t_cte_fra);

                simpor1 = 0;
                importes[0] = 0;
                importes[1] = 0;
                //sacamos los importes con iva de linfac a simpor1; los sin iva ya estan acumulados en campo tasa.               
                importes = Linfac_Opera.Calcular_importes_linfac(_registros.ElementAt(pos_reg).factura);
                simpor1 = importes[1];

                base_imp = _registros.ElementAt(pos_reg).base_imp + simpor1;
                imp_iva = ((base_imp * _registros.ElementAt(pos_reg).p_iva) / 100);
                tot_fra = base_imp + imp_iva + _registros.ElementAt(pos_reg).tasa;

                
                sc_base_imp = sc_base_imp + base_imp;
                sc_imp_iva = sc_imp_iva + imp_iva;
                sc_tasas = sc_tasas + _registros.ElementAt(pos_reg).tasa;
                sc_tot_fra = sc_tot_fra + tot_fra;
                
                //sacamos el sig. id                
                if (pos_reg < _registros.Count - 1)
                    id_new = _registros.ElementAt(pos_reg + 1).id;
                /*
                else 
                    deleg_new='Z'; //entra siempre
                */
                //si la sig. linea es del mismo id, no la pintamos y acumulamos.
                if (_registros.ElementAt(pos_reg).id != id_new | (pos_reg == _registros.Count - 1))
                { 
                    printFont = new Font("Arial", 10, FontStyle.Regular);
                    //ev.Graphics.DrawLine(new Pen(Color.Black, 2), xPos, yPos + 10, xPos + 1050, yPos + 10);
                    ev.Graphics.DrawString(Convert.ToString(_registros.ElementAt(pos_reg).t_cte_fra), printFont, Brushes.Black, xPos, yPos + 10);
                    ev.Graphics.DrawString(Convert.ToString(_registros.ElementAt(pos_reg).id), printFont, Brushes.Black, xPos + 70, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(ClienteFacturado, printFont, Brushes.Black, xPos + 70, yPos + 10);
                    ev.Graphics.DrawString(string.Format("{0:###,##0.00}", sc_base_imp), printFont, Brushes.Black, xPos + 600, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##0}", _registros.ElementAt(pos_reg).p_iva), printFont, Brushes.Black, xPos + 690, yPos + 10, drawFormat);                    
                    ev.Graphics.DrawString(string.Format("{0:###,##0.00}", sc_imp_iva), printFont, Brushes.Black, xPos + 780, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:###,##0.00}", sc_tasas), printFont, Brushes.Black, xPos + 880, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:###,##0.00}", sc_tot_fra), printFont, Brushes.Black, xPos + 1010, yPos + 10, drawFormat);
                    ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 30, xPos + 1050, yPos + 30);

                    sd_base_imp = sd_base_imp + sc_base_imp;
                    sd_imp_iva = sd_imp_iva + sc_imp_iva;
                    sd_tasas = sd_tasas + sc_tasas;
                    sd_tot_fra = sd_tot_fra + sc_tot_fra;
                    sc_base_imp = 0;
                    sc_imp_iva = 0;
                    sc_tasas = 0;
                    sc_tot_fra = 0;
                    
                    yPos = yPos + 40;
                    n_lineas = n_lineas + 3; 

                    //acumulado final.
                    if (pos_reg == _registros.Count - 1)
                    {
                        printFont = new Font("Arial", 10, FontStyle.Bold);
                        ev.Graphics.DrawLine(new Pen(Color.Black, 2), xPos, yPos + 10, xPos + 1050, yPos + 10);
                        ev.Graphics.DrawString(string.Format("{0:###,##0.00}", sd_base_imp), printFont, Brushes.Black, xPos + 600, yPos + 20, drawFormat);
                        ev.Graphics.DrawString(string.Format("{0:###,##0.00}", sd_imp_iva), printFont, Brushes.Black, xPos + 780, yPos + 20, drawFormat);
                        ev.Graphics.DrawString(string.Format("{0:###,##0.00}", sd_tasas), printFont, Brushes.Black, xPos + 880, yPos + 20, drawFormat);
                        ev.Graphics.DrawString(string.Format("{0:###,##0.00}", sd_tot_fra), printFont, Brushes.Black, xPos + 1010, yPos + 20, drawFormat);

                        yPos = yPos + 30;
                        n_lineas = n_lineas + 3;
                    }
                }

                //sig. linea de registro.
                pos_reg++;
               
            }

            //pie
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, 800, xPos + 1050, 800);
            line = "Pag. " + Convert.ToString(n_pag);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 500, 805);

            // If more lines exist, print another page.
            if (pos_reg < _registros.Count)//(line != null)
                ev.HasMorePages = true;
            else
            {
                ev.HasMorePages = false;
                pos_reg = 0; //reinicio para la impresion en papel
                n_pag = 0;
            }
        }

        private void btt_imp_lfra_Click(object sender, EventArgs e)
        {
            lanza_lfra();
            Iniciar_lreg();
            //this.Close();
        }


        private void btt_cancelar_lfra_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rpt_Facturas_Load(object sender, EventArgs e)
        {
            Iniciar_lreg();
        }

        void Iniciar_lreg()
        {
            rb_y_lrg.Checked = false;
            rb_m_lrg.Checked = false;
            rb_y_lrg.Checked = false;
            rb_cte_lrg.Checked = false;
            rb_titular_lrg.Checked = false;
            tb_d_fra.Text = "0";
            tb_h_fra.Text = "9999999";
            tb_d_cte.Text = "0";
            tb_h_cte.Text = "999999";            
            dtp_d_ffra.Value = Convert.ToDateTime("01/01/" + DateTime.Today.Year.ToString());
            dtp_h_ffra.Value = Convert.ToDateTime("31/12/" + DateTime.Today.Year.ToString());
          
            //cb_secc_lrg.ResetText();
            //cb_estado_lrg.ResetText();
            //tb_exp_rg.Clear();
            //tb_fra_rg.Clear();
            //dgv_regs.DataSource = null;
            //dgv_regs.Refresh();

        }

        private void btt_buscar_lrg_Click_1(object sender, EventArgs e)
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

        private void btt_buscar2_lrg_Click_1(object sender, EventArgs e)
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
