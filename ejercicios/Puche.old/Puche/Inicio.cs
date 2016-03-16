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
    public partial class Inicio : Form
    {        

        public Inicio()
        {
            InitializeComponent();
        }

        private void btt_entrar_Click(object sender, EventArgs e)
        {
            if (rb_del_y.Checked == true)
            {
                General.delegacion = 'Y';                
            }
            else
            {
                if (rb_del_m.Checked == true)
                    General.delegacion = 'M';
                else
                {
                    if (rb_del_a.Checked == true)
                        General.delegacion = 'A';

                }
            }

            if (char.IsWhiteSpace(General.delegacion))
                MessageBox.Show("Seleccione una delegación.","Atención!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else           
                this.Close();
                                            
        }
    }
}
