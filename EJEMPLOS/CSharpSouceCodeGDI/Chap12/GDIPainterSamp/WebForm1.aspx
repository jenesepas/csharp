<%@ Import Namespace="System.Drawing" %>
<HTML>
	<HEAD>
		<title>Painter.aspx</title>
		<Script Runat="Server">

Sub Page_Load
  If Not IsPostBack Then
    ibtnCanvas.ImageUrl = "PaintImage.aspx"
    lstColor.DataSource = System.Enum.GetValues( GetType( KnownColor ) )
    lstColor.SelectedIndex = 0
    lstAction.SelectedIndex = 0
    DataBind()
  End If
End Sub

Sub ibtnCanvas_Click( s As Object, e As ImageClickEventArgs )
  Dim strQueryString As String

  strQueryString &= "a=" & lstAction.SelectedItem.Text
  strQueryString &= "&color=" & lstColor.SelectedItem.Text
  strQueryString &= "&x=" & e.X
  strQueryString &= "&y=" & e.y
  ibtnCanvas.ImageUrl = "PaintImage.aspx?" & strQueryString
End Sub

Sub btnClear_Click( s As Object, e As EventArgs )
  Session( "Canvas" ) = Nothing
  ibtnCanvas.ImageURL = "PaintImage.aspx"
End Sub

		</Script>
	</HEAD>
	<body>
		<form Runat="Server" ID="Form1">
			<table width="100%">
				<tr>
					<td valign="top">
						<h3>Draw:</h3>
						<asp:ListBox ID="lstAction" Runat="Server">
							<asp:ListItem Text="SetPixel" />
							<asp:ListItem Text="DrawLine" />
							<asp:ListItem Text="DrawRectangle" />
							<asp:ListItem Text="FillRectangle" />
						</asp:ListBox>
						<h3>Color:</h3>
						<asp:ListBox id="lstColor" Runat="Server" />
						<p>
							<asp:Button id="btnClear" Text="Clear All" OnClick="btnClear_Click" Runat="Server" /></p>
					</td>
					<td valign="top">
						<asp:ImageButton id="ibtnCanvas" OnClick="ibtnCanvas_Click" Runat="Server" />
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
