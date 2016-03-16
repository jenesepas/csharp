using System;

public class Test
{
  public static void Main(string[] args)
  {
    char car = '\0';

    Console.Write("\nDesea continuar s/n (sí o no) ");
    while ((car = (char)Console.Read()) != 's' && car != 'n')
    {
      // Saltar los caracteres disponibles en el flujo de entrada
      Console.ReadLine();
      Console.Write("\nDesea continuar s/n (sí o no) ");
    }
  }
}
