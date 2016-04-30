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
    class Linfac_Opera
    {        

        public static DataTable Asigna_detalle(int pnum_fra)
        {
            DataTable tabla = new DataTable();

            string sql = "select numfac,linea,descripcion,importe, p_iva, cta_cble from linfac where numfac='" + pnum_fra + "' order by linea";

            // AquÃ­ lanzas el proceso de guardado a la bd etc...
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                // Incrementamos hasta un minuto para evitar que de error cualquier ejecuciÃ³n comÃºn.
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);

                tabla.Clear();
                NpgsqlDataReader datos = comando.ExecuteReader();

                tabla.Load(datos, LoadOption.OverwriteChanges);
                      
            }

            return tabla;
        }
        


        
        public static int Calcular_max_linfac(int pnum_fra)
        {
            int max_linfac = 0; 
            string sql = "select max(linea) as total from linfac where numfac='" + pnum_fra + "'";
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

        public static decimal[] Calcular_importes_linfac(int pnum_fra)
        {            
            decimal[] importes = new decimal[2];
            string sql = "select p_iva,sum(importe) from linfac where numfac='" + pnum_fra + "' group by p_iva";
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                //si no hay datos, coge valor 0.
                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        if (!datos.IsDBNull(0) && !datos.IsDBNull(1))
                        {
                            //importe[0]: importes sin iva // importe[1]:m importes con iva
                            if (datos.GetValue(0).ToString() == "0")
                                importes[0] = Convert.ToDecimal(datos.GetValue(1).ToString());
                            else
                                importes[1] = Convert.ToDecimal(datos.GetValue(1).ToString());
                        }
                    }
                    
                }

                comando.Connection.Close();

                return importes;
            }

        }

        public static List<Cuentas> Saca_ctas_x_impor(int pnum_fra)
        {            
            List<Cuentas> _cuentas = new List<Cuentas>();

            string sql = "select cta_cble,sum(importe) from linfac where numfac='" + pnum_fra + "' group by cta_cble";
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                //si no hay datos, coge valor 0.
                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        if (!datos.IsDBNull(0) && !datos.IsDBNull(1))
                        {
                            Cuentas pCuentas = new Cuentas();
                            pCuentas.cta_cble = datos.GetValue(0).ToString();
                            pCuentas.importe_acu = Convert.ToDecimal(datos.GetValue(1).ToString());

                            _cuentas.Add(pCuentas);
                            
                        }
                    }

                }

                comando.Connection.Close();

                return _cuentas;
            }

        }
        
       
        public static int Agregar_modif(Linfac pLinfac, short pguardando)
        {            
            int retorno = 0;
            string scantidad = "0";
            string simporte = General.Convertir_a_real(pLinfac.importe.ToString("0.00")); //N2
            string sql = "";

            if (pguardando == 1) //new linea
                sql = "insert into linfac values(" + pLinfac.numfac + "," + pLinfac.linea + ",'" + pLinfac.descripcion.Trim() +
                      "','" + scantidad + "','" + simporte + "','" + pLinfac.p_iva + "','" + pLinfac.cta_cble.Trim() + "')";
            else//modif. linea                
                sql = "update linfac set descripcion='" + pLinfac.descripcion.Trim() + "', p_iva='" + pLinfac.p_iva + "', importe='" + simporte + "', cta_cble='" + pLinfac.cta_cble +
                      "' where numfac='" + pLinfac.numfac + "' and linea='" + pLinfac.linea + "'";
                
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

        public static int Update_linfac(int pfactu_old, int pfactu_new)
        {
            int retorno = 0;
            string sql = "update linfac set numfac='" + pfactu_new + "' where numfac='" + pfactu_old + "'";

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


        public static int Eliminar(int pnumfac, short plinea)
        {
            int retorno = 0;
            if (pnumfac !=0 && plinea !=0)
            {
                string sql = "delete from linfac where numfac='" + pnumfac + "' and linea='" + plinea + "'";
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


        public static int Existe_Linfac(int pn_fra) //,int pn_reg, char p_deleg
        {
            int existe = 0;
            
            string sql = "select * from linfac where numfac=" + pn_fra;
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
