﻿Public Class opkomentar
    Public ke As Integer = 0
    Private check As New Check
    Private search As New Search
    Private childalat As New childalat
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        prevkomentar()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        opmenu.Label1.Hide()
        Me.Hide()
        opmenu.Show()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nextkomentar()
    End Sub
    Private Sub nextkomentar()
        ke += 1
        If ke < check.checkcount("komentar") Then
            childalat.tabel = New DataTable
            childalat.tabel = search.searchkomentar()
            Label4.Text = childalat.tabel.Rows(ke).Item(1)
            RichTextBox1.Text = childalat.tabel.Rows(ke).Item(2)
            Button1.Show()
            Label5.Show()
        Else
            ke -= 1
            MsgBox("Tidak ada komentar lagi", MsgBoxStyle.Information)
            Button2.Hide()
            Label6.Hide()
        End If
    End Sub
    Private Sub prevkomentar()
        ke -= 1
        If ke >= 0 Then
            childalat.tabel = New DataTable
            childalat.tabel = search.searchkomentar()
            Label4.Text = childalat.tabel.Rows(ke).Item(1)
            RichTextBox1.Text = childalat.tabel.Rows(ke).Item(2)
            Button2.Show()
            Label6.Show()
        Else
            ke += 1
            MsgBox("Ini adalah komentar terbaru", MsgBoxStyle.Information)
            Button1.Hide()
            Label5.Hide()
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MsgBox("Anda yakin untuk keluar dari Akun?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Hide()
            wtflog.Textusername.Clear()
            wtflog.Textpassword.Clear()
            wtflog.Show()
        End If
    End Sub
End Class