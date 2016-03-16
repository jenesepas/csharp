class COrdenador
{
  string marca;
  string procesador;
  int peso;
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
  
  public string Procesador
  {
    get
    {
      return procesador;
    }
    set
    {
      if (value == null)
        procesador = "procesador desconocido";
      else
        procesador = value;
    }
  }
  
  public int Peso
  {
    get
    {
      return peso;
    }
    set
    {
      if (value < 0)
        peso = 0;
      else
        peso = value;
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
      
  public void ApagarOrdenador()
  {
    if (encendido == false)
    {
      System.Console.WriteLine("El ordenador ya está apagado");
    }
    else 
    {
      encendido=false;
      System.Console.WriteLine("El ordenador ha sido apagado");
    }
  }
  
  public void ActivarPantalla()
  {
    if (pantalla == true)
    {
      System.Console.WriteLine("La pantalla ya está activada");
    }
    else 
    {
      pantalla = true;
      System.Console.WriteLine("La pantalla ha sido activada");
    }
  }
      
  public void DesactivarPantalla()
  {
    if (pantalla == false)
    {
      System.Console.WriteLine("La pantalla ya está desactivada");
    }
    else 
    {
      pantalla = false;
      System.Console.WriteLine("La pantalla ha sido desactivada");
    }
  }

  public void Estado()
  {
    System.Console.Write("\nEl estado del ordenador es el siguiente: ");
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
