/**
 * Clase CGrados. Un objeto de esta clase almacena un valor
 * en grados centígrados.
 * Atributos:
 *   gradosC
 * Métodos:
 *   CentígradosAsignar, FahrenheitObtener y CentígradosObtener
 */
class CGrados
{
  private float gradosC; // grados centígrados
  
  public void CentígradosAsignar(float gC)
  {
    // Establecer el atributo grados centígrados
    gradosC = gC;
  }
  
  public float FahrenheitObtener()
  {
    // Retornar los grados fahrenheit equivalentes a gradosC
    // 9/5: la división de dos enteros da otro entero; en este caso 1.
    // Por eso utilizamos la expresión 9F/5F.
    return 9F/5F * gradosC + 32;
  }
  
  public float CentígradosObtener()
  {
    return gradosC; // retornar los grados centígrados
  }
}

