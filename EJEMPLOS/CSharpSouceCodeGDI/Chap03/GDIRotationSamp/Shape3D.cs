// created on 2/3/2002 at 6:11 PM
using System;
using System.Drawing;

namespace My3D
{

public class Shape3D : ICloneable
{
	private Polygon[] poly;
	
	public object Clone()
	{
		return new Shape3D(poly);
	}
	
	public Shape3D(params Polygon[] poly)
	{
		this.poly=poly;
	}
	
	public virtual void Draw(Graphics g)
	{
		foreach (Polygon p in poly)
			p.Draw(g);
	}
	
	public Shape3D Rotate(RotateMatrix mat)
	{
		int count=0;
		Polygon[] newP=new Polygon[poly.Length];
		foreach (Polygon p in poly)
			newP[count++]=p.Rotate(mat);
		return new Shape3D(newP);
	}
}

}
