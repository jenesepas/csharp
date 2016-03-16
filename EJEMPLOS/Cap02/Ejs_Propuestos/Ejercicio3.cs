public class Ejercicio3
{
  public static double calcular(double a, double b, double c)
  {
    double resultado = 0;

    resultado = ((b * b) - (4 * a * c)) / (2 * a);
    return resultado;
  }

  public static void Main(string[] args)
  {
    double a = 1, b = 5, c = 2;
    double resultado = 0;

    resultado = calcular(a, b, c);

    System.Console.WriteLine("El resultado es " + resultado);
  }
}
