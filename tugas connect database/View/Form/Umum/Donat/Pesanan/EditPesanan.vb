Public Class EditPesanan
    Private create As New Create
    Private search As New Search
    Private check As New Check
    Private read As New Read
    Private alat As New childalat
    Private _kode As String
    Private _aksi As String
    Private updatee As New Update
    Private valid As New childvalidasi
    Private kata, kaki, _nama As String
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
    Sub New(aksi As String, kode As String, nama As String)
        InitializeComponent()
        _aksi = aksi
        _kode = kode
        _nama = nama
    End Sub
    Public Property nama As String
        Get
            Return _nama
        End Get
        Set(value As String)
            _nama = value
        End Set
    End Property
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If valid.batas5(TextBox4.Text) = False Or valid.batas5(TextBox1.Text) = False Then
            MsgBox("Batas 5 Karakter", MsgBoxStyle.Critical)
        Else
            If _aksi = "edit" Then
                sunting()
            Else
                insert()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim op As New TampPesanan("op")
        op.all()
        op.Show()
    End Sub

    Private Sub tx2(sender As Object, e As KeyPressEventArgs)
        valid.presskata(e)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            kaki = ""
            kata.Split()
            For i = 0 To 6
                kaki += kata(i)
            Next
            alat.tabel = read.viewwhere(kaki, "pasien")
            TextBox4.Text = alat.tabel.Rows(0).Item(0)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub comboinap()
        DataGridView1.DataSource = search.searchcomboinap("PSN", "")
        If DataGridView1.RowCount() = 1 Then
            MsgBox("Semua Pasien Berada Dirawat Inap", MsgBoxStyle.Information)
        Else
            Try
                For i = 0 To DataGridView1.RowCount() - 1
                    kaki = ""
                    For j = 0 To DataGridView1.ColumnCount() - 1
                        kaki += DataGridView1.Rows(i).Cells(j).Value.ToString + " ; "
                    Next

                Next
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub showdatainap()
        Dim a As New DataTable
        TextBox4.ReadOnly = True
        a = read.viewwhere(_kode, "inap")
        TextBox4.Text = a.Rows(0).Item(0)
    End Sub
    Private Sub optambahdokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox5.ReadOnly = True
        isi()
        TextBox4.ReadOnly = True
    End Sub
    Private Sub insert()
        create.insertinaporpembayaran(TextBox4.Text, TextBox1.Text)
        If create.bool = True Then
            Me.Hide()
            Dim op As New TampPesanan("op")
            op.all()
            op.Show()
            MsgBox("Data Pasien Rawat Inap Berhasil Ditambahkan", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub sunting()
        updatee.updateinaporpembayaran(_kode, TextBox1.Text)
        If updatee.bool = True Then
            Me.Hide()
            Dim op As New TampPesanan("op")
            op.all()
            op.Show()
            MsgBox("Data Pasien Rawat Inap Berhasil Diubah", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub isi()
        If _aksi = "edit" Then
            showdatainap()
            Label12.Text = "Edit Data Pasien"
            Button1.Text = "Selesai"
        Else
            comboinap()
            Label12.Text = "Tambah Pasien Baru"
            Button1.Text = "Daftarkan"
        End If
    End Sub

    Private Sub Textusername_TextChanged(sender As Object, e As EventArgs)
        
    End Sub

End Class