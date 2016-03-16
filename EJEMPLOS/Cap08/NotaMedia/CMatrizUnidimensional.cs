// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES

using System;
using MisClases.ES;

public class CMatrizUnidimensional
{
  // Trabajar con una matriz unidimensional
  public static void Main(string[] args)
  {
    int nAlumnos;    // número de alumnos (valor no negativo)
    do
    {
      Console.Write("Número de alumnos: ");
      nAlumnos = Leer.datoInt();
    }
    while (nAlumnos < 1);

    float[] nota = new float[nAlumnos]; // crear la matriz nota
    int i = 0;       // subíndice
    float suma = 0F; // suma total de las notas medias
    
    Console.WriteLine("Introducir las notas medias del curso.");
    for (i = 0; i < nota.Length; i++)
    {
      Console.Write("Nota media del alumno " + (i+1) + ": ");
      nota[i] = Leer.datoFloat();
    }

    // Sumar las notas medias
    for (i = 0; i < nota.Length; i++)
      suma += nota[i];

    // Visualizar la nota media del curso
    Console.WriteLine("\n\nNota media del curso: " + suma / nAlumnos);
  }
}

