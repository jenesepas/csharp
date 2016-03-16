using System;

public class CValorUnicode
{
  // Examinar una cadena de caracteres almacenada en un string
  public static void Main(string[] args)
  {
    string cadena = null; // referencia a una cadena de caracteres

    Console.Write("Introduzca un texto: ");
    cadena = Console.ReadLine(); // leer una línea de texto

    // Examinar la cadena de caracteres
    int i = 0;
    do
    {
      Console.WriteLine("Carácter = " + cadena[i] + 
                        ", código Unicode = " + (int)cadena[i]);
      i++;
    }
    while (i < cadena.Length);
  }
}
