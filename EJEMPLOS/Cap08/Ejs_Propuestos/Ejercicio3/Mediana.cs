// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class Mediana
{
  public static void IntroducirDatos(Numeros x)
  {
    int i = 0, n = 0, t = x.Tamaño();

    for (i = 0; i < t; i++)
    {
      Console.Write("Valor: ");
      n = Leer.datoInt();
      x.AsignarValor(n, i);
    }
  }

  public static void Main(string[] args)
  {
    int n;
 
    Console.WriteLine("¿Cuántos números quieres introducir?");
    Console.Write("Recuerda, debe ser un valor impar: ");
    n = Leer.datoInt();

    Numeros a = new Numeros(n);
    IntroducirDatos(a);
    a.Ordenar();
    Console.WriteLine("Mediana = " + a.Mediana());
  }
}
