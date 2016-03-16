// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CMenor
{
  // Menor de tres números a, b y c
   
  public static void Main(string[] args)
  {
    float a, b, c, menor;
    
    // Leer los valores de a, b y c
    Console.Write("a : "); a = Leer.datoFloat();
    Console.Write("b : "); b = Leer.datoFloat();
    Console.Write("c : "); c = Leer.datoFloat();
    // Obtener el menor
    if (a < b)
      if (a < c)
        menor = a;
      else
        menor =c;
    else
      if (b < c)
        menor = b;
      else
        menor = c;
    Console.WriteLine("Menor = " + menor);
  }
}
