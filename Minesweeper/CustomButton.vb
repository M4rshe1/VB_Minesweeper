Imports System.Drawing
Imports System.Windows.Forms

Public Class CustomButton
    Inherits Panel

    Private _enabled As Boolean = True
    Private _cornerRadius As Integer = 0
    Private _borderThickness As Integer = 0
    Private _borderColor As Color = Color.Black
    Public LastColor As Color

    Public Sub New()
        ' Set default properties
        Me.Size = New Size(100, 30)
        Me.BackColor = ColorTranslator.FromHtml("#9ea6e4")
        Me.ForeColor = Color.White
        Me.BorderStyle = BorderStyle.None
        Me.Cursor = Cursors.Hand

        AddHandler Me.MouseEnter, AddressOf OnMouseEnter
        AddHandler Me.MouseLeave, AddressOf OnMouseLeave
        AddHandler Me.Click, AddressOf OnClick
        AddHandler Me.MouseUp, AddressOf OnClick
    End Sub

    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Refresh()
        End Set
    End Property

    Public Shadows Property Enabled As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
            UpdateAppearance()
        End Set
    End Property

    Public Property CornerRadius As Integer
        Get
            Return _cornerRadius
        End Get
        Set(value As Integer)
            _cornerRadius = value
            Me.Refresh()
        End Set
    End Property

    Public Property BorderThickness As Integer
        Get
            Return _borderThickness
        End Get
        Set(value As Integer)
            _borderThickness = value
            Me.Refresh()
        End Set
    End Property

    Private _buttonText As String = ""
    Public Overrides Property Text As String
        Get
            Return _buttonText
        End Get
        Set(value As String)
            _buttonText = value
            Me.Refresh()
        End Set
    End Property

    Private Sub UpdateAppearance()
        Me.BackColor = If(_enabled, ColorTranslator.FromHtml("#9ea6e4"), Color.Transparent)
        Me.Cursor = If(_enabled, Cursors.Hand, Cursors.Default)
        Me.Refresh()
    End Sub

    Private Sub OnMouseEnter(sender As Object, e As EventArgs)
        If _enabled Then
            LastColor = Me.BackColor ' Store the current color
            ' Implement mouse hover effect if needed
            Dim alpha As Integer = CInt(255 * 0.8)
            Dim newBackColor As Color = Color.FromArgb(alpha, LastColor.R, LastColor.G, LastColor.B)
            Me.BackColor = newBackColor
        End If
    End Sub

    Private Sub OnMouseLeave(sender As Object, e As EventArgs)
        If _enabled Then
            ' Restore the last color on mouse leave
            Me.BackColor = LastColor
        End If
    End Sub

    Private Sub OnClick(sender As Object, e As EventArgs)
        If _enabled Then
            ' Implement click action if needed
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim borderRect As New Rectangle(_borderThickness, _borderThickness, Me.Width - 2 * _borderThickness, Me.Height - 2 * _borderThickness)

        Using brush As New SolidBrush(Me.ForeColor)
            Using format As New StringFormat()
                format.Alignment = StringAlignment.Center
                format.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(_buttonText, Me.Font, brush, borderRect, format)
            End Using
        End Using

        Dim borderPen As New Pen(_borderColor, _borderThickness)
        e.Graphics.DrawRectangle(borderPen, borderRect)

        If _cornerRadius > 0 Then
            CreateRoundCorners()
        End If
    End Sub

    Private Sub CreateRoundCorners()
        Dim path As New Drawing2D.GraphicsPath()
        Dim arcRect As New Rectangle(0, 0, _cornerRadius * 2, _cornerRadius * 2)

        ' Top left arc
        path.AddArc(arcRect, 180, 90)

        ' Top right arc
        arcRect.X = Me.Width - _cornerRadius * 2
        path.AddArc(arcRect, 270, 90)

        ' Bottom right arc
        arcRect.Y = Me.Height - _cornerRadius * 2
        path.AddArc(arcRect, 0, 90)

        ' Bottom left arc
        arcRect.X = 0
        path.AddArc(arcRect, 90, 90)

        path.CloseFigure()
        Me.Region = New Region(path)
    End Sub
End Class
