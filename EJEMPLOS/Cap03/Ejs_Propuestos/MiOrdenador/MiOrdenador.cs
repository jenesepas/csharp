class MiOrdenador
{
  public static void Main(string[] args)
  {
    COrdenador miordenador = new COrdenador();
    miordenador.Marca = "Toshiba";
    miordenador.Procesador = "Pentium III";
    miordenador.Peso = 3;
    miordenador.EncenderOrdenador();
    miordenador.Estado();
    miordenador.DesactivarPantalla();
    miordenador.Estado();
    miordenador.ApagarOrdenador();
  }
}
      
