Public Class CustomButton
    Inherits Panel ' or Label, or any other control you prefer

    Private _enabled As Boolean = True

    Public Sub New()
        ' Set default properties
        Me.Size = New Size(100, 30)
        Me.BackColor = ColorTranslator.FromHtml("#9ea6e4")
        Me.ForeColor = Color.White
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.Cursor = Cursors.Hand

        AddHandler Me.MouseEnter, AddressOf OnMouseEnter
        AddHandler Me.MouseLeave, AddressOf OnMouseLeave
        AddHandler Me.Click, AddressOf OnClick
        AddHandler Me.MouseUp, AddressOf OnClick
    End Sub

    Public Shadows Property Enabled As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
            Me.BackColor = If(value, ColorTranslator.FromHtml("#9ea6e4"), Color.Transparent)
            Me.CornerRadius = If(value, 0, 3)
            Me.Refresh()

            If Not value Then
                Me.Cursor = Cursors.Default
            End If
        End Set
    End Property
    Public _last_color As Color
    Private Sub OnMouseEnter(sender As Object, e As EventArgs)
        If _enabled Then
            _last_color = Me.BackColor
            Dim alpha As Integer = CInt(255 * 0.8)
            Dim newBackColor As Color = Color.FromArgb(alpha, _last_color.R, _last_color.G, _last_color.B)
            Me.BackColor = newBackColor
        End If
        Me.Refresh()
    End Sub

    Private Sub OnMouseLeave(sender As Object, e As EventArgs)
        If _enabled Then
            Me.BackColor = _last_color
        End If
        Me.Refresh()
    End Sub

    Private Sub OnClick(sender As Object, e As EventArgs)
        If _enabled Then

        End If
        Me.Refresh()
    End Sub
    Private _buttonText As String = ""
    Public Overrides Property Text As String
        Get
            Return _buttonText
        End Get
        Set(value As String)
            _buttonText = value
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is Label Then
                    DirectCast(ctrl, Label).Text = _buttonText
                    Exit For
                End If
            Next
        End Set
    End Property

    Private _cornerRadius As Integer = 1

    Public Property CornerRadius As Integer
        Get
            Return _cornerRadius
        End Get
        Set(value As Integer)
            _cornerRadius = value
            Me.Refresh()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Using brush As New SolidBrush(Me.ForeColor)
            Using format As New StringFormat()
                format.Alignment = StringAlignment.Center
                format.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(_buttonText, Me.Font, brush, New RectangleF(0, 0, Me.Width, Me.Height), format)
            End Using
        End Using

        Dim path As New Drawing2D.GraphicsPath()
        path.AddArc(0, 0, _cornerRadius * 2, _cornerRadius * 2, 180, 90)
        path.AddArc(Me.Width - _cornerRadius * 2, 0, _cornerRadius * 2, _cornerRadius * 2, 270, 90)
        path.AddArc(Me.Width - _cornerRadius * 2, Me.Height - _cornerRadius * 2, _cornerRadius * 2, _cornerRadius * 2, 0, 90)
        path.AddArc(0, Me.Height - _cornerRadius * 2, _cornerRadius * 2, _cornerRadius * 2, 90, 90)
        Me.Region = New Region(path)
    End Sub
End Class