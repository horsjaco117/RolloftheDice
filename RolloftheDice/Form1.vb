Public Class Form1
 Dim beanCounter(12) As Integer
    Sub diceRoll()
        'Dim beanCounter(12) As Integer
        TestRandomness(beanCounter) 'This runs the random number generator
        'DisplayBoard(beanCounter) 'Things are organized into a board
    End Sub

    Sub TestRandomness(ByRef beanCounter() As Integer) 'Random generator

        For i = 1 To 1000

            beanCounter(randomNumberBetween(1, 13)) += 1 'the return is the pointer for the array

        Next

    End Sub


    Function randomNumberBetween(max As Integer, min As Integer) As Integer
            Dim temp As Single 'The single type helps work with the randomize stuff
            Randomize()
            temp = Rnd()
            temp = temp * (max - min + 1) + min
            Return CInt(Math.Floor(temp)) 'min isn't included
        End Function


    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        diceRoll()

        ListBox1.Items.Add("Test Line")
        ' Display results in ListBox
        ListBox1.Items.Add("Dice Roll Results:")
        ListBox1.Items.Add("Roll  | Count")
        ListBox1.Items.Add("-----------------")

        For i = 2 To 12
            ListBox1.Items.Add(i.ToString().PadRight(5) & " | " & beanCounter(i).ToString())
        Next

    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
