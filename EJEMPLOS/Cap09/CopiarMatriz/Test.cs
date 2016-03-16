public class Test
{
  public static double[,] CopiarMatriz2D(double[,] x)
  {
    int filas = x.GetLength(0); // dimensión 0
    int cols =  x.GetLength(1); // dimensión 1
    double[,] z = new double[filas,cols];

    for (int f = 0; f < filas; f++)
      for (int c = 0; c < cols; c++)
        z[f,c] = x[f,c];
    return z;
  }

  public static void Main(string[] args)
  {
/*  
    double[,] m1 = {{10, 20, 30}, {40, 50, 60}};

    // Copiar una matriz utilizando un método
    double[,] m2 = CopiarMatriz2D(m1);
    m1[0,0] = 77; // modificar un elemento de la matriz original
    // Visualizar la matriz m2
    for (int f = 0; f < m2.GetLength(0); f++)
      for (int c = 0; c < m2.GetLength(1); c++)
        System.Console.Write(m2[f,c] + " ");
    System.Console.WriteLine();
    
    // Copiar una matriz utilizando el método clone
    double[,] m3 = (double[,])m1.Clone();
    m1[0,0] = 10; // modificar un elemento de la matriz original
    // Visualizar la matriz m3
    for (int f = 0; f < m3.GetLength(0); f++)
      for (int c = 0; c < m3.GetLength(1); c++)
        System.Console.Write(m3[f,c] + " ");
    System.Console.WriteLine();
*/
/*
    double[][] m1 = new double[2][];
    m1[0] = new double[3] {10, 20, 30};
    m1[1] = new double[3] {40, 50, 60};

    // Copiar una matriz utilizando el método clone
    double[][] m2 = (double[][])m1.Clone();
    for (int f = 0; f < m1.Length; f++)
      m2[f] = (double[])m1[f].Clone();
    m1[0][0] = 77; // modificar un elemento de la matriz original
    // Visualizar la matriz m3
    for (int f = 0; f < m1.Length; f++)
      for (int c = 0; c < m1[0].Length; c++)
        System.Console.Write(m2[f][c] + " ");
    System.Console.WriteLine();
*/
    double[,] m1 = {{10, 20, 30}, {40, 50, 60}};

    // Copiar una matriz utilizando el método Copy
    double[,] m2 = new double[m1.GetLength(0),m1.GetLength(1)];
    System.Array.Copy(m1, 0, m2, 0, m1.Length);
    m1[0,0] = 88; // modificar un elemento de la matriz original
    // Visualizar la matriz m3
    for (int f = 0; f < m2.GetLength(0); f++)
      for (int c = 0; c < m2.GetLength(1); c++)
        System.Console.Write(m2[f,c] + " ");
    System.Console.WriteLine();

  }
}

