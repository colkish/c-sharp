Imports System
Imports System.Media 'used tools->nuget package manager to add
Imports VBFromsApp
Imports Microsoft.VisualBasic.Devices
Imports System.Windows.Forms
Imports System.IO
'Imports MediaPlayer

Module Program

    Sub Main(args As String())
        'Dim a As New Form1
        'a.Play()
        'Dim wmPlayer As New 


        'My.Computer.Audio.Play("C:\Users\ckish.admin\Downloads\got_s3e9_apologies1.wav", AudioPlayMode.Background)

        'Dim wav As New SoundPlayer()
        'wav.SoundLocation = "C:\Users\ckish.admin\Downloads\got_s3e9_apologies1.wav"
        'wav.Play()
        'Console.WriteLine("Hello World!")
        Sound.PlaySound("C:\Users\ckish.admin\Downloads\got_s3e9_apologies1.wav", Sound.SND_FILENAME, Sound.SND_SYNC)
        'Sound.PlaySound("Sound.wav", Sound.SND_RESOURCE, 0)

    End Sub

End Module


Public Class Sound

    Public Const SND_SYNC = &H0 ' play synchronously 
    Public Const SND_ASYNC = &H1 ' play asynchronously 
    Public Const SND_MEMORY = &H4  'Play wav in memory
    Public Const SND_ALIAS = &H10000 'Play system alias wav 
    Public Const SND_NODEFAULT = &H2
    Public Const SND_FILENAME = &H20000 ' name is file name 
    Public Const SND_RESOURCE = &H40004 ' name is resource name or atom 

    Declare Auto Function PlaySound Lib "winmm.dll" (ByVal name _
      As String, ByVal hmod As Integer, ByVal flags As Integer) As Integer


End Class




