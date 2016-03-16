﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Puche
{
    class General
    {
        //sustituimos "," x "." para insert o update bd.
        public static string Convertir_a_real(string preal)
        {
            return preal = preal.Replace(",", ".");
        }

        //Campos enteros
        public static int Validar_entero(string pentero)
        {
            int valor;
            if (! Int32.TryParse(pentero, out valor)) //si false, conversion erronea
            {
                MessageBox.Show("Debe introducir un número entero", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else return valor;
        }

        //Campos enteros
        public static long Validar_entero_l(string pentero)
        {
            long valor;
            if (!Int64.TryParse(pentero, out valor)) //si false, conversion erronea
            {
                MessageBox.Show("Debe introducir un número entero", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else return valor;
        }

        //campos reales
        public static int Validar_real(string preal)
        {
            decimal valor;
            if (!decimal.TryParse(preal, out valor)) //si false, conversion erronea
            {
                MessageBox.Show("Debe introducir un número decimal con 1 coma", "Atención Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else                            
                return 0;
            
        }
    }

}