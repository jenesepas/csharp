using System;
using System.IO;

public class CEscribirBytes
{
  public static void Main(string[] args)
  {
    FileStream fs = null;
    byte[] buffer = new byte[81];
    int nbytes = 0, car;
    
    try
    {
      // Crear un flujo hacia el fichero texto.txt
      fs = new FileStream("texto.txt",
                          FileMode.Create, FileAccess.Write);

      Console.WriteLine(
        "Escriba el texto que desea almacenar en el fichero:");
      while ((car = Console.Read()) != '\r' && nbytes < buffer.Length)
      {
        buffer[nbytes] = (byte)car;
        nbytes++;
      }

      // Escribir la línea de texto en el fichero
      fs.Write(buffer, 0, nbytes);
    }
    catch(IOException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
    finally
    {
      if (fs != null) fs.Close();
    }
  }
}

