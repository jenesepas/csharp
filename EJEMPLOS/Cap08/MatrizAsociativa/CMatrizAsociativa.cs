// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CMatrizAsociativa
{
  // Frecuencia con la que aparecen las letras en un texto.
  public static void Main(string[] args)
  {
    // Crear la matriz c con 'z'-'a'+1 elementos.
    // C# inicia los elementos de la matriz a cero.
    int[] c = new int['z'-'a'+1];
    int car; // subíndice
    
    // Entrada de datos y cálculo de la tabla de frecuencias
    Console.WriteLine("Introducir un texto.");
    Console.WriteLine("Para finalizar pulsar [Ctrl][z]\n");

    // Leer el siguiente carácter del texto y contabilizarlo
    while ((car = Console.Read()) != -1)
    {
      // Si el carácter leído está entre la 'a' y la 'z'
      // incrementar el contador correspondiente
      if (car >= 'a' && car <= 'z')
        c[car - 'a']++;
    }

    // Mostrar la tabla de frecuencias
    Console.WriteLine("\n");
    // Visualizar una cabecera "a b c ... "
    for (car = 'a'; car <= 'z'; car++)
      Console.Write(" " + (char)car);
    Console.WriteLine("\n ------------------------------------" +
    "----------------------------------------");
    // Visualizar la frecuencia con la que han aparecido los caracteres
    for (car = 'a'; car <= 'z'; car++)
      Console.Write(" " + c[car - 'a']);
    Console.WriteLine();
  }
}

