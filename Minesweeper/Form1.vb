Public Class Minesweeper
    Private _minesFound As Integer = 0
    Private _mines As Integer = 0
    Private _fieldSize As Integer = 12
    Private _flagsPlaced As Integer = 0
    Private _field(30, 30) As Integer
    Private _fieldsClicked As Integer = 0
    Private _firstClick As Boolean = True
    Private _minesPer100 As Integer = 20
    Private _revealMode As Boolean = False
    Private _visited(30, 30) As Boolean
    Private _lost As Boolean
    Private _radius As Integer = 1

    Private Sub Build_Field()
        Const buttonWidth As Integer = 25
        Const buttonHeight As Integer = 25
        Const spacing As Integer = 0

        For i As Integer = 0 To _fieldSize - 1
            For j As Integer = 0 To _fieldSize - 1
                Dim newButton As New CustomButton With {
                    .Width = buttonWidth,
                    .Height = buttonHeight,
                    .Left = j * (buttonWidth + spacing) + 50,
                    .Top = i * (buttonHeight + spacing) + 120,
                    .Text = "",
                    .Tag = $"{i}_{j}",
                    .Name = $"fld_{i}_{j}"
                }
                newButton.Font = New Font(newButton.Font, FontStyle.Bold)
                'no boarder
                newButton.BorderStyle = BorderStyle.None
                newButton.ForeColor = ColorTranslator.FromHtml("#9ea6e4")
                newButton.BackColor = ColorTranslator.FromHtml("#9ea6e4")
                newButton.BorderColor = ColorTranslator.FromHtml("#9ea6e4")

                AddHandler newButton.MouseUp, AddressOf Button_MouseClick


                Controls.Add(newButton)
            Next
        Next
    End Sub

    Private Sub Button_MouseClick(sender As Object, e As MouseEventArgs)
        If _lost Then
            Exit Sub
        End If
        Dim button As CustomButton = DirectCast(sender, CustomButton)
        Dim position As String = sender.tag
        Dim posY As Integer = CInt(position.Split("_")(0))
        Dim posX As Integer = CInt(position.Split("_")(1))
        If _visited(posY, posX) AndAlso Not button.Text = ChrW(&H2691) Then
            Exit Sub
        End If
        If _firstClick Then
            Fill_Field_Matrix(posY, posX)
            check_first_radius(posY, posX)

            If (_radius * 2 + 1) ^ 2 < _fieldsClicked Then
                _fieldsClicked -= 1
                'MsgBox((_radius * 2 + 1) ^ 2 & "     " & _fieldsClicked)
            End If
            _firstClick = False
            _lbl_flages_left.Text = _mines - _flagsPlaced
            'Normal Right Click
        ElseIf e.Button = Mousebuttons.Right Then
            If button.Text = "" AndAlso _flagsPlaced < _mines Then
                SetButtonTextColor(button, ChrW(&H2691))
                If _field(posY, posX) >= 9 Then
                    _minesFound += 1
                End If
            ElseIf button.Text = CStr(ChrW(&H2691)) Then
                SetButtonTextColor(button, "")
                If _field(posY, posX) >= 9 Then
                    _minesFound -= 1
                End If
            End If
            _lbl_flages_left.Text = _mines - _flagsPlaced

            'Reveal Mode Enabled
        ElseIf _revealMode Then
            _firstClick = False
            If button.Text = ChrW(&H2691) Then
                Exit Sub
            End If
            If _field(posY, posX) >= 9 Then
                SetButtonTextColor(button, ChrW(&H2691))
                _minesFound += 1
                _lbl_flages_left.Text = _mines - _flagsPlaced
            Else
                CheckSurroundingZeros(posY, posX)
            End If
            button.Refresh()

            'Normal Left Click
        Else
            'MsgBox("Y:" & posY & " X: " & posX & vbNewLine & "Value: " & _field(posY, posX))

            If button.Text = ChrW(&H2691) Then
                Exit Sub
            End If
            If _field(posY, posX) >= 9 Then
                Reveal_Mines(posY, posX, _revealMode)
                _lbl_start_lose.Text = "You Lose"
                _lost = True
                _lbl_start_lose.Refresh()
                lose_sound()
                _firstClick = True
                Exit Sub
            Else
                CheckSurroundingZeros(posY, posX)
            End If
        End If
        '_lbl_debug.Text = _minesFound & " == " & _mines & " AND " & (_fieldSize * _fieldSize) & " == " & _fieldsClicked
        'MsgBox(_minesFound & " == " & _mines & " AND " & (_fieldSize * _fieldSize) & " == " & _fieldsClicked)
        If _minesFound = _mines And (_fieldSize * _fieldSize) = _fieldsClicked Then
            Reveal_Mines(posY, posX, _revealMode)
            _lbl_start_lose.Text = "You Win"
            _lbl_start_lose.Refresh()
            win_sound()
            _firstClick = True
        End If
    End Sub

    Private Sub DeleteButtonMatrix()
        _lost = False
        _fieldsClicked = 0
        _flagsPlaced = 0
        _minesFound = 0
        _mines = 0
        _lbl_start_lose.Text = ""
        _lbl_flages_left.Text = ""

        For i As Integer = 0 To 30
            For j As Integer = 0 To 30
                _field(i, j) = 0
                _visited(i, j) = False
            Next
        Next

        Dim buttonsToDelete As New List(Of Control)

        For Each ctrl As Control In Controls
            If TypeOf ctrl Is CustomButton AndAlso ctrl.Name.StartsWith("fld_") Then
                buttonsToDelete.Add(ctrl)
            End If
        Next

        ' Delete the collected buttons
        For Each button As Control In buttonsToDelete
            Controls.Remove(button)
            button.Dispose()
        Next
    End Sub
    
    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click
        _firstClick = True
        If Integer.TryParse(_txt_size.Text, Nothing) Then
            _fieldSize = CInt(_txt_size.Text)
            'MsgBox("Field Size: " & _fieldSize)
            If _fieldSize > 30 Then
                MsgBox("Please enter a valid Field Size (max 30)")
                Exit Sub
            End If
        Else
            MsgBox("Please enter a valid Field Size (max 30)")
            Exit Sub
        End If
        DeleteButtonMatrix()
        Build_Field()
        _lbl_flages_left.Text = ""
        _lbl_fields.Text = _fieldSize * _fieldSize
    End Sub

    Private Sub Fill_Field_Matrix(y, x)
        _mines = 0
        _minesFound = 0
        _flagsPlaced = 0
        Dim rand As New Random()
        Dim threshold As Double = 0.3

        If Integer.TryParse(_txt_minesp.Text, _minesPer100) Then
            threshold = _minesPer100 / 100
        End If
        For i As Integer = 0 To _fieldSize - 1
            For j As Integer = 0 To _fieldSize - 1
                If i = y AndAlso j = x Then
                    Exit For
                End If
                Dim randomValue As Double = rand.NextDouble()

                If randomValue < threshold Then

                    _field(i, j) = 9
                    _mines += 1
                    check_mineRadius(i, j)
                End If
            Next
        Next
        'MsgBox("Mines: " & _mines)
        _lbl_flages_left.Text = _mines
        'PrintArrayInMessageBox()
    End Sub

    Private Sub check_mineRadius(x, y)
        Dim buttons As New List(Of String)

        Dim mineRadius As Integer = 1

        For i As Integer = -mineRadius To mineRadius
            For j As Integer = -mineRadius To mineRadius
                If i = 0 And j = 0 Then Continue For

                buttons.Add("fld_" & (x + i) & "_" & (y + j))
            Next
        Next
        For Each btn As String In buttons
            If Not Controls.ContainsKey(btn) Then
                Continue For
            Else
                _field(CInt(btn.Split("_")(1)), CInt(btn.Split("_")(2))) += 1
            End If
        Next

    End Sub

    Private Sub check_first_radius(x, y)
        Dim buttons As New List(Of String)
        Integer.TryParse(txt_helperr.Text, _radius)

        For i As Integer = -_radius To _radius
            For j As Integer = -_radius To _radius
                If i = 0 And j = 0 Then Continue For
                buttons.Add("fld_" & (x + i) & "_" & (y + j))
            Next
        Next
        For Each btn As String In buttons
            Dim posX As Integer = CInt(btn.Split("_")(1))
            Dim posY As Integer = CInt(btn.Split("_")(2))
            If Not Controls.ContainsKey(btn) Then
                Continue For
            End If
            If _field(posX, posY) >= 9 Then
                Dim curBtn As CustomButton = DirectCast(Controls.Item(btn), CustomButton)
                _minesFound += 1
                SetButtonTextColor(curBtn, ChrW(&H2691))
            Else
                CheckSurroundingZeros(posX, posY)
            End If
        Next

        SetButtonTextColor(Controls.Item("fld_" & (x) & "_" & (y)), CStr(_field(x, y)))
        If _fieldsClicked = (_fieldSize * _fieldSize) Then
            MsgBox("You Win")
            Reveal_Mines(-1, -1, _revealMode)
            _firstClick = True
        End If
    End Sub


    Private Sub Reveal_Mines(a As Integer, b As Integer, revMode As Boolean)
        For i As Integer = 0 To _fieldSize - 1
            For j As Integer = 0 To _fieldSize - 1
                Dim button As CustomButton = DirectCast(Controls("fld_" & i & "_" & j), CustomButton)
                button.Enabled = False
                'MsgBox("i: " & i & " j: " & j & " value: " & _field(i, j) & " visited: " & _visited(i, j))
                If _field(i, j) >= 9 AndAlso _visited(i, j) Then
                    button.Text = "X"
                    button.ForeColor = Color.Black
                    button.BackColor = ColorTranslator.FromHtml("#62636d")
                    button.BorderColor = ColorTranslator.FromHtml("#62636d")
                ElseIf _field(i, j) >= 9 Then
                    button.Text = "X"
                    button.ForeColor = Color.Black
                    button.BackColor = ColorTranslator.FromHtml("#9ea6e4")
                ElseIf _visited(i, j) AndAlso button.Text = ChrW(&H2691) Then
                    button.ForeColor = Color.Black
                    button.BackColor = ColorTranslator.FromHtml("#62636d")
                ElseIf Not _visited(i, j) Then
                    button.BackColor = ColorTranslator.FromHtml("#9ea6e4")
                End If


                button.Refresh()
            Next
        Next
        If a = b = -1 Or revMode Or _minesFound = _mines Then
            Exit Sub
        End If
        Dim btn As CustomButton = DirectCast(Controls("fld_" & a & "_" & b), CustomButton)
        btn.BackColor = Color.Red
        btn.BorderColor = Color.Transparent
    End Sub

    Private Sub reset_Click(sender As Object, e As EventArgs) Handles reset_btn.Click
        DeleteButtonMatrix()
        _txt_helperr.Text = 1
        _txt_size.Text = 12
        _lbl_flages_left.Text = ""
        _lbl_fields.Text = ""
        _lbl_start_lose.Text = ""
        _firstClick = True
        _mines = 0
        _minesFound = 0
        _fieldSize = 12
        _flagsPlaced = 0
        _fieldsClicked = 0
        _firstClick = True
        _minesPer100 = 20
        _revealMode = False
        reveal_btn.Text = "Reveal: OFF"
        _txt_minesp.Text = _minesPer100
    End Sub

    Private Sub lose_sound()
        ' Loss melody
        Dim melodyFreq() As Integer = {784, 698, 659, 587, 523, 494, 440, 392}
        Dim noteDuration As Integer = 100

        For Each freq As Integer In melodyFreq
            Console.Beep(freq, noteDuration)
        Next
    End Sub

    Private Sub win_sound()
        ' Victory melody
        Dim melodyFreq() As Integer = {392, 440, 494, 523.0R, 587, 659, 698, 784}
        Dim noteDuration As Integer = 50

        For Each freq As Integer In melodyFreq
            Console.Beep(freq, noteDuration)
        Next
    End Sub

    Private Sub txt_mines_per_TextChanged(sender As Object, e As EventArgs) Handles txt_minesp.TextChanged, txt_size.TextChanged, txt_helperr.TextChanged
        Dim txtBox As TextBox = DirectCast(sender, TextBox)

        If Not Integer.TryParse(txtBox.Text, Nothing) AndAlso txtBox.Text.Length >= 1 Then
            txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1)

        End If
    End Sub

    Private Sub reveal_btn_Click(sender As Object, e As EventArgs) Handles reveal_btn.Click
        If _revealMode Then
            _revealMode = False
            reveal_btn.Text = "Reveal: OFF"
        Else
            _revealMode = True
            reveal_btn.Text = "Reveal: ON"
        End If
    End Sub

    Private Sub check_flags_btn_Click(sender As Object, e As EventArgs) Handles check_flags_btn.Click
        For i As Integer = 0 To _fieldSize - 1
            For j As Integer = 0 To _fieldSize - 1
                Dim btnName As String = "fld_" & i & "_" & j
                If Controls.ContainsKey(btnName) Then
                    Dim btn As CustomButton = DirectCast(Controls(btnName), CustomButton)

                    If btn.Text = ChrW(&H2691) Then
                        If Not _field(i, j) >= 9 Then
                            SetButtonTextColor(btn, "")
                        End If
                    End If
                End If
            Next
        Next
        _lbl_flages_left.Text = _mines - _flagsPlaced
    End Sub

    Private Sub CheckSurroundingZeros(ByVal y As Integer, ByVal x As Integer)
        If y >= 0 AndAlso y < _field.GetLength(0) AndAlso x >= 0 AndAlso x < _field.GetLength(1) Then
            Dim controlName As String = "fld_" & y & "_" & x
            If Not _visited(y, x) Then
                If Controls.ContainsKey(controlName) AndAlso TypeOf Controls(controlName) Is CustomButton AndAlso _field(y, x) = 0 Then
                    Dim btn As CustomButton = DirectCast(Controls(controlName), CustomButton)

                    If Not btn.Enabled = False Then
                        SetButtonTextColor(btn, "0")
                    Else
                        SetButtonTextColor(btn, CStr(_field(y, x)))
                        _visited(y, x) = True
                    End If

                    CheckSurroundingZeros(y - 1, x) ' Up
                    CheckSurroundingZeros(y + 1, x) ' Down
                    CheckSurroundingZeros(y, x - 1) ' Left
                    CheckSurroundingZeros(y, x + 1) ' Right
                    CheckSurroundingZeros(y - 1, x + 1) ' Top Right
                    CheckSurroundingZeros(y - 1, x - 1) ' Top Left
                    CheckSurroundingZeros(y + 1, x + 1) ' Bottom Right
                    CheckSurroundingZeros(y + 1, x - 1) ' Bottom Left



                ElseIf Controls.ContainsKey(controlName) AndAlso TypeOf Controls(controlName) Is CustomButton Then
                    Dim btn As CustomButton = DirectCast(Controls(controlName), CustomButton)
                    SetButtonTextColor(btn, CStr(_field(y, x)))
                End If
            End If
        End If
    End Sub

    Private Sub SetButtonTextColor(btn As CustomButton, value As String)
        'MsgBox(value)
        _fieldsClicked += 1
        If value = ChrW(&H2691) Then
            btn.ForeColor = ColorTranslator.FromHtml("#1b1c21")
            btn.BackColor = ColorTranslator.FromHtml("#5e5c67")
            btn.LastColor = ColorTranslator.FromHtml("#5e5c67")
            btn.BorderColor = ColorTranslator.FromHtml("#5e5c67")
            btn.Text = ChrW(&H2691)
            _flagsPlaced += 1
            _visited(btn.Name.Split("_")(1), btn.Name.Split("_")(2)) = True
            btn.Refresh()
            Exit Sub
        ElseIf value.Length = 0 Then
            btn.ForeColor = ColorTranslator.FromHtml("#62636d")
            btn.BackColor = ColorTranslator.FromHtml("#9fa8e3")
            btn.LastColor = ColorTranslator.FromHtml("#9fa8e3")
            btn.BorderColor = ColorTranslator.FromHtml("#9fa8e3")
            btn.Text = value
            _fieldsClicked -= 2
            _flagsPlaced -= 1
            btn.Refresh()
            _visited(btn.Name.Split("_")(1), btn.Name.Split("_")(2)) = False
            Exit Sub
        End If

        If _visited(btn.Name.Split("_")(1), btn.Name.Split("_")(2)) Then
            Exit Sub
        Else
            _visited(btn.Name.Split("_")(1), btn.Name.Split("_")(2)) = True
        End If
        btn.BorderColor = ColorTranslator.FromHtml("#62636d")
        'border radius to 1
        btn.CornerRadius = 5

        If CInt(value) <= 0 Then
            btn.Text = ""
        ElseIf CInt(value) <= 1 Then
            btn.ForeColor = ColorTranslator.FromHtml("#4140FB")
            btn.Text = value
        ElseIf CInt(value) <= 2 Then
            btn.ForeColor = ColorTranslator.FromHtml("#409F40")
            btn.Text = value
        ElseIf CInt(value) <= 3 Then
            btn.ForeColor = ColorTranslator.FromHtml("#EF4447")
            btn.Text = value
        ElseIf CInt(value) <= 4 Then
            btn.ForeColor = ColorTranslator.FromHtml("#41409F")
            btn.Text = value
        ElseIf CInt(value) <= 5 Then
            btn.ForeColor = ColorTranslator.FromHtml("#9D4241")
            btn.Text = value
        ElseIf CInt(value) <= 6 Then
            btn.ForeColor = ColorTranslator.FromHtml("#40A09F")
            btn.Text = value
        ElseIf CInt(value) <= 7 Then
            btn.ForeColor = Color.Black
            btn.Text = value
        ElseIf CInt(value) <= 8 Then
            btn.ForeColor = ColorTranslator.FromHtml("#A0A0A0")
            btn.Text = value
        End If
        btn.Enabled = False
        btn.Refresh()
    End Sub
End Class
