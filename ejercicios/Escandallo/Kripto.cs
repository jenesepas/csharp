using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Data;

namespace cartera
{
    class Kripto
    {
        public static void Encriptar(string fichero, string cadenaParaEncriptar)
        {
            int longitudFichero = 26 * cadenaParaEncriptar.Length * 2;

            StreamWriter sw = new StreamWriter(fichero);
            Byte[] b = new Byte[longitudFichero];

            Random rnd = new Random((int)DateTime.Now.Ticks); ;
            rnd.NextBytes(b);
            //Obtenemos la longitud de la cadena a encriptar y la almacenamos en la posición 0 del fichero.
            b[0] = Convert.ToByte(cadenaParaEncriptar.Length);

            int posicion = 1;
            int indice = 0;
            int contador = 1;

            for (int a = 0; a != b.Length; a++)
            {
                if (a == posicion)
                {
                    if (indice == cadenaParaEncriptar.Length)
                    {
                        //Ya no debe recorrer la cadena.
                    }
                    else
                    {
                        b[a] = Convert.ToByte(Convert.ToChar(cadenaParaEncriptar.Substring(indice, 1)));
                        indice++;
                        switch (contador)
                        {
                            case 1:
                                posicion += 9;
                                contador++;
                                break;
                            case 2:
                                posicion += 6;
                                contador++;
                                break;
                            case 3:
                                posicion += 8;
                                contador++;
                                break;
                            case 4:
                                posicion += 1;
                                contador = 1;
                                break;
                        }
                    }
                }
                sw.Write((char)b[a]);
            }

            sw.Close();
        }

        public static string Desencriptar(string fichero)
        {
            string cadenaDesencriptada = "";

            StreamReader sr = new StreamReader(fichero);

            int posicion = 1;
            int contador = 1;

            string bloque = sr.ReadToEnd();
            byte[] b = new Byte[bloque.Length];

            //Obtenemos la longitud de la cadena a desencriptar de la posición cero del fichero.
            char[] ch = bloque.ToCharArray(0, 1);
            int longitud = Convert.ToInt32(ch[0]);

            for (int a = 0; a != bloque.Length; a++)
            {
                if (a == posicion)
                {
                    if (longitud == cadenaDesencriptada.Length)
                    {
                        //Ya hemos obtenido la cadena encriptada.
                    }
                    else
                    {
                        switch (contador)
                        {
                            case 1:
                                cadenaDesencriptada += bloque.Substring(posicion, 1);
                                posicion += 9;
                                contador++;
                                break;
                            case 2:
                                cadenaDesencriptada += bloque.Substring(posicion, 1);
                                posicion += 6;
                                contador++;
                                break;
                            case 3:
                                cadenaDesencriptada += bloque.Substring(posicion, 1);
                                posicion += 8;
                                contador++;
                                break;
                            case 4:
                                cadenaDesencriptada += bloque.Substring(posicion, 1);
                                posicion += 1;
                                contador = 1;
                                break;
                        }
                    }
                }
            }
            return cadenaDesencriptada;
        }

        //public static void DescargaDatos(System.Data.DataTable tabla) //, string columnaOrderBy)
        //{
        //    string columnaOrderBy = tabla.Columns[0].ColumnName;
        //    tabla.Clear();

        //    string cadenaOrderby = "";
        //    if (columnaOrderBy.Trim().Length > 0)
        //    {
        //        cadenaOrderby = " order by " + columnaOrderBy;
        //    }
        //    sql.ConsultarSQL("select * from " + tabla.TableName + cadenaOrderby, tabla, false);

