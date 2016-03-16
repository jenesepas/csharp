class Test
{
  public static void Main(string[] args)
  {
    CDesplazar cad1 = new CDesplazar();
    cad1.leerTexto();
    int numCarcteres = cad1.numCars();

    for (int i = 0; i < numCarcteres+1; i++)
    {
      cad1.mostrarTexto();
      cad1.desplazarUnCaracter();
    }
  }
}
