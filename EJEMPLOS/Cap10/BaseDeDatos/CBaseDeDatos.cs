/////////////////////////////////////////////////////////////////
// Definición de la clase CBaseDeDatos.
//
using System;
using System.IO;

public class CBaseDeDatos
{
  // Atributos
  private FileStream fs;         // flujo subyacente
  private BinaryWriter bw;       // flujo hacia el fichero
  private BinaryReader br;       // flujo desde el fichero
  private string ficheroActual;  // nombre del fichero
  private int nregs;             // número de registros
  private int tamañoReg = 50;    // tamaño del registro en bytes
  private bool borrar = false;   // true si se borran registros

  // Métodos
  public CBaseDeDatos(string fichero)
  {
    // ¿Se trata de un fichero?
    if (Directory.Exists(fichero))
      throw new IOException(Path.GetFileName(fichero) + " no es un fichero");

    // Asignar valores a los atributos
    fs = new FileStream(fichero, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    bw = new BinaryWriter(fs); // flujo hacia el fichero
    br = new BinaryReader(fs); // flujo desde el fichero
    ficheroActual = fichero;
    // Como es casi seguro que el último registro no ocupe el
    // tamaño fijado, utilizamos Ceiling para redondear por encima.
    nregs = (int)Math.Ceiling((double)fs.Length / (double)tamañoReg);
  }

  public void cerrar() { bw.Close(); br.Close(); fs.Close(); }

  public int longitud() { return nregs; } // número de registros

  public bool ponerValorEn( int i, CRegistro objeto )

  {
    if (i >= 0 && i <= nregs)
    {
      // Los 1 o 2 primeros bytes que escribe Write indican la
      // longitud de la cadena que escribe a continuación,
      // información utilizada por ReadString para recuperarla.
      if (objeto.tamaño() + 2 > tamañoReg)
        Console.WriteLine("tamaño del registro excedido");
      else
      {
        // Situar el puntero de L/E en el registro i.
        bw.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);
        // Sobreescribir el registro con la nueva información
        bw.Write(objeto.obtenerReferencia());
        bw.Write(objeto.obtenerPrecio());
        return true;
      }
    }
    else
      Console.WriteLine("número de registro fuera de límites");
    return false;
  }

  public void añadir(CRegistro obj)
  {
    // Añadir un registro al final del fichero e incrementar
    // el número de registros
    if (ponerValorEn( nregs, obj )) nregs++;
  }

  public CRegistro valorEn( int i )
  {
    if (i >= 0 && i < nregs)
    {
      // Situar el puntero de L/E en el registro i.
      br.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);

      string referencia;
      double precio;
      // Leer la información correspondiente al registro i.
      referencia = br.ReadString();
      precio = br.ReadDouble();

      // Devolver el objeto CRegistro correspondiente.
      return new CRegistro(referencia, precio);
    }
    else
    {
      Console.WriteLine("número de registro fuera de límites");
      return null;
    }
  }

  public int buscar(string str, int nreg)
  {
    // Buscar un registro por una subcadena de la referencia
    // a partir de un registro determinado. Si se encuentra,
    // se devuelve el número de registro, o -1 en otro caso.
    CRegistro obj;
    string refer;
    if (str == null) return -1;
    if (nreg < 0) nreg = 0;
    for ( int reg_i = nreg; reg_i < nregs; reg_i++ )
    {
      // Obtener el registro reg_i
      obj = valorEn(reg_i);
      // Obtener su referencia
      refer = obj.obtenerReferencia();
      // ¿str está contenida en referencia?
      if (refer.IndexOf(str) > -1)
        return reg_i; // devolver el número de registro
    }
    return -1; // la búsqueda falló
  }

  public bool eliminar(string refer)
  {
    CRegistro obj;
    // Buscar la referencia y marcar el registro correspondiente
    // para poder eliminarlo en otro proceso.
    for ( int reg_i = 0; reg_i < nregs; reg_i++ )
    {
      // Obtener el registro reg_i
      obj = valorEn(reg_i);
      // Tiene la referencia refer?
      if (refer.CompareTo(obj.obtenerReferencia()) == 0)
      {
        // Marcar el registro con la referencia "borrar"
        obj.asignarReferencia("borrar");
        borrar = true;
        // Grabarlo
        ponerValorEn( reg_i, obj );
        return true;
      }
    }
    return false;
  }

  public bool tieneRegsEliminados()
  {
    return borrar;
  }

  public void actualizar()
  {
    // Crear un fichero temporal.
    string ficheroTemp = "articulos.tmp";
    CBaseDeDatos ftemp = new CBaseDeDatos(ficheroTemp);

    // Copiar en el fichero temporal todos los registros del
    // fichero actual que no estén marcados para "borrar"
    CRegistro obj;
    for ( int reg_i = 0; reg_i < nregs; reg_i++ )
    {
      obj = valorEn(reg_i);
      if (obj.obtenerReferencia().CompareTo("borrar") != 0)
        ftemp.añadir(obj);
    }

    // Cerrar ambos ficheros, copiar el fichero temporal sobre
    // el actual y borrar el fichero temporal
    this.cerrar();          // cerrar el fichero actual
    ftemp.cerrar();         // cerrar el fichero temporal
    File.Copy(ficheroTemp, ficheroActual, true);
    File.Delete(ficheroTemp);
  }
}
