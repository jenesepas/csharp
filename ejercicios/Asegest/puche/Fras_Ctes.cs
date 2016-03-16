using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asegest
{
    public class Fras_Ctes
    {
        public char t_cte_fra { get; set; }
        public int id { get; set; }        
        public decimal base_imp { get; set; }       
        public int p_iva { get; set; }
        public decimal tasa { get; set; }
        public char delegacion { get; set; }
        public int factura { get; set; } 
        
        
        public Fras_Ctes() { }

        public Fras_Ctes(char pt_cte_fra, int pid, decimal pbase_imp, int pp_iva, decimal ptasa,
                         char pdelegacion, int pfactura)
        {
            this.t_cte_fra = pt_cte_fra;
            this.id = pid;                        
            this.base_imp = pbase_imp;
            this.p_iva = pp_iva;      
            this.tasa = tasa;
            this.delegacion = pdelegacion;
            this.factura = pfactura;
        }


    }
}
