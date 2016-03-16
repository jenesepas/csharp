// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CAjedrez
{
  // Imprimir un tablero de ajedrez.
  public static void Main(string[] args)
  {
    int falfil, calfil; // posición inicial del alfil
    int fila, columna;  // posición actual del alfil
    
    Console.WriteLine("Posición del alfil:");
    Console.Write("  fila    "); falfil = Leer.datoInt();
    Console.Write("  columna "); calfil = Leer.datoInt();
    Console.WriteLine(); // dejar una línea en blanco
    
    // Pintar el tablero de ajedrez
    for (fila = 1; fila <= 8; fila++)
    {
      for (columna = 1; columna <= 8; columna++)
      {
        if ((fila + columna == falfil + calfil) ||
           (fila - columna == falfil - calfil))
          Console.Write("* ");
        else if ((fila + columna) % 2 == 0)
          Console.Write("B ");
        else
          Console.Write("N ");
      }
      Console.WriteLine(); // cambiar de fila
    }
  }
}
