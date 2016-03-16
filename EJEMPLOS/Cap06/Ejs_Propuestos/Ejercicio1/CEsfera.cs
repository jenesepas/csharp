using System;

class CEsfera
{
  // Atributos
  private double rad = 0;
  
  // Constructores
  public CEsfera() {}
  public CEsfera(int r)
  {
    rad = r;
  }

  // Métodos
  public void setRadio(double r)
  {
    rad = r;
  }

  public double getRadio()
  {
    return rad;
  }

  public double Volumen()
  {
    return (double)(4.0 / 3.0) * Math.PI * rad * rad * rad;
  }
}
