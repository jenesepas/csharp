using System;
using System.IO;
using MisClases.ES; // espacio de nombres de la clase Leer
//////////////////////////////////////////////////////////////////
// Aplicación para trabajar con un fichero accedido aleatoriamente
// Utiliza la clase Leer para leer de la entrada estándar cadenas
// y datos de tipos primitivos.
public class Test
{
  static CBaseDeDatos artículos;
  static bool ficheroAbierto = false;

  public static void nuevoFich()
  {
    if (ficheroAbierto)
    {
      Console.WriteLine("Ya hay un fichero abierto.");
      return;
    }
    Console.Write("Nombre del fichero: ");
    string strFichero = Console.ReadLine(); // nombre del fichero
    while (File.Exists(strFichero))
    {
      Console.WriteLine("Este fichero existe. Escriba otro.");
      strFichero = Console.ReadLine();
    }
    artículos = new CBaseDeDatos(strFichero);
    ficheroAbierto = true;
  }

  public static void abrirFich()
  {
    if (ficheroAbierto)
    {
      Console.WriteLine("Ya hay un fichero abierto.");
      return;
    }

    Console.Write("Nombre del fichero: ");
    string strFichero = Console.ReadLine(); // nombre del fichero

    string[] fichero = null;
    char resp;
    while (!File.Exists(strFichero))
    {
      Console.WriteLine("Este fichero no existe.");
      Console.Write("Desea ver la lista de ficheros? s/n: ");
      resp = (char)Console.Read();
      Console.ReadLine(); // limpiar el buffer de entrada
      if (resp == 'n') return;
      // Obtener un listado del directorio actual de trabajo
      fichero = Directory.GetFiles(Directory.GetCurrentDirectory());
      for (int i = 0; i < fichero.Length; i++)
        Console.Write(Path.GetFileName(fichero[i]) + ",  ");
      Console.Write("\n\nNombre del fichero: ");
      strFichero = Console.ReadLine();
    }
    artículos = new CBaseDeDatos(strFichero);
    ficheroAbierto = true;
  }

  public static void añadirReg()
  {
    string referencia;
    double precio;

    Console.Write("Referencia:    ");
    referencia = Console.ReadLine();
    Console.Write("Precio:        ");
    precio = Leer.datoDouble();
    artículos.añadir(new CRegistro(referencia, precio));
  }

  public static void modificarReg()
  {
    string referencia;
    double precio;
    int op, nreg;

    // Solicitar el número de registro a modificar
    Console.Write("Número de registro entre 0 y " +
                 (artículos.longitud() - 1) + ": ");
    nreg = Leer.datoInt();

    // Leer el registro
    CRegistro obj = artículos.valorEn(nreg);
    if (obj == null) return;
    // Visualizarlo
    Console.WriteLine(obj.obtenerReferencia());
    Console.WriteLine(obj.obtenerPrecio());

    // Modificar el registro
    do
    {
      Console.Write("\n\n");
      Console.WriteLine("Modificar el dato:");
      Console.WriteLine("1. Referencia");
      Console.WriteLine("2. Precio");
      Console.WriteLine("3. Salir y salvar los cambios");
      Console.WriteLine("4. Salir sin salvar los cambios");
      Console.WriteLine();
      Console.Write("   Opción: ");
      op = Leer.datoInt();

      switch( op )
      {
        case 1: // modificar referencia
          Console.Write("Referencia:    ");
          referencia = Console.ReadLine();
          obj.asignarReferencia(referencia);
          break;
        case 2: // modificar precio
          Console.Write("Precio:  ");
          precio = Leer.datoDouble();
          obj.asignarPrecio(precio);
          break;
        case 3: // guardar los cambios
          artículos.ponerValorEn(nreg, obj);
          return;
        case 4: // salir sin guardar los cambios
          break;
      }
    }
    while( op != 4);
  }

  public static bool eliminarReg()
  {
    string referencia;
    Console.Write("Referencia: ");
    referencia = Console.ReadLine();
    bool eliminado = artículos.eliminar(referencia);
    if (eliminado)
      Console.WriteLine("registro eliminado");
    else
      if (artículos.longitud() != 0)
        Console.WriteLine("referencia no encontrada");
      else
        Console.WriteLine("lista vacía");
    return eliminado;
  }

  public static void visualizarRegs()
  {
    int nreg = -1, nregs = artículos.longitud();
    if (nregs == 0)
      Console.WriteLine("lista vacía");
    Console.Write("conjunto de caracteres a buscar: ");
    string str = Console.ReadLine();
    CRegistro obj = null;
    do
    {
      nreg = artículos.buscar(str, nreg+1);
      if (nreg > -1)
      {
        obj = artículos.valorEn(nreg);
        Console.WriteLine("Registro: " + nreg);
        Console.WriteLine(obj.obtenerReferencia());
        Console.WriteLine(obj.obtenerPrecio());
        Console.WriteLine();
      }
    }
    while (nreg != -1);
    if (obj == null)
      Console.WriteLine("no se encontró ningún registro");
  }

  public static int menú()
  {
    Console.Write("\n\n");
    Console.WriteLine("1. Nuevo fichero");
    Console.WriteLine("2. Abrir fichero");
    Console.WriteLine("3. Añadir registro");
    Console.WriteLine("4. Modificar registro");
    Console.WriteLine("5. Eliminar registro");
    Console.WriteLine("6. Visualizar registros");
    Console.WriteLine("7. Salir");
    Console.WriteLine();
    Console.Write("   Opción: ");
    int op;
    do
    {
      op = Leer.datoInt();
      if (op < 1 || op > 7)
        Console.Write("Opción no válida. Elija otra: ");
    }
    while (op < 1 || op > 7);
    if (op > 2 && op < 7 && !ficheroAbierto)
    {
      Console.WriteLine("No hay un fichero abierto.");
      return 0;
    }
    return op;
  }

  public static void Main(string[] args)
  {
    int opción = 0;

    try
    {
      do
      {
        opción = menú();
        switch (opción)
        {
          case 1: // nuevo fichero
            nuevoFich();
            break;
          case 2: // abrir fichero
            abrirFich();
            break;
          case 3: // añadir registro al final del fichero
            añadirReg();
            break;
          case 4: // modificar registro
            modificarReg();
            break;
          case 5: // eliminar registro
            eliminarReg();
            break;
          case 6: // visualizar registros
            visualizarRegs();
            break;
          case 7: // salir
            if (artículos != null && artículos.tieneRegsEliminados())
              artículos.actualizar();
            artículos = null;
            break;
        }
      }
      while(opción != 7);
    }
    catch (IOException e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
  }
}
