class Test
{
  public static void Main(string[] args)
  {
    CCuentaAhorro cuenta01 = new CCuentaAhorro("Un nombre", "Una cuenta", 1000000, 3.5, 300);
    // Cobrar cuota de mantenimiento
    cuenta01.reintegro(cuenta01.obtenerCuotaManten());
    // Ingreso
    cuenta01.ingreso(1000000);
    // Reintegro
    cuenta01.reintegro(1800000);
    // ...
    
    System.Console.WriteLine(cuenta01.obtenerNombre());
    System.Console.WriteLine(cuenta01.obtenerCuenta());
    System.Console.WriteLine(cuenta01.estado());
    System.Console.WriteLine(cuenta01.obtenerTipoDeInterés());
  }
}

