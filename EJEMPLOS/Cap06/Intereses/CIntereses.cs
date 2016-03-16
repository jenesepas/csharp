// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES

using System;
using MisClases.ES;

class CIntereses
{
  public static void Main(string[] args)
  {
    double c, intereses, capital;
    float r;
    int t;
    
    Console.Write("Capital invertido: ");
    c = Leer.datoDouble();
    Console.Write("\nA un % anual del: ");
    r = Leer.datoFloat();
    Console.Write("\nDurante cuántos días: ");
    t = Leer.datoInt();
    
    intereses = c * r * t / (360 * 100);
    capital = c + intereses;

    Console.WriteLine("Intereses producidos... " + intereses);
    Console.WriteLine("Capital acumulado...... " + capital);
  }
}
