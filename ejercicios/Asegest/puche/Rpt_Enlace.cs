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
    public partial class Rpt_Enlace : Form
    {
        //private Font printFont;
        //private StreamReader streamToPrint;
        //static string filePath;
       
        
        String line = null;
        short pos_reg = 0;
        //short n_pag = 0;
        //string secc_int;
        //string estado;
        public List<Registro> _registros = new List<Registro>();        
        decimal base_imp = 0;
        decimal imp_iva = 0;
        decimal tot_fra = 0;
        decimal imp_tasa = 0;        
        decimal imp_det = 0;
        decimal[] importes = new decimal[2];
        StreamWriter fichero_asi;
        StreamWriter fichero_fra;
        StreamWriter fichero_cte;
        //string cta_cte;
        string concepto;
        string nom_cte;
        //string dnicif;
        public char deleg;
        //string filePath;
        public Cliente Cte_a_enlazar = new Cliente();
        /* registro
        struct Cuentas
        {
            public string cta;
            public decimal importe_acu;
        }
         */ 
        public List<Cuentas> _cuentas = new List<Cuentas>();

        public Rpt_Enlace(char pdeleg)
        {
            InitializeComponent();

            //solo buscamos en la delegacion actual.
            deleg = pdeleg;
            if (deleg == 'Y')
                rb_y_lrg.Checked = true;
            else
            {
                if (deleg == 'M')
                    rb_m_lrg.Checked = true;
                else rb_a_lrg.Checked = true;
            }
            rb_y_lrg.Enabled = false;
            rb_m_lrg.Enabled = false;
            rb_a_lrg.Enabled = false;
        }

        public void Enlaza_fra()
        {
            try
            {
                int asiento=0;
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
                /*
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
                 */
                //secc_int = cb_secc_lrg.Text.Trim();
                //estado = cb_estado_lrg.Text.Trim();

                _registros.Clear();
                _registros.AddRange(Reg_Opera.Buscar_rfra(deleg, Convert.ToInt32(tb_d_fra.Text), Convert.ToInt32(tb_h_fra.Text), dtp_d_ffra.Value, dtp_h_ffra.Value,
                                    t_cte, Convert.ToInt32(tb_d_cte.Text), Convert.ToInt32(tb_h_cte.Text),'Z', 1));

                if (_registros.Count == 0)
                    MessageBox.Show("No se obtuvo ningún registro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //filePath = = "@\"" + tb_pdf.Text + "\"";                    
                    fichero_asi = File.CreateText(tb_ruta.Text + "enlace.txt"); //"c:\\temp\\csharp\\enlace.txt"
                    fichero_fra = File.CreateText(tb_ruta.Text + "enlace_fra.txt");
                    fichero_cte = File.CreateText(tb_ruta.Text + "enlace_cte.txt");
                    asiento = Convert.ToInt32(tb_n_asi.Text);
                    while (pos_reg < _registros.Count)
                    {
                        
                        if (_registros.ElementAt(pos_reg).t_cte_fra == 'C')
                        {
                            //facturar a cte.
                            //cta_cte = Reg_Opera.Sacar_cta_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_cte), 'C');
                            //nom_cte = Reg_Opera.Calcular_nom_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_cte), 'C');
                            //dnicif = Reg_Opera.Sacar_dnicif_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_cte), 'C');
                            Cte_a_enlazar = Ctes_Opera.ObtenerCliente(_registros.ElementAt(pos_reg).id_cte);
                        }
                        else
                        {
                            if (_registros.ElementAt(pos_reg).t_cte_fra == 'T') //facturar a titular.
                            {
                                //cta_cte = Reg_Opera.Sacar_cta_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_titular), 'T');
                                //nom_cte = Reg_Opera.Calcular_nom_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_titular), 'T');
                                //dnicif = Reg_Opera.Sacar_dnicif_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_titular), 'T');
                                Cte_a_enlazar = Ctes_Opera.ObtenerCliente(_registros.ElementAt(pos_reg).id_titular);
                            }
                            else //facturar a colaborador.
                            {
                                //cta_cte = Reg_Opera.Sacar_cta_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_colabora), 'B');
                                //nom_cte = Reg_Opera.Calcular_nom_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_colabora), 'B');
                                //dnicif = Reg_Opera.Sacar_dnicif_cte(Convert.ToString(_registros.ElementAt(pos_reg).id_colabora), 'B');
                                Cte_a_enlazar = Ctes_Opera.ObtenerCliente(_registros.ElementAt(pos_reg).id_colabora);
                            }
                        }
                        //Ctas cliente
                        line = "'" + Cte_a_enlazar.cta_cble.Trim() + "';'" + Cte_a_enlazar.Nombre.Trim() + "';'S';'" + Cte_a_enlazar.Documento.Trim() + Cte_a_enlazar.Letra + "';'" +
                                Cte_a_enlazar.Direccion.Trim() + "';'" + Cte_a_enlazar.Cpostal.Trim() + "';'" + Cte_a_enlazar.Ciudad.Trim() + "';'" + Cte_a_enlazar.Telf1.Trim() + "';'','','" +
                                Cte_a_enlazar.Pers_cont.Trim() + "';'" + Cte_a_enlazar.Email.Trim() + "';";
                        fichero_cte.WriteLine(line.Replace("'", "\""));


                        base_imp = 0;
                        imp_iva = 0;
                        tot_fra = 0;
                        imp_tasa = 0;
                        imp_det = 0;
                        importes[0] = 0;
                        importes[1] = 0;
                        //sacamos los importes con iva de linfac a simpor1; los sin iva ya estan acumulados en campo tasa.               
                        importes = Linfac_Opera.Calcular_importes_linfac(_registros.ElementAt(pos_reg).factura);                        

                        base_imp = _registros.ElementAt(pos_reg).dcho_col + _registros.ElementAt(pos_reg).honorarios + importes[1];
                        imp_iva = ((base_imp * _registros.ElementAt(pos_reg).p_iva) / 100);
                        imp_tasa = _registros.ElementAt(pos_reg).tasa - importes[0]; //le quitamos impor sin iva de detalles
                        tot_fra = base_imp + imp_iva + _registros.ElementAt(pos_reg).tasa;

                        //creamos fichero de fras.
                        line = "'E';'" + string.Format("{0:000000}", asiento) + "';'" + string.Format("{0:000000}", _registros.ElementAt(pos_reg).factura) + "';'" +
                            _registros.ElementAt(pos_reg).fec_fra.ToString("ddMMyyyy") + "';'" + Cte_a_enlazar.cta_cble.Trim() + "';'" + Cte_a_enlazar.Nombre.Trim() + "';'" + Cte_a_enlazar.Documento.Trim()+ Cte_a_enlazar.Letra + "';'" +
                            string.Format("{0:###,##0.00}", base_imp) + "';'" + string.Format("{0:##0}", _registros.ElementAt(pos_reg).p_iva) + "';'" + string.Format("{0:###,##0.00}", imp_iva) + "';'Varias';'"+
                            string.Format("{0:###,##0.00}", _registros.ElementAt(pos_reg).tasa) + "';'0';'0';'705000011';'S';'00';'N';'N';";
                        fichero_fra.WriteLine(line.Replace("'", "\""));

                        //Sacamos ctas de detalle
                        _cuentas = Linfac_Opera.Saca_ctas_x_impor(_registros.ElementAt(pos_reg).factura);

                        concepto = "N/FRA. " + _registros.ElementAt(pos_reg).factura + " - " + Cte_a_enlazar.Nombre.Trim().Trim();
                        line = "'D';'" + string.Format("{0:000000}", asiento) + "';'" + _registros.ElementAt(pos_reg).fec_fra.ToString("ddMM") + "';'" + Cte_a_enlazar.cta_cble.Trim() + "';'" +
                               string.Format("{0:###,##0.00}", tot_fra) + "';'" + concepto.Trim() + "';'FE';'N';'';'N';'';";
                        fichero_asi.WriteLine(line.Replace("'", "\""));//deben ser comillas dobles
                        
                        //buscamos el importe de la cta de tasa en detalles
                        imp_det = Busca_cta_det( tb_ctasa.Text.Trim()); 
                        if (_registros.ElementAt(pos_reg).tasa > 0 |  imp_det > 0)
                        {
                            line = "'H';'" + string.Format("{0:000000}", asiento) + "';'" + _registros.ElementAt(pos_reg).fec_fra.ToString("ddMM") + "';'" + tb_ctasa.Text.Trim() + "';'" +
                            string.Format("{0:###,##0.00}", imp_tasa + imp_det) + "';'" + concepto.Trim() + "';'FE';'N';'" + Cte_a_enlazar.cta_cble.Trim() + "';'N';'';";
                            fichero_asi.WriteLine(line.Replace("'", "\""));
                        }
                        imp_det = Busca_cta_det(tb_cdcol.Text.Trim());
                        if (_registros.ElementAt(pos_reg).dcho_col > 0 |  imp_det > 0)
                        {
                            line = "'H';'" + string.Format("{0:000000}", asiento) + "';'" + _registros.ElementAt(pos_reg).fec_fra.ToString("ddMM") + "';'" + tb_cdcol.Text.Trim() + "';'" +
                            string.Format("{0:###,##0.00}", _registros.ElementAt(pos_reg).dcho_col + imp_det) + "';'" + concepto.Trim() + "';'FE';'N';'" + Cte_a_enlazar.cta_cble.Trim() + "';'N';'';";
                            fichero_asi.WriteLine(line.Replace("'", "\""));
                        }
                        imp_det = Busca_cta_det(tb_chono.Text.Trim());
                        if (_registros.ElementAt(pos_reg).honorarios > 0 |  imp_det > 0)
                        {
                            line = "'H';'" + string.Format("{0:000000}", asiento) + "';'" + _registros.ElementAt(pos_reg).fec_fra.ToString("ddMM") + "';'" + tb_chono.Text.Trim() + "';'" +
                            string.Format("{0:###,##0.00}", _registros.ElementAt(pos_reg).honorarios + imp_det) + "';'" + concepto.Trim() + "';'FE';'N';'" + Cte_a_enlazar.cta_cble.Trim() + "';'N';'';";
                            fichero_asi.WriteLine(line.Replace("'", "\""));
                        }
                        if(imp_iva > 0)
                        {
                            line = "'H';'" + string.Format("{0:000000}", asiento) + "';'" + _registros.ElementAt(pos_reg).fec_fra.ToString("ddMM") + "';'" + tb_civa.Text.Trim() + "';'" +
                            string.Format("{0:###,##0.00}", imp_iva) + "';'" + concepto.Trim() + "';'FE';'N';'" + Cte_a_enlazar.cta_cble.Trim() + "';'N';'';";
                            fichero_asi.WriteLine(line.Replace("'", "\""));
                        }
                        
                        //Ver ctas de detalle: cta_suplido
                        if (_cuentas.Count > 0)
                        {
                            foreach (Cuentas pcuenta in _cuentas)
                            {
                                line = "'H';'" + string.Format("{0:000000}", asiento) + "';'" + _registros.ElementAt(pos_reg).fec_fra.ToString("ddMM") + "';'" + pcuenta.cta_cble.Trim() + "';'" +
                                string.Format("{0:###,##0.00}", pcuenta.importe_acu) + "';'" + concepto.Trim() + "';'FE';'N';'" + Cte_a_enlazar.cta_cble.Trim() + "';'N';'';";
                                fichero_asi.WriteLine(line.Replace("'", "\""));
                            }
                        }

                        //updateo facturas a enlazado
                        if (_registros.ElementAt(pos_reg).estado_fac == 'L' & Reg_Opera.Fra_listada_enlazada(_registros.ElementAt(pos_reg).factura, 1) > 0)
                        { //actualiza estado factura a enlazada
                        }
                        
                        pos_reg++;
                        //incremento n_asi                        
                        asiento++;
                        //tb_n_asi.Text = Convert.ToString(asiento);



                    }
                    fichero_cte.Close();
                    fichero_asi.Close();
                    fichero_fra.Close();
                    MessageBox.Show("Fras. enlazadas con éxito.", "Muy bien!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("No se seleccionó ningún registro.", e1.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btt_enlaza_fra_Click(object sender, EventArgs e)
        {
            Enlaza_fra();
            this.Close();
        }


        private void btt_cancelar_lfra_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rpt_Enlace_Load_1(object sender, EventArgs e)
        {
            this.Text = this.Text.Trim() + General.Saca_titulo_win();
            Iniciar_lreg();
        }

        void Iniciar_lreg()
        {
            
            rb_cte_lrg.Checked = false;
            rb_titular_lrg.Checked = false;
            rb_colab_lrg.Checked = false;
            tb_d_fra.Text = "0";
            tb_h_fra.Text = "9999999";
            tb_d_cte.Text = "0";
            tb_h_cte.Text = "999999";
            dtp_d_ffra.Value = Convert.ToDateTime("01/01/" + DateTime.Today.Year.ToString());
            dtp_h_ffra.Value = Convert.ToDateTime("31/12/" + DateTime.Today.Year.ToString());

            tb_n_asi.Text = "000000";
            tb_ctasa.Text = "705000011";
            tb_cdcol.Text = "705000012";
            tb_chono.Text = "705000010";
            tb_civa.Text = "477000001";
            tb_csupli.Text = "566000023";
            tb_ruta.Text= "z:\\docus\\";
           

        }

        public decimal Busca_cta_det(string pcta)
        {
            decimal pimporte = 0;
            short pos=0;
            
            while (pos < _cuentas.Count)
            {
                if (_cuentas.ElementAt(pos).cta_cble.Trim() == pcta.Trim())
                {
                    pimporte = _cuentas.ElementAt(pos).importe_acu;
                    //borro cta q saco el impor
                    _cuentas.RemoveAt(pos);
                }
                pos++;
            }

            return pimporte;
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

        private void tb_n_asi_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long_exacta(tb_n_asi.Text.TrimEnd(), 6) == -1)
            {
                tb_n_asi.Focus();
                tb_n_asi.Text = "000000";
                tb_n_asi.SelectAll();
            }
        }

        private void tb_ctasa_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long_exacta(tb_ctasa.Text.TrimEnd(), 9) == -1)
            {
                tb_ctasa.Focus();
                tb_ctasa.Text = "705000011";
                tb_ctasa.SelectAll();
            }
        }

        private void tb_cdcol_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long_exacta(tb_cdcol.Text.TrimEnd(), 9) == -1)
            {
                tb_cdcol.Focus();
                tb_cdcol.Text = "705000012";
                tb_cdcol.SelectAll();
            }
        }

        private void tb_chono_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long_exacta(tb_chono.Text.TrimEnd(), 9) == -1)
            {
                tb_chono.Focus();
                tb_chono.Text = "705000013";
                tb_chono.SelectAll();
            }
        }

        private void tb_civa_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long_exacta(tb_civa.Text.TrimEnd(), 9) == -1)
            {
                tb_civa.Focus();
                tb_civa.Text = "477000000";
                tb_civa.SelectAll();
            }
        }

        private void tb_csupli_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long_exacta(tb_csupli.Text.TrimEnd(), 9) == -1)
            {
                tb_csupli.Focus();
                tb_csupli.Text = "566000023";
                tb_csupli.SelectAll();
            }
        }

        private void tb_ruta_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToChar(tb_ruta.Text.Substring(tb_ruta.Text.Length - 1, 1)) != '\\')
                tb_ruta.Text = tb_ruta.Text + "\\";
        }

        
        
        
                  
                      

    }
}
