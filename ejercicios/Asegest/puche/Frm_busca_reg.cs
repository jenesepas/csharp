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
    public partial class Frm_busca_reg : Form
    {
        public char deleg;
        public Frm_busca_reg(char pdeleg)
        {
            InitializeComponent();

            //solo buscamos en la delegacion actual.
            deleg = pdeleg;
            if (deleg == 'Y')
                rb_y_rg.Checked = true;
            else
            {
                if (deleg == 'M')
                    rb_m_rg.Checked = true;
                else rb_a_rg.Checked = true;
            }
            rb_y_rg.Enabled = false;
            rb_m_rg.Enabled = false;
            rb_a_rg.Enabled = false;
        }

        public Registro RegSeleccionado { get; set; }

        private void btt_b_buscar_Click(object sender, EventArgs e)
        {
            char t_cte = ' ';
            if (rb_cte_rg.Checked == true)
                t_cte = 'C';
            else
            {
                if (rb_titular_rg.Checked == true)
                    t_cte = 'T';
                else if (rb_col_rg.Checked == true)
                        t_cte = 'B';
            }
            
            /*
            char deleg = ' ';
            if (rb_y_rg.Checked == true)
                deleg = 'Y';
            else
            {
                if (rb_m_rg.Checked == true)
                    deleg = 'M';
                else if (rb_a_rg.Checked == true)
                    deleg = 'A';
            }
            */

            int num_reg = 0;
            if (string.IsNullOrWhiteSpace(tb_b_n_rg.Text.Trim())) {} // num_reg=0
            else num_reg = Convert.ToInt32(tb_b_n_rg.Text.Trim());

            int num_fra = 0;
            if (string.IsNullOrWhiteSpace(tb_fra_rg.Text.Trim())) { } // num_reg=0
            else num_fra = Convert.ToInt32(tb_fra_rg.Text.Trim());

            string nombre = " ";
            if (string.IsNullOrWhiteSpace(tb_b_nombre_rg.Text.Trim())) {}
            else nombre = tb_b_nombre_rg.Text.Trim();

            string n_exp = " ";
            if (string.IsNullOrWhiteSpace(tb_exp_rg.Text.Trim())) {}
            else n_exp = tb_exp_rg.Text.Trim();

            string exp_ntl = " ";
            if (string.IsNullOrWhiteSpace(tb_exp_ntl.Text.Trim())) { }
            else exp_ntl = tb_exp_ntl.Text.Trim();

            string matricula = " ";
            if (string.IsNullOrWhiteSpace(tb_matri_rg.Text.Trim())) { }
            else matricula = tb_matri_rg.Text.Trim();

            string vehiculo = " ";
            if (string.IsNullOrWhiteSpace(tb_vehi_rg.Text.Trim())) { }
            else vehiculo = tb_vehi_rg.Text.Trim();

            //pasamos deleg, n_reg, n_fra, t_cte, n_cte, n_exp
            dgv_regs.DataSource = Reg_Opera.Buscar(deleg, num_reg, num_fra, t_cte, nombre, n_exp, exp_ntl, matricula, vehiculo);
        }

        private void Frm_busca_reg_Load(object sender, EventArgs e)
        {
            Limpiar_busq();
        }        

        private void bt_b_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar_busq();
        }

        private void btt_b_aceptar_rg_Click(object sender, EventArgs e)
        {
            if (dgv_regs.SelectedRows.Count == 1)
            {

                char deleg = Convert.ToChar(dgv_regs.CurrentRow.Cells[0].Value);
                int n_reg = Convert.ToInt32(dgv_regs.CurrentRow.Cells[1].Value);
                
                RegSeleccionado = Reg_Opera.ObtenerReg(deleg, n_reg);
                
                this.Close();
            }
            else
                MessageBox.Show("Se debe seleccionar una fila.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btt_b_cancelar_rg_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Limpiar_busq()
        {
            /*
            rb_a_rg.Checked = false;
            rb_m_rg.Checked = false;
            rb_y_rg.Checked = false;
            */
            rb_cte_rg.Checked = false;
            rb_titular_rg.Checked = false;
            tb_b_n_rg.Clear();
            tb_b_nombre_rg.Clear();
            tb_exp_rg.Clear();
            tb_fra_rg.Clear();
            dgv_regs.DataSource = null;
            dgv_regs.Refresh();
            tb_matri_rg.Clear();
            tb_vehi_rg.Clear();
            
        }

    }
}
