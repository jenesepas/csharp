// project created on 1/27/2002 at 11:11 PM
using System;
using MyMath;
using My3D;
using System.Drawing;
using System.Windows.Forms; 

public class MainClass : Form
{
	Shape3D Cube;
	Shape3D Circle;
	Shape3D Axis;
	Shape3D currentShape;
	float changex=0.0F;
	float changey=0.0F;
	float changez=0.0F;
	Timer tm;
	Label t1, t2, t3;
	RotateMatrix Zmat;
	RotateMatrix Ymat;
	RotateMatrix Xmat;
	bool stop=false;
	Button b7=new Button();
	
	public MainClass()
	{
		Xmat=new XRotate(changex);
		Ymat=new YRotate(changey);
		Zmat=new ZRotate(changez);
		Size=new Size(400,260);
		Text="  Hellllo 3D!";
		FormBorderStyle=FormBorderStyle.FixedToolWindow;
		MaximizeBox=false;
		Button b1=new Button();
		b1.Text="Add X axis Speed";
		b1.Size=new Size(115,25);
		b1.Click+=new EventHandler(moreX);
		Controls.Add(b1);
		Button b2=new Button();
		b2.Text="Add Y axis Speed";
		b2.Size=new Size(115,25);
		b2.Location=new Point(0,25);
		b2.Click+=new EventHandler(moreY);
		Controls.Add(b2);
		Button b3=new Button();
		b3.Text="Add Z axis Speed";
		b3.Size=new Size(115,25);
		b3.Location=new Point(0,50);
		b3.Click+=new EventHandler(moreZ);
		Controls.Add(b3);
		Button b4=new Button();
		b4.Text="Less X axis Speed";
		b4.Size=new Size(115,25);
		b4.Location=new Point(0,75);
		b4.Click+=new EventHandler(lessX);
		Controls.Add(b4);
		Button b5=new Button();
		b5.Text="Less Y axis Speed";
		b5.Size=new Size(115,25);
		b5.Location=new Point(0,100);
		b5.Click+=new EventHandler(lessY);
		Controls.Add(b5);
		Button b6=new Button();
		b6.Text="Less Z axis Speed";
		b6.Size=new Size(115,25);
		b6.Location=new Point(0,125);
		b6.Click+=new EventHandler(lessZ);
		Controls.Add(b6);
		b7.Text="Stop !!!";
		b7.Size=new Size(115,25);
		b7.Location=new Point(0,150);
		b7.Click+=new EventHandler(Stop);
		Controls.Add(b7);
		RadioButton b8=new RadioButton();
		b8.Text="CUBE";
		b8.Size=new Size(195,25);
		b8.Location=new Point(250,210);
		b8.BackColor=Color.White;
		b8.Checked=false;
		b8.CheckedChanged+=new EventHandler(shapeCube);
		Controls.Add(b8);
		RadioButton b9=new RadioButton();
		b9.Text="Sphere";
		b9.Checked=false;
		b9.Size=new Size(75,25);
		b9.BackColor=Color.White;
		b9.Location=new Point(115,210);
		b9.CheckedChanged+=new EventHandler(shapeSphere);
		Controls.Add(b9);
		RadioButton b10=new RadioButton();
		b10.Text="Axis";
		b10.Checked=true;
		b10.Size=new Size(115,25);
		b10.BackColor=Color.White;
		b10.Location=new Point(190,210);
		b10.CheckedChanged+=new EventHandler(shapeAxis);
		Controls.Add(b10);
		t1=new Label();
		t2=new Label();
		t3=new Label();
		t1.Size=new Size(115,20);
		t2.Size=new Size(115,20);
		t3.Size=new Size(115,20);
		t1.Location=new Point(0,175);
		t2.Location=new Point(0,195);
		t3.Location=new Point(0,215);
		t1.BackColor=Color.White;
		t2.BackColor=Color.White;
		t3.BackColor=Color.White;
		Controls.Add(t1);
		Controls.Add(t2);
		Controls.Add(t3);
		
		SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		SetStyle(ControlStyles.DoubleBuffer, true);
		
		Vector z=new Vector(250,105,1000);
		Vector[] points1=new Vector[4];
		Vector[] points2=new Vector[4];
		Vector[] points3=new Vector[4];
		Vector[] points4=new Vector[4];
		
		Polygon poly1,poly2,poly3,poly4;
		
		// building the axis shape;
		points1[0]=new Vector(-100,0,0);
		points1[1]=new Vector(100,0,0);
		
		points2[0]=new Vector(0,-100,0);
		points2[1]=new Vector(0,100,0);
		
		points3[0]=new Vector(0,0,-100);		
		points3[1]=new Vector(0,0,100);
		poly1=new Polygon(1000,z,points1[0],points1[1]);
		poly2=new Polygon(1000,z,points2[0],points2[1]);
		poly3=new Polygon(1000,z,points3[0],points3[1]);
		Axis=new Shape3D(poly1,poly2,poly3);
		
		// building the Cube shape;
		points1[0]=new Vector(0,0,50);
		points1[1]=new Vector(0,50,50);
		points1[2]=new Vector(50,50,50);
		points1[3]=new Vector(50,0,50);
		poly1=new Polygon(1000,z,points1);
		poly1=poly1.Transpose(new Vector(-5,-5,-30));
		
		
		points2[0]=new Vector(0,0,50);
		points2[1]=new Vector(0,0,100);
		points2[2]=new Vector(0,50,100);
		points2[3]=new Vector(0,50,50);
		poly2=new Polygon(1000,z,points2);
		poly2=poly2.Transpose(new Vector(-5,-5,-30));
	
		points3[0]=new Vector(0,0,100);
		points3[1]=new Vector(0,50,100);
		points3[2]=new Vector(50,50,100);
		points3[3]=new Vector(50,0,100);
		poly3=new Polygon(1000,z,points3);
		poly3=poly3.Transpose(new Vector(-5,-5,-30));
		
		points4[0]=new Vector(50,0,50);
		points4[1]=new Vector(50,0,100);
		points4[2]=new Vector(50,50,100);
		points4[3]=new Vector(50,50,50);
		poly4=new Polygon(1000,z,points4);
		poly4=poly4.Transpose(new Vector(-5,-5,-30));
		Cube=new Shape3D(poly1,poly2,poly3,poly4);
		
		// building the Cube shape;
		Polygon[] p = new Polygon[130];
		poly1=poly1.Transpose(new Vector(-30,-30,-100));
		for (int count=0;count<p.Length;count++) {
			p[count]=poly1.Rotate(new ZRotate(System.Math.PI/20*count)).Rotate(new XRotate(System.Math.PI/60*count)).Rotate(new YRotate(System.Math.PI/180*count));
		}
		Circle=new Shape3D(p);
		
		
		this.Paint+=new System.Windows.Forms.PaintEventHandler(MyPaint);
		this.Click+=new EventHandler(MyClick);
				
		
		currentShape=Axis;
		
		tm=new Timer();
		tm.Interval=10;
		tm.Tick+=new EventHandler(tmEvent);
		tm.Start();		
	}
	

