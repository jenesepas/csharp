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
    public partial class Frm_busca_cte : Form
    {
        public char llamada;

        //llamada: form desde donde se llama este form / pt_cte: Cte o Titu
        public Frm_busca_cte(char pt_llamada, char pt_cte)
        {
            InitializeComponent();
            llamada = pt_llamada;
            
            if (pt_cte != ' ')
            {
                rb_cte.Enabled = false;
                rb_titular.Enabled = false;
                if (pt_cte == 'C')
                    rb_cte.Checked = true;
                else
                    rb_titular.Checked = true;
            }
        }

        public Cliente ClienteSeleccionado { get; set; }

        public int id_cteSeleccionado { get; set; }        

        private void btt_b_aceptar_Click(object sender, EventArgs e)
        {
            if (dgv_ctes.SelectedRows.Count == 1)
            {
                //Cliente CteSel = new Cliente();

                int id = Convert.ToInt32(dgv_ctes.CurrentRow.Cells[0].Value);
                
                if (llamada == 'C') //devolucion a Mclientes
                    ClienteSeleccionado = Ctes_Opera.ObtenerCliente(id);
                else
                    id_cteSeleccionado = id; //devolucion a Mregistros

                this.Close();
            }
            else
                MessageBox.Show("Se debe seleccionar una fila.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
        }

        private void btt_b_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btt_b_buscar_Click(object sender, EventArgs e)
        {
            char t_cte='C';
            if (rb_titular.Checked == true)
                t_cte='T';

            //MessageBox.Show("Antes: " + Convert.ToString(tb_b_nombre.Text) + " / " + tb_b_docu.Text + " / " + t_cte);
            dgv_ctes.DataSource = Ctes_Opera.Buscar(Convert.ToString(tb_b_nombre.Text.Trim()), Convert.ToString(tb_b_docu.Text.Trim()), t_cte);
        }

    }
}
