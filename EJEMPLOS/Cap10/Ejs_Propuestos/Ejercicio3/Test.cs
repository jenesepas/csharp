using System;
using System.IO;

public class Test
{  
  public static void Main(string[] args)
  {
    if (args.Length != 2)
      Console.WriteLine("Sintaxis: Ejercicio3 " +
                        "<fichero1>" + "<fichero2>");
    else
    {
      Ficheros ficheros = new Ficheros();
      try
      {
        ficheros.abrir(args[0], args[1]);
        ficheros.fusionar();
      }
      catch(IOException e)
      {
        Console.WriteLine("Error: " + e.Message);
      }
    }
  }
}
