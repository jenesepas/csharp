// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CEcuacion2Grado
{
  // Calcular las raíces de una ecuación de 2º grado
  public static void Main(string[] args)
  {
    double a, b, c; // coeficientes de la ecuación
    double d;       // discriminante
    double re, im;  // parte real e imaginaria de la raíz
    
    Console.WriteLine("Coeficientes a, b y c de la ecuación:");
    Console.Write("a = "); a = Leer.datoDouble();
    Console.Write("b = "); b = Leer.datoDouble();
    Console.Write("c = "); c = Leer.datoDouble();
    Console.WriteLine();
    if (a == 0 && b == 0)
      Console.WriteLine("La ecuación es degenerada");
    else if (a == 0)
      Console.WriteLine("La única raíz es: " + -c/b);
    else
    {
      re = -b / (2 * a);
      d = b * b - 4 * a * c;
      im = Math.Sqrt(Math.Abs(d)) / (2 * a);
      if (d >= 0)
      {
        Console.WriteLine("Raíces reales:");
        Console.WriteLine((re+im) + ", " + (re-im));
      }
      else
      {
        Console.WriteLine("Raíces complejas:");
        Console.WriteLine(re + " + " + Math.Abs(im) + " j");
        Console.WriteLine(re + " - " + Math.Abs(im) + " j");
      }
    }
  }
}
