using System;
using MisClases.ES;

public class Ejercicio3
{
  public static int compcads(char[] cad1, char[] cad2, int n)
  {
    int num = 0;
    int longCad1 = 0, longCad2 = 0;

    while (cad1[longCad1] != '\0' && longCad1 < cad1.Length)
      longCad1++;

    while ((cad2[longCad2] != '\0')  && (longCad2 < cad2.Length))
      longCad2++; 

    if (longCad1 < longCad2)
    {
      if (n < 1 || n > longCad1) n = longCad2;
    }
    else
      if (n < 1 || n > longCad2) n = longCad1;

    while (num < n)
    {
      if (cad1[num] < cad2[num])
        return -1;
      else if (cad1[num] > cad2[num])
        return 1;
      num++;
    }
    return 0;
  }

  public static void Main(string[] arg)
  {

    int MAX = 70;
    char[] cadena1 = new char[MAX];
    char[] cadena2 = new char[MAX];
    char car = '\0';
    int i = 0, n = 0, j = 0;

    Console.WriteLine("Introduzca la primera cadena");
    while ((car = (char)Console.Read()) != '\r' && i < cadena1.Length)
      cadena1[i++] = car;
    cadena1[i] = '\0';

    Console.WriteLine("Introduzca la segunda cadena");
    Console.ReadLine();
    while ((car = (char)Console.Read()) != '\r' && j < cadena2.Length)
      cadena2[j++] = car;
    cadena2[j] = '\0';

    Console.WriteLine("Cuántos caracteres quiere comparar");
    Console.ReadLine();
    n = Leer.datoInt();
                              
    int con = compcads(cadena1, cadena2, n);

    String cad1 = new String(cadena1, 0, i);
    String cad2 = new String(cadena2, 0, j);
    if (con == 0)
      Console.WriteLine("\nLas dos cadenas son iguales");
    else if (con < 0)
      Console.WriteLine(cad1 + " es menor que " + cad2);
    else
      Console.WriteLine(cad1 + " es mayor que " + cad2);
  }
}
