Public Class oppetugasshow
    Private validasi As New childvalidasi
    Private search As New Search
    Private _kode, nama As String
    Private delete As New Delete

    Private Property kode()
        Get
            Return _kode
        End Get
        Set(value)
            _kode = value
        End Set
    End Property

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim opaddoredit As New oppetugasaddoredit("tambah", kode())
        opaddoredit.ShowDialog()
    End Sub

    Public Sub refreshdata()
        DataGridView1.DataSource = search.searchpetugas(Textbox1.text)
        ceklabel()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If kode() = "" Then
            MsgBox("Belum ada data terpilih")
        Else
            Try
                hidebut()
                Dim edit As New oppetugasaddoredit("edit", kode())
                edit.ShowDialog()
            Catch ex As Exception
                MsgBox("Tidak ada data yang terpilih")
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        kode() = DataGridView1.CurrentRow.Cells(0).Value.ToString
        nama = DataGridView1.CurrentRow.Cells(2).Value.ToString
        If search.bool = False Then
            hidebut()
        Else
            showbut()
        End If
    End Sub

    Private Sub hidebut()
        Button5.Hide()
        Button6.Hide()
    End Sub

    Private Sub showbut()
        Button5.Show()
        Button6.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        opmenu.Show()
    End Sub

    Private Sub ceklabel()
        If DataGridView1.RowCount < 1 Then
            Label4.Show()
        Else
            Label4.Hide()
        End If
    End Sub
    Public Sub all()
        DataGridView1.DataSource = search.searchpetugas("PTG")
        ceklabel()
    End Sub
    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        all()
        hidebut()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Textbox1_OnTextChange(sender As Object, e As EventArgs) Handles Textbox1.OnTextChange
        If validasi.cekkosong(Textbox1.text) = False Then
            all()
            hidebut()
        Else
            refreshdata()
            DataGridView1.Show()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If kode() = "" Then
            MsgBox("belum ada data yang terpilih", MsgBoxStyle.Information)
        Else
            If MsgBox("Anda yakin untuk Menghapus " + nama, MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
                delete.deleteallorwhere("petugas", kode())
                hidebut()
                all()
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim a As New cetak("petugas")
        a.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        all()
    End Sub
End Class