        //    string fecha = string.Format("{0:yyyy}-{0:MM}-{0:dd}", DateTime.Now);
        //    //string directorio = @"c:\zs\gctap\" + Globales.CodigoEmpresa + @"\" + Globales.FechaMinima.Year + @"\" + fecha + @"\";
        //    string directorio = @"c:\zs\gctap\" + Globales.NombreEmpresa + @"\" + Globales.FechaMinima.Year + @"\" + fecha + @"\";
        //    if (!Directory.Exists(directorio))
        //    {
        //        Directory.CreateDirectory(directorio);
        //    }
        //    string fichero = tabla.TableName + ".zcs";
        //    string fileName = directorio + fichero;
        //    StringBuilder linea;
        //    StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode);

        //    for (int a = 0; a != tabla.Rows.Count; a++)
        //    {
        //        linea = new StringBuilder();
        //        for (int b = 0; b != tabla.Columns.Count; b++)
        //        {
        //            if (tabla.Columns[b].DataType == typeof(System.DateTime))   
        //            {
        //                linea.Append(((System.DateTime)tabla.Rows[a].ItemArray[b]).ToShortDateString() + "|");
        //            }
        //            else if (tabla.Columns[b].DataType == typeof(System.Decimal))
        //            {
        //                string valorConPunto = Convert.ToString(tabla.Rows[a].ItemArray[b]).Replace(',','.');
        //                linea.Append(valorConPunto + "|");
        //            }
        //            else
        //            {
        //                linea.Append(tabla.Rows[a].ItemArray[b] + "|");
        //            }
        //        }
        //        sw.WriteLine(linea);
        //    }

        //    sw.Close();

        //    #region " PROCESO DE ENCRIPTADO DE LOS DATOS DESCARGADOS. "

        //    // La contraseña debe ser la misma que la de la cadena de conexión.
        //    string password = "";
        //    string[] parametros = Globales.ConnectionStringComun.Split(';');
        //    for (int a = 0; a != parametros.Length; a++)
        //    {
        //        string[] valorParametro = parametros[a].Split('=');
        //        if (valorParametro[0] == "Password")
        //        {
        //            password = valorParametro[1];
        //        }
        //    }

        //    // Comprimimos y encriptamos con contraseña el fichero descargado.
        //    string targetName = tabla.TableName + ".7z";
        //    string sourceName = tabla.TableName + ".zcs";
        //    System.Diagnostics.ProcessStartInfo procesoDeEncriptado = new System.Diagnostics.ProcessStartInfo();
        //    procesoDeEncriptado.FileName = @"c:\zs\7-Zip\7z.exe";
        //    procesoDeEncriptado.WorkingDirectory = directorio;
        //    procesoDeEncriptado.Arguments = "a -p" + password + " " + "\"" + targetName + "\"" + " " + "\"" + sourceName + "\" -mx=9";
        //    procesoDeEncriptado.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        //    // Lanzamos el proceso.
        //    System.Diagnostics.Process x = System.Diagnostics.Process.Start(procesoDeEncriptado);
        //    x.WaitForExit();

        //    // Borramos el fichero sin encriptar.
        //    File.Delete(directorio + sourceName);

        //    #endregion
        //}

        //public static void CargaDatos(System.Data.DataTable tabla, string rutaFichero)
        //{     
        //    string ficheroEncriptado = rutaFichero + "\\" + tabla.TableName + ".7z";
        //    string ficheroDesencriptado = rutaFichero + "\\" + tabla.TableName + ".zcs";

        //    if (File.Exists(ficheroEncriptado))
        //    {

        //        // La contraseña debe ser la misma que la de la cadena de conexión.
        //        string password = "";
        //        string[] parametros = Globales.ConnectionStringComun.Split(';');
        //        for (int a = 0; a != parametros.Length; a++)
        //        {
        //            string[] valorParametro = parametros[a].Split('=');
        //            if (valorParametro[0] == "Password")
        //            {
        //                password = valorParametro[1];
        //            }
        //        }

