using System;

public class Test
{
  public static void Main(string[] args)
  {
    int car1 = 'A', car2 = 65, car3 = 0;

    car3 = car1 + 'a' - 'A';
    Console.WriteLine((char)car3 + " " + car3); // a 97

    car3 = car2 + 32;
    Console.WriteLine((char)car3 + " " + car3); // a 97
  }
}
