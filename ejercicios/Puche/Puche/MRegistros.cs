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
using System.Diagnostics;

namespace Puche
{
    public partial class MRegistros : Form
    {
        public MRegistros()
        {
            InitializeComponent();
        }

        public Registro RegActual { get; set; }

        public string nfra_ant;

        public List<Registro> _registros = new List<Registro>();       

        private void MRegistros_Load(object sender, EventArgs e)
        {
            Deshabilitar_rg();
            Deshabilitar_cursores_rg();
            btt_modificar_rg.Enabled = false;
            btt_borrar_rg.Enabled = false;
            btt_cancelar_rg.Enabled = false;
            btt_guardar_rg.Enabled = false;
            btt_imprimir_rg.Enabled = false;
            btt_imprimir_fra.Enabled = false;
        }

        private void Asigna_campos_rg(Registro pRegistro)
        {
            
            if (pRegistro.delegacion == 'Y')
                    rb_del_y.Checked = true;
                else
                {
                    if (pRegistro.delegacion == 'M')
                        rb_del_m.Checked = true;
                    else
                        rb_del_a.Checked = true;
                }
            
            tb_n_reg.Text = Convert.ToString(pRegistro.n_reg); 
            dtp_fec_rg.Value = pRegistro.fec_ent; 
            tb_cte_rg.Text = Convert.ToString(pRegistro.id_cte);
            tb_n_cte_rg.Text = Reg_Opera.Calcular_nom_cte(tb_cte_rg.Text,'C');
            tb_tit_rg.Text = Convert.ToString(pRegistro.id_titular);
            tb_n_tit_rg.Text = Reg_Opera.Calcular_nom_cte(tb_tit_rg.Text, 'T');
            cb_sec_int.Text = pRegistro.seccion_int;
            cb_sec.Text = pRegistro.seccion;
            cb_tram.Text = pRegistro.t_tramite;
            tb_matri.Text = pRegistro.matricula;
            cb_estado.Text = pRegistro.estado;
            tb_fra.Text = Convert.ToString(pRegistro.factura);
            dtp_fec_fra.Value = pRegistro.fec_fra;
            tb_observ.Text = pRegistro.observacion;
            tb_hono.Text = pRegistro.honorarios.ToString("N2");//Convert.ToString(pRegistro.base_imp);
            tb_p_iva.Text = Convert.ToString(pRegistro.p_iva);
            tb_tasa_fra.Text = pRegistro.tasa.ToString("N2");//Convert.ToString(pRegistro.tasa);
            tb_exp.Text = Convert.ToString(pRegistro.exp_tl);
            dtp_fec_pre.Value = pRegistro.fec_pre_exp;
            tb_tasa.Text = Convert.ToString(pRegistro.et_tasa);
            tb_tipo.Text = pRegistro.t_tasa;
            tb_c_serv.Text = pRegistro.cambio_serv;
            tb_bate_ant.Text = pRegistro.bate_ant;
            tb_nif.Text = pRegistro.nif;
            tb_d_col.Text = pRegistro.dcho_col.ToString("N2");//Convert.ToString(pRegistro.tasa_tl); 
            if (pRegistro.t_cte_fra == 'C')
                cb_cte_fra.Text = "CLIENTE";
            else
                cb_cte_fra.Text = "TITULAR";
            tb_base_imp.Text = (pRegistro.honorarios + pRegistro.dcho_col).ToString("N2");
            
            tb_tasa2.Text = Convert.ToString(pRegistro.et_tasa2);
            tb_tipo2.Text = pRegistro.t_tasa2;
            tb_tasa3.Text = Convert.ToString(pRegistro.et_tasa3);
            tb_tipo3.Text = pRegistro.t_tasa3;
            tb_tasa4.Text = Convert.ToString(pRegistro.et_tasa4);
            tb_tipo4.Text = pRegistro.t_tasa4;
            tb_descrip.Text = pRegistro.descripcion;
            tb_pdf.Text = pRegistro.ruta_pdf;
            tb_vehic.Text = pRegistro.vehiculo;
            tb_descrip1.Text = pRegistro.descrip1;
            tb_impor1.Text = pRegistro.impor1.ToString("N2");            
            tb_descrip2.Text = pRegistro.descrip2;
            tb_impor2.Text = pRegistro.impor2.ToString("N2");
            if (pRegistro.iva1_sn == true)
                cb_iva1.Checked = false;
            else
                cb_iva1.Checked = true;

            if (pRegistro.iva2_sn == true)
                cb_iva2.Checked = false;
            else
                cb_iva2.Checked = true;
            tb_itasa.Text = Tasas_Opera.Saca_imp_tasa(Convert.ToInt16(dtp_fec_fra.Value.Year), pRegistro.t_tasa.Trim()).ToString("N2");
            tb_itasa2.Text = Tasas_Opera.Saca_imp_tasa(Convert.ToInt16(dtp_fec_fra.Value.Year), pRegistro.t_tasa2.Trim()).ToString("N2");
            tb_itasa3.Text = Tasas_Opera.Saca_imp_tasa(Convert.ToInt16(dtp_fec_fra.Value.Year), pRegistro.t_tasa3.Trim()).ToString("N2");
            tb_itasa4.Text = Tasas_Opera.Saca_imp_tasa(Convert.ToInt16(dtp_fec_fra.Value.Year), pRegistro.t_tasa4.Trim()).ToString("N2");
            //tb_tasa_fra.Text = (Convert.ToDecimal(tb_itasa.Text) + Convert.ToDecimal(tb_itasa2.Text) + Convert.ToDecimal(tb_itasa3.Text) + 
            //                    Convert.ToDecimal(tb_itasa4.Text)).ToString("N2");
            //tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
            Recalcula_importes();                                              
        }

