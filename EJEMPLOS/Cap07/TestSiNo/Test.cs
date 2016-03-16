using System;

public class Test
{
  public static void Main(string[] args)
  {
    char car = '\0';

    Console.Write("\nDesea continuar s/n (sí o no) ");
    car = (char)Console.Read();
    // Eliminar los caracteres disponibles en el flujo de entrada
    Console.ReadLine();
    while (car != 's' && car != 'n')
    {
      Console.Write("\nDesea continuar s/n (sí o no) ");
      car = (char)Console.Read();
      Console.ReadLine();
    }
  }
}
