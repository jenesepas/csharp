using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            tb_base.Text = pRegistro.base_imp.ToString("N2");//Convert.ToString(pRegistro.base_imp);
            tb_p_iva.Text = Convert.ToString(pRegistro.p_iva);
            tb_tasa_fra.Text = pRegistro.tasa.ToString("N2");//Convert.ToString(pRegistro.tasa);
            tb_exp.Text = Convert.ToString(pRegistro.exp_tl);
            dtp_fec_pre.Value = pRegistro.fec_pre_exp;
            tb_tasa.Text = Convert.ToString(pRegistro.tasa_tl);
            tb_tipo.Text = pRegistro.tipo_tl;
            tb_c_serv.Text = pRegistro.cambio_serv;
            tb_bate_ant.Text = pRegistro.bate_ant;
            tb_nif.Text = pRegistro.nif;
            tb_d_col.Text = pRegistro.dcho_col.ToString("N2");//Convert.ToString(pRegistro.tasa_tl); 
            if (pRegistro.t_cte_fra == 'C')
                cb_cte_fra.Text = "CTE.";
            else
                cb_cte_fra.Text = "TIT.";
            tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base.Text, tb_p_iva.Text, tb_tasa_fra.Text);
                                              
        }

        private void btt_guardar_rg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_n_reg.Text) || string.IsNullOrWhiteSpace(tb_cte_rg.Text) ||
               string.IsNullOrWhiteSpace(tb_tit_rg.Text) || (rb_del_y.Checked==false & rb_del_m.Checked==false & rb_del_a.Checked==false))

                MessageBox.Show("Hay uno o más Campos Vacios, no se puede guardar!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Registro pRegistro = new Registro();
                /*
                if (rb_del_y.Checked == true)
                    pRegistro.delegacion = 'Y';
                else
                {
                    if (rb_del_m.Checked == true)
                        pRegistro.delegacion = 'M';
                    else
                        pRegistro.delegacion = 'A';
                }*/
                pRegistro.delegacion = Seleccionar_deleg();
                pRegistro.n_reg = Convert.ToInt32(tb_n_reg.Text);
                pRegistro.fec_ent = Convert.ToDateTime(dtp_fec_rg.Text);
                pRegistro.id_cte = Convert.ToInt32(tb_cte_rg.Text);
                pRegistro.id_titular = Convert.ToInt32(tb_tit_rg.Text);
                pRegistro.seccion_int = cb_sec_int.Text.Trim();
                pRegistro.seccion = cb_sec.Text.Trim();
                pRegistro.t_tramite = cb_tram.Text.Trim();
                pRegistro.matricula = tb_matri.Text.Trim();
                pRegistro.estado = cb_estado.Text.Trim();
                pRegistro.factura = Convert.ToInt32(tb_fra.Text);
                pRegistro.fec_fra = Convert.ToDateTime(dtp_fec_fra.Text);
                pRegistro.observacion = tb_observ.Text.Trim();
                pRegistro.base_imp = Convert.ToDecimal(tb_base.Text);
                pRegistro.p_iva = Convert.ToInt16(tb_p_iva.Text);
                pRegistro.tasa = Convert.ToDecimal(tb_tasa_fra.Text);
                pRegistro.exp_tl = tb_exp.Text.Trim();
                pRegistro.fec_pre_exp = Convert.ToDateTime(dtp_fec_pre.Text);
                pRegistro.tasa_tl = Convert.ToInt32(tb_tasa.Text);  //float.Parse(tb_tasa.Text);
                pRegistro.tipo_tl = tb_tipo.Text.Trim();
                pRegistro.cambio_serv = tb_c_serv.Text.Trim();
                pRegistro.bate_ant = tb_bate_ant.Text.Trim();
                pRegistro.nif = tb_nif.Text.Trim();
                pRegistro.dcho_col = Convert.ToDecimal(tb_d_col.Text);
                if (cb_cte_fra.Text == "CTE.")
                    pRegistro.t_cte_fra = 'C';
                else
                    pRegistro.t_cte_fra = 'T';
                /*
                if (string.IsNullOrWhiteSpace(tb_letra.Text))
                    tb_letra.Text = " ";
                else
                    tb_letra.Text = tb_letra.Text.Trim();
                */
                //dtpFechaNacimiento.Value.Year + "/" + dtpFechaNacimiento.Value.Month + "/" + dtpFechaNacimiento.Value.Day;

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
            _registros.AddRange(Reg_Opera.Buscar(' ',0,0,' ', " "," "));        //obtengo todos los regs en ctes_opera.buscar y se lo paso a la lista
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
            _registros.AddRange(Reg_Opera.Buscar(' ',0,0,' '," "," "));        //obtengo todos los regs en ctes_opera.buscar y se lo paso a la lista
            RegActual = _registros.ElementAt(0);
			lb_num_rg_rg.Text="1/"+ Convert.ToString(_registros.Count) + " Registros.";
            Asigna_campos_rg(RegActual); //asignamos a los campos del form cte.
        }

        private void btt_next_rg_Click(object sender, EventArgs e)
        {
            _registros.Clear();
            _registros.AddRange(Reg_Opera.Buscar(' ',0,0,' '," "," "));        //obtengo todos los regs en ctes_opera.buscar y se lo paso a la lista
            int pos = 0;
            char deleg_act; //solo de la delegacion actual

            /*
            if (rb_del_y.Checked == true)
                deleg_act = 'Y';
            else
            {
                if (rb_del_m.Checked == true)
                    deleg_act = 'M';
                else
                    deleg_act = 'A';
            }*/

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
            _registros.AddRange(Reg_Opera.Buscar(' ', 0, 0,' '," "," "));        //obtengo todos los regs en ctes_opera.buscar y se lo paso a la lista
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
            _registros.AddRange(Reg_Opera.Buscar(' ', 0, 0, ' '," "," "));         //obtengo todos los ctes en ctes_opera.buscar y se lo paso a la lista
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
               /*
                 if (rb_del_y.Checked == true)
                    pRegistro.delegacion = 'Y';
                else
                {
                    if (rb_del_m.Checked == true)
                        pRegistro.delegacion = 'M';
                    else
                        pRegistro.delegacion = 'A';
                }
                */

                pRegistro.delegacion = Seleccionar_deleg();
                pRegistro.n_reg = Convert.ToInt32(tb_n_reg.Text);
                pRegistro.fec_ent = Convert.ToDateTime(dtp_fec_rg.Text);
                pRegistro.id_cte = Convert.ToInt32(tb_cte_rg.Text);
                pRegistro.id_titular = Convert.ToInt32(tb_tit_rg.Text);
                pRegistro.seccion_int = cb_sec_int.Text.Trim();
                pRegistro.seccion = cb_sec.Text.Trim();
                pRegistro.t_tramite = cb_tram.Text.Trim();
                pRegistro.matricula = tb_matri.Text.Trim();
                pRegistro.estado = cb_estado.Text.Trim();
                pRegistro.factura = Convert.ToInt32(tb_fra.Text);
                pRegistro.fec_fra = Convert.ToDateTime(dtp_fec_fra.Text);
                pRegistro.observacion = tb_observ.Text.Trim();
                pRegistro.base_imp = decimal.Parse(tb_base.Text); //Convert.ToDecimal(tb_base.Text);
                pRegistro.p_iva = Convert.ToInt16(tb_p_iva.Text);
                pRegistro.tasa = decimal.Parse(tb_tasa_fra.Text); //Convert.ToDecimal(tb_tasa_fra.Text);
                pRegistro.exp_tl = tb_exp.Text.Trim();
                pRegistro.fec_pre_exp = Convert.ToDateTime(dtp_fec_pre.Text);
                pRegistro.tasa_tl = Convert.ToInt32(tb_tasa.Text);
                pRegistro.tipo_tl = tb_tipo.Text.Trim();
                pRegistro.cambio_serv = tb_c_serv.Text.Trim();
                pRegistro.bate_ant = tb_bate_ant.Text.Trim();
                pRegistro.nif = tb_nif.Text.Trim();
                pRegistro.dcho_col = decimal.Parse(tb_d_col.Text); //Convert.ToDecimal(tb_tasa.Text);   //Single.Parse(tb_tasa.Text);
                if (cb_cte_fra.Text == "CTE.")
                    pRegistro.t_cte_fra = 'C';
                else
                    pRegistro.t_cte_fra = 'T';
                               

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

            rb_del_a.Enabled = false;
            rb_del_m.Enabled = false;
            rb_del_y.Enabled = false;
            tb_n_reg.Enabled = false;
            // solo habilito deleg de yecla
            rb_del_y.Checked = true;
            int max_n_reg = Reg_Opera.Calcular_n_reg('Y');
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
            dtp_fec_rg.Enabled = true;
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
            tb_observ.Clear();
            tb_base.Clear();
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
            Deshabilitar_cursores_rg();
           
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
            tb_observ.Enabled = false;
            tb_base.Enabled = false;
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

            btt_ac_tl.Enabled = true;
            btt_facturar.Enabled = true;
            btt_cancelar_rg.Enabled = true;

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
            tb_observ.Enabled = false;
            tb_base.Enabled = false;
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

            btt_ac_tl.Enabled = false;
            btt_facturar.Enabled = false;
            btt_nuevo_rg.Enabled = true;
            btt_consultar_rg.Enabled = true;
            btt_buscar_rg.Enabled = true;

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
            tb_tasa.Enabled = true;
            tb_tipo.Enabled = true;
            tb_c_serv.Enabled = true;
            tb_bate_ant.Enabled = true;
            tb_nif.Enabled = true;
            tb_d_col.Enabled = true;
            tb_exp.Focus();
        }

        private void btt_facturar_Click(object sender, EventArgs e)
        {
            tb_fra.Enabled = true;
            dtp_fec_fra.Enabled = true;
            tb_observ.Enabled = true;
            tb_base.Enabled = true;
            tb_p_iva.Enabled = true;
            tb_tasa_fra.Enabled = true;
            cb_cte_fra.Enabled = true;
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
            tb_base.Text = "0";
            tb_p_iva.Text = "0";
            tb_tasa_fra.Text = "0";
            tb_exp.Text = " ";
            tb_tasa.Text = "0";
            tb_tipo.Text = " ";
            tb_c_serv.Text = " ";
            tb_bate_ant.Text = " ";
            tb_nif.Text = " ";
            tb_d_col.Text = "0";
            cb_cte_fra.Text = "CTE.";
            tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base.Text, tb_p_iva.Text, tb_tasa_fra.Text);
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
       

        private void bt_tit_buscar_Click(object sender, EventArgs e)
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
                tb_p_iva.Focus();
                tb_p_iva.SelectAll();
            }
        }

        private void tb_fra_Validating(object sender, CancelEventArgs e)
        {
            // solo comparamos con fras nuevas: valor = 0
            if (tb_fra.Text != nfra_ant || tb_fra.Text == "0")
            {
                //validamos que sea entero y que existe ese id_cte
                int valor_fra = General.Validar_entero(tb_fra.Text);
                if (valor_fra == -1)
                {
                    tb_fra.Focus();
                    tb_fra.SelectAll();
                }
                else
                {
                    /*
                    char pdeleg;
                    if (rb_del_y.Checked == true)
                        pdeleg = 'Y';
                    else
                    {
                        if (rb_del_m.Checked == true)
                            pdeleg = 'M';
                        else
                            pdeleg = 'A';
                    }
                     */
                    if (Reg_Opera.Existe_factura(valor_fra) != 0) //, Convert.ToInt32(tb_n_reg.Text), pdeleg
                    {
                        MessageBox.Show("El número de factura ya existe.", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_fra.Focus();
                        tb_fra.SelectAll();
                    }
                }
            }
        }

        private void tb_tasa_Validating(object sender, CancelEventArgs e)
        {           
            //validamos que sea entero
            if (General.Validar_entero(tb_tasa.Text) == -1)
            {
                tb_tasa.Focus();
                tb_tasa.SelectAll();
            }
            
               
        }
        

        private void tb_base_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero y que existe ese id_cte
            if (General.Validar_real(tb_base.Text) == -1)
            {
                tb_base.Focus();
                tb_base.SelectAll();
            }
            else //valido pro cambiar "." x "," 
            {
                tb_base.Text = tb_base.Text.Replace(".", ",");
            }
        }

        private void tb_tasa_fra_Validating(object sender, CancelEventArgs e)
        {
            //validamos que sea entero y que existe ese id_cte
            if (General.Validar_real(tb_tasa_fra.Text) == -1)
            {
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
        }

        private void tb_base_Validated(object sender, EventArgs e)
        {
            tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base.Text, tb_p_iva.Text, tb_tasa_fra.Text);
        }

        private void tb_p_iva_Validated(object sender, EventArgs e)
        {
            tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base.Text, tb_p_iva.Text, tb_tasa_fra.Text);
        }

        private void tb_tasa_fra_Validated(object sender, EventArgs e)
        {
            tb_t_fra.Text = Reg_Opera.Calcular_tot_fra(tb_base.Text, tb_p_iva.Text, tb_tasa_fra.Text);
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
    }
}
