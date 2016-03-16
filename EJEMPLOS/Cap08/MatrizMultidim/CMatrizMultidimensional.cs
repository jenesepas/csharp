// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CMatrizMultidimensional
{
  // Creación de una matriz multidimensional.
  // Suma de las filas de una matriz de dos dimensiones.
  public static void Main(string[] args)
  {
    int nfilas, ncols;     // filas y columnas de la matriz
    
    do
    {
      Console.Write("Número de filas de la matriz:    ");
      nfilas = Leer.datoInt();
    }
    while (nfilas < 1);    // no permitir un valor negativo
    
    do
    {
      Console.Write("Número de columnas de la matriz: ");
      ncols = Leer.datoInt();
    }
    while (ncols < 1);     // no permitir un valor negativo
    
    float[,] m = new float[nfilas,ncols]; // crear la matriz m
    int fila = 0, col = 0; // subíndices
    float sumafila = 0;    // suma de los elementos de una fila
    
    Console.WriteLine("Introducir los valores de la matriz.");
    for (fila = 0; fila < nfilas; fila++)
    {
      for (col = 0; col < ncols; col++)
      {
        Console.Write("m[" + fila + "," + col + "] = ");
        m[fila,col] = Leer.datoFloat();
      }
    }
    
    // Visualizar la suma de cada fila de la matriz
    Console.WriteLine();
    for (fila = 0; fila < nfilas; fila++)
    {
      sumafila = 0;
      for (col = 0; col < ncols; col++)
        sumafila += m[fila,col];
      Console.WriteLine("Suma de la fila " + fila + ": " + sumafila);
    }
    Console.WriteLine("\nFin del proceso.");
  }
}
