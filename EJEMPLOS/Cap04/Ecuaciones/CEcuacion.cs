class CEcuacion
{
  // El término de mayor grado tiene exponente 3 fijo

  private double c3, c2, c1, c0; // coeficientes

  public void Ecuación(double a, double b, double c, double d)
  {
    c3 = a; c2 = b; c1 = c; c0 = d;
  }
  
  public double ValorPara(double x)
  {
    double resultado;
    resultado = c3*x*x*x + c2*x*x + c1*x + c0;
    return resultado; // devolver el valor calculado
  }
}