        //        // Descomprimimos y desencriptamos el fichero de la copia de seguridad.
        //        string targetName = tabla.TableName + ".7z";
        //        string sourceName = tabla.TableName + ".zcs";
        //        System.Diagnostics.ProcessStartInfo procesoDeEncriptado = new System.Diagnostics.ProcessStartInfo();
        //        procesoDeEncriptado.FileName = @"c:\zs\7-Zip\7z.exe";
        //        procesoDeEncriptado.WorkingDirectory = rutaFichero; //directorio;
        //        procesoDeEncriptado.Arguments = "x -p" + password + " " + "\"" + targetName + "\"" + " " + "\"" + sourceName + "\" -mx=9";
        //        procesoDeEncriptado.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        //        // Lanzamos el proceso.
        //        System.Diagnostics.Process x = System.Diagnostics.Process.Start(procesoDeEncriptado);
        //        x.WaitForExit();

        //        StreamReader sr = new StreamReader(ficheroDesencriptado);

        //        // Leemos todos los datos.
        //        string datos = sr.ReadToEnd();

        //        // Cerramos el fichero y...
        //        sr.Close();

        //        // Borramos el fichero desencriptado una vez obtenidos sus datos.
        //        File.Delete(ficheroDesencriptado);

        //        // Formateamos los datos para poder acceder a ellos de manera optima.
        //        datos = datos.Replace("\r\n", "");
        //        string[] camposDatos = datos.Split('|');
        //        string cadenaValoresDatos = "";

        //        // Calculamos las pasadas que debe de hacer de la siguiente manera.
        //        int bucles = (camposDatos.Length - 1) / tabla.Columns.Count;
        //        int posicionDatos = 0;

        //        for (int bucle = 0; bucle != bucles; bucle++)
        //        {
        //            // Limpiamos la variable contenedora de la instrucción sql.
        //            cadenaValoresDatos = "";

        //            for (int a = 0; a != tabla.Columns.Count; a++)
        //            {
        //                cadenaValoresDatos += "'" + camposDatos[posicionDatos++] + "'";

        //                if (a != tabla.Columns.Count - 1)
        //                {
        //                    cadenaValoresDatos += ",";
        //                }
        //            }
        //            using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(Convert.ToString(tabla.ExtendedProperties["CadenaConexionTabla"])))
        //            {
        //                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("insert into " + tabla.TableName + " values(" + cadenaValoresDatos + ")", connection);
        //                command.Connection.Open();
        //                try
        //                {
        //                    command.ExecuteNonQuery();
        //                }
        //                catch
        //                {
        //                }
        //            }
        //        }

        //            #region " proceso de carga anterior "

        //            // Proceso anterior que leía la línea, si se encontraba algún intro por enmedio se joroba el proceso porque captura menos campos
        //            // de los que realmente son.

        //            //while (!sr.EndOfStream)
        //            //{
        //                //string linea = sr.ReadLine();
        //            //string[] campos = linea.Split('|');
        //            //string cadenaValores = "";

        //            //for (int a = 0; a != tabla.Columns.Count; a++)
        //            //{
        //            //    cadenaValores += "'" + campos[a] + "'";

        //            //    if (a != tabla.Columns.Count - 1)
        //            //    {
        //            //        cadenaValores += ",";
        //            //    }
        //            //}
        //            // Insertamos el registro que hemos recogido del fichero correspondiente.
        //            //using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(Convert.ToString(tabla.ExtendedProperties["CadenaConexionTabla"])))
        //            //{
        //            //    Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("insert into " + tabla.TableName + " values(" + cadenaValores + ")", connection);
        //            //    command.Connection.Open();
        //            //    command.ExecuteNonQuery();
        //            //}
        //            //}
        //            //sr.Close();

        //            // Borramos el fichero sin encriptar.
        //            //File.Delete(ficheroDesencriptado);

        //            #endregion

        //    }
        //}

