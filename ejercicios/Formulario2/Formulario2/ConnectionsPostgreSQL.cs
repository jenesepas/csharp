using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Windows.Forms;

namespace Formulario2
{
    public class ConnectionsPostgreSQL
    {
        public NpgsqlConnection abreConexion()
        {
            NpgsqlConnection conexion = new NpgsqlConnection()
            string cadenaConexion = "server=127.0.0.1;port=5432;database=asesoria;user=postgres;password=''"; 
                
            if (!string.IsNullOrEmpty(cadenaConexion))
            {
                try
                {
                    conexion = new NpgsqlConnection(cadenaConexion);
                    conexion.Open();
                }
                catch(NpgsqlException)
                {
                    MessageBox.Show("Error de conexión con la bd.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    conexion.Close();
                }
            }
            return conexion;
        }

        public 
    }
}