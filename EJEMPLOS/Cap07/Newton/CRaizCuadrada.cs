// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CRaizCuadrada
{
  // Raíz cuadrada. Método de Newton.
  public static void Main(string[] args)
  {
    double n;        // número
    double aprox;    // aproximación a la raíz cuadrada
    double antaprox; // anterior aproximación a la raíz cuadrada
    double epsilon;  // coeficiente de error
        
    do
    {
      Console.Write("Número: ");
      n = Leer.datoDouble();
    }
    while ( n < 0 );
    do
    {
      Console.Write("Raíz cuadrada aproximada: ");
      aprox = Leer.datoDouble();
    }
    while ( aprox <= 0 );
    do
    {
    Console.Write("Coeficiente de error: ");
    epsilon = Leer.datoDouble();
    }
    while ( epsilon <= 0 );
    do
    {
      antaprox = aprox;
      aprox = (n/antaprox + antaprox) / 2;
    }
    while (Math.Abs(aprox - antaprox) >= epsilon);
    Console.WriteLine("La raíz cuadrada de {0:F2} es {1:F2}", n, aprox);
  }
}
