//created on 1/31/2002 at 2:51 PM

using System.Drawing;

namespace My3D
{

public class Polygon
{
	private Vector[] vectors;
	private Vector zeroVec=new Vector(0,0,0);
	private float zVal=100;
	
	public Polygon(params Vector[] points)
	{
		int count=0;
		vectors=new Vector[points.Length];
		foreach (Vector vec in points) 
			vectors[count++]=vec;
	}
	
	public Polygon(Vector zero, params Vector[] points) : this(points)
	{
		this.Zero=zero;
	}

	public Polygon(float zVal, Vector zero, params Vector[] points) : this(zero,points)
	{
		this.ZVal=zVal;
	}

	public virtual void Draw()
	{
		foreach(Vector vec in vectors)
		{
			vec.Draw();
			System.Console.Write(", ");
		}
		System.Console.WriteLine();
	}
	
	private float X2D(Vector vec)
	{
		return vec.X/(vec.Z+Zero.Z)*ZVal+Zero.X;
	}
	
	private float Y2D(Vector vec)
	{
		return vec.Y/(vec.Z+Zero.Z)*ZVal+Zero.Y;
	}
	
	public virtual void Draw(Graphics g)
	{
		for (int count=0;count<Len-1;count++)
			g.DrawLine(Pens.Green,
			           X2D(vectors[count])  ,Y2D(vectors[count])  ,
			           X2D(vectors[count+1]),Y2D(vectors[count+1]));
			           
			g.DrawLine(Pens.Green,
			           X2D(vectors[Len-1])  ,Y2D(vectors[Len-1])  ,
			           X2D(vectors[0])      ,Y2D(vectors[0]));
	}
	
	public Polygon Rotate(RotateMatrix rot)
	{
		int count=0;
		Vector[] retVec=new Vector[Len];
		foreach (Vector vec in vectors)
			retVec[count++]=vec.Rotate(rot);
		return new Polygon(ZVal,Zero,retVec);
	}
	
	public Polygon ScaleSize(float d)
	{
		int count=0;
		Vector[] retVec=new Vector[Len];
		foreach (Vector vec in vectors)
			retVec[count++]=vec.ScaleSize(d);
		return new Polygon(ZVal,Zero,retVec);		
	}
	
	public Polygon Transpose(Vector to)
	{
		int count=0;
		Vector[] retVec=new Vector[Len];
		foreach (Vector vec in vectors)
			retVec[count++]=vec.Add(to);
		return new Polygon(ZVal,Zero,retVec);				
	}
	
	public int Len
	{
		get
		{
			return vectors.Length;
		}
	}
	
	public Vector Zero
	{
		get 
		{
			return zeroVec;
		}
		set
		{
			zeroVec=value;
		}
		
	}

	public float ZVal
	{
		get 
		{
			return zVal;
		}
		set
		{
			zVal=value;
		}
		
	}
}

 
}
