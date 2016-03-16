using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cartera
{
    public partial class frmCartera : Form
    {
        Color colorReadOnly = Color.LightSkyBlue;
        Color colorReadWrite = Color.LightSkyBlue;

        DataTable tablaCobros;
        DataTable tablaClientes;
        DataTable tablaPunteados;

        DataTable tablaConsulta;

        public frmCartera()
        {
            InitializeComponent();
            Globales.ConnectionStringComun = "";//Kripto.Desencriptar(@"c:\zs\zs.krp");
            Globales.ConnectionStringGest = Globales.ConnectionStringComun.Replace("comun", "gest01");

            tablaCobros = Tabla.Cobros.TablaADO();
            tablaClientes  = Tabla.Clientes.TablaADO();
            tablaPunteados = Tabla.Punteados.TablaADO();

            this.dgvRejillaDatos.AllowUserToAddRows = false;
            this.dgvRejillaDatos.MultiSelect = false;
            this.dgvRejillaDatos.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;

            // Creamos los eventos.
            this.dgvRejillaDatos.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            this.dgvRejillaDatos.CellValidated += new DataGridViewCellEventHandler(dataGridView1_CellValidated);
            this.dgvRejillaDatos.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            this.dgvRejillaDatos.KeyDown += new KeyEventHandler(dataGridView1_KeyDown);
            this.dgvRejillaDatos.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
            this.dgvRejillaDatos.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);
            this.dgvRejillaDatos.CellLeave += new DataGridViewCellEventHandler(dataGridView1_CellLeave);


            #region " Creamos tabla necesaria para rellenar los datos según consulta "

            this.tablaConsulta = new DataTable("Consulta");
            DataColumn columna;

            columna = new DataColumn("IdFactura");
            tablaConsulta.Columns.Add(columna);
            columna = new DataColumn("Cliente");
            tablaConsulta.Columns.Add(columna);
            columna = new DataColumn("Fecha");
            tablaConsulta.Columns.Add(columna);
            columna = new DataColumn("Fec.Anotación");
            tablaConsulta.Columns.Add(columna);
            columna = new DataColumn("Anotación");
            tablaConsulta.Columns.Add(columna);
            columna = new DataColumn("Punteado");
            tablaConsulta.Columns.Add(columna);

            #endregion



        }

        private void btObtenerDatos_Click(object sender, EventArgs e)
        {
            string codigoClienteConsulta = "0";

            this.dgvRejillaDatos.Rows.Clear();
            this.dgvRejillaDatos.Columns.Clear();

            if (this.tbCodigoCliente.Text.Trim().Length > 0)
            {
                // si lleva un asterisco debe buscar todo
                if (this.tbCodigoCliente.Text.Contains("*"))
                {
                    codigoClienteConsulta = "*";
                }
                else
                {
                    if (this.tbCodigoCliente.Text.Contains("-"))
                    {
                        string[] enPartes = this.tbCodigoCliente.Text.Split('-');
                    }
                    else
                    {
                        codigoClienteConsulta = this.tbCodigoCliente.Text;
                    }
                }
            }

            this.consultaDatos(codigoClienteConsulta);
            if (this.dgvRejillaDatos.Rows.Count > 0)
            {
                this.dgvRejillaDatos.Focus();
            }
        }

        private void btInsertarLinea_Click(object sender, EventArgs e)
        {
            int indiceFila = 0;

            ////// Sólo puede seleccionar una fila.
            DataGridViewSelectedRowCollection filasSeleccionadas = this.dgvRejillaDatos.SelectedRows;

            if (filasSeleccionadas.Count > 0)
            {
                DataGridViewRow fila = filasSeleccionadas[0];
                indiceFila = fila.Index + 1;
                DataGridViewRow filaNueva = new DataGridViewRow();
                this.dgvRejillaDatos.Rows.Insert(indiceFila, filaNueva);

                this.configuraDataGridView(indiceFila, false);

                this.dgvRejillaDatos.Rows[indiceFila].Cells[0].Value = this.dgvRejillaDatos.Rows[indiceFila - 1].Cells[0].Value;
                this.dgvRejillaDatos.Rows[indiceFila].Cells[5].Value = DateTime.Now;
                this.dgvRejillaDatos.CurrentCell = this.dgvRejillaDatos.Rows[indiceFila].Cells[6];
                this.dgvRejillaDatos.BeginEdit(false);
            }
            else
            {
                foreach (DataGridViewCell celda in this.dgvRejillaDatos.SelectedCells)
                {
                    DataGridViewRow filaNueva = new DataGridViewRow();
                    indiceFila = celda.RowIndex + 1;
                    this.dgvRejillaDatos.Rows.Insert(indiceFila, filaNueva);

                    this.configuraDataGridView(indiceFila, false);

                    this.dgvRejillaDatos.Rows[indiceFila].Cells[0].Value = this.dgvRejillaDatos.Rows[indiceFila - 1].Cells[0].Value;
                    this.dgvRejillaDatos.Rows[indiceFila].Cells[5].Value = DateTime.Now;
                    this.dgvRejillaDatos.CurrentCell = this.dgvRejillaDatos.Rows[indiceFila].Cells[6];
                    this.dgvRejillaDatos.BeginEdit(false);
                }
            }
        }

        private void btGuardarDatos_Click(object sender, EventArgs e)
        {
            this.tablaConsulta.Clear();

            StringBuilder filaRejilla = new StringBuilder();
            DataRow filaTabla;

            // Rellenamos la tabla que debemos guardar
            for (int a = 0; a != this.dgvRejillaDatos.Rows.Count; a++)
            {
                filaRejilla = new StringBuilder();

                string[] cliente = ((string)this.dgvRejillaDatos.Rows[0].Cells[3].Value).Split(' ');

                // Si la columna factura es "" quiere decir que estamos en un registro que debemos guardar.
                if (this.dgvRejillaDatos.Rows[a].Cells[1].Value == "")
                {
                    filaTabla = this.tablaConsulta.NewRow();
                    // IdFacturaVenta
                    filaTabla[0] = this.dgvRejillaDatos.Rows[a].Cells[0].Value;
                    // Cliente
                    filaTabla[1] = cliente[0];
                    // Fecha
                    filaTabla[2] = DateTime.Today.ToShortDateString();
                    // Fec.Anotación
                    filaTabla[3] = Convert.ToDateTime(this.dgvRejillaDatos.Rows[a].Cells[5].Value).ToShortDateString();
                    // Anotación
                    filaTabla[4] = this.dgvRejillaDatos.Rows[a].Cells[6].Value;
                    // Punteado
                    filaTabla[5] = Convert.ToInt16(this.dgvRejillaDatos.Rows[a].Cells[7].Value);

                    this.tablaConsulta.Rows.Add(filaTabla);


                    // Convertir fecha a número
                    //////DateTime fecha = Convert.ToDateTime(this.dgvRejillaDatos.Rows[a].Cells[5].Value);
                    //////long ticks = fecha.Ticks;
                    //////fecha = new DateTime(ticks);
                }
            }

            Kripto.GuardaDatos(this.tablaConsulta);
        }

        private void configuraDataGridView(int indiceFila, bool soloLectura)
        {

            if (!soloLectura)
            {
                this.colorReadWrite = Color.PaleGreen;
            }

            // Esta primera columna se oculta, este código no funciona como tal pero se mantiene para ver las columnas de las
            // que consta el datagridview.
            //this.dataGridView1.Rows[indiceFila].Cells["Id"].Visible = false;


            this.dgvRejillaDatos.Rows[indiceFila].Cells["Factura"].ReadOnly = soloLectura;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Factura"].Style.BackColor = this.colorReadOnly;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Factura"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Factura"].Value = "";

            this.dgvRejillaDatos.Rows[indiceFila].Cells["Fecha"].ReadOnly = soloLectura;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Fecha"].Style.BackColor = this.colorReadOnly;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Fecha"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Fecha"].Value = "";

            this.dgvRejillaDatos.Rows[indiceFila].Cells["Cliente"].ReadOnly = soloLectura;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Cliente"].Style.BackColor = this.colorReadOnly;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Cliente"].Value = "";

            this.dgvRejillaDatos.Rows[indiceFila].Cells["Importe"].ReadOnly = soloLectura;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Importe"].Style.BackColor = this.colorReadOnly;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Importe"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Importe"].Value = "";

            this.dgvRejillaDatos.Rows[indiceFila].Cells["Fec.Anotación"].ReadOnly = soloLectura;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Fec.Anotación"].Style.BackColor = this.colorReadWrite;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Fec.Anotación"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Fec.Anotación"].Value = "";

            this.dgvRejillaDatos.Rows[indiceFila].Cells["Anotación"].ReadOnly = soloLectura;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Anotación"].Style.BackColor = this.colorReadWrite;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Anotación"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Anotación"].Value = "";

            this.dgvRejillaDatos.Rows[indiceFila].Cells["Punteado"].ReadOnly = soloLectura;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Punteado"].Style.BackColor = this.colorReadWrite;
            this.dgvRejillaDatos.Rows[indiceFila].Cells["Punteado"].Value = 0;
        }

        private void consultaDatos(string codigoClienteConsulta)
        {
            #region " Creamos la tabla del datagridview que contendrá los datos "

            DataGridViewColumn columnaDgw;

            columnaDgw = new DataGridViewTextBoxColumn();
            columnaDgw.HeaderText = "Id";
            columnaDgw.Name = "Id";
            columnaDgw.Resizable = DataGridViewTriState.False;
            columnaDgw.Width = 100;
            this.dgvRejillaDatos.Columns.Add(columnaDgw);

            columnaDgw = new DataGridViewTextBoxColumn();
            columnaDgw.HeaderText = "Factura";
            columnaDgw.Name = "Factura";
            columnaDgw.Resizable = DataGridViewTriState.False;
            columnaDgw.Width = 100;
            this.dgvRejillaDatos.Columns.Add(columnaDgw);

            columnaDgw = new DataGridViewTextBoxColumn();
            columnaDgw.HeaderText = "Fecha";
            columnaDgw.Name = "Fecha";
            columnaDgw.Resizable = DataGridViewTriState.False;
            columnaDgw.Width = 100;
            this.dgvRejillaDatos.Columns.Add(columnaDgw);

            columnaDgw = new DataGridViewTextBoxColumn();
            columnaDgw.HeaderText = "Cliente";
            columnaDgw.Name = "Cliente";
            columnaDgw.Resizable = DataGridViewTriState.False;
            columnaDgw.Width = 300;
            this.dgvRejillaDatos.Columns.Add(columnaDgw);

            columnaDgw = new DataGridViewTextBoxColumn();
            columnaDgw.HeaderText = "Importe";
            columnaDgw.Name = "Importe";
            columnaDgw.Resizable = DataGridViewTriState.False;
            columnaDgw.Width = 100;
            this.dgvRejillaDatos.Columns.Add(columnaDgw);

            columnaDgw = new CalendarColumn();
            columnaDgw.HeaderText = "Fec.Anotación";
            columnaDgw.Name = "Fec.Anotación";
            columnaDgw.Resizable = DataGridViewTriState.False;
            columnaDgw.Width = 100;
            this.dgvRejillaDatos.Columns.Add(columnaDgw);

            columnaDgw = new DataGridViewTextBoxColumn();
            columnaDgw.HeaderText = "Anotación";
            columnaDgw.Name = "Anotación";
            columnaDgw.Resizable = DataGridViewTriState.False;
            columnaDgw.Width = 100;
            this.dgvRejillaDatos.Columns.Add(columnaDgw);

            columnaDgw = new DataGridViewCheckBoxColumn();
            columnaDgw.HeaderText = "Punteado";
            columnaDgw.Name = "Punteado";
            columnaDgw.Resizable = DataGridViewTriState.False;
            columnaDgw.Width = 80;
            this.dgvRejillaDatos.Columns.Add(columnaDgw);

            #endregion

            // La primera columna, que es la que tiene el Id, no debe ser visible.
            this.dgvRejillaDatos.Columns[0].Visible = false;

            #region " Realizamos las consultas pertinentes "

            decimal idCliente;
            string codigoCliente;
            string nombreCliente;
            //decimal idCobro;
            decimal idFacturaVenta;
            string factura;
            string fechaFactura;
            string importe;
            string fechaAnotacion = "";
            string anotacion = "";
            decimal punteado = 0;

            // Variables de trabajo.
            decimal ejercicio = 0;
            decimal serie = 0;
            decimal numero = 0;
            decimal variableTemporal = 0;
            int indiceRegistro = 0;
            string consultaCobros = "select * from Cobros";

            //if (codigoClienteConsulta == "*")
            //{
            //    consultaCobros = "select * from Cobros";
            //}
            //else
            //{
            //    consultaCobros = "select * from Cobros where IdCliente = '" + codigoClienteConsulta + "'";
            //}

            // Obtenemos los datos guardados en el fichero cp.
            //this.tablaConsulta.Clear();
            //Kripto.CargaDatos(this.tablaConsulta);

            // Recogemos todos los datos de cobros y los respasamos para ir montando la tabla a mostrar.
            //sql.ConsultarSQL(consultaCobros, this.tablaCobros, false);
            //for (int a = 0; a != this.tablaCobros.Rows.Count; a++)
            //{
            //    // Obtenemos la factura.
            //    ejercicio = Convert.ToDecimal(this.tablaCobros.Rows[a].ItemArray[5]);
            //    serie = Convert.ToDecimal(this.tablaCobros.Rows[a].ItemArray[6]);
            //    numero = Convert.ToDecimal(this.tablaCobros.Rows[a].ItemArray[7]);
            //    factura = ejercicio + "-" + string.Format("{0:00}", serie) + "-" + string.Format("{0:000000}", numero);
            //    // Obtenemos la fecha de la factura.
            //    fechaFactura = Convert.ToDateTime(this.tablaCobros.Rows[a].ItemArray[8]).ToShortDateString();
            //    // Obtenemos el importe del descuento.
            //    variableTemporal = Convert.ToDecimal(this.tablaCobros.Rows[a].ItemArray[19]);
            //    importe = string.Format("{0:C}", variableTemporal);
                
            //    // Obtenemos el idFacturaVenta.
            //    idFacturaVenta = Convert.ToDecimal(this.tablaCobros.Rows[a].ItemArray[3]);
            //    // Obtenemos el id del cliente para pintar su nombre.
            //    idCliente = Convert.ToDecimal(this.tablaCobros.Rows[a].ItemArray[10]);
            //    sql.ConsultarSQL("select * from Clientes where Id = '" + idCliente + "'", this.tablaClientes, false);
            //    // Obtenemos el código del cliente.
            //    codigoCliente = Convert.ToString(this.tablaClientes.Rows[0].ItemArray[3]);
            //    // Obtenemos el nombre del cliente.
            //    nombreCliente = Convert.ToString(this.tablaClientes.Rows[0].ItemArray[8]);

                // Insertamos un nuevo registro.
                this.dgvRejillaDatos.Rows.Add();

                this.configuraDataGridView(indiceRegistro, false);

                // Rellenamos los datos del nuevo registro creado.
                this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Id"].Value = 0; // idFacturaVenta;

                this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Factura"].Value = "100";//factura;

                this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Fecha"].Value = "10/10/2015"; // fechaFactura;

                this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Cliente"].Value = "Nombre Cliente "; // codigoCliente + " " + nombreCliente;

                this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Importe"].Value = "1200";// importe;

                this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Fec.Anotación"].Value = "";// fechaAnotacion;

                this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Anotación"].Value = "120"; // anotacion;

                this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Punteado"].Value = punteado;

                // Incrementamos el indiceRegistro para que apunte bien al registro correspondiente de la rejilla.
                indiceRegistro++;

            //    // Insertamos las líneas correspondientes a las anotaciones.
            //    // Esto sale del fichero cp
            //    if (tablaConsulta.Rows.Count > 0)
            //    {
            //        tablaConsulta.DefaultView.RowFilter = "IdFactura = " + idFacturaVenta;
            //        DataView vista = tablaConsulta.DefaultView;

            //        for (int b = 0; b != vista.Count; b++)
            //        {
            //            this.dgvRejillaDatos.Rows.Add();

            //            this.configuraDataGridView(indiceRegistro, true);

            //            // Rellenamos los datos del nuevo registro creado.
            //            this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Id"].Value = vista[b].Row.ItemArray[0];
            //            this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Factura"].Value = "";
            //            this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Fecha"].Value = "";
            //            this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Cliente"].Value = "";
            //            this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Importe"].Value = "";
            //            this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Fec.Anotación"].Value = vista[b].Row.ItemArray[3];
            //            this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Anotación"].Value = vista[b].Row.ItemArray[4];
            //            this.dgvRejillaDatos.Rows[indiceRegistro].Cells["Punteado"].Value = Convert.ToInt32(vista[b].Row.ItemArray[5]);

            //            // Incrementamos el indiceRegistro para que apunte bien al registro correspondiente de la rejilla.
            //            indiceRegistro++;                        
            //        }
            //    }
            //}

            #endregion
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell celda = ((DataGridView)sender).CurrentCell;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewCell celda = ((DataGridView)sender).CurrentCell;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n')
            {
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((DataGridView)sender).CurrentCell.Value = null;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (!e.Handled)
                {
                    //e.Handled = true;
                    //e.SuppressKeyPress = true;
                    //SendKeys.Send("\t");
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell celda = ((DataGridView)sender).CurrentCell;

            if (celda.ColumnIndex == 6)
            {
                string valor = Convert.ToString(celda.Value);

                if (valor.Contains('.'))
                {
                    celda.Value = valor.Replace('.', ',');
                }

                ////if (((DataGridView)sender).CurrentCell.IsInEditMode)
                ////{
                ////    //((DataGridView)sender).EditMode = DataGridViewEditMode.EditOnKeystroke;
                ////    //((DataGridView)sender).EndEdit();
                ////    //DataGridViewCell celda = ((DataGridView)sender).CurrentCell;
                ////    //((DataGridView)sender).CurrentCell = celda;
                ////    //SendKeys.Send("\t");
                ////}
                //////this.dataGridView1.Columns["Anotación"].DefaultCellStyle.Format = "c";
                //////string valor = Convert.ToString(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                //////this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Format = string.Format("{0:C}", valor);
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                //e.CellStyle.Format = "c";
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                prueba (e);
            }
        }

        private void prueba(DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (e.Value != null)
                {
                    decimal valorValido = 0;

                    string cadena = Convert.ToString(e.Value);
                    if (cadena.Trim().Length > 0)
                    {
                        if (cadena.Contains("€"))
                        {
                            decimal valorDec = decimal.Parse(cadena.Replace('€', ' '));
                            string valor = string.Format("{0:C}", valorDec);
                            e.Value = valor;
                            e.FormattingApplied = true;
                        }
                        else
                        {
                            bool result = decimal.TryParse(cadena, out valorValido);
                            if (result)
                            {
                                string valor = string.Format("{0:C}", valorValido);
                                e.Value = valor;
                                e.FormattingApplied = true;
                            }
                            else
                            {
                                e.Value = "";
                            }
                        }
                    }
                }
            }
        }
    }
}
