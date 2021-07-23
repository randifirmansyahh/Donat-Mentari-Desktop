Public Class adeditop
    Private create As New Create
    Private read As New Read
    Private updatee As New Update
    Private validasi As New childvalidasi
    Private send As New childsendmail
    Private view As New Read
    Private _kode, _nama, sip, _aksi As String

    Public Property kode As String
        Get
            Return _kode
        End Get
        Set(value As String)
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
    Sub New(a As String, b As String)
        InitializeComponent()
        aksi() = a
        kode() = b
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sikat()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub optambahdokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isi()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        validasi.pressuser(e)
    End Sub

    Private Sub Textusername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textusername.KeyPress
        validasi.pressemail(e)
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        validasi.presspass(e)
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        TextBox4.MaxLength = 8
    End Sub

    Private Sub Textusername_TextChanged(sender As Object, e As EventArgs) Handles Textusername.TextChanged
        Textusername.MaxLength = 50
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Textusername.MaxLength = 25
    End Sub

    Private Sub showdataop()
        Dim a As New DataTable
        a = read.viewwherebebas("operator", "Username", _kode)
        TextBox1.Text = a.Rows(0).Item(0)
        TextBox4.Text = a.Rows(0).Item(1)
        Textusername.Text = a.Rows(0).Item(2)
    End Sub

    Private Sub insert()
        create.insertopereatororpetugas(TextBox1.Text, TextBox4.Text, Textusername.Text)
        If create.bool = True Then
            Me.Hide()
            adop.showall()
            MsgBox("Data Operator Berhasil Ditambahkan", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub sunting()
        updatee.updateopereatororpetugas(TextBox1.Text, _kode, Textusername.Text)
        If updatee.bool = True Then
            Me.Hide()
            adop.showall()
            MsgBox("Data Operator Berhasil Diubah", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub sikat()
        If validasi.batas5(TextBox1.Text) = False Or validasi.batas5(TextBox4.Text) = False Or validasi.batas5(Textusername.Text) = False Then
            MsgBox("Masukan minimal 5 karakter", MsgBoxStyle.Critical)
        Else
            If _aksi = "edit" Then
                sunting()
            Else
                Try
                    If view.view1where("username", "operator", "username", TextBox1.Text) = True Then
                        MsgBox("Username Sudah Digunakan, Silahkan untuk mencari username baru", MsgBoxStyle.Information)
                    Else
                        If sip = "" Then
                            TextBox2.Show()
                            Label5.Show()
                            Label7.Show()
                            If send.verifikasi(Textusername.Text, TextBox1.Text, "randiganteng" + TextBox4.Text) = True Then
                                sip = "oke"
                            Else
                                Label5.Hide()
                                Label7.Hide()
                            End If
                        Else
                            If "randiganteng" + TextBox4.Text = TextBox2.Text Then
                                insert()
                            Else
                                MsgBox("Kode Verifikasi salah", MsgBoxStyle.Critical)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Username Sudah ada, Silahkan untuk menggantinya", MsgBoxStyle.Information)
                End Try
            End If
        End If
    End Sub
    Private Sub isi()
        TextBox2.Hide()
        Label5.Hide()
        Label7.Hide()
        If _aksi = "edit" Then
            showdataop()
            Label12.Text = "Edit Datar"
            Button1.Text = "Selesai"
        Else
            Label12.Text = "Tambah Operator"
            Button1.Text = "Daftarkan"
        End If
    End Sub
End Class