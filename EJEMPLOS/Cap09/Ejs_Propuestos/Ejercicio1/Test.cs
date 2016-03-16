using System;
using MisClases.ES; // espacio de nombres de la clase Leer

public class Test
{
  public static void entrada(Diccionario dic, int s)
  {
    // s = 0 --> añadir
    // s = 1 --> cambiar
    String palabra_sp = null, palabra_en = null;
 
    do
    {
      Console.Write("Palabra en español: ");
      palabra_sp = Console.ReadLine();
      if (palabra_sp != null)
      {
        do
        {
          Console.Write("Palabra en inglés: ");
          palabra_en = Console.ReadLine();
        }
        while (palabra_en == null);
      }
    }
    while (palabra_sp == null);
    if (s == 0)
      dic.añadir(palabra_sp, palabra_en);
    else
    {
      Console.Write("Posición: ");
      int pos = Leer.datoInt();
      dic.cambiar(pos, palabra_sp, palabra_en);
    }
  }     

  public static int Menu()
  {
    int opción = 0;
    do
    {
      Console.WriteLine("\t1.- Añadir nueva entrada");
      Console.WriteLine("\t2.- Modificar entrada");
      Console.WriteLine("\t3.- Traducir inglés a español");
      Console.WriteLine("\t4.- Traducir español a inglés");
      Console.WriteLine("\t5.- Buscar palabra en español o en inglés");
      Console.WriteLine("\t6.- Exit o Salir");
      Console.Write("\nopción: ");
      opción = Leer.datoInt();
    }
    while((opción < 1) || (opción > 6));
    return opción;
  }

  public static void Main(string[] arg)
  {
    Diccionario dicSpEnSp = new Diccionario();

    String palabra;
    int pos = 0, opción = 0;
 
    do
    {
      opción = Menu();
      switch (opción)
      {
        case 1:
          entrada(dicSpEnSp, 0);
          break;
        case 2:
          entrada(dicSpEnSp, 1);
          break;
        case 3:
          Console.Write("Palabra en inglés: ");
          palabra = Console.ReadLine();
          palabra = dicSpEnSp.EnToSp(palabra);
          if (palabra == null)
            Console.WriteLine("No existe esa palabra");
          else
            Console.WriteLine(palabra);
          break;
        case 4:
          Console.Write("Palabra en español: ");
          palabra = Console.ReadLine();
          palabra = dicSpEnSp.SpToEn(palabra);
          if (palabra == null)
            Console.WriteLine("No existe esa palabra");
          else
            Console.WriteLine(palabra);
          break;
        case 5:
          Console.Write("Palabra: ");
          palabra = Console.ReadLine();
          pos = dicSpEnSp.buscar(palabra);
          if (pos == -1)
            Console.WriteLine("No existe esa palabra");
          else
            Console.WriteLine("La palabra buscada está en la posición " + pos);
          break;
      }
    }
    while (opción != 6);
  }
}
