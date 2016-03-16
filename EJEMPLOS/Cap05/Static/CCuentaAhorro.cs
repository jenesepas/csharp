class CCuentaAhorro : CCuenta
{
  // Atributos
  private static double cuotaMantenimiento;
  
  // Métodos
  public CCuentaAhorro() {} // constructor sin parámetros
  
  public CCuentaAhorro(string nom, string cue, double sal,
                       double tipo, double mant) :
                       base(nom, cue, sal, tipo) // invoca al constructor CCuenta,
                                                 // esto es, al de la clase base
  {
    asignarCuotaManten(mant);   // inicia cuotaMantenimiento
  }

  public static void asignarCuotaManten(double cantidad)
  {
    if (cantidad < 0)
    {
      System.Console.WriteLine("Error: cantidad negativa");
      return;
    }
    cuotaMantenimiento = cantidad;
  }
  
  public static double obtenerCuotaManten()
  {
    return cuotaMantenimiento;
  }

  public void reintegro(double cantidad)
  {
    double saldo = estado();
    double tipoDeInterés = obtenerTipoDeInterés();

    if ( tipoDeInterés >= 3.5)
    {
      if (saldo - cantidad < 250000)
      {
        System.Console.WriteLine("Error: no dispone de esa cantidad");
        return;
      }
    }
    base.reintegro(cantidad);
  }
}

