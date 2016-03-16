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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void f2_bot_aceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public string GetNombre()
        {
            return f2_tb_nombre.Text + " " + f2_tb_apellidos.Text;
        }
    }
}
