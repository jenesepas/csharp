using System;
using System.IO;

//////////////////////////////////////////////////////////////////
// Imprimir un fichero de texto
//
public class Imprimir
{
  public static void imprimir(FileStream fs)
  {
    byte[] buffer = new byte[1024];
    int nbytes = 0;
    byte ff = (byte)'\f';

    // Crear un flujo hacia la impresora
    FileStream impre = new FileStream("LPT1", FileMode.Open,
                                      FileAccess.Write);
  
    do
    {
      // Leer del fichero de texto
      nbytes = fs.Read(buffer, 0, 1024);
      if (nbytes == 0) break;
      // Imprimir el texto leído
      impre.Write(buffer, 0, nbytes);
    }
    while (true);

    impre.WriteByte(ff); // saltar a la siguiente página
    impre.Close();       // cerrar el flujo hacia la impresora
  }
  
  public static void Main(string[] args)
  {
    FileStream fs = null;
    
    try
    {
      if (args.Length == 0)
      {
        Console.WriteLine("Sintaxis: imprimir fichero");
        return;
      }

      string fichero = args[0];

      if (!File.Exists(fichero))
      {
        Console.WriteLine("El fichero no existe");
        return;
      }
      
      // Crear un flujo desde el fichero
      fs = new FileStream(fichero, FileMode.Open,
                          FileAccess.Read);
      // Imprimir el fichero de texto
      imprimir(fs);
    }
    catch(IOException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
    finally
    {
      // Cerrar el fichero
      if (fs != null) fs.Close();
    }
  }
}
