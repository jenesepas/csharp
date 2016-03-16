// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CDiasMes
{
  // Días correspondientes a un mes de un año dado
  
  public static void Main(string[] args)
  {
    int días = 0, año = 0;
    string mes;
    bool error = false;
    
    Console.Write("Mes (en letras): "); mes = Console.ReadLine();
    Console.Write("Año (####): "); año = Leer.datoInt();
    
    switch (mes)
    {
      case "enero":
      case "marzo":
      case "mayo":
      case "julio":
      case "agosto":
      case "octubre":
      case "diciembre":
        días = 31;
        break;
      case "abril":
      case "junio":
      case "septiembre":
      case "noviembre":
        días = 30;
        break;
      case "febrero":
        // Es el año bisiesto?
        if ((año % 4 == 0) && (año % 100 != 0) || (año % 400 == 0))
          días = 29;
        else
          días = 28;
          break;
      default:
        Console.WriteLine("\nEl mes no es válido");
        error = true;
        break;
    }
    if (!error)
      Console.WriteLine("\nEl mes " + mes + " del año " + año +
                        " tiene " + días + " días");
  }
}
