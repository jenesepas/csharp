// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES

using System;
using MisClases.ES;

public class Ejercicio2
{
  public static void Main(string[] args)
  {
    String nombre;
    int año = 2030;
    int nacimiento;
    int edad;

    Console.Write("Introduzca el nombre: ");
    nombre = Console.ReadLine();

    Console.Write("Introduzca el año de nacimiento: ");
    nacimiento = Leer.datoInt();

    edad = año - nacimiento;
    Console.WriteLine("Hola " + nombre + " en el año 2030 tendrás " + edad + " años.");
  }
}
