class Coche
{
  private string color;
  private string marca;
  private string tipo;
  private int marcha = 0;

  public string Color
  {
    get
    {
      return color;
    }
    set
    {
      if (value == null)
        color = "color desconocido";
      else
        color = value;
    }
  }

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

  public string Tipo
  {
    get
    {
      return tipo;
    }
    set
    {
      if (value == null)
        tipo = "marca desconocida";
      else
        tipo = value;
    }
  }

  public void ArrancarMotor()
  {
    System.Console.WriteLine("\nBRrrrrrrrrummmmm...");
  }

  public void Acelerar()
  {
    System.Console.WriteLine("Acelerando...");
  }

  public void SubirMarcha()
  {
    marcha++;
    System.Console.WriteLine("Marcha: " + marcha);
  }

  public void BajarMarcha()
  {
    marcha--;
    System.Console.WriteLine("Marcha: " + marcha);
  }

  public void Frenar()
  {
    System.Console.WriteLine("Frenando...");
  }

  public void PararMotor()
  {
    System.Console.WriteLine("\nMotor parado.");
  }

  public void DescribirCoche()
  {
    System.Console.WriteLine("\n  -- Mi coche es un " + marca + " " + color + " " + tipo);
  } 
}
