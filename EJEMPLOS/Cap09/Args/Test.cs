public class Test
{
  public static void Main(string[] args)
  {
    // Código común a todos los casos
    System.Console.WriteLine("Argumentos: ");
    if (args.Length == 0)
    {
      // Escriba aquí el código que sólo se debe ejecutar cuando
      // no se pasan argumentos
      System.Console.WriteLine("    ninguno");
    }
    else
    {
      bool argumento_k = false, argumento_l = false,
           argumento_n = false;
    
      // ¿Qué argumentos se han pasado?
      for (int i = 0; i < args.Length; i++)
      {
        if (args[i].CompareTo("-k") == 0) argumento_k = true;
        if (args[i].CompareTo("-l") == 0) argumento_l = true;
        if (args[i].CompareTo("-n") == 0) argumento_n = true;
      }

      if (argumento_k) // si se pasó el argumento -k:
      {
        // Escriba aquí el código que sólo se debe ejecutar cuando
        // se pasa el argumento -k
        System.Console.WriteLine("    -k");
      }

      if (argumento_l) // si se pasó el argumento -l:
      {
        // Escriba aquí el código que sólo se debe ejecutar cuando
        // se pasa el argumento -l
        System.Console.WriteLine("    -l");
      }

      if (argumento_n) // si se pasó el argumento -n:
      {
        // Escriba aquí el código que sólo se debe ejecutar cuando
        // se pasa el argumento -n
        System.Console.WriteLine("    -n");
      }
    }
    // Código común a todos los casos
  }
}

