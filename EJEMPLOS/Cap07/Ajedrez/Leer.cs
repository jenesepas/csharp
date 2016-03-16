using System;

namespace MisClases.ES // espacio de nombres
{
  public class Leer    // clase Leer
  {
    public static short datoShort()
    {
      try
      {
        return Int16.Parse(Console.ReadLine());
      }
      catch(FormatException)
      {
        return Int16.MinValue; // valor más pequeño
      }
    }
  
    public static int datoInt()
    {
      try
      {
        return Int32.Parse(Console.ReadLine());
      }
      catch(FormatException)
      {
        return Int32.MinValue; // valor más pequeño
      }
    }
  
    public static long datoLong()
    {
      try
      {
        return Int64.Parse(Console.ReadLine());
      }
      catch(FormatException)
      {
        return Int64.MinValue; // valor más pequeño
      }
    }
  
    public static float datoFloat()
    {
      try
      {
        return Single.Parse(Console.ReadLine());
      }
      catch(FormatException)
      {
        return Single.NaN; // No es un Número; valor float.
      }
    }
  
    public static double datoDouble()
    {
      try
      {
        return Double.Parse(Console.ReadLine());
      }
      catch(FormatException)
      {
        return Double.NaN; // No es un Número; valor double.
      }
    }
  }
}
