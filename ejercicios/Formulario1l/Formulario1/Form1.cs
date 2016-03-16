using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Diagnostics;
using Npgsql;

namespace Formulario1
{
    public partial class Form1 : Form
    {
        NpgsqlCommand comando;
        NpgsqlDataAdapter adaptador;
        NpgsqlCommandBuilder constructor, constructor1;
        DataSet conjunto;
        DataTable tabla;
        DataTable tabla_det;
        NpgsqlDataReader datos;        
    	
    	
    	public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BotonIr_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void haciaAtrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void haciaDelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Imprimir();
            toolStripStatusLabel1.Text="Opción Imprime";
        	//Imprimir imprime = new Imprimir();
            //imprime.ReadDocument();
            //imprime.printPreviewDialog1.Document = imprime.printDocument1;
            //imprime.printPreviewDialog1.ShowDialog();

            //Rpt_Imp imprime = new Rpt_Imp();
            //imprime.ShowDialog();
            //Rpt_imprimir imprime = new Rpt_imprimir();
            //imprime.ShowDialog();
        }

        private void btt_Imprimir_Click(object sender, EventArgs e)
        {
            Rpt_Imp imprime = new Rpt_Imp();
            imprime.CaptureScreen();
            imprime.printDocument2.Print();
            toolStripStatusLabel1.Text="Opción Imprime botón";
        }

