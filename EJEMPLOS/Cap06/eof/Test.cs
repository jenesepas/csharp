using System;

class Test
{
  public static void Main(string[] args)
  {
    string sdato;
    float precio = 0.0F;
    
      Console.Write("Precio: ");
      sdato = Console.ReadLine();
      precio = (sdato != null)
               ? float.Parse(sdato)
               : float.NaN;

    Console.WriteLine(precio);
    Console.WriteLine("Continúa el programa");
  }
}