        public static string SHA(string cadena)
        {
            string resultado = "";

            try
            {
                UnicodeEncoding codificador = new UnicodeEncoding();

                byte[] datos = codificador.GetBytes(cadena);
                byte[] cadenaEncriptada;

                SHA1 encriptarSHA = new SHA1CryptoServiceProvider();
                cadenaEncriptada = encriptarSHA.ComputeHash(datos);

                StringBuilder sBuilder = new StringBuilder();

                // Repite a traves de cada byte de el hash y formatea cada uno como un string hexadecimal.

                for (int i = 0; i < cadenaEncriptada.Length; i++)
                {

                    sBuilder.Append(cadenaEncriptada[i].ToString("x2"));

                }

                //System.Windows.Forms.MessageBox.Show("Texto a Encriptar: " + cadena);
                //System.Windows.Forms.MessageBox.Show("Texto Encriptado : " + sBuilder.ToString());

                resultado = sBuilder.ToString();
            }
            catch (ArgumentNullException)
            {
                System.Windows.Forms.MessageBox.Show("Fallo en la Encriptacion");
            }

            return resultado;
        }


        public static void GuardaDatos(System.Data.DataTable tabla)
        {
            
            string directorio = @"c:\zs\cp\";
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
            string fichero = "cp.zcs";
            string fileName = directorio + fichero;
            StringBuilder linea;
            StreamWriter sw = new StreamWriter(fileName, true, Encoding.Unicode);
            
            for (int a = 0; a != tabla.Rows.Count; a++)
            {
                linea = new StringBuilder();

                if (a == 0)
                {
                    linea.AppendLine("~ " + DateTime.Now);
                }

                for (int b = 0; b != tabla.Columns.Count; b++)
                {
                    linea.Append(tabla.Rows[a].ItemArray[b] + "|");
                }
                sw.WriteLine(linea);
            }

            sw.Close();

            return;

            #region " PROCESO DE ENCRIPTADO DE LOS DATOS DESCARGADOS. "

            // La contraseña debe ser la misma que la de la cadena de conexión.
            string password = "";
            string[] parametros = Globales.ConnectionStringComun.Split(';');
            for (int a = 0; a != parametros.Length; a++)
            {
                string[] valorParametro = parametros[a].Split('=');
                if (valorParametro[0] == "Password")
                {
                    password = valorParametro[1];
                }
            }

            // Comprimimos y encriptamos con contraseña el fichero descargado.
            string targetName = tabla.TableName + ".7z";
            string sourceName = tabla.TableName + ".zcs";
            System.Diagnostics.ProcessStartInfo procesoDeEncriptado = new System.Diagnostics.ProcessStartInfo();
            procesoDeEncriptado.FileName = @"c:\zs\7-Zip\7z.exe";
            procesoDeEncriptado.WorkingDirectory = directorio;
            procesoDeEncriptado.Arguments = "a -p" + password + " " + "\"" + targetName + "\"" + " " + "\"" + sourceName + "\" -mx=9";
            procesoDeEncriptado.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            // Lanzamos el proceso.
            System.Diagnostics.Process x = System.Diagnostics.Process.Start(procesoDeEncriptado);
            x.WaitForExit();

            // Borramos el fichero sin encriptar.
            File.Delete(directorio + sourceName);

            #endregion
        }

        public static void CargaDatos(System.Data.DataTable tabla)
        {

            string fileName = @"c:\zs\cp\cp.zcs";
            string linea = "";
            string[] lineaEnPartes;
            DataRow fila;

            if (File.Exists(fileName))
            {
                StreamReader sr = new StreamReader(fileName);


                while (!sr.EndOfStream)
                {
                    linea = sr.ReadLine();

                    if (linea.Contains('~'))
                    {
                    }
                    else
                    {
                        fila = tabla.NewRow();
                        lineaEnPartes = linea.Split('|');
                        for (int a = 0; a != tabla.Columns.Count; a++)
                        {
                            fila[a] = lineaEnPartes[a];
                        }
                        tabla.Rows.Add(fila);
                    }
                }
                sr.Close();
            }
        }
    }
}

