using System;   // utilizar el espacio de nombres System

/**
 * Clase CGrados. Un objeto de esta clase almacena un valor
 * en grados centígrados.
 * Atributos:
 *   gradosC
 * Mtodos:
 *   CentgradosAsignar, FahrenheitObtener y CentgradosObtener
 */
class CGrados
{
  private float gradosC; // grados centígrados
  
  public void CentgradosAsignar(float gC)
  {
    // Establecer el atributo grados centígrados
    gradosC = gC;
  }
  
  public float FahrenheitObtener()
  {
    // Retornar los grados fahrenheit equivalentes a gradosC
    return 9F/5F * gradosC + 32;
  }
  
  public float CentgradosObtener()
  {
    return gradosC; // retornar los grados centígrados
  }
}

/**
 * Conversión de grados centgrados a fahrenheit:
 * F = 9/5 * C + 32
 */

class CApGrados
{
  // Definición de constantes
  const int limInferior = -30;
  const int limSuperior = 100;
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
      grados.CentgradosAsignar(gradosCent);
      // Obtener del objeto grados los grados fahrenheit
      gradosFahr = grados.FahrenheitObtener();
      // Escribir la siguiente línea de la tabla
      Console.WriteLine("{0, 8:d} C {1, 8:f2} F", gradosCent, gradosFahr);
      // Siguiente valor
      gradosCent += incremento;
    }
  }
}


