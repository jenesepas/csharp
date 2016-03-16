using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BaseDeDatos bd = new BaseDeDatos();

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvRegistros.DataSource = bd.SelectDataTable("select * from datos");

            //txtClave.Text = bd.selectstring("select clave from datos where clave = 2");
             
            cmbSexo.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string agregar = "insert into datos values (" + txtClave.Text + ",'" + txtNombre.Text + "','" + txtApellidoP.Text + "','" +
                txtApellidoM.Text + "'," + txtEdad.Text + ",'" + cmbSexo.Text + "')";

            if (bd.executecommand(agregar))
            {
                MessageBox.Show("Registro agregado correctamente");
                dgvRegistros.DataSource = bd.SelectDataTable("select * from datos");
            }
            else
            {
                MessageBox.Show("Error al agregar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "delete datos where clave = " + txtClave.Text;

            if (bd.executecommand(eliminar))
            {
                MessageBox.Show("Registro eliminado correctamente");
                dgvRegistros.DataSource = bd.SelectDataTable("select * from datos");
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string actualizar = "update datos set edad = " + txtEdad.Text + " where clave = " + txtClave.Text;

            if (bd.executecommand(actualizar))
            {
                MessageBox.Show("Registro actualizado correctamente");
                dgvRegistros.DataSource = bd.SelectDataTable("select * from datos");
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvRegistros.DataSource = bd.SelectDataTable("select * from datos where clave = " + txtBuscar.Text); 
        }

        private void dgvRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dgvRegistros.Rows[e.RowIndex];
            txtClave.Text = dgv.Cells[0].Value.ToString();
            txtNombre.Text = dgv.Cells[1].Value.ToString();
            txtApellidoP.Text = dgv.Cells[2].Value.ToString();
            txtApellidoM.Text = dgv.Cells[3].Value.ToString();
            txtEdad.Text = dgv.Cells[4].Value.ToString();
            cmbSexo.Text = dgv.Cells[5].Value.ToString();            
        }
    }
}
