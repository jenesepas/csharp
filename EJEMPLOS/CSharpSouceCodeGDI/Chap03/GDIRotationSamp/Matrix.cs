// created on 1/27/2002 at 10:54 PM
namespace MyMath
{
	
public interface IMatrix : System.ICloneable
{
	double GetNum(int x, int y);
	void SetNum(int x, int y, double num);
	int SizeX {get; set;}
	int SizeY{get;set;}	
}

public class Matrix : IMatrix, System.ICloneable
{	
	private int lenX=0, lenY=0;
	private double[,] data;
	
	public object Clone()
	{
		Matrix tmp=new Matrix(SizeX,SizeY);
		int x,y;
		for (x=0;x<SizeX;x++)
			for (y=0;y<SizeY;y++)
				tmp.SetNum(x,y,data[x,y]);
		return tmp;
	}
	public Matrix(int sizeX, int sizeY)
	{
		data=new double[SizeX,SizeY];
		this.SizeX=sizeX;
		this.SizeY=sizeY;
	}

	public double GetNum(int x, int y)
	{
		return data[x,y];
	}
	
	public void SetNum(int x, int y, double num)
	{
		data[x,y]=num;
	}
	
	public IMatrix SubMatrix(int x, int y)
	{
		int m, n;		
		IMatrix temp=(IMatrix)this.Clone();
		temp.SizeX=SizeX-1;
		temp.SizeY=SizeY-1;
		for (n=0;n<y;n++)
			for(m=0;m<x;m++)
				temp.SetNum(m,n,GetNum(m,n));
		for (n=y+1;n<SizeY;n++)
			for(m=0;m<x;m++)
				temp.SetNum(m,n-1,GetNum(m,n));
		for (n=0;n<y;n++)
			for(m=x+1;m<SizeX;m++)
				temp.SetNum(m-1,n,GetNum(m,n));
		for (n=y+1;n<SizeY;n++)
			for(m=x+1;m<SizeX;m++)
				temp.SetNum(m-1,n-1,GetNum(m,n));
		return temp;
	}
	
	private static double det(Matrix mat)
	{
		double tmp=0;
		int c, sign=1;
		if (mat.SizeX==1&&mat.SizeY==1) 
			return mat.GetNum(0,0);
		for (c=0;c<mat.SizeX;c++)
		{
			tmp+=sign*det((Matrix)mat.SubMatrix(c,0))*mat.GetNum(c,0);
			sign=-sign;
		}
		return tmp;
	}
	
	public int SizeX
	{
		get
		{
			return lenX;
		}
		set
		{
			int x,y, dataX=SizeX<value?SizeX:value;
			double[,] newData=new double[value,SizeY];
			for (x=0;x<dataX;x++)
				for(y=0;y<SizeY;y++)
					newData[x,y]=data[x,y];
			lenX=value;
			data=newData;
		}
	}
	
	public int SizeY
	{
		get
		{
			return lenY;
		}
		set
		{
			int x,y, dataY=SizeY<value?SizeY:value;
			double[,] newData=new double[SizeX,value];
			for (x=0;x<SizeX;x++)
				for(y=0;y<dataY;y++)
					newData[x,y]=data[x,y];
			lenY=value;
			data=newData;
		}
	}
	
	public double Determinant
	{
		get
		{
			return det(this);
		}
	}
	
	public virtual void Draw()
	{
		int m,n;
		for (n=0; n<SizeY;n++) {
			System.Console.WriteLine();
			for (m=0; m<SizeX; m++)
				System.Console.Write("{0}    ",GetNum(m,n));
		}
	}
	
	public IMatrix Mul(IMatrix mat)
	{
		int m,n,r;
		double row;
		System.Console.WriteLine("in Mul!");
		IMatrix tmp=(IMatrix)mat.Clone();
		tmp.SizeY=SizeY;
		
		for (m=0;m<tmp.SizeX;m++)
			for(n=0;n<SizeY;n++)
			{
				row=0;			
				for (r=0;r<SizeX;r++)
					row+=GetNum(r,n)*mat.GetNum(m,r);
				tmp.SetNum(m,n,row);
			}
		return tmp;
	}
	
	public IMatrix Mul(double num)
	{
		int m,n;
		IMatrix tmp=(IMatrix)this.Clone();
		for (m=0;m<SizeX;m++)
			for(n=0;n<SizeY;n++)
				tmp.SetNum(m,n,GetNum(m,n)*num);
		return tmp;		
	}
	
	public IMatrix Div(double num)
	{
		return Mul(1/num);
	}
	
	public IMatrix Add(IMatrix mat)
	{
		int m,n;
		IMatrix tmp=(IMatrix)this.Clone();
		for (m=0;m<SizeX;m++)
			for(n=0;n<SizeY;n++)
				tmp.SetNum(m,n,GetNum(m,n)+mat.GetNum(m,n));
		return tmp;
		
	}
	
	public IMatrix Add(double num)
	{
		int m,n;
		IMatrix tmp=(IMatrix)this.Clone();
		for (m=0;m<SizeX;m++)
			for(n=0;n<SizeY;n++)
				tmp.SetNum(m,n,GetNum(m,n)+num);
		return tmp;
		
	}
	
	public IMatrix Deduct(IMatrix mat)
	{
		int m,n;
		IMatrix tmp=(IMatrix)this.Clone();
		for (m=0;m<SizeX;m++)
			for(n=0;n<SizeY;n++)
				tmp.SetNum(m,n,GetNum(m,n)-mat.GetNum(m,n));
		return tmp;
		
	}
	
	public IMatrix Deduct(double num)
	{
		return Add(-num);
	}
	
	public IMatrix Identity(int sizeX, int sizeY)
	{
		int m,n;
		IMatrix tmp=(IMatrix)this.Clone();
		for (m=0;m<sizeX;m++)
			for(n=0;n<sizeY;n++)
				tmp.SetNum(m,n,(m==n)?1:0);
		return tmp;		
	}
	
	public IMatrix Identity(int sizeX, int sizeY, double fac)
	{
		int m,n;
		IMatrix tmp=(IMatrix)this.Clone();		
		for (m=0;m<sizeX;m++)
			for(n=0;n<sizeY;n++)
				tmp.SetNum(m,n,(m==n)?fac:0);
		return tmp;		
	}
}


}
