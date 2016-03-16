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
    public partial class Menu : Form
    {
        MClientes MClientes;
        public Menu()
        {
            InitializeComponent();
            
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MClientes = new MClientes();
            MClientes.ShowDialog();
        }

        private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MRegistros MRegistros = new MRegistros();
            MRegistros.ShowDialog();
            //MessageBox.Show("Opción en construcción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MClientes = new MClientes();
            MClientes.ShowDialog();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opción en construcción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new LClientes();
        }

        private void registrosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rpt_Registros rpt_registros = new Rpt_Registros();
            rpt_registros.ShowDialog();
            //MessageBox.Show("Opción en construcción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            MClientes = new MClientes();
            MClientes.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MRegistros MRegistros = new MRegistros();
            MRegistros.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new LClientes();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Rpt_Registros rpt_registros = new Rpt_Registros();
            rpt_registros.ShowDialog();
        }

        
    }
}
