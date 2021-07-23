Public Class login
    Private check As New Check
    Private validasi As New childvalidasi
    Private search As New Search
    Private childlogin As New childlogin
    Private childloginadmin As New childloginadmin
    Private child As New childalat
    Private read As New Read
    Private percobaan As Integer = 0
    Private send As New childsendmail
    Private Sub latar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Hide()
        Timer1.Start()
        Label10.Hide()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        slide()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        pengunjung.Show()
    End Sub

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
    Private Sub slide()
        ProgressBar1.Value += 1
        If ProgressBar1.Value = 30 Then
            Me.BackColor = Color.DarkSalmon
        ElseIf ProgressBar1.Value = 60 Then
            Me.BackColor = Color.DarkSeaGreen
        ElseIf ProgressBar1.Value = 90 Then
            Me.BackColor = Color.DarkSlateGray
            ProgressBar1.Value = 0
        End If
    End Sub
    Private Sub back(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        pengunjung.Button4.Show()
        pengunjung.Show()
    End Sub
    Private Sub popupkomentar()
        DataGridView1.DataSource = check.email()
        child.nberita = DataGridView1.RowCount() - 1
        If child.nberita > 0 Then
            opmenu.Label1.Text = child.nberita
        Else
            opmenu.Label1.Hide()
        End If
    End Sub
    Private Sub cek()
        Try
            If validasi.cekkosong(Textusername.Text) = False Or validasi.cekkosong(Textpassword.Text) = False Then
                MsgBox("Isi terlebih dahulu !", MsgBoxStyle.Critical)
            Else
                If Button5.BackColor = Color.Red Then
                    If check.cekop("operator", Textusername.Text, Textpassword.Text) = "1" Then
                        MsgBox("Welcome " + Textusername.Text)
                        popupkomentar()
                        Me.Hide()
                        opmenu.Show()
                    ElseIf check.cekop("operator", Textusername.Text, Textpassword.Text) = "2" Then
                        MsgBox("Password Anda Salah")
                        Textpassword.Focus()
                        Label10.Show()
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
                    If check.cekop("admin", Textusername.Text, Textpassword.Text) = "1" Then
                        MsgBox("Welcome " + Textusername.Text)
                        Me.Hide()
                        menuad.Show()
                    ElseIf check.cekop("admin", Textusername.Text, Textpassword.Text) = "2" Then
                        MsgBox("Password Anda Salah")
                        Textpassword.Focus()
                        Label10.Show()
                    Else
                        percobaan += 1
                        If percobaan > 1 Then
                            MsgBox("Kesempatan anda habis", MsgBoxStyle.Exclamation)
                            Button1.Enabled = False
                        Else
                            MsgBox("Akun anda tidak terdaftar, anda hanya memiliki " + (childloginadmin.banyaklogin() - percobaan).ToString + " kesempatan lagi", MsgBoxStyle.Exclamation)
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
            Me.Close()
            pengunjung.Close()
        End If
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        sendmail()
    End Sub

    Private Sub sendmail()
        If Textusername.Text = "" Then
            MsgBox("isi username terlebih dahulu", MsgBoxStyle.Information)
        ElseIf Button5.BackColor = Color.Red Then
            child.tabel = New DataTable
            child.tabel = read.viewwherebebas("operator", "Username", Textusername.Text)
            send.alatproperty(child.tabel.Rows(0).Item(2), child.tabel.Rows(0).Item(0), child.tabel.Rows(0).Item(1))
            Label10.Hide()
        Else
            child.tabel = New DataTable
            child.tabel = read.viewwherebebas("admin", "Username", Textusername.Text)
            send.alatproperty(child.tabel.Rows(0).Item(2), child.tabel.Rows(0).Item(0), child.tabel.Rows(0).Item(1))
            Label10.Hide()
        End If
    End Sub

End Class