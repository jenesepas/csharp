/////////////////////////////////////////////////////////////////
// Definición de la clase CPersona
//
public class CPersona
{
  // Atributos
  private string nombre;
  private string dirección;
  private long teléfono;
  
  // Métodos
  public CPersona() {}
  public CPersona(string nom, string dir, long tel)
  {
    nombre = nom;
    dirección = dir;
    teléfono = tel;
  }
  
  public void asignarNombre(string nom)
  {
    nombre = nom;
  }
  
  public string obtenerNombre()
  {
    return nombre;
  }
  
  public void asignarDirección(string dir)
  {
    dirección = dir;
  }
  
  public string obtenerDirección()
  {
    return dirección;
  }
  
  public void asignarTeléfono(long tel)
  {
    teléfono = tel;
  }
  
  public long obtenerTeléfono()
  {
    return teléfono;
  }
  
  public int tamaño()
  {
    // Longitud en bytes de los atributos (un long = 8 bytes)
    return nombre.Length*2 + dirección.Length*2 + 8;
  }
}
