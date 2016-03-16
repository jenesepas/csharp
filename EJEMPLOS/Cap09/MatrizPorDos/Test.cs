public class Test
{
  public static void MultiplicarPorDosMatriz2D(double[,] x)
  {
    for (int f = 0; f < x.GetLength(0); f++)
    {
      for (int c = 0; c < x.GetLength(1); c++)
        x[f,c] *= 2;
    }
  }

  public static void Main(string[] args)
  {
    double[,] m = {{10, 20, 30}, {40, 50, 60}};
    
    MultiplicarPorDosMatriz2D(m);
    // Visualizar la matriz por filas
    for (int f = 0; f < m.GetLength(0); f++)
    {
      for (int c = 0; c < m.GetLength(1); c++)
        System.Console.Write(m[f,c] + " ");
      System.Console.WriteLine();
    }
  }
}

