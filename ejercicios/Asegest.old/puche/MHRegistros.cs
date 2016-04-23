using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace Asegest
{
    public partial class MHRegistros : Form
    {
        

        public HRegistro HRegActual { get; set; }


        public List<HRegistro> _hregs = new List<HRegistro>();

        //bool buscando = false;

        //bool añadiendo = false;

        char deleg = ' ';
        
        public MHRegistros()
        {
            InitializeComponent();
            Limpiar_hrg();
            Deshabilitar_hrg();
        }

        public MHRegistros(char pdeleg, int pn_reg)
        {
            InitializeComponent();
            Limpiar_hrg();
            Deshabilitar_hrg();

            Pintar_consulta(pdeleg, pn_reg, " ");

        }

        private void MHRegistros_Load_1(object sender, EventArgs e)
        {
            this.Text = this.Text.Trim() + General.Saca_titulo_win();

            btt_cancel_hreg.Enabled = false;
            //Limpiar_hrg();
            //Deshabilitar_hrg();
            
        }

        void Limpiar_hrg()
        {
            tb_h_n_rg.Clear();
            tb_h_usu.Clear();
            rb_y_hrg.Checked = false;
            rb_m_hrg.Checked = false;
            rb_a_hrg.Checked = false;

            dgv_hregs.DataSource = null;
            dgv_hregs.Refresh();
            
        }

        void Habilitar_hrg()
        {
            tb_h_n_rg.Enabled = true;
            tb_h_usu.Enabled = true;
            rb_y_hrg.Enabled = true;
            rb_m_hrg.Enabled = true;
            rb_a_hrg.Enabled = true;

            deleg = General.delegacion;
            if (deleg == 'Y')
                rb_y_hrg.Checked = true;
            else
            {
                if (deleg == 'M')
                    rb_m_hrg.Checked = true;
                else rb_a_hrg.Checked = true;
            }
        }

        void Deshabilitar_hrg()
        {
            tb_h_n_rg.Enabled = false;
            tb_h_usu.Enabled = false;
            rb_y_hrg.Enabled = false;
            rb_m_hrg.Enabled = false;
            rb_a_hrg.Enabled = false;
        }



        //void Inicializar()
        //{
        //    tb_codigo.Text = " ";
        //    tb_clave.Text = " ";
        //    tb_nombre.Text = " ";
        //    tb_acceso.Text = "0";

        //    tb_codigo.Focus();
        //    tb_codigo.SelectAll();
        //}


        private void btt_consultar_hreg_Click_1(object sender, EventArgs e)
        {
            deleg = ' ';
            if (rb_y_hrg.Checked == true)
                deleg = 'Y';
            else
            {
                if (rb_m_hrg.Checked == true)
                    deleg = 'M';
                else if (rb_a_hrg.Checked == true)
                    deleg = 'A';
            }

            int num_reg = 0;
            if (string.IsNullOrWhiteSpace(tb_h_n_rg.Text.Trim())) { } // num_reg=0
            else num_reg = Convert.ToInt32(tb_h_n_rg.Text.Trim());

            string usu = " ";
            if (string.IsNullOrWhiteSpace(tb_h_usu.Text.Trim())) { }
            else usu = tb_h_usu.Text.Trim();


            Pintar_consulta(deleg, num_reg, usu);                        
        }


        private void Pintar_consulta(char pdeleg, int pn_reg, string pusu)
        {

            //Consultar: saca toda la tabla; buscar: segun los campos pasados.
            dgv_hregs.DataSource = HReg_Opera.Buscar(pdeleg, pn_reg, pusu);

            dgv_hregs.ReadOnly = true;
            dgv_hregs.AutoResizeColumns();
            dgv_hregs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //DataGridViewColumn column = dgv_hregs.Columns[1];
            //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //columna descrip completa el espacio de la tabla.

            //btt_new_usu.Enabled = true;
            btt_buscar_hreg.Enabled = true;
            Deshabilitar_hrg();
            btt_cancel_hreg.Enabled = true;
            btt_consultar_hreg.Enabled = false; 
        }

        

        private void btt_cancel_hreg_Click(object sender, EventArgs e)
        {
            Limpiar_hrg();
            Deshabilitar_hrg();
            

            btt_buscar_hreg.Enabled = true;
            btt_consultar_hreg.Enabled = true;
            btt_cancel_hreg.Enabled = false;
            //añadiendo = false;            

        }

        
        private void btt_buscar_hreg_Click_1(object sender, EventArgs e)        
        {
            //buscando = true;
            Limpiar_hrg();
            Habilitar_hrg();

            btt_buscar_hreg.Enabled = false;           
            btt_cancel_hreg.Enabled = false;
            btt_consultar_hreg.Enabled = true;
        }

       
          
         

        
                       

        
    }
}
