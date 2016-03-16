using System;
using System.IO;

public class Ejercicio2
{
  public static void estadística(string fichero)
  {
    BinaryReader br = null; // flujo entrada de datos
                            //desde el fichero
    // Declarar contadores
    int ss = 0, ap = 0, nt = 0, sb = 0, total = 0;
    
    try
    {
      if (File.Exists(fichero))
      {
        // Si existe, abrir un flujo desde el mismo para leer
        br = new BinaryReader(new FileStream(
                      fichero, FileMode.Open, FileAccess.Read));
        
        // Declarar variables
        CRegistro reg = new CRegistro();
        string calificación;

        do
        {
          // Leer un nº de matrícula, un nombre y una calificación desde
          // el fichero. Cuando se alcance el final del fichero C#
          // lanzará una excepción del tipo EndOfStreamException.
          reg.asignarNumMat(br.ReadInt32());
          reg.asignarNombre(br.ReadString());
          reg.asignarCalificación(br.ReadString());
          
          // Contar SS, AP, NT y SB
          calificación = reg.obtenerCalificación();
          if (calificación.CompareTo("SS") == 0)
            ss++;
          else if (calificación.CompareTo("AP") == 0)
            ap++;
          else if (calificación.CompareTo("NT") == 0)
            nt++;
          else if (calificación.CompareTo("SB") == 0)
            sb++;
        }
        while (true);
      }
      else
        Console.WriteLine("El fichero no existe");
    }
    catch(EndOfStreamException)
    {
      Console.WriteLine("Fin del fichero");
      total = ss + ap + nt + sb;
      Console.WriteLine("Suspensos:      " + (100F*ss/total) + "%");
      Console.WriteLine("Aprobados:      " + (100F*ap/total) + "%");
      Console.WriteLine("Notables:       " + (100F*nt/total) + "%");
      Console.WriteLine("Sobresalientes: " + (100F*sb/total) + "%");
    }
    finally
    {
      // Cerrar el flujo
      if (br != null) br.Close();
    }
  }
  
  public static void Main(string[] args)
  {
    if (args.Length != 1)
      Console.WriteLine("Sintaxis: Ejercicio2 " +
                        "<fichero fuente>");
    else
    {
      try
      {
        estadística(args[0]);
      }
      catch(IOException e)
      {
        Console.WriteLine("Error: " + e.Message);
      }
    }
  }
}
