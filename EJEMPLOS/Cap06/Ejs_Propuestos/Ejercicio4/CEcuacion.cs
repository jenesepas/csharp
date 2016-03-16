using System;

public class CEcuacion
{
  private double a, b, c;

  public CEcuacion() {}
  public CEcuacion(double p1, double p2, double p3)
  {
    establecerCoeficientes(p1, p2, p3);
  }

  public void establecerCoeficientes(double p1, double p2, double p3)
  {
    a = p1;
    b = p2;
    c = p3;
  }

  public double valorEcuacion(double x)
  {
    return (a * Math.Pow(x, 5) - b * Math.Pow(x, 3) + c * x - 7);
  }
}
