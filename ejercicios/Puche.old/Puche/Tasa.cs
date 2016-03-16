using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puche
{
    public class Tasa
    {
        public short ejercicio { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal importe { get; set; }

        public Tasa() { }

        public Tasa(short pejercicio, string pcodigo, string pdescripcion, decimal pimporte)
        {
            this.ejercicio = pejercicio;
            this.codigo = pcodigo;
            this.descripcion = pdescripcion;
            this.importe = pimporte;            
        }


    }
}
