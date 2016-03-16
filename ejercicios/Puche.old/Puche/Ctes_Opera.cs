using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace Puche
{
    class Ctes_Opera
    {
        public static int Agregar(Cliente pCliente)
        {

            int retorno = 0;
            string sql = "insert into clientes values((select max(id_cliente)from clientes)+1,'" + pCliente.Nombre + "','" + pCliente.Tipo_docu + "','" + pCliente.Documento + "','" +
                         pCliente.Letra + "','" + pCliente.Direccion + "','" + pCliente.Pers_cont + "','" + pCliente.Email + "','" + pCliente.Telf1 + "','" + pCliente.Telf2 + "','" +
                         pCliente.Cpostal + "','" + pCliente.Ciudad + "','" + pCliente.Provin + "','"+ pCliente.Tipo_cte +"')";


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
        

        public static List<Cliente> Buscar(string pnombre, string pdocu, char pt_cte)
        {
            string sql;
            List<Cliente> _lista = new List<Cliente>();
            
            //SELECT * FROM clientes WHERE nombre ~* 'pUc';
            if (pnombre=="" & pdocu=="" & pt_cte==' ') //consulta todos los ctes.
                sql = "select * from clientes order by id_cliente";
            else
                sql = "select * from clientes where nombre ~* '" + pnombre + "' and documento ~* '" + pdocu + "' and tipo_cte='" + pt_cte + "'";
            
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;
                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                    Cliente pCliente = new Cliente();
                    pCliente.Id_Cliente = datos.GetInt32(0);
                    pCliente.Nombre = datos.GetString(1);
                    pCliente.Tipo_docu = datos.GetString(2);
                    pCliente.Documento = datos.GetString(3);
                    pCliente.Letra = datos.GetChar(4);
                    pCliente.Direccion = datos.GetString(5);
                    pCliente.Pers_cont = datos.GetString(6);
                    pCliente.Email = datos.GetString(7);
                    pCliente.Telf1 = datos.GetString(8);
                    pCliente.Telf2 = datos.GetString(9);
                    pCliente.Cpostal = datos.GetString(10);
                    pCliente.Ciudad = datos.GetString(11);
                    pCliente.Provin = datos.GetString(12);
                    pCliente.Tipo_cte = datos.GetChar(13);


                    _lista.Add(pCliente);

                }
                
                comando.Connection.Close();
                return _lista;
            }
        }

        //Se utiliza ene el form de busq.
        public static Cliente ObtenerCliente(int pcod_cte)
        {
            Cliente pCliente = new Cliente();
            string sql = "select * from clientes where id_cliente=" + pcod_cte;
            using (BDConexion.ObtenerConexion())
            {

                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;
                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {                    
                    pCliente.Id_Cliente = datos.GetInt32(0);
                    pCliente.Nombre = datos.GetString(1);
                    pCliente.Tipo_docu = datos.GetString(2);
                    pCliente.Documento = datos.GetString(3);
                    pCliente.Letra = datos.GetChar(4);
                    pCliente.Direccion = datos.GetString(5);
                    pCliente.Pers_cont = datos.GetString(6);
                    pCliente.Email = datos.GetString(7);
                    pCliente.Telf1 = datos.GetString(8);
                    pCliente.Telf2 = datos.GetString(9);
                    pCliente.Cpostal = datos.GetString(10);
                    pCliente.Ciudad = datos.GetString(11);
                    pCliente.Provin = datos.GetString(12);
                    pCliente.Tipo_cte = datos.GetChar(13);
                }


                comando.Connection.Close();
                return pCliente;
            }

        }

        public static int Actualizar(Cliente pCliente)
        {
            int retorno = 0;            
            string sql = "update clientes set nombre='" + pCliente.Nombre + "', tipo_docu='" + pCliente.Tipo_docu + "', documento='" + pCliente.Documento + "', letra='" +
                         pCliente.Letra + "', direccion='" + pCliente.Direccion + "', pers_cont='" + pCliente.Pers_cont + "', email='" + pCliente.Email + "', telf1='" + pCliente.Telf1 + "', telf2='"+
                         pCliente.Telf2 + "', cpostal='" + pCliente.Cpostal + "', ciudad='" + pCliente.Ciudad + "', provin='" + pCliente.Provin + "', tipo_cte='" + pCliente.Tipo_cte + 
                         "' where id_cliente=" + pCliente.Id_Cliente;

            using (BDConexion.ObtenerConexion())
            {                                
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                retorno = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return retorno;
            }

        }

        public static int Eliminar(int pId)
        {
            int retorno = 0;
            string sql = "delete from clientes where id_cliente=" + pId;
            using (BDConexion.ObtenerConexion())
            {                
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                retorno = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return retorno;
            }

        }

        public static int Calcular_id_cte()
        {
            int max_id = 0;
            string sql = "select max(id_cliente) from clientes";
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();
                
                while (datos.Read())
                {
                    max_id = datos.GetInt32(0); //solo un reg.
                }

                comando.Connection.Close();
                return max_id + 1;
            }

        }
    }
}
