// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class Ejercicio2
{
  public static void Main(string[] args)
  {
    int b = 0, a = 0;
    int aux = 0;
    double x, y, suma = 0;

    do
    {
      Console.Write("Sumatorio desde a = 0 hasta b = ");
      b = Leer.datoInt();
    }
    while (b < 0);

    if (b < a)
    {
      aux = a;
      a = b;
      b = aux;
    }
    
    Console.WriteLine("de 1/(x + ay)");

    do
    {
      Console.Write("Introduce el valor de x: ");
      x = Leer.datoDouble();
    }
    while (x < 0);

    do
    {
      Console.Write("Introduce el valor de y: ");
      y = Leer.datoDouble();
    }
    while (y < 0);

    CEcuacion ec1 = new CEcuacion();
    for(a = 0; a <= b; a++)
    {
      ec1.establecerCoeficientes(a);
      suma += ec1.valorEcuacion(x, y);
    }

    Console.WriteLine("La suma es " + suma);
  }
}
