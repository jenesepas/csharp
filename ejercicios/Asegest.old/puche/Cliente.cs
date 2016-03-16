using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asegest
{
    public class Cliente
    {
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Tipo_docu { get; set; }
        public string Documento { get; set; }
        public char Letra { get; set; }
        public string Direccion { get; set; }
        public string Pers_cont { get; set; }
        public string Email { get; set; }
        public string Telf1 { get; set; }
        public string Telf2 { get; set; }
        public string Cpostal { get; set; }
        public string Ciudad { get; set; }
        public string Provin { get; set; }
        public char Tipo_cte { get; set; }
        public string cta_cble { get; set; }

        public Cliente() { }

        public Cliente(int pid_cte, string pnombre, string ptipo_docu, string pdocumento, char pletra,
                       string pdireccion, string ppers_c, string pemail, string ptel1, string ptel2,
                       string pcp, string pcity, string pprov, char pt_cte, string pcta_cble)
        {
            this.Id_Cliente = pid_cte;
            this.Nombre = pnombre;
            this.Tipo_docu = ptipo_docu;
            this.Documento = pdocumento;
            this.Letra = pletra;
            this.Direccion = pdireccion;
            this.Pers_cont = ppers_c;
            this.Email = pemail;
            this.Telf1 = ptel1;
            this.Telf2 = ptel2;
            this.Cpostal = pcp;
            this.Ciudad = pcity;
            this.Provin = pprov;
            this.Tipo_cte = pt_cte;
            this.cta_cble = pcta_cble;
        }
    }
}
