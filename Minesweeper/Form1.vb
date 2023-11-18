Public Class Minesweeper
    Public MinesFound As Integer = 0
    Public Mines As Integer = 0
    Public FieldSize As Integer = 12
    Public FlagesPlaces As Integer = 0
    Public Field(30, 30) As Integer
    Public FieldsClicked As Integer = 0
    Public FirstClick As Boolean = True
    Public MinesPer100 As Integer = 20
    Public Reveal_Mode As Boolean = False
    Public FoundZero As Boolean = False
    Public Visited(30, 30) As Boolean
    Public Lost As Boolean
    Public radius As Integer = 1

    Private Sub Build_Fieled()
        Const buttonWidth As Integer = 25
        Const buttonHeight As Integer = 25
        Const spacing As Integer = 0

        For i As Integer = 0 To FieldSize - 1
            For j As Integer = 0 To FieldSize - 1
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
                newButton.ForeColor = Color.White
                newButton.BackColor = ColorTranslator.FromHtml("#9ea6e4")

                AddHandler newButton.MouseUp, AddressOf Button_MouseClick


                Me.Controls.Add(newButton)
            Next
        Next
    End Sub

    Private Sub Button_MouseClick(sender As Object, e As MouseEventArgs)
        If Lost Then
            Exit Sub
        End If
        Dim Button As CustomButton = DirectCast(sender, CustomButton)
        Dim Position As String = sender.tag
        Dim Pos_y As Integer = CInt(Position.Split("_")(0))
        Dim Pos_x As Integer = CInt(Position.Split("_")(1))
        If Visited(Pos_y, Pos_x) Then
            Exit Sub
        End If
        If FirstClick Then
            Fill_Field_Matrix(Pos_y, Pos_x)
            check_first_radius(Pos_y, Pos_x)

            If (radius * 2 + 1) ^ 2 < FieldsClicked Then
                FieldsClicked -= 1
                'MsgBox((radius * 2 + 1) ^ 2 & "     " & FieldsClicked)
            End If
            FirstClick = False
            _lbl_flages_left.Text = Mines - FlagesPlaces
                'Normal Right Click
            ElseIf e.Button = MouseButtons.Right Then
                If Button.Text = "" AndAlso FlagesPlaces < Mines Then
                    SetButtonTextColor(Button, "F")
                    If Field(Pos_y, Pos_x) >= 9 Then
                        MinesFound += 1
                    End If
                ElseIf Button.Text = "F" Then
                    SetButtonTextColor(Button, "")
                    If Field(Pos_y, Pos_x) >= 9 Then
                        MinesFound -= 1
                    End If
                End If
                _lbl_flages_left.Text = Mines - FlagesPlaces

                'Reveal Mode Enabled
            ElseIf Reveal_Mode Then
                FirstClick = False
                If Button.Text = "F" Then
                    Exit Sub
                End If
                If Field(Pos_y, Pos_x) >= 9 Then
                    SetButtonTextColor(Button, "F")
                    MinesFound += 1
                    _lbl_flages_left.Text = Mines - FlagesPlaces
                Else

                    CheckSurroundingZeros(Pos_y, Pos_x)
                End If
                Button.Refresh()

                'Normal Left Click
            Else
                'MsgBox("Y:" & Pos_y & " X: " & Pos_x & vbNewLine & "Value: " & Field(Pos_y, Pos_x))

                If Button.Text = "F" Then
                Exit Sub
            End If
            If Field(Pos_y, Pos_x) >= 9 Then
                Reveal_Mines()
                _lbl_start_lose.Text = "You Lose"
                Lost = True
                _lbl_start_lose.Refresh()
                lose_sound()
                FirstClick = True
                Exit Sub
            Else
                CheckSurroundingZeros(Pos_y, Pos_x)
            End If
        End If
        _lbl_debuge.Text = MinesFound & " == " & Mines & " AND " & (FieldSize * FieldSize) & " == " & FieldsClicked
        'MsgBox(MinesFound & " == " & Mines & " AND " & (FieldSize * FieldSize) & " == " & FieldsClicked)
        If MinesFound = Mines And (FieldSize * FieldSize) = FieldsClicked Then
            Reveal_Mines()
            _lbl_start_lose.Text = "You Win"
            _lbl_start_lose.Refresh()
            win_sound()
            FirstClick = True
        End If
    End Sub

    Private Sub DeleteButtonMatrix()
        Lost = False
        FieldsClicked = 0
        FlagesPlaces = 0
        MinesFound = 0
        Mines = 0
        _lbl_start_lose.Text = ""
        _lbl_flages_left.Text = ""

        For i As Integer = 0 To 30
            For j As Integer = 0 To 30
                Field(i, j) = 0
                Visited(i, j) = False
            Next
        Next

        Dim buttonsToDelete As New List(Of Control)

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is CustomButton AndAlso ctrl.Name.StartsWith("fld_") Then
                buttonsToDelete.Add(ctrl)
            End If
        Next

        ' Delete the collected buttons
        For Each button As Control In buttonsToDelete
            Me.Controls.Remove(button)
            button.Dispose()
        Next
    End Sub

    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click
        FirstClick = True
        If Integer.TryParse(_txt_size.Text, Nothing) Then
            FieldSize = CInt(_txt_size.Text)
            'MsgBox("Field Size: " & FieldSize)
            If FieldSize > 30 Then
                MsgBox("Please enter a valid Field Size (max 30)")
                Exit Sub
            End If
        Else
            MsgBox("Please enter a valid Field Size (max 30)")
            Exit Sub
        End If
        DeleteButtonMatrix()
        Build_Fieled()
        _lbl_flages_left.Text = ""
        _lbl_fields.Text = FieldSize * FieldSize
    End Sub

    Private Sub Fill_Field_Matrix(y, x)
        Mines = 0
        MinesFound = 0
        FlagesPlaces = 0
        Dim rand As New Random()
        Dim threshold As Double = 0.3

        If Integer.TryParse(_txt_minesp.Text, MinesPer100) Then
            threshold = MinesPer100 / 100
        End If
        For i As Integer = 0 To FieldSize - 1
            For j As Integer = 0 To FieldSize - 1
                If i = y AndAlso j = x Then
                    Exit For
                End If
                Dim randomValue As Double = rand.NextDouble()

                If randomValue < threshold Then

                    Field(i, j) = 9
                    Mines += 1
                    check_mine_radius(i, j)
                End If
            Next
        Next
        'MsgBox("Mines: " & Mines)
        _lbl_flages_left.Text = Mines
        'PrintArrayInMessageBox()
    End Sub

    Private Sub check_mine_radius(x, y)
        Dim Buttons As New List(Of String)

        Dim mine_radius As Integer = 1

        For i As Integer = -mine_radius To mine_radius
            For j As Integer = -mine_radius To mine_radius
                If i = 0 And j = 0 Then Continue For

                Buttons.Add("fld_" & (x + i) & "_" & (y + j))
            Next
        Next
        For Each btn As String In Buttons
            If Not Me.Controls.ContainsKey(btn) Then
                Continue For
            Else
                Field(CInt(btn.Split("_")(1)), CInt(btn.Split("_")(2))) += 1
            End If
        Next

    End Sub

    Private Sub check_first_radius(x, y)
        Dim Buttons As New List(Of String)
        Integer.TryParse(txt_helperr.Text, radius)

        For i As Integer = -radius To radius
            For j As Integer = -radius To radius
                If i = 0 And j = 0 Then Continue For
                Buttons.Add("fld_" & (x + i) & "_" & (y + j))
            Next
        Next
        For Each btn As String In Buttons
            Dim pos_x As Integer = CInt(btn.Split("_")(1))
            Dim pos_y As Integer = CInt(btn.Split("_")(2))
            If Not Me.Controls.ContainsKey(btn) Then
                Continue For
            End If
            If Field(pos_x, pos_y) >= 9 Then
                Dim CurBtn As CustomButton = DirectCast(Me.Controls.Item(btn), CustomButton)
                MinesFound += 1
                SetButtonTextColor(CurBtn, "F")
            Else
                Dim value As Integer = Field(pos_x, pos_y)
                CheckSurroundingZeros(pos_x, pos_y)
            End If
        Next

        SetButtonTextColor(Me.Controls.Item("fld_" & (x) & "_" & (y)), CStr(Field(x, y)))
        If FieldsClicked = (FieldSize * FieldSize) Then
            MsgBox("You Win")
            Reveal_Mines()
            FirstClick = True
        End If
    End Sub


    Private Sub Reveal_Mines()
        For i As Integer = 0 To FieldSize - 1
            For j As Integer = 0 To FieldSize - 1
                Dim button As CustomButton = DirectCast(Me.Controls("fld_" & i & "_" & j), CustomButton)
                button.Enabled = False
                If Field(i, j) >= 9 Then
                    button.Text = "X"
                    button.ForeColor = Color.Red
                End If
                button.Refresh()
            Next
        Next
    End Sub

    Private Sub reset_Click(sender As Object, e As EventArgs) Handles reset_btn.Click
        DeleteButtonMatrix()
        _txt_helperr.Text = 1
        _txt_size.Text = 12
        _lbl_flages_left.Text = ""
        _lbl_fields.Text = ""
        _lbl_start_lose.Text = ""
        FirstClick = True
        Mines = 0
        MinesFound = 0
        FieldSize = 12
        FlagesPlaces = 0
        FieldsClicked = 0
        FirstClick = True
        MinesPer100 = 20
        Reveal_Mode = False
        reveal_btn.Text = "Reveal: OFF"
        _txt_minesp.Text = MinesPer100
    End Sub

    Sub lose_sound()
        ' Loss melody
        Dim melodyFreq() As Integer = {784, 698, 659, 587, 523, 494, 440, 392}
        Dim noteDuration As Integer = 100

        For Each freq As Integer In melodyFreq
            Console.Beep(freq, noteDuration)
        Next
    End Sub

    Sub win_sound()
        ' Victory melody
        Dim melodyFreq() As Integer = {392, 440, 494, 523.0R, 587, 659, 698, 784}
        Dim noteDuration As Integer = 50

        For Each freq As Integer In melodyFreq
            Console.Beep(freq, noteDuration)
        Next
    End Sub

    Private Sub txt_minesp_TextChanged(sender As Object, e As EventArgs) Handles txt_minesp.TextChanged, txt_size.TextChanged, txt_helperr.TextChanged
        Dim TxtBox As TextBox = DirectCast(sender, TextBox)

        If Not Integer.TryParse(TxtBox.Text, Nothing) AndAlso TxtBox.Text.Length >= 1 Then
            TxtBox.Text = TxtBox.Text.Substring(0, TxtBox.Text.Length - 1)

        End If
    End Sub

    Private Sub reveal_btn_Click(sender As Object, e As EventArgs) Handles reveal_btn.Click
        If Reveal_Mode Then
            Reveal_Mode = False
            reveal_btn.Text = "Reveal: OFF"
        Else
            Reveal_Mode = True
            reveal_btn.Text = "Reveal: ON"
        End If
    End Sub

    Private Sub check_flags_btn_Click(sender As Object, e As EventArgs) Handles check_flags_btn.Click
        For i As Integer = 0 To FieldSize - 1
            For j As Integer = 0 To FieldSize - 1
                Dim btnName As String = "fld_" & i & "_" & j
                If Me.Controls.ContainsKey(btnName) Then
                    Dim btn As CustomButton = DirectCast(Me.Controls(btnName), CustomButton)

                    If btn.Text = "F" Then
                        If Not Field(i, j) >= 9 Then
                            SetButtonTextColor(btn, "")
                        End If
                    End If
                End If
            Next
        Next
        _lbl_flages_left.Text = Mines - FlagesPlaces
    End Sub

    Private Sub CheckSurroundingZeros(ByVal y As Integer, ByVal x As Integer)
        If y >= 0 AndAlso y < Field.GetLength(0) AndAlso x >= 0 AndAlso x < Field.GetLength(1) Then
            Dim controlName As String = "fld_" & y & "_" & x
            If Not Visited(y, x) Then
                If Me.Controls.ContainsKey(controlName) AndAlso TypeOf Me.Controls(controlName) Is CustomButton AndAlso Field(y, x) = 0 Then
                    Dim btn As CustomButton = DirectCast(Me.Controls(controlName), CustomButton)

                    If Not btn.Enabled = False Then
                        SetButtonTextColor(btn, "0")
                    Else
                        SetButtonTextColor(btn, CStr(Field(y, x)))
                        Visited(y, x) = True
                    End If

                    CheckSurroundingZeros(y - 1, x) ' Up
                    CheckSurroundingZeros(y + 1, x) ' Down
                    CheckSurroundingZeros(y, x - 1) ' Left
                    CheckSurroundingZeros(y, x + 1) ' Right
                    CheckSurroundingZeros(y - 1, x + 1) ' Top Rigth
                    CheckSurroundingZeros(y - 1, x - 1) ' Top Left
                    CheckSurroundingZeros(y + 1, x + 1) ' Buttom Right
                    CheckSurroundingZeros(y + 1, x - 1) ' Buttom Left



                ElseIf Me.Controls.ContainsKey(controlName) AndAlso TypeOf Me.Controls(controlName) Is CustomButton Then
                    Dim btn As CustomButton = DirectCast(Me.Controls(controlName), CustomButton)
                    SetButtonTextColor(btn, CStr(Field(y, x)))
                End If
            End If
        End If
    End Sub

    Public Sub SetButtonTextColor(btn As CustomButton, value As String)
        'MsgBox(value)
        FieldsClicked += 1
        If value = "F" Then
            btn.ForeColor = Color.White
            btn.BackColor = ColorTranslator.FromHtml("#5e5c67")
            btn.last_color = ColorTranslator.FromHtml("#5e5c67")
            btn.Text = value
            FlagesPlaces += 1
            btn.Refresh()
            Exit Sub
        ElseIf value.Length = 0 Then
            btn.BackColor = ColorTranslator.FromHtml("#9fa8e3")
            btn.last_color = ColorTranslator.FromHtml("#9fa8e3")
            btn.Text = value
            FieldsClicked -= 2
            FlagesPlaces -= 1
            btn.Refresh()
            Exit Sub
        End If

        If Visited(btn.Name.Split("_")(1), btn.Name.Split("_")(2)) Then
            Exit Sub
        Else
            Visited(btn.Name.Split("_")(1), btn.Name.Split("_")(2)) = True
        End If

        If CInt(value) <= 0 Then
            btn.ForeColor = Color.White
            btn.Text = ""
        ElseIf CInt(value) <= 1 Then
            btn.ForeColor = ColorTranslator.FromHtml("#0100fa")
            btn.Text = value
        ElseIf CInt(value) <= 2 Then
            btn.ForeColor = ColorTranslator.FromHtml("#007f00")
            btn.Text = value
        ElseIf CInt(value) <= 3 Then
            btn.ForeColor = ColorTranslator.FromHtml("#ea060a")
            btn.Text = value
        ElseIf CInt(value) <= 4 Then
            btn.ForeColor = ColorTranslator.FromHtml("#01007f")
            btn.Text = value
        ElseIf CInt(value) <= 5 Then
            btn.ForeColor = ColorTranslator.FromHtml("#7c0302")
            btn.Text = value
        ElseIf CInt(value) <= 6 Then
            btn.ForeColor = ColorTranslator.FromHtml("#00807f")
            btn.Text = value
        ElseIf CInt(value) <= 7 Then
            btn.ForeColor = Color.Black
            btn.Text = value
        ElseIf CInt(value) <= 8 Then
            btn.ForeColor = ColorTranslator.FromHtml("#808080")
            btn.Text = value
        End If
        btn.Enabled = False
        btn.Refresh()
    End Sub
End Class
