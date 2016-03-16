/*
 * Conversión de grados centígrados a fahrenheit:
 * F = 9/5 * C + 32
 */

class CApGrados
{
  // Definición de constantes
  const int limInferior = -30;
  const int limSuperior = 100;
  const int incremento = 6;

  public static float FahrenheitObtener(float gradosC)
  {
    // Retornar los grados fahrenheit equivalentes a gradosC
    return 9F/5F * gradosC + 32;
  }
  
  public static void Main(string[] args)
  {
    // Declaración de variables
    int gradosCent = limInferior;
    float gradosFahr = 0;

    while (gradosCent <= limSuperior) // mientras ... hacer:
    {
      // Obtener los grados fahrenheit equivalentes a gradosCent
      gradosFahr = FahrenheitObtener(gradosCent);
      // Escribir la siguiente línea de la tabla
      System.Console.WriteLine("{0, 8:d} C {1, 8:f2} F", gradosCent, gradosFahr);
      // Siguiente valor
      gradosCent += incremento;
    }
  }
}

