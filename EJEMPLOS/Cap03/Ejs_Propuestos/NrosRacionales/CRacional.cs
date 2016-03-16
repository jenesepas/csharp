/////////////////////////////////////////////////////////////////
// Clase para operar con números racionales (utiliza la clase Leer)
// El objeto para el que se invoca el método (el objeto que recibe
// el mensaje) está accesible en dicho método por la referencia: this.
// Por ejemplo: r1.sumar(r2)
//                  cuando se ejecuta sumar, r1 está referenciado por
//                  this, que se omite y r2 por el parámetro r.
//
public class CRacional
{
  // Atributos
  private long numerador;
  private long denominador;
  
  // Métodos
  protected CRacional Simplificar()
  {
    // Máximo común divisor
    long mcd, temp, resto;
    mcd = System.Math.Abs( numerador );
    temp = System.Math.Abs( denominador );
    while ( temp > 0 )
    {
      resto = mcd % temp;
      mcd = temp;
      temp = resto;
    }
    // Simplificar
    if ( mcd > 1 )
    {
      numerador /= mcd;
      denominador /= mcd;
    }
    return this;
  }

  public CRacional() // constructor
  {
    numerador = 0;
    denominador = 1;
  }

  public CRacional( long num ) // constructor
  {
    numerador = num;
    denominador = 1;
  }

  public CRacional( long num, long den ) // constructor
  {
    numerador = num;
    denominador = den;
    if ( denominador == 0 )
    {
      System.Console.WriteLine("Error: denominador 0. Se asigna 1.");
      denominador = 1;
    }
    if ( denominador < 0 )
    {
      numerador = -numerador;
      denominador = -denominador;
    }
    Simplificar();
  }
  
  public CRacional( CRacional r ) // constructor copia
  {
     numerador = r.numerador;
     denominador = r.denominador;
  }

  // Sumar números racionales
  public CRacional Sumar( CRacional r )
  {
    return new CRacional(numerador * r.denominador +
                         denominador * r.numerador,
                         denominador * r.denominador );
  }
  
  // Restar números racionales
  public CRacional Restar( CRacional r )
  {
    return new CRacional(numerador * r.denominador -
                         denominador * r.numerador,
                         denominador * r.denominador );
  }
  
  // Multiplicar números racionales
  public CRacional Multiplicar( CRacional r )
  {
    return new CRacional(numerador * r.numerador,
                         denominador * r.denominador );
  }
  
  // Dividir números racionales
  public CRacional Dividir( CRacional r )
  {
    return new CRacional(numerador * r.denominador,
                         denominador * r.numerador );
  }
  
  // Verificar si dos números racionales son iguales
  public bool Equals( CRacional r )
  {
    return ( numerador * r.denominador ==
             denominador * r.numerador );
  }

  // Verificar si un racional es menor que otro
  public bool Menor( CRacional r )
  {
    return ( numerador * r.denominador <
             denominador * r.numerador );
  }

  // Verificar si un racional es mayor que otro
  public bool Mayor( CRacional r )
  {
    return ( numerador * r.denominador >
             denominador * r.numerador );
  }

  // Devolver un número racional como cadena
  public string ToString()
  {
  	return numerador + "/" + denominador;
  }

  // Copiar un racional en otro
  public CRacional Copiar( CRacional r )
  {
     numerador = r.numerador;
     denominador = r.denominador;
     return this;
     // El objeto sobre el que un método está trabajando en un
     // instante determinado, siempre está referenciado por this.
  }

  // Verificar si es 0
  public bool EsCero()
  {
    return numerador == 0;
  }
}

