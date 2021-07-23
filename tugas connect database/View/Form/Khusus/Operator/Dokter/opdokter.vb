Public Class opdokter
    Private validasi As New childvalidasi
    Private childalat As New childalat
    Private search As New Search
    Private check As New Check
    Private updatee As New Update
    Private delete As New Delete
    Private _kode As String

    Private Property kode()
        Get
            Return _kode
        End Get
        Set(value)
            _kode = value
        End Set
    End Property

    Public Sub refreshdata()
        DataGridView1.DataSource = search.searchdokter(TextBox1.Text)
        ceklabel()
    End Sub

    Private Sub ceklabel()
        If DataGridView1.RowCount < 1 Then
            Label4.Show()
        Else
            Label4.Hide()
        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        kode() = DataGridView1.CurrentRow.Cells(0).Value.ToString
        If search.bool = False Then
            hidebut()
        Else
            showbut()
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If kode() = "" Then
            MsgBox("Belum ada data terpilih")
        Else
            Try
                hidebut()
                Dim edit As New opaddorupdatedokter("edit", kode())
                edit.ShowDialog()
            Catch ex As Exception
                MsgBox("Tidak ada data yang terpilih")
            End Try
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

    Public Sub all()
        DataGridView1.DataSource = search.searchdokter("DTR")
        ceklabel()
        hidebut()
    End Sub
    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        all()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If validasi.cekkosong(TextBox1.Text) = False Then
            all()
            hidebut()
        Else
            refreshdata()
            DataGridView1.Show()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim tambah As New opaddorupdatedokter("tambah", kode())
            tambah.ShowDialog()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        childalat.tabel = New DataTable
        childalat.tabel = check.querybebastable("select Ditangani,Kode,Nama from pasien a where Kode not in(select Pasien from pembayaran)and ditangani='" + kode + "'")
        Try
            If childalat.tabel.Rows(0).Item(0) = kode() Then
                MsgBox("Tidak bisa dihapus karna Dokter masih melayani Pasien")
            End If
        Catch ex As Exception
            If MsgBox("Anda yakin untuk menghapus Dokter ini ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
                delete.deleteallorwhere("dokter", kode())
                If delete.bool = True Then
                    MsgBox("Dokter telah di hapus dari daftar", MsgBoxStyle.Information)
                    hidebut()
                End If
            End If
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim a As New cetak("dokter")
        a.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        all()
    End Sub
End Class