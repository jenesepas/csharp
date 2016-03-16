using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;


namespace Cab_Lin
{
    public partial class Principal : Form
    {
        NpgsqlCommand comando, comando_d;
        NpgsqlDataAdapter adaptador, adaptador_d;
        NpgsqlCommandBuilder constructor, constructor_d;
        DataSet conjunto;
        DataTable tabla = new DataTable();
        DataTable tabla_det = new DataTable();
        NpgsqlDataReader datos;

        public Principal()
        {
            InitializeComponent();
        }


        private void btt_consultar_Click(object sender, EventArgs e)
        {
            string sql = "select * from cabfac";

            btt_consultar.Enabled = false;
            btt_cancel.Enabled = true;
            btt_new.Enabled = true;
            btt_save.Enabled = true;
            btt_del.Enabled = true;
            // AquÃ­ lanzas el proceso de guardado a la bd etc...
            using (BDConexion.ObtenerConexion())
            {
                comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                // Incrementamos hasta un minuto para evitar que de error cualquier ejecuciÃ³n comÃºn.
                comando.CommandTimeout = 5 * 60;
                /*
                tabla = new DataTable();
                tabla.Clear();
                datos = comando.ExecuteReader();

                tabla.Load(datos, LoadOption.OverwriteChanges);
                */
                conjunto = new DataSet();
                adaptador = new NpgsqlDataAdapter(comando);
                constructor = new NpgsqlCommandBuilder(adaptador);
                
                adaptador.Fill(conjunto, "cabfac");                
                tabla = conjunto.Tables["cabfac"];

                bindingSource1.DataSource = tabla;
                //bindingSource1.DataMember = "cabfac";
                bindingNavigator1.BindingSource = bindingSource1;

                tb_n_fra.DataBindings.Add("Text", bindingSource1, "numfac", true);
                dat_f_fra.DataBindings.Add("Text", bindingSource1, "fec_fra", true);
                tb_cte.DataBindings.Add("Text", bindingSource1, "cliente", true);
                tb_base.DataBindings.Add("Text", bindingSource1, "base", true);
                tb_iva.DataBindings.Add("Text", bindingSource1, "p_iva", true);
                tb_tasas.DataBindings.Add("Text", bindingSource1, "tasas", true);

                //comando.Connection.Close();

                string sql_d = "select numfac,linea,descripcion,cantidad,precio from linfac"; // where numfac='" + tb_n_fra.Text + "'";

                comando_d = new NpgsqlCommand(sql_d, BDConexion.ObtenerConexion());
                adaptador_d = new NpgsqlDataAdapter(comando_d);
                constructor_d = new NpgsqlCommandBuilder(adaptador_d);
                //conjunto = new DataSet();
                adaptador_d.Fill(conjunto, "linfac");
                tabla_det = conjunto.Tables["linfac"];

                // Establish a relationship between the two tables.
                DataRelation relation = new DataRelation("cablinfac", conjunto.Tables["cabfac"].Columns["numfac"],
                                                        conjunto.Tables["linfac"].Columns["numfac"]);
                conjunto.Relations.Add(relation);
                comando_d.Connection.Close();
                
                bindingSource2.DataSource = bindingSource1;
                bindingSource2.DataMember = "cablinfac";
                dgv_lf.DataSource = bindingSource2; //tabla_det;
                
                dgv_lf.ReadOnly = true;
                dgv_lf.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_lf.Columns[0].Visible = false;
                //comando_d.Connection.Close();
                
            }
        }

        //void ToolStripButton1Click(object sender, EventArgs e)
        private void save_Click(object sender, EventArgs e)
        {
                        
            DataRow fila = tabla.NewRow();

            fila["numfac"] = Convert.ToInt32(tb_n_fra.Text);
            fila["fec_fra"] = Convert.ToDateTime(dat_f_fra.Text);
            fila["cliente"] = Convert.ToInt32(tb_cte.Text);
            fila["base"] = Convert.ToDecimal(tb_base.Text);
            fila["p_iva"] = Convert.ToInt16(tb_iva.Text);
            fila["tasas"] = Convert.ToDecimal(tb_tasas.Text);
            tabla.Rows.Add(fila);
            //conjunto.Tables["cabfac"].Rows.Add(fila);
            //tabla = conjunto.Tables["cabfac"];
            /*
            if (conjunto.HasChanges())
            {
                adaptador.Update(tabla); //conjunto, "cabfac"
            }
             */
            //btt_cancel_Click_1(sender, e);
            //bindingSource1.DataSource = tabla;
            //bindingNavigator1.BindingSource = bindingSource1;
            

        }

 
        private void btt_new_Click_1(object sender, EventArgs e)
        {
            dgv_lf.ReadOnly = false;
            btt_save.Enabled = true;
            btt_new.Enabled = false;
            btt_del.Enabled = false;
        }

        private void btt_del_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dgv_lf.Rows.RemoveAt(dgv_lf.SelectedRows[0].Index);
                adaptador_d.Update(tabla_det);
            }
        }

        private void btt_save_Click_1(object sender, EventArgs e)
        {           	
        	adaptador_d.Update(tabla_det);
            //adaptador_d.Fill(tabla_det);
            //tabla_det = conjunto.Tables["linfac"];
            dgv_lf.ReadOnly = true;
            btt_save.Enabled = false;
            btt_new.Enabled = true;
            btt_del.Enabled = true;
        }

        private void btt_cancel_Click_1(object sender, EventArgs e)
        {
            btt_consultar.Enabled = true;
            dgv_lf.DataSource = null;
            dgv_lf.Refresh();
            bindingNavigator1.DataBindings.Clear();
            //bindingNavigator1.Dispose();
            //tabla.Clear();
            //bindingSource1.Clear();
            tb_n_fra.Clear();
            dat_f_fra.ResetText();
            tb_cte.Clear();
            tb_base.Clear();
            tb_iva.Clear();
            tb_tasas.Clear();
        }

        private void cablin_Click(object sender, EventArgs e)
        {
            btt_cancel.Enabled = false;
            btt_new.Enabled = false;
            btt_save.Enabled = false;
            btt_del.Enabled = false;
        }
      
        

        private void delete_Click(object sender, EventArgs e)
        {
          
            if (MessageBox.Show("Are you sure you want to delete the invoice nº "+ tb_n_fra.Text +"?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int pos=0;
                //buscamos la filas (aunq deberia ser solo 1)
                DataRow[] filas = conjunto.Tables["cabfac"].Select("numfac='"+ tb_n_fra.Text + "'");
                //borramos todas las filas (1 en este caso)
                foreach (DataRow fila_act in filas)
                {
                    pos = conjunto.Tables["cabfac"].Rows.IndexOf(fila_act);
                    conjunto.Tables["cabfac"].Rows[pos].Delete();
                }
                //int pos = conjunto.Tables["cabfac"].Rows.IndexOf(fila_act);
                //conjunto.Tables["cabfac"].Rows.Remove(fila_act);
                
                if (conjunto.HasChanges())
                {
                    adaptador.Update(conjunto,"cabfac");
                    btt_cancel_Click_1(sender, e);
                    bindingNavigator1.BindingSource.ResetBindings(false);
                }
            }




            
            
        }

            

                             
        
       
    }
}