        private void Rellena_registro(Registro pRegistro)
        {
            //Registro pRegistro = new Registro();

            pRegistro.delegacion = Seleccionar_deleg();
            pRegistro.n_reg = Convert.ToInt32(tb_n_reg.Text);
            pRegistro.fec_ent = Convert.ToDateTime(dtp_fec_rg.Value);
            pRegistro.id_cte = Convert.ToInt32(tb_cte_rg.Text);
            pRegistro.id_titular = Convert.ToInt32(tb_tit_rg.Text);
            pRegistro.seccion_int = cb_sec_int.Text.Trim();
            pRegistro.seccion = cb_sec.Text.Trim();
            pRegistro.t_tramite = cb_tram.Text.Trim();
            pRegistro.matricula = tb_matri.Text.Trim();
            pRegistro.estado = cb_estado.Text.Trim();
            pRegistro.factura = Convert.ToInt32(tb_fra.Text);
            pRegistro.fec_fra = Convert.ToDateTime(dtp_fec_fra.Value);
            pRegistro.observacion = tb_observ.Text.Trim();
            pRegistro.honorarios = Convert.ToDecimal(tb_hono.Text);
            pRegistro.p_iva = Convert.ToInt16(tb_p_iva.Text);
            pRegistro.tasa = Convert.ToDecimal(tb_tasa_fra.Text);
            pRegistro.exp_tl = tb_exp.Text.Trim();
            pRegistro.fec_pre_exp = Convert.ToDateTime(dtp_fec_pre.Value);
            pRegistro.et_tasa = Convert.ToInt64(tb_tasa.Text);  //float.Parse(tb_tasa.Text);
            pRegistro.t_tasa = tb_tipo.Text.Trim();
            pRegistro.cambio_serv = tb_c_serv.Text.Trim();
            pRegistro.bate_ant = tb_bate_ant.Text.Trim();
            pRegistro.nif = tb_nif.Text.Trim();
            pRegistro.dcho_col = Convert.ToDecimal(tb_d_col.Text);
            if (cb_cte_fra.Text == "CLIENTE")
                pRegistro.t_cte_fra = 'C';
            else
                pRegistro.t_cte_fra = 'T';
            pRegistro.et_tasa2 = Convert.ToInt64(tb_tasa2.Text);
            pRegistro.t_tasa2 = tb_tipo2.Text.Trim();
            pRegistro.et_tasa3 = Convert.ToInt64(tb_tasa3.Text);
            pRegistro.t_tasa3 = tb_tipo3.Text.Trim();
            pRegistro.et_tasa4 = Convert.ToInt64(tb_tasa4.Text);
            pRegistro.t_tasa4 = tb_tipo4.Text.Trim();
            pRegistro.descripcion = tb_descrip.Text.Trim();
            pRegistro.ruta_pdf = tb_pdf.Text.Trim();
            pRegistro.vehiculo = tb_vehic.Text.Trim();
            pRegistro.descrip1 = tb_descrip1.Text.Trim();
            pRegistro.impor1 = Convert.ToDecimal(tb_impor1.Text);
            pRegistro.descrip2 = tb_descrip2.Text.Trim();
            pRegistro.impor2 = Convert.ToDecimal(tb_impor2.Text);
            if (cb_iva1.Checked == false)
                pRegistro.iva1_sn = true;
            else
                pRegistro.iva1_sn = false;

            if (cb_iva2.Checked == false)
                pRegistro.iva2_sn = true;
            else
                pRegistro.iva2_sn = false;
            /*
            if (string.IsNullOrWhiteSpace(tb_letra.Text))
                tb_letra.Text = " ";
            else
                tb_letra.Text = tb_letra.Text.Trim();
            */
            //dtpFechaNacimiento.Value.Year + "/" + dtpFechaNacimiento.Value.Month + "/" + dtpFechaNacimiento.Value.Day;
        }

