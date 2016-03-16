/////////////////////////////////////////////////////////////////
// Definición de la clase CListaTfnos.
//
using System;
using System.IO;
public class CListaTfnos
{
  private FileStream fs;          // flujo subyacente
  private BinaryWriter bw;        // flujo hacia el fichero
  private BinaryReader br;        // flujo desde el fichero
  private int nregs;              // número de registros
  private int tamañoReg = 140;    // tamaño del registro en bytes
  private bool regsEliminados = false; // true si se
                                  // eliminaron registros

  public CListaTfnos(string fichero)
  {
    if (Directory.Exists(fichero))
      throw new IOException(Path.GetFileName(fichero) + " no es un fichero");
    fs = new FileStream(fichero, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    bw = new BinaryWriter(fs);
    br = new BinaryReader(fs);
    
    // Como es casi seguro que el último registro no ocupe el
    // tamaño fijado, utilizamos Ceiling para redondear por encima.
    nregs = (int)Math.Ceiling((double)fs.Length / (double)tamañoReg);
  }
  
  public void cerrarFichero() { bw.Close(); br.Close(); fs.Close(); }
  
  public int númeroDeRegs() { return nregs; } // número de registros
  
  public bool escribirReg( int i, CPersona obj )
  {
    if (i >= 0 && i <= nregs)
    {
      if (obj.tamaño() + 4 > tamañoReg)
        Console.WriteLine("tamaño del registro excedido");
      else
      {
        // Situar el puntero de L/E
        bw.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);
        bw.Write(obj.obtenerNombre());
        bw.Write(obj.obtenerDirección());
        bw.Write(obj.obtenerTeléfono());
        return true;
      }
    }
    else
      Console.WriteLine("número de registro fuera de límites");
    return false;
  }
  
  public void añadirReg(CPersona obj)
  {
    if (escribirReg( nregs, obj )) nregs++;
  }

  public CPersona leerReg( int i )
  {
    if (i >= 0 && i < nregs)
    {
      // Situar el puntero de L/E
      br.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);
      
      string nombre, dirección;
      long teléfono;
      nombre = br.ReadString();
      dirección = br.ReadString();
      teléfono = br.ReadInt64();
      
      return new CPersona(nombre, dirección, teléfono);
    }
    else
    {
      Console.WriteLine("número de registro fuera de límites");
      return null;
    }
  }
  
  public bool eliminarReg(long tel)
  {
    CPersona obj;
    // Buscar el teléfono y marcar el registro para
    // posteriormente eliminarlo
    for ( int reg_i = 0; reg_i < nregs; reg_i++ )
    {
      obj = leerReg(reg_i);
      if (obj.obtenerTeléfono() == tel)
      {
        obj.asignarTeléfono(0);
        escribirReg( reg_i, obj );
        regsEliminados = true;
        return true;
      }
    }
    return false;
  }
  
  public bool tieneRegsEliminados()
  {
    return regsEliminados;
  }
  
  public int buscarReg(string str, int pos)
  {
    // Buscar un registro por una subcadena del nombre
    // a partir de un registro determinado
    CPersona obj;
    string nom;
    if (str == null) return -1;
    if (pos < 0) pos = 0;
    for ( int reg_i = pos; reg_i < nregs; reg_i++ )
    {
      obj = leerReg(reg_i);
      nom = obj.obtenerNombre();
      // str está contenida en nom?
      if (nom.IndexOf(str) > -1)
        return reg_i;
    }
    return -1;
  }
}
