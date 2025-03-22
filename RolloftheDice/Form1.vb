Imports System.Windows.Markup

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

        ListBox1.Items.Clear()
        ListBox1.Items.Add("Roll of The Dice")
        ListBox1.Items.Add("- - - - - - - - - - - - - - - - - - - - -")

        ' Horizontal Header settings
        Dim header As String = ""
        For i = 2 To 12
            header &= i.ToString().PadRight(6) & "| " 'the padding helps align the top row
        Next
        ListBox1.Items.Add(header)

        ' This adds in the values for both rows
        Dim values As String = ""
        For i = 2 To 12
            values &= beanCounter(i).ToString().PadRight(5) & "| " 'Align the bottom row
        Next
        ListBox1.Items.Add(values)
    End Sub


    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
