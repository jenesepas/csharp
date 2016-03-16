<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Drawing2D" %>
<%@ Import Namespace="System.Drawing.Imaging" %>

<script language="C#" runat="server">

void Page_Load(Object sender, EventArgs e) 
{
Pen redPen = new Pen(Color.Red, 3);
HatchBrush brush = new HatchBrush(HatchStyle.Cross,
Color.Red, Color.Yellow);
Pen hatchPen = new Pen(brush, 2);
Bitmap curBitmap = new Bitmap(200, 200);
Graphics g = Graphics.FromImage(curBitmap);
g.FillRectangle(brush, 50, 50, 100, 100);
g.DrawLine(Pens.WhiteSmoke, 10, 10, 180, 10);
g.DrawLine(Pens.White, 10, 10, 10, 180);
curBitmap.Save(Response.OutputStream, ImageFormat.Gif);
g.Dispose();
}

</script> 