        private void imprimir2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Print();
        }
        
        void AbrirPDFToolStripMenuItemClick(object sender, EventArgs e)
        {
		    string filePath = @"e:\tmp\document.pdf";
        	Process.Start(filePath);
        	toolStripStatusLabel1.Text="Opción Abrir PDF";
        }
        
        
        
        void Btt_expClick(object sender, EventArgs e)
        {
        	 
	       	Stream myStream = null;
		    OpenFileDialog openFileDialog1 = new OpenFileDialog();
		
		    openFileDialog1.InitialDirectory = "c:\\" ;
		    openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
		    openFileDialog1.FilterIndex = 2 ;
		    openFileDialog1.RestoreDirectory = true ;
		
		    if(openFileDialog1.ShowDialog() == DialogResult.OK)
		    {
		        try
		        {
		            if ((myStream = openFileDialog1.OpenFile()) != null)
		            {
		                using (myStream)
		                {
		                    // Insert code to read the stream here.
		                    tb_link.Text = openFileDialog1.FileName;
		                }
		            }
		        }
		        catch (Exception ex)
		        {
		            MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
		        }
		    }
	        
        }
        
        
        
        void Btt_abrirClick(object sender, EventArgs e)
        {
        	//Process.Start(tb_link.Text);
        	if (!string.IsNullOrWhiteSpace(tb_link.Text))
        		webBrowser2.Navigate(new Uri(tb_link.Text));
        	toolStripStatusLabel1.Text="Opción Abrir en browser";
        }
        
      
        
        void Btt_imp3Click(object sender, EventArgs e)
        {
        	
        	PageSetupDialog PageSetupDialog1 = new PageSetupDialog();
        	// Initialize the dialog's PrinterSettings property to hold user
	        // defined printer settings.
	        PageSetupDialog1.PageSettings =
	            new System.Drawing.Printing.PageSettings();
	
	        // Initialize dialog's PrinterSettings property to hold user
	        // set printer settings.
	        PageSetupDialog1.PrinterSettings =
	            new System.Drawing.Printing.PrinterSettings();
	
	        //Do not show the network in the printer dialog.
	        PageSetupDialog1.ShowNetwork = false;
	
	        //Show the dialog storing the result.
	        DialogResult result = PageSetupDialog1.ShowDialog();
	
	        // If the result is OK, display selected settings in
	        // ListBox1. These values can be used when printing the
	        // document.
	        if (result == DialogResult.OK)
	        {
	            object[] results = new object[]{ 
					PageSetupDialog1.PageSettings.Margins, 
					PageSetupDialog1.PageSettings.PaperSize, 
					PageSetupDialog1.PageSettings.Landscape, 
					PageSetupDialog1.PrinterSettings.PrinterName, 
					PageSetupDialog1.PrinterSettings.PrintRange};
	            listBox1.Items.AddRange(results);
	        }
	        
	        toolStripStatusLabel1.Text="Opción Imprime3";
        }
        
        
                
        
        
        void ControlToolStripMenuItemClick(object sender, EventArgs e)
        {
        	Rpt_Imp2 imprime = new Rpt_Imp2();
            imprime.ShowDialog();
            toolStripStatusLabel1.Text="Opción Imprime Previa";
        }
                
        
        void Btt_consultarClick(object sender, EventArgs e)
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
				
                tabla = new DataTable();
                tabla.Clear();
                datos = comando.ExecuteReader();
                
                tabla.Load(datos, LoadOption.OverwriteChanges);
                bindingSource1.DataSource=tabla;
                bindingNavigator1.BindingSource=bindingSource1;
                
                tb_n_fra.DataBindings.Add("Text",bindingSource1,"numfac",true);
                dat_f_fra.DataBindings.Add("Text",bindingSource1,"fec_fra",true);
                tb_cte.DataBindings.Add("Text",bindingSource1,"cliente",true);
                tb_base.DataBindings.Add("Text",bindingSource1,"base",true);
                tb_iva.DataBindings.Add("Text",bindingSource1,"p_iva",true);
                tb_tasas.DataBindings.Add("Text",bindingSource1,"tasas",true);
                
                comando.Connection.Close();
				
                Asigna_detalle(Convert.ToInt32(tb_n_fra.Text));
            }
        }
        
        void Asigna_detalle(int pnum_fra)
        {
        	//string sql = "select numfac,linea,descripcion,cantidad,precio, (cantidad * precio) as Total,iva_sn from linfac where numfac='"+ pnum_fra +"'";
            string sql = "select numfac,linea,descripcion,cantidad,precio,iva_sn from linfac where numfac='" + pnum_fra + "'";

            // AquÃ­ lanzas el proceso de guardado a la bd etc...
            using (BDConexion.ObtenerConexion())
            {
                comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                // Incrementamos hasta un minuto para evitar que de error cualquier ejecuciÃ³n comÃºn.
                comando.CommandTimeout = 5 * 60;
                adaptador = new NpgsqlDataAdapter(comando);
                //constructor = new NpgsqlCommandBuilder(adaptador);
                //conjunto = new DataSet();
                tabla_det = new DataTable();
                adaptador.Fill(tabla_det);                
                //adaptador.Fill(conjunto,"linfac");                
                //tabla_det = conjunto.Tables["linfac"];
                //comando.Connection.Close();  
                	
                dgv_lf.DataSource=tabla_det;
                dgv_lf.ReadOnly=true;
                dgv_lf.SelectionMode = DataGridViewSelectionMode.CellSelect; 
                dgv_lf.Columns[0].Visible = false;
                                
            }
        }
        
        void ToolStripButton1Click(object sender, EventArgs e)
        {
        	DataRow fila = tabla.NewRow();

        	fila["numfac"] = Convert.ToInt32(tb_n_fra.Text);
			fila["fec_fra"] = Convert.ToDateTime(dat_f_fra.Text);
			fila["cliente"] = Convert.ToInt32(tb_cte.Text);
			fila["base"] = Convert.ToDecimal(tb_base.Text);
			fila["p_iva"] = Convert.ToInt16(tb_iva.Text);
			fila["tasas"] = Convert.ToDecimal(tb_tasas.Text);
        	tabla.Rows.Add(fila);
        	
        	bindingSource1.DataSource=tabla;
            bindingNavigator1.BindingSource=bindingSource1;
        	
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            Asigna_detalle(Convert.ToInt32(tb_n_fra.Text));
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            Asigna_detalle(Convert.ToInt32(tb_n_fra.Text));
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            Asigna_detalle(Convert.ToInt32(tb_n_fra.Text));
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            Asigna_detalle(Convert.ToInt32(tb_n_fra.Text));
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
                adaptador.Update(tabla_det);
            }
        }

        private void btt_save_Click_1(object sender, EventArgs e)
        {
            //campo oculto numfac 
            //int fila_act = dgv_lf.CurrentRow.Index;
            if (dgv_lf.CurrentRow.Cells[0].Value == null)
                dgv_lf.CurrentRow.Cells[0].Value = Convert.ToInt32(tb_n_fra.Text);

            //if (conjunto.HasChanges())
            constructor = new NpgsqlCommandBuilder(adaptador);
            adaptador.Update(tabla_det);
            
            dgv_lf.ReadOnly = true;
            btt_save.Enabled = false;
            btt_new.Enabled = true;
            btt_del.Enabled = true;
        }

        private void btt_cancel_Click(object sender, EventArgs e)
        {
            btt_consultar.Enabled = true;
            dgv_lf.DataSource = null;
            dgv_lf.Refresh();
            bindingNavigator1.DataBindings.Clear();
            tabla.Clear();
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

        
        
                   
        
        
    }
}
