using System;

public class CUnicode
{
  // Código Unicode de cada uno de los caracteres de un texto
  public static void Main(string[] args)
  {
    int car = 0; // car = carácter nulo (\0)

    Console.WriteLine("Introduzca texto.");
    Console.WriteLine("Para terminar pulse Ctrl+z\n");
    while ((car = Console.Read()) > -1)
    {
      if (car != '\r' && car != '\n')
        Console.WriteLine("El código Unicode de " + (char)car + 
                          " es " + car);
    }
  }
}
