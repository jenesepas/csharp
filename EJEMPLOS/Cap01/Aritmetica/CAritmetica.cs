class CAritmetica
{
  /*
   * Operaciones aritméticas 
   */
  public static void Main(string[] args)
  {
    int dato1, dato2, resultado;

    dato1 = 20;
    dato2 = 10;
  
    // Suma
    resultado = dato1 + dato2;
  	System.Console.WriteLine("{0} + {1} = {2}", dato1, dato2, resultado);
  
    // Resta
    resultado = dato1 - dato2;
    System.Console.WriteLine("{0} - {1} = {2}", dato1, dato2, resultado);
  
    // Producto
    resultado = dato1 * dato2;
    System.Console.WriteLine("{0} * {1} = {2}", dato1, dato2, resultado);
  
    // Cociente
    resultado = dato1 / dato2;
    System.Console.WriteLine("{0} / {1} = {2}", dato1, dato2, resultado);
  }
}
