﻿using System;
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
        int num_reg = 0;
        short pos_reg = 0;
        short n_pag = 0;
        string secc_int;
        string estado;
        string seccion;
        string tramite;
        char est_reg;
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
                secc_int = cb_secc_lrg.Text.Trim();
                estado = cb_estado_lrg.Text.Trim();
                seccion = cb_secc.Text.Trim();
                tramite = cb_tram.Text.Trim();
                est_reg='T';
                if (cb_treg.Text == "SIN FACTURAR")
                    est_reg = 'S';
                else
                {
                    if (cb_treg.Text == "FACTURADOS")
                        est_reg = 'F';
                }

                _registros.Clear();
                _registros.AddRange(Reg_Opera.Buscar_lreg(deleg, Convert.ToInt32(tb_d_rg.Text), Convert.ToInt32(tb_h_rg.Text), dtp_d_freg.Value, dtp_h_freg.Value,
                                    t_cte, Convert.ToInt32(tb_d_cte.Text), Convert.ToInt32(tb_h_cte.Text),secc_int, estado,est_reg, seccion, tramite));
                
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
            string line;
            // Calculate the number of lines per page.
            linesPerPage = 43; //Convert.ToInt32(ev.MarginBounds.Height /printFont.GetHeight(ev.Graphics));
            n_pag++;
            n_lineas = 0;
            //num_reg = 0;
            //short pinta_deleg=0;
            char deleg_old='Z'; //para cambio de cab. de delegacion

            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (n_lineas * printFont.GetHeight(ev.Graphics));

            ev.Graphics.DrawRectangle(new Pen(Color.Black, 1), xPos, yPos, xPos + 60, yPos + 50);
            printFont = new Font("Arial", 16, FontStyle.Bold);
            ev.Graphics.DrawString("ASEGEST", printFont, Brushes.Black, xPos, yPos + 10);
            ev.Graphics.DrawString("YECMUR", printFont, Brushes.Black, xPos, yPos + 40);
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 70, xPos + 1050, yPos + 70);            

            string titulo="LISTADO DE REGISTROS: ";
            if (secc_int !="")
                titulo=titulo + secc_int;
            if (estado != "")
                titulo = titulo + " " + estado;
            //titulo con est_reg.
            titulo = titulo + " - " + cb_treg.Text.Trim();


            printFont = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            ev.Graphics.DrawString(titulo, printFont, Brushes.Black, xPos + 300, yPos + 90);

            n_lineas = n_lineas + 5;
            yPos = yPos + 90;
            
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
                    ev.Graphics.DrawString("TITULAR", printFont, Brushes.Black, xPos + 430, yPos + 60);
                    ev.Graphics.DrawString("SECCION", printFont, Brushes.Black, xPos + 730, yPos + 60);                    
                    ev.Graphics.DrawString("ESTADO", printFont, Brushes.Black, xPos + 950, yPos + 60);

                    ev.Graphics.DrawString("EXPEDIENTE", printFont, Brushes.Black, xPos, yPos + 80);
                    ev.Graphics.DrawString("COLABORADOR", printFont, Brushes.Black, xPos + 140, yPos + 80);
                    ev.Graphics.DrawString("SECC. INT./EXP. NO TL.", printFont, Brushes.Black, xPos + 430, yPos + 80);                                        
                    ev.Graphics.DrawString("TRAMITE", printFont, Brushes.Black, xPos + 730, yPos + 80);
                    ev.Graphics.DrawString("NUM.FRA.", printFont, Brushes.Black, xPos + 950, yPos + 80);
                    
                    ev.Graphics.DrawLine(new Pen(Color.Black, 2), xPos, yPos + 100, xPos + 1050, yPos + 100);

                    n_lineas = n_lineas + 6;
                    yPos = yPos + 100;
                    deleg_old = _registros.ElementAt(pos_reg).delegacion;
                }
                                
                
                
                //lineas
                printFont = new Font("Arial", 10, FontStyle.Regular);
                ev.Graphics.DrawString(Convert.ToString(_registros.ElementAt(pos_reg).n_reg), printFont, Brushes.Black, xPos, yPos + 10);
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).fec_ent.ToString("dd/MM/yyyy"), printFont, Brushes.Black, xPos+65, yPos + 10);
                string n_cte = Reg_Opera.Calcular_nom_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_cte), 'C');
                if (n_cte.Trim().Length > 33)
                    ev.Graphics.DrawString(n_cte.Substring(0, 33), printFont, Brushes.Black, xPos+140, yPos + 10);
                else
                    ev.Graphics.DrawString(n_cte.Trim(), printFont, Brushes.Black, xPos + 140, yPos + 10);

                string n_tit = Reg_Opera.Calcular_nom_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_titular), 'T');
                if (n_tit.Trim().Length > 34)
                    ev.Graphics.DrawString(n_tit.Substring(0, 34), printFont, Brushes.Black, xPos + 430, yPos + 10);
                else
                    ev.Graphics.DrawString(n_tit.Trim(), printFont, Brushes.Black, xPos + 430, yPos + 10);

                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).seccion, printFont, Brushes.Black, xPos + 730, yPos + 10);
                //ev.Graphics.DrawString(_registros.ElementAt(pos_reg).t_tramite.Substring(0,24), printFont, Brushes.Black, xPos + 780, yPos + 10);
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).estado, printFont, Brushes.Black, xPos + 950, yPos + 10);

                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).exp_tl, printFont, Brushes.Black, xPos, yPos + 30);
                string n_col = Reg_Opera.Calcular_nom_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_colabora), 'B');
                if (n_col.Trim().Length > 34)
                    ev.Graphics.DrawString(n_col.Substring(0, 34), printFont, Brushes.Black, xPos + 140, yPos + 30);                
                else
                    ev.Graphics.DrawString(n_col.Trim(), printFont, Brushes.Black, xPos + 140, yPos + 30);                

                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).seccion_int, printFont, Brushes.Black, xPos + 430, yPos + 30);
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).exp_ntl, printFont, Brushes.Black, xPos + 520, yPos + 30);
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).t_tramite, printFont, Brushes.Black, xPos + 730, yPos + 30);                                
                printFont = new Font("Arial", 10, FontStyle.Bold);
                line = "Nº Factura: " + Convert.ToString(_registros.ElementAt(pos_reg).factura);
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos + 930, yPos + 30);

                yPos = yPos + 30;
                n_lineas = n_lineas + 2;

                printFont = new Font("Arial", 10, FontStyle.Regular);
                if (_registros.ElementAt(pos_reg).observacion.Trim().Length > 0)
                {
                    string observ = "Obs: " + Convert.ToString(_registros.ElementAt(pos_reg).observacion);
                    ev.Graphics.DrawString(observ.Substring(0, 100), printFont, Brushes.Black, xPos, yPos + 20);
                    yPos = yPos + 20;
                    n_lineas++;

                    if (observ.Trim().Length > 100)
                    {
                        ev.Graphics.DrawString(observ.Substring(101), printFont, Brushes.Black, xPos + 40, yPos + 20);
                        yPos = yPos + 20;
                        n_lineas++;
                    }
                }
                ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 20, xPos + 1050, yPos + 20);

                yPos = yPos + 20;
                n_lineas++;
                pos_reg++;
                num_reg++;
                
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

        private void btt_imp_lrg_Click(object sender, EventArgs e)
        {
            lanza_lreg();
            //this.Close();
            Iniciar_lreg();
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
            cb_secc_lrg.ResetText();
            cb_estado_lrg.ResetText();
            cb_treg.Text = cb_treg.Items[0].ToString(); //"TODOS";
            dtp_d_freg.Value = Convert.ToDateTime("01/01/" + DateTime.Today.Year.ToString());
            dtp_h_freg.Value = Convert.ToDateTime("31/12/" + DateTime.Today.Year.ToString());
            cb_secc.ResetText();
            cb_tram.ResetText();
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

        private void cb_secc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccionado = Convert.ToInt32(((ComboBox)sender).SelectedIndex);
            // ver si le podemos pasar la lista entera o item a item
            switch (seleccionado)
            {
                case 0: //seccion = hacienda
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Certificados Hacienda");
                    this.cb_tram.Text = "";//"Certificados Hacienda"; //el text visible = 1er. item
                    this.cb_tram.Items.Add("Exenciones Hacienda");
                    this.cb_tram.Items.Add("Aplazamiento Deudas");
                    this.cb_tram.Items.Add("Requerimientos Hacienda");
                    this.cb_tram.Items.Add("Registro de Renta");
                    this.cb_tram.Items.Add("Registros");
                    this.cb_tram.Items.Add("Censos");
                    break;
                case 1: //seccion = s.s
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Altas RETA");
                    this.cb_tram.Text = "";//"Altas RETA"; //el text visible = 1er. item
                    this.cb_tram.Items.Add("Bajas RETA");
                    this.cb_tram.Items.Add("Altas Empleado/a Hogar");
                    this.cb_tram.Items.Add("Bajas Empleado/a Hogar");
                    this.cb_tram.Items.Add("Certificados S.S.");
                    this.cb_tram.Items.Add("Asignación NAF");
                    this.cb_tram.Items.Add("URE");
                    break;
                case 2: //extrang.
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Nacionalidad");
                    this.cb_tram.Text = " ";//Nacionalidad";
                    this.cb_tram.Items.Add("Otros");
                    break;
                case 3: //conductores 
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Renovación Permiso");
                    this.cb_tram.Text = " ";//"Renovación Permiso";
                    this.cb_tram.Items.Add("Duplicado Permiso");
                    this.cb_tram.Items.Add("Canje Permiso");
                    break;
                case 4: //vehiculos 
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Duplicado Permiso Circulación");
                    this.cb_tram.Text = " ";//"Duplicado Permiso Circulación";
                    this.cb_tram.Items.Add("Informe Tráfico");
                    this.cb_tram.Items.Add("Transferencias");
                    this.cb_tram.Items.Add("Transferencia Agrícola");
                    this.cb_tram.Items.Add("Matriculación");
                    this.cb_tram.Items.Add("Notificación Venta");
                    this.cb_tram.Items.Add("Baja Temporal");
                    this.cb_tram.Items.Add("Reserva Dominio");
                    break;
                case 5:
                case 6: // transporte
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Pendiente Cliente");
                    this.cb_tram.Text = " ";//"Pendiente Cliente";
                    this.cb_tram.Items.Add("Pendiente Gestoría");
                    this.cb_tram.Items.Add("En Trámite");
                    this.cb_tram.Items.Add("Terminado");
                    this.cb_tram.Items.Add("Anulado");
                    break;
                /*
                case 6: // serv. trafico
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Nacionalidad");
                    this.cb_tram.Text = "Nacionalidad";
                    this.cb_tram.Items.Add("Otros");
                    break;
                */

                case 7:
                case 8: // escritura
                    this.cb_tram.Items.Clear();
                    break;


                case 9: // Varios
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Varios");
                    this.cb_tram.Text = " ";//"Varios";                    
                    break;
                default:
                    break;
            }
        }
        
       
    }
}