﻿Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Threading

<Localizable(False)>
Public Class LanguagesForm
    Private Sub LangsListBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LangsListBox.MouseDoubleClick
        If LangsListBox.SelectedIndex <> -1 Then
            Acceptbtn.PerformClick()
        End If
    End Sub

    Private Sub Done()
        StartupForm.Show()
        Close()
    End Sub

    Private Sub Acceptbtn_Click(sender As Object, e As EventArgs) Handles Acceptbtn.Click
        If LangsListBox.SelectedIndex <> -1 Then
            If LangsListBox.SelectedItem = "English"
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("en")
                My.Computer.FileSystem.WriteAllText(Mainform.ApplicationFiles + "\configs\lang.cfg", "en", False)
            End If
            Done()
        End If
    End Sub

    Private Sub LanguagesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(Mainform.ApplicationFiles + "\configs\lang.cfg") Then
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(File.ReadAllText(Mainform.ApplicationFiles + "\configs\lang.cfg"))
            Done()
        End If
    End Sub
End Class