// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES

using System;
using MisClases.ES;

public class Ejercicio4
{
  public static void Main(string[] args)
  {
    double  x, res;
    double a, b, c;
     
    Console.Write("Introduzca el valor de a: ");
    a = Leer.datoDouble();
    Console.Write("Introduzca el valor de b: ");
    b = Leer.datoDouble();
    Console.Write("Introduzca el valor de c: ");
    c = Leer.datoDouble();
    Console.Write("Introduzca el valor de x: ");
    x = Leer.datoDouble();

    CEcuacion ec1 = new CEcuacion(a, b, c);

    res = ec1.valorEcuacion(x);
    Console.WriteLine("Para x = " + x + ", ax^5 - bx^3 + cx - 7  =  " + res);
  }
}
