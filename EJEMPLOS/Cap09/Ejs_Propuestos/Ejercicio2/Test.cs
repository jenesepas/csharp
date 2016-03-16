using System;
using MisClases.ES;

public class Test
{
  public static void Main(string[] arg)
  {
    int n = 0;

    Console.Write("Orden del cuadrado mágico (impar): ");
    n = Leer.datoInt();

    CuadradoMagico cm = new CuadradoMagico(n); 
    cm.cuadradoMagico();
     
    Console.WriteLine("\n\nEL cuadrado mágico de orden " + n + " es:\n\n");
    cm.visualizar();
  }
}
