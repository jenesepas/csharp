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
    public partial class Rpt_RegAS : Form
    {
        private Font printFont;        
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();

        private int linesPerPage = 0;
        private int xPos = 0;
        private int yPos = 0;
        private int n_lineas = 0;
        private float leftMargin = 0;
        private float topMargin = 0;
       
        short pos_reg = 0;
        short n_pag = 0;        
        List<Rg_mes_secc> _registros = new List<Rg_mes_secc>();
             
        string seccion;
        string estado;
        int[] impor_meses = new int[12];
        int[] timpor_meses = new int[12];
        int tacum=0;
        short i;
        //short y;
        short year;
        char deleg = ' ';
        string ndeleg = "";
        string[] secciones = { "Hacienda", "Seg. Social", "Extranjería", "Conductores", "Vehículos", "Transporte", "Sanciones Tráfico", "Escrituras", "Herencias", "Varios" };
        
        public Rpt_RegAS()
        {
            InitializeComponent();
        }

        public void lanza_lfra()
        {

            try
            {

                deleg = ' ';
                if (rb_y_lrg.Checked == true)
                    deleg = 'Y';
                else
                {
                    if (rb_m_lrg.Checked == true)
                        deleg = 'M';
                    else if (rb_a_lrg.Checked == true)
                        deleg = 'A';
                }
                seccion = cb_secc.Text.Trim();
                estado = cb_estado_lrg.Text.Trim();
                year = Convert.ToInt16(tb_year.Text);

                //vacio lista de registros
                _registros.Clear();                                                

                //si seccion no vacia = elegimos 1 seccion
                if (!string.IsNullOrWhiteSpace(seccion))
                {
                    impor_meses = (Reg_Opera.Reg_Acum_Mes_Seccion(deleg, year, seccion, estado, 0));
                    _registros.Add(Asigna_rg_acum(seccion, impor_meses));
                    //for (i = 0; i <= 11; i++)
                    //{
                    //    MessageBox.Show("Para la sección " + seccion + " en el mes " + (i + 1) + " hubo " + impor_meses[i] + " registros.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
                //para todas las secciones
                else
                {
                    //sacamos los acumulados(12) x cada seccion(10)
                    for (i = 0; i <= 9; i++)
                    {
                        impor_meses = (Reg_Opera.Reg_Acum_Mes_Seccion(deleg, year, secciones[i], estado, 0));                                                
                        _registros.Add(Asigna_rg_acum(secciones[i], impor_meses));
                    }
                }



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
            //int id_new = 0;
            
            //Pinta cabecera
            xPos = Convert.ToInt32(leftMargin);
            yPos = Convert.ToInt32(topMargin); //+ (n_lineas * printFont.GetHeight(ev.Graphics));

            ev.Graphics.DrawRectangle(new Pen(Color.Black, 1), xPos, yPos, xPos + 60, yPos + 50);
            printFont = new Font("Arial", 16, FontStyle.Bold);
            ev.Graphics.DrawString("ASEGEST", printFont, Brushes.Black, xPos, yPos + 10);
            ev.Graphics.DrawString("YECMUR", printFont, Brushes.Black, xPos, yPos + 40);
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 70, xPos + 1080, yPos + 70);

            string titulo = "REGISTROS ACUMULADOS POR MESES Y SECCION DEL AÑO: "+ tb_year.Text;
            

            switch (deleg)
            {
                case 'Y':
                    ndeleg=" - (Deleg.: Yecla)";
                    break;
                case 'M':
                    ndeleg=" - (Deleg.: Murcia)";
                    break;
                case 'A':
                    ndeleg=" - (Deleg.: Albacete)";
                    break;
            }
            if (estado != "")
                ndeleg = ndeleg + " - (" + estado + ")";

            printFont = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            ev.Graphics.DrawString(titulo, printFont, Brushes.Black, xPos + 100, yPos + 130);
            printFont = new Font("Arial", 12, FontStyle.Bold | FontStyle.Regular);
            ev.Graphics.DrawString(ndeleg, printFont, Brushes.Black, xPos + 780, yPos + 130);

            n_lineas = n_lineas + 2;
            yPos = yPos + 150;
           

            printFont = new Font("Arial", 12, FontStyle.Bold);
            ev.Graphics.DrawString("SECCIÓN", printFont, Brushes.Black, xPos, yPos + 50);
            ev.Graphics.DrawString("ENE.", printFont, Brushes.Black, xPos + 150, yPos + 50);
            ev.Graphics.DrawString("FEB.", printFont, Brushes.Black, xPos + 230, yPos + 50);
            ev.Graphics.DrawString("MAR.", printFont, Brushes.Black, xPos + 310, yPos + 50);
            ev.Graphics.DrawString("ABR.", printFont, Brushes.Black, xPos + 390, yPos + 50);
            ev.Graphics.DrawString("MAY.", printFont, Brushes.Black, xPos + 470, yPos + 50);
            ev.Graphics.DrawString("JUN.", printFont, Brushes.Black, xPos + 550, yPos + 50);
            ev.Graphics.DrawString("JUL.", printFont, Brushes.Black, xPos + 630, yPos + 50);
            ev.Graphics.DrawString("AGO.", printFont, Brushes.Black, xPos + 710, yPos + 50);
            ev.Graphics.DrawString("SEP.", printFont, Brushes.Black, xPos + 790, yPos + 50);
            ev.Graphics.DrawString("OCT.", printFont, Brushes.Black, xPos + 870, yPos + 50);
            ev.Graphics.DrawString("NOV.", printFont, Brushes.Black, xPos + 950, yPos + 50);
            ev.Graphics.DrawString("DIC.", printFont, Brushes.Black, xPos + 1030, yPos + 50);
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos + 70, xPos + 1080, yPos + 70);

            n_lineas = n_lineas + 2;
            yPos = yPos + 70;


            while ((pos_reg < _registros.Count)) // && (n_lineas < linesPerPage))
            {
                //lineas                                
                printFont = new Font("Arial", 12, FontStyle.Bold);                
                ev.Graphics.DrawString(_registros.ElementAt(pos_reg).seccion, printFont, Brushes.Black, xPos, yPos + 10);

                printFont = new Font("Arial", 10, FontStyle.Regular);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).ene), printFont, Brushes.Black, xPos + 200, yPos + 10, drawFormat);                    
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).feb), printFont, Brushes.Black, xPos + 280, yPos + 10, drawFormat);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).mar), printFont, Brushes.Black, xPos + 360, yPos + 10, drawFormat);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).abr), printFont, Brushes.Black, xPos + 440, yPos + 10, drawFormat);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).may), printFont, Brushes.Black, xPos + 520, yPos + 10, drawFormat);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).jun), printFont, Brushes.Black, xPos + 600, yPos + 10, drawFormat);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).jul), printFont, Brushes.Black, xPos + 680, yPos + 10, drawFormat);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).ago), printFont, Brushes.Black, xPos + 760, yPos + 10, drawFormat);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).sep), printFont, Brushes.Black, xPos + 840, yPos + 10, drawFormat);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).oct), printFont, Brushes.Black, xPos + 920, yPos + 10, drawFormat);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).nov), printFont, Brushes.Black, xPos + 1000, yPos + 10, drawFormat);
                ev.Graphics.DrawString(string.Format("{0:##,##0}", _registros.ElementAt(pos_reg).dic), printFont, Brushes.Black, xPos + 1080, yPos + 10, drawFormat);
                    
                //sumatorio para acumulado
                timpor_meses[0]=timpor_meses[0] + _registros.ElementAt(pos_reg).ene;
                timpor_meses[1]=timpor_meses[1] + _registros.ElementAt(pos_reg).feb;
                timpor_meses[2]=timpor_meses[2] + _registros.ElementAt(pos_reg).mar;
                timpor_meses[3]=timpor_meses[3] + _registros.ElementAt(pos_reg).abr;
                timpor_meses[4]=timpor_meses[4] + _registros.ElementAt(pos_reg).may;
                timpor_meses[5]=timpor_meses[5] + _registros.ElementAt(pos_reg).jun;
                timpor_meses[6]=timpor_meses[6] + _registros.ElementAt(pos_reg).jul;
                timpor_meses[7]=timpor_meses[7] + _registros.ElementAt(pos_reg).ago;
                timpor_meses[8]=timpor_meses[8] + _registros.ElementAt(pos_reg).sep;
                timpor_meses[9]=timpor_meses[9] + _registros.ElementAt(pos_reg).oct;
                timpor_meses[10]=timpor_meses[10] + _registros.ElementAt(pos_reg).nov;
                timpor_meses[11]=timpor_meses[11] + _registros.ElementAt(pos_reg).dic;


                yPos = yPos + 40;
                n_lineas = n_lineas + 3;

                //acumulado final 
                if (pos_reg == _registros.Count - 1)
                {
                    printFont = new Font("Arial", 10, FontStyle.Bold);
                    ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, yPos, xPos + 1080, yPos);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[0]), printFont, Brushes.Black, xPos + 200, yPos + 10, drawFormat);                    
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[1]), printFont, Brushes.Black, xPos + 280, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[2]), printFont, Brushes.Black, xPos + 360, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[3]), printFont, Brushes.Black, xPos + 440, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[4]), printFont, Brushes.Black, xPos + 520, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[5]), printFont, Brushes.Black, xPos + 600, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[6]), printFont, Brushes.Black, xPos + 680, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[7]), printFont, Brushes.Black, xPos + 760, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[8]), printFont, Brushes.Black, xPos + 840, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[9]), printFont, Brushes.Black, xPos + 920, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[10]), printFont, Brushes.Black, xPos + 1000, yPos + 10, drawFormat);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", timpor_meses[11]), printFont, Brushes.Black, xPos + 1080, yPos + 10, drawFormat);

                    for (i = 0; i <= 11; i++)
                    {
                        tacum = tacum + timpor_meses[i];
                        
                    }

                    printFont = new Font("Arial", 12, FontStyle.Bold);
                    ev.Graphics.DrawString("Acumulado Total: ", printFont, Brushes.Black, xPos + 10, yPos + 50);
                    ev.Graphics.DrawString(string.Format("{0:##,##0}", tacum), printFont, Brushes.Black, xPos + 250, yPos + 50, drawFormat);
                    
                    yPos = yPos + 40;
                    n_lineas = n_lineas + 4;
                }                

                //sig. linea de registro.
                pos_reg++;

            }

            //pie
            ev.Graphics.DrawLine(new Pen(Color.Black, 1), xPos, 800, xPos + 1080, 800);
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

        private void btt_imp_ac_rg_s_Click(object sender, EventArgs e)
        {
            lanza_lfra();
            Iniciar_lreg();
            //this.Close();
        }


        private void btt_cancelar_ac_rg_s_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rpt_RegAS_Load(object sender, EventArgs e)
        {
            Iniciar_lreg();
        }

        void Iniciar_lreg()
        {
            rb_y_lrg.Checked = false;
            rb_m_lrg.Checked = false;
            rb_y_lrg.Checked = false;

            deleg = General.delegacion;
            if (deleg == 'Y')
                rb_y_lrg.Checked = true;
            else
            {
                if (deleg == 'M')
                    rb_m_lrg.Checked = true;
                else rb_a_lrg.Checked = true;
            }

            cb_secc.ResetText();
            cb_estado_lrg.ResetText();
            //dtp_d_ffra.Value = Convert.ToDateTime("01/01/" + DateTime.Today.Year.ToString());
            tb_year.Text = DateTime.Today.Year.ToString();
            
            //inicio vector
            for (i = 0; i <= 11; i++)
            {
                impor_meses[i] = 0;
                timpor_meses[i] = 0;
            }
            tacum = 0;
            
        }

        public static Rg_mes_secc Asigna_rg_acum(string pseccion, int[] pimpor_meses)
        {

            Rg_mes_secc _rg_mes_secc = new Rg_mes_secc();

            _rg_mes_secc.seccion = pseccion; 
            _rg_mes_secc.ene = pimpor_meses[0];
            _rg_mes_secc.feb = pimpor_meses[1];
            _rg_mes_secc.mar = pimpor_meses[2];
            _rg_mes_secc.abr = pimpor_meses[3];
            _rg_mes_secc.may = pimpor_meses[4];
            _rg_mes_secc.jun = pimpor_meses[5];
            _rg_mes_secc.jul = pimpor_meses[6];
            _rg_mes_secc.ago = pimpor_meses[7];
            _rg_mes_secc.sep = pimpor_meses[8];
            _rg_mes_secc.oct = pimpor_meses[9];
            _rg_mes_secc.nov = pimpor_meses[10];
            _rg_mes_secc.dic = pimpor_meses[11];

            return _rg_mes_secc;
        }

              

        



        //private void cb_secc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int seleccionado = Convert.ToInt32(((ComboBox)sender).SelectedIndex);
        //    // ver si le podemos pasar la lista entera o item a item
        //    switch (seleccionado)
        //    {
        //        case 0: //seccion = hacienda
        //            this.cb_tram.Items.Clear();
        //            this.cb_tram.Items.Add("Certificados Hacienda");
        //            this.cb_tram.Text = "";//"Certificados Hacienda"; //el text visible = 1er. item
        //            this.cb_tram.Items.Add("Exenciones Hacienda");
        //            this.cb_tram.Items.Add("Aplazamiento Deudas");
        //            this.cb_tram.Items.Add("Requerimientos Hacienda");
        //            this.cb_tram.Items.Add("Registro de Renta");
        //            this.cb_tram.Items.Add("Registros");
        //            this.cb_tram.Items.Add("Censos");
        //            break;
        //        case 1: //seccion = s.s
        //            this.cb_tram.Items.Clear();
        //            this.cb_tram.Items.Add("Altas RETA");
        //            this.cb_tram.Text = "";//"Altas RETA"; //el text visible = 1er. item
        //            this.cb_tram.Items.Add("Bajas RETA");
        //            this.cb_tram.Items.Add("Altas Empleado/a Hogar");
        //            this.cb_tram.Items.Add("Bajas Empleado/a Hogar");
        //            this.cb_tram.Items.Add("Certificados S.S.");
        //            this.cb_tram.Items.Add("Asignación NAF");
        //            this.cb_tram.Items.Add("URE");
        //            break;
        //        case 2: //extrang.
        //            this.cb_tram.Items.Clear();
        //            this.cb_tram.Items.Add("Nacionalidad");
        //            this.cb_tram.Text = " ";//Nacionalidad";
        //            this.cb_tram.Items.Add("Otros");
        //            break;
        //        case 3: //conductores 
        //            this.cb_tram.Items.Clear();
        //            this.cb_tram.Items.Add("Renovación Permiso");
        //            this.cb_tram.Text = " ";//"Renovación Permiso";
        //            this.cb_tram.Items.Add("Duplicado Permiso");
        //            this.cb_tram.Items.Add("Canje Permiso");
        //            break;
        //        case 4: //vehiculos 
        //            this.cb_tram.Items.Clear();
        //            this.cb_tram.Items.Add("Duplicado Permiso Circulación");
        //            this.cb_tram.Text = " ";//"Duplicado Permiso Circulación";
        //            this.cb_tram.Items.Add("Informe Tráfico");
        //            this.cb_tram.Items.Add("Transferencias");
        //            this.cb_tram.Items.Add("Transferencia Agrícola");
        //            this.cb_tram.Items.Add("Matriculación");
        //            this.cb_tram.Items.Add("Notificación Venta");
        //            this.cb_tram.Items.Add("Baja Temporal");
        //            this.cb_tram.Items.Add("Reserva Dominio");
        //            break;
        //        case 5:
        //        case 6: // transporte
        //            this.cb_tram.Items.Clear();
        //            this.cb_tram.Items.Add("Pendiente Cliente");
        //            this.cb_tram.Text = " ";//"Pendiente Cliente";
        //            this.cb_tram.Items.Add("Pendiente Gestoría");
        //            this.cb_tram.Items.Add("En Trámite");
        //            this.cb_tram.Items.Add("Terminado");
        //            this.cb_tram.Items.Add("Anulado");
        //            break;
        //        /*
        //        case 6: // serv. trafico
        //            this.cb_tram.Items.Clear();
        //            this.cb_tram.Items.Add("Nacionalidad");
        //            this.cb_tram.Text = "Nacionalidad";
        //            this.cb_tram.Items.Add("Otros");
        //            break;
        //        */

        //        case 7:
        //        case 8: // escritura
        //            this.cb_tram.Items.Clear();
        //            break;


        //        case 9: // Varios
        //            this.cb_tram.Items.Clear();
        //            this.cb_tram.Items.Add("Varios");
        //            this.cb_tram.Text = " ";//"Varios";                    
        //            break;
        //        default:
        //            break;
        //    }
        //}
        
       



    }
}
