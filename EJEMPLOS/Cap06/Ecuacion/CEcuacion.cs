// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES

using System;
using MisClases.ES;

class CEcuacion
{
  public static void Main(string[] args)
  {
    double a, b, c, d, x1, x2;
    
    Console.Write("Coeficiente a: "); a = Leer.datoDouble();
    Console.Write("Coeficiente b: "); b = Leer.datoDouble();
    Console.Write("Coeficiente c: "); c = Leer.datoDouble();
    
    d = b * b - 4 * a * c;
    if (d < 0)
    {
      // Si d es menor que 0
      Console.WriteLine("Las raíces son complejas.");
      return; // salir
    }
    // Si d es mayor o igual que 0
    Console.WriteLine("Las raíces reales son:");
    d = Math.Sqrt(d);
    x1 = (-b + d) / (2 * a);
    x2 = (-b - d) / (2 * a);
    Console.WriteLine("x1 = " + x1 + ", x2 = " + x2);
  }
}
