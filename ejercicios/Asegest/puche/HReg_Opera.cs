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
    class HReg_Opera
    {

        public static int Agregar(char pt_deleg, int pn_reg, char ptipo_modif)
        {

            int retorno = 0;
            int n_linea = 0;
            string sql = "";            

            //Altas
            //if (ptipo_modif == 'A')
                //sql = "insert into h_registros values('" + pt_deleg + "'," + pn_reg + ", 1, current_date,'" + ptipo_modif +"','"+ General.usuario.Trim() +"')";            
            //Modif. y Bajas
            //else
            //    sql = "insert into h_registros values('" + pt_deleg + "'," + pn_reg + ",(select max(linea) from h_registros where delegacion='" + pt_deleg + "' and n_reg=" + pn_reg + ")+1, current_date,'" + 
            //              ptipo_modif +"','"+ General.usuario.Trim() +"')";

            //Sacamos max de linea del historico (inc. +1)
            n_linea = Calcular_max_hreg(pt_deleg, pn_reg);
            sql = "insert into h_registros values('" + pt_deleg + "'," + pn_reg + ","+ n_linea +", current_date,'" + ptipo_modif + "','" + General.usuario.Trim() + "')";            

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


        public static List<HRegistro> Buscar(char pt_deleg, int pn_reg, string pusu) 
        {
            string sql = "";
            List<HRegistro> _l_hregs = new List<HRegistro>();

            //SELECT * FROM clientes WHERE nombre ~* 'pUc'; 
            sql = "select * from h_registros where 1=1";
            if (pt_deleg != ' ')
                sql=sql.TrimEnd() + " and delegacion='" + pt_deleg + "'";
                
            if (pn_reg != 0) 
                sql=sql.TrimEnd() + " and n_reg=" + pn_reg;
                
                
            if (!string.IsNullOrWhiteSpace(pusu))
                sql = sql.TrimEnd() + " and cod_usu ~* '" + pusu + "'";
            
            sql=sql +" order by delegacion, n_reg, linea";
            
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                    HRegistro pHRegistro = new HRegistro();
                    pHRegistro.delegacion = datos.GetChar(0);
                    pHRegistro.n_reg = datos.GetInt32(1);
                    pHRegistro.linea = datos.GetInt16(2);
                    pHRegistro.fec_modif = datos.GetDateTime(3);
                    pHRegistro.tipo_modif = datos.GetChar(4);
                    pHRegistro.cod_usu = datos.GetString(5);

                    _l_hregs.Add(pHRegistro);

                }

                comando.Connection.Close();
                return _l_hregs;
            }
        }

        public static int Calcular_max_hreg(char pt_deleg, int pn_reg)
        {
            int max_linfac = 0;
            string sql = "select max(linea) as total from h_registros where delegacion='" + pt_deleg + "' and n_reg=" + pn_reg;
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                //si no hay datos, coge valor 0.
                if (datos.HasRows)
                {
                    datos.Read();
                    if (!datos.IsDBNull(0)) //si dato no null                   
                        max_linfac = Convert.ToInt32(datos.GetValue(0).ToString());//solo un reg.  

                }

                comando.Connection.Close();

                return max_linfac + 1;
            }

        }


        //public static int Actualizar(Usuario pUsuario)
        //{
        //    int retorno = 0;

        //    string sql = "update usuarios set nombre='" + pUsuario.nombre.Trim() + "', clave='" + pUsuario.clave.Trim() + "', acceso=" + pUsuario.acceso +
        //                 " where codigo='" + pUsuario.codigo + "'";

        //    using (BDConexion.ObtenerConexion())
        //    {
        //        NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
        //        comando.CommandTimeout = 5 * 60;

        //        retorno = comando.ExecuteNonQuery();
        //        comando.Connection.Close();

        //        return retorno;
        //    }

        //}

        //public static int Eliminar(string pcodigo)
        //{
        //    int retorno = 0;
            
        //    string sql = "delete from usuarios where codigo='" + pcodigo + "'";
        //    using (BDConexion.ObtenerConexion())
        //    {
        //        NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
        //        comando.CommandTimeout = 5 * 60;

        //        retorno = comando.ExecuteNonQuery();
        //        comando.Connection.Close();                    
        //    }
            
        //    return retorno;
        //}


        
        

    }
}
