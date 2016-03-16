using System;
using System.Text;

public class CCadenas
{
  // Convertir una cadena a mayúsculas
  static void MinusculasMayusculas(StringBuilder str)
  {
    int i = 0, desp = 'a' - 'A';
    char car = '\0';
    for (i = 0; i < str.Length; i++)
    {
      car = str[i];
      if (car >= 'a' && car <= 'z')
        str[i] = (char)(car - desp);
    }
  }

  public static void Main(string[] args)
  {
    string scadena = null;
    StringBuilder bcadena = null;

    Console.Write("Introduzca un texto: ");
    scadena = Console.ReadLine(); // leer una línea de texto
    // Construir un objeto StringBuilder a partir de la cadena
    bcadena = new StringBuilder(scadena);

    // Convertir minúsculas a mayúsculas
    MinusculasMayusculas(bcadena); // llamar al método
    System.Console.WriteLine(bcadena);   // escribir el resultado
  }
}

