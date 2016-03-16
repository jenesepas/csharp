class CRelacion
{
  /*
   * Expresiones condicionales
   *
   */
  public static void Main(string[] args)
  {
    int num = 23;

    if ( num % 2 == 0 ) // si el resto de la división es igual a 0,
      System.Console.WriteLine("Número par");
    else             // si el resto de la división no es igual a 0,
      System.Console.WriteLine("Número impar");

    System.Console.WriteLine("Valor: " + num);
  }
}

