// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES

using System;
using MisClases.ES;

class LeerDatos
{
  public static void Main(string[] args)
  {
    short dato_short = 0;
    int dato_int = 0;
    long dato_long = 0;
    float dato_float = 0;
    double dato_double = 0;

    Console.Write("Dato short: ");
    dato_short = Leer.datoShort();
    Console.Write("Dato int: ");
    dato_int = Leer.datoInt();
    Console.Write("Dato long: ");
    dato_long = Leer.datoLong();
    Console.Write("Dato float: ");
    dato_float = Leer.datoFloat();
    Console.Write("Dato double: ");
    dato_double = Leer.datoDouble();
    
    Console.WriteLine(dato_short);
    Console.WriteLine(dato_int);
    Console.WriteLine(dato_long);
    Console.WriteLine(dato_float);
    Console.WriteLine(dato_double);
  }
}
