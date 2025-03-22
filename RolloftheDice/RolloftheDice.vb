'Jacob Horsley
'RCET 0265
'Spring 2025
'Address Label Program
'URL: https://github.com/horsjaco117/RolloftheDice

Option Strict On
Option Explicit On

Imports System.Windows.Markup



Public Class RolloftheDice
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

    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click 'Clicking this button displays all values 
        diceRoll()

        Dim header As String = ""
        Dim width As Integer = 6

        ListBox1.Items.Clear() 'values cleared
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

        'as the numbers add up the spaces don't line up. 
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click 'Info cleared

        ListBox1.Items.Clear() 'shuts off screen
        Array.Clear(diceCounter, 0, diceCounter.Length) 'Resets number

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click 'Closes the program
        Me.Close()
    End Sub

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click
        MsgBox("You found an Easter Egg!") 'Instructions didn't specify menu content
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        MsgBox("Hit the buttons and see which numbers appear") 'Shows help
    End Sub
End Class
