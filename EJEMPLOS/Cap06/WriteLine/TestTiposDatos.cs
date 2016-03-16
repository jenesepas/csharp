using System;

class TestTiposDatos
{
  // Tipos de datos
  public static void Main(string[] args)
  {
    string sCadena = "Lenguaje C#";
    char[] cMatrizCars = { 'a', 'b', 'c' }; // matriz de caracteres
    int dato_int = 4;
    long dato_long = long.MinValue;    // mínimo valor long
    float dato_float = float.MaxValue; // máximo valor float
    double dato_double = Math.PI;      // 3.1415926
    bool dato_bool = true;

    Console.WriteLine(sCadena);
    Console.WriteLine(cMatrizCars);
    Console.WriteLine(dato_int);
    Console.WriteLine(dato_long);
    Console.WriteLine(dato_float);
    Console.WriteLine(dato_double);
    Console.WriteLine(dato_bool);
  }
}
