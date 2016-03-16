// Este programa utiliza la clase Leer del espacio de nombres
// MisClases.ES
using System;
using MisClases.ES;

public class CCalculadora
{
  // Simulación de una calculadora
  private double operando1;
  private double operando2;
  private double resultado;

  public void EstablecerOperandos(double op1, double op2)
  {
    operando1 = op1;
    operando2 = op2;
  }
  public double Resultado()
  {
    return resultado;
  }

  public int menú()
  {
    int op;
    do
    {
      Console.WriteLine("\t1. sumar");
      Console.WriteLine("\t2. restar");
      Console.WriteLine("\t3. multiplicar");
      Console.WriteLine("\t4. dividir");
      Console.WriteLine("\t5. salir");
      Console.Write("\nSeleccione la operación deseada: ");
      op = Leer.datoInt();
    }
    while (op < 1 || op > 5);
    return op;
  }

  public double Sumar()
  {
    resultado = operando1 + operando2;
    return resultado;
  }
  
  public double Restar()
  {
    resultado = operando1 - operando2;
    return resultado;
  }
  
  public double Multiplicar()
  {
    resultado = operando1 * operando2;
    return resultado;
  }
  
  public double Dividir()
  {
    resultado = operando1 / operando2;
    return resultado;
  }
}

