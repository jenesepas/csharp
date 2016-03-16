using System;
using MisClases.ES;
 
public class Ejercicio4
{  
  public static long factorial(int n)  
  {
    if (n == 0) return 1;
    return n * factorial(n-1);
  }
    
  public static long combinaciones(int n, int k)  
  {
    long n_sobre_k = 0L;
    n_sobre_k = factorial(n) / (factorial(k) * factorial(n-k));
    return n_sobre_k;
  }
    
  public static long potencia(int b, int e)  
  {
    return (long)Math.Pow(b, e);
  }  

  public static void Main(string[] arg)
  {
    int a = 0, b = 0,x = 0,y = 0, n = 0;
    long res = 0L;
         
    Console.Write("a = ");
    a = Leer.datoInt();
    Console.Write("x = ");
    x = Leer.datoInt();
    Console.Write("b = ");
    b = Leer.datoInt();
    Console.Write("y = ");
    y = Leer.datoInt();
    Console.Write("n = ");
    n = Leer.datoInt();
    if ((a * x + b * y == 0) && (n == 0))
      Console.WriteLine("Indeterminado");
    else
    {
      Console.Write("El valor de la expresión (ax + by)^n = ");
      for (int k = 0; k <= n; k++)
        res += combinaciones(n, k) * potencia(a*x, n-k) * potencia(b*y, k);
      Console.WriteLine(res);
    }
  }
}
