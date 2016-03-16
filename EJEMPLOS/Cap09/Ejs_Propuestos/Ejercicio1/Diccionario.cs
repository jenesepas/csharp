using System;

public class Diccionario
{
  private String[] spanish;
  private String[] english;
  private int ultimaEntradaLibre;

  public Diccionario()
  {
    spanish = new String[100];
    english = new String[100];
    ultimaEntradaLibre = 0;
  }

  public Diccionario(int n)
  {
    if (n < 1) n = 100;
    spanish = new String[n];
    english = new String[n];
    ultimaEntradaLibre = 0;
  }

  public void añadir(String es, String uk)
  {
    if (ultimaEntradaLibre < 100)
    {
      spanish[ultimaEntradaLibre] = es;
      english[ultimaEntradaLibre] = uk;
      ultimaEntradaLibre++;
    }
    else
      Console.WriteLine("No hay entradas libres");
  }     

  public void cambiar(int i, String es, String uk)
  {
    if (i < 0 || i > 99)
    {
      Console.WriteLine("No hay entradas libres");
      return;
    }
    spanish[i] = es;
    english[i] = uk;
  }     

  public String EnToSp(String palabra)
  {
    for (int i = 0; i < ultimaEntradaLibre; i++)
      if (english[i].CompareTo(palabra) == 0) return spanish[i];
    return null;         
  }

  public String SpToEn(String palabra)
  {
    for (int i = 0; i < ultimaEntradaLibre; i++)
      if (spanish[i].CompareTo(palabra) == 0) return english[i];
    return null;         
  }

  public int buscar(String palabra)
  {
    // Buscar en ingls o en espaol
    for (int i = 0; i < ultimaEntradaLibre; i++)
      if (spanish[i].CompareTo(palabra) == 0 ||
          english[i].CompareTo(palabra) == 0) return i;
    return -1;         
  }
}
