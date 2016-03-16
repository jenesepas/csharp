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
    public partial class Rpt_Registros : Form
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
        public List<Registro> _registros = new List<Registro>();

        public Rpt_Registros()
        {
            InitializeComponent();
        }

        public void lanza_lreg()
        {
            try
            {
                char t_cte = ' ';
                if (rb_cte_lrg.Checked == true)
                    t_cte = 'C';
                else if (rb_titular_lrg.Checked == true)
                    t_cte = 'T';

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
                _registros.AddRange(Reg_Opera.Buscar_lreg(deleg, Convert.ToInt32(tb_d_rg.Text), Convert.ToInt32(tb_h_rg.Text),
                                    t_cte, Convert.ToInt32(tb_d_cte.Text), Convert.ToInt32(tb_h_cte.Text)));

                if (_registros.Count == 0)
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
            // Calculate the number of lines per page.
            linesPerPage = 55; //Convert.ToInt32(ev.MarginBounds.Height /printFont.GetHeight(ev.Graphics));
            n_pag++;
            n_lineas = 0;
            //short pinta_deleg=0;
            char deleg_old='Z'; //para cambio de cab. de delegacion

            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (n_lineas * printFont.GetHeight(ev.Graphics));

            ev.Graphics.DrawRectangle(new Pen(Color.Black, 1), xPos, yPos, xPos + 60, yPos + 50);
            printFont = new Font("Arial", 16, FontStyle.Bold);
            ev.Graphics.DrawString("ASEGEST", printFont, Brushes.Black, xPos, yPos + 30);
            ev.Graphics.DrawString("YECMUR", printFont, Brushes.Black, xPos, yPos + 60);
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 100, xPos + 750, yPos + 100);            

            printFont = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            ev.Graphics.DrawString("LISTADO DE REGISTROS:", printFont, Brushes.Black, xPos + 250, yPos + 120);

            n_lineas = n_lineas + 5;
            yPos = yPos + 120;
            
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
                    printFont = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
                    ev.Graphics.DrawString("Delegación:   " + n_deleg, printFont, Brushes.Black, xPos, yPos + 30);                    

                    printFont = new Font("Arial", 10, FontStyle.Bold);
                    ev.Graphics.DrawString("N.REG.", printFont, Brushes.Black, xPos, yPos + 60);
                    ev.Graphics.DrawString("F.ENTREGA", printFont, Brushes.Black, xPos + 55, yPos + 60);
                    ev.Graphics.DrawString("CLIENTE", printFont, Brushes.Black, xPos + 140, yPos + 60);
                    ev.Graphics.DrawString("TITULAR", printFont, Brushes.Black, xPos + 290, yPos + 60);
                    ev.Graphics.DrawString("SECCION", printFont, Brushes.Black, xPos + 440, yPos + 60);
                    ev.Graphics.DrawString("TRAMITE", printFont, Brushes.Black, xPos + 555, yPos + 60);
                    ev.Graphics.DrawString("ESTADO", printFont, Brushes.Black, xPos + 690, yPos + 60);
                    ev.Graphics.DrawLine(new Pen(Color.Black, 2), xPos, yPos + 80, xPos + 750, yPos + 80);

                    n_lineas = n_lineas + 4;
                    yPos = yPos + 80;
                    deleg_old = _registros.ElementAt(pos_reg).delegacion;
                }
                
                

                
                
                //lineas
                printFont = new Font("Arial", 10, FontStyle.Regular);
                ev.Graphics.DrawString(Convert.ToString(_registros.ElementAt(pos_reg).n_reg), printFont, Brushes.Black, xPos, yPos + 10);
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).fec_ent.ToString("dd/MM/yyyy"), printFont, Brushes.Black, xPos+65, yPos + 10);
                string n_cte = Reg_Opera.Calcular_nom_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_cte), 'C'); 
                ev.Graphics.DrawString(n_cte, printFont, Brushes.Black, xPos+140, yPos + 10);
                string n_tit = Reg_Opera.Calcular_nom_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_titular), 'T');
                ev.Graphics.DrawString(n_tit, printFont, Brushes.Black, xPos+290, yPos + 10);
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).seccion, printFont, Brushes.Black, xPos + 440, yPos + 10);
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).t_tramite.Substring(0,19), printFont, Brushes.Black, xPos + 555, yPos + 10);
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).estado.Substring(0,9), printFont, Brushes.Black, xPos + 690, yPos + 10);
                
                
                yPos = yPos + 30;
                pos_reg++;
                n_lineas = n_lineas + 2;
            }

            //pie
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, 1120, xPos + 750, 1120);
            string line = "Pag. " + Convert.ToString(n_pag);
            ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 350, 1125);

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

        private void btt_imp_lrg_Click(object sender, EventArgs e)
        {
            lanza_lreg();
        }

        
        void Btt_cancelar_lrgClick(object sender, EventArgs e)
        {
        	this.Close();
        }
        
        void Rpt_RegistrosLoad(object sender, EventArgs e)
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
            tb_d_rg.Text = "0";
            tb_h_rg.Text = "999999";
            tb_d_cte.Text ="0";
            tb_h_cte.Text = "999999";
            //tb_exp_rg.Clear();
            //tb_fra_rg.Clear();
            //dgv_regs.DataSource = null;
            //dgv_regs.Refresh();
            
        }

        private void btt_buscar_lrg_Click(object sender, EventArgs e)
        {

            char t_cte = ' ';
            if (rb_cte_lrg.Checked == true)
                t_cte = 'C';
            else if (rb_titular_lrg.Checked == true)
                t_cte = 'T';

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
            else if (rb_titular_lrg.Checked == true)
                t_cte = 'T';

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
