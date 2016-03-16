// created on 1/28/2002 at 11:47 PM
using MyMath;

namespace My3D
{
public class Vector : IMatrix
{
	private float cX, cY, cZ;
	
	public Vector(float x, float y, float z)
	{
		X=x;
		Y=y;
		Z=z;
	}
	
	public float X
	{
		get
		{
			return cX;
		}
		set
		{
			cX=value;
		}
	}
	
	public float Y
	{
		get
		{
			return cY;
		}
		set
		{
			cY=value;
		}
	}
	
	public float Z
	{
		get
		{
			return cZ;
		}
		set
		{
			cZ=value;
		}
	}
	
	//public object Clone()
	
	public Vector Rotate(RotateMatrix rot)
	{
		return (Vector)rot.Rotate(this);
	}
	
	public Vector ScaleSize(float s)
	{
		return new Vector(X*s,Y*s,Z*s);
	}
	
	public Vector Add(Vector v)
	{
		return new Vector(X+v.X, Y+v.Y, Z+v.Z);
	}
	
	public Vector Sub(Vector v)
	{
		return new Vector(X-v.X, Y-v.Y, Z-v.Z);
	}
	
	public double GetNum(int x, int y)
	{
		switch(y) {
			case 0:	
				return (double)X;
			case 1:
				return (double)Y;
			case 2:
				return (double)Z;
		}
		throw (new System.Exception());
	}

	public void SetNum(int x, int y, double num)
	{
		switch(y) {
			case 0:	
				X=(float)num;
			break;
			case 1:
				Y=(float)num;
			break;
			case 2:
				Z=(float)num;
			break;
		}
	}
	
	public int SizeX
	{
		get
		{
			return 1;
		}
		set
		{			
			if (value!=3) throw (new System.Exception());
		}
	}

	public int SizeY
	{
		get
		{
			return 3;
		}
		set
		{
			if (value!=3) throw (new System.Exception());
		}
	}
	
	public object Clone()
	{
		return new Vector(X, Y, Z);
	}
	
	public virtual void Draw()
	{
		System.Console.WriteLine("({0},{1},{2})",X,Y,Z);
	}
	
}


}
