public class Test
{
  public static void Main(string[] args)
  {
    int nFilas = 3, nCarsPorFila = 60, car = 0, f, c;
    // Definir la matriz de caracteres
    char[,] m = new char[nFilas,nCarsPorFila];
    // Leer las cadenas de caracteres
    for (f = 0; f < nFilas; f++)
    {
      c = 0;
      // Leer una cadena
      while ((car = System.Console.Read()) != '\r' && c < nCarsPorFila)
      {
        m[f,c] = (char)car;
        c++; // posición del siguiente carácter
      }
      System.Console.ReadLine(); // Limpiar el buffer de entrada
    }
    // Escribir las cadenas de caracteres
    for (f = 0; f < nFilas; f++)
    {
      c = 0;
      // Escribir una cadena
      while (m[f,c] != '\0')
      {
        System.Console.Write(m[f,c]);
        c++;
      }
      System.Console.WriteLine(); // cambiar de línea
    }
  }
}

