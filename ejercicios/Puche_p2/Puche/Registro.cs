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
        public decimal honorarios { get; set; }
        public int p_iva  { get; set; }
        public decimal tasa  { get; set; }
        public string exp_tl  { get; set; }
        public DateTime fec_pre_exp  { get; set; }
        public int et_tasa  { get; set; }
        public string t_tasa  { get; set; }
        public string cambio_serv { get; set; }
        public string bate_ant { get; set; }
        public string nif { get; set; }
        public decimal  dcho_col { get; set; }
        public char t_cte_fra { get; set; }
        public int et_tasa2 { get; set; }
        public string t_tasa2 { get; set; }
        public int et_tasa3 { get; set; }
        public string t_tasa3 { get; set; }
        public int et_tasa4 { get; set; }
        public string t_tasa4 { get; set; }
        public string descripcion { get; set; }
        public string ruta_pdf { get; set; }

        public Registro() { }

        public Registro(char pdelegacion, int pn_reg, DateTime pfec_ent, int pid_cte, int pid_titular, string pseccion_int, 
                        string pseccion, string pt_tramite, string pmatricula, string pestado, int pfactura, DateTime pfec_fra, string pobservacion, 
                        decimal phonorarios, int pp_iva, decimal ptasa, string pexp_tl, DateTime pfec_pre_exp, int pet_tasa, string pt_tasa, string pcambio_serv,
                        string pbate_ant, string pnif, decimal pdcho_col, char pt_cte_fra, int pet_tasa2, string pt_tasa2, int pet_tasa3, string pt_tasa3,
                        int pet_tasa4, string pt_tasa4, string pdescripcion, string pruta_pdf)
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
            this.honorarios = phonorarios;
            this.p_iva = pp_iva;
            this.tasa = ptasa;
            this.exp_tl = pexp_tl;
            this.fec_pre_exp = pfec_pre_exp;
            this.et_tasa = pet_tasa;
            this.t_tasa = pt_tasa;
            this.cambio_serv = pcambio_serv;
            this.bate_ant = pbate_ant;
            this.nif = pnif;
            this.dcho_col = pdcho_col;
            this.t_cte_fra = pt_cte_fra;
            this.et_tasa2 = pet_tasa2;
            this.t_tasa2 = pt_tasa2;
            this.et_tasa3 = pet_tasa3;
            this.t_tasa3 = pt_tasa3;
            this.et_tasa4 = pet_tasa4;
            this.t_tasa4 = pt_tasa4;
            this.descripcion = pdescripcion;
            this.ruta_pdf = pruta_pdf;
        }
    }
}
