using System;
using System.IO;

public class CopiarFichero
{
  public static void copiar(string fichFuente, string fichDestino)
  {
    // Si el fichero fuente y el destino son el mismo fichero ...
    if (fichFuente.CompareTo(fichDestino) == 0)
        throw new IOException("No se puede copiar un fichero " +
                              "sobre sí mismo");

    // Definiciones de variables, referencias y objetos
    FileStream fFuente = null;
    FileStream fDestino = null;
    
    try
    {
      // Asegurarse de que el fichero "fichFuente" existe
      if (!File.Exists(fichFuente))
        throw new IOException("No existe el fichero " + fichFuente);

      // Si "fichDestino" existe, asegurarse de que no está
      // protegido contra escritura y preguntar si se quiere
      // sobreescribir.
      if (File.Exists(fichDestino))
      {
        FileAttributes atributos = File.GetAttributes(fichDestino);
        if ((atributos & FileAttributes.ReadOnly) != 0)
          throw new IOException("No se puede escribir en " +
                                "el fichero " + fichDestino);
        // Indicar que el fichero ya existe y preguntar si se
        // desea sobreescribir.
        Console.Write("El fichero " + fichDestino + " existe. " +
                      "¿Desea sobreescribirlo? (s/n): ");
        // Leer la respuesta
        char resp = (char)Console.Read();
        Console.ReadLine(); // limpiar el buffer de entrada
        if (resp == 'n' || resp == 'N')
          throw new IOException("Copia cancelada");
      }
      else
      {
        // Si se ha introducido una ruta absoluta, por ejemplo:
        // c:\ejemplos\c#\mifichero
        // y "mifichero" no existe verificar que el directorio
        // padre "c:\ejemplos\c#" existe y no está protegido
        // contra escritura
        DirectoryInfo infoDir; // información sobre el directorio
        infoDir = Directory.GetParent(fichDestino);
        // Ruta del directorio padre de fichDestino
        string dirPadre = infoDir.FullName;
        if (!Directory.Exists(dirPadre))
          throw new IOException("El directorio " + dirPadre +
                                " no existe");
        FileAttributes atributos = File.GetAttributes(dirPadre);
        if ((atributos & FileAttributes.ReadOnly) != 0)
          throw new IOException("No se puede escribir en el " +
                                "directorio " + dirPadre);
      }

      // Para realizar la copia, abrir un flujo de entrada desde
      // el fichero fuente y otro de salida hacia el destino.
      fFuente = new FileStream(fichFuente, FileMode.Open,
                               FileAccess.Read);
      fDestino = new FileStream(fichDestino, FileMode.Create,
                                FileAccess.Write);

      // Copiar el fichero fuente en el destino
      byte[] buffer = new byte[1024];
      int nbytes;
      while (true)
      {
        nbytes = fFuente.Read(buffer, 0, 1024);
        if (nbytes == 0) break; // se llegó al final del fichero
        fDestino.Write(buffer, 0, nbytes);
      }
    }
    catch(ArgumentException)
    {
      Console.WriteLine("El nombre del directorio o del fichero " +
                        "no es válido");
    }
    finally
    {
      // Cerrar los flujos que estén abiertos
      if (fFuente != null) fFuente.Close();
      if (fDestino != null) fDestino.Close();
    }    
  }
  
  public static void Main(string[] args)
  {
    // Main debe recibir dos parámetros: el fichero fuente y
    // el destino.
    if (args.Length != 2)
      Console.WriteLine("Sintaxis: CopiarFichero " +
                        "<fichero fuente> <fichero destino>");
    else
    {
      try
      {
        copiar(args[0], args[1]); // realizar la copia
      }
      catch(IOException e)
      {
        Console.WriteLine("Error: " + e.Message);
      }
    }
  }
}

