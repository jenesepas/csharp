using System;
using System.IO;

public class CEscribirCars
{
  public static void Main(string[] args)
  {
    StreamWriter sw = null;
    String str;
    
    try
    {
      // Obtener el nombre del fichero de la entrada estándar
      Console.Write("Nombre del fichero: ");
      str = Console.ReadLine();

      char resp = 's';
      if (File.Exists(str))
      {
        Console.Write("El fichero existe ¿desea sobreescribirlo? (s/n) ");
        resp = (char)Console.Read();
        // Saltar los bytes no leídos del flujo de entrada estándar
        Console.ReadLine();
      }
      if (resp != 's') return;

      // Crear un flujo hacia el fichero doc.txt
      sw = new StreamWriter(str);

      Console.WriteLine(
        "Escriba las líneas de texto a almacenar en el fichero.\n" +
        "Finalice cada línea pulsando la tecla <Entrar>.\n" +
        "Para finalizar pulse sólo la tecla <Entrar>.\n");
      // Leer una línea de la entrada estándar
      str = Console.ReadLine();
      while (str.Length != 0)
      {
        // Escribir la línea leída en el fichero
        sw.WriteLine(str);
        // Leer la línea siguiente
        str = Console.ReadLine();
      }      
    }
    catch(UnauthorizedAccessException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
    catch(IOException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
    finally
    {
      if (sw != null) sw.Close();
    }
  }
}

