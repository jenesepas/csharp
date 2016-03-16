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
                General.server = "172.26.0.223";
            }
            else
            {
                if (rb_del_m.Checked == true)
                {
                    General.delegacion = 'M';
                    General.server = "127.0.0.1";//"192.168.1.33";
                }
                else
                {
                    if (rb_del_a.Checked == true)
                    {
                        General.delegacion = 'A';
                        General.server = "172.26.0.223";
                    }
                }
            }


            if (char.IsWhiteSpace(General.delegacion))
                MessageBox.Show("Seleccione una delegación.", "Atención!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    //192.168.0.100-127.0.0.1-172.26.0.223
                    string cadenaConexionTabla = "Server='" + General.server.Trim() + "';Port=5432;User id=postgres;Password=admin;Database=asesoria";
                    NpgsqlConnection conectar = new NpgsqlConnection(cadenaConexionTabla);
                    conectar.Open();

                    //sigue sin error al menu.
                    //General.cerrar_ini = 1;
                    //this.Close();
                   
                    int sigue = Usuarios_Opera.Existe_usu_pass(tb_cod.Text.Trim(), tb_clave.Text.Trim());

                    //sigue=1 si encuentra usu y pass
                    if (sigue == 0)
                    {
                        MessageBox.Show("Usuario incorrecto. Vuelva a intentarlo.", "Atención!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //vble global de usu
                        General.usuario = tb_cod.Text.Trim();
                        //sigue sin error al menu.
                        General.cerrar_ini = 1;
                        this.Close();
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show("No se pudo conectar con el Servidor. Pruebe con otra delegación.", e1.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    rb_del_y.Checked = false;
                    rb_del_m.Checked = false;
                    rb_del_a.Checked = false;
                }

                /*finally
                {
                }*/
            }


        }

        private void tb_cod_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_cod.Text))
            {
                MessageBox.Show("El código de usuario no puede estar vacio", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod.Focus();
                tb_cod.SelectAll();
            }
            else
            {
               
                if (General.Validar_long(tb_cod.Text.TrimEnd(), 20) == -1)
                {
                    tb_cod.Focus();
                    tb_cod.Text = tb_cod.Text.Substring(0, 19);
                    tb_cod.SelectAll();
                }
                
            }
        }

        private void tb_clave_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_clave.Text.TrimEnd(), 20) == -1)
            {
                tb_clave.Focus();
                tb_clave.Text = tb_clave.Text.Substring(0, 19);
                tb_clave.SelectAll();
            }
        }


        
    }
}
