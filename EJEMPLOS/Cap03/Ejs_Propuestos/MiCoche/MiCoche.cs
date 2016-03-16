class MiCoche
{
  public static void Main(string[] args)
  {
    Coche micoche = new Coche();
    micoche.Marca = "BMW";
    micoche.Color = "Negro metalizado";
    micoche.Tipo = "descapotable";
    micoche.ArrancarMotor();
    micoche.Acelerar();
    micoche.SubirMarcha();
    micoche.Acelerar();
    micoche.SubirMarcha();
    micoche.Acelerar();
    micoche.SubirMarcha();      
    micoche.Frenar();
    micoche.BajarMarcha();
    micoche.Frenar();
    micoche.BajarMarcha();
    micoche.Frenar();
    micoche.BajarMarcha();
    micoche.PararMotor();
    micoche.DescribirCoche();
  }
}
