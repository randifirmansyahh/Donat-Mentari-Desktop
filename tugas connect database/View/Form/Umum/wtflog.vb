Public Class wtflog
    Private check As New Check
    Private validasi As New validasi
    Private search As New Search
    Private childlogin As New childlogin
    Private percobaan As Integer = 0
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cekwarna()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        cekwarna()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        hideshowpass()
    End Sub
    Private Sub formlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        normal()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        cekwarna()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cek()
    End Sub

    Private Sub back(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        pengunjung.Button4.Show()
        pengunjung.Show()
    End Sub
    Private Sub popupkomentar()
        opmenu.Label1.Text = check.checkcount("komentar")
    End Sub
    Private Sub cek()
        Try
            If validasi.cekkosong(Textusername.Text) = False Or validasi.cekkosong(Textpassword.Text) = False Then
                MsgBox("Isi terlebih dahulu !", MsgBoxStyle.Critical)
            Else
                If Button5.BackColor = Color.Red Then
                    If check.cekop(Textusername.Text, Textpassword.Text) = "1" Then
                        MsgBox("Welcome " + Textusername.Text)
                        popupkomentar()
                        opmenu.Show()
                    ElseIf check.cekop(Textusername.Text, Textpassword.Text) = "2" Then
                        MsgBox("Password Anda Salah")
                        Textusername.Focus()
                    Else
                        percobaan += 1
                        If percobaan > 2 Then
                            MsgBox("Kesempatan anda habis", MsgBoxStyle.Exclamation)
                            Button1.Enabled = False
                        Else
                            MsgBox("Akun anda tidak terdaftar, anda hanya memiliki " + (childlogin.banyaklogin() - percobaan).ToString + " kesempatan lagi", MsgBoxStyle.Exclamation)
                        End If
                    End If
                Else
                    If check.cekad(Textusername.Text, Textpassword.Text) = "1" Then
                        MsgBox("Welcome " + Textusername.Text)
                    ElseIf check.cekad(Textusername.Text, Textpassword.Text) = "2" Then
                        MsgBox("Password Anda Salah")
                        Textpassword.Focus()
                    Else
                        percobaan += 1
                        If percobaan > 2 Then
                            MsgBox("Kesempatan anda habis", MsgBoxStyle.Exclamation)
                            Button1.Enabled = False
                        Else
                            MsgBox("Akun anda tidak terdaftar, anda hanya memiliki " + (childlogin.banyaklogin() - percobaan).ToString + " kesempatan lagi", MsgBoxStyle.Exclamation)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub normal()
        Label8.ForeColor = Color.White
        Button5.BackColor = Color.Red
        Button6.BackColor = Color.White
        Button6.Hide()
    End Sub
    Private Sub cekwarna()
        If Button5.BackColor = Color.Red Then
            Button5.Hide()
            Button6.BackColor = Color.LimeGreen
            Button6.Show()
            Button5.BackColor = Color.White
            Label8.ForeColor = Color.Black
        Else
            Button6.Hide()
            Button5.BackColor = Color.Red
            Button5.Show()
            Button6.BackColor = Color.White
            Label8.ForeColor = Color.White
        End If
    End Sub
    Private Sub hideshowpass()
        If CheckBox1.Checked Then
            Textpassword.PasswordChar = ""
        Else
            Textpassword.PasswordChar = "*"
        End If
    End Sub
    Private Sub closees(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            login.Close()
            Me.Close()
            pengunjung.Close()
        End If
    End Sub
End Class