using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asegest
{
    public class Rg_mes_secc
    {
        public string seccion { get; set; }
        public int ene { get; set; }        
        public int feb { get; set; } 
        public int mar { get; set; } 
        public int abr { get; set; } 
        public int may { get; set; } 
        public int jun { get; set; } 
        public int jul { get; set; } 
        public int ago { get; set; } 
        public int sep { get; set; } 
        public int oct { get; set; } 
        public int nov { get; set; } 
        public int dic { get; set; } 
        
        public Rg_mes_secc() { }

        public Rg_mes_secc(string pseccion, int pene, int pfeb, int pmar, int pabr, int pmay, int pjun, int pjul, int pago, int psep, 
                         int poct, int pnov, int pdic)
        {
            this.seccion = pseccion;
            this.ene = pene;                        
            this.feb = pfeb;
            this.mar = pmar;      
            this.abr = pabr;
            this.may = pmay;
            this.jun = pjun;
            this.jul = pjul;
            this.ago = pago;
            this.sep = psep;
            this.oct = poct;
            this.nov = pnov;
            this.dic = pdic;
        }
    }
}
