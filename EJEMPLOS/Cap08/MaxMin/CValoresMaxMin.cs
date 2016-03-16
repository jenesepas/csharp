// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CValoresMaxMin
{
  // Obtener el máximo y el mínimo de un conjunto de valores
  public static void Main(string[] args)
  {
    int nElementos;    // número de elementos (valor no negativo)

    do
    {
      Console.Write("Número de valores que desea introducir: ");
      nElementos = Leer.datoInt();
    }
    while (nElementos < 1);

    float[] dato = new float[nElementos]; // crear la matriz dato
    int i = 0;       // subíndice
    float max, min;  // valor máximo y valor mínimo
    
    Console.WriteLine("Introducir los valores.\n" +
                      "Para finalizar pulse [Entrar]");
    for (i = 0; i < dato.Length; i++)
    {
      Console.Write("dato[" + i + "]= ");
      dato[i] = Leer.datoFloat();
      if (float.IsNaN(dato[i])) break;
    }
    nElementos = i; // número de valores leídos

    // Obtener los valores máximo y mínimo
    if (nElementos > 0)
    {
      max = min = dato[0];
      for (i = 0; i < nElementos; i++)
      {
        if (dato[i] > max)
          max = dato[i];
        if (dato[i] < min)
          min = dato[i];
      }
      // Escribir los resultados 
      Console.WriteLine("\nValor máximo: " + max);
      Console.WriteLine("Valor mínimo: " + min);
    }
    else
      Console.WriteLine("\nNo hay datos.");
  }
}

