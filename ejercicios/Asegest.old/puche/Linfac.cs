using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asegest
{
    class Linfac
    {
        public int numfac { get; set; }
        public short linea { get; set; }        
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public decimal importe { get; set; }
        public int p_iva { get; set; }
        public string cta_cble { get; set; }

        public Linfac() { }

        public Linfac(int pnumfac, short plinea, string pdescripcion, decimal pcantidad, decimal pimporte, int pp_iva, string pcta_cble)
        {
            this.numfac = pnumfac;
            this.linea = plinea;
            this.descripcion = pdescripcion;
            this.cantidad = pcantidad;            
            this.importe = pimporte;
            this.p_iva = pp_iva;
            this.cta_cble = pcta_cble;
        }
    }
}
