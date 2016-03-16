using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asegest
{
    public partial class Rpt_Desenlaza : Form
    {
        public char deleg;
        public Rpt_Desenlaza(char pdeleg)
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

        public void Desenlaza_fra()
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
            char accion = ' ';
            if (cb_accion.Text.Trim() == "FRAS. LISTADAS")
                accion = 'L';
            else
            {
                if (cb_accion.Text.Trim() == "FRAS. ENLAZADAS")
                    accion = 'E';
            }

            if (Reg_Opera.Fra_desenlazada(deleg, Convert.ToInt32(tb_d_fra.Text), Convert.ToInt32(tb_h_fra.Text), dtp_d_ffra.Value, dtp_h_ffra.Value,
                                t_cte, Convert.ToInt32(tb_d_cte.Text), Convert.ToInt32(tb_h_cte.Text), accion) > 0)
            {
                MessageBox.Show("Facturas actualizadas con éxito.", "Muy bien!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se actualizó ninguna Factura.", "Atención!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            
        }


        private void btt_act_lfra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cb_accion.Text))
            {
                MessageBox.Show("No se seleccionó nigún estado.", "Atención!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_accion.Focus();
            }
            else
            {
                Desenlaza_fra();
                this.Close();
            }
        }


        private void btt_cancelar_lfra_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rpt_Desenlaza_Load(object sender, EventArgs e)
        {
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
            dtp_h_ffra.Value = Convert.ToDateTime("01/01/" + DateTime.Today.Year.ToString());           

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
