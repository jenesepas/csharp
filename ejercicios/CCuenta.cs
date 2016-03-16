/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAritmetica
{
 */ 
    class CCuenta
    {
        private string nombre;
        private string cuenta;
        private double saldo;
        private double tipoDeInteres;

        public void asignarNombre(string nom)
        {
            if (nom.Length == 0)
            {
                System.Console.WriteLine("Error: cadena vacía.");
                return;
            }
            nombre = nom;
        }

        public string obtenerNombre()
        {
            return nombre;
        }

        public void asignarCta(string cta)
        {
            if (cta.Length == 0)
            {
                System.Console.WriteLine("Error: Cta no válida.");
                return;
            }
            cuenta = cta;
        }

        public string obtenerCta()
        {
            return cuenta;
        }

        public double estado()
        {
            return saldo;
        }

        public void ingreso(double cantidad)
        {
            if (cantidad < 0)
            {
                System.Console.WriteLine("Error: Cantidad negativa.");
                return;
            }
            saldo = saldo + cantidad;
        }

        public void reintegro(double cantidad)
        {
            if (saldo - cantidad < 0)
            {
                System.Console.WriteLine("Error: No dispone de saldo.");
                return;
            }
            saldo = saldo - cantidad;
        }

        public void asignarTipoDeInteres(double tipo)
        {
            if (tipo < 0)
            {
                System.Console.WriteLine("Error: Tipo no válido.");
                return;
            }
            tipoDeInteres = tipo;
        }

        public double obtenerTipoDeInteres()
        {
            return tipoDeInteres;
        }
    }

//}
