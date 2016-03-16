using System;

class Test
{
  public static void Main(string[] args)
  {
    double a = 10, b = 20, c = 0;
    try
    {
      c = a + b;
      // La siguiente sentencia contiene un error:
      // utiliza el forma d con un double
      Console.WriteLine("{0:f} + {1:f} = {2:d}", a, b, c);
    }
    catch(FormatException)
    {
      Console.Write("Ha ocurrido un error de formato");
    }
    catch(Exception e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
  }
}

