// created on 1/31/2002 at 2:41 PM
namespace My3D
{

using MyMath;

interface IRotateMatrix
{
	IMatrix Rotate(IMatrix vec);
}

public abstract class RotateMatrix : Matrix, IRotateMatrix
{
	public RotateMatrix():base(3,3)
	{
	}
	public abstract IMatrix Rotate(IMatrix vec);
}
	
public class ZRotate : RotateMatrix
{
	public ZRotate(double d):base()
	{
		SetAngle(d);
	}
	
	public void SetAngle(double d)
	{
		SetNum(0,0,System.Math.Cos(d));	
		SetNum(1,0,-System.Math.Sin(d));	
		SetNum(2,0,0);	
		SetNum(0,1,System.Math.Sin(d));	
		SetNum(1,1,System.Math.Cos(d));	
		SetNum(2,1,0);	
		SetNum(0,2,0);	
		SetNum(1,2,0);	
		SetNum(2,2,1);			
	}
	
	public override IMatrix Rotate(IMatrix vec)
	{
		return Mul(vec);
	}
}

public class XRotate : RotateMatrix
{	
	public XRotate(double d):base()
	{
		SetAngle(d);
	}
	
	public void SetAngle(double d)
	{
		SetNum(0,0,1);	
		SetNum(1,0,0);	
		SetNum(2,0,0);	
		SetNum(0,1,0);	
		SetNum(1,1,System.Math.Cos(d));	
		SetNum(2,1,System.Math.Sin(d));	
		SetNum(0,2,0);	
		SetNum(1,2,-System.Math.Sin(d));	
		SetNum(2,2,System.Math.Cos(d));			
	}
	
	public override IMatrix Rotate(IMatrix vec)
	{
		return Mul(vec);
	}
}

public class YRotate : RotateMatrix
{
	public YRotate(double d):base()
	{
		SetAngle(d);
	}
	
	public void SetAngle(double d)
	{
		SetNum(0,0,System.Math.Cos(d));	
		SetNum(1,0,0);	
		SetNum(2,0,-System.Math.Sin(d));	
		SetNum(0,1,0);	
		SetNum(1,1,1);	
		SetNum(2,1,0);	
		SetNum(0,2,System.Math.Sin(d));	
		SetNum(1,2,0);	
		SetNum(2,2,System.Math.Cos(d));			
	}
	
	public override IMatrix Rotate(IMatrix vec)
	{
		return Mul(vec);
	}
}

}
