Imports System.Text

Public Class Form1

    Dim mistakes As Integer

    Private word As String = "CURCAN"
    Private wordToShow As New StringBuilder

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim tmp As String
        Dim regex As New RegularExpressions.Regex("[A-Z]")

        While True
            tmp = InputBox("Witch word ? (A-Z only)")
            If regex.IsMatch(tmp) Then
                word = tmp
                Exit While
            End If
        End While

        start()
    End Sub

    Sub drawThings()
        Dim g As Graphics
        g = Me.CreateGraphics
        'scaffolding
        g.DrawLine(Pens.Black, 50, 50, 50, 400)
        g.DrawLine(Pens.Black, 50, 50, 200, 50)
        g.DrawLine(Pens.Black, 200, 50, 200, 90)
        'head
        If mistakes = 1 Then
            g.DrawEllipse(Pens.Green, 150, 90, 100, 100)
        End If

        'body
        If mistakes = 2 Then
            g.DrawLine(Pens.Orange, 200, 190, 200, 300)
        End If

        'handL
        If mistakes = 3 Then
            g.DrawLine(Pens.Red, 200, 240, 230, 190)
        End If

        'handR
        If mistakes = 4 Then
            g.DrawLine(Pens.Red, 200, 240, 170, 190)
        End If


        'footR
        If mistakes = 5 Then
            g.DrawLine(Pens.Red, 200, 300, 230, 400)
        End If

        'footL
        If mistakes = 6 Then
            g.DrawLine(Pens.Red, 200, 300, 170, 400)
        End If




    End Sub

    Sub start()
        mistakes = 0

        For i As Integer = 1 To word.Length
            wordToShow.Append("_")
        Next


        Label1.Text = wordToShow.ToString

        drawThings()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click,
        Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click,
        Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button32.Click, Button33.Click, Button34.Click,
        Button35.Click, Button36.Click, Button37.Click, Button38.Click

        Dim b As Button = CType(sender, Button)
        b.Enabled = False

        Dim position As Integer = word.IndexOf(b.Text)
        If position > -1 Then
            For i As Integer = 0 To word.Length - 1
                If word(i) = b.Text Then
                    wordToShow(i) = b.Text
                    Label1.Text = wordToShow.ToString
                End If
            Next
        Else
            mistakes = mistakes + 1
            drawThings()
        End If

        If Not wordToShow.ToString().Contains("_") Then
            win()
        End If
        If mistakes = 6 Then
            lost()
        End If

    End Sub

    Private Sub win()
        MsgBox("won !")
    End Sub

    Private Sub lost()
        MsgBox("Lost !")
    End Sub

End Class
