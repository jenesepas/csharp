/////////////////////////////////////////////////////////////////
// Definición de la clase CRegistro
//
public class CRegistro
{
  // Atributos
  private int númeroMatrícula;
  private string nombre;
  private string calificación;
  
  // Mtodos
  public CRegistro() {}
  public CRegistro(int nmat, string nom, string cal)
  {
    númeroMatrícula = nmat;
    nombre = nom;
    calificación = cal;
  }
  
  public void asignarNumMat(int nmat)
  {
    númeroMatrícula = nmat;
  }
  
  public long obtenerNumMat()
  {
    return númeroMatrícula;
  }
  
  public void asignarNombre(string nom)
  {
    nombre = nom;
  }
  
  public string obtenerNombre()
  {
    return nombre;
  }
  
  public void asignarCalificación(string cal)
  {
    calificación = cal;
  }
  
  public string obtenerCalificación()
  {
    return calificación;
  }
}
