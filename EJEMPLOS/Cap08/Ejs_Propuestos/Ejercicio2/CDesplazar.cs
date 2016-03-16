class CDesplazar
{
  private string texto;
  private int tamaño;

  public void leerTexto()
  {
    System.Console.Write("Introduce un texto: ");
    texto = System.Console.ReadLine();
    tamaño = texto.Length;            
  }
 
  public void mostrarTexto()
  {
    System.Console.WriteLine(texto);            
  }
 
  public void desplazarUnCaracter()
  {
    int i=0;
    char ultimo;
    // Convertir el string en una matriz de caracteres
    char[] cadChar = new char[texto.Length];
    texto.CopyTo(0, cadChar, 0, texto.Length);

    ultimo = cadChar[tamaño-1];

    // Desplazar el texto una posición a la derecha. El último
    // pasa a ser el primero.
    for(i = 0; i < tamaño-1; i++)
      cadChar[tamaño-(i+1)] = cadChar[tamaño-(i+2)];
     
    cadChar[0] = ultimo;
    // Convertir la matriz de caracteres en un String
    texto = new string(cadChar);
  }
 
  public int numCars()
  {
    return tamaño;
  }
}

