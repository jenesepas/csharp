using System;
using System.IO;

public class CLeerBytes
{
  public static void Main(string[] args)
  {
    FileStream fe = null;
    char[] cBuffer = new char[81];
    byte[] bBuffer = new byte[81];
    int nbytes;
    
    try
    {
      // Crear un flujo desde el fichero texto.txt
      fe = new FileStream("texto.txt",
                          FileMode.Open, FileAccess.Read);
      // Leer del fichero una línea de texto
      nbytes = fe.Read(bBuffer, 0, 81);
      // Crear un objeto string con el texto leído
      Array.Copy(bBuffer, cBuffer, bBuffer.Length);
      String str = new String(cBuffer, 0, nbytes);
      // Mostrar el texto leído
      Console.WriteLine(str);
    }
    catch(IOException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
    finally
    {
      // Cerrar el fichero
      if (fe != null) fe.Close();
    }
  }
}
