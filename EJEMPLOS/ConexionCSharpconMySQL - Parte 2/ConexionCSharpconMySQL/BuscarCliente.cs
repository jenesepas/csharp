using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionCSharpconMySQL
{
    public partial class BuscarCliente : Form
    {
        public BuscarCliente()
        {
            InitializeComponent();
        }

        public Cliente ClienteSelecionado { get; set; }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvBuscar.DataSource = ClietesDAL.Buscar(txtNombre.Text, txtApellido.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvBuscar.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvBuscar.CurrentRow.Cells[0].Value);
                ClienteSelecionado = ClietesDAL.ObtenerCliente(id);

                this.Close();
            }
            else
                MessageBox.Show("debe de seleccionar una fila");
        }
    }
}
