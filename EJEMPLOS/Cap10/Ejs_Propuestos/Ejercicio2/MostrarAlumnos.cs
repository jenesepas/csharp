using System;
using System.IO;

public class MostrarAlumnos
{
  public static void mostrarFichero(string fichero)
  {
    BinaryReader br = null; // flujo entrada de datos
                            //desde el fichero
    try
    {
      if (File.Exists(fichero))
      {
        // Si existe, abrir un flujo desde el mismo para leer
        br = new BinaryReader(new FileStream(
                      fichero, FileMode.Open, FileAccess.Read));
        
        // Declarar los datos a leer desde el fichero
        int númeroMatrícula;
        String nombre;
        String calificación;

        do
        {
          // Leer un nº de matrícula, un nombre y una calificación desde
          // el fichero. Cuando se alcance el final del fichero C#
          // lanzará una excepción del tipo EndOfStreamException.
          númeroMatrícula = br.ReadInt32();
          nombre = br.ReadString();
          calificación = br.ReadString();
          
          // Mostrar los datos nº de matrícula, nombre y calificación
          Console.WriteLine(númeroMatrícula);
          Console.WriteLine(nombre);
          Console.WriteLine(calificación);
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
