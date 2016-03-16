class Test
{
  public static void Main(string[] args)
  {
    CCuenta cuenta01 = new CCuenta();    
    CCuenta cuenta02 = new CCuenta("Un nombre", "Una cuenta", 1000000, 3.5);

    cuenta01.asignarNombre("Un nombre");
    cuenta01.asignarCuenta("Una cuenta");
    cuenta01.asignarTipoDeInterés(2.5);
    
    cuenta01.ingreso(1000000);
    cuenta01.reintegro(500000);
    
    System.Console.WriteLine(cuenta01.obtenerNombre());
    System.Console.WriteLine(cuenta01.obtenerCuenta());
    System.Console.WriteLine(cuenta01.estado());
    System.Console.WriteLine(cuenta01.obtenerTipoDeInterés());
    System.Console.WriteLine();
    System.Console.WriteLine(cuenta02.obtenerNombre());
    System.Console.WriteLine(cuenta02.obtenerCuenta());
    System.Console.WriteLine(cuenta02.estado());
    System.Console.WriteLine(cuenta02.obtenerTipoDeInterés());    
  }
}
