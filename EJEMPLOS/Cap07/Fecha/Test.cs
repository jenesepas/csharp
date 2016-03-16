// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class Test
{
  public static void Main(string[] args)
  {
    int día, mes, año;
    Console.Write("Día: "); día = Leer.datoInt();
    Console.Write("Mes: "); mes = Leer.datoInt();
    Console.Write("Año: "); año = Leer.datoInt();

    CFecha fecha = new CFecha(día, mes, año);

    Console.WriteLine("Fecha: " + fecha.ObtenerDía() + "/" +
                                  fecha.ObtenerMes() + "/" +
                                  fecha.ObtenerAño()         );
  }
}

