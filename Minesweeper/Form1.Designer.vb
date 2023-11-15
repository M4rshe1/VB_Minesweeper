<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Minesweeper
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txt_size = New System.Windows.Forms.TextBox()
        Me.btn_start = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_flages_left = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_minesp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_fields = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txt_size
        '
        Me.txt_size.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_size.Location = New System.Drawing.Point(52, 26)
        Me.txt_size.Name = "txt_size"
        Me.txt_size.Size = New System.Drawing.Size(126, 38)
        Me.txt_size.TabIndex = 1
        '
        'btn_start
        '
        Me.btn_start.Location = New System.Drawing.Point(354, 26)
        Me.btn_start.Name = "btn_start"
        Me.btn_start.Size = New System.Drawing.Size(65, 38)
        Me.btn_start.TabIndex = 2
        Me.btn_start.Text = "Start"
        Me.btn_start.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(425, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 38)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Reset"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Flages: "
        '
        'lbl_flages_left
        '
        Me.lbl_flages_left.AutoSize = True
        Me.lbl_flages_left.Location = New System.Drawing.Point(104, 67)
        Me.lbl_flages_left.Name = "lbl_flages_left"
        Me.lbl_flages_left.Size = New System.Drawing.Size(0, 16)
        Me.lbl_flages_left.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Field Size X*X"
        '
        'txt_minesp
        '
        Me.txt_minesp.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_minesp.Location = New System.Drawing.Point(184, 26)
        Me.txt_minesp.Name = "txt_minesp"
        Me.txt_minesp.Size = New System.Drawing.Size(106, 38)
        Me.txt_minesp.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(181, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Mines per 100"
        '
        'lbl_fields
        '
        Me.lbl_fields.AutoSize = True
        Me.lbl_fields.Location = New System.Drawing.Point(104, 92)
        Me.lbl_fields.Name = "lbl_fields"
        Me.lbl_fields.Size = New System.Drawing.Size(0, 16)
        Me.lbl_fields.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fields:"
        '
        'Minesweeper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 537)
        Me.Controls.Add(Me.lbl_fields)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_minesp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_flages_left)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_start)
        Me.Controls.Add(Me.txt_size)
        Me.Name = "Minesweeper"
        Me.Text = "Minesweeper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_size As TextBox
    Friend WithEvents btn_start As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_flages_left As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_minesp As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lbl_fields As Label
    Friend WithEvents Label5 As Label
End Class
