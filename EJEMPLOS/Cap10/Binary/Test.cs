using System;
using System.IO;

public class Test
{
  public static void Main(string[] args)
  {
    FileStream fs = null;
    BinaryWriter bw = null;
    BinaryReader br = null;
    String nombreFichero = "datos.dat";
    String nombre = null, dirección = null;
    long teléfono = 0;
    
    // Escribir daros
    try
    {
      fs = new FileStream(nombreFichero, FileMode.Create,
                          FileAccess.Write);
      bw = new BinaryWriter(fs);
    
      // Almacenar el nombre la dirección y el teléfono en el fichero
      bw.Write("un nombre");
      bw.Write("una dirección");
      bw.Write(942334455L);
      
      bw.Close(); fs.Close();
    
      // Leer datos
      fs = new FileStream(nombreFichero, FileMode.Open,
                          FileAccess.Read);
      br = new BinaryReader(fs);                        
    
      // Leer el nombre la dirección y el teléfono del fichero
      nombre = br.ReadString();
      dirección = br.ReadString();
      teléfono = br.ReadInt64();

      Console.WriteLine(nombre);
      Console.WriteLine(dirección);
      Console.WriteLine(teléfono);
  
      br.Close(); fs.Close();
    }
    catch (IOException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
  }
}

