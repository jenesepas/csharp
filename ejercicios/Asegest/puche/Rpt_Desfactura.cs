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
    public partial class Rpt_Desfactura : Form
    {
        public Rpt_Desfactura()
        {
            InitializeComponent();
        }

        public void Desfactura()
        {
            if (Reg_Opera.Fra_desfacturada(Convert.ToInt32(tb_nfac.Text),General.delegacion) > 0)
            {                
                MessageBox.Show("Factura desfacturada con éxito.", "Muy bien!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se desfacturó ninguna Factura.", "Atención!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            
        }

        private void Rpt_Desfactura_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void btt_cancelar_ts_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btt_imp_ts_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_nfac.Text) || tb_nfac.Text =="0")
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
            }
        }

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
    }
}
