Public Class opadministrasi
    Private validasi As New childvalidasi
    Private search As New Search
    Private check As New Check
    Private kode As String

    Public Function refreshdata()
        DataGridView1.DataSource = search.searchpasien(TextBox1.Text, "")
        ceklabel()
        Return True
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Button4.Show()
        kode = DataGridView1.CurrentRow.Cells(0).Value.ToString
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        opmenu.Show()
    End Sub

    Public Sub all()
        DataGridView1.DataSource = search.searchpasien("PSN", "")
        ceklabel()
    End Sub
    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        all()
        Button4.Hide()
    End Sub

    Private Sub ceklabel()
        If DataGridView1.RowCount() < 1 Then
            Label4.Show()
        Else
            Label4.Hide()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = validasi.cekdoublespasi(TextBox1.Text)
        TextBox1.Select(TextBox1.Text.Length, 0)
        refreshdata()
        If validasi.cekkosong(TextBox1.Text) = False Then
            all()
            Button4.Hide()
        Else
            refreshdata()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If check.checkcountfromwhatwhere("petugas", "Divisi", "Kasir") = "0" Then
            MsgBox("Anda harus menambah Petugas Divisi Kasir terlebih dahulu")
        ElseIf kode = "" Then
            MsgBox("Belum ada kode terpilih")
        Else
            Me.Hide()
            Dim tambah As New opbayar(kode)
            Button4.Hide()
            tambah.ShowDialog()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        all()
    End Sub
End Class