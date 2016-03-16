using System;
using System.IO;
using MisClases.ES; // espacio de nombres de la clase Leer

public class CrearAlumnos
{
  public static void crearFichero(string fichero)
  {
    BinaryWriter bw = null;// salida de datos hacia el fichero
    char resp;
    try
    {
      // Crear un flujo hacia el fichero que permita escribir
      // datos de tipos primitivos y que utilice un buffer.
      bw = new BinaryWriter(new FileStream(
                    fichero, FileMode.Create, FileAccess.Write));

      // Declarar los datos a escribir en el fichero
      int númeroMatrícula;
      string nombre;
      string calificación;

      // Leer datos de la entrada estándar y escribirlos
      // en el fichero
      do
      {
        Console.Write("Nº de matrícula:                ");
        númeroMatrícula = Leer.datoInt();
        Console.Write("Nombre:                         ");
        nombre = Console.ReadLine();
        Console.Write("Calificación (SS, AP, NT o SB): ");
        calificación = Console.ReadLine();
            
        // Almacenar un registro en el fichero
        bw.Write(númeroMatrícula);
        bw.Write(nombre);
        bw.Write(calificación);
            
        Console.Write("desea escribir otro registro? (s/n) ");
        resp = (char)Console.Read();
        // Saltar los caracteres disponibles en el flujo de entrada
        Console.ReadLine();
      }
      while (resp == 's');
    }
    finally
    {
      // Cerrar el flujo
      if (bw != null) bw.Close();
    }
  }

  public static void Main(string[] args)
  {
    string nombreFichero = null;     // nombre del fichero
    
    try
    {
      // Obtener el nombre del fichero
      Console.Write("Nombre del fichero: ");
      nombreFichero = Console.ReadLine();
      
      // Verificar si el fichero existe
      char resp = 's';
      if (File.Exists(nombreFichero))
      {
        Console.Write("¿El fichero existe desea sobreescribirlo? (s/n) ");
        resp = (char)Console.Read();
        // Eliminar los caracteres sobrantes en el flujo de entrada
        Console.ReadLine();
      }
      if (resp == 's')
      {
        crearFichero(nombreFichero);
      }
    }
    catch(IOException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
  }
}
