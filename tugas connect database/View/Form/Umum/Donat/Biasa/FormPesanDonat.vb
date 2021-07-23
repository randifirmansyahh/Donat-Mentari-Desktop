Public Class FormPesanDonat
    Private create As New Create
    Private check As New Check
    Private read As New Read
    Private alat As New childalat
    Private _kode, kata, kaki, _aksi As String
    Private updatee As New Update
    Private val As New childvalidasi

    Sub New(aksi As String, kode As String)
        InitializeComponent()
        _aksi = aksi
        _kode = kode
    End Sub

    Private Sub isi()
        If _aksi = "edit" Then
            showdatapemesan()
            Label12.Text = "Edit Pemesanan"
            tombolpesan.Text = "Selesai"
        Else
            Label12.Text = "Pesan Donat"
            tombolpesan.Text = "Pesan"
        End If
    End Sub

    Private Sub setting()
        total.ReadOnly = True
        DateTimePicker1.Enabled = False
        DateTimePicker1.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub optambahpasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setting()
        isi()
    End Sub

    Private Sub showdatapemesan()
        Dim a As New DataTable
        a = read.viewwhere(_kode, "pesanan")
        nama.Text = a.Rows(0).Item(0)
        jenis.Text = a.Rows(0).Item(1)
        banyak.Text = a.Rows(0).Item(2)
        total.Text = a.Rows(0).Item(3)
    End Sub

    Private Sub tx1(sender As Object, e As KeyPressEventArgs) Handles nama.KeyPress
        val.presskata(e)
    End Sub

    Private Sub tx2(sender As Object, e As KeyPressEventArgs) Handles banyak.KeyPress
        val.pressangka(e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles tombolpesan.Click
        If val.batas5(jenis.Text) = False Or val.batas5(nama.Text) = False Then
            MsgBox("Masukan minimal 5 karakter", MsgBoxStyle.Critical)
            Me.Show()
        Else
            If check.namapemesan(nama.Text) = nama.Text Then
                MsgBox("Nama " + nama.Text + " telah digunakan, silahkan gunakan nama lain", MsgBoxStyle.Information)
            Else
                Me.Hide()
                If _aksi = "tambah" Then
                    insert()
                Else
                    sunting()
                End If
                keluar()
            End If
            
        End If
    End Sub

    Private Sub insert()
        create.pesandonat(nama.Text, jenis.Text, CInt(banyak.Text), CInt(total.Text), CStr(DateTimePicker1.Value))
        If create.bool = True Then
            Me.Hide()
        End If
    End Sub
    Private Sub sunting()
        updatee.pesanan(_kode, nama.Text, jenis.Text, banyak.Text, total.Text)
        If updatee.bool = True Then
            Me.Hide()
        End If
    End Sub

    Private Sub banyak_TextChanged(sender As Object, e As EventArgs) Handles banyak.TextChanged
        Try
            total.Text = (1500 * CInt(banyak.Text))
        Catch ex As Exception
            MsgBox("Banyak pesanan tidak boleh dimulai angka 0 !", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub keluar()
        Me.Hide()
        If _aksi = "tambah" Then
            TampPesanDonat.Show()
        Else
            Dim a As New TampPesanan("op")
            a.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        keluar()
    End Sub

End Class