using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace cartera
{
    public static class sql
    {

        #region " Campos "

        private static NpgsqlConnection connection = new NpgsqlConnection();
        private static NpgsqlCommand command = new NpgsqlCommand();
        private static NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();

        #endregion

        #region "Inserción, modificación, borrado y consulta "
        
        public static void InsertarSQL(string sqlInsert, DataTable tabla)
        {
            // Resultado contiene cero si la inserción ha sido correcta o el número de la excepción en caso de error.
            //int resultado = Globales.Resultado_Correcto;
            // En este campo obtendremos el mensaje del error para así encontrar el control al que hay que ponerle el error provider. 
            //string mensajeError = "";
            //string[] enPartes;
            //string[] tablaCampo;
            //Control[] control;

            //try
            //{
                sql.ejecucionComun(sqlInsert, obtenerCadenaConexionTabla(tabla));
            //}
            //catch (NpgsqlException excepcion)
            //{
            //    resultado = Globales.Resultado_ErrorInsercion;

            //    switch (excepcion.Code)
            //    {
            //        case "23505":
            //            mensajeError = excepcion.BaseMessage;
            //            //llave duplicada viola restricción de unicidad «registroproduccion_idparteproduccion_key»
            //            enPartes = mensajeError.Split('«');
            //            tablaCampo = enPartes[1].Split('_');
            //            if (formBase != null)
            //            {
            //                try
            //                {
            //                    control = formBase.Controls.Find(tablaCampo[0] + "." + tablaCampo[1], true);
            //                    if (control.Length > 0)
            //                    {
            //                        ((TB)control[0]).errorProvider.SetError(control[0], Globales.MensajeErrorSqlCodigoExiste);
            //                    }
            //                }
            //                catch
            //                {
            //                }
            //            }
            //            break;
            //    }
            //}
            // Devolvemos el código de error.
            //return resultado;
        }

        public static void ModificarSQL(string sqlModify, DataTable tabla)
        {
            // Resultado contiene cero si todo ha ido bien, en caso contrario el número de error.
            //int resultado = Globales.Resultado_Correcto;

            //try
            //{
                sql.ejecucionComun(sqlModify, obtenerCadenaConexionTabla(tabla));
            //}
            //catch (NpgsqlException excepcion)
            //{
            //    resultado = Globales.Resultado_ErrorModificacion;

            //    switch (excepcion.ErrorCode)
            //    {
            //        // Intento de modificar una clave unica ya existente.
            //        case 1:
            //            formBase.PrimerControlConElFoco.errorProvider.SetError(formBase.PrimerControlConElFoco, Globales.MensajeErrorSqlCodigoExiste);                
            //            formBase.PrimerControlConElFoco.Focus();
            //            break;
            //    }
            //}

            //// Devolvemos el código de error.
            //return resultado;
        }

        public static void BorrarSQL(string sqlDelete, DataTable tabla)
        {
            // Resultado contiene cero si el borrado ha sido correcto o el número de la excepción en caso de error.
            //int resultado = Globales.Resultado_Correcto;

            //try
            //{
                sql.ejecucionComun(sqlDelete, obtenerCadenaConexionTabla(tabla));
            //    if (formBase != null)
            //    {
            //        formBase.PrimerControlConElFoco.Focus();
            //    }
            //}
            //catch (NpgsqlException excepcion)
            //{
            //    // guardamos el número del error que devolveremos a quien nos ha llamado.
            //    resultado = Globales.Resultado_ErrorBorrado;

            //    switch (excepcion.ErrorCode)
            //    {
            //        // Intento de borrado de un registro que está referenciado(Foreign Key) y está en uso.
            //        case 2292:
            //            formBase.PrimerControlConElFoco.errorProvider.SetError(formBase.PrimerControlConElFoco, Globales.MensajeErrorSqlRegistroEnUso);
            //            break;

            //        // Transacción abortada por algún error.
            //        case -2147467259:
            //            formBase.PrimerControlConElFoco.errorProvider.SetError(formBase.PrimerControlConElFoco, Globales.MensajeErrorSqlRegistroEnUso);                
            //            break;
            //    }
            //}

            //// Devolvemos el código de error.
            //return resultado;
        }
        
        public static void ConsultarSQL(string sqlSelect, DataTable tabla, bool filtrarFilasRepetidas)
        {
            // Ponemos el cursor RelojArena para indicar que está procesando algo.
            //Cursor.Current = Cursors.WaitCursor;

            // Limpiamos la tabla de los posibles datos que pudiera tener.
            tabla.Clear();

            NpgsqlDataReader dr;
            using (NpgsqlConnection connection = new NpgsqlConnection(obtenerCadenaConexionTabla(tabla)))
            {
                NpgsqlCommand command = new NpgsqlCommand("", connection);
                command.Connection.Open();
                command.CommandText = sqlSelect;
                // Incrementamos el tiempo de espera hasta que de error a 2 minutos.
                command.CommandTimeout = 120;

                dr = command.ExecuteReader();

                DataRow registro;

                while (dr.Read())
                {
                    registro = tabla.NewRow();
                    for (int a = 0; a != tabla.Columns.Count; a++)
                    {
                        registro[a] = dr[a];
                    }

                    if (filtrarFilasRepetidas)
                    {
                        if (tabla.PrimaryKey.Length > 0)
                        {
                            if (!tabla.Rows.Contains(registro.ItemArray[0]))
                            {
                                tabla.Rows.Add(registro);
                            }
                        }
                        else
                        {
                            // Si no tiene clave principal debemos insertar el registro en la tabla.
                            tabla.Rows.Add(registro);
                        }
                    }
                    else
                    {
                        // Insertamos el registro en la tabla.
                        tabla.Rows.Add(registro);
                    }
                }
                dr.Dispose();
            }

            // Reponemos el cursor por defecto.
            //Cursor.Current = Cursors.Default;
        }

        //public static void ConsultarEstructuraTabla(DataTable tabla)
        //{

        //    string sqlSelect = "select column_name from information_schema.columns where table_name = '" + tabla.TableName.ToLower() + "'";
        //    int posicion;
        //    SortedList<int, string> listaColumnas = new SortedList<int, string>();

        //    NpgsqlDataReader dr;
        //    using (NpgsqlConnection connection = new NpgsqlConnection(obtenerCadenaConexionTabla(tabla)))
        //    {
        //        NpgsqlCommand command = new NpgsqlCommand("", connection);
        //        command.Connection.Open();
        //        command.CommandText = sqlSelect;
        //        dr = command.ExecuteReader();
        //        posicion = 0;
        //        while (dr.Read())
        //        {
        //            listaColumnas.Add(posicion, Convert.ToString(dr[0]));
        //            posicion++;
        //        }
        //        dr.Dispose();

        //        // Una vez obtenidos los datos de la tabla que existe en la BD los cotejamos con las columnas que están definidas en Tabla.
        //        // Lo primero es comprobar si son la misma cantidad de columnas.
        //        if (tabla.Columns.Count == listaColumnas.Count())
        //        {
        //            string nombreTablaBD = "";
        //            string nombreTablaTABLA = "";

        //            for (int a = 0; a != tabla.Columns.Count; a++)
        //            {
        //                nombreTablaBD = listaColumnas[a].ToLower();
        //                nombreTablaTABLA = tabla.Columns[a].ColumnName.ToLower();
        //                if (nombreTablaBD != nombreTablaTABLA)
        //                {
        //                    MessageBox.Show("Tabla: " + tabla.TableName + "\nPosición: " + a + "\nNombres no coincidentes: " + nombreTablaBD + " - " + nombreTablaTABLA + ".", "Atención");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            // Debemos mostrar un mensaje diciendo que no coinciden la cantidad de campos.
        //            MessageBox.Show("Comprobar la tabla " + tabla.TableName + ".\nNo coinciden la cantidad de columnas en BD-TABLA.", "Atención");
        //        }
        //    }
        //}

        //public static Decimal ObtenerId(frmBase formBase, string sqlSelectId, DataTable tabla)
        //{
        //    decimal resultado = 0;

        //    NpgsqlDataReader dr;
        //    using (NpgsqlConnection connection = new NpgsqlConnection(obtenerCadenaConexionTabla(tabla)))
        //    {
        //        NpgsqlCommand command = new NpgsqlCommand("", connection);
        //        command.Connection.Open();
        //        command.CommandText = sqlSelectId;
        //        dr = command.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            resultado = Convert.ToDecimal(dr[0]);
        //        }
        //        dr.Dispose();
        //    }
        //    return resultado;
        //}

        //public static Decimal ObtenerSumas(string sqlSelect, DataTable tabla)
        //{
        //    decimal resultado = 0;
        //    NpgsqlDataReader dr;
        //    using (NpgsqlConnection connection = new NpgsqlConnection(obtenerCadenaConexionTabla(tabla)))
        //    {
        //        NpgsqlCommand command = new NpgsqlCommand("", connection);
        //        command.Connection.Open();
        //        command.CommandText = sqlSelect;
        //        dr = command.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            if (dr[0] is DBNull)
        //            {
        //            }
        //            else
        //            {
        //                resultado = Convert.ToDecimal(dr[0]);
        //            }
        //        }
        //        dr.Dispose();
        //    }
        //    return resultado;
        //}

        //public static void CrearBD(string sql, string cadenaConexion)
        //{
        //    // Esta función sólo la lanza desde el principal la opción de menú "CreaBD" y en ese punto
        //    // se ha creado el try catch para evitar una excepción, aquí no funcionaría correctamente.
        //    DB.ejecucionComun(null, sql, cadenaConexion);
        //}

        //public static void CrearTabla(frmBase formBase, string sql, DataTable tabla)
        //{
        //    try
        //    {
        //        DB.ejecucionComun(formBase, sql, obtenerCadenaConexionTabla(tabla));
        //    }
        //    catch (NpgsqlException excepcion)
        //    {
        //        // Si entra en este punto se tiene que avisar mediante un messagebox
        //        MessageBox.Show(excepcion.ErrorSql, Globales.MensajeAvisoAtencion);
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------

        private static string obtenerCadenaConexionTabla(DataTable tabla)
        {
            string resultado = Convert.ToString(tabla.ExtendedProperties["CadenaConexionTabla"]);

            return resultado;
        }

        private static void ejecucionComun(string sqlInstructions, string cadenaConexionTabla)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(cadenaConexionTabla))
            {
                NpgsqlCommand command = new NpgsqlCommand(sqlInstructions, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        #endregion

    }
}

