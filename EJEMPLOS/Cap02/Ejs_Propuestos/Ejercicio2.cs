public class Ejercicio2
{
  public static void Main(string[] args)
  {
    int a = 2, b = 3, c = 6, d = 11;
    long suma = 0;
    float media = 0;
    
    suma = a + b + c + d;    // no es necesaria la conversión cast
    media = (float)suma / 4; // SI es necesaria la conversión CAST
            
    System.Console.WriteLine("La suma es " + suma);
    System.Console.WriteLine("La media es " + media);
  }
}
