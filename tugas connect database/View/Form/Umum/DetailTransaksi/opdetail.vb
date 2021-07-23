Public Class opdetail
    Private validasi As New childvalidasi
    Private search As New Search
    Private delete As New Delete
    Private check As New Check
    Private _kode, _aksi, _nama, _pasien As String

    Private Property kode()
        Get
            Return _kode
        End Get
        Set(value)
            _kode = value
        End Set
    End Property
    Private Sub back()
        If _aksi = "admin" Then
            Me.Hide()
            menuad.Show()
        Else
            Me.Hide()
            opmenu.Show()
        End If
    End Sub
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
        DataGridView1.DataSource = search.WhatFromWhatLikePesanan("*", "Pesanan", TextBox1.Text, "Berhasil")
        Label5.Text = check.total()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If _aksi = "admin" Then
            Me.Hide()
            menuad.Show()
        Else
            Me.Hide()
            opmenu.Show()
        End If
    End Sub

    Public Sub showall()
        DataGridView1.DataSource = search.WhatFromWhatWhere("*", "Pesanan", "Status", "Berhasil")
        Label5.Text = check.total()
    End Sub

    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showall()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = validasi.cekdoublespasi(TextBox1.Text)
        If validasi.cekkosong(TextBox1.Text) = False Then
            showall()
        Else
            refreshdata()
            DataGridView1.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim edit As New editdetail(kode(), _nama)
        Button4.Hide()
        Button5.Hide()
        edit.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        kode() = DataGridView1.CurrentRow.Cells(1).Value.ToString
        _nama = DataGridView1.CurrentRow.Cells(5).Value.ToString
        _pasien = DataGridView1.CurrentRow.Cells(4).Value.ToString
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Anda yakin untuk Menghapus Transaksi Pasien " + _nama + "?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            delete.deleteallorwhere("pembayaran", kode())
            delete.deleteallorwhere("pasien", _pasien)
            delete.deletefromwhatwhere("inap", "Pasien", _pasien)
            MsgBox("Detail Pasien dan Pembayarannya telah terhapus", MsgBoxStyle.Information)
            showall()
            Button4.Hide()
            Button5.Hide()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Dim cetak As New cetak("transaksi")
        cetak.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showall()
    End Sub
End Class