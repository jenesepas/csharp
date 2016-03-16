class COrdenador
{
  string marca = null;
  string procesador = null;
  int peso = 0;
  bool encendido = false;
  bool pantalla = false;


  public string Marca
  {
    get
    {
      return marca;
    }
    set
    {
      if (value == null)
        marca = "marca desconocida";
      else
        marca = value;
    }
  }
  
  public void EncenderOrdenador()
  {
    if (encendido == true)
    {
      System.Console.WriteLine("El ordenador ya está encendido");
    }
    else 
    {
      encendido = true;
      pantalla = true;
      System.Console.WriteLine("El ordenador ha sido encendido");
    }
  }
      
  public void Estado()
  {
    System.Console.Write("\nEl estado del ordenador es el siguiente:");
    System.Console.Write("\nMarca: " + marca);
    System.Console.Write("\nProcesador: " + procesador);
    System.Console.Write("\nPeso: " + peso + " kg.");

    if (encendido == true)
    {
      System.Console.Write("\nEl ordenador está encendido");
    }
    else
      System.Console.Write("\nEl ordenador está apagado");

    if (pantalla == true)
    {
      System.Console.Write("\nLa pantalla está activada");
    }
    else
      System.Console.Write("\nLa pantalla está desactivada");

    System.Console.WriteLine("\n");
  }
}
