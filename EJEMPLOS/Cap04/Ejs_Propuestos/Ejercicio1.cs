class Ejercicio1
{
  public static void Main(string[] args)
  {
    int a = 10, b = 3, d, e;
    float x, y;
    bool c = true;
    x = a / b;        // x = 3, pues a y b son int
    c = a < b && c;   // error si 'c' es entero
    d = a + b++;      // d = 13, pues incrementa tras asignar
    e = ++a - b;      // e = 7, pues ++a = 11 y b = 4 (incrementado antes)
    y = (float)a / b; // y = 2.75, pues hacemos una conversión cast
    
    System.Console.WriteLine("Las soluciones son:");

    System.Console.WriteLine("x = " + x);
    System.Console.WriteLine("y = " + y);
    System.Console.WriteLine("a = " + a);
    System.Console.WriteLine("b = " + b);
    System.Console.WriteLine("c = " + c);
    System.Console.WriteLine("d = " + d);
    System.Console.WriteLine("e = " + e);
  }
}
