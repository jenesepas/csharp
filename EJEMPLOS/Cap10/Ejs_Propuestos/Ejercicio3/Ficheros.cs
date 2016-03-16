using System;
using System.IO;

public class Ficheros
{
  private class CRegistro
  {
    public string nombre;
    public float nota;
  }

  // Flujos
  private BinaryReader br1 = null;  // entrada de datos desde el fichero1
  private string fichero1 = null;   // nombre del fichero1
  private BinaryReader br2 = null;  // entrada de datos desde el fichero2
  private string fichero2 = null;   // nombre del fichero2
  private BinaryWriter bw = null;   // salida de datos hacia el fichero final
  private string fichero = null;    // nombre del fichero final

  public void abrir(string nomFichero1, string nomFichero2)
  {
    fichero1 = nomFichero1;
    fichero2 = nomFichero2;
    
    // Verificar si el fichero existe
    if (File.Exists(fichero1))
    {
      // Si existe, abrir un flujo desde el mismo para leer
      br1 = new BinaryReader(new FileStream(
                    fichero1, FileMode.Open, FileAccess.Read));
    }
    else
    {
      Console.WriteLine("El fichero " + fichero1 + " no existe");
      return;
    }

    // Verificar si el fichero existe
    if (File.Exists(fichero2))
    {
      // Si existe, abrir un flujo desde el mismo para leer
      br2 = new BinaryReader(new FileStream(
                    fichero2, FileMode.Open, FileAccess.Read));
    }
    else
    {
      Console.WriteLine("El fichero " + fichero2 + " no existe");
      return;
    }

    // Fichero final
    fichero = "temporal";

    // Abrir un flujo hacia el mismo
    bw = new BinaryWriter(new FileStream(
                  fichero, FileMode.Create, FileAccess.Write));
  }

  public void fusionar()
  {
    // Variable para leer desde el fichero1
    CRegistro regF1 = new CRegistro();
    bool finFichero1 = false;

    // Variable para leer desde el fichero2
    CRegistro regF2 = new CRegistro();
    bool finFichero2 = false;

    int i; // resultado de una comparación

    try
    {
      // Leer un un nombre y una nota desde el fichero1.
      // Cuando se alcance el final del fichero C#
      // lanzará una excepción del tipo EndOfStreamException.
      regF1.nombre = br1.ReadString();
      regF1.nota = br1.ReadSingle();

      // Leer un un nombre y una nota desde el fichero2.
      // Cuando se alcance el final del fichero C#
      // lanzará una excepción del tipo EndOfStreamException.
      regF2.nombre = br2.ReadString();
      regF2.nota = br2.ReadSingle();

      while (true)
      {
        if (finFichero1 && finFichero2) break;

        i = regF1.nombre.CompareTo(regF2.nombre);

        // Forzar el resultado de la comparación a un valor
        // determinado si alguno de los dos ficheros finalizó, 
        // para que lea y grabe del que aún no finalizó.
        if (finFichero1)
          i = 1;
        else if (finFichero2)
          i = -1;

        if (i == 0) // regF1.nombre == regF2.nombre
        {
          // El mismo alumno. Grabar regF2
          bw.Write(regF2.nombre);
          bw.Write(regF2.nota);

          // Leer de nuevo de ambos ficheros
          try
          {
            regF1.nombre = br1.ReadString();
            regF1.nota = br1.ReadSingle();
          }
          catch(EndOfStreamException)
          {
            Console.WriteLine("Fin del fichero1");
            finFichero1 = true;
          }

          try
          {
            regF2.nombre = br2.ReadString();
            regF2.nota = br2.ReadSingle();
          }
          catch(EndOfStreamException)
          {
            Console.WriteLine("Fin del fichero2");
            finFichero2 = true;
          }
          continue;
        }
        else if (i > 0) // regF1.nombre > regF2.nombre
        {
          // Grabar regF2
          bw.Write(regF2.nombre);
          bw.Write(regF2.nota);

          // Leer de nuevo de fichero2
          try
          {
            regF2.nombre = br2.ReadString();
            regF2.nota = br2.ReadSingle();
          }
          catch(EndOfStreamException)
          {
            Console.WriteLine("Fin del fichero2");
            finFichero2 = true;
          }
          continue;
        }
        else // regF2.nombre > regF1.nombre
        {
          // Grabar regF1
          bw.Write(regF1.nombre);
          bw.Write(regF1.nota);

          // Leer de nuevo de fichero1
          try
          {
            regF1.nombre = br1.ReadString();
            regF1.nota = br1.ReadSingle();
          }
          catch(EndOfStreamException)
          {
            Console.WriteLine("Fin del fichero1");
            finFichero1 = true;
          }
        }
      }

    }
    catch(EndOfStreamException)
    {
      Console.WriteLine("Fin del fichero1 y fichero2");
    }
    finally
    {
      // Cerrar flujos
      if (br1 != null) br1.Close();
      if (br2 != null) br2.Close();
      if (bw != null) bw.Close();
      // Copiar en el fichero alumnos todos los registros del temporal
      // excepto los que en el campo nota tengan -1.
      copiar("alumnos", "temporal");
    }
  }

  public void copiar(string fichero1, string fichero2)
  {
    // Copiar fichero2 en fichero1

    // Verificar si el fichero existe
    if (File.Exists(fichero2))
    {
      // Si existe, abrir un flujo desde el mismo para leer
      br2 = new BinaryReader(new FileStream(
                    fichero2, FileMode.Open, FileAccess.Read));
    }
    else
    {
      Console.WriteLine("El fichero " + fichero2 + " no existe");
      return;
    }

    // Abrir un flujo hacia el fichero1
    bw = new BinaryWriter(new FileStream(
                  fichero1, FileMode.Create, FileAccess.Write));

    // Variable para leer desde el fichero2
    CRegistro regF2 = new CRegistro();

    try
    {
      while (true)
      {
        // Leer del fichero2
        regF2.nombre = br2.ReadString();
        regF2.nota = br2.ReadSingle();

        // Escribir en el fichero1
        if (regF2.nota != -1)
        {
          bw.Write(regF2.nombre);
          bw.Write(regF2.nota);
        }
      }
    }
    catch(EndOfStreamException)
    {
      Console.WriteLine("Fin de la copia");
    }
    finally
    {
      // Cerrar flujos
      if (br2 != null) br2.Close();
      if (bw != null) bw.Close();
      // Borrar el fichero temporal
      File.Delete(fichero2);
    }
  }
}
