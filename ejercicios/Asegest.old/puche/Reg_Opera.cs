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
    class Reg_Opera
    {        

        public static int Agregar(Registro pRegistro)
        {

            int retorno = 0;
            //coversion de los decimales
            string shonorarios = General.Convertir_a_real(pRegistro.honorarios.ToString("N2"));
            string stasa = General.Convertir_a_real(pRegistro.tasa.ToString("N2"));
            string sdcho_col = General.Convertir_a_real(pRegistro.dcho_col.ToString("0.00"));
            string simpor_liq = General.Convertir_a_real(pRegistro.impor_liq.ToString("N2"));

            short panyo = Convert.ToInt16(pRegistro.fec_ent.Year);
            //busco el ultimo reg. insertado
            int max_reg_anyo = Reg_Opera.Calcular_max_reg_anyo(pRegistro.delegacion, panyo);

            string sql = "";
            if (max_reg_anyo == 0) //numero nuevo, primer numero del año, ej: (2016 - 2000) =16 * 10000 = 160000 + 1= 160001.
            {
                max_reg_anyo = ((panyo - 2000) * 10000) + 1;
                //MessageBox.Show("Nuevo año, nuevo contador: " + max_reg_anyo , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sql = "insert into registros values('" + pRegistro.delegacion + "',"+ max_reg_anyo +",'" + pRegistro.fec_ent + "'," + pRegistro.id_cte + "," +
                     pRegistro.id_titular + ",'" + pRegistro.seccion_int + "','" + pRegistro.seccion + "','" + pRegistro.t_tramite + "','" + pRegistro.matricula + "','" + pRegistro.estado + "'," +
                     pRegistro.factura + ",'" + pRegistro.fec_fra + "','" + pRegistro.observacion + "','" + shonorarios + "','" + pRegistro.p_iva +
                     "','" + stasa + "','" + pRegistro.exp_tl + "','" + pRegistro.fec_pre_exp + "','" + pRegistro.et_tasa + "','" + pRegistro.t_tasa + "','" + pRegistro.cambio_serv +
                     "','" + pRegistro.bate_ant + "','" + pRegistro.nif + "','" + sdcho_col + "','" + pRegistro.t_cte_fra + "','" + pRegistro.et_tasa2 + "','" + pRegistro.t_tasa2 +
                     "','" + pRegistro.et_tasa3 + "','" + pRegistro.t_tasa3 + "','" + pRegistro.et_tasa4 + "','" + pRegistro.t_tasa4 + "','" + pRegistro.descripcion + "','" + pRegistro.ruta_pdf +
                     "','" + pRegistro.vehiculo + "'," + pRegistro.id_colabora + ",'" + pRegistro.estado_fac + "','" + pRegistro.exp_ntl + "','" + pRegistro.usuario +
                     "','" + pRegistro.enviado + "','" + pRegistro.fec_anul + "','" + pRegistro.entidad + "','" + pRegistro.n_operacion + "','" + pRegistro.notario +
                     "','" + simpor_liq + "','" + pRegistro.firmado_por + "')";
            }
            else
            {

                     sql = "insert into registros values('" + pRegistro.delegacion + "',(select max(n_reg) from registros where delegacion='" + pRegistro.delegacion + "' and (Extract(Year from fec_ent))="+ panyo+")+1,'" + pRegistro.fec_ent + "'," + pRegistro.id_cte + "," +
                     pRegistro.id_titular + ",'" + pRegistro.seccion_int + "','" + pRegistro.seccion + "','" + pRegistro.t_tramite + "','" + pRegistro.matricula + "','" + pRegistro.estado + "'," +
                     pRegistro.factura + ",'" + pRegistro.fec_fra + "','" + pRegistro.observacion + "','" + shonorarios + "','" + pRegistro.p_iva +
                     "','" + stasa + "','" + pRegistro.exp_tl + "','" + pRegistro.fec_pre_exp + "','" + pRegistro.et_tasa + "','" + pRegistro.t_tasa + "','" + pRegistro.cambio_serv +
                     "','" + pRegistro.bate_ant + "','" + pRegistro.nif + "','" + sdcho_col + "','" + pRegistro.t_cte_fra + "','" + pRegistro.et_tasa2 + "','" + pRegistro.t_tasa2 +
                     "','" + pRegistro.et_tasa3 + "','" + pRegistro.t_tasa3 + "','" + pRegistro.et_tasa4 + "','" + pRegistro.t_tasa4 + "','" + pRegistro.descripcion + "','" + pRegistro.ruta_pdf +
                     "','" + pRegistro.vehiculo + "'," + pRegistro.id_colabora + ",'" + pRegistro.estado_fac + "','" + pRegistro.exp_ntl + "','" + pRegistro.usuario +
                     "','" + pRegistro.enviado + "','" + pRegistro.fec_anul + "','" + pRegistro.entidad + "','" + pRegistro.n_operacion + "','" + pRegistro.notario +
                     "','" + simpor_liq + "','" + pRegistro.firmado_por + "')";
            }

            // Aquí lanzas el proceso de guardado a la bd etc...
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                // Incrementamos hasta un minuto para evitar que de error cualquier ejecución común.
                comando.CommandTimeout = 5 * 60;

                retorno = comando.ExecuteNonQuery();
            }

            //si retorno>0 insercion correcta , sino retorno=0.
            if (retorno > 0)
            {
                //busco el ultimo reg. del año insertado
                retorno = Reg_Opera.Calcular_max_reg_anyo(pRegistro.delegacion, panyo); 
            }
            
            return retorno;
        }

        public static List<Registro> Buscar(char pt_deleg, int pn_reg, int pfra, char pt_cte, string pn_cte, string pexp, string pexp_ntl, 
                                            string pmatri, string pvehi)
        {
            string sql;
            List<Registro> _lista = new List<Registro>();

            if (pt_deleg != ' ' & pn_reg == 0 & pfra == 0 & pt_cte == ' ' & pn_cte == " " & pexp == " " & pexp_ntl == " " & pmatri == " " & pvehi == " ") //consulta todos los registros. (Mregistros)
                sql = "select * from registros where delegacion='"+ pt_deleg + "' order by delegacion, n_reg";
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
                                sql = "select * from registros where registros.id_cte in (select id_cliente from clientes where tipo_cte ='C' and nombre ~* '" + pn_cte + "')";
                            else
                            {
                                if (pt_cte == 'T')
                                    sql = "select * from registros where registros.id_titular in (select id_cliente from clientes where tipo_cte ='T' and nombre ~* '" + pn_cte + "')";                                    
                                else
                                    sql = "select * from registros where registros.id_colabora in (select id_cliente from clientes where tipo_cte ='B' and nombre ~* '" + pn_cte + "')";
                            }
                            //sql = "select delegacion, n_reg, fec_ent, id_cte,nombre,factura, fec_fra, exp_tl, fec_pre_exp from registros, clientes " +                                 
                            //"where registros.id_titular = clientes.id_cliente and clientes.tipo_cte ='T' and nombre like '%" + pn_cte + "%'";
                        }
                        else 
                        {
                            if (pmatri != " " | pvehi != " ")// matricula or vehiculo                            
                                sql = "select * from registros where matricula ~* '" + pmatri + "' and vehiculo ~* '" + pvehi + "'";
                            else //x n_exp.
                            {
                                if (pexp != " " )// exp. tl.                            
                                    sql = "select * from registros where exp_tl ~* '" + pexp + "'";
                                else //exp. no tl.
                                    sql = "select * from registros where exp_ntl ~* '" + pexp_ntl + "'";
                            }
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
                    pRegistro.id_colabora = datos.GetInt32(34);
                    pRegistro.estado_fac = datos.GetChar(35);
                    pRegistro.exp_ntl = datos.GetString(36);
                    pRegistro.usuario = datos.GetString(37);
                    pRegistro.enviado = datos.GetString(38);
                    pRegistro.fec_anul = datos.GetString(39);
                    pRegistro.entidad = datos.GetString(40);
                    pRegistro.n_operacion = datos.GetString(41);
                    pRegistro.notario = datos.GetString(42);
                    pRegistro.impor_liq = datos.GetDecimal(43);
                    pRegistro.firmado_por = datos.GetString(44);

                    _lista.Add(pRegistro);
                    
                }

                comando.Connection.Close();
                return _lista;
            }
        }


        public static List<Registro> Buscar_lreg(char pt_deleg, int pd_n_rg, int ph_n_rg, DateTime pd_f_ent, DateTime ph_f_ent, char pt_cte, int pd_cte, int ph_cte, string psecc_int, 
                                                 string pestado, char pest_reg, string pseccion, string ptramite) 
        {
            string sql="";
            List<Registro> _lista = new List<Registro>();
            string ordena = "";

            //pest_est:(T)odos/(S)in fact./(F)act./(L)no liq.
            switch (pest_reg)
            {
                case 'T':
                    ordena = " order by delegacion, n_reg";
                    break;
                case 'S':
                    ordena = " factura=0 order by delegacion, n_reg";
                    break;
                case 'F':
                    ordena = " factura <> 0 order by delegacion, n_reg";
                    break;
                case 'L':
                    ordena = " estado <> 'LIQUIDADO' order by delegacion, fec_ent, n_reg";
                    break;
            }

            sql = "select * from registros where fec_ent between '" + pd_f_ent.ToShortDateString() + "' and '" + ph_f_ent.ToShortDateString() + "'";
            
            if (pt_deleg != ' ') //consulta el n_reg de su deleg.
                sql = sql + " and delegacion='" + pt_deleg + "' and n_reg between " + pd_n_rg + " and " + ph_n_rg;
            
            if (pt_cte != ' ')// t_cte y nombre
            {
                
                if (pt_cte == 'C')
                    sql = sql = sql + " and registros.id_cte between " + pd_cte + " and " + ph_cte; //(select id_cliente from clientes where tipo_cte ='C' and nombre like '%" + pn_cte + "%')";
                else
                {
                    if (pt_cte == 'T')
                        sql = sql + " and registros.id_titular between " + pd_cte + " and " + ph_cte; 
                    else
                        sql = sql + " and registros.id_colabora between " + pd_cte + " and " + ph_cte;
                        
                }
            }

            if (psecc_int != "")
                sql = sql + " and seccion_int='" + psecc_int + "'";

            if (pestado != "")
                sql = sql + " and estado='" + pestado + "'";

            if (pseccion != "")
                sql = sql + " and seccion='" + pseccion + "'";

            if (ptramite != "")
                sql = sql + " and t_tramite='" + ptramite + "'";

            if (pest_reg == 'T')
                sql = sql + ordena;
            else sql = sql + " and " + ordena;

            /*
            if (pt_deleg == ' ' & pd_n_rg == 0 & ph_n_rg == 999999 & pt_cte == ' ' & pd_cte == 0 & ph_cte == 999999 & psecc_int == "" & pestado == "" & pseccion == "" & ptramite == "") //consulta todos los registros. (Mregistros)
            {
                
                if (pest_reg=='T')
                    sql = "select * from registros where fec_ent between '" + pd_f_ent.ToShortDateString() + "' and '" + ph_f_ent.ToShortDateString() + "'" + ordena;
                else sql = "select * from registros where fec_ent between '" + pd_f_ent.ToShortDateString() + "' and '" + ph_f_ent.ToShortDateString() + "' and " + ordena;
            }
            else //opciones del buscador de registros
            {
                if (pt_deleg != ' ') //consulta el n_reg de su deleg.
                {
                    //sql = "select delegacion, n_reg, fec_ent, id_cte, factura, fec_fra, exp_tl, fec_pre_exp from registros where delegacion='" + pt_deleg + "' and n_reg=" + pn_reg;
                    sql = "select * from registros where delegacion='" + pt_deleg + "' and n_reg between " + pd_n_rg + " and " + ph_n_rg + 
                           " and fec_ent between '" + pd_f_ent.ToShortDateString() + "' and '" + ph_f_ent.ToShortDateString() + "'";
                    if (psecc_int != "")
                        sql = sql + " and seccion_int='" + psecc_int + "'";

                    if (pestado != "")
                        sql = sql + " and estado='" + pestado + "'";

                    if (pseccion != "")
                        sql = sql + " and seccion='" + pseccion + "'";

                    if (ptramite != "")
                        sql = sql + " and t_tramite='" + ptramite + "'";

                    if (pest_reg == 'T')
                        sql = sql + ordena;                                    
                    else sql = sql + " and " + ordena;
                    
                }
                else
                {
                    if (pt_cte != ' ')// t_cte y nombre
                    {
                        if (pt_cte == 'C')
                            sql = "select * from registros where registros.id_cte between " + pd_cte + " and " + ph_cte +
                            " and fec_ent between '" + pd_f_ent.ToShortDateString() + "' and '" + ph_f_ent.ToShortDateString() + "'"; //(select id_cliente from clientes where tipo_cte ='C' and nombre like '%" + pn_cte + "%')";
                        else
                        {
                            if (pt_cte == 'T')
                                sql = "select * from registros where registros.id_titular between " + pd_cte + " and " + ph_cte +
                                " and fec_ent between '" + pd_f_ent.ToShortDateString() + "' and '" + ph_f_ent.ToShortDateString() + "'"; //(select id_cliente from clientes where tipo_cte ='T' and nombre like '%" + pn_cte + "%')";                                    
                            else
                                sql = "select * from registros where registros.id_colabora between " + pd_cte + " and " + ph_cte +
                                " and fec_ent between '" + pd_f_ent.ToShortDateString() + "' and '" + ph_f_ent.ToShortDateString() + "'"; //(select id_cliente from clientes where tipo_cte ='C' and nombre like '%" + pn_cte + "%')";
                        }
                        if (psecc_int != "")
                            sql = sql + " and seccion_int='" + psecc_int + "'";

                        if (pestado != "")
                            sql = sql + " and estado='" + pestado + "'";

                        if (pseccion != "")
                            sql = sql + " and seccion='" + pseccion + "'";

                        if (ptramite != "")
                            sql = sql + " and t_tramite='" + ptramite + "'";

                        if (pest_reg == 'T')
                            sql = sql + ordena;
                        else sql = sql + " and " + ordena;
                        //sql = "select delegacion, n_reg, fec_ent, id_cte,nombre,factura, fec_fra, exp_tl, fec_pre_exp from registros, clientes " +                                 
                        //"where registros.id_titular = clientes.id_cliente and clientes.tipo_cte ='T' and nombre like '%" + pn_cte + "%'";


                    }
                    else //las ultimas restricciones las montamos dinamicamente
                    {
                        sql = "select * from registros where fec_ent between '" + pd_f_ent.ToShortDateString() + "' and '" + ph_f_ent.ToShortDateString() + "'";

                        if (psecc_int != "")
                            sql = sql + " and seccion_int='" + psecc_int + "'";

                        if (pestado != "")
                            sql = sql + " and estado='" + pestado + "'";

                        if (pseccion != "")
                            sql = sql + " and seccion='" + pseccion + "'";

                        if (ptramite != "")
                            sql = sql + " and t_tramite='" + ptramite + "'";

                        if (pest_reg == 'T')
                            sql = sql + ordena;
                        else sql = sql + " and " + ordena;

                        
                    }
             */
                    //else //x n_exp.
                    //  sql = "select * from registros where exp_tl like '%" + pexp + "%'";
                    /*
                    if (pfra != 0)// consulta n_fra
                        sql = "select * from registros where factura=" + pfra;
                    else
                    {    
                	}
                	
                }
            }*/

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
                    pRegistro.id_colabora = datos.GetInt32(34);
                    pRegistro.estado_fac = datos.GetChar(35);
                    pRegistro.exp_ntl = datos.GetString(36);
                    pRegistro.usuario = datos.GetString(37);
                    pRegistro.enviado = datos.GetString(38);
                    pRegistro.fec_anul = datos.GetString(39);
                    pRegistro.entidad = datos.GetString(40);
                    pRegistro.n_operacion = datos.GetString(41);
                    pRegistro.notario = datos.GetString(42);
                    pRegistro.impor_liq = datos.GetDecimal(43);
                    pRegistro.firmado_por = datos.GetString(44);

                    _lista.Add(pRegistro);
                    
                }

                comando.Connection.Close();
                return _lista;
            }
        }



        public static List<Registro> Buscar_rfra(char pt_deleg, int pd_n_fra, int ph_n_fra, DateTime pd_f_fra, DateTime ph_f_fra, 
                                                char pt_cte, int pd_cte, int ph_cte, char pest_fra,short pt_orden) 
        {
            string sql = "";
            string ordenado = "";
            List<Registro> _lista = new List<Registro>();

            if (pt_orden == 0)
            {
                if (pest_fra == 'Z')//cualquier estado_fac
                    ordenado = " order by delegacion, factura";
                else
                {
                    if (pest_fra == ' ')//sin listar
                        ordenado = " and estado_fac=' ' order by delegacion, factura";
                    else
                    {
                        if (pest_fra == 'L')//listadas
                            ordenado = " and estado_fac='L' order by delegacion, factura";
                        else //enlazadas
                            ordenado = " and estado_fac='E' order by delegacion, factura";
                    }
                }
            }
            else //enlaza solo las listadas.
                ordenado = " and estado_fac='L' order by delegacion, factura";

            //string d_fec = "01/01/" + DateTime.Today.Year.ToString();
            //string h_fec = "31/12/" + DateTime.Today.Year.ToString();
            //& pd_f_fra.ToShortDateString() == d_fec & ph_f_fra.ToShortDateString() == h_fec

            if (pt_deleg == ' ' & pt_cte == ' ') //consulta todos los registros. (Mregistros)
            {
                if (pt_orden == 0)
                    sql = "select * from registros where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                    " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "'" +
                    ordenado.TrimEnd();
                
            }
            else //opciones del buscador de registros
            {

                //MessageBox.Show("Fechas: "+d_fec +"-"+h_fec,pd_f_fra.Date +""+ph_f_fra.Date);

                if (pt_deleg != ' ' & pt_cte == ' ') //consulta el n_reg de su deleg.
                {                    
                    sql = "select * from registros where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                    " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() +
                    "' and delegacion='" + pt_deleg + "'";
                    /*
                    if (psecc_int != "")
                        sql = sql + " and seccion_int='" + psecc_int + "'";

                    if (pestado != "")
                        sql = sql + " and estado='" + pestado + "'";
                    */
                    sql = sql + ordenado.TrimEnd();
                }
                else
                {
                    if (pt_cte != ' ' & pt_deleg == ' ')// t_cte y nombre
                    {
                        if (pt_cte == 'C')
                            sql = "select * from registros where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                            " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() +
                            "' and registros.id_cte between " + pd_cte + " and " + ph_cte; //(select id_cliente from clientes where tipo_cte ='C' and nombre like '%" + pn_cte + "%')";
                        else
                        {
                            if (pt_cte == 'T')
                                sql = "select * from registros where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                                " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() +
                                "' and registros.id_titular between " + pd_cte + " and " + ph_cte; //(select id_cliente from clientes where tipo_cte ='T' and nombre like '%" + pn_cte + "%')";                                    
                            else
                                sql = "select * from registros where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                                " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() +
                                "' and registros.id_colabora between " + pd_cte + " and " + ph_cte; //(select id_cliente from clientes where tipo_cte ='C' and nombre like '%" + pn_cte + "%')";
                        }
                        
                        sql = sql + " and t_cte_fra='" + pt_cte + "'" + ordenado.TrimEnd();
                    }

                    else
                    {
                        //si pt_cte != ' ' & pt_deleg != ' '
                        if (pt_cte == 'C')
                            sql = "select * from registros where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                            " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() +
                            "' and registros.id_cte between " + pd_cte + " and " + ph_cte; //(select id_cliente from clientes where tipo_cte ='C' and nombre like '%" + pn_cte + "%')";
                        else
                        {
                            if (pt_cte == 'T')
                                sql = "select * from registros where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                                " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() +
                                "' and registros.id_titular between " + pd_cte + " and " + ph_cte; //(select id_cliente from clientes where tipo_cte ='T' and nombre like '%" + pn_cte + "%')";                                    
                            else
                                sql = "select * from registros where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                                " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() +
                                "' and registros.id_colabora between " + pd_cte + " and " + ph_cte; //(select id_cliente from clientes where tipo_cte ='C' and nombre like '%" + pn_cte + "%')";
                        }

                        sql = sql + " and delegacion='" + pt_deleg + "' and t_cte_fra='" + pt_cte + "'" + ordenado.TrimEnd();

                        
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
                    pRegistro.id_colabora = datos.GetInt32(34);
                    pRegistro.estado_fac = datos.GetChar(35);
                    pRegistro.exp_ntl = datos.GetString(36);
                    pRegistro.usuario = datos.GetString(37);
                    pRegistro.enviado = datos.GetString(38);
                    pRegistro.fec_anul = datos.GetString(39);
                    pRegistro.entidad = datos.GetString(40);
                    pRegistro.n_operacion = datos.GetString(41);
                    pRegistro.notario = datos.GetString(42);
                    pRegistro.impor_liq = datos.GetDecimal(43);
                    pRegistro.firmado_por = datos.GetString(44);


                    _lista.Add(pRegistro);

                }

                comando.Connection.Close();
                return _lista;
            }
        }


        public static List<Fras_Ctes> Buscar_rfra_cte(char pt_deleg, int pd_n_fra, int ph_n_fra, DateTime pd_f_fra, DateTime ph_f_fra,
                                                char pt_cte, int pd_cte, int ph_cte) 
        {
            string sql = "";
            //string ordenado = "";
            List<Fras_Ctes> _lista = new List<Fras_Ctes>();

            

            if (pt_deleg == ' ' & pt_cte == ' ') //consulta todos los registros. (Mregistros)
            {
                sql = "(select t_cte_fra, id_colabora as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                        "from registros where factura <> 0 and t_cte_fra ='B'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                        " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "')" +
                        " union " +
                        "(select t_cte_fra , id_cte as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                        "from registros where factura <> 0 and t_cte_fra ='C'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                        " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "')" +
                        " union " +
                        "(select t_cte_fra , id_titular as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                        "from registros where factura <> 0 and t_cte_fra ='T'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                        " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "')" +
                        " order by 2";
                
            }
            else //opciones del buscador de registros
            {                

                if (pt_deleg != ' ' & pt_cte == ' ') //consulta el n_reg de su deleg.
                {                    
                    sql = "(select t_cte_fra, id_colabora as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                        "from registros where factura <> 0 and t_cte_fra ='B'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                        " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "' and delegacion ='"+pt_deleg+"')" +
                        " union " +
                        "(select t_cte_fra , id_cte as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                        "from registros where factura <> 0 and t_cte_fra ='C'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                        " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "' and delegacion ='"+pt_deleg+"')" +
                        " union " +
                        "(select t_cte_fra , id_titular as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                        "from registros where factura <> 0 and t_cte_fra ='T'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                        " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "' and delegacion ='"+pt_deleg+"')" +
                        " order by 2";                    
                }
                
                else
                {
                    if (pt_cte != ' ' & pt_deleg == ' ')// t_cte y nombre
                    {
                        if (pt_cte == 'C')
                            sql="select t_cte_fra , id_cte as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                            "from registros where factura <> 0 and t_cte_fra ='C'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                            " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + 
                            "' and id_cte between " + pd_cte + " and " + ph_cte + 
                            " order by 2";
                        else
                        {
                            if (pt_cte == 'T')
                                sql = "select t_cte_fra , id_titular as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                                      "from registros where factura <> 0 and t_cte_fra ='T'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                                      " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + 
                                      "' and id_titular between " + pd_cte + " and " + ph_cte + 
                                      " order by 2";
                            else
                                sql = "select t_cte_fra, id_colabora as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                                "from registros where factura <> 0 and t_cte_fra ='B'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                                " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + 
                                "' and id_colabora between " + pd_cte + " and " + ph_cte +
                                " order by 2";
                        }
                                                
                    }

                    else
                    {
                        //si pt_cte != ' ' & pt_deleg != ' '
                        if (pt_cte == 'C')
                            sql="select t_cte_fra , id_cte as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                            "from registros where factura <> 0 and t_cte_fra ='C'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                            " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "' and delegacion ='"+pt_deleg+
                             "' and id_cte between " + pd_cte + " and " + ph_cte + 
                            " order by 2";
                        else
                        {
                            if (pt_cte == 'T')
                                sql = "select t_cte_fra , id_titular as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                                      "from registros where factura <> 0 and t_cte_fra ='T'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                                      " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "' and delegacion ='"+pt_deleg+
                                      "' and id_titular between " + pd_cte + " and " + ph_cte + 
                                      " order by 2";
                            else
                                sql = "select t_cte_fra, id_colabora as id, (honorarios + dcho_col) as base, p_iva, tasa, delegacion, factura " +
                                "from registros where factura <> 0 and t_cte_fra ='B'" + " and factura between " + pd_n_fra + " and " + ph_n_fra +
                                " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "' and delegacion ='"+pt_deleg+
                                "' and id_colabora between " + pd_cte + " and " + ph_cte +
                                " order by 2";
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
                    Fras_Ctes pFras_Ctes = new Fras_Ctes();
                    pFras_Ctes.t_cte_fra = datos.GetChar(0);
                    pFras_Ctes.id = datos.GetInt32(1);                                        
                    pFras_Ctes.base_imp = datos.GetDecimal(2);
                    pFras_Ctes.p_iva = datos.GetInt16(3);
                    pFras_Ctes.tasa = datos.GetDecimal(4);
                    pFras_Ctes.delegacion = datos.GetChar(5);
                    pFras_Ctes.factura = datos.GetInt32(6);

                    _lista.Add(pFras_Ctes);

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
                    pRegistro.id_colabora = datos.GetInt32(34);
                    pRegistro.estado_fac = datos.GetChar(35);
                    pRegistro.exp_ntl = datos.GetString(36);
                    pRegistro.usuario = datos.GetString(37);
                    pRegistro.enviado = datos.GetString(38);
                    pRegistro.fec_anul = datos.GetString(39);
                    pRegistro.entidad = datos.GetString(40);
                    pRegistro.n_operacion = datos.GetString(41);
                    pRegistro.notario = datos.GetString(42);
                    pRegistro.impor_liq = datos.GetDecimal(43);
                    pRegistro.firmado_por = datos.GetString(44);

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
            string simpor_liq = General.Convertir_a_real(pRegistro.impor_liq.ToString("0.00"));
            

            //+  + pRegistro.tasa pRegistro.tasa_tl
            string sql = "update registros set fec_ent='"  + pRegistro.fec_ent + "', id_cte=" + pRegistro.id_cte + ", id_titular=" + pRegistro.id_titular + ", seccion_int='" + pRegistro.seccion_int + 
                         "', seccion='" + pRegistro.seccion + "', t_tramite='" + pRegistro.t_tramite + "', matricula='" + pRegistro.matricula + "', estado='" + pRegistro.estado + "', factura='" + pRegistro.factura +
                         "', fec_fra='" + pRegistro.fec_fra + "', observacion='" + pRegistro.observacion + "', honorarios='" + shonorarios + "', p_iva='" + pRegistro.p_iva + "', tasa='" + stasa +
                         "', exp_tl='" + pRegistro.exp_tl + "', fec_pre_exp='" + pRegistro.fec_pre_exp + "', et_tasa='" + pRegistro.et_tasa + "', t_tasa='" + pRegistro.t_tasa + "', cambio_serv='" + pRegistro.cambio_serv +
                         "', bate_ant='" + pRegistro.bate_ant + "', nif='" + pRegistro.nif + "', dcho_col='" + sdcho_col + "', t_cte_fra='" + pRegistro.t_cte_fra + "', et_tasa2='" + pRegistro.et_tasa2 + "', t_tasa2='" + pRegistro.t_tasa2 +
                         "', et_tasa3='" + pRegistro.et_tasa3 + "', t_tasa3='" + pRegistro.t_tasa3 + "', et_tasa4='" + pRegistro.et_tasa4 + "', t_tasa4='" + pRegistro.t_tasa4 + "', descripcion='" + pRegistro.descripcion +
                         "', ruta_pdf='" + pRegistro.ruta_pdf + "', vehiculo='" + pRegistro.vehiculo + "', id_colabora=" + pRegistro.id_colabora + ", estado_fac='" + pRegistro.estado_fac +
                         "'" + ", exp_ntl='" + pRegistro.exp_ntl + "'" + ", enviado='" + pRegistro.enviado + "'" + ", fec_anul='" + pRegistro.fec_anul + "'" + ", entidad='" + pRegistro.entidad +
                         "'" + ", n_operacion='" + pRegistro.n_operacion + "'" + ", notario='" + pRegistro.notario + "'" + ", impor_liq='" + simpor_liq + "'" + ", firmado_por='" + pRegistro.firmado_por + "'" +
                         " where delegacion='" + pRegistro.delegacion + "' and n_reg=" + pRegistro.n_reg;

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


        
        //public static List<Rg_mes_secc> Reg_Acum_Mes_Seccion(char pdeleg, short panyo, string pseccion)
        public static int[] Reg_Acum_Mes_Seccion(char pdeleg, short panyo, string pseccion, string pestado, short popcion)
        {         
            int[] pimpor_meses = new int[12];
            //List<Rg_mes_secc> _lista = new List<Rg_mes_secc>();
            //short index = 0;
            string sql = "";

            //opcion=0 --> seccion
            if (popcion == 0)
                sql = "select (Extract(Month from fec_ent)) mes, count(*) from registros where delegacion='" + pdeleg + "' and (Extract(Year from fec_ent))="+ panyo +
                         " and seccion='" + pseccion + "'";
            //opcion=1 --> seccion_int
            else
                sql = "select (Extract(Month from fec_ent)) mes, count(*) from registros where delegacion='" + pdeleg + "' and (Extract(Year from fec_ent))="+ panyo +
                         " and seccion_int='" + pseccion + "'";

            if (pestado != "")
                sql = sql + " and estado='" + pestado + "'";

            sql = sql + " group by mes order by mes";

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {

                    if (!datos.IsDBNull(0))
                    {
                        //**** cuidado con la conversion de datos en select con sum(), count(), ...****                        
                        pimpor_meses[Convert.ToInt32(datos.GetValue(0).ToString()) -1] = Convert.ToInt32(datos.GetValue(1).ToString());                                                
                    }
                    //index++;
                }

                comando.Connection.Close();

                return pimpor_meses;
            }

        }

        /* No utilizado, ver Calcular_max_linfac() q si lo está.
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

         */
 

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

                //si iid_cte = 0 -> cte comodin: pt_cte(C,T,B)
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
                        if (!datos.IsDBNull(0))
                        {
                            pid_cte = datos.GetString(0); //solo un reg.
                            existe++;
                        }
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

        /*** se utiliza el de x año, a continuacion.
        public static int Calcular_max_reg(char pt_deleg)
        {
            int max_reg = 0;
            string sql = "select max(n_reg) as total from registros where delegacion='" + pt_deleg + "'";
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
                        max_reg = Convert.ToInt32(datos.GetValue(0).ToString());//solo un reg.  

                }

                comando.Connection.Close();

                return max_reg;
            }
        }
         ***/

        public static int Calcular_max_reg_anyo(char pt_deleg, short panyo)
        {
            int max_reg = 0;
            string sql = "select max(n_reg) as total from registros where delegacion='" + pt_deleg + "' and (Extract(Year from fec_ent))="+ panyo;
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
                        max_reg = Convert.ToInt32(datos.GetValue(0).ToString());//solo un reg.  

                }

                comando.Connection.Close();

                return max_reg;
            }
        }

        public static string Sacar_tlfos_cte(string pid_cte, char pt_cte)
        {
            if (string.IsNullOrWhiteSpace(pid_cte.Trim()))
            {
                return pid_cte = " ";
            }
            else
            {
                int existe = 0;
                string sql;
                string tlfnos = "";
                int iid_cte = Convert.ToInt32(pid_cte);

                
                sql = "select telf1,telf2 from clientes where id_cliente=" + iid_cte + " and tipo_cte='" + pt_cte + "'";

                using (BDConexion.ObtenerConexion())
                {
                    NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                    comando.CommandTimeout = 5 * 60;

                    NpgsqlDataReader datos = comando.ExecuteReader();

                    while (datos.Read())
                    {
                        tlfnos = datos.GetString(0); //solo un reg.
                        if (!string.IsNullOrWhiteSpace(datos.GetString(1)))
                            tlfnos = tlfnos.Trim() + " - " + datos.GetString(1);
                        existe++;
                    }

                    comando.Connection.Close();

                    return tlfnos;
                }
            }
        }

        public static string Sacar_cta_cte(string pid_cte, char pt_cte)
        {
            if (string.IsNullOrWhiteSpace(pid_cte.Trim()))
            {
                return pid_cte = " ";
            }
            else
            {
                int existe = 0;
                string sql;
                string cta_cte = "430000000";
                int iid_cte = Convert.ToInt32(pid_cte);


                sql = "select cta_cble from clientes where id_cliente=" + iid_cte + " and tipo_cte='" + pt_cte + "'";

                using (BDConexion.ObtenerConexion())
                {
                    NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                    comando.CommandTimeout = 5 * 60;

                    NpgsqlDataReader datos = comando.ExecuteReader();

                    while (datos.Read())
                    {
                        cta_cte = datos.GetString(0); //solo un reg.
                        existe++;
                    }

                    comando.Connection.Close();

                    return cta_cte;
                }
            }
        }


        public static string Sacar_dnicif_cte(string pid_cte, char pt_cte)
        {
            if (string.IsNullOrWhiteSpace(pid_cte.Trim()))
            {
                return pid_cte = " ";
            }
            else
            {
                int existe = 0;
                string sql;
                string pdnicif = "";
                int iid_cte = Convert.ToInt32(pid_cte);


                sql = "select trim(documento)||letra dnicif from clientes where id_cliente=" + iid_cte + " and tipo_cte='" + pt_cte + "'";

                using (BDConexion.ObtenerConexion())
                {
                    NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                    comando.CommandTimeout = 5 * 60;

                    NpgsqlDataReader datos = comando.ExecuteReader();

                    while (datos.Read())
                    {
                        pdnicif = datos.GetString(0); //solo un reg.
                        existe++;
                    }

                    comando.Connection.Close();

                    return pdnicif;
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

        public static int Fra_listada_enlazada(int pn_fra, short ptipo) //,int pn_reg, char p_deleg
        {
            int listada = 0;
            string sql;
            //ptipo=0 listada/=1: enlazada
            if (ptipo == 0)
                sql = "update registros set estado_fac='L' where factura=" + pn_fra+" and estado_fac=' '";
            else 
                sql = "update registros set estado_fac='E' where factura=" + pn_fra+" and estado_fac='L'";

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                listada = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return listada;
            }

        }

        public static int Fra_desenlazada(char pt_deleg, int pd_n_fra, int ph_n_fra, DateTime pd_f_fra, DateTime ph_f_fra,
                                                char pt_cte, int pd_cte, int ph_cte, char ptipo)
        {
            int desenlazada = 0;
            string sql;
            //ptipo='L' listada/='E': enlazada/' ': sin listar
            
            if (pt_cte == ' ') //actualiza todos los tipos de ctes.
            {
                sql = "update registros set estado_fac='"+ptipo+"' where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() + "'";
            }
            else
            {
                if (pt_cte == 'C')
                    sql = "update registros set estado_fac='" + ptipo + "' where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                    " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() +
                    "' and registros.id_cte between " + pd_cte + " and " + ph_cte; 
                else
                {
                    if (pt_cte == 'T')
                        sql = "update registros set estado_fac='" + ptipo + "' where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                        " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() +
                        "' and registros.id_titular between " + pd_cte + " and " + ph_cte; 
                    else
                        sql = "update registros set estado_fac='" + ptipo + "' where factura <> 0 and factura between " + pd_n_fra + " and " + ph_n_fra +
                        " and fec_fra between '" + pd_f_fra.ToShortDateString() + "' and '" + ph_f_fra.ToShortDateString() +
                        "' and registros.id_colabora between " + pd_cte + " and " + ph_cte; 
                }

                sql = sql + " and delegacion='" + pt_deleg + "' and t_cte_fra='" + pt_cte + "'";
            }

            

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                desenlazada = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return desenlazada;
            }

        }

        public static int Fra_desfacturada(int pn_fra, char pdeleg) 
        {
            int accion = 0;
            string sql;
            
            sql = "update registros set factura=0, estado_fac=' ' where factura=" + pn_fra + " and delegacion='"+pdeleg+"'";            

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                accion = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return accion;
            }

        }

        public static int Reg_liquidado(char pt_deleg, int pn_reg) //,int pn_reg, char p_deleg
        {
            int updateado = 0;
            string sql;
            //ptipo=0 listada/=1: enlazada
            //if (ptipo == 0)
            //    sql = "update registros set estado_fac='L' where factura=" + pn_fra + " and estado_fac=' '";
            //else
            sql = "update registros set estado='LIQUIDADO' where delegacion='" + pt_deleg + "' and n_reg=" + pn_reg;

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                updateado = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return updateado;
            }

        }

        //no utilizado, por ahora segun Sergio.
        public static int Saca_serie_numfac(int p_sec_numfac0) //,int pn_reg, char p_deleg
        {
            //valores 0 y 9999 de posibles numfac
            int p_sec_numfac9 = p_sec_numfac0 + 9999;
            int max_numfac = p_sec_numfac0; //inicializamos valor 0 de la serie           
            
            string sql = "select max(factura) from registros where factura between " + p_sec_numfac0 + " and "+ p_sec_numfac9;
            
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
                        max_numfac = Convert.ToInt32(datos.GetValue(0).ToString());//solo un reg.  

                }

                comando.Connection.Close();
                return max_numfac + 1;
            }
            
        }

       

        public static int act_n_reg_anyo() //,int pn_reg, char p_deleg
        {
            int existe = 0;
            int n_reg_old=0;

            //la actual ya no entra aqui, luego solo busco la nueva si exite
            string sql = "select n_reg from registros where delegacion='"+ General.delegacion+"' and (Extract(Year from fec_ent))=2016 order by n_reg";
            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                NpgsqlDataReader datos = comando.ExecuteReader();

                while (datos.Read())
                {
                    n_reg_old = datos.GetInt32(0); 
                    //actualizamos el reg. actual
                    existe = act_n_reg_anyo2(General.delegacion, n_reg_old);
                }

                comando.Connection.Close();
                return existe;
            }

        }

        public static int act_n_reg_anyo2(char pdeleg, int p_n_reg_old)
        {
            int accion = 0;
            string sql;

             //busco el ultimo reg. insertado
            int max_reg_anyo = Reg_Opera.Calcular_max_reg_anyo(pdeleg, 2016);

            if (max_reg_anyo < 160001) //numero nuevo, 160001, sino max + 1.
            {
                max_reg_anyo = 160001;
            }
            else max_reg_anyo ++;


            sql = "update registros set n_reg="+ max_reg_anyo +" where n_reg=" + p_n_reg_old + " and delegacion='" + pdeleg + "'";

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                accion = comando.ExecuteNonQuery();
                comando.Connection.Close();

                //actualizamos h_registros
                if (accion > 0)
                {
                    accion = act_n_reg_anyo3(pdeleg, p_n_reg_old, max_reg_anyo);
                }
                return accion;
            }

        }
        public static int act_n_reg_anyo3(char pdeleg, int p_n_reg_old, int p_n_reg_new)
        {
            int accion = 0;
            string sql;

            sql = "update h_registros set n_reg=" + p_n_reg_new + " where n_reg=" + p_n_reg_old + " and delegacion='" + pdeleg + "'";

            using (BDConexion.ObtenerConexion())
            {
                NpgsqlCommand comando = new NpgsqlCommand(sql, BDConexion.ObtenerConexion());
                comando.CommandTimeout = 5 * 60;

                accion = comando.ExecuteNonQuery();
                comando.Connection.Close();

                return accion;
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
