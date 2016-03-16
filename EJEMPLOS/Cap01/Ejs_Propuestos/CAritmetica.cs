class CAritmetica
{
  public static void Main(string[] args)
  {
    int dato1, dato2, dato3, resultado;
        
    dato1 = 10;
    dato2 = 20;
    dato3 = 30;
        
    // Suma
    resultado = dato1 + dato2 + dato3;
    System.Console.WriteLine("{0} + {1} + {2} = {3}", dato1, dato2, dato3, resultado);
        
    // Resta
    resultado = dato1 - dato2 - dato3;
  	System.Console.WriteLine("{0} - {1} - {2} = {3}", dato1, dato2, dato3, resultado);
        
    // Multiplicación
    resultado = dato1 * dato2 * dato3;
    System.Console.WriteLine("{0} * {1} * {2} = {3}", dato1, dato2, dato3, resultado);
      
    // División
    resultado = dato1 / dato2 / dato3;
    System.Console.WriteLine("{0} / {1} / {2} = {3}", dato1, dato2, dato3, resultado);
      
    // Varias Operaciones
    resultado = dato1 + dato1 * dato2 - dato3;
  	System.Console.WriteLine("{0} + {1} * {2} - {3} = {4}",
  	                         dato1, dato1, dato2, dato3, resultado);
  }
}
         
