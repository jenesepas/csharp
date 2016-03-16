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
    class Usuarios_Opera
    {
        public static int Agregar(Usuario pUsuario)
        {

            int retorno = 0;

            string sql = "insert into usuarios values('" + pUsuario.codigo.Trim() + "','" + pUsuario.nombre.Trim() + "','" + pUsuario.clave.Trim() + "'," + pUsuario.acceso + ")";


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


        public static List<Usuario> Buscar() //string pcodigo, string pnombre, string pclave, string pacceso
        {
            string sql = "";
            List<Usuario> _l_usus = new List<Usuario>();

            //SELECT * FROM clientes WHERE nombre ~* 'pUc'; 
            sql = "select * from usuarios order by codigo";
            
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                    Usuario pUsuario = new Usuario();
                    pUsuario.codigo = datos.GetString(0);
                    pUsuario.nombre = datos.GetString(1);
                    pUsuario.clave = datos.GetString(2);
                    pUsuario.acceso = datos.GetInt16(3);

                    _l_usus.Add(pUsuario);

                }

                comando.Connection.Close();
                return _l_usus;
            }
        }



        public static int Actualizar(Usuario pUsuario)
        {
            int retorno = 0;

            string sql = "update usuarios set nombre='" + pUsuario.nombre.Trim() + "', clave='" + pUsuario.clave.Trim() + "', acceso=" + pUsuario.acceso +
                         " where codigo='" + pUsuario.codigo + "'";

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                retorno = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return retorno;
            }

        }

        public static int Eliminar(string pcodigo)
        {
            int retorno = 0;
            
            string sql = "delete from usuarios where codigo='" + pcodigo + "'";
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                retorno = comando.ExecuteNonQuery();
                comando.Connection.Close();                    
            }
            
            return retorno;
        }


        public static int Existe_usu(string pcodigo) 
        {

            int existe = 0;

            string sql = "select * from usuarios where codigo='" + pcodigo + "'";
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

        public static int Existe_usu_pass(string pcodigo, string pclave)
        {

            int existe = 0;

            string sql = "select * from usuarios where codigo='" + pcodigo + "' and clave='"+ pclave + "'";
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


        public static int Acceso_usu(string pcodigo, short pacceso)
        {

            int existe = 0;

            string sql = "select * from usuarios where codigo='" + pcodigo + "' and acceso =" + pacceso;
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

    }
}
