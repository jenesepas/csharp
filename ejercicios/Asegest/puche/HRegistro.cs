using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asegest
{
    public class HRegistro
    {        
        public char delegacion { get; set; }
        public int n_reg { get; set; }
        public short linea { get; set; }
        public DateTime fec_modif { get; set; }
        public char tipo_modif { get; set; }
        public string cod_usu { get; set; }                

        public HRegistro() { }

        public HRegistro(char pdelegacion, int pn_reg, short plinea, DateTime pfec_modif, char ptipo_modif, string pcod_usu)
        {            
            this.delegacion = pdelegacion;
            this.n_reg = pn_reg;
            this.linea = plinea;
            this.fec_modif = pfec_modif;
            this.tipo_modif = ptipo_modif;
            this.cod_usu = pcod_usu;
        }


    }
}
