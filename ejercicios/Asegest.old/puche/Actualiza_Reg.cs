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
    public partial class Actualiza_Reg : Form
    {
        public Actualiza_Reg()
        {
            InitializeComponent();
        }

        public void Actuaaliza_n_reg()
        {
            if (Reg_Opera.act_n_reg_anyo() > 0)
            {
                MessageBox.Show("Registros actualizados con éxito.", "Muy bien!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se actualizó ningún registro.", "Atención!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        /*
        private void Rpt_Desfactura_Load(object sender, EventArgs e)
        {
            Iniciar();
        }
        */
        private void btt_cancelar_ts_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void btt_imp_ts_Click_1(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Esta Seguro que desea actualizar los registros?", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Actuaaliza_n_reg();
            }

            this.Close();
            /*
            if (string.IsNullOrWhiteSpace(tb_nfac.Text) || tb_nfac.Text == "0")
            {
                MessageBox.Show("No se insertó ningún Num. de Fra.", "Atención!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_nfac.Focus();
            }
            else
            {
                if (Reg_Opera.Existe_factura(Convert.ToInt32(tb_nfac.Text)) == 0)
                {
                    MessageBox.Show("No existe ese Num. de Fra.", "Atención!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (Linfac_Opera.Existe_Linfac(Convert.ToInt32(tb_nfac.Text)) != 0)
                        MessageBox.Show("Ese N.Fra. tiene detalle, bórrelo y inténtelo de nuevo.", "Atención!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {   //procede a update                 
                        Desfactura();
                        this.Close();
                    }
                }
            }*/
        }

        
       

        /* 
        void Iniciar()
        {
            tb_nfac.Text = "0";

        }

        private void tb_nfac_Validating(object sender, CancelEventArgs e)
        {
            int valor_fra = General.Validar_entero(tb_nfac.Text);
            if (valor_fra == -1)
            {
                tb_nfac.Text = "0";
                tb_nfac.Focus();
                tb_nfac.SelectAll();
            }
        }

        
       
        */
    }
}
