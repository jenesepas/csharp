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
    public partial class Rpt_RegLiq : Form
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
        int num_reg = 0;
        short pos_reg = 0;
        short n_pag = 0;
        decimal sd_tot_impor = 0;
        
        public List<Registro> _registros = new List<Registro>();

        public Rpt_RegLiq()
        {
            InitializeComponent();
        }

        public void lanza_lregliq()
        {
            try
            {                
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
                

                _registros.Clear();
                _registros.AddRange(Reg_Opera.Buscar_lreg(deleg, 0, 9999999, dtp_d_freg.Value, dtp_h_freg.Value, 'T', 0, 99999999, "", "", 'L', "Escrituras", ""));

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
            //num_reg = 0;
            //short pinta_deleg=0;
            char deleg_old = 'Z'; //para cambio de cab. de delegacion

            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (n_lineas * printFont.GetHeight(ev.Graphics));

            ev.Graphics.DrawRectangle(new Pen(Color.Black, 1), xPos, yPos, xPos + 60, yPos + 50);
            printFont = new Font("Arial", 16, FontStyle.Bold);
            ev.Graphics.DrawString("ASEGEST", printFont, Brushes.Black, xPos, yPos + 10);
            ev.Graphics.DrawString("YECMUR", printFont, Brushes.Black, xPos, yPos + 40);
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 70, xPos + 1050, yPos + 70);

            string titulo = tb_titulo.Text.Trim(); //+" - " + DateTime.Today.ToString("dd/MM/yyyy");

            printFont = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            ev.Graphics.DrawString(titulo, printFont, Brushes.Black, xPos + 200, yPos + 90);

            n_lineas = n_lineas + 5;
            yPos = yPos + 110;

            while ((pos_reg < _registros.Count) && (n_lineas < linesPerPage))
            {

                //cabecera
                string n_deleg = "";
                if (deleg_old != _registros.ElementAt(pos_reg).delegacion)
                {
                    if (_registros.ElementAt(pos_reg).delegacion == 'Y')
                        n_deleg = "YECLA";
                    else
                    {
                        if (_registros.ElementAt(pos_reg).delegacion == 'M')
                            n_deleg = "MURCIA";
                        else
                            n_deleg = "ALBACETE";
                    }

                    //printFont = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
                    //ev.Graphics.DrawString("Delegación:   " + n_deleg, printFont, Brushes.Black, xPos, yPos + 30);

                    printFont = new Font("Arial", 10, FontStyle.Bold);
                    ev.Graphics.DrawString("ASUNTO", printFont, Brushes.Black, xPos, yPos + 30);
                    ev.Graphics.DrawString("FECHA", printFont, Brushes.Black, xPos + 145, yPos + 30);
                    ev.Graphics.DrawString("COMPRADOR", printFont, Brushes.Black, xPos + 220, yPos + 30);
                    ev.Graphics.DrawString("ENTIDAD BANCARIA", printFont, Brushes.Black, xPos + 475, yPos + 30);
                    ev.Graphics.DrawString("Nº OPERACION", printFont, Brushes.Black, xPos + 680, yPos + 30);
                    ev.Graphics.DrawString("NOTARIO", printFont, Brushes.Black, xPos + 800, yPos + 30);
                    ev.Graphics.DrawString("IMPORTE", printFont, Brushes.Black, xPos + 980, yPos + 30);                   
                    ev.Graphics.DrawLine(new Pen(Color.Black, 2), xPos, yPos + 50, xPos + 1050, yPos + 50);

                    n_lineas = n_lineas + 3;
                    yPos = yPos + 50;
                    deleg_old = _registros.ElementAt(pos_reg).delegacion;
                }



                //lineas
                printFont = new Font("Arial", 10, FontStyle.Regular);
                ev.Graphics.DrawString(Convert.ToString(_registros.ElementAt(pos_reg).t_tramite), printFont, Brushes.Black, xPos, yPos + 10);
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).fec_ent.ToString("dd/MM/yyyy"), printFont, Brushes.Black, xPos + 145, yPos + 10);
                               
                string n_tit = Reg_Opera.Calcular_nom_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_titular), 'T');
                if (n_tit.Trim().Length > 30)
                    ev.Graphics.DrawString(n_tit.Substring(0, 30), printFont, Brushes.Black, xPos + 220, yPos + 10);
                else
                    ev.Graphics.DrawString(n_tit.Trim(), printFont, Brushes.Black, xPos + 220, yPos + 10);


                if (_registros.ElementAt(pos_reg).entidad.Trim().Length > 30)
                    ev.Graphics.DrawString(_registros.ElementAt(pos_reg).entidad.Substring(0, 30), printFont, Brushes.Black, xPos + 475, yPos + 10);
                else
                   ev.Graphics.DrawString(_registros.ElementAt(pos_reg).entidad.Trim(), printFont, Brushes.Black, xPos + 475, yPos + 10);                            
                
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).n_operacion, printFont, Brushes.Black, xPos + 680, yPos + 10);

                if (_registros.ElementAt(pos_reg).notario.Trim().Length > 30)
                    ev.Graphics.DrawString(_registros.ElementAt(pos_reg).notario.Substring(0, 30), printFont, Brushes.Black, xPos + 800, yPos + 10);
                else
                    ev.Graphics.DrawString(_registros.ElementAt(pos_reg).notario, printFont, Brushes.Black, xPos + 800, yPos + 10);
                
                ev.Graphics.DrawString(string.Format("{0:#,##0.00}", _registros.ElementAt(pos_reg).impor_liq), printFont, Brushes.Black, xPos + 1050, yPos + 10, drawFormat);
                               
                //ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 40, xPos + 1050, yPos + 40);

                sd_tot_impor = sd_tot_impor + _registros.ElementAt(pos_reg).impor_liq;
                yPos = yPos + 30;
                n_lineas++;
                num_reg++;

                //updateo registro a liquidado
                if (cb_liq.Checked)
                { //actualiza registro a liquidado
                    Reg_Opera.Reg_liquidado(_registros.ElementAt(pos_reg).delegacion, _registros.ElementAt(pos_reg).n_reg);
                }

                if (pos_reg == _registros.Count - 1)
                {
                    printFont = new Font("Arial", 10, FontStyle.Bold);
                    ev.Graphics.DrawLine(new Pen(Color.Black, 2), xPos, yPos + 10, xPos + 1050, yPos + 10);
                    ev.Graphics.DrawString("TOTAL ", printFont, Brushes.Black, xPos + 900, yPos + 20);
                    ev.Graphics.DrawString(string.Format("{0:###,##0.00}", sd_tot_impor), printFont, Brushes.Black, xPos + 1050, yPos + 20, drawFormat);
                    
                    yPos = yPos + 30;
                    n_lineas = n_lineas + 2;
                }

                //sig. linea de registro.
                pos_reg++;
                

            }

            //pie
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, 800, xPos + 1050, 800);
            line = "Pag. " + Convert.ToString(n_pag);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 500, 805);
            line = "Num. de Registros = " + Convert.ToString(num_reg);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 870, 805);

            // If more lines exist, print another page.
            if (pos_reg < _registros.Count)//(line != null)
                ev.HasMorePages = true;
            else
            {
                ev.HasMorePages = false;
                pos_reg = 0; //reinicio para la impresion en papel
                n_pag = 0;
                num_reg = 0;
            }
        }


        private void Rpt_RegLiq_Load(object sender, EventArgs e)
        {
            Iniciar_lregliq();
        }

        void Iniciar_lregliq()
        {
            rb_y_lrg.Checked = false;
            rb_m_lrg.Checked = false;
            rb_y_lrg.Checked = false;            
            dtp_d_freg.Value = Convert.ToDateTime("01/01/" + DateTime.Today.Year.ToString());
            dtp_h_freg.Value = Convert.ToDateTime("31/12/" + DateTime.Today.Year.ToString());
            tb_titulo.Text = "Liquidación 1er. Trimestre Grupo Vilanova Consulting, S.L. - "+ DateTime.Today.ToString("dd/MM/yyyy");
            cb_liq.Checked = false;
            sd_tot_impor = 0;
                        
        }

        private void btt_imp_lrg_Click_1(object sender, EventArgs e)
        {
            lanza_lregliq();
            //this.Close();
            Iniciar_lregliq();
        }

        private void btt_cancelar_lrg_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
       
              




    }
}
