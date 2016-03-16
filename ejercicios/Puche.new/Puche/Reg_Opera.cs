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
    class Reg_Opera
    {        

        public static int Agregar(Registro pRegistro)
        {

            int retorno = 0;
            //coversion de los decimales
            string shonorarios = General.Convertir_a_real(pRegistro.honorarios.ToString("N2"));
            string stasa = General.Convertir_a_real(pRegistro.tasa.ToString("N2"));
            string sdcho_col = General.Convertir_a_real(pRegistro.dcho_col.ToString("0.00"));
            
            string sql = "insert into registros values('" + pRegistro.delegacion + "'," + pRegistro.n_reg + ",'" + pRegistro.fec_ent + "'," + pRegistro.id_cte + "," +
                         pRegistro.id_titular + ",'" + pRegistro.seccion_int + "','" + pRegistro.seccion + "','" + pRegistro.t_tramite + "','" + pRegistro.matricula + "','" + pRegistro.estado + "'," +
                         pRegistro.factura + ",'" + pRegistro.fec_fra + "','" + pRegistro.observacion + "','" + shonorarios + "','" + pRegistro.p_iva +
                         "','" + stasa + "','" + pRegistro.exp_tl + "','" + pRegistro.fec_pre_exp + "','" + pRegistro.et_tasa + "','" + pRegistro.t_tasa + "','" + pRegistro.cambio_serv +
                         "','" + pRegistro.bate_ant + "','" + pRegistro.nif + "','" + sdcho_col + "','" + pRegistro.t_cte_fra + "','" + pRegistro.et_tasa2 + "','" + pRegistro.t_tasa2 +
                         "','" + pRegistro.et_tasa3 + "','" + pRegistro.t_tasa3 + "','" + pRegistro.et_tasa4 + "','" + pRegistro.t_tasa4 + "','" + pRegistro.descripcion + "','" + pRegistro.ruta_pdf +
                         "','" + pRegistro.vehiculo + "')";


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

        public static List<Registro> Buscar(char pt_deleg, int pn_reg, int pfra,char pt_cte, string pn_cte, string pexp, string pmatri, string pvehi)
        {
            string sql;
            List<Registro> _lista = new List<Registro>();

            if (pt_deleg == ' ' & pn_reg == 0 & pfra == 0 & pt_cte == ' ' & pn_cte == " " & pexp == " " & pmatri == " " & pvehi == " ") //consulta todos los registros. (Mregistros)
                sql = "select * from registros order by delegacion, n_reg";
            else //opciones del buscador de registros
            {
                if (pt_deleg != ' ' & pn_reg != 0) //consulta el n_reg de su deleg.
                    //sql = "select delegacion, n_reg, fec_ent, id_cte, factura, fec_fra, exp_tl, fec_pre_exp from registros where delegacion='" + pt_deleg + "' and n_reg=" + pn_reg;
                    sql = "select * from registros where delegacion='" + pt_deleg + "' and n_reg=" + pn_reg;
                else
                {
                    if (pfra != 0)// consulta n_fra
                        sql = "select * from registros where factura=" + pfra;
                    else
                    {
                        if (pt_cte != ' ' & pn_cte != " ")// t_cte y nombre
                        {
                            if (pt_cte == 'C')
                                sql = "select * from registros where registros.id_cte = (select id_cliente from clientes where tipo_cte ='C' and nombre ~* '" + pn_cte + "')";
                            else
                                sql = "select * from registros where registros.id_titular = (select id_cliente from clientes where tipo_cte ='T' and nombre ~* '" + pn_cte + "')";
                            //sql = "select delegacion, n_reg, fec_ent, id_cte,nombre,factura, fec_fra, exp_tl, fec_pre_exp from registros, clientes " +                                 
                            //"where registros.id_titular = clientes.id_cliente and clientes.tipo_cte ='T' and nombre like '%" + pn_cte + "%'";
                        }
                        else 
                        {
                            if (pmatri != " " | pvehi != " ")// matricula or vehiculo                            
                                sql = "select * from registros where matricula ~* '" + pmatri + "' and vehiculo ~* '" + pvehi +"'";
                            else //x n_exp.
                                sql = "select * from registros where exp_tl ~* '" + pexp + "'";
                        }
                    }
                }
            }

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;
                NpgsqlDataReader datos = comando.ExecuteReader();

                
                while (datos.Read())
                {
                    Registro pRegistro = new Registro();
                    pRegistro.delegacion = datos.GetChar(0);
                    pRegistro.n_reg = datos.GetInt32(1);
                    pRegistro.fec_ent = datos.GetDateTime(2);
                    pRegistro.id_cte = datos.GetInt32(3);
                    pRegistro.id_titular = datos.GetInt32(4);
                    pRegistro.seccion_int = datos.GetString(5);
                    pRegistro.seccion = datos.GetString(6);
                    pRegistro.t_tramite = datos.GetString(7);
                    pRegistro.matricula = datos.GetString(8);
                    pRegistro.estado = datos.GetString(9);
                    pRegistro.factura = datos.GetInt32(10);
                    pRegistro.fec_fra = datos.GetDateTime(11);
                    pRegistro.observacion = datos.GetString(12);                    
                    pRegistro.honorarios = datos.GetDecimal(13);
                    pRegistro.p_iva = datos.GetInt16(14);
                    pRegistro.tasa = datos.GetDecimal(15);
                    pRegistro.exp_tl = datos.GetString(16);
                    pRegistro.fec_pre_exp = datos.GetDateTime(17);
                    pRegistro.et_tasa = datos.GetInt64(18); 
                    pRegistro.t_tasa = datos.GetString(19);
                    pRegistro.cambio_serv = datos.GetString(20);
                    pRegistro.bate_ant = datos.GetString(21);
                    pRegistro.nif = datos.GetString(22);
                    pRegistro.dcho_col = datos.GetDecimal(23);
                    pRegistro.t_cte_fra = datos.GetChar(24);
                    pRegistro.et_tasa2 = datos.GetInt64(25);
                    pRegistro.t_tasa2 = datos.GetString(26);
                    pRegistro.et_tasa3 = datos.GetInt64(27);
                    pRegistro.t_tasa3 = datos.GetString(28);
                    pRegistro.et_tasa4 = datos.GetInt64(29);
                    pRegistro.t_tasa4 = datos.GetString(30);
                    pRegistro.descripcion = datos.GetString(31);
                    pRegistro.ruta_pdf = datos.GetString(32);
                    pRegistro.vehiculo = datos.GetString(33);

                    _lista.Add(pRegistro);
                    
                }

                comando.Connection.Close();
                return _lista;
            }
        }
		
        
        public static List<Registro> Buscar_lreg(char pt_deleg, int pd_n_rg, int ph_n_rg, char pt_cte, int pd_cte, int ph_cte) //int pfra, string pn_cte, string pexp)
        {
            string sql="";
            List<Registro> _lista = new List<Registro>();            

            if (pt_deleg == ' ' & pd_n_rg == 0 & ph_n_rg == 999999 & pt_cte == ' ' & pd_cte == 0 & ph_cte == 999999) //consulta todos los registros. (Mregistros)
                sql = "select * from registros order by delegacion, n_reg";
            else //opciones del buscador de registros
            {
                if (pt_deleg != ' ') //consulta el n_reg de su deleg.
                    //sql = "select delegacion, n_reg, fec_ent, id_cte, factura, fec_fra, exp_tl, fec_pre_exp from registros where delegacion='" + pt_deleg + "' and n_reg=" + pn_reg;
                    sql = "select * from registros where delegacion='" + pt_deleg + "' and n_reg between " + pd_n_rg + " and " + ph_n_rg + " order by delegacion, n_reg";
                else
                {
                    
                        if (pt_cte != ' ')// t_cte y nombre
                        {
                            if (pt_cte == 'C')
                                sql = "select * from registros where registros.id_cte between " + pd_cte + " and " + ph_cte; //(select id_cliente from clientes where tipo_cte ='C' and nombre like '%" + pn_cte + "%')";
                            else
                                sql = "select * from registros where registros.id_titular between "+ pd_cte + " and " + ph_cte; //(select id_cliente from clientes where tipo_cte ='T' and nombre like '%" + pn_cte + "%')";
                                //sql = "select delegacion, n_reg, fec_ent, id_cte,nombre,factura, fec_fra, exp_tl, fec_pre_exp from registros, clientes " +                                 
                                //"where registros.id_titular = clientes.id_cliente and clientes.tipo_cte ='T' and nombre like '%" + pn_cte + "%'";
                        }
                        //else //x n_exp.
                          //  sql = "select * from registros where exp_tl like '%" + pexp + "%'";
                    /*
                    if (pfra != 0)// consulta n_fra
                        sql = "select * from registros where factura=" + pfra;
                    else
                    {    
                	}
                	*/
                }
            }

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;
                NpgsqlDataReader datos = comando.ExecuteReader();

                
                while (datos.Read())
                {
                    Registro pRegistro = new Registro();
                    pRegistro.delegacion = datos.GetChar(0);
                    pRegistro.n_reg = datos.GetInt32(1);
                    pRegistro.fec_ent = datos.GetDateTime(2);
                    pRegistro.id_cte = datos.GetInt32(3);
                    pRegistro.id_titular = datos.GetInt32(4);
                    pRegistro.seccion_int = datos.GetString(5);
                    pRegistro.seccion = datos.GetString(6);
                    pRegistro.t_tramite = datos.GetString(7);
                    pRegistro.matricula = datos.GetString(8);
                    pRegistro.estado = datos.GetString(9);
                    pRegistro.factura = datos.GetInt32(10);
                    pRegistro.fec_fra = datos.GetDateTime(11);
                    pRegistro.observacion = datos.GetString(12);                    
                    pRegistro.honorarios = datos.GetDecimal(13);
                    pRegistro.p_iva = datos.GetInt16(14);
                    pRegistro.tasa = datos.GetDecimal(15);
                    pRegistro.exp_tl = datos.GetString(16);
                    pRegistro.fec_pre_exp = datos.GetDateTime(17);
                    pRegistro.et_tasa = datos.GetInt64(18); 
                    pRegistro.t_tasa = datos.GetString(19);
                    pRegistro.cambio_serv = datos.GetString(20);
                    pRegistro.bate_ant = datos.GetString(21);
                    pRegistro.nif = datos.GetString(22);
                    pRegistro.dcho_col = datos.GetDecimal(23);
                    pRegistro.t_cte_fra = datos.GetChar(24);
                    pRegistro.et_tasa2 = datos.GetInt64(25);
                    pRegistro.t_tasa2 = datos.GetString(26);
                    pRegistro.et_tasa3 = datos.GetInt64(27);
                    pRegistro.t_tasa3 = datos.GetString(28);
                    pRegistro.et_tasa4 = datos.GetInt64(29);
                    pRegistro.t_tasa4 = datos.GetString(30);
                    pRegistro.descripcion = datos.GetString(31);
                    pRegistro.ruta_pdf = datos.GetString(32);
                    pRegistro.vehiculo = datos.GetString(33);

                    _lista.Add(pRegistro);
                    
                }

                comando.Connection.Close();
                return _lista;
            }
        }
        
        //Se utiliza ene el form de busq.
        public static Registro ObtenerReg(char pdeleg, int pn_reg)
        {
            Registro pRegistro = new Registro();
            string sql = "select * from registros where delegacion='" + pdeleg + "' and n_reg=" + pn_reg;
            using (BDConexion.ObtenerConexion())
            {

                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;
                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                    pRegistro.delegacion = datos.GetChar(0);
                    pRegistro.n_reg = datos.GetInt32(1);
                    pRegistro.fec_ent = datos.GetDateTime(2);
                    pRegistro.id_cte = datos.GetInt32(3);
                    pRegistro.id_titular = datos.GetInt32(4);
                    pRegistro.seccion_int = datos.GetString(5);
                    pRegistro.seccion = datos.GetString(6);
                    pRegistro.t_tramite = datos.GetString(7);
                    pRegistro.matricula = datos.GetString(8);
                    pRegistro.estado = datos.GetString(9);
                    pRegistro.factura = datos.GetInt32(10);
                    pRegistro.fec_fra = datos.GetDateTime(11);
                    pRegistro.observacion = datos.GetString(12);
                    pRegistro.honorarios = datos.GetDecimal(13);
                    pRegistro.p_iva = datos.GetInt16(14);
                    pRegistro.tasa = datos.GetDecimal(15);
                    pRegistro.exp_tl = datos.GetString(16);
                    pRegistro.fec_pre_exp = datos.GetDateTime(17);
                    pRegistro.et_tasa = datos.GetInt64(18); //(float)datos.GetDecimal(18);
                    pRegistro.t_tasa = datos.GetString(19);
                    pRegistro.cambio_serv = datos.GetString(20);
                    pRegistro.bate_ant = datos.GetString(21);
                    pRegistro.nif = datos.GetString(22);
                    pRegistro.dcho_col = datos.GetDecimal(23);
                    pRegistro.t_cte_fra = datos.GetChar(24);
                    pRegistro.et_tasa2 = datos.GetInt64(25);
                    pRegistro.t_tasa2 = datos.GetString(26);
                    pRegistro.et_tasa3 = datos.GetInt64(27);
                    pRegistro.t_tasa3 = datos.GetString(28);
                    pRegistro.et_tasa4 = datos.GetInt64(29);
                    pRegistro.t_tasa4 = datos.GetString(30);
                    pRegistro.descripcion = datos.GetString(31);
                    pRegistro.ruta_pdf = datos.GetString(32);
                    pRegistro.vehiculo = datos.GetString(33);
                }


                comando.Connection.Close();
                return pRegistro;
            }

        }

        public static int Actualizar(Registro pRegistro)
        {
            int retorno = 0;
            //coversion de los decimales
            string shonorarios = General.Convertir_a_real(pRegistro.honorarios.ToString("0.00"));
            string stasa = General.Convertir_a_real(pRegistro.tasa.ToString("0.00"));
            string sdcho_col = General.Convertir_a_real(pRegistro.dcho_col.ToString("0.00"));

            //+  + pRegistro.tasa pRegistro.tasa_tl
            string sql = "update registros set fec_ent='"  + pRegistro.fec_ent + "', id_cte=" + pRegistro.id_cte + ", id_titular=" + pRegistro.id_titular + ", seccion_int='" + pRegistro.seccion_int + 
                         "', seccion='" + pRegistro.seccion + "', t_tramite='" + pRegistro.t_tramite + "', matricula='" + pRegistro.matricula + "', estado='" + pRegistro.estado + "', factura='" + pRegistro.factura +
                         "', fec_fra='" + pRegistro.fec_fra + "', observacion='" + pRegistro.observacion + "', honorarios='" + shonorarios + "', p_iva='" + pRegistro.p_iva + "', tasa='" + stasa +
                         "', exp_tl='" + pRegistro.exp_tl + "', fec_pre_exp='" + pRegistro.fec_pre_exp + "', et_tasa='" + pRegistro.et_tasa + "', t_tasa='" + pRegistro.t_tasa + "', cambio_serv='" + pRegistro.cambio_serv +
                         "', bate_ant='" + pRegistro.bate_ant + "', nif='" + pRegistro.nif + "', dcho_col='" + sdcho_col + "', t_cte_fra='" + pRegistro.t_cte_fra + "', et_tasa2='" + pRegistro.et_tasa2 + "', t_tasa2='" + pRegistro.t_tasa2 +
                         "', et_tasa3='" + pRegistro.et_tasa3 + "', t_tasa3='" + pRegistro.t_tasa3 + "', et_tasa4='" + pRegistro.et_tasa4 + "', t_tasa4='" + pRegistro.t_tasa4 + "', descripcion='" + pRegistro.descripcion +
                         "', ruta_pdf='" + pRegistro.ruta_pdf + "', vehiculo='" + pRegistro.vehiculo +
                         "' where delegacion='" + pRegistro.delegacion + "' and n_reg=" + pRegistro.n_reg;

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                retorno = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return retorno;
            }

        }

        public static int Eliminar(char pdeleg, int pn_reg)
        {
            int retorno = 0;
            string sql = "delete from registros where delegacion='" + pdeleg + "' and n_reg=" + pn_reg;
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                retorno = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return retorno;
            }

        }

        public static int Calcular_n_reg(char pdeleg)
        {
            int max_n_reg = 0;
            string sql = "select max(n_reg) from registros where delegacion='" + pdeleg + "'";
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                    if (!datos.IsDBNull(0))//si no hay datos, coge valor 0.
                        max_n_reg = datos.GetInt32(0); //solo un reg.
                }

                comando.Connection.Close();
                return max_n_reg + 1;
            }

        }

        public static string Calcular_nom_cte(string pid_cte,char pt_cte)
        {
            if (string.IsNullOrWhiteSpace(pid_cte.Trim())) 
            {
                return pid_cte=" ";
            }
            else
            {
                int existe = 0;
                string sql;
                int iid_cte = Convert.ToInt32(pid_cte);

                //si iid_cte = 0 -> cte comodin: pt_cte(C,T)
                if (iid_cte == 0)
                    sql = "select nombre from clientes where id_cliente=" + iid_cte;
                else
                    sql = "select nombre from clientes where id_cliente=" + iid_cte + " and tipo_cte='" + pt_cte + "'";
                
                using (BDConexion.ObtenerConexion())
                {
                    NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                    comando.CommandTimeout = 5 * 60;

                    NpgsqlDataReader datos = comando.ExecuteReader();

                    while (datos.Read())
                    {
                        pid_cte = datos.GetString(0); //solo un reg.
                        existe++;
                    }

                    comando.Connection.Close();

                    if (existe > 0)
                        return pid_cte;
                    else //no existe cte.
                    {
                        MessageBox.Show("Debe dar de alta ese código de cliente.", "El Código de Cliente no existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return " ";
                    }
                }
            }
        }

        public static int Existe_factura(int pn_fra) //,int pn_reg, char p_deleg
        {
            

            int existe = 0;
            //busco la fra. en todas las filas menos en la actual.(antes)
            //string sql = "select * from registros where factura <> (select factura from registros where delegacion ='" + p_deleg + "' and n_reg ='" + pn_reg + "') and factura=" + pn_fra;
            
            //la actual ya no entra aqui, luego solo busco la nueva si exite
            string sql = "select * from registros where factura=" + pn_fra;
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

        public static string Calcular_tot_fra(string pbase, string pp_iva, string ptasa)
        {
            if (string.IsNullOrWhiteSpace(pbase))
                pbase = "0";
            if (string.IsNullOrWhiteSpace(pp_iva))
                pp_iva = "0";
            if (string.IsNullOrWhiteSpace(ptasa))
                ptasa = "0";
            decimal tot_fra = (Convert.ToDecimal(pbase) + (Convert.ToDecimal(pbase) * Convert.ToInt16(pp_iva)) / 100) + Convert.ToDecimal(ptasa);
            
            return tot_fra.ToString("N2")+" €";
        }

        public static string Calcular_tasa_fra(string ptasa1, string ptasa2, string ptasa3, string ptasa4)
        {
            if (string.IsNullOrWhiteSpace(ptasa1))
                ptasa1="0";
            if (string.IsNullOrWhiteSpace(ptasa2))
                ptasa2 = "0";
            if (string.IsNullOrWhiteSpace(ptasa3))
                ptasa3 = "0";
            if (string.IsNullOrWhiteSpace(ptasa4))
                ptasa4 = "0";
            decimal tasa_fra = Convert.ToDecimal(ptasa1) + Convert.ToDecimal(ptasa2) + Convert.ToDecimal(ptasa3) + Convert.ToDecimal(ptasa4);

            return tasa_fra.ToString("N2");
        }
    }
}
