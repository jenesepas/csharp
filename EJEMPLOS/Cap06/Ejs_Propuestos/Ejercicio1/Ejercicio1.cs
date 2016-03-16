// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES

using System;
using MisClases.ES;

public class Ejercicio1
{
  public static void Main(string[] args)
  {
    int radio;
    CEsfera obj = new CEsfera();        
    
    Console.Write("Introduce el radio: ");
    radio = Leer.datoInt();
    obj.setRadio(radio);
    Console.WriteLine("Volumen: " + obj.Volumen());
    Console.WriteLine("Radio: " + obj.getRadio());
  }
}
