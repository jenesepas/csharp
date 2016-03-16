using System;

public class Test
{
  public static void Main(string[] args)
  {
    char car = '\0';

    Console.Write("Carácter: ");
    car = (char)Console.Read();
    Console.WriteLine(car);

    // Limpiar el buffer de entrada
    Console.ReadLine();

    Console.Write("Carácter: ");
    car = (char)Console.Read();
    Console.WriteLine(car);
  }
}
