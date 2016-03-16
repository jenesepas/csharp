<%@ Page ContentType="image/gif" %>
<%@ Import namespace="System.Drawing" %>
<%@ Import namespace="System.Drawing.Imaging" %>

<Script Runat="Server">

Sub Page_Load
  Dim objBitmap As Bitmap
  Dim objGraphics As Graphics
  Dim objPen As Pen
  Dim strAction As String
  Dim strColor As String
  Dim objColor As Color
  Dim intOldX, intOldY As Integer 
  Dim intNewX, intNewY As Integer

  ' Create or Retrieve Bitmap
  objBitmap = Session( "Canvas" )
  If objBitmap Is Nothing Then
    objBitmap = New Bitmap( 600, 400, PixelFormat.Format32bppARGB )
  End If
  objGraphics  = Graphics.FromImage( objBitmap )

  ' Get Action, Color, and Coordinates
  strAction = Request.QueryString( "a" )
  strColor = Request.QueryString( "color" )
  intNewX = Request.QueryString( "x" )
  intNewY = Request.QueryString( "y" )
  intOldX = Session( "OldX" )
  intOldY = Session( "OldY" )

  ' Create Pen
  If strColor <> Nothing Then
    objColor = Color.FromName( strColor )
    objPen = New Pen( objColor )
  Else
    objColor = Color.White
    objPen = New Pen( objColor )
  End If

  ' Perform Action
  Select Case strAction
    Case "SetPixel"
      objBitMap.SetPixel( intNewX, intNewY, objColor )
    Case "DrawLine"
      If intOldX <> Nothing Then
        objGraphics.DrawLine( objPen, intOldX, intOldY, intNewX, intNewY )
      End If
    Case "DrawLine"
      If intOldX <> Nothing Then
        objGraphics.DrawLine( objPen, intOldX, intOldY, intNewX, intNewY )
      End If
    Case "DrawRectangle"
      If intOldX <> Nothing Then
        objGraphics.DrawRectangle( objPen, intOldX, intOldY, intNewX - intOldX, intNewY - intOldY )
      End If
    Case "FillRectangle"
      If intOldX <> Nothing Then
        objGraphics.FillRectangle( New SolidBrush( objColor ), intOldX, intOldY, intNewX - intOldX, intNewY - intOldY )
      End If
  End Select

  ' Display the Bitmap
  objBitmap.Save( Response.OutputStream, ImageFormat.GIF)

  ' Save the Bitmap
  Session( "Canvas" ) = objBitMap

  If Session( "OldX" ) <> Nothing Then
    Session( "OldX" ) = Nothing
    Session( "OldY" ) = Nothing
  Else
    Session( "OldX" ) = intNewX
    Session( "OldY" ) = intNewY
  End If
End Sub

</Script>
