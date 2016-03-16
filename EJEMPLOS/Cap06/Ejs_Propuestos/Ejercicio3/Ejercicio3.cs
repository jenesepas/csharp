// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES

using System;
using MisClases.ES;

public class Ejercicio3
{
  public static void Main(string[] arg)
  {
    double x;
    double res;
    
    Console.Write("Introduzca el valor de x: ");
    x = Leer.datoInt();

    res = 3 * Math.Pow(x, 5) - 5 * Math.Pow(x, 3) + 2 * x - 7;
    Console.WriteLine("Para x = " + x + ", 3x^5 - 5x^3 + 2x - 7 = " + res);   
  }
}
