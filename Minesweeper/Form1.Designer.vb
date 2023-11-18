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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Minesweeper))
        Me.txt_size = New System.Windows.Forms.TextBox()
        Me.btn_start = New System.Windows.Forms.Button()
        Me.reset_btn = New System.Windows.Forms.Button()
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
        Me.reveal_btn = New System.Windows.Forms.Button()
        Me.check_flags_btn = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_debuge = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txt_size
        '
        Me.txt_size.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txt_size.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_size.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.txt_size.Location = New System.Drawing.Point(23, 31)
        Me.txt_size.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_size.Name = "txt_size"
        Me.txt_size.Size = New System.Drawing.Size(96, 32)
        Me.txt_size.TabIndex = 1
        Me.txt_size.Text = "12"
        '
        'btn_start
        '
        Me.btn_start.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btn_start.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_start.Location = New System.Drawing.Point(290, 31)
        Me.btn_start.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_start.Name = "btn_start"
        Me.btn_start.Size = New System.Drawing.Size(49, 32)
        Me.btn_start.TabIndex = 2
        Me.btn_start.Text = "Start"
        Me.btn_start.UseVisualStyleBackColor = False
        '
        'reset_btn
        '
        Me.reset_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.reset_btn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.reset_btn.Location = New System.Drawing.Point(343, 31)
        Me.reset_btn.Margin = New System.Windows.Forms.Padding(2)
        Me.reset_btn.Name = "reset_btn"
        Me.reset_btn.Size = New System.Drawing.Size(49, 32)
        Me.reset_btn.TabIndex = 3
        Me.reset_btn.Text = "Reset"
        Me.reset_btn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(21, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Flages: "
        '
        'lbl_flages_left
        '
        Me.lbl_flages_left.AutoSize = True
        Me.lbl_flages_left.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lbl_flages_left.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_flages_left.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.lbl_flages_left.Location = New System.Drawing.Point(62, 64)
        Me.lbl_flages_left.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_flages_left.Name = "lbl_flages_left"
        Me.lbl_flages_left.Size = New System.Drawing.Size(0, 17)
        Me.lbl_flages_left.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(21, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Field Size"
        '
        'txt_minesp
        '
        Me.txt_minesp.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txt_minesp.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_minesp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.txt_minesp.Location = New System.Drawing.Point(122, 31)
        Me.txt_minesp.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_minesp.Name = "txt_minesp"
        Me.txt_minesp.Size = New System.Drawing.Size(80, 32)
        Me.txt_minesp.TabIndex = 7
        Me.txt_minesp.Text = "20"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(120, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Mines per 100"
        '
        'lbl_fields
        '
        Me.lbl_fields.AutoSize = True
        Me.lbl_fields.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lbl_fields.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fields.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.lbl_fields.Location = New System.Drawing.Point(161, 65)
        Me.lbl_fields.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_fields.Name = "lbl_fields"
        Me.lbl_fields.Size = New System.Drawing.Size(0, 17)
        Me.lbl_fields.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(120, 65)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fields:"
        '
        'lbl_start_lose
        '
        Me.lbl_start_lose.AutoSize = True
        Me.lbl_start_lose.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lbl_start_lose.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_start_lose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.lbl_start_lose.Location = New System.Drawing.Point(576, 31)
        Me.lbl_start_lose.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_start_lose.Name = "lbl_start_lose"
        Me.lbl_start_lose.Size = New System.Drawing.Size(0, 26)
        Me.lbl_start_lose.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(204, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Helper Field r"
        '
        'txt_helperr
        '
        Me.txt_helperr.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txt_helperr.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_helperr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.txt_helperr.Location = New System.Drawing.Point(206, 31)
        Me.txt_helperr.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_helperr.Name = "txt_helperr"
        Me.txt_helperr.Size = New System.Drawing.Size(80, 32)
        Me.txt_helperr.TabIndex = 12
        Me.txt_helperr.Text = "1"
        '
        'reveal_btn
        '
        Me.reveal_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.reveal_btn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.reveal_btn.Location = New System.Drawing.Point(396, 31)
        Me.reveal_btn.Margin = New System.Windows.Forms.Padding(2)
        Me.reveal_btn.Name = "reveal_btn"
        Me.reveal_btn.Size = New System.Drawing.Size(95, 32)
        Me.reveal_btn.TabIndex = 14
        Me.reveal_btn.Text = "Reveal: OFF"
        Me.reveal_btn.UseVisualStyleBackColor = False
        '
        'check_flags_btn
        '
        Me.check_flags_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.check_flags_btn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.check_flags_btn.Location = New System.Drawing.Point(495, 31)
        Me.check_flags_btn.Margin = New System.Windows.Forms.Padding(2)
        Me.check_flags_btn.Name = "check_flags_btn"
        Me.check_flags_btn.Size = New System.Drawing.Size(74, 32)
        Me.check_flags_btn.TabIndex = 15
        Me.check_flags_btn.Text = "Check Flags"
        Me.check_flags_btn.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(396, 16)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Reveal Mode"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(21, 87)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Debuge:"
        '
        'lbl_debuge
        '
        Me.lbl_debuge.AutoSize = True
        Me.lbl_debuge.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lbl_debuge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_debuge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.lbl_debuge.Location = New System.Drawing.Point(87, 87)
        Me.lbl_debuge.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_debuge.Name = "lbl_debuge"
        Me.lbl_debuge.Size = New System.Drawing.Size(0, 17)
        Me.lbl_debuge.TabIndex = 18
        '
        'Minesweeper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(700, 436)
        Me.Controls.Add(Me.lbl_debuge)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.check_flags_btn)
        Me.Controls.Add(Me.reveal_btn)
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
        Me.Controls.Add(Me.reset_btn)
        Me.Controls.Add(Me.btn_start)
        Me.Controls.Add(Me.txt_size)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Minesweeper"
        Me.Text = "Minesweeper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_size As TextBox
    Friend WithEvents btn_start As Button
    Friend WithEvents reset_btn As Button
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
    Friend WithEvents reveal_btn As Button
    Friend WithEvents check_flags_btn As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lbl_debuge As Label
End Class
