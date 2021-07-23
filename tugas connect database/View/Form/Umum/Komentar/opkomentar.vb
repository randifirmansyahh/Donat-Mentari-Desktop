Public Class opkomentar
    Public ke As Integer = 0
    Private check As New Check
    Private childalat As New childalat
    Private delete As New Delete
    Private val As New childvalidasi
    Private send As New childsendmail
    Private _aksi, email, _kode As String

    Private Property kode()
        Get
            Return _kode
        End Get
        Set(value)
            _kode = value
        End Set
    End Property

    Public Property aksi As String
        Get
            Return _aksi
        End Get
        Set(value As String)
            _aksi = value
        End Set
    End Property
    Sub New(aksi As String)
        InitializeComponent()
        _aksi = aksi
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        prevkomentar()
    End Sub
    Private Sub back()
        If _aksi = "admin" Then
            Me.Hide()
            With menuad
                .Show()
                .Label1.Hide()
            End With
        Else
            Me.Hide()
            With opmenu
                .Show()
                .Label1.Hide()
            End With
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        back()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nextkomentar()
    End Sub
    Private Sub showawal()
        ke = 0
        Dim table As New DataTable
        Dim n As Integer
        DataGridView1.DataSource = check.email()
        n = DataGridView1.RowCount()
        If n > 1 Then
            childalat.tabel = New DataTable
            childalat.tabel = check.email()
            kode() = childalat.tabel.Rows(ke).Item(0)
            Label4.Text = childalat.tabel.Rows(ke).Item(3)
            RichTextBox1.Text = childalat.tabel.Rows(ke).Item(4)
            RichTextBox1.ReadOnly = True
            Button1.Show()
            Label5.Show()
            If _aksi = "admin" Then
                RichTextBox2.Hide()
                Button4.Show()
                Button5.Show()
                Label9.Hide()
                Button3.Hide()
            Else
                Button4.Hide()
                Button5.Hide()
            End If
        Else
            MsgBox("Tidak ada komentar yang dapat ditampilkan", MsgBoxStyle.Information)
            Button1.Hide()
            Button2.Hide()
            Label5.Hide()
            Label6.Hide()
            RichTextBox1.Hide()
            RichTextBox2.Hide()
            Label4.Hide()
            Label7.Hide()
            Button3.Hide()
            Label9.Hide()
            Button4.Hide()
            Button5.Hide()
        End If
    End Sub
    Private Sub nextkomentar()
        ke += 1
        Dim table As New DataTable
        Dim n As Integer
        DataGridView1.DataSource = check.email()
        n = DataGridView1.RowCount() - 1
        If ke < n Then
            childalat.tabel = New DataTable
            childalat.tabel = check.email()
            kode() = childalat.tabel.Rows(ke).Item(0)
            Label4.Text = childalat.tabel.Rows(ke).Item(3)
            RichTextBox1.Text = childalat.tabel.Rows(ke).Item(4)
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
            childalat.tabel = check.email()
            kode() = childalat.tabel.Rows(ke).Item(0)
            Label4.Text = childalat.tabel.Rows(ke).Item(3)
            RichTextBox1.Text = childalat.tabel.Rows(ke).Item(4)
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
            login.Show()
        End If
    End Sub

    Private Sub opkomentar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showawal()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MsgBox("Anda yakin untuk menghapus komentar dari " + email + " ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            delete.deleteallorwhere("pengunjung", _kode)
            If delete.bool = True Then
                MsgBox("komentar telah dihapus", MsgBoxStyle.Information)
                showawal()
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Anda yakin untuk menghapus semua komentar ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            delete.deleteallorwhere("pengunjung")
            If delete.bool = True Then
                MsgBox("Semua komentar telah terhapus", MsgBoxStyle.Information)
                showawal()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If val.batas5(RichTextBox2.Text) = False Then
            MsgBox("Masukan Minimal 5 Karakter !", MsgBoxStyle.Critical)
        Else
            send.balaskomentar(Label4.Text, RichTextBox1.Text, RichTextBox2.Text)
        End If
    End Sub
End Class