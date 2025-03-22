Imports System.Windows.Markup

Public Class Form1
    Dim diceCounter(12) As Integer
    Sub diceRoll()

        RandomGen(diceCounter) 'This runs the random number generator

    End Sub

    Sub RandomGen(ByRef diceCounter() As Integer) 'Random generator

        For i = 1 To 1000

            diceCounter(randomNumberBetween(1, 13)) += 1 'the return is the pointer for the array
        Next

    End Sub

    Function randomNumberBetween(max As Integer, min As Integer) As Integer
        Dim temp As Single 'The single type helps work with the randomize stuff
        Randomize()
        temp = Rnd()
        temp = temp * (max - min + 1) + min
        Return CInt(Math.Floor(temp)) 'min isn't included
    End Function

    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        diceRoll()

        Dim header As String = ""
        Dim width As Integer = 6

        ListBox1.Items.Clear()
        ListBox1.Items.Add("Roll of The Dice")
        ListBox1.Items.Add("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -")

        ' Horizontal Header settings
        For i = 2 To 12
            header &= i.ToString().PadLeft(width) & " |" 'the padding helps align the top row
        Next
        ListBox1.Items.Add(header)

        ListBox1.Items.Add("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -")

        ' This adds in the values for both rows
        Dim values As String = ""
        For i = 2 To 12
            values &= diceCounter(i).ToString().PadLeft(width) & "| " 'Align the bottom row
        Next
        ListBox1.Items.Add(values)

        ListBox1.Items.Add("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -")

    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click

        ListBox1.Items.Clear()
        Array.Clear(diceCounter, 0, diceCounter.Length)

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click
        MsgBox("You found an Easter Egg!")
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        MsgBox("Hit the buttons and see which numbers appear")
    End Sub
End Class
