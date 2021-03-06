public class CFecha
{
  private int día;
  private int mes;
  private int año;
  
  public CFecha() {}
  public CFecha(int d, int m, int a)
  {
    día = d; mes = m; año = a;
    if ( !FechaCorrecta() ) // Se asume 1/1/2000
      día = 1; mes = 1; año = 2000;
  }

  public bool EstablecerFecha(int d, int m, int a)
  {
    día = d; mes = m; año = a;
    return FechaCorrecta();
  }

  public int ObtenerDa()
  {
    return día;
  }

  public int ObtenerMes()
  {
    return mes;
  }
  public int ObtenerAo()
  {
    return año;
  }

  private bool FechaCorrecta()
  {
    bool día_correcto = true;
    bool mes_correcto = true;
    bool año_correcto = true;
    
    año_correcto = año >= 1;

    switch (mes)
    {
      case 1:      // enero
      case 3:      // marzo
      case 5:      // mayo
      case 7:      // julio
      case 8:      // agosto
      case 10:     // octubre
      case 12:     // diciembre
        día_correcto = día >= 1 && día <= 31;
        break;
      case 4:      // abril
      case 6:      // junio
      case 9:      // septiembre
      case 11:     // noviembre
        día_correcto = día >= 1 && día <= 30;
        break;
      case 2:      // febrero
        // Es el año bisiesto?
        if ((año % 4 == 0) && (año % 100 != 0) || (año % 400 == 0))
          día_correcto = día >= 1 && día <= 29;
        else
          día_correcto = día >= 1 && día <= 28;
          break;
      default:
        mes_correcto = false;
        break;
    }
    return día_correcto && mes_correcto && año_correcto;
  }
}
