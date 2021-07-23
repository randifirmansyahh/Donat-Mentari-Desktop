Public Class opbayar
    Private create As New Create
    Private check As New Check
    Private read As New Read
    Private alat As New childalat
    Private _kode, kata, kaki, kaku As String
    Private updatee As New Update
    Private val As New childvalidasi
    Private diskon As New childdiscount
    Private diskon99 As New childdiscount99

    Public Property kode As String
        Get
            Return _kode
        End Get
        Set(value As String)
            _kode = value
        End Set
    End Property
    Sub New(a As String)
        InitializeComponent()
        kode() = a
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If val.cekkosong(TextBox8.Text) = False Or val.cekkosong(TextBox9.Text) = False Or val.cekkosong(TextBox10.Text) = False Then
            MsgBox("Mohon isi semua data terlebih dahulu")
        Else
            insert()
            Me.Hide()
            opadministrasi.TextBox1.Clear()
            opadministrasi.all()
            opadministrasi.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        opadministrasi.Show()
    End Sub
    Private Sub tx8(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        val.pressangka(e)
    End Sub

    Private Sub combopetugas()
        Try
            For i = 0 To check.checkcount("petugas") - 1
                ComboBox1.Items.Add(read.viewwherebebas("petugas", "Divisi", "Kasir").Rows(i).Item(0) + " A/n : " + read.viewwherebebas("petugas", "Divisi", "Kasir").Rows(i).Item(2))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub showdatapasien()
        Dim a As New DataTable
        TextBox4.ReadOnly = True
        a = read.viewwhere(_kode, "pasien")
        TextBox1.Text = a.Rows(0).Item(1)
        TextBox1.ReadOnly = True
        TextBox2.Text = a.Rows(0).Item(2)
        TextBox2.ReadOnly = True
        TextBox3.Text = a.Rows(0).Item(3)
        TextBox3.ReadOnly = True
        TextBox4.Text = a.Rows(0).Item(4)
        TextBox4.ReadOnly = True
        TextBox5.Text = a.Rows(0).Item(5)
        TextBox5.ReadOnly = True
        TextBox6.Text = a.Rows(0).Item(6)
        TextBox6.ReadOnly = True
        TextBox7.Text = a.Rows(0).Item(7)
        TextBox7.ReadOnly = True
        a = read.viewwhere(a.Rows(0).Item(1), "dokter")
        TextBox1.Text = a.Rows(0).Item(2)
    End Sub
    Private Sub optambahpasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isi()
    End Sub
    Private Sub insert()
        If val.cekkosong(TextBox8.Text) = False Or val.cekkosong(TextBox9.Text) = False Or val.cekkosong(TextBox10.Text) = False Then
            MsgBox("Harap mengisi semua inputan terlebih dahulu")
        End If
        create.insertinaporpembayaran(TextBox9.Text, _kode, DateTimePicker1.Value, TextBox10.Text)
        If create.bool = True Then
            MsgBox("Terima Kasih Pembayaran telah dilakukan")
        End If
    End Sub
    Private Sub isi()
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox5.ReadOnly = True
        TextBox6.ReadOnly = True
        TextBox7.ReadOnly = True
        TextBox9.ReadOnly = True
        TextBox10.ReadOnly = True
        combopetugas()
        showdatapasien()
        RadioButton1.Checked = True
        Label12.Text = "   Administrasi"
        Button1.Text = "Selesai"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            alat.tabel = New DataTable
            kaki = ""
            kata = ComboBox1.Text
            kata.Split()
            For i = 0 To 6
                kaki += kata(i)
            Next
            alat.tabel = read.viewwhere(kaki, "petugas")
            TextBox9.Text = alat.tabel.Rows(0).Item(0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox8.Text = val.cekangka(TextBox8.Text)
        TextBox10.Text = TextBox8.Text
        RadioButton1.Checked = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox10.Text = CInt(TextBox8.Text) - diskon.diskon(TextBox8.Text)
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        TextBox10.Text = CInt(TextBox8.Text) - diskon99.diskon(TextBox8.Text)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox10.Text = TextBox8.Text
    End Sub
End Class