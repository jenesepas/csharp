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
    public partial class MClientes : Form
    {
        public MClientes()
        {
            InitializeComponent();
        }

        public Cliente clienteActual { get; set; }


        public List<Cliente> _ctes = new List<Cliente>();

        private void MClientes_Load(object sender, EventArgs e)
        {
            Deshabilitar();
            Deshabilitar_cursores();
            btt_modificar.Enabled = false;
            btt_borrar.Enabled = false;
            btt_cancelar.Enabled = false; 
            btt_guardar.Enabled = false;
        }

        private void Asigna_campos_cte(Cliente pcliente)
        {
            tb_id_cte.Text = Convert.ToString(pcliente.Id_Cliente);
            tb_nombre.Text = pcliente.Nombre;
            cb_t_docu.Text = pcliente.Tipo_docu;
            tb_documento.Text = pcliente.Documento;
            tb_letra.Text = Convert.ToString(pcliente.Letra);
            tb_direccion.Text = pcliente.Direccion;
            tb_p_cont.Text = pcliente.Pers_cont;
            tb_email.Text = pcliente.Email;
            tb_tf1.Text = pcliente.Telf1;
            tb_tf2.Text = pcliente.Telf2;
            tb_cp.Text = pcliente.Cpostal;
            tb_ciudad.Text = pcliente.Ciudad;
            tb_provin.Text = pcliente.Provin;

            if (pcliente.Tipo_cte == 'C')
                rb_cte.Checked = true;
            else
                rb_titular.Checked = true; 
        }

        private void btt_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_id_cte.Text) || string.IsNullOrWhiteSpace(tb_nombre.Text) ||
                            string.IsNullOrWhiteSpace(cb_t_docu.Text) || string.IsNullOrWhiteSpace(tb_documento.Text))

                MessageBox.Show("Hay uno o más Campos Vacios, no se puede guardar!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Cliente pCliente = new Cliente();
                pCliente.Id_Cliente = Convert.ToInt32(tb_id_cte.Text);
                pCliente.Nombre = tb_nombre.Text.Trim();
                pCliente.Tipo_docu = cb_t_docu.Text.Trim(); 
                pCliente.Documento = tb_documento.Text.Trim();
                if (string.IsNullOrWhiteSpace(tb_letra.Text))
                    tb_letra.Text = " ";
                else 
                    tb_letra.Text=tb_letra.Text.Trim();
                pCliente.Letra = Convert.ToChar(tb_letra.Text);
                pCliente.Direccion = tb_direccion.Text.Trim();
                pCliente.Pers_cont = tb_p_cont.Text.Trim();
                pCliente.Email = tb_email.Text.Trim();
                pCliente.Telf1 = tb_tf1.Text.Trim();
                pCliente.Telf2 = tb_tf2.Text.Trim();
                pCliente.Cpostal = tb_cp.Text.Trim();
                pCliente.Ciudad = tb_ciudad.Text.Trim();
                pCliente.Provin = tb_provin.Text.Trim();
                if (rb_cte.Checked == true)
                    pCliente.Tipo_cte = 'C';
                else
                    pCliente.Tipo_cte =  'T';
                //dtpFechaNacimiento.Value.Year + "/" + dtpFechaNacimiento.Value.Month + "/" + dtpFechaNacimiento.Value.Day;

                int resultado = Ctes_Opera.Agregar(pCliente);
                if (resultado > 0)
                {
                    MessageBox.Show("Cliente Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        

        private void btt_consultar_Click(object sender, EventArgs e)
        {
            _ctes.Clear();
            _ctes.AddRange(Ctes_Opera.Buscar("","",' '));        //obtengo todos los ctes en ctes_opera.buscar y se lo paso a la lista
            clienteActual = _ctes.ElementAt(_ctes.Count - 1);
            lb_num_rg.Text=Convert.ToString(_ctes.Count) + "/"+ Convert.ToString(_ctes.Count) + " Clientes.";
            
            Asigna_campos_cte(clienteActual); //asignamos a los campos del form cte.

            
            btt_modificar.Enabled = true;
            btt_borrar.Enabled = true;
            Habilitar();
            btt_guardar.Enabled = false;
            Habilitar_cursores();
             
        }

        private void btt_first_Click(object sender, EventArgs e)
        {
            _ctes.Clear();
            _ctes.AddRange(Ctes_Opera.Buscar("","",' '));        //obtengo todos los ctes en ctes_opera.buscar y se lo paso a la lista
            clienteActual = _ctes.ElementAt(0);
			lb_num_rg.Text="1/"+ Convert.ToString(_ctes.Count) + " Clientes.";							
            Asigna_campos_cte(clienteActual); //asignamos a los campos del form cte.
        }
        

        private void btt_next_Click(object sender, EventArgs e)
        {
            _ctes.Clear();
            _ctes.AddRange(Ctes_Opera.Buscar("","",' '));        //obtengo todos los ctes en ctes_opera.buscar y se lo paso a la lista
            int pos = 0;

            for (pos = 0; pos < _ctes.Count - 1; pos++)
            {
                if (tb_id_cte.Text == Convert.ToString(_ctes.ElementAt(pos).Id_Cliente))
                {
                    clienteActual = _ctes.ElementAt(pos + 1);
					lb_num_rg.Text=Convert.ToString(pos + 2) + "/"+ Convert.ToString(_ctes.Count) + " Clientes.";
					
                    Asigna_campos_cte(clienteActual); //asignamos a los campos del form cte.
                    break;
                }
            }
        }

        private void btt_back_Click(object sender, EventArgs e)
        {
            _ctes.Clear();
            _ctes.AddRange(Ctes_Opera.Buscar("","",' '));        //obtengo todos los ctes en ctes_opera.buscar y se lo paso a la lista
            int pos = 0;

            for (pos = _ctes.Count - 1; pos > 0; pos--)
            {
                if (tb_id_cte.Text == Convert.ToString(_ctes.ElementAt(pos).Id_Cliente))
                {
                    clienteActual = _ctes.ElementAt(pos - 1);
					lb_num_rg.Text=Convert.ToString(pos) + "/"+ Convert.ToString(_ctes.Count) + " Clientes.";
                    Asigna_campos_cte(clienteActual); //asignamos a los campos del form cte.
                    break;
                }
            }
        }

        private void btt_last_Click(object sender, EventArgs e)
        {
            _ctes.Clear();
            _ctes.AddRange(Ctes_Opera.Buscar("","",' '));        //obtengo todos los ctes en ctes_opera.buscar y se lo paso a la lista
            clienteActual = _ctes.ElementAt(_ctes.Count - 1);
			lb_num_rg.Text=Convert.ToString(_ctes.Count) + "/"+ Convert.ToString(_ctes.Count) + " Clientes.";
            Asigna_campos_cte(clienteActual); //asignamos a los campos del form cte.

            
            btt_modificar.Enabled = true;
            btt_borrar.Enabled = true;
            Habilitar();
            btt_guardar.Enabled = false;
             
        }

        private void btt_buscar_Click(object sender, EventArgs e)
        {
            Frm_busca_cte buscar = new Frm_busca_cte('C',' ');
            buscar.ShowDialog();

            if (buscar.ClienteSeleccionado != null)
            {
                clienteActual = buscar.ClienteSeleccionado;
                Asigna_campos_cte(clienteActual); //asignamos a los campos del form cte.

                
                btt_modificar.Enabled = true;
                btt_borrar.Enabled = true;
                Habilitar();
                btt_guardar.Enabled = false;
                Deshabilitar_cursores();
                
            }
        }

        private void btt_modificar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_id_cte.Text) || string.IsNullOrWhiteSpace(tb_nombre.Text) ||
                             string.IsNullOrWhiteSpace(cb_t_docu.Text) || string.IsNullOrWhiteSpace(tb_documento.Text))

                MessageBox.Show("Hay Uno o mas Campos Vacios!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {                
                Cliente pCliente = new Cliente();
                pCliente.Id_Cliente = Convert.ToInt32(tb_id_cte.Text);
                pCliente.Nombre = tb_nombre.Text.Trim();
                pCliente.Tipo_docu = cb_t_docu.Text.Trim();
                pCliente.Documento = tb_documento.Text.Trim();
                if (string.IsNullOrWhiteSpace(tb_letra.Text))
                    tb_letra.Text = " ";
                else
                    tb_letra.Text = tb_letra.Text.Trim();
                pCliente.Letra = Convert.ToChar(tb_letra.Text);
                pCliente.Direccion = tb_direccion.Text.Trim();
                pCliente.Pers_cont = tb_p_cont.Text.Trim();
                pCliente.Email = tb_email.Text.Trim();
                pCliente.Telf1 = tb_tf1.Text.Trim();
                pCliente.Telf2 = tb_tf2.Text.Trim();
                pCliente.Cpostal = tb_cp.Text.Trim();
                pCliente.Ciudad = tb_ciudad.Text.Trim();
                pCliente.Provin = tb_provin.Text.Trim();
                if (rb_cte.Checked == true)
                    pCliente.Tipo_cte = 'C';
                else
                    pCliente.Tipo_cte = 'T';

                if (Ctes_Opera.Actualizar(pCliente) > 0)
                {
                    MessageBox.Show("Los datos del cliente se actualizaron.", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    Deshabilitar();

                    btt_borrar.Enabled = false;
                    btt_cancelar.Enabled = false;

                }
                else
                {
                    MessageBox.Show("No se pudo actualizar.", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
        }

        private void btt_borrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Cliente Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ctes_Opera.Eliminar(clienteActual.Id_Cliente, clienteActual.Tipo_cte) > 0)
                {
                    MessageBox.Show("Cliente Eliminado Correctamente!", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Cliente", "Cliente No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se canceló la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btt_nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            tb_id_cte.Enabled = false;
            btt_buscar.Enabled = false;
            btt_consultar.Enabled = false;
            btt_borrar.Enabled = false;
            btt_modificar.Enabled = false;
            btt_guardar.Enabled = true;
            btt_nuevo.Enabled = false;

            Deshabilitar_cursores();
            int max_id = 0; //Ctes_Opera.Calcular_id_cte(); (en guardar)
            tb_id_cte.Text = Convert.ToString(max_id);

            Inicializar();
        }

        private void btt_cancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            tb_id_cte.Enabled = false;
            btt_buscar.Enabled = true;
            btt_consultar.Enabled = true;
            btt_borrar.Enabled = false;
            btt_modificar.Enabled = false;

            Deshabilitar_cursores();
        }

        void Limpiar()
        {
            tb_id_cte.Clear();
            tb_nombre.Clear();
            cb_t_docu.ResetText();
            tb_documento.Clear();
            tb_letra.Clear();
            tb_direccion.Clear();
            tb_p_cont.Clear();
            tb_email.Clear();
            tb_tf1.Clear();
            tb_tf2.Clear();
            tb_cp.Clear();
            tb_ciudad.Clear();
            tb_provin.Clear();
            rb_cte.Checked = false;
            rb_titular.Checked = false;
            
            Deshabilitar_cursores();
                
            //dtpFechaNacimiento.ResetText();

        }

        void Habilitar()
        {
            tb_id_cte.Enabled=false;
            tb_nombre.Enabled=true;
            cb_t_docu.Enabled = true;
            tb_documento.Enabled = true;
            tb_letra.Enabled = true;
            tb_direccion.Enabled = true;
            tb_p_cont.Enabled = true;
            tb_email.Enabled = true;
            tb_tf1.Enabled = true;
            tb_tf2.Enabled = true;
            tb_cp.Enabled = true;
            tb_ciudad.Enabled = true;
            tb_provin.Enabled = true;           

            btt_cancelar.Enabled = true;
                  
        }


        void Deshabilitar()
        {
            tb_id_cte.Enabled = false;
            tb_nombre.Enabled = false;
            cb_t_docu.Enabled = false;
            tb_documento.Enabled = false;
            tb_letra.Enabled = false;
            tb_direccion.Enabled = false;
            tb_p_cont.Enabled = false;
            tb_email.Enabled = false;
            tb_tf1.Enabled = false;
            tb_tf2.Enabled = false;
            tb_cp.Enabled = false;
            tb_ciudad.Enabled = false;
            tb_provin.Enabled = false;
            rb_cte.Checked = false;

            btt_nuevo.Enabled = true;
            btt_consultar.Enabled = true;
            btt_buscar.Enabled = true;

        }

        void Deshabilitar_cursores() 
        {
            btt_first.Enabled = false;
            btt_back.Enabled = false;
            btt_next.Enabled = false;
            btt_last.Enabled = false;
            lb_num_rg.Text=" ";
        }

        void Habilitar_cursores()
        {
            btt_first.Enabled = true;
            btt_back.Enabled = true;
            btt_next.Enabled = true;
            btt_last.Enabled = true;
        }

        void Inicializar()
        {
            tb_nombre.Text = "";
            cb_t_docu.Text = "DNI";
            tb_documento.Text = "";
            tb_letra.Text = "";
            tb_direccion.Text = "";
            tb_p_cont.Text = "";
            tb_email.Text = "";
            tb_tf1.Text = "";
            tb_tf2.Text = "";
            tb_cp.Text = "";
            tb_ciudad.Text = "";
            tb_provin.Text = "";            
            rb_cte.Checked = true;
        }
        
        
        void Btt_imp_cteClick(object sender, EventArgs e)
        {
        	new LClientes();
        }

        private void tb_nombre_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_nombre.Text.TrimEnd(), 60) == -1)
            {
                tb_nombre.Focus();
                tb_nombre.Text = tb_nombre.Text.Substring(0, 59);
                tb_nombre.SelectAll();
            }
        }

        private void tb_documento_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_documento.Text.TrimEnd(), 60) == -1)
            {
                tb_documento.Focus();
                tb_documento.Text = tb_documento.Text.Substring(0, 59);
                tb_documento.SelectAll();
            }
        }

        private void tb_p_cont_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_p_cont.Text.TrimEnd(), 60) == -1)
            {
                tb_p_cont.Focus();
                tb_p_cont.Text = tb_p_cont.Text.Substring(0, 59);
                tb_p_cont.SelectAll();
            }
        }

        private void tb_email_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_email.Text.TrimEnd(), 60) == -1)
            {
                tb_email.Focus();
                tb_email.Text = tb_email.Text.Substring(0, 59);
                tb_email.SelectAll();
            }
        }

        private void tb_tf1_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_tf1.Text.TrimEnd(), 20) == -1)
            {
                tb_tf1.Focus();
                tb_tf1.Text = tb_tf1.Text.Substring(0, 19);
                tb_tf1.SelectAll();
            }
        }

        private void tb_tf2_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_tf2.Text.TrimEnd(), 20) == -1)
            {
                tb_tf2.Focus();
                tb_tf2.Text = tb_tf2.Text.Substring(0, 19);
                tb_tf2.SelectAll();
            }
        }

        private void tb_direccion_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_direccion.Text.TrimEnd(), 60) == -1)
            {
                tb_direccion.Focus();
                tb_direccion.Text = tb_direccion.Text.Substring(0, 59);
                tb_direccion.SelectAll();
            }
        }

        private void tb_cp_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_cp.Text.TrimEnd(), 10) == -1)
            {
                tb_cp.Focus();
                tb_cp.Text = tb_cp.Text.Substring(0, 9);
                tb_cp.SelectAll();
            }
        }

        private void tb_ciudad_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_ciudad.Text.TrimEnd(), 50) == -1)
            {
                tb_ciudad.Focus();
                tb_ciudad.Text = tb_ciudad.Text.Substring(0, 49);
                tb_ciudad.SelectAll();
            }
        }

        private void tb_provin_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_provin.Text.TrimEnd(), 60) == -1)
            {
                tb_provin.Focus();
                tb_provin.Text = tb_provin.Text.Substring(0, 59);
                tb_provin.SelectAll();
            }
        }






    }
}
