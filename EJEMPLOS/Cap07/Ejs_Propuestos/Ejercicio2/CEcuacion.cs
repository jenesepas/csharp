public class CEcuacion // 1/(x + a*y)
{
  private double a;

  public CEcuacion() {}
  public CEcuacion(double p1)
  {
    establecerCoeficientes(p1);
  }

  public void establecerCoeficientes(double p1)
  {
    a = p1;
  }

  public double valorEcuacion(double x, double y)
  {
    return 1/(x + a*y);
  }
}
