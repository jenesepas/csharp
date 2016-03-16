using System;
using System.IO;

public class MostrarListaTfnos
{
  public static void mostrarFichero(String fichero)
  {
    BinaryReader br = null; // flujo entrada de datos
                            //desde el fichero
    try
    {
      // Verificar si el fichero existe
      if (File.Exists(fichero))
      {
        // Si existe, abrir un flujo desde el mismo para leer
        br = new BinaryReader(new FileStream(
                      fichero, FileMode.Open, FileAccess.Read));
        
        // Declarar los datos a leer desde el fichero
        String nombre, dirección;
        long teléfono;
        
        do
        {
          // Leer un nombre, una dirección y un teléfono desde el
          // fichero. Cuando se alcance el final del fichero C#
          // lanzará una excepción del tipo EndOfStreamException.
          nombre = br.ReadString();
          dirección = br.ReadString();
          teléfono = br.ReadInt64();
          
          // Mostrar los datos nombre, dirección y teléfono
          Console.WriteLine(nombre);
          Console.WriteLine(dirección);
          Console.WriteLine(teléfono);
          Console.WriteLine();
        }
        while (true);
      }
      else
        Console.WriteLine("El fichero no existe");
    }
    catch(EndOfStreamException)
    {
      Console.WriteLine("Fin del listado");
    }
    finally
    {
      // Cerrar el flujo
      if (br != null) br.Close();
    }
  }
  
  public static void Main(string[] args)
  {
    try
    {
      if (args.Length == 0)
      {
        // Obtener el nombre del fichero
        Console.Write("Nombre del fichero: ");
        string nombreFichero = Console.ReadLine();
        mostrarFichero(nombreFichero);
      }
      else
      {
          mostrarFichero(args[0]);
      }
    }
    catch(IOException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
  }
}