        private void btt_guardar_rg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_n_reg.Text) || string.IsNullOrWhiteSpace(tb_cte_rg.Text) ||
               string.IsNullOrWhiteSpace(tb_tit_rg.Text) || (rb_del_y.Checked==false & rb_del_m.Checked==false & rb_del_a.Checked==false))

                MessageBox.Show("Hay uno o más Campos Vacios, no se puede guardar!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Registro pRegistro = new Registro();
                Rellena_registro(pRegistro);

        
                int resultado = Reg_Opera.Agregar(pRegistro);
                if (resultado > 0)
                {
                    MessageBox.Show("Registro Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar_rg();
                    Deshabilitar_rg();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btt_consultar_rg_Click(object sender, EventArgs e)
        {
            _registros.Clear();
            _registros.AddRange(Reg_Opera.Buscar(' ',0,0,' ', " "," "," "," "));        //obtengo todos los regs en reg_opera.buscar y se lo paso a la lista
            RegActual = _registros.ElementAt(_registros.Count - 1);
			lb_num_rg_rg.Text=Convert.ToString(_registros.Count) + "/"+ Convert.ToString(_registros.Count) + " Registros.";
            Asigna_campos_rg(RegActual); //asignamos a los campos del form cte.

            
            btt_modificar_rg.Enabled = true;
            btt_borrar_rg.Enabled = true;
            btt_imprimir_rg.Enabled = true;
            btt_imprimir_fra.Enabled = true;
            Habilitar_rg();
            btt_guardar_rg.Enabled = false;
            Habilitar_cursores_rg();
            
        }

        private void btt_first_rg_Click(object sender, EventArgs e)
        {
            _registros.Clear();
            _registros.AddRange(Reg_Opera.Buscar(' ', 0, 0, ' ', " ", " ", " ", " "));        //obtengo todos los regs en ctes_opera.buscar y se lo paso a la lista
            RegActual = _registros.ElementAt(0);
			lb_num_rg_rg.Text="1/"+ Convert.ToString(_registros.Count) + " Registros.";
            Asigna_campos_rg(RegActual); //asignamos a los campos del form cte.
        }

        private void btt_next_rg_Click(object sender, EventArgs e)
        {
            _registros.Clear();
            _registros.AddRange(Reg_Opera.Buscar(' ', 0, 0, ' ', " ", " ", " ", " "));        //obtengo todos los regs en ctes_opera.buscar y se lo paso a la lista
            int pos = 0;
            char deleg_act; //solo de la delegacion actual           

            deleg_act = Seleccionar_deleg();
            for (pos = 0; pos < _registros.Count - 1; pos++)
            {
                if (deleg_act == Convert.ToChar(_registros.ElementAt(pos).delegacion) &
                    tb_n_reg.Text == Convert.ToString(_registros.ElementAt(pos).n_reg))
                {
                    RegActual = _registros.ElementAt(pos + 1);
					lb_num_rg_rg.Text=Convert.ToString(pos + 2) + "/"+ Convert.ToString(_registros.Count) + " Registros.";
                    Asigna_campos_rg(RegActual); //asignamos a los campos del form cte.
                    break;
                }
            }
        }

        private void btt_back_rg_Click(object sender, EventArgs e)
        {
            _registros.Clear();
            _registros.AddRange(Reg_Opera.Buscar(' ', 0, 0, ' ', " ", " ", " ", " "));        //obtengo todos los regs en ctes_opera.buscar y se lo paso a la lista
            int pos = 0;
            char deleg_act; //solo de la delegacion actual

            
            if (rb_del_y.Checked == true)
                deleg_act = 'Y';
            else
            {
                if (rb_del_m.Checked == true)
                    deleg_act = 'M';
                else
                    deleg_act = 'A';
            }

            //deleg_act = Seleccionar_deleg();
            for (pos = _registros.Count - 1; pos > 0; pos--)
            {
                if (deleg_act == Convert.ToChar(_registros.ElementAt(pos).delegacion) &
                    tb_n_reg.Text == Convert.ToString(_registros.ElementAt(pos).n_reg))
                {
                    RegActual = _registros.ElementAt(pos - 1);
					lb_num_rg_rg.Text=Convert.ToString(pos) + "/"+ Convert.ToString(_registros.Count) + " Registros.";
                    Asigna_campos_rg(RegActual); //asignamos a los campos del form cte.
                    break;
                }
            }
        }

        private void btt_last_rg_Click_1(object sender, EventArgs e)
        {
            _registros.Clear();
            _registros.AddRange(Reg_Opera.Buscar(' ', 0, 0, ' ', " ", " ", " ", " "));         //obtengo todos los ctes en ctes_opera.buscar y se lo paso a la lista
            RegActual = _registros.ElementAt(_registros.Count - 1);
			lb_num_rg_rg.Text=Convert.ToString(_registros.Count) + "/"+ Convert.ToString(_registros.Count) + " Registros.";
            Asigna_campos_rg(RegActual); //asignamos a los campos del form cte.

            btt_modificar_rg.Enabled = true;
            btt_imprimir_rg.Enabled = true;
            btt_imprimir_fra.Enabled = true;
            btt_borrar_rg.Enabled = true;
            Habilitar_rg();
            btt_guardar_rg.Enabled = false;

        }

        private void btt_modificar_rg_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrWhiteSpace(tb_n_reg.Text) || string.IsNullOrWhiteSpace(tb_cte_rg.Text) ||
               string.IsNullOrWhiteSpace(tb_tit_rg.Text) || (rb_del_y.Checked==false & rb_del_m.Checked==false & rb_del_a.Checked==false))

                MessageBox.Show("Hay Uno o mas Campos Vacios!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {                
                Registro pRegistro = new Registro();
                Rellena_registro(pRegistro);
               

                if (Reg_Opera.Actualizar(pRegistro) > 0)
                {
                    MessageBox.Show("Los datos del registro se actualizaron.", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    Limpiar_rg();
                    Deshabilitar_rg();

                    btt_borrar_rg.Enabled = false;
                    btt_cancelar_rg.Enabled = false;
                    btt_modificar_rg.Enabled = false;
                    btt_imprimir_rg.Enabled = false;
                    btt_imprimir_fra.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar.", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
        }

        

        private void btt_borrar_rg_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el egistro Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Reg_Opera.Eliminar(RegActual.delegacion, RegActual.n_reg) > 0)
                {
                    MessageBox.Show("Registro Eliminado Correctamente!", "Registro Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar_rg();
                    Deshabilitar_rg();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Registro", "Registro No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se canceló la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btt_nuevo_rg_Click(object sender, EventArgs e)
        {
            Limpiar_rg();
            Habilitar_rg();
            /*
            rb_del_a.Enabled = false;
            rb_del_m.Enabled = false;
            rb_del_y.Enabled = false;
            tb_n_reg.Enabled = false;
            // solo habilito deleg de yecla
            rb_del_y.Checked = true;
            */
            if (General.delegacion == 'Y')
                rb_del_y.Checked = true;
            else
            {
                if (General.delegacion == 'M')
                    rb_del_m.Checked = true;
                else
                    rb_del_a.Checked = true;
            }
            int max_n_reg = 0; //Reg_Opera.Calcular_n_reg('Y'); (lo sacamos en guardar)
            tb_n_reg.Text = Convert.ToString(max_n_reg);
            
            btt_buscar_rg.Enabled = false;
            btt_consultar_rg.Enabled = false;
            btt_borrar_rg.Enabled = false;
            btt_modificar_rg.Enabled = false;
            btt_guardar_rg.Enabled = true;
            btt_nuevo_rg.Enabled = false;
            btt_imprimir_rg.Enabled = false;
            btt_imprimir_fra.Enabled = false;
            Deshabilitar_cursores_rg ();

            dtp_fec_rg.Focus();
            Inicializar();

            

            /*            
            char deleg_act = ' '; //solo de la delegacion actual
            
            if (rb_del_y.Checked == true)
                pRegistro.delegacion = 'Y';
            else
            {
                if (rb_del_m.Checked == true)
                    pRegistro.delegacion = 'M';
                else
                {
                    if (rb_del_a.Checked == true)
                        pRegistro.delegacion = 'A';
                }
            }

            if (pRegistro.delegacion != ' ')
            {
                int max_n_reg = Reg_Opera.Calcular_n_reg(deleg_act);
                tb_n_reg.Text = Convert.ToString(max_n_reg);
                

            }
            else MessageBox.Show("Tiene que seleccionar primero una Delegación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            */
            
        }

        private void btt_cancelar_rg_Click(object sender, EventArgs e)
        {
            //cancelado = true;
            Limpiar_rg();
            Deshabilitar_rg();
            tb_n_reg.Enabled = false;
            btt_buscar_rg.Enabled = true;
            btt_consultar_rg.Enabled = true;
            btt_borrar_rg.Enabled = false;
            btt_modificar_rg.Enabled = false;
            btt_imprimir_rg.Enabled = false;
            btt_imprimir_fra.Enabled = false;

            Deshabilitar_cursores_rg();
        }

        void Limpiar_rg()
        {
            rb_del_a.Checked = false;
            rb_del_m.Checked = false;
            rb_del_y.Checked = false;
            tb_n_reg.Clear();
            dtp_fec_rg.ResetText();
            tb_cte_rg.Clear();
            tb_n_cte_rg.Clear();
            tb_tit_rg.Clear();
            tb_n_tit_rg.Clear();
            cb_sec_int.ResetText();
            cb_sec.ResetText();
            cb_tram.ResetText();
            tb_matri.Clear();
            cb_estado.ResetText();
            tb_fra.Clear();
            dtp_fec_fra.ResetText();
            tb_descrip.Clear();
            tb_hono.Clear();
            tb_p_iva.Clear();
            tb_tasa_fra.Clear();
            tb_exp.Clear();
            dtp_fec_pre.ResetText();
            tb_tasa.Clear();
            tb_tipo.Clear();
            tb_c_serv.Clear();
            tb_bate_ant.Clear();
            tb_nif.Clear();
            tb_d_col.Clear();
            cb_cte_fra.ResetText();
            tb_t_fra.Clear();
            tb_tasa2.Clear();
            tb_tipo2.Clear();
            tb_tasa3.Clear();
            tb_tipo3.Clear();
            tb_tasa4.Clear();
            tb_tipo4.Clear();
            tb_pdf.Clear();
            btt_explorar.Enabled = false;
            btt_ver.Enabled = false;
            tb_observ.Clear();            
            Deshabilitar_cursores_rg();
            btt_cte_buscar.Enabled = false;
            btt_ir_cte.Enabled = false;
            btt_tit_buscar.Enabled = false;
            btt_ir_tit.Enabled = false;
            tb_itasa.Clear();
            tb_itasa2.Clear();
            tb_itasa3.Clear();
            tb_itasa4.Clear();
            tb_base_imp.Clear();
            tb_vehic.Clear();
            tb_descrip1.Clear();
            tb_impor1.Clear();            
            tb_descrip2.Clear();
            tb_impor2.Clear();
            //cb_iva1.CheckState = CheckState.Indeterminate;
            //cb_iva2.CheckState = CheckState.Indeterminate;
           
        }

        void Habilitar_rg()
        {
            //rb_del_a.Enabled = true;
            //rb_del_m.Enabled = true;
            //rb_del_y.Enabled = true;
            tb_n_reg.Enabled = false;
            dtp_fec_rg.Enabled = true;
            tb_cte_rg.Enabled = true;
            tb_tit_rg.Enabled = true;
            cb_sec_int.Enabled = true;
            cb_sec.Enabled = true;
            cb_tram.Enabled = true;
            tb_matri.Enabled = true;
            cb_estado.Enabled = true;
            tb_fra.Enabled = false;
            dtp_fec_fra.Enabled = false;
            tb_descrip.Enabled = false;
            tb_hono.Enabled = false;
            tb_p_iva.Enabled = false;
            tb_tasa_fra.Enabled = false;
            tb_exp.Enabled = false;
            dtp_fec_pre.Enabled = false;
            tb_tasa.Enabled = false;
            tb_tipo.Enabled = false;
            tb_c_serv.Enabled = false;
            tb_bate_ant.Enabled = false;
            tb_nif.Enabled = false;
            tb_d_col.Enabled = false;
            cb_cte_fra.Enabled = false;
            tb_t_fra.Enabled = false;
            tb_tasa2.Enabled = false;
            tb_tipo2.Enabled = false;
            tb_tasa3.Enabled = false;
            tb_tipo3.Enabled = false;
            tb_tasa4.Enabled = false;
            tb_tipo4.Enabled = false;
            tb_pdf.Enabled = true;
            btt_explorar.Enabled = true;
            btt_ver.Enabled = true;
            tb_observ.Enabled = true;
            tb_vehic.Enabled = true;
            
            
            btt_ac_tl.Enabled = true;
            btt_facturar.Enabled = true;
            btt_cancelar_rg.Enabled = true;
            btt_cte_buscar.Enabled = true;
            btt_ir_cte.Enabled = true;
            btt_tit_buscar.Enabled = true;
            btt_ir_tit.Enabled = true;

        }


        void Deshabilitar_rg()
        {
            rb_del_a.Enabled = false;
            rb_del_m.Enabled = false;
            rb_del_y.Enabled = false;
            tb_n_reg.Enabled = false;
            dtp_fec_rg.Enabled = false;
            tb_cte_rg.Enabled = false;
            tb_tit_rg.Enabled = false;
            cb_sec_int.Enabled = false;
            cb_sec.Enabled = false;
            cb_tram.Enabled = false;
            tb_matri.Enabled = false;
            cb_estado.Enabled = false;
            tb_fra.Enabled = false;
            dtp_fec_fra.Enabled = false;
            tb_descrip.Enabled = false;
            tb_hono.Enabled = false;
            tb_p_iva.Enabled = false;
            tb_tasa_fra.Enabled = false;
            tb_exp.Enabled = false;
            dtp_fec_pre.Enabled = false;
            tb_tasa.Enabled = false;
            tb_tipo.Enabled = false;
            tb_c_serv.Enabled = false;
            tb_bate_ant.Enabled = false;
            tb_nif.Enabled = false;
            tb_d_col.Enabled = false;            
            cb_cte_fra.Enabled = false;
            tb_t_fra.Enabled =false;
            tb_tasa2.Enabled = false;
            tb_tipo2.Enabled = false;
            tb_tasa3.Enabled = false;
            tb_tipo3.Enabled = false;
            tb_tasa4.Enabled = false;
            tb_tipo4.Enabled = false;
            tb_pdf.Enabled = false;
            btt_explorar.Enabled = false;
            btt_ver.Enabled = false;
            tb_observ.Enabled = false;
            tb_vehic.Enabled = false;
            tb_descrip1.Enabled = false;
            tb_impor1.Enabled = false;
            cb_iva1.Enabled = false;
            tb_descrip2.Enabled = false;
            tb_impor2.Enabled = false;
            cb_iva2.Enabled = false;
            Deshabilitar_cursores_rg();


            btt_ac_tl.Enabled = false;
            btt_facturar.Enabled = false;
            btt_nuevo_rg.Enabled = true;
            btt_consultar_rg.Enabled = true;
            btt_buscar_rg.Enabled = true;
            btt_cte_buscar.Enabled = false;
            btt_ir_cte.Enabled = false;
            btt_tit_buscar.Enabled = false;
            btt_ir_tit.Enabled = false;

        }

        void Deshabilitar_cursores_rg()
        {
            btt_first_rg.Enabled = false;
            btt_back_rg.Enabled = false;
            btt_next_rg.Enabled = false;
            btt_last_rg.Enabled = false;
            lb_num_rg_rg.Text=" ";
        }

        void Habilitar_cursores_rg()
        {
            btt_first_rg.Enabled = true;
            btt_back_rg.Enabled = true;
            btt_next_rg.Enabled = true;
            btt_last_rg.Enabled = true;
        }

        private void btt_ac_tl_Click(object sender, EventArgs e)
        {
            tb_exp.Enabled = true;
            dtp_fec_pre.Enabled = true;            
            tb_c_serv.Enabled = true;
            tb_bate_ant.Enabled = true;
            tb_nif.Enabled = true;
            
            tb_exp.Focus();
        }

        private void btt_facturar_Click(object sender, EventArgs e)
        {
            tb_fra.Enabled = true;
            dtp_fec_fra.Enabled = true;
            tb_descrip.Enabled = true;
            tb_hono.Enabled = true;
            tb_p_iva.Enabled = true;
            tb_tasa_fra.Enabled = true;
            cb_cte_fra.Enabled = true;
            tb_tasa.Enabled = true;
            tb_tipo.Enabled = true;
            tb_tasa2.Enabled = true;
            tb_tipo2.Enabled = true;
            tb_tasa3.Enabled = true;
            tb_tipo3.Enabled = true;
            tb_tasa4.Enabled = true;
            tb_tipo4.Enabled = true;
            tb_d_col.Enabled = true;
            tb_descrip1.Enabled = true;
            tb_impor1.Enabled = true;
            cb_iva1.Enabled = true;
            tb_descrip2.Enabled = true;
            tb_impor2.Enabled = true;
            cb_iva2.Enabled = true;
            tb_fra.Focus();
        }

        void Inicializar()
        {                        
            tb_cte_rg.Text = "0";
            tb_tit_rg.Text = "0";
            cb_sec_int.Text = "GESTASER";
            cb_sec.Text = "Hacienda";
            cb_tram.Text = "Certificados Hacienda";
            tb_matri.Text = " ";
            cb_estado.Text = "PTE. CLIENTE";
            tb_fra.Text = "0";
            tb_observ.Text = " ";
            tb_hono.Text = "0";
            tb_p_iva.Text = "21";
            tb_tasa_fra.Text = "0";
            tb_exp.Text = " ";
            tb_tasa.Text = "0";
            tb_tipo.Text = " ";
            tb_c_serv.Text = " ";
            tb_bate_ant.Text = " ";
            tb_nif.Text = " ";
            tb_d_col.Text = "0";
            cb_cte_fra.Text = "CLIENTE";
            tb_base_imp.Text ="0"; //(Convert.ToDecimal(tb_hono.Text) + Convert.ToDecimal(tb_d_col)).ToString("N2");
            tb_t_fra.Text = "0";//Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
            tb_tasa2.Text = "0";
            tb_tipo2.Text = " ";
            tb_tasa3.Text = "0";
            tb_tipo3.Text = " ";
            tb_tasa4.Text = "0";
            tb_tipo4.Text = " ";
            tb_descrip.Text=" ";
            tb_pdf.Text=" ";
            tb_vehic.Text = " ";
            dtp_fec_pre.ResetText();
            dtp_fec_rg.ResetText();
            dtp_fec_fra.ResetText();
            tb_itasa.Text = "0";
            tb_itasa2.Text = "0";
            tb_itasa3.Text = "0";
            tb_itasa4.Text = "0";
            tb_descrip1.Text = " ";
            tb_impor1.Text = "0";
            tb_descrip2.Text = " ";
            tb_impor2.Text = "0";
        }

        public char Seleccionar_deleg()
        {
            if (rb_del_y.Checked == true)
                    return 'Y';
                else
                {
                    if (rb_del_m.Checked == true)
                        return 'M';
                    else
                        return 'A';
                }
        }

  
        private void cb_sec_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccionado = Convert.ToInt32(((ComboBox)sender).SelectedIndex);
            // ver si le podemos pasar la lista entera o item a item
            switch (seleccionado)
            {
                case 0: //seccion = hacienda
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Certificados Hacienda");
                    this.cb_tram.Text = "Certificados Hacienda"; //el text visible = 1er. item
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
                    this.cb_tram.Text = "Altas RETA"; //el text visible = 1er. item
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
                    this.cb_tram.Text = "Nacionalidad";
                    this.cb_tram.Items.Add("Otros");
                    break;
                case 3: //conductores 
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Renovación Permiso");
                    this.cb_tram.Text = "Renovación Permiso";
                    this.cb_tram.Items.Add("Duplicado Permiso");
                    this.cb_tram.Items.Add("Canje Permiso");
                    break;
                case 4: //vehiculos 
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Duplicado Permiso Circulación");
                    this.cb_tram.Text = "Duplicado Permiso Circulación";
                    this.cb_tram.Items.Add("Informe Tráfico");
                    this.cb_tram.Items.Add("Transferencias");
                    this.cb_tram.Items.Add("Transferencia Agrícola");
                    this.cb_tram.Items.Add("Matriculación");
                    this.cb_tram.Items.Add("Notificación Venta");
                    this.cb_tram.Items.Add("Baja Temporal");
                    this.cb_tram.Items.Add("Reserva Dominio");
                    break;
                case 5: case 6: // transporte
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Pendiente Cliente");
                    this.cb_tram.Text = "Pendiente Cliente";
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
                
                 */case 7: // Varios
                    this.cb_tram.Items.Clear();
                    this.cb_tram.Items.Add("Varios");
                    this.cb_tram.Text = "Varios";                    
                    break;
                default:
                    break;
            }
        }

        private void btt_ir_cte_Click(object sender, EventArgs e)
        {
             MClientes _MClientes = new MClientes();
            _MClientes.ShowDialog();
        }

        private void btt_ir_tit_Click(object sender, EventArgs e)
        {
            MClientes _MClientes = new MClientes();
            _MClientes.ShowDialog();
        }

        private void btt_cte_buscar_Click(object sender, EventArgs e)
        {
            Frm_busca_cte buscar = new Frm_busca_cte('R','C');
            buscar.ShowDialog();

            if (buscar.id_cteSeleccionado != 0)
            {
                tb_cte_rg.Text = Convert.ToString(buscar.id_cteSeleccionado);
                tb_n_cte_rg.Text = Reg_Opera.Calcular_nom_cte(tb_cte_rg.Text,'C');
            }
        }


        private void btt_tit_buscar_Click_1(object sender, EventArgs e)
        {
            Frm_busca_cte buscar = new Frm_busca_cte('R', 'T');
            buscar.ShowDialog();

            if (buscar.id_cteSeleccionado != 0)
            {
                tb_tit_rg.Text = Convert.ToString(buscar.id_cteSeleccionado);
                tb_n_tit_rg.Text = Reg_Opera.Calcular_nom_cte(tb_tit_rg.Text, 'T');
            }
        }

                      

        private void tb_cte_rg_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero y que existe ese id_cte
            if (General.Validar_entero(tb_cte_rg.Text) == -1 || (Reg_Opera.Calcular_nom_cte(tb_cte_rg.Text,'C') == " ")) 
            {
                tb_cte_rg.Text = "0";
                tb_cte_rg.Focus();                
                tb_cte_rg.SelectAll();
            }
            else
            {
                tb_cte_rg.Text = tb_cte_rg.Text.Trim();
                tb_n_cte_rg.Text = Reg_Opera.Calcular_nom_cte(tb_cte_rg.Text,'C');
            }
        }

                

        private void tb_tit_rg_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero y que existe ese id_cte
            if (General.Validar_entero(tb_tit_rg.Text) == -1 || (Reg_Opera.Calcular_nom_cte(tb_tit_rg.Text,'T') == " ")) 
            {
                tb_tit_rg.Text = "0";
                tb_tit_rg.Focus();
                tb_tit_rg.SelectAll();
            }
            else
            {
                tb_tit_rg.Text = tb_tit_rg.Text.Trim();
                tb_n_tit_rg.Text = Reg_Opera.Calcular_nom_cte(tb_tit_rg.Text,'T');
            }
        }

        private void tb_d_col_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero y que existe ese id_cte
            if (General.Validar_real(tb_d_col.Text) == -1)
            {
                tb_d_col.Text = "0";
                tb_d_col.Focus();
                tb_d_col.SelectAll();
            }
            else //valido pro cambiar "." x "," 
            {
                tb_d_col.Text = tb_d_col.Text.Replace(".", ",");
            }
            
        }

        private void tb_p_iva_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero y valor (0,100)
            int valor_iva= General.Validar_entero(tb_p_iva.Text);
            if (( valor_iva == -1) | (valor_iva < 0) | (valor_iva > 100))
            {
                // el valor -1 no saca mensaje de error.
                if (valor_iva != -1)
                    MessageBox.Show("Porcentaje de IVA debe ser valor entre 0 y 100.", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_p_iva.Text = "0";
                tb_p_iva.Focus();
                tb_p_iva.SelectAll();
            }
        }

        private void tb_fra_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name == "btt_cancelar_rg") //si pulso boton cancelar
            {
                tb_fra.CausesValidation = false; //ya no pasa por validating
                btt_cancelar_rg_Click(sender, e); //cancela pantalla
            }
        }

        private void tb_fra_Validating(object sender, CancelEventArgs e)
        {
                       
            // solo comparamos con fras nuevas: valor = 0
            if ((tb_fra.Text != nfra_ant) || (tb_fra.Text == "0"))
            {
                //validamos que sea entero y que existe ese id_cte
                int valor_fra = General.Validar_entero(tb_fra.Text);
                if (valor_fra == -1)
                {
                    tb_fra.Text = nfra_ant;
                    tb_fra.Focus();
                    tb_fra.SelectAll();
                }
                else
                {
                    
                    if (Reg_Opera.Existe_factura(valor_fra) != 0) //, Convert.ToInt32(tb_n_reg.Text), pdeleg
                    {
                        MessageBox.Show("El número de factura ya existe.", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_fra.Text = nfra_ant;
                        tb_fra.Focus();
                        tb_fra.SelectAll();
                    }
                }
            }
        }

        private void tb_tasa_Validating(object sender, CancelEventArgs e)
        {           
            //validamos que sea entero
            if (General.Validar_entero_l(tb_tasa.Text) == -1)
            {
                tb_tasa.Text = "0";
                tb_tasa.Focus();
                tb_tasa.SelectAll();
            }
            
               
        }
        

        private void tb_base_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero y que existe ese id_cte
            if (General.Validar_real(tb_hono.Text) == -1)
            {
                tb_hono.Text = "0";
                tb_hono.Focus();
                tb_hono.SelectAll();
            }
            else //valido pro cambiar "." x "," 
            {
                tb_hono.Text = tb_hono.Text.Replace(".", ",");
            }
        }

        private void tb_tasa_fra_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero y que existe ese id_cte
            if (General.Validar_real(tb_tasa_fra.Text) == -1)
            {
                tb_tasa.Text = "0";
                tb_tasa_fra.Focus();
                tb_tasa_fra.SelectAll();
            }
            else //valido pro cambiar "." x "," 
            {
                tb_tasa_fra.Text = tb_tasa_fra.Text.Replace(".", ",");
            }
        }

        private void tb_fra_Enter(object sender, EventArgs e)
        {
            nfra_ant = tb_fra.Text; //sabemos el valor anterior
            tb_fra.CausesValidation = true; //activamos que pase por validating
        }

        private void tb_base_Validated(object sender, EventArgs e)
        {
            //tb_base_imp.Text = (Convert.ToDecimal(tb_hono.Text) + Convert.ToDecimal(tb_d_col.Text)).ToString("N2");
            //tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
            Recalcula_importes();
        }

        private void tb_p_iva_Validated(object sender, EventArgs e)
        {            
            //tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);            
            Recalcula_importes();
        }

        private void tb_tasa_fra_Validated(object sender, EventArgs e)
        {
            //tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
            Recalcula_importes();
        }

        private void btt_buscar_rg_Click(object sender, EventArgs e)
        {
            Frm_busca_reg buscar = new Frm_busca_reg();
            buscar.ShowDialog();

            if (buscar.RegSeleccionado != null)
            {
                RegActual = buscar.RegSeleccionado;
                Asigna_campos_rg(RegActual); //asignamos a los campos del form cte.


                btt_modificar_rg.Enabled = true;
                btt_borrar_rg.Enabled = true;
                btt_imprimir_rg.Enabled = true;
                btt_imprimir_fra.Enabled = true;
                Habilitar_rg();
                btt_guardar_rg.Enabled = false;
                Deshabilitar_cursores_rg();

            }
        }

        private void btt_imprimir_rg_Click(object sender, EventArgs e)
        {
            new LRegistros(RegActual);
        }
               

        
        void Btt_imprimir_fraClick(object sender, EventArgs e)
        {
        	if (RegActual.factura != 0)
        		new LFacturas(RegActual);
        	else
        		MessageBox.Show("Registro sin facturar.","Attención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btt_explorar_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            tb_pdf.Text = openFileDialog1.FileName;
                            tb_pdf.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se puede leer del disco. Error original: " + ex.Message);
                }
            }
        }

        private void btt_ver_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_pdf.Text) & File.Exists(tb_pdf.Text))
            {
                //string filePath = "@\"" + tb_pdf.Text + "\"";
                Process.Start(tb_pdf.Text);
            }
            else
                MessageBox.Show("Necesita adjuntar un fichero o la ruta es incorrecta.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }

        private void tb_descrip_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_descrip.Text))
            {
                tb_descrip.Text = cb_sec.Text.Trim() + " - " + cb_tram.Text.Trim() + " - " + tb_matri.Text.Trim() + " - " + tb_vehic.Text.Trim();
                if (tb_cte_rg.Text != "0" && tb_tit_rg.Text != "0") //solo si existe cte y titu, poner al titular en la descri
                    tb_descrip.Text = tb_descrip.Text.Trim() + " - " + tb_n_tit_rg.Text.Trim();
            }
        }

        private void tb_tasa2_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero
            if (General.Validar_entero_l(tb_tasa2.Text) == -1)
            {
                tb_tasa2.Text = "0";
                tb_tasa2.Focus();
                tb_tasa2.SelectAll();
            }
        }

        private void tb_tasa3_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero
            if (General.Validar_entero_l(tb_tasa3.Text) == -1)
            {
                tb_tasa3.Text = "0";
                tb_tasa3.Focus();
                tb_tasa3.SelectAll();
            }
        }

        private void tb_tasa4_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero
            if (General.Validar_entero_l(tb_tasa4.Text) == -1)
            {
                tb_tasa4.Text = "0";
                tb_tasa4.Focus();
                tb_tasa4.SelectAll();
            }
        }

        private void tb_d_col_Validated(object sender, EventArgs e)
        {
            //tb_base_imp.Text = (Convert.ToDecimal(tb_hono.Text) + Convert.ToDecimal(tb_d_col.Text)).ToString("N2");
            //tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
            Recalcula_importes();
        }

        private void tb_tipo_Validating(object sender, CancelEventArgs e)
        {
            tb_itasa.Text = Tasas_Opera.Saca_imp_tasa(Convert.ToInt16(dtp_fec_fra.Value.Year), tb_tipo.Text.Trim()).ToString("N2");            
        }

        private void tb_tipo2_Validating(object sender, CancelEventArgs e)
        {
            tb_itasa2.Text = Tasas_Opera.Saca_imp_tasa(Convert.ToInt16(dtp_fec_fra.Value.Year), tb_tipo2.Text.Trim()).ToString("N2");
        }

        private void tb_tipo3_Validating(object sender, CancelEventArgs e)
        {
            tb_itasa3.Text = Tasas_Opera.Saca_imp_tasa(Convert.ToInt16(dtp_fec_fra.Value.Year), tb_tipo3.Text.Trim()).ToString("N2");
        }

        private void tb_tipo4_Validating(object sender, CancelEventArgs e)
        {
            tb_itasa4.Text = Tasas_Opera.Saca_imp_tasa(Convert.ToInt16(dtp_fec_fra.Value.Year), tb_tipo4.Text.Trim()).ToString("N2");
        }

        private void tb_tipo_Validated(object sender, EventArgs e)
        {
            //tb_tasa_fra.Text = Reg_Opera.Calcular_tasa_fra(tb_itasa.Text, tb_itasa2.Text, tb_itasa3.Text, tb_itasa4.Text);
            //tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
            Recalcula_importes();
        }

        private void tb_tipo2_Validated(object sender, EventArgs e)
        {
            //tb_tasa_fra.Text = Reg_Opera.Calcular_tasa_fra(tb_itasa.Text, tb_itasa2.Text, tb_itasa3.Text, tb_itasa4.Text);
            //tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
            Recalcula_importes();
        }

        private void tb_tipo3_Validated(object sender, EventArgs e)
        {
            //tb_tasa_fra.Text = Reg_Opera.Calcular_tasa_fra(tb_itasa.Text, tb_itasa2.Text, tb_itasa3.Text, tb_itasa4.Text);
            //tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
            Recalcula_importes();
        }

        private void tb_tipo4_Validated(object sender, EventArgs e)
        {
            Recalcula_importes();
            //tb_tasa_fra.Text = Reg_Opera.Calcular_tasa_fra(tb_itasa.Text, tb_itasa2.Text, tb_itasa3.Text, tb_itasa4.Text);
            //tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);            
        }

        private void tb_vehic_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_vehic.Text.TrimEnd(), 50) == -1)
            {
                tb_vehic.Focus();
                tb_vehic.Text = tb_vehic.Text.Substring(0, 49);
                tb_vehic.SelectAll();
            }
        }

        private void tb_pdf_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_pdf.Text.TrimEnd(), 100) == -1)
            {
                tb_pdf.Focus();
                tb_pdf.Text = tb_pdf.Text.Substring(0, 99);
                tb_pdf.SelectAll();
            }
        }

        private void tb_observ_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_observ.Text.TrimEnd(), 180) == -1)
            {
                tb_observ.Focus();
                tb_observ.Text = tb_observ.Text.Substring(0, 179);
                tb_observ.SelectAll();
            }
        }

        private void tb_descrip_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_descrip.Text.TrimEnd(), 150) == -1)
            {
                tb_descrip.Focus();
                tb_descrip.Text = tb_descrip.Text.Substring(0, 149);
                tb_descrip.SelectAll();
            }
        }

        private void tb_matri_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_matri.Text.TrimEnd(), 10) == -1)
            {
                tb_matri.Focus();
                tb_matri.Text = tb_matri.Text.Substring(0, 9);
                tb_matri.SelectAll();
            }
        }

        private void tb_exp_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_exp.Text.TrimEnd(), 20) == -1)
            {
                tb_exp.Focus();
                tb_exp.Text = tb_exp.Text.Substring(0, 19);
                tb_exp.SelectAll();
            }
        }

        private void tb_bate_ant_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_bate_ant.Text.TrimEnd(), 10) == -1)
            {
                tb_bate_ant.Focus();
                tb_bate_ant.Text = tb_bate_ant.Text.Substring(0, 9);
                tb_bate_ant.SelectAll();
            }
        }

        private void tb_nif_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_nif.Text.TrimEnd(), 12) == -1)
            {
                tb_nif.Focus();
                tb_nif.Text = tb_nif.Text.Substring(0, 11);
                tb_nif.SelectAll();
            }
        }

        private void tb_c_serv_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_c_serv.Text.TrimEnd(), 20) == -1)
            {
                tb_c_serv.Focus();
                tb_c_serv.Text = tb_c_serv.Text.Substring(0, 19);
                tb_c_serv.SelectAll();
            }
        }

        private void tb_descrip1_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_descrip1.Text.TrimEnd(), 100) == -1)
            {
                tb_descrip1.Focus();
                tb_descrip1.Text = tb_descrip1.Text.Substring(0, 99);
                tb_descrip1.SelectAll();
            }
        }

        private void tb_impor1_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero y que existe ese id_cte
            if (General.Validar_real(tb_impor1.Text) == -1)
            {
                tb_impor1.Text = "0";
                tb_impor1.Focus();
                tb_impor1.SelectAll();
            }
            else //valido pro cambiar "." x "," 
            {
                tb_impor1.Text = tb_impor1.Text.Replace(".", ",");
            }
        }

        private void tb_impor1_Validated(object sender, EventArgs e)
        {
            Recalcula_importes();
            /*
            if (!cb_iva1.Checked)
            {
                tb_base_imp.Text = (Convert.ToDecimal(tb_impor1.Text) + Convert.ToDecimal(tb_hono.Text) + Convert.ToDecimal(tb_d_col.Text)).ToString("N2");
                tb_tasa_fra.Text = Reg_Opera.Calcular_tasa_fra(tb_itasa.Text, tb_itasa2.Text, tb_itasa3.Text, tb_itasa4.Text);
                
            }
            else
            {
                tb_tasa_fra.Text = (Convert.ToDecimal(Reg_Opera.Calcular_tasa_fra(tb_itasa.Text, tb_itasa2.Text, tb_itasa3.Text, tb_itasa4.Text)) + 
                                    Convert.ToDecimal(tb_impor1.Text)).ToString("N2");
                tb_base_imp.Text = (Convert.ToDecimal(tb_hono.Text) + Convert.ToDecimal(tb_d_col.Text)).ToString("N2");
                
            }
            tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
             */ 
        }

        private void cb_iva1_CheckedChanged(object sender, EventArgs e)
        {
            Recalcula_importes();
            /*
            if (!cb_iva1.Checked)
            {
                tb_base_imp.Text = (Convert.ToDecimal(tb_impor1.Text) + Convert.ToDecimal(tb_hono.Text) + Convert.ToDecimal(tb_d_col.Text)).ToString("N2");
                tb_tasa_fra.Text = Reg_Opera.Calcular_tasa_fra(tb_itasa.Text, tb_itasa2.Text, tb_itasa3.Text, tb_itasa4.Text);

            }
            else
            {
                tb_tasa_fra.Text = (Convert.ToDecimal(Reg_Opera.Calcular_tasa_fra(tb_itasa.Text, tb_itasa2.Text, tb_itasa3.Text, tb_itasa4.Text)) +
                                    Convert.ToDecimal(tb_impor1.Text)).ToString("N2");
                tb_base_imp.Text = (Convert.ToDecimal(tb_hono.Text) + Convert.ToDecimal(tb_d_col.Text)).ToString("N2");

            }
            tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
             */ 
        }

        private void tb_descrip2_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_descrip2.Text.TrimEnd(), 100) == -1)
            {
                tb_descrip2.Focus();
                tb_descrip2.Text = tb_descrip2.Text.Substring(0, 99);
                tb_descrip2.SelectAll();
            }
        }

        private void tb_impor2_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero y que existe ese id_cte
            if (General.Validar_real(tb_impor2.Text) == -1)
            {
                tb_impor2.Text = "0";
                tb_impor2.Focus();
                tb_impor2.SelectAll();
            }
            else //valido pro cambiar "." x "," 
            {
                tb_impor2.Text = tb_impor2.Text.Replace(".", ",");
            }
        }

        private void tb_impor2_Validated(object sender, EventArgs e)
        {
            Recalcula_importes();
        }


        private void cb_iva2_CheckedChanged(object sender, EventArgs e)
        {
            Recalcula_importes();
        }


        private void Recalcula_importes()
        {
            decimal simpor11 = 0;//con iva
            decimal simpor12 = 0;//sin iva
            decimal simpor21 = 0;//con iva
            decimal simpor22 = 0;//sin iva

            if (!string.IsNullOrWhiteSpace(tb_impor1.Text))
            {
                if (cb_iva1.Checked == false)
                    simpor11 = Convert.ToDecimal(tb_impor1.Text);
                else
                    simpor12 = Convert.ToDecimal(tb_impor1.Text);
            }

            if (!string.IsNullOrWhiteSpace(tb_impor2.Text))
            {
                if (cb_iva2.Checked == false)
                    simpor21 = Convert.ToDecimal(tb_impor2.Text);
                else
                    simpor22 = Convert.ToDecimal(tb_impor2.Text);
            }

            tb_base_imp.Text = (simpor11 + simpor21 + Convert.ToDecimal(tb_hono.Text) + Convert.ToDecimal(tb_d_col.Text)).ToString("N2");

            tb_tasa_fra.Text = (Convert.ToDecimal(Reg_Opera.Calcular_tasa_fra(tb_itasa.Text, tb_itasa2.Text, tb_itasa3.Text, tb_itasa4.Text)) +
                                    simpor12 + simpor22).ToString("N2");

            tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base_imp.Text, tb_p_iva.Text, tb_tasa_fra.Text);
        }
                        
       

                
        

        
    }
}
