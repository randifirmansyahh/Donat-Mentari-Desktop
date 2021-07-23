Public Class AllPesanan

    Private validasi As New childvalidasi
    Private childalat As New childalat
    Private search As New Search
    Private read As New Read
    Private check As New Check
    Private updatee As New Update
    Private delete As New Delete
    Private nama As String
    Private _aksi, _kode, stat As String

    Private Property kode()
        Get
            Return _kode
        End Get
        Set(value)
            _kode = value
        End Set
    End Property

    Private Property aksi()
        Get
            Return _aksi
        End Get
        Set(value)
            _aksi = value
        End Set
    End Property

    Sub New(a As String)
        InitializeComponent()
        aksi() = a
    End Sub

    Public Sub refreshdata()
        If Dikirim.Checked = True And Proses.Checked = False Then
            DataGridView1.DataSource = search.WhatFromWhatLikePesananTanggal("*", "pesanan", Textbox1.text, "Berhasil", DateTimePicker1.Text)
        ElseIf Proses.Checked = True And Dikirim.Checked = False Then
            DataGridView1.DataSource = search.WhatFromWhatLikePesananTanggal("*", "pesanan", Textbox1.text, "Dalam Proses", DateTimePicker1.Text)
        Else
            DataGridView1.DataSource = search.AllWhatFromWhatLikePesananTanggal("*", "pesanan", Textbox1.text, DateTimePicker1.Text)
        End If
        ceklabel()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If _aksi = "op" Then
            kode() = DataGridView1.CurrentRow.Cells(0).Value.ToString
            stat = DataGridView1.CurrentRow.Cells(5).Value.ToString
            childalat.tabel = search.WhatFromWhatWhere("Nama", "Pesanan", "Nama", kode())
            If search.bool = False Then
                Button5.Hide()
            Else
                Button5.Show()
            End If
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Button5.Hide()
        If kode() = "" Then
            MsgBox("Belum ada data terpilih")
        Else
            Try
                Dim edit As New EditPesanan("edit", kode(), nama)
                edit.ShowDialog()
                kode() = ""
            Catch ex As Exception
                MsgBox("Tidak ada data yang terpilih")
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If _aksi = "user" Then
            Me.Hide()
            usermenu.Show()
        Else
            Me.Hide()
            opmenu.Show()
        End If
    End Sub

    Public Sub all()
        Dikirim.Checked = True
        Proses.Checked = True
        DataGridView1.DataSource = search.AllWhatFromWhatLikePesananTanggal("*", "pesanan", Textbox1.text, Format(Now, "dd/MM/yyyy"))
        ceklabel()
    End Sub

    Private Sub ceklabel()
        If DataGridView1.RowCount = 1 Then
            Button6.BringToFront()
            Button6.Show()
            Label4.BringToFront()
            Label4.Show()
        Else
            Label4.Hide()
            Button6.Hide()
        End If
    End Sub

    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        all()
        ceklabel()
        DataGridView1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If kode() = "" Then
            MsgBox("Silahkan pilih data terlebih dahulu !", MsgBoxStyle.Critical)
        Else
            If stat = "Berhasil" Then
                MsgBox("Makanan telah dikirim dan tidak dapat dikirim kembali, silahkan untuk memesan donat kembali", MsgBoxStyle.Information)
            Else
                If MsgBox("Makanan telah selesai dibuat dan siap untuk dikirimkan ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
                    updatee.pesanan(kode())
                    MsgBox("Selamat, Pesanan berhasil dikirimkan !", MsgBoxStyle.Information)
                    all()
                    kode() = ""
                End If
            End If
            
        End If
    End Sub

    Private Sub Textbox1_OnTextChange(sender As Object, e As EventArgs) Handles Textbox1.OnTextChange
        If validasi.cekkosong(Textbox1.text) = False Then
            all()
        Else
            refreshdata()
            DataGridView1.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        all()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If kode() = "" Then
            MsgBox("Silahkan untuk memilih data terlebih daulu?", MsgBoxStyle.Critical)
        Else
            If MsgBox("Anda yakin untuk menghapus " + kode() + " dari antrian pesanan ini?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
                MsgBox("Pesanan berhasil dihapus", MsgBoxStyle.Information)
                delete.FromWhatWhere("Pesanan", "Nama", kode())
                all()
                kode() = ""
            End If
        End If
    End Sub

    Private Sub Dikirim_CheckedChanged(sender As Object, e As EventArgs) Handles Dikirim.CheckedChanged
        If Proses.Checked = False And Dikirim.Checked = False Then
            Dikirim.Checked = True
        End If
        refreshdata()
    End Sub

    Private Sub Proses_CheckedChanged(sender As Object, e As EventArgs) Handles Proses.CheckedChanged
        If Proses.Checked = False And Dikirim.Checked = False Then
            Proses.Checked = True
        End If
        refreshdata()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        refreshdata()
    End Sub
End Class