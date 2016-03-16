public class Test
{
  public static void Main(string[] args)
  {
    string str1 = "La provincia de Santander es muy bonita";
    string str2 = "La provincia de SANTANDER es muy bonita";
    string strtemp;
    int resultado;
    resultado = System.String.Compare(str1, str2, true);

    if( resultado > 0 )
      strtemp = "mayor que ";
    else if( resultado < 0 )
      strtemp = "menor que ";
    else
      strtemp = "igual a ";
    System.Console.WriteLine( str1 + " es " + strtemp + str2 );
  }
}
