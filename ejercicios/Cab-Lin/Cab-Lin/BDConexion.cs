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
	/// <summary>
	/// Description of BDConexion.
	/// </summary>
	public class BDConexion
	{
		
			public static NpgsqlConnection ObtenerConexion()
        {
            //192.168.0.100
            string cadenaConexionTabla = "Server=127.0.0.1;Port=5432;User id=postgres;Password=admin;Database=prueba";
            NpgsqlConnection conectar = new NpgsqlConnection(cadenaConexionTabla);

            conectar.Open();
            return conectar;
       
		}
	}
}
