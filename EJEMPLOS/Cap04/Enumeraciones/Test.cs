class Test
{
  enum día {lunes, martes, miércoles, jueves, viernes, sábado, domingo};
  public static void Main(string[] args)
  {
    día díaSem = día.jueves;
    if (díaSem == día.domingo) 
      System.Console.Write("fiesta");
    else
      System.Console.Write(díaSem);
  }
}

