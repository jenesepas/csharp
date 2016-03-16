// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CDescuento
{
  public static void Main(string[] args)
  {
    int ar, cc;
    float pu, desc;
    
    Console.Write("Código artículo....... ");
    ar = Leer.datoInt();
    Console.Write("Cantidad comprada..... ");
    cc = Leer.datoInt();
    Console.Write("Precio unitario....... ");
    pu = Leer.datoFloat();
    Console.WriteLine();

    if (cc > 100)
      desc = 40F;      // descuento 40%
    else if (cc >= 25)
      desc = 20F;      // descuento 20%
    else if (cc >= 10)
      desc = 10F;      // descuento 10%
    else
      desc = 0.0F;     // descuento 0%
    Console.WriteLine("Descuento............. " + desc + "%");
    Console.WriteLine("Total................. " +
                       cc * pu * (1 - desc / 100));
  }
}
