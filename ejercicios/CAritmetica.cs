class CAritmetica
{
  /*
   * Operaciones aritméticas 
   */

    public static float sumar(float x, float y)
    {
        float resul = 0;

        resul = x + y;

        return resul;
    }


  public static void Main(string[] args)
  {
    int dato1, dato2, dato3;
    float resultado, resultado1;
    string cadena = "These are answers: ";

    dato1 = 20;
    dato2 = 10;
    dato3 = 30;

    System.Console.WriteLine(cadena);
    // Suma
    resultado1 = dato1 + dato2 + dato3;
    System.Console.WriteLine("{0} + {1} + {2} = {3}", dato1, dato2, dato3, resultado1);
  
    // Resta
    resultado = dato1 - dato2 - dato3;
    System.Console.WriteLine("{0} - {1} - {2} = {3}", dato1, dato2, dato3, resultado);
  
    // Producto
    resultado = dato1 * dato2 * dato3;
    0System.Console.WriteLine("{0} * {1} * {2} = {3}", dato1, dato2, dato3, resultado);
  
    // Cociente
    resultado = resultado1 / dato1 / dato2 / dato3;
    System.Console.WriteLine("{0} / {1} / {2} / {3} = {4}", resultado1, dato1, dato2, dato3, resultado);

    // Suma2
    resultado = sumar(dato1,dato3);
    System.Console.WriteLine("Suma de {0} + {1} = {2}", dato1, dato3, resultado);

    System.Console.WriteLine();
    System.Console.WriteLine("Inicializamos clase CCuenta:");
    System.Console.WriteLine();

    CCuenta cuenta01 = new CCuenta("Adán Martinez Tabuada", "3086 1100 00 1234432100",1202.98,2.89);
    CCuentaAhorro cuenta02 = new CCuentaAhorro("Anne Tabuada Mas", "3022 1100 22 1234432122", 202.98, 2.82,85.3);

    cuenta01.muestraCta();
    cuenta02.muestraCta();

    System.Console.WriteLine();
    System.Console.WriteLine("Modificamos clase CCuenta:");
    System.Console.WriteLine();
  
    cuenta01.asignarNombre("Pepito Perez Lopez");
    cuenta01.asignarCta("1086 1100 12 1234432109");
    cuenta01.asignarTipoDeInteres(2.5);
    
    cuenta01.ingreso(523.34);
    cuenta01.reintegro(1000);
    cuenta02.ingreso(823.34);
    cuenta02.reintegro(1000);

    cuenta01.muestraCta();
    cuenta02.muestraCta();

    System.Console.Read();
  }
}