	private void shapeSphere(object sender, System.EventArgs e)
	{
		currentShape=Circle;
		Invalidate(new Rectangle(135,0,235,210));
	}
	private void shapeCube(object sender, System.EventArgs e)
	{
		currentShape=Cube;
		Invalidate(new Rectangle(135,0,235,210));
	}
	private void shapeAxis(object sender, System.EventArgs e)
	{
		currentShape=Axis;
		Invalidate(new Rectangle(135,0,235,210));
	}
	
	private void moreX(object sender, System.EventArgs e)
	{
		changex+=0.006F;
		Xmat=new XRotate(changex);
	}
	private void moreY(object sender, System.EventArgs e)
	{
		changey+=0.006F;
		Ymat=new YRotate(changey);
	}
	private void moreZ(object sender, System.EventArgs e)
	{
		changez+=0.006F;
		Zmat=new ZRotate(changez);
	}
	private void lessX(object sender, System.EventArgs e)
	{
		changex-=0.006F;
		Xmat=new XRotate(changex);
	}
	private void lessY(object sender, System.EventArgs e)
	{
		changey-=0.006F;
		Ymat=new YRotate(changey);
	}
	private void lessZ(object sender, System.EventArgs e)
	{
		changez-=0.006F;
		Zmat=new ZRotate(changez);
	}
	private void Stop(object sender, System.EventArgs e)
	{
		stop=!stop;
		if (stop)
		{
			tm.Stop();
			b7.Text="Continue";
		}
		else
		{
			tm.Start();
			b7.Text="Stop!";
		}
	}
	private void tmEvent(object sender, System.EventArgs e)
	{
		Invalidate(new Rectangle(135,0,235,210));
	}
	
	public void MyClick(object sender, EventArgs e)
	{
		changey=-changey;		
		changex=-changex;		
		changez=-changez;	
		Xmat=new XRotate(changex);
		Ymat=new YRotate(changey);
		Zmat=new ZRotate(changez);
	}
	
	public void MyPaint(object sender, PaintEventArgs e)
	{
		t1.Text="X speed: "+changex.ToString();
		t2.Text="Y speed: "+changey.ToString();
		t3.Text="Z speed: "+changez.ToString();
		currentShape=currentShape.Rotate(Zmat).Rotate(Xmat).Rotate(Ymat);
		currentShape.Draw(e.Graphics);
	}

	public static void Main(string[] args)
	{
		Application.Run(new MainClass());
	}
}
