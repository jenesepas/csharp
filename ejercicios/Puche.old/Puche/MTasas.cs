using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace Puche
{
    public partial class MTasas : Form
    {
        

        public Tasa TasaActual { get; set; }


        public List<Tasa> _tasas = new List<Tasa>();

        bool buscando = false;

        bool añadiendo = false;
        
        public MTasas()
        {
            InitializeComponent();
        }

        private void MTasas_Load(object sender, EventArgs e)
        {
            tb_ejercicio.Enabled = false;
            tb_codigo.Enabled = false;
            tb_descri.Enabled = false;
            tb_importe.Enabled = false;

            btt_modif_tas.Enabled = false;
            btt_del_tas.Enabled = false;
            btt_cancel_tas.Enabled = false;
            btt_save_tas.Enabled = false;
            btt_new_tas.Enabled = false;
        }

        private void btt_consultar_tas_Click(object sender, EventArgs e)
        {
            //Consultar: saca toda la tabla; buscar: segun los campos pasados.
            dgv_tasas.DataSource = Tasas_Opera.Buscar(tb_ejercicio.Text, tb_codigo.Text.Trim(), tb_descri.Text.Trim(), tb_importe.Text);

            dgv_tasas.ReadOnly = true;
            //dgv_tasas.AutoResizeColumns();            
            //dgv_tasas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewColumn column = dgv_tasas.Columns[2];
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //columna descrip completa el espacio de la tabla.

            btt_new_tas.Enabled = true;
            btt_buscar_tas.Enabled = true;
            Deshabilitar_ts();
            
            
            
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
        private void dgv_tasas_SelectionChanged(object sender, EventArgs e)
        {
            if (!añadiendo)
            {
                if (dgv_tasas.SelectedRows.Count == 1)
                {
                    Habilitar_ts();
                    tb_ejercicio.Enabled = false;
                    tb_codigo.Enabled = false;
                    buscando = false;

                    btt_modif_tas.Enabled = true;
                    btt_cancel_tas.Enabled = true;
                    btt_del_tas.Enabled = true;


                    tb_ejercicio.Text = dgv_tasas.CurrentRow.Cells[0].Value.ToString();
                    tb_codigo.Text = dgv_tasas.CurrentRow.Cells[1].Value.ToString();
                    tb_descri.Text = dgv_tasas.CurrentRow.Cells[2].Value.ToString();
                    tb_importe.Text = dgv_tasas.CurrentRow.Cells[3].Value.ToString();

                    tb_importe.Focus();
                    tb_importe.SelectAll();
                }
            }
        }

        private void btt_new_tas_Click(object sender, EventArgs e)
        {
            Habilitar_ts();
            Inicializar();

            buscando = false;
            btt_new_tas.Enabled = false;
            btt_save_tas.Enabled = true;
            btt_cancel_tas.Enabled = true;
            btt_modif_tas.Enabled = false;
            btt_del_tas.Enabled = false;
            btt_consultar_tas.Enabled = false;
            btt_buscar_tas.Enabled = false;

            añadiendo = true;


        }

        private void btt_save_tas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_ejercicio.Text) || string.IsNullOrWhiteSpace(tb_codigo.Text))
                MessageBox.Show("Hay uno o más Campos Vacios, no se puede guardar!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Tasa pTasa = new Tasa();
                pTasa.ejercicio = Convert.ToInt16(tb_ejercicio.Text);
                pTasa.codigo = tb_codigo.Text.Trim();
                pTasa.descripcion = tb_descri.Text.Trim();
                pTasa.importe = Convert.ToDecimal(tb_importe.Text);
                
                int resultado = Tasas_Opera.Agregar(pTasa);
                if (resultado > 0)
                {
                    MessageBox.Show("Tasa guardada con éxito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    añadiendo = false;
                    Limpiar_ts();
                    Deshabilitar_ts();

                    btt_consultar_tas.Enabled = true;
                    btt_buscar_tas.Enabled = true;

                    dgv_tasas.DataSource = null;
                    dgv_tasas.Refresh();
                    
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la tasa", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        void Limpiar_ts()
        {
            tb_ejercicio.Clear();
            tb_codigo.Clear();
            tb_descri.Clear();
            tb_importe.Clear();
        }

        void Habilitar_ts()
        {
            tb_ejercicio.Enabled = true;
            tb_codigo.Enabled = true;
            tb_descri.Enabled = true;
            tb_importe.Enabled = true;
        }

        void Deshabilitar_ts()
        {
            tb_ejercicio.Enabled = false;
            tb_codigo.Enabled = false;
            tb_descri.Enabled = false;
            tb_importe.Enabled = false;
        }

        private void tb_ejercicio_Validating(object sender, CancelEventArgs e)
        {
            if (!buscando)
            {
                //validamos que sea entero
                if (General.Validar_entero(tb_ejercicio.Text) == -1)
                {
                    tb_ejercicio.Text = "0";
                    tb_ejercicio.Focus();
                    tb_ejercicio.SelectAll();
                }
            }
        }

        private void tb_importe_Validating(object sender, CancelEventArgs e)
        {
            if (!buscando)
            {
                //validamos que sea decimal
                if (General.Validar_real(tb_importe.Text) == -1)
                {
                    tb_importe.Text = "0";
                    tb_importe.Focus();
                    tb_importe.SelectAll();
                }
                else //valido pro cambiar "." x "," 
                {
                    tb_importe.Text = tb_importe.Text.Replace(".", ",");
                }
            }
        }

        void Inicializar()
        {
            DateTime ano = DateTime.Today;
            tb_ejercicio.Text = ano.ToString("yyyy");
            tb_codigo.Text = " ";
            tb_descri.Text = " ";
            tb_importe.Text = "0";

            tb_ejercicio.Focus();
            tb_ejercicio.SelectAll();
        }

        private void btt_modif_tas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_ejercicio.Text) || string.IsNullOrWhiteSpace(tb_codigo.Text))
                MessageBox.Show("Hay uno o más Campos Vacios, no se puede guardar!", "Campos Vacios!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Tasa pTasa = new Tasa();
                pTasa.ejercicio = Convert.ToInt16(tb_ejercicio.Text);
                pTasa.codigo = tb_codigo.Text.Trim();
                pTasa.descripcion = tb_descri.Text.Trim();
                pTasa.importe = Convert.ToDecimal(tb_importe.Text);

                int resultado = Tasas_Opera.Actualizar(pTasa);
                if (resultado > 0)
                {
                    MessageBox.Show("Tasa modificada con éxito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Limpiar_ts();
                    Deshabilitar_ts();
                    dgv_tasas.DataSource = null;
                    dgv_tasas.Refresh();

                }
                else
                {
                    MessageBox.Show("No se pudo modificar la tasa.", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void tb_codigo_Validating(object sender, CancelEventArgs e)
        {
            if (!buscando)
            {
                if (string.IsNullOrWhiteSpace(tb_codigo.Text))
                {
                    MessageBox.Show("El código de tasa no puede estar vacio", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_codigo.Focus();
                    tb_codigo.SelectAll();
                }
                else
                {
                    if (Tasas_Opera.Existe_tasa(Convert.ToInt16(tb_ejercicio.Text), tb_codigo.Text.Trim()) != 0) //, Convert.ToInt32(tb_n_reg.Text), pdeleg
                    {
                        MessageBox.Show("La tasa ya existe para ese año.", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //tb_fra.Text = nfra_ant;
                        tb_codigo.Focus();
                        tb_codigo.SelectAll();
                    }
                }
            }
        }

        private void btt_del_tas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar la Tasa Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Tasas_Opera.Eliminar(Convert.ToInt16(tb_ejercicio.Text), tb_codigo.Text.Trim()) > 0)
                {
                    MessageBox.Show("Tasa Eliminada Correctamente!", "Tasa Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar_ts();
                    Deshabilitar_ts();

                    dgv_tasas.DataSource = null;
                    dgv_tasas.Refresh();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la Tasa", "Tasa No Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se canceló la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }

        private void btt_cancel_tas_Click(object sender, EventArgs e)
        {
            Limpiar_ts();
            Deshabilitar_ts();
            tb_ejercicio.Enabled = false;
            tb_codigo.Enabled = false;

            btt_buscar_tas.Enabled = true;
            btt_consultar_tas.Enabled = true;
            btt_del_tas.Enabled = false;
            btt_modif_tas.Enabled = false;
            btt_new_tas.Enabled = true;
            btt_save_tas.Enabled = false;
            añadiendo = false;


        }

        private void btt_buscar_tas_Click(object sender, EventArgs e)
        {
            buscando = true;
            Limpiar_ts();
            Habilitar_ts();

            btt_buscar_tas.Enabled = false;
            btt_new_tas.Enabled = false;
            btt_del_tas.Enabled = false;
            btt_modif_tas.Enabled = false;
            btt_save_tas.Enabled = false;
            btt_cancel_tas.Enabled = false;
        }

        private void btt_imp_ts_Click(object sender, EventArgs e)
        {
            Rpt_Tasas rpt_tasas = new Rpt_Tasas();
            rpt_tasas.ShowDialog();
        }

        private void tb_descri_Validating(object sender, CancelEventArgs e)
        {
            if (General.Validar_long(tb_descri.Text.TrimEnd(), 100) == -1)
            {
                tb_descri.Focus();
                tb_descri.Text = tb_descri.Text.Substring(0, 99);
                tb_descri.SelectAll();
            }
        }


        
    }
}
