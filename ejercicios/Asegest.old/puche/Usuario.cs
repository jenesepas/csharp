using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asegest
{
    public class Usuario
    {        
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string clave { get; set; }
        public short acceso { get; set; }

        public Usuario() { }

        public Usuario(string pcodigo, string pnombre, string pclave, short pacceso)
        {            
            this.codigo = pcodigo;
            this.nombre = pnombre;
            this.clave = pclave;
            this.acceso = pacceso;
        }


    }
}
