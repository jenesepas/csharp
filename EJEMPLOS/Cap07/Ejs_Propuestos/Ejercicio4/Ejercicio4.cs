// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class Ejercicio4
{
  public static void Main(string[] arg)
  {
    int numero = 0;
    int adivinar = 0;
    int i = 0;
    int oportunidades = 7;
    Random rnd = new Random();
    char resp = '\0';

    Console.WriteLine("Adivina mi número entre 0 y 100.");
    Console.WriteLine("Tienes " + oportunidades + " oportunidades. SUERTE.");
    do
    {
      adivinar = (int)(rnd.Next(0, 100));
      i = 0;
      do
      {
        Console.Write("\nNúmero: ");
        numero=Leer.datoInt(); 
        if (numero < adivinar)
          Console.WriteLine("Más grande");
        else if (numero > adivinar)
          Console.WriteLine("Más pequeño");
        else if (numero == adivinar)
          Console.WriteLine("Muy bien!!!!. Has acertado");
        i++;
      }
      while ((numero != adivinar) && (i < oportunidades));

      if (numero != adivinar)
        Console.WriteLine("No acertaste. El número era el "+ adivinar);

      Console.Write("\n¿Quieres seguir jugando? (s/n): ");
      resp = (char)Console.Read();
      Console.ReadLine(); // limpiar buffer de entrada
    }
    while(resp == 's');
  }
}
