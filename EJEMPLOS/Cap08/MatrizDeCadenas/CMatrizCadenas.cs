// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CMatrizCadenas
{
  public static void Main(string[] args)
  {
    int nFilas = 0, fila = 0;
    do
    {
      Console.Write("Número de filas de la matriz:  ");
      nFilas = Leer.datoInt();
    }
    while (nFilas < 1);       // no permitir un valor negativo

    // Matriz de cadenas de caracteres
    string[] nombre = new String[nFilas];

    Console.WriteLine("Escriba los nombres que desea introducir.");
    Console.WriteLine("Puede finalizar pulsando las teclas [Ctrl][Z].");
    for (fila = 0; fila < nFilas; fila++)
    {
      Console.Write("Nombre[" + fila + "]: ");
      nombre[fila] = Console.ReadLine();
      // Si se pulsó [Ctrl][Z], salir del bucle
      if (nombre[fila] == null) break;
    }
    Console.WriteLine();
    nFilas = fila; // número de filas leídas
    char respuesta;
    do
    {
      Console.Write("¿Desea visualizar el contenido de la matriz? (s/n): ");
      respuesta = ((Console.ReadLine()).ToLower())[0];
    }
    while (respuesta != 's' && respuesta != 'n');
    if ( respuesta == 's' )
    {
      // Visualizar la lista de nombres
      Console.WriteLine();
      for (fila = 0; fila < nFilas; fila++)
        Console.WriteLine(nombre[fila]);
    }
  }
}

