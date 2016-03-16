Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(8, 8)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(176, 120)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "Button1"
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 128)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(272, 136)
    Me.DataGrid1.TabIndex = 1
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(352, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1, Me.Button1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
  Private Sub FormPaintEvent(ByVal sender As Object, _
  ByVal args As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
    ' Write your code here
    args.Graphics.DrawRectangle(New Pen(Color.Blue, 3), _
    New Rectangle(10, 10, 50, 50))
    args.Graphics.FillEllipse(Brushes.Red, _
    New Rectangle(60, 60, 100, 100))
    args.Graphics.DrawString("Text", New Font("Verdana", 14), _
    New SolidBrush(Color.Green), 200, 200)
  End Sub


  Private Sub TheButtonPaintEventHandler(ByVal sender As Object, _
  ByVal btnArgs As System.Windows.Forms.PaintEventArgs) Handles Button1.Paint
    btnArgs.Graphics.FillEllipse(Brushes.Blue, 10, 10, 100, 100)
  End Sub

  Private Sub TheDataGridPaintEventHandler(ByVal sender As Object, _
ByVal dtGridArgs As System.Windows.Forms.PaintEventArgs) Handles DataGrid1.Paint
    dtGridArgs.Graphics.FillEllipse(Brushes.Blue, 10, 10, 100, 100)
  End Sub

End Class
