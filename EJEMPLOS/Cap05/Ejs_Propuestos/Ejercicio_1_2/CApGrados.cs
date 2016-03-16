/**
 * Conversión de grados centígrados a fahrenheit:
 * F = 9/5 * C + 32
 */

using System;   // utilizar el espacio de nombres System

class CApGrados
{
  // Definición de constantes
  const int limInferior = -40;
  const int limSuperior = 110;
  const int incremento = 6;

  public static void Main(string[] args)
  {
    // Declaración de variables
    CGrados grados = new CGrados(); // objeto grados
    int gradosCent = limInferior;
    float gradosFahr = 0;

    while (gradosCent <= limSuperior) // mientras ... hacer:
    {
      // Asignar al objeto grados el valor en grados centígrados
      grados.CentígradosAsignar(gradosCent);
      // Obtener del objeto grados los grados fahrenheit
      gradosFahr = grados.FahrenheitObtener();
      // Escribir la siguiente línea de la tabla
      System.Console.WriteLine("{0, 8:d} C {1, 8:f2} F", gradosCent, gradosFahr);
      // Siguiente valor
      gradosCent += incremento;
    }
  }
}

