// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class Ejercicio1
{
  public static void Main(string[] args)
  {
    int x, y, suma = 0;

    do
    {
      Console.Write("Extremo inferior del intervalo: ");
      x = Leer.datoInt();
    }
    while (x < 0);

    do
    {
      Console.Write("Extremo superior del intervalo: ");
      y = Leer.datoInt();
    }
    while (y < 0);
    
    if (y < x)
    {
      int z = x;
      x = y;
      y = z;
    }

    for(int i = x; i < y; i++)
    {
      if (i % 5 == 0)
        suma += i;
    }
    Console.WriteLine("Suma de los múltiplos de 5 entre " + x + " y " + y + ": " + suma);
  }
}
