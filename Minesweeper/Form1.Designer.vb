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
        Me.lbl_start_lose = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_helperr = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txt_size
        '
        Me.txt_size.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_size.Location = New System.Drawing.Point(39, 21)
        Me.txt_size.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_size.Name = "txt_size"
        Me.txt_size.Size = New System.Drawing.Size(96, 32)
        Me.txt_size.TabIndex = 1
        Me.txt_size.Text = "8"
        '
        'btn_start
        '
        Me.btn_start.Location = New System.Drawing.Point(306, 21)
        Me.btn_start.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_start.Name = "btn_start"
        Me.btn_start.Size = New System.Drawing.Size(49, 32)
        Me.btn_start.TabIndex = 2
        Me.btn_start.Text = "Start"
        Me.btn_start.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(359, 21)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(49, 32)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Reset"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 54)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Flages: "
        '
        'lbl_flages_left
        '
        Me.lbl_flages_left.AutoSize = True
        Me.lbl_flages_left.Location = New System.Drawing.Point(78, 54)
        Me.lbl_flages_left.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_flages_left.Name = "lbl_flages_left"
        Me.lbl_flages_left.Size = New System.Drawing.Size(0, 13)
        Me.lbl_flages_left.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Field Size"
        '
        'txt_minesp
        '
        Me.txt_minesp.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_minesp.Location = New System.Drawing.Point(138, 21)
        Me.txt_minesp.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_minesp.Name = "txt_minesp"
        Me.txt_minesp.Size = New System.Drawing.Size(80, 32)
        Me.txt_minesp.TabIndex = 7
        Me.txt_minesp.Text = "30"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(136, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Mines per 100"
        '
        'lbl_fields
        '
        Me.lbl_fields.AutoSize = True
        Me.lbl_fields.Location = New System.Drawing.Point(177, 55)
        Me.lbl_fields.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_fields.Name = "lbl_fields"
        Me.lbl_fields.Size = New System.Drawing.Size(0, 13)
        Me.lbl_fields.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 55)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fields:"
        '
        'lbl_start_lose
        '
        Me.lbl_start_lose.AutoSize = True
        Me.lbl_start_lose.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_start_lose.Location = New System.Drawing.Point(460, 27)
        Me.lbl_start_lose.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_start_lose.Name = "lbl_start_lose"
        Me.lbl_start_lose.Size = New System.Drawing.Size(0, 26)
        Me.lbl_start_lose.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(220, 6)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Helper Field r"
        '
        'txt_helperr
        '
        Me.txt_helperr.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_helperr.Location = New System.Drawing.Point(222, 21)
        Me.txt_helperr.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_helperr.Name = "txt_helperr"
        Me.txt_helperr.Size = New System.Drawing.Size(80, 32)
        Me.txt_helperr.TabIndex = 12
        Me.txt_helperr.Text = "1"
        '
        'Minesweeper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 436)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_helperr)
        Me.Controls.Add(Me.lbl_start_lose)
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
        Me.Margin = New System.Windows.Forms.Padding(2)
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
    Friend WithEvents lbl_start_lose As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_helperr As TextBox
End Class
