using System;
using System.IO;

public class CLeerCars
{
  public static void Main(string[] args)
  {
    StreamReader sr = null;
    String str;
    
    try
    {
      // Obtener el nombre del fichero de la entrada estándar
      do
      {
        Console.Write("Nombre del fichero: ");
        str = Console.ReadLine();
      }
      while (!File.Exists(str));
      
      // Crear un flujo desde el fichero str
      sr = new StreamReader(str);
      
      // Leer del fichero una línea de texto
      str = sr.ReadLine();
      while (str != null)
      {
        // Mostrar la línea leída
        Console.WriteLine(str);
        // Leer la línea siguiente
        str = sr.ReadLine();
      }
    }
    catch(IOException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
    finally
    {
      // Cerrar el fichero
      if (sr != null) sr.Close();
    }
  }
}
