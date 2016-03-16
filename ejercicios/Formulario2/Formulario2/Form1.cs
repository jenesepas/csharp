using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Formulario2
{
    public partial class Form1 : Form
    {
        Form2 ventanaIntro;

        public Form1()
        {
            InitializeComponent();
            ventanaIntro = new Form2();
        }

        private void Pulsar_Click(object sender, EventArgs e)
        {
            if (campo_01.Text.Length != 0)
                MessageBox.Show(campo_01.Text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Campo vacio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                MessageBox.Show("Desea probar de nuevo?", "Aviso", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                
                    //Close();  
            }
            campo_01.Text = "";
        }

        private void Insertar_Click(object sender, EventArgs e)
        {
            ventanaIntro.ShowDialog();
            campo_01.Text = ventanaIntro.GetNombre();
        }
    }
}
