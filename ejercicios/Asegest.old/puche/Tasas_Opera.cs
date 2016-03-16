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
    class Tasas_Opera
    {
        public static int Agregar(Tasa pTasa)
        {

            int retorno = 0;
            string simporte = General.Convertir_a_real(pTasa.importe.ToString("N2"));

            string sql = "insert into tasas values(" + pTasa.ejercicio + ",'" + pTasa.codigo.Trim() + "','" + pTasa.descripcion.Trim() + "','" + simporte + "')";


            // Aquí lanzas el proceso de guardado a la bd etc...
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                // Incrementamos hasta un minuto para evitar que de error cualquier ejecución común.
                comando.CommandTimeout = 5 * 60;

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }


        public static List<Tasa> Buscar(string pejercicio, string pcodigo, string pdescri, string pimporte)
        {
            string sql = "";
            List<Tasa> _l_tasas = new List<Tasa>();

            //SELECT * FROM clientes WHERE nombre ~* 'pUc';            
            if (string.IsNullOrWhiteSpace(pejercicio) & string.IsNullOrWhiteSpace(pcodigo) & string.IsNullOrWhiteSpace(pdescri) & string.IsNullOrWhiteSpace(pimporte))
                sql = "select * from tasas order by ejercicio desc,codigo";
            else
            {
                if (string.IsNullOrWhiteSpace(pejercicio) & string.IsNullOrWhiteSpace(pimporte))
                    sql = "select * from tasas where codigo ~* '" + pcodigo + "' and descripcion ~* '" + pdescri + "' order by ejercicio desc,codigo";
                else 
                    if (pejercicio != "")
                        sql = "select * from tasas where ejercicio ='" + pejercicio + "' and codigo ~* '" + pcodigo + "' and descripcion ~* '" + pdescri + "' order by ejercicio desc,codigo";
                    else
                        sql = "select * from tasas where importe ='" + pimporte + "' and codigo ~* '" + pcodigo + "' and descripcion ~* '" + pdescri + "' order by ejercicio desc,codigo";

            }

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                    Tasa pTasa = new Tasa();
                    pTasa.ejercicio = datos.GetInt16(0);
                    pTasa.codigo = datos.GetString(1);
                    pTasa.descripcion = datos.GetString(2);
                    pTasa.importe = datos.GetDecimal(3);

                    _l_tasas.Add(pTasa);

                }

                comando.Connection.Close();
                return _l_tasas;
            }
        }


        public static List<Tasa> Buscar_ltasas(string pd_ej, string ph_ej, string pd_cod, string ph_cod)
        {
            string sql = "";
            List<Tasa> _l_tasas = new List<Tasa>();

            //SELECT * FROM clientes WHERE nombre ~* 'pUc';            
            if (pd_ej == "0" & ph_ej == "9999" & pd_cod =="" & ph_cod =="ZZZZZ")
                sql = "select * from tasas order by ejercicio desc,codigo";
            else
                sql = "select * from tasas where ejercicio between '" + pd_ej + "' and '" + ph_ej + "' and codigo between '" + pd_cod + "' and '" + ph_cod +
                      "' order by ejercicio desc,codigo";
            

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                    Tasa pTasa = new Tasa();
                    pTasa.ejercicio = datos.GetInt16(0);
                    pTasa.codigo = datos.GetString(1);
                    pTasa.descripcion = datos.GetString(2);
                    pTasa.importe = datos.GetDecimal(3);

                    _l_tasas.Add(pTasa);

                }

                comando.Connection.Close();
                return _l_tasas;
            }
        }

        public static int Actualizar(Tasa pTasa)
        {
            int retorno = 0;
            string simporte = General.Convertir_a_real(pTasa.importe.ToString("N2"));

            string sql = "update tasas set descripcion='" + pTasa.descripcion.Trim() + "', importe='" + simporte + 
                         "' where ejercicio=" + pTasa.ejercicio + " and codigo='" + pTasa.codigo + "'";

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                retorno = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return retorno;
            }

        }

        public static int Eliminar(short pejercicio, string pcodigo)
        {
            int retorno = 0;
            if (Existe_tasa_rg(pejercicio, pcodigo) == 0) //no hay tasas en regs.
            {
                string sql = "delete from tasas where ejercicio=" + pejercicio + " and codigo='" + pcodigo + "'";
                using (BDConexion.ObtenerConexion())
                {
                    NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                    comando.CommandTimeout = 5 * 60;

                    retorno = comando.ExecuteNonQuery();
                    comando.Connection.Close();                    
                }
            }
            return retorno;
        }


        public static int Existe_tasa(short pejercicio, string pcodigo) 
        {

            int existe = 0;

            string sql = "select * from tasas where ejercicio=" + pejercicio + " and codigo='" + pcodigo + "'";
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                    // max_n_reg = datos.GetInt32(0); //solo un reg.
                    existe++;
                }

                comando.Connection.Close();
                return existe;
            }

        }

        public static decimal Saca_imp_tasa(short pejercicio, string pcodigo)
        {

            decimal timp = 0;

            string sql = "select importe from tasas where ejercicio=" + pejercicio + " and codigo='" + pcodigo + "'";
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                     timp = datos.GetDecimal(0); //solo un reg.                    
                }

                comando.Connection.Close();
                return timp;
            }

        }

        public static int Existe_tasa_rg(short pejercicio, string pcodigo) 
        {
            string sql;
            
            int existe = 0;            
            sql = "select * from registros where extract(year from fec_fra)='" + pejercicio +"' and (t_tasa='" + pcodigo +
                "' or t_tasa2='" + pcodigo + "' or t_tasa3='" + pcodigo + "' or t_tasa4='" + pcodigo + "')";

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                    // si existe > 0, si hay tasas en rgs. 
                    existe++;
                }

                comando.Connection.Close();
                return existe;
            }

        }

    }
}
