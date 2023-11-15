Public Class Minesweeper
    Public MinesFound As Integer = 0
    Public Mines As Integer = 0
    Public FieldSize As Integer = 12
    Public FlagesPlaces As Integer = 0
    Public Field(30, 30) As Integer
    Public FieldsClicked As Integer = 0
    Public ClickedMines As Integer = 0
    Public WrongClicks As Integer = 0
    Public FirstClick As Boolean = True
    Public MinesPer100 As Integer = 30


    Private Sub Button_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button_MouseClick(sender As Object, e As MouseEventArgs)
        'Right-click event handling logic
        Dim Button As Button = DirectCast(sender, Button)
        Dim Position As String = sender.tag
        Dim Pos_y As Integer = CInt(Position.Split("_")(0))
        Dim Pos_x As Integer = CInt(Position.Split("_")(1))
        If FirstClick Then
            Fill_Field_Matrix(Pos_y, Pos_x)
            FirstClick = False
        End If

        If e.Button = MouseButtons.Right Then
            If Button.Text = "" AndAlso FlagesPlaces < Mines Then
                Button.Text = "F"
                Button.ForeColor = Color.Red
                FlagesPlaces += 1
                FieldsClicked += 1
                If Field(Pos_y, Pos_x) >= 9 Then
                    MinesFound += 1
                End If
            ElseIf Button.Text = "F" Then
                Button.Text = ""
                Button.ForeColor = Color.Black
                FlagesPlaces -= 1
                FieldsClicked -= 1
                If Field(Pos_y, Pos_x) >= 9 Then
                    MinesFound -= 1
                End If
            End If
            _lbl_flages_left.Text = Mines - FlagesPlaces
        Else
            If FirstClick Then
                Fill_Field_Matrix(Pos_y, Pos_x)
                FirstClick = False
            End If

            FieldsClicked += 1
            'MsgBox("Y:" & Pos_y & " X: " & Pos_x & vbNewLine & "Value: " & Field(Pos_y, Pos_x))

            If Button.Text = "F" Then
                Exit Sub
            End If
            If Field(Pos_y, Pos_x) >= 9 Then
                lose_sound()
                MsgBox("You Lose")
                Reveal_Mines()
                FirstClick = True
                Exit Sub
            Else
                Button.Text = Field(Pos_y, Pos_x)
                Button.Enabled = False
            End If
        End If

        If MinesFound = Mines And (FieldSize * FieldSize) = FieldsClicked Then
            win_sound()
            MsgBox("You Win")
            Reveal_Mines()
            FirstClick = True
        End If
    End Sub

    Private Sub DeleteButtonMatrix()

        For i As Integer = 0 To 30
            For j As Integer = 0 To 30
                Field(i, j) = 0
            Next
        Next

        Dim buttonsToDelete As New List(Of Control)

        ' Collect buttons with a specific naming pattern
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button AndAlso ctrl.Name.StartsWith("fld_") Then
                buttonsToDelete.Add(ctrl)
            End If
        Next

        ' Delete the collected buttons
        For Each button As Control In buttonsToDelete
            Me.Controls.Remove(button)
            button.Dispose() ' Optional: Dispose to release resources
        Next
    End Sub

    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click
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


    Private Sub Build_Fieled()
        Const buttonWidth As Integer = 25
        Const buttonHeight As Integer = 25
        Const spacing As Integer = 2

        For i As Integer = 0 To FieldSize - 1
            For j As Integer = 0 To FieldSize - 1
                Dim newButton As New Button()

                ' Set properties for the button
                newButton.Width = buttonWidth
                newButton.Height = buttonHeight
                newButton.Left = j * (buttonWidth + spacing) + 50
                newButton.Top = i * (buttonHeight + spacing) + 100
                newButton.Text = ""
                newButton.Tag = $"{i}_{j}"
                newButton.Name = $"fld_{i}_{j}"

                ' Add click event handler if needed
                AddHandler newButton.Click, AddressOf Button_Click
                AddHandler newButton.MouseUp, AddressOf Button_MouseClick

                ' Add the button to the form
                Me.Controls.Add(newButton)
            Next
        Next
    End Sub

    Private Sub Fill_Field_Matrix(y, x)
        Mines = 0
        MinesFound = 0
        FlagesPlaces = 0
        Integer.TryParse(_txt_minesp.Text, MinesPer100)
        Dim rand As New Random()
        Dim threshold As Double = 0.3 ' 30% chance for 9

        For i As Integer = 0 To FieldSize - 1
            For j As Integer = 0 To FieldSize - 1
                If i = y AndAlso j = x Then
                    Exit For
                End If                ' Generate a random number between 0 and 1
                Dim randomValue As Double = rand.NextDouble()
                ' Check if the random number falls below the threshold
                If randomValue < threshold Then
                    ' Assign 9 if the random number is below the threshold
                    Field(i, j) = 9
                    Mines += 1
                    check_mine_radius(i, j)
                    'Else
                    ' Assign 0 if the random number is above the threshold
                    '    Field(i, j) = 0
                End If
            Next
        Next
        'MsgBox("Mines: " & Mines)
        _lbl_flages_left.Text = Mines
        'PrintArrayInMessageBox()
    End Sub

    Private Sub PrintArrayInMessageBox()
        Dim output As String = ""

        For i As Integer = 0 To Field.GetUpperBound(0) ' Iterate through rows
            Dim rowString As String = ""

            For j As Integer = 0 To Field.GetUpperBound(1) ' Iterate through columns
                rowString &= Field(i, j).ToString() & " " ' Add each element to the row string
            Next

            output &= rowString.Trim() & vbCrLf ' Add the row to the output string with a newline
        Next

        MessageBox.Show(output) ' Display the whole array in a message box
    End Sub

    Private Sub check_mine_radius(x, y)
        Try
            If Integer.TryParse(Field(x - 1, y), Nothing) Then
                Field(x - 1, y) = CInt(Field(x - 1, y)) + 1
            End If
        Catch ex As Exception

        End Try

        Try
            If Integer.TryParse(Field(x - 1, y - 1), Nothing) Then
                Field(x - 1, y - 1) = CInt(Field(x - 1, y - 1)) + 1
            End If
        Catch ex As Exception

        End Try

        Try
            If Integer.TryParse(Field(x, y - 1), Nothing) Then
                Field(x, y - 1) = CInt(Field(x, y - 1)) + 1
            End If
        Catch ex As Exception

        End Try

        Try
            If Integer.TryParse(Field(x + 1, y), Nothing) Then
                Field(x + 1, y) = CInt(Field(x + 1, y)) + 1
            End If
        Catch ex As Exception

        End Try

        Try
            If Integer.TryParse(Field(x + 1, y + 1), Nothing) Then
                Field(x + 1, y + 1) = CInt(Field(x + 1, y + 1)) + 1
            End If
        Catch ex As Exception

        End Try

        Try
            If Integer.TryParse(Field(x, y + 1), Nothing) Then
                Field(x, y + 1) = CInt(Field(x, y + 1)) + 1
            End If
        Catch ex As Exception

        End Try

        Try
            If Integer.TryParse(Field(x - 1, y + 1), Nothing) Then
                Field(x - 1, y + 1) = CInt(Field(x - 1, y + 1)) + 1
            End If
        Catch ex As Exception

        End Try

        Try
            If Integer.TryParse(Field(x + 1, y - 1), Nothing) Then
                Field(x + 1, y - 1) = CInt(Field(x + 1, y - 1)) + 1
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Reveal_Mines()
        For i As Integer = 0 To FieldSize - 1
            For j As Integer = 0 To FieldSize - 1
                Dim button As Button = DirectCast(Me.Controls("fld_" & i & "_" & j), Button)
                button.Enabled = False
                If Field(i, j) >= 9 Then
                    'get button with name fld_(i)_(j)
                    button.Text = "X"
                    button.ForeColor = Color.Red
                End If
            Next
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DeleteButtonMatrix()
        For i As Integer = 0 To FieldSize - 1
            For j As Integer = 0 To FieldSize - 1
                Field(i, j) = 0
            Next
        Next
    End Sub

    Sub lose_sound()
        ' Loss melody
        Dim melodyFreq() As Integer = {784, 698, 659, 587, 523, 494, 440, 392} ' Frequencies of the melody notes
        Dim noteDuration As Integer = 300 ' Duration of each note in milliseconds

        For Each freq As Integer In melodyFreq
            Console.Beep(freq, noteDuration)
        Next
    End Sub

    Sub win_sound()
        ' Victory melody
        Dim melodyFreq() As Integer = {392, 440, 494, 523, 587, 659, 698, 784} ' Frequencies of the melody notes
        Dim noteDuration As Integer = 300 ' Duration of each note in milliseconds

        For Each freq As Integer In melodyFreq
            Console.Beep(freq, noteDuration)
        Next
    End Sub
End Class
