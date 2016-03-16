// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class Test
{
  public static void Main(string[] args)
  {
    CCalculadora MiCalculadora = new CCalculadora();
    double dato1 = 0, dato2 = 0;
    int operación = 0;

    while (true)
    {
      operación = MiCalculadora.menú();
      if (operación != 5)
      {
        // Leer datos
        Console.Write("Dato 1 ([Entrar] para Dato1 = resultado anterior): ");
        dato1 = Leer.datoDouble();
        if (Double.IsNaN(dato1)) // se pulsó [Entrar]
          dato1 = MiCalculadora.Resultado();
        Console.Write("Dato 2: "); dato2 = Leer.datoDouble();
        MiCalculadora.EstablecerOperandos(dato1, dato2);

        // Realizar la operación
        switch (operación)
        {
          case 1:
            MiCalculadora.Sumar();
            break;
          case 2:
            MiCalculadora.Restar();
            break;
          case 3:
            MiCalculadora.Multiplicar();
            break;
          case 4:
            MiCalculadora.Dividir();
            break;
        }
        // Escribir el resultado
        Console.WriteLine("Resultado = " + MiCalculadora.Resultado() + "\n");
      }
      else
        break;
    }
  }
}

