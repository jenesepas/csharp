public class Test
{
  public static void Main(string[] args)
  {
    int nFilas = 3, nCarsPorFila = 60, car = 0, f, c, k;
    
    // Declarar una matriz de matrices
    char[][] m = new char[nFilas][];
    // Una cadena
    char[] cadena = new char[nCarsPorFila];

    // Leer las cadenas de caracteres
    for (f = 0; f < nFilas; f++)
    {
      c = 0;
      // Leer una cadena
      while ((car = System.Console.Read()) != '\r' && c < nCarsPorFila)
      {
        cadena[c] = (char)car;
        c++; // posición del siguiente carácter = caracteres leídos
      }
      System.Console.ReadLine(); // Limpiar el buffer de entrada
      
      // Añadir una submatriz de longitud c a m
      m[f] = new char[c];
      // Copiar la cadena leída en m[f]
      for (k = 0; k < c; k++)
        m[f][k] = cadena[k];
    }

    // Escribir las cadenas de caracteres
    for (f = 0; f < nFilas; f++)
      System.Console.WriteLine(m[f]);
  }
}

