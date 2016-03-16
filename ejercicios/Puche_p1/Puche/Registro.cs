using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puche
{
    public class Registro
    {
        public char delegacion { get; set; }
        public int n_reg { get; set; }
        public DateTime fec_ent { get; set; }
        public int id_cte { get; set; }
        public int id_titular { get; set; }
        public string seccion_int { get; set; }
        public string seccion { get; set; }
        public string t_tramite { get; set; }
        public string matricula { get; set; }
        public string estado { get; set; }
        public int factura { get; set; }
        public DateTime fec_fra { get; set; }
        public string observacion { get; set; }
        public decimal base_imp { get; set; }
        public int p_iva  { get; set; }
        public decimal tasa  { get; set; }
        public string exp_tl  { get; set; }
        public DateTime fec_pre_exp  { get; set; }
        public int tasa_tl  { get; set; }
        public string tipo_tl  { get; set; }
        public string cambio_serv { get; set; }
        public string bate_ant { get; set; }
        public string nif { get; set; }
        public decimal  dcho_col { get; set; }
        public char t_cte_fra { get; set; }

        public Registro() { }

        public Registro(char pdelegacion, int pn_reg, DateTime pfec_ent, int pid_cte, int pid_titular, string pseccion_int, 
                        string pseccion, string pt_tramite, string pmatricula, string pestado, int pfactura, DateTime pfec_fra, string pobservacion, 
                        decimal pbase_imp, int pp_iva, decimal ptasa, string pexp_tl, DateTime pfec_pre_exp, int ptasa_tl, string ptipo_tl, string pcambio_serv, 
                        string pbate_ant, string pnif, decimal pdcho_col, char pt_cte_fra)
        {
            this.delegacion = pdelegacion;
            this.n_reg = pn_reg;
            this.fec_ent = pfec_ent;
            this.id_cte = pid_cte;
            this.id_titular = pid_titular;
            this.seccion_int = pseccion_int;
            this.seccion = pseccion;
            this.t_tramite = pt_tramite;
            this.matricula = pmatricula;
            this.estado = pestado;
            this.factura = pfactura;
            this.fec_fra = pfec_fra;
            this.observacion = pobservacion;
            this.base_imp = pbase_imp;
            this.p_iva = pp_iva;
            this.tasa = ptasa;
            this.exp_tl = pexp_tl;
            this.fec_pre_exp = pfec_pre_exp;
            this.tasa_tl = ptasa_tl;
            this.tipo_tl = ptipo_tl;
            this.cambio_serv = pcambio_serv;
            this.bate_ant = pbate_ant;
            this.nif = pnif;
            this.dcho_col = pdcho_col;
            this.t_cte_fra = pt_cte_fra;
        }
    }
}
