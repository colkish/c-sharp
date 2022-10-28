Imports Microsoft.VisualBasic.Devices


Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Play()
    End Sub

    Public Sub Play()
        My.Computer.Audio.Play("C:\Users\ckish.admin\Downloads\got_s3e9_apologies1.wav", AudioPlayMode.Background)
    End Sub

End Class

