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
    public partial class MUsuarios : Form
    {
        

        public Usuario UsuarioActual { get; set; }


        public List<Usuario> _usuarios = new List<Usuario>();

        bool buscando = false;

        bool añadiendo = false;
        
        public MUsuarios()
        {
            InitializeComponent();
        }

        private void MUsuarios_Load_1(object sender, EventArgs e)
        {
            this.Text = this.Text.Trim() + General.Saca_titulo_win();

            tb_codigo.Enabled = false;
            tb_clave.Enabled = false;
            tb_nombre.Enabled = false;
            tb_acceso.Enabled = false;

            btt_modif_usu.Enabled = false;
            btt_del_usu.Enabled = false;
            btt_cancel_usu.Enabled = false;
            btt_save_usu.Enabled = false;
            btt_new_usu.Enabled = false;
        }

        void Limpiar_usu()
        {
            tb_codigo.Clear();
            tb_clave.Clear();
            tb_nombre.Clear();
            tb_acceso.Clear();
        }

        void Habilitar_usu()
        {
            tb_codigo.Enabled = true;
            tb_clave.Enabled = true;
            tb_nombre.Enabled = true;
            tb_acceso.Enabled = true;
        }

        void Deshabilitar_usu()
        {
            tb_codigo.Enabled = false;
            tb_clave.Enabled = false;
            tb_nombre.Enabled = false;
            tb_acceso.Enabled = false;
        }



        void Inicializar()
        {
            tb_codigo.Text = " ";
            tb_clave.Text = " ";
            tb_nombre.Text = " ";
            tb_acceso.Text = "0";

            tb_codigo.Focus();
            tb_codigo.SelectAll();
        }


        private void btt_consultar_usu_Click_1(object sender, EventArgs e)
        {
            //Consultar: saca toda la tabla; buscar: segun los campos pasados.
            dgv_usuarios.DataSource = Usuarios_Opera.Buscar(); //tb_codigo.Text, tb_nombre.Text.Trim(), tb_clave.Text.Trim(), tb_acceso.Text

            dgv_usuarios.ReadOnly = true;
            //dgv_tasas.AutoResizeColumns();            
            //dgv_tasas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewColumn column = dgv_usuarios.Columns[1];
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //columna descrip completa el espacio de la tabla.

            btt_new_usu.Enabled = true;            
            Deshabilitar_usu();                     
            
        }

        /*
        private void dgv_tasas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dgv_tasas.Rows[e.RowIndex];
            tb_ejercicio.Text = dgv.Cells[0].Value.ToString();
            tb_codigo.Text = dgv.Cells[1].Value.ToString();
            tb_descri.Text = dgv.Cells[2].Value.ToString();
            tb_importe.Text = dgv.Cells[3].Value.ToString();            
        }
        */
        private void dgv_usuarios_SelectionChanged_1(object sender, EventArgs e)
        {
            if (!añadiendo)
            {
                if (dgv_usuarios.SelectedRows.Count == 1)
                {
                    Habilitar_usu();
                    tb_codigo.Enabled = false;                    
                    buscando = false;

                    btt_modif_usu.Enabled = true;
                    btt_cancel_usu.Enabled = true;
                    btt_del_usu.Enabled = true;
                    btt_save_usu.Enabled = false;


                    tb_codigo.Text = dgv_usuarios.CurrentRow.Cells[0].Value.ToString();
                    tb_nombre.Text = dgv_usuarios.CurrentRow.Cells[1].Value.ToString();
                    tb_clave.Text = dgv_usuarios.CurrentRow.Cells[2].Value.ToString();
                    tb_acceso.Text = dgv_usuarios.CurrentRow.Cells[3].Value.ToString();

                    tb_clave.Focus();
                    tb_clave.SelectAll();
                }
            }
        }

        private void btt_new_usu_Click_1(object sender, EventArgs e)
        {
            Habilitar_usu();
            Inicializar();

            buscando = false;
            btt_new_usu.Enabled = false;
            btt_save_usu.Enabled = true;
            btt_cancel_usu.Enabled = true;
            btt_modif_usu.Enabled = false;
            btt_del_usu.Enabled = false;
            btt_consultar_usu.Enabled = false;            

            añadiendo = true;


        }
        
        private void btt_save_usu_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_codigo.Text) || string.IsNullOrWhiteSpace(tb_clave.Text))
                MessageBox.Show("Hay uno o más Campos Vacios, no se puede guardar!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Usuario pUsuario = new Usuario();                
                pUsuario.codigo = tb_codigo.Text.Trim();
                pUsuario.nombre = tb_nombre.Text.Trim();
                pUsuario.acceso = Convert.ToInt16(tb_acceso.Text);
                pUsuario.clave = tb_clave.Text.Trim();
                
                int resultado = Usuarios_Opera.Agregar(pUsuario);
                if (resultado > 0)
                {
                    MessageBox.Show("Usuario guardado con éxito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    añadiendo = false;
                    Limpiar_usu();
                    Deshabilitar_usu();

                    btt_consultar_usu.Enabled = true;                    

                    dgv_usuarios.DataSource = null;
                    dgv_usuarios.Refresh();
                    
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el Usuario.", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        

        private void btt_modif_usu_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_codigo.Text) || string.IsNullOrWhiteSpace(tb_clave.Text))
                MessageBox.Show("Hay uno o más Campos Vacios, no se puede guardar!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Usuario pUsuario = new Usuario();                
                pUsuario.codigo = tb_codigo.Text.Trim();
                pUsuario.nombre = tb_nombre.Text.Trim();
                pUsuario.clave = tb_clave.Text.Trim();
                pUsuario.acceso = Convert.ToInt16(tb_acceso.Text);

                int resultado = Usuarios_Opera.Actualizar(pUsuario);
                if (resultado > 0)
                {
                    MessageBox.Show("Usuario modificado con éxito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Limpiar_usu();
                    Deshabilitar_usu();
                    dgv_usuarios.DataSource = null;
                    dgv_usuarios.Refresh();

                }
                else
                {
                    MessageBox.Show("No se pudo modificar la tasa.", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        

        private void btt_del_usu_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Usuario Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Usuarios_Opera.Eliminar(tb_codigo.Text.Trim()) > 0)
                {
                    MessageBox.Show("Usuario Eliminado Correctamente!", "Usuario Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar_usu();
                    Deshabilitar_usu();

                    dgv_usuarios.DataSource = null;
                    dgv_usuarios.Refresh();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Usuario", "Usuario No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se canceló la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }

        private void btt_cancel_usu_Click(object sender, EventArgs e)
        {
            Limpiar_usu();
            Deshabilitar_usu();
            tb_codigo.Enabled = false;            

            //btt_buscar_usu.Enabled = true;
            btt_consultar_usu.Enabled = true;
            btt_del_usu.Enabled = false;
            btt_modif_usu.Enabled = false;
            btt_new_usu.Enabled = true;
            btt_save_usu.Enabled = false;
            añadiendo = false;


        }

        //private void btt_buscar_usu_Click_1(object sender, EventArgs e)        
        //{
        //    buscando = true;
        //    Limpiar_usu();
        //    Habilitar_usu();

        //    btt_buscar_usu.Enabled = false;
        //    btt_new_usu.Enabled = false;
        //    btt_del_usu.Enabled = false;
        //    btt_modif_usu.Enabled = false;
        //    btt_save_usu.Enabled = false;
        //    btt_cancel_usu.Enabled = false;
        //}
/*
        private void btt_imp_ts_Click(object sender, EventArgs e)
        {
            Rpt_Tasas rpt_tasas = new Rpt_Tasas();
            rpt_tasas.ShowDialog();
        }
*/

        private void tb_codigo_Validating_1(object sender, CancelEventArgs e)
        {
            if (!buscando)
            {
                if (string.IsNullOrWhiteSpace(tb_codigo.Text))
                {
                    MessageBox.Show("El código de usuario no puede estar vacio", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_codigo.Focus();
                    tb_codigo.SelectAll();
                }
                else
                {
                    if (Usuarios_Opera.Existe_usu(tb_codigo.Text.Trim()) != 0) //, Convert.ToInt32(tb_n_reg.Text), pdeleg
                    {
                        MessageBox.Show("Este código de usuario ya existe.", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //tb_fra.Text = nfra_ant;
                        tb_codigo.Focus();
                        tb_codigo.SelectAll();
                    }
                    else
                    {
                        if (General.Validar_long(tb_codigo.Text.TrimEnd(), 20) == -1)
                        {
                            tb_codigo.Focus();
                            tb_codigo.Text = tb_codigo.Text.Substring(0, 19);
                            tb_codigo.SelectAll();
                        }
                    } 
                }
            }
        }

        private void tb_nombre_Validating_1(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_nombre.Text.TrimEnd(), 50) == -1)
            {
                tb_nombre.Focus();
                tb_nombre.Text = tb_nombre.Text.Substring(0, 49);
                tb_nombre.SelectAll();
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


        private void tb_acceso_Validating_1(object sender, CancelEventArgs e)
        {
            if (!buscando)
            {
                //validamos que sea entero
                if (General.Validar_entero(tb_acceso.Text) == -1)
                {
                    tb_acceso.Text = "0";
                    tb_acceso.Focus();
                    tb_acceso.SelectAll();
                }
            }
        }

        private void tb_codigo_Enter(object sender, EventArgs e)
        {
            tb_codigo.CausesValidation = true; //activamos que pase por validating
        }

        private void tb_codigo_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name == "btt_cancel_usu") //si pulso boton cancelar
            {
                tb_codigo.CausesValidation = false; //ya no pasa por validating
                //btt_cancelar_rg_Click(sender, e); //cancela pantalla
            }
        }

       
        
        
                       

        
    }
}
