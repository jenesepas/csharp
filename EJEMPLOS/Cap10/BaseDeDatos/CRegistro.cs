/////////////////////////////////////////////////////////////////
// Definición de la clase CRegistro
//
public class CRegistro
{
  // Atributos
  private string referencia;
  private double precio;

  // Métodos
  public CRegistro() {}
  public CRegistro(string refer, double pre)
  {
    referencia = refer;
    precio = pre;
  }

  public void asignarReferencia(string refer)
  {
    referencia = refer;
  }

  public string obtenerReferencia()
  {
    return referencia;
  }

  public void asignarPrecio(double pre)
  {
    precio = pre;
  }

  public double obtenerPrecio()
  {
    return precio;
  }

  public int tamaño()
  {
    // Longitud en bytes de los atributos (un double = 8 bytes)
    return referencia.Length*2 + 8;
  }
}
