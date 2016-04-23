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
    public partial class Menu : Form
    {
        MClientes MClientes;       

        public Menu()
        {
            InitializeComponent();
            
        }        

        private void Menu_Load(object sender, EventArgs e)
        {
            if (char.IsWhiteSpace(General.delegacion))
            {
                Inicio inicio = new Inicio();
                inicio.ShowDialog();

                //if cerrar_ini = 0, cerrar aplicacion
                if (General.cerrar_ini == 0)
                    this.Close();
                else
                {
                    //switch (General.delegacion)
                    //{
                    //    case 'Y':
                    //        this.Text = this.Text.TrimEnd() + " *** YECLA *** - USUARIO: " + General.usuario;
                    //        break;
                    //    case 'M':
                    //        this.Text = this.Text.TrimEnd() + " *** MURCIA *** - USUARIO: " + General.usuario;
                    //        break;
                    //    case 'A':
                    //        this.Text = this.Text.TrimEnd() + " *** ALBACETE *** - USUARIO: " + General.usuario;
                    //        break;
                    //}

                    this.Text = this.Text.Trim() + General.Saca_titulo_win();
                }
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MClientes = new MClientes();
            MClientes.Show();
        }

        private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MRegistros MRegistros = new MRegistros();
            MRegistros.Show();
            //MessageBox.Show("Opción en construcción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MClientes = new MClientes();
            MClientes.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opción en construcción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rpt_Ctes rpt_lclientes = new Rpt_Ctes();
            rpt_lclientes.Show();
            //new LClientes();
        }

        private void registrosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rpt_Registros rpt_registros = new Rpt_Registros();
            rpt_registros.Show();
            //MessageBox.Show("Opción en construcción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            MClientes = new MClientes();
            //MClientes.MdiParent = this;
            MClientes.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MRegistros MRegistros = new MRegistros();
            MRegistros.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Rpt_Ctes rpt_lclientes = new Rpt_Ctes();
            rpt_lclientes.Show();
            //new LClientes();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Rpt_Registros rpt_registros = new Rpt_Registros();
            rpt_registros.Show();
        }

        private void tasasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MTasas mtasas = new MTasas();
            mtasas.Show();
        }

        private void tasasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rpt_Tasas rpt_tasas = new Rpt_Tasas();
            rpt_tasas.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MTasas mtasas = new MTasas();
            mtasas.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Rpt_Tasas rpt_tasas = new Rpt_Tasas();
            rpt_tasas.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Rpt_RFacturas rpt_facturas = new Rpt_RFacturas();
            rpt_facturas.Show();
        }

        private void regFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rpt_RFacturas rpt_rfacturas = new Rpt_RFacturas();
            rpt_rfacturas.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Rpt_RAFacturas rpt_rafacturas = new Rpt_RAFacturas();
            rpt_rafacturas.Show();
        }

        private void regAcumFrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rpt_RAFacturas rpt_rafacturas = new Rpt_RAFacturas();
            rpt_rafacturas.Show();
        }

        private void enlaceAContabilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rpt_Enlace rpt_enlace = new Rpt_Enlace(General.delegacion);
            rpt_enlace.Show();
        }

        private void desenlazaFrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rpt_Desenlaza rpt_desenlace = new Rpt_Desenlaza(General.delegacion);
            rpt_desenlace.Show();
        }

        private void desfacturaFraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rpt_Desfactura rpt_desfactura = new Rpt_Desfactura();
            rpt_desfactura.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //si acceso del usu <> 9, no entra a usuarios
            if (Usuarios_Opera.Acceso_usu(General.usuario, 9) == 0)
            {
                MessageBox.Show("El usuario actual no tiene permisos para entrar en esta opción de menu.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MUsuarios musuarios = new MUsuarios();
                musuarios.Show();
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            //si acceso del usu <> 9, no entra a usuarios
            if (Usuarios_Opera.Acceso_usu(General.usuario, 9) == 0)
            {
                MessageBox.Show("El usuario actual no tiene permisos para entrar en esta opción de menu.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MUsuarios musuarios = new MUsuarios();
                musuarios.Show();
            }
        }
               

        private void históricoRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MHRegistros mhregistros = new MHRegistros();
            mhregistros.Show();
        }

        private void acRegsXSecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rpt_RegAS _Rpt_RegAS = new Rpt_RegAS();
            _Rpt_RegAS.Show();
        }

        private void acRegsXSeccIntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rpt_RegASI _Rpt_RegASI = new Rpt_RegASI();
            _Rpt_RegASI.Show();
        }

        

        
    }
}
