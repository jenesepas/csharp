public class Ejercicio3
{
  public static void Main(string[] args)
  {
    CEcuacion ec1 = new CEcuacion(5, -1.7, 2);
    
    double r = ec1.ValorPara(10.5);
    System.Console.WriteLine("El resultado es " + r);
  }
}

class CEcuacion
{
  private double c2, c1, c0;

  public CEcuacion(double a, double b, double c)
  {
    c2 = a;
    c1 = b;
    c0 = c;
  }
  
  public double ValorPara(double x)
  {
    double solucion;

    solucion  =  c2*x*x*x + c1*x*x - c0*x + 3;
    return solucion;
  }
}   
