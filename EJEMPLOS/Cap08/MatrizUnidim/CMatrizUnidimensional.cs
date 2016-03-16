// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CMatrizUnidimensional
{
  // Creación de una matriz unidimensional
  public static void Main(string[] args)
  {
    int nElementos;
    Console.Write("Número de elementos de la matriz: ");
    nElementos = Leer.datoInt();
    int[] m = new int[nElementos]; // crear la matriz m
    int i = 0; // subíndice
    
    Console.WriteLine("Introducir los valores de la matriz.");
    for (i = 0; i < nElementos; i++)
    {
      Console.Write("m[" + i + "] = ");
      m[i] = Leer.datoInt();
    }
    
    // Visualizar los elementos de la matriz
    Console.WriteLine();
    for (i = 0; i < nElementos; i++)
      Console.Write(m[i] + " ");
    Console.WriteLine("\n\nFin del proceso.");
  }
}
