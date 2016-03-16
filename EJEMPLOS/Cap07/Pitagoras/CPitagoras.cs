using System;

public class CPitagoras
{
  // Teorema de Pitágoras
  public static void Main(string[] args)
  {
    int x = 1, y = 1, z = 0;
    Console.WriteLine("Z\t" + "X\t" + "Y");
    Console.WriteLine("____________________");
    while (x <= 50)
    {
      // Calcular z. Como z es un entero, almacena
      // la parte entera de la raíz cuadrada
      z = (int)Math.Sqrt(x * x + y * y);
      while (y <= 50 && z <= 50)
      {
        // Si la raíz cuadrada anterior fue exacta,
        // escribir z, x e y
        if (z * z == x * x + y * y)
        Console.WriteLine(z + "\t" + x + "\t" + y);
        y = y + 1;
        z = (int)Math.Sqrt(x * x + y * y);
      }
      x = x + 1; y = x;
    }
  }
}
