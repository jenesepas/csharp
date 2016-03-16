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

        private void Menu_Load(object sender, EventArgs e)
        {
            if (char.IsWhiteSpace(General.delegacion))
            {
                Inicio inicio = new Inicio();
                inicio.ShowDialog();

                switch (General.delegacion)
                {
                    case 'Y':
                        this.Text = this.Text.TrimEnd() + " *** YECLA ***";
                        break;
                    case 'M':
                        this.Text = this.Text.TrimEnd() + " *** MURCIA ***";
                        break;
                    case 'A':
                        this.Text = this.Text.TrimEnd() + " *** ALBACETE ***";
                        break;
                }
            }
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

        private void tasasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MTasas mtasas = new MTasas();
            mtasas.ShowDialog();
        }

        private void tasasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rpt_Tasas rpt_tasas = new Rpt_Tasas();
            rpt_tasas.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MTasas mtasas = new MTasas();
            mtasas.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Rpt_Tasas rpt_tasas = new Rpt_Tasas();
            rpt_tasas.ShowDialog();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
    }
}
