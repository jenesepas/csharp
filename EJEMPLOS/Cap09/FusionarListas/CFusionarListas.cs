public class CFusionarListas
{
  // Fusionar dos listas ordenadas
  public static int Fusionar(string[] listaA, string[] listaB,
                             string[] listaC)
  {
    int ind = 0, indA = 0, indB = 0, indC = 0;

    if (listaA.Length + listaB.Length == 0)
      return 0;

    // Fusionar las listas A y B en la C
    while (indA < listaA.Length && indB < listaB.Length)
      if (listaA[indA].CompareTo(listaB[indB]) < 0)
        listaC[indC++] = listaA[indA++];
      else
        listaC[indC++] = listaB[indB++];
    
    // Los dos bucles siguientes son para prever el caso de que,
    // lógicamente una lista finalizará antes que la otra.
    for (ind = indA; ind < listaA.Length; ind++)
      listaC[indC++] = listaA[ind];
    
    for (ind = indB; ind < listaB.Length; ind++)
      listaC[indC++] = listaB[ind];
    
    return 1;
  }
                            
  static public void Main(string[] args)
  {
    // Iniciamos las listas a ordenar (puede sustituir este
    // proceso, por otro de lectura con el fin de tomar los
    // datos de la entrada estándar).
    string[] lista1 = { "Ana", "Carmen", "David",
                        "Francisco", "Javier", "Jesús",
                        "José", "Josefina", "Luís",
                        "María", "Patricia", "Sonia" };
    
    string[] lista2 = { "Agustín", "Belén", "Daniel",
                        "Fernando", "Manuel",
                        "Pedro", "Rosa", "Susana" };
    
    // Declarar la matriz que va a almacenar el resultado de
    // fusionar las dos anteriores
    string[] lista3 = new string[lista1.Length + lista2.Length];
    
    // Fusionar lista1 y lista2 y almacenar el resultado en lista3.
    // El método "Fusionar" devolverá un 0 cuando no se pueda
    // realizar la fusión.
    int ind, r;
    r = Fusionar(lista1, lista2, lista3);

    // Escribir la matriz resultante
    if (r != 0)
    {
      for (ind = 0; ind < lista3.Length; ind++)
        System.Console.WriteLine(lista3[ind]);
    }
    else
      System.Console.WriteLine("Error");
  }
}

