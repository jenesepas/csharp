using System;
using System.IO;
using MisClases.ES; // espacio de nombres de la clase Leer
//////////////////////////////////////////////////////////////////
// Aplicación para trabajar con un fichero accedido aleatoriamente
//
public class Test
{
  static CListaTfnos listatfnos;

  public static void imprimirListaTfnos()
  {
    // Crear un flujo hacia la impresora
    StreamWriter flujoS = new StreamWriter("LPT1");
  
    string ff = "\f";     // saltar a la siguiente página
    int nregs = listatfnos.númeroDeRegs(); // número de registros
    CPersona obj;

    for (int n = 0; n < nregs; n++)
    {
      // Saltar página inicialmente y después cada 60 líneas
      if (n % 60 == 0) flujoS.Write(ff);
      // Imprimir el registro n de la lista de teléfonos
      flujoS.WriteLine("Registro: " + n);
      obj = listatfnos.leerReg(n);
      flujoS.WriteLine(obj.obtenerNombre());
      flujoS.WriteLine(obj.obtenerDirección());
      flujoS.WriteLine(obj.obtenerTeléfono());
      flujoS.WriteLine(); // saltar una línea
    }
    flujoS.Write(ff); // saltar a la siguiente página
    flujoS.Close();   // cerrar el flujo hacia la impresora
  }
  
  public static bool modificar(int nreg)
  {
    string nombre, dirección;
    long teléfono;
    int op;
    // Leer el registro
    CPersona obj = listatfnos.leerReg(nreg);
    if (obj == null) return false;
    
    // Modificar el registro
    do
    {
      Console.Write("\n\n");
      Console.WriteLine("Modificar el dato:");
      Console.WriteLine("1. Nombre");
      Console.WriteLine("2. Dirección");
      Console.WriteLine("3. Teléfono");
      Console.WriteLine("4. Salir y salvar los cambios");
      Console.WriteLine("5. Salir sin salvar los cambios");
      Console.WriteLine();
      Console.Write("   Opción: ");
      op = Leer.datoInt();
          
      switch( op )
      {
        case 1: // modificar nombre
          Console.Write("nombre:    ");
          nombre = Console.ReadLine();
          obj.asignarNombre(nombre);
          break;
        case 2: // modificar dirección
          Console.Write("dirección: ");
          dirección = Console.ReadLine();
          obj.asignarDirección(dirección);
          break;
        case 3: // modificar teléfono
          Console.Write("teléfono:  ");
          teléfono = Leer.datoLong();
          obj.asignarTeléfono(teléfono);
          break;
        case 4: // guardar los cambios
          // Operación pospuesta a la salida del switch
          listatfnos.escribirReg(nreg, obj);             
          return true;
        case 5: // salir sin guardar los cambios
          break;
      }
    }
    while(op != 5);
    
    return false;    
  }
  
  public static void actualizar(string fActual) 
  {
    // Crear un fichero temporal
    string ficheroTemp = "listatfnos.tmp";
    CListaTfnos ftemp = new CListaTfnos(ficheroTemp);    
    int nregs = listatfnos.númeroDeRegs();
    // Copiar en el fichero temporal todos los registros del
    // fichero actual que en su campo teléfono no tengan un 0
    CPersona obj;
    for ( int reg_i = 0; reg_i < nregs; reg_i++ )
    {
      obj = listatfnos.leerReg(reg_i);
      if (obj.obtenerTeléfono() != 0)
        ftemp.añadirReg(obj);
    }
    listatfnos.cerrarFichero();
    ftemp.cerrarFichero();
    File.Copy(ficheroTemp, fActual, true);
    File.Delete(ficheroTemp);
  }  

  public static int menú()
  {
    Console.Write("\n\n");
    Console.WriteLine("1. Buscar");
    Console.WriteLine("2. Buscar siguiente");
    Console.WriteLine("3. Modificar");
    Console.WriteLine("4. Añadir");
    Console.WriteLine("5. Eliminar");
    Console.WriteLine("6. Imprimir");    
    Console.WriteLine("7. Salir");    
    Console.WriteLine();
    Console.Write("   Opción: ");
    int op;
    do
      op = Leer.datoInt();
    while (op < 1 || op > 7);
    Console.WriteLine();
    return op;
  }
  
  public static void Main(string[] args)
  {
    int opción = 0, pos = -1;
    string cadenabuscar = null;
    string nombre, dirección;
    long teléfono;
    bool eliminado = false;
    bool modificado = false;
    CPersona obj;
    
    try
    {
      // Crear un objeto lista de teléfonos vacío (con 0 elementos)
      // o con el contenido del fichero listatfnos.dat si existe.
      string fichero = "listatfnos.dat";
      listatfnos = new CListaTfnos(fichero);
      
      do
      {
        opción = menú();
        switch (opción)
        {
          case 1: // buscar
            Console.Write("conjunto de caracteres a buscar ");
            cadenabuscar = Console.ReadLine();
            pos = listatfnos.buscarReg(cadenabuscar, 0);
            if (pos == -1)
              if (listatfnos.númeroDeRegs() != 0)
                Console.WriteLine("búsqueda fallida");
              else
                Console.WriteLine("lista vacía");
            else
            {
              obj = listatfnos.leerReg(pos);
              Console.WriteLine("Número de registro: " + pos);
              Console.WriteLine(obj.obtenerNombre());
              Console.WriteLine(obj.obtenerDirección());
              Console.WriteLine(obj.obtenerTeléfono());
            }
            break;
          case 2: // buscar siguiente
            pos = listatfnos.buscarReg(cadenabuscar, pos + 1);
            if (pos == -1)
              if (listatfnos.númeroDeRegs() != 0)
                Console.WriteLine("búsqueda fallida");
              else
                Console.WriteLine("lista vacía");
            else
            {
              obj = listatfnos.leerReg(pos);
              Console.WriteLine("Número de registro: " + pos);
              Console.WriteLine(obj.obtenerNombre());
              Console.WriteLine(obj.obtenerDirección());
              Console.WriteLine(obj.obtenerTeléfono());
            }
            break;
          case 3: // modificar
            // Solicitar el número de registro a modificar  
            Console.Write("número de registro entre 0 y " + 
                          (listatfnos.númeroDeRegs() - 1) + ": ");
            pos = Leer.datoInt();
            modificado = modificar(pos);
            if (modificado)
              Console.WriteLine("modificación realizada con éxito");
            else
              Console.WriteLine("error: no se modificó el registro");
            break;
          case 4: // añadir
            Console.Write("nombre:    "); nombre = Console.ReadLine();
            Console.Write("dirección: "); dirección = Console.ReadLine();
            Console.Write("teléfono:  "); teléfono = Leer.datoLong();
            listatfnos.añadirReg(new CPersona(nombre, dirección, teléfono));
            break;
          case 5: // eliminar
            Console.Write("teléfono: "); teléfono = Leer.datoLong();
            eliminado = listatfnos.eliminarReg(teléfono);
            if (eliminado)
              Console.WriteLine("registro eliminado");
            else
              if (listatfnos.númeroDeRegs() != 0)
                Console.WriteLine("teléfono no encontrado");
              else
                Console.WriteLine("lista vacía");
            break;
          case 6: // imprimir
            imprimirListaTfnos();
            break;
          case 7: // salir
            // guardar lista
            if (listatfnos.tieneRegsEliminados())
              actualizar(fichero);
            listatfnos = null;
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
