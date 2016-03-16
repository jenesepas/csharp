class CAritmetica
{
  /*
   * Método sumar:
   *   parámetros x e y de tipo double
   *   devuelve x + y
   */

  public static double sumar(double x, double y)
  {
    double resultado = 0;
    resultado = x + y;
    return resultado;
  }
  
  public static void Main(string[] args)
  {
    double a = 10, b = 20, r = 0;
    r = sumar(a, b);
    System.Console.WriteLine("Suma = " + r);
  }
}
