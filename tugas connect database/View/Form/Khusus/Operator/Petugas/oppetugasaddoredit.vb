Public Class oppetugasaddoredit
    Private create As New Create
    Private read As New Read
    Private updatee As New Update
    Private val As New childvalidasi
    Private a As New childalat
    Private check As New Check
    Private _kode, _aksi As String
    
    Public Property kode() As String
        Get
            Return _kode
        End Get
        Set(value As String)
            _kode = value
        End Set
    End Property

    Public Property aksi() As String
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
    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub tx1(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        val.presskata(e)
    End Sub

    Private Sub tx2(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        val.presskata(e)
    End Sub

    Private Sub tx3(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        val.presskata(e)
    End Sub

    Private Sub tx4(sender As Object, e As KeyPressEventArgs) Handles Textusername.KeyPress
        val.presskata(e)
    End Sub

    Private Sub optambahpasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isi()
    End Sub

    Private Sub insert()
        create.insertopereatororpetugas(TextBox4.Text, Textusername.Text, TextBox1.Text, TextBox2.Text, CStr(DateTimePicker1.Value))
        If create.bool = True Then
            Me.Hide()
            oppetugasshow.all()
        End If
    End Sub

    Private Sub sunting()
        updatee.updateopereatororpetugas(_kode, TextBox4.Text, Textusername.Text, TextBox1.Text, TextBox2.Text, CStr(DateTimePicker1.Value))
        If updatee.bool = True Then
            oppetugasshow.all()
            Me.Hide()
        End If
    End Sub

    Private Sub isi()
        If _aksi = "edit" Then
            showdatapasien()
            Label12.Text = "Edit Data Petugas"
            Button1.Text = "Selesai"
        Else
            Label12.Text = "Tambah Petugas Baru"
            Button1.Text = "Daftarkan"
        End If
    End Sub

     Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub showdatapasien()
        a.tabel = New DataTable
        a.tabel = read.viewwhere(_kode, "petugas")
        TextBox4.Text = a.tabel.Rows(0).Item(1)
        Textusername.Text = a.tabel.Rows(0).Item(2)
        TextBox1.Text = a.tabel.Rows(0).Item(3)
        TextBox2.Text = a.tabel.Rows(0).Item(4)
        DateTimePicker1.Value = a.tabel.Rows(0).Item(5)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If val.batas5(TextBox1.Text) = False Or val.batas5(TextBox2.Text) = False Or val.cekkosong(TextBox4.Text) = False Or val.batas5(Textusername.Text) = False Then
            MsgBox("Masukan minimal 5 karakter", MsgBoxStyle.Critical)
        Else
            If _aksi = "tambah" Then
                insert()
            Else
                sunting()
                oppetugasshow.Button5.Hide()
                oppetugasshow.Button6.Hide()
            End If
        End If
    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        TextBox4.Text = val.cekdoublespasi(TextBox4.Text)
        TextBox4.Select(TextBox4.Text.Length, 0)
        TextBox4.MaxLength = 25
    End Sub

    Private Sub Textusername_TextChanged(sender As Object, e As EventArgs) Handles Textusername.TextChanged
        Textusername.Text = val.cekdoublespasi(Textusername.Text)
        Textusername.Select(Textusername.Text.Length, 0)
        Textusername.MaxLength = 25
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = val.cekdoublespasi(TextBox1.Text)
        TextBox1.Select(TextBox1.Text.Length, 0)
        TextBox1.MaxLength = 25
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.Text = val.cekdoublespasi(TextBox2.Text)
        TextBox2.Select(TextBox2.Text.Length, 0)
        TextBox2.MaxLength = 25
    End Sub
End Class