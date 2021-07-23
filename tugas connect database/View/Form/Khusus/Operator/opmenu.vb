Public Class opmenu
    Private childalat As New childalat

    'big 416; 302

    Private normlbig As Integer = 416
    Private hovlbig As Integer = 446
    Private nortingbig As Integer = 302
    Private hovtingbig As Integer = 332

    'cols 416; 148
    Private normlcols As Integer = 416
    Private hovlcols As Integer = 446
    Private normtingcols As Integer = 148
    Private hovtingcols As Integer = 178

    'rows 205; 302
    Private normlrows As Integer = 205
    Private hovlrows As Integer = 235
    Private normtingrows As Integer = 302
    Private hovtingrows As Integer = 332

    Private tingginormal As Integer = 148
    Private tinggihover As Integer = 178
    Private lebarnormal As Integer = 205
    Private lebarhover As Integer = 235
    Private labellebarhover As Integer = 111
    Private labeltinggihover As Integer = 80
    Private labellebarnormal As Integer = 81
    Private labeltingginormal As Integer = 50
    Private search As New Search
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        showkomentar()
    End Sub
    Private Sub hbt1(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.Width = lebarhover
        Button1.Height = tinggihover
        sendback()
    End Sub

    Private Sub lbt1(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.Width = lebarnormal
        Button1.Height = tingginormal
    End Sub
    Private Sub hbt8(sender As Object, e As EventArgs) Handles Button8.MouseHover
        Button8.Width = lebarhover
        Button8.Height = tinggihover
        sendback()
    End Sub

    Private Sub lbt8(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Button8.Width = lebarnormal
        Button8.Height = tingginormal
    End Sub
    Private Sub hbt9(sender As Object, e As EventArgs) Handles Button9.MouseHover
        Button9.Width = lebarhover
        Button9.Height = tinggihover
        sendback()
        Button9.BringToFront()
    End Sub

    Private Sub lbt9(sender As Object, e As EventArgs) Handles Button9.MouseLeave
        Button9.Width = lebarnormal
        Button9.Height = tingginormal
    End Sub
    Private Sub button2_MouseHover(sender As Object, e As EventArgs) Handles Button5.MouseHover
        Button5.Width = lebarhover
        Button5.Height = tinggihover
        sendback()
    End Sub

    Private Sub button2_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.Width = lebarnormal
        Button5.Height = tingginormal
    End Sub
    Private Sub hb0(sender As Object, e As EventArgs) Handles Button0.MouseHover
        Button0.Width = hovlrows
        Button0.Height = hovtingrows
        sendback()
    End Sub

    Private Sub lb0(sender As Object, e As EventArgs) Handles Button0.MouseLeave
        Button0.Width = normlrows
        Button0.Height = normtingrows
    End Sub
    Private Sub hb10(sender As Object, e As EventArgs) Handles Button10.MouseHover
        Button10.Width = hovlrows
        Button10.Height = hovtingrows
        sendback()
        Button10.BringToFront()
    End Sub

    Private Sub lb10(sender As Object, e As EventArgs) Handles Button10.MouseLeave
        Button10.Width = normlrows
        Button10.Height = normtingrows
    End Sub
    Private Sub Button0_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.Width = hovlbig
        Button2.Height = hovtingbig
        sendback()
    End Sub

    Private Sub Button0_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.Width = normlbig
        Button2.Height = nortingbig
    End Sub
    Private Sub hb4(sender As Object, e As EventArgs) Handles Button4.MouseHover
        Button4.Width = hovlcols
        Button4.Height = hovtingcols
        sendback()
        Label1.BringToFront()
        Label1.Width = labellebarhover
        Label1.Height = labeltinggihover
    End Sub

    Private Sub lb4(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.Width = normlcols
        Button4.Height = normtingcols
        Label1.Width = labellebarnormal
        Label1.Height = labeltingginormal
        End Sub
    Private Sub hb3(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.Width = hovlcols
        Button3.Height = hovtingcols
        sendback()
    End Sub

    Private Sub lb3(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.Width = normlcols
        Button3.Height = normtingcols
    End Sub
    Private Sub sendback()
        Button2.SendToBack()
        Button3.SendToBack()
        Button5.SendToBack()
        Button0.SendToBack()
        Button9.SendToBack()
        Button4.SendToBack()
        Button1.SendToBack()
        Button8.SendToBack()
        Button10.SendToBack()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            login.Close()
            pengunjung.Close()
            Me.Close()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Anda yakin untuk keluar dari Akun?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Hide()
            wtflog.Textusername.Clear()
            wtflog.Textpassword.Clear()
            wtflog.Show()
        End If
    End Sub
    Private Sub showkomentar()
        childalat.tabel = New DataTable
        childalat.tabel = search.searchkomentar()
        opkomentar.Label4.Text = childalat.tabel.Rows(0).Item(1)
        opkomentar.RichTextBox1.Text = childalat.tabel.Rows(0).Item(2)
        opkomentar.RichTextBox1.ReadOnly = True
        opkomentar.Refresh()
        opkomentar.ke = 0
        opkomentar.Show()
        opkomentar.RichTextBox1.ReadOnly = True
        Me.Hide()
    End Sub

    Private Sub Button0_Click(sender As Object, e As EventArgs) Handles Button0.Click
        Me.Hide()
        oppasien.Show()
        oppasien.DataGridView1.Hide()
        oppasien.TextBox1.Clear()
        oppasien.Button5.Hide()
    End Sub
End Class