using System;
using MisClases.ES;

public class Test
{
  // Cálculo del factorial de un número
  public static long factorial(int n)
  {
    if (n == 0)
      return 1;
    else
      return n * factorial(n-1);
  }

  public static void Main(string[] args)
  {
    int numero;
    long fac;

    do
    {
      Console.Write("¿Número? ");
      numero = Leer.datoInt();
    }
    while (numero < 0 || numero > 25);

    fac = factorial(numero);
    Console.WriteLine("\nEl factorial de " + numero + " es: " + fac);
  }
}

