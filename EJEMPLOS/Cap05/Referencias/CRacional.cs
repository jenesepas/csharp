public class CRacional
{
  // Atributos
  private int Numerador;
  private int Denominador;
  
  // Constructores
  public CRacional() {}
  public CRacional(int num, int den)
  {
    AsignarDatos(num, den);
  }
  
  // Métodos
  public void AsignarDatos(int num, int den)
  {
    Numerador = num;
    if (den == 0) den = 1; // el denominador no puede ser cero
    Denominador = den;
  }
  
  public void VisualizarRacional()
  {
    System.Console.WriteLine(Numerador + "/" + Denominador);
  }
  
  public static CRacional Sumar(CRacional a, CRacional b)
  {
    CRacional r = new CRacional(); // crear un objeto CRacional
    int num = a.Numerador * b.Denominador + 
              a.Denominador * b.Numerador;
    int den = a.Denominador * b.Denominador;
    r.AsignarDatos(num, den);
    return r;
  }
}

