/////////////////////////////////////////////////////////////////
// Aplicación para trabajar con números racionales
//
class Test
{
  public static void Main(string[] args)
  {
    CRacional r1 = new CRacional(1);
    CRacional r2 = new CRacional(1, 4);
    CRacional r3;
    r3 = r1.Sumar(r2);  	
    System.Console.WriteLine(r3.ToString());
    
    long n = 2;
    r3 = new CRacional(n).Sumar(r2);
    System.Console.WriteLine(r3.ToString());
    
    CRacional r4 = new CRacional(r2);
    r3.Copiar(r2);
    if (r3.Equals(r2)) r1 = r3.Sumar(r4);
    System.Console.WriteLine(r1.ToString());
    
    if (r3.EsCero())
      System.Console.WriteLine("racional cero");
    else
      System.Console.WriteLine(r3.ToString());
  }
}
