class CMiAplicacion
{
  public static void Main(string[] args)
  {
    CEcuacion ec1 = new CEcuacion(1, -3.2, 0, 7);
    
    double r = ec1.ValorPara(1);
    System.Console.WriteLine(r);
    
    r = ec1.ValorPara(1.5);
    System.Console.WriteLine(r);
  }
}

