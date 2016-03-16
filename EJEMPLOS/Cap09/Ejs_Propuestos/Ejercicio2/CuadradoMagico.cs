using System;

public class CuadradoMagico
{
  private int[,] cm;
  private int n;

  public CuadradoMagico(int orden)
  {
    if (!esImpar(orden)) orden++;
    n = orden;
    cm = new int[n,n];
  }

  public bool esImpar(int n)
  {
    if (n % 2 != 0) return true;
    return false;         
  }
  
  public void cuadradoMagico()
  {    
    int fil = 0, col = n/2, fil_ant = 0, col_ant = n/2, cont = 1;
    
    cm[fil,col] = cont++;
                   
    while (cont <= n * n) 
    {   
      fil = fil-1;
      col = col+1;
           
      if(fil < 0) fil = n-1;
      if(col > n-1) col = 0;
      if(cm[fil,col] != 0)
      {
        col = col_ant; 
        fil = fil_ant + 1;
        if (fil == n) fil = 0;
      }
   
      cm[fil,col] = cont++;
      fil_ant = fil;
      col_ant = col;
    }
  }

  public void visualizar()
  {
    for (int i = 0; i < n;i++)
    {
      Console.Write("\t");
      for (int j = 0; j < n;j++)     
        Console.Write(cm[i,j] + "\t");
      Console.WriteLine();
    }      
  }
}
