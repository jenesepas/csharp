public class Test
{
  public static void Visualizar(byte car)
  {
    int i = 0, bit;
    for (i = 7; i >= 0; i--)
    {
      bit = ((car & (1 << i))!= 0) ? 1 : 0;
      System.Console.Write(bit);
    }
    System.Console.WriteLine();
  }
  
  public static byte HaceAlgo(byte car)
  {
    return (byte)(((car & 0x01) << 7) | ((car & 0x02) << 5) |
                  ((car & 0x04) << 3) | ((car & 0x08) << 1) |
                  ((car & 0x10) >> 1) | ((car & 0x20) >> 3) |
                  ((car & 0x40) >> 5) | ((car & 0x80) >> 7));
  }

  public static void Main(string[] args)
  {
    byte car;

    System.Console.Write("Introduce un carácter Unicode: ");
    car = (byte)System.Console.Read();
    Visualizar(car);
    System.Console.WriteLine("\nCarácter resultante:");
    car = HaceAlgo(car);
    Visualizar(car);
  }
}

