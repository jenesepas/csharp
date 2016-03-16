using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConexionCSharpconMySQL
{
    class ClietesDAL
    {
        public static int Agregar(Cliente pCliente)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into clientes (Nombre, Apellido, Fecha_Nacimiento, Direccion) values ('{0}','{1}','{2}', '{3}')",
                pCliente.Nombre, pCliente.Apellido, pCliente.Fecha_Nac, pCliente.Direccion), BdComun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }



        public static List<Cliente> Buscar(string pNombre, string pApellido)
        {
            List<Cliente> _lista = new List<Cliente>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT IdCliente, Nombre, Apellido, Fecha_Nacimiento, Direccion FROM clientes  where Nombre ='{0}' or Apellido='{1}'", pNombre, pApellido), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Cliente pCliente = new Cliente();
                pCliente.Id = _reader.GetInt32(0);
                pCliente.Nombre = _reader.GetString(1);
                pCliente.Apellido = _reader.GetString(2);
                pCliente.Fecha_Nac = _reader.GetString(3);
                pCliente.Direccion = _reader.GetString(4);


                _lista.Add(pCliente);
            }

            return _lista;
        }



        public static Cliente ObtenerCliente(int pId)
        {
            Cliente pCliente = new Cliente();
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT IdCliente, Nombre, Apellido, Fecha_Nacimiento, Direccion FROM clientes where IdCliente={0}", pId), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pCliente.Id = _reader.GetInt32(0);
                pCliente.Nombre = _reader.GetString(1);
                pCliente.Apellido = _reader.GetString(2);
                pCliente.Fecha_Nac = _reader.GetString(3);
                pCliente.Direccion = _reader.GetString(4);

            }

            conexion.Close();
            return pCliente;

        }





    }
}
