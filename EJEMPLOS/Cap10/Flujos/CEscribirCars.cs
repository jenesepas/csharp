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
      // Crear un flujo hacia el fichero doc.txt
      sw = new StreamWriter("doc.txt");

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

