using System;

public class CRandomCSharp
{
  // Obtener números aleatorios dentro de un rango
  public static void Main(string[] args)
  {
    int i, k, límiteSup = 49, límiteInf = 1;
    int[] n = new int[6];
    // Crear un objeto de la clase Random
    Random rnd = new Random();

    for (i = 0; i < n.Length; i++)
    {
      // Obtener un número aleatorio
      n[i] = (int)((límiteSup - límiteInf + 1) * rnd.NextDouble() +
                    límiteInf);
      // Verificar si ya existe el último número obtenido
      for (k = 0; k < i; k++)
        if (n[k] == n[i]) // ya existe
        {
          i--;   // i será incrementada por el for externo
          break; // salir de este for
        }
    }
    // Ordenar la matriz
    Array.Sort(n);
    // Mostrar la matriz
    for (i = 0; i < n.Length; i++)
      System.Console.Write(n[i] + " ");
    System.Console.WriteLine();
  }
}

