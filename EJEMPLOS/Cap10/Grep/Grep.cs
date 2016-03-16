using System;
using System.IO;

public class Grep
{
  public static bool BuscarCadena(string cadena1, string cadena2)
  {
    // ¿cadena2 está contenida en cadena1?
    if (cadena1.IndexOf(cadena2) > -1)
      return true;  // sí
    else
      return false; // no
  }
  
  public static void BuscarEnFich(string nombrefich, string cadena)
  {
    // Definiciones de variables
    StreamReader sr = null;
    
    try
    {
      // Asegurarse de que el fichero existe
      if (!File.Exists(nombrefich))
      {
        Console.WriteLine("No existe el fichero " + nombrefich);
        return;
      }
      
      // Abrir un flujo de entrada desde el fichero fuente
      sr = new StreamReader(nombrefich);

      // Buscar cadena en el fichero fuente
      string linea;
      int nroLinea = 0;

      while ((linea = sr.ReadLine()) != null)
      {
        // Si se alcanzó el final del fichero,
        // ReadLine devuelve null
        nroLinea++; // contador de líneas
        if (BuscarCadena(linea, cadena))
          Console.WriteLine(nombrefich + " " + nroLinea + " " +
                            linea);
      }
    }
    catch(IOException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
    finally
    {
      // Cerrar el flujo
      if (sr != null) sr.Close();
    }    
  }
  
  public static void Main(string[] args)
  {
    // Main debe recibir dos o más parámetros: la cadena a buscar
    // y los ficheros fuente. Por ejemplo:
    // Grep catch Grep.cs Leer.cs

    if (args.Length < 2)
      Console.WriteLine("Sintaxis: Grep " + "<cadena> " +
                         "<fichero 1> <fichero 2> ...");
    else
    {
      for (int i = 1; i < args.Length; i++)
        // Buscar args[0] en args[i]
        BuscarEnFich(args[i], args[0]);
    }
  }
}

