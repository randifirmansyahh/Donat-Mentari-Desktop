Public Class userkomentar
    Private validasi As New childvalidasi
    Private updatee As New Update
    Private check As New Check

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        kirim()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        usermenu.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
    Private Sub kirim()
        If validasi.cekkosong(TextBox1.Text) = False Or validasi.cekkosong(RichTextBox1.Text) = False Then
            MsgBox("Harap untuk mengisi semua inputan", MsgBoxStyle.Critical)
        Else
            updatee.updatepengunjung(check.checkmax("pengunjung"), TextBox1.Text, RichTextBox1.Text)
            MsgBox("Terima kasih banyak atas kontribusi anda memajukan perusahaan donat mentari", MsgBoxStyle.Information)
            Me.Hide()
            usermenu.Show()
        End If
    End Sub

    Private Sub userkomentar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label8.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.MaxLength = 50
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        validasi.pressemail(e)
    End Sub
End Class