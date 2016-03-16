// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

class Pesos
{
  private int num = 91;
  private int[] lista;

  public void CrearObj(int numero)
  {
    int peso;
    lista = new int[num];

    for (int i = 0; i < numero; i++)
    {
      System.Console.Write("Peso del alumno "+ (i+1) +": ");
      peso = Leer.datoInt();
      while ((peso < 10) || (peso > 100))
      {
        System.Console.Write("Peso incorrecto, (debe estar entre 10-100): ");
        peso = Leer.datoInt();
      }
      lista[peso-10]++;
    }
  }

  public void Mostrar()
  {
    int j, contador;
    System.Console.WriteLine("Peso       Número de Alumnos");
    System.Console.WriteLine("----------------------------");

    for (j = 0; j < num; j++)
    {
      if (lista[j] > 0)
      {
        System.Console.Write("  " + (j + 10) + "        ");
        for(contador = 0; contador < lista[j]; contador++)
          System.Console.Write("*");
        System.Console.WriteLine();
      }
    }
  }
}

public class CPesos
{
  public static void Main(string[] args)
  {
    int numAlumnos;
    Pesos p = new Pesos();      
    System.Console.Write("Introduce el número de alumnos: ");
    numAlumnos = Leer.datoInt();
    p.CrearObj(numAlumnos);
    p.Mostrar();
  }
}

