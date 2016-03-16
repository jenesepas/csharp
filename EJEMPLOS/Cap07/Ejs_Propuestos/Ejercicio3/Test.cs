// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class Test
{
  public static void Main(string[] args)
  {
    CFecha fecha = new CFecha();
    int día, mes, año;

    do
    {
      Console.Write("Día: "); día = Leer.datoInt();
      Console.Write("Mes: "); mes = Leer.datoInt();
      Console.Write("Año: "); año = Leer.datoInt();
    }
    while (!fecha.EstablecerFecha(día, mes, año));


    int div = 0, suma = día + mes + año;

    do
    {
      for (int i = 3; i >= 0; i--)
      {
          div += suma / (int)Math.Pow(10, i);
          suma = suma % (int)Math.Pow(10, i);
      }
      suma = div;
      div = 0;
    }
    while(suma > 9);

    Console.WriteLine("Su nmero de Tarot es: " + suma);
  }
}

