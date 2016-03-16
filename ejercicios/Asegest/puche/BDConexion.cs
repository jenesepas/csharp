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
    public class BDConexion
    {
        public static NpgsqlConnection ObtenerConexion()
        {
            
            //192.168.0.100-127.0.0.1-172.26.0.223
            string cadenaConexionTabla = "Server='" + General.server.Trim() + "';Port=5432;User id=postgres;Password=admin;Database=asesoria";
            NpgsqlConnection conectar = new NpgsqlConnection(cadenaConexionTabla);

            conectar.Open();
            return conectar;
           
        }
    }
}
