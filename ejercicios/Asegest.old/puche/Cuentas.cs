using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asegest
{
    public class Cuentas
    {
         
        public string cta_cble { get; set; }
        public decimal importe_acu { get; set; }
        

        public Cuentas() { }

        public Cuentas(string pcta_cble, decimal pimporte_acu)
        {
           
            this.cta_cble = pcta_cble;
            this.importe_acu = pimporte_acu;            
            
        }
    }
}
