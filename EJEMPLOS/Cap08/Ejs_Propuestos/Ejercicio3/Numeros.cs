using System;

public class Numeros
{
  // Atributos
  private int[] m;
  private int numElementos;
  
  // Métodos
  public Numeros(int n)
  {
    if ( n < 1 )
      n = 11;
    else if ( n % 2 == 0 )
      n++;

    numElementos = n;
    m = new int[numElementos];
  }
  
  public int Tamaño()
  {
    return numElementos;
  }

  public void AsignarValor(int n, int i)
  {
    if (i < 0 || i > numElementos-1)
    {
      Console.WriteLine("Índice fuera de límites");
      return;
    }
    m[i] = n;
  }

  public void Ordenar()
  {
    Array.Sort(m);
  }
  
  public int Mediana()
  {
    return m[(numElementos-1)/2];
  }
}
