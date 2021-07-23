Public Class oppasien
    Private validasi As New validasi
    Private childalat As New childalat
    Private search As New Search
    Private read As New Read
    Private check As New Check
    Private updatee As New Update
    Private Sub refreshdata()
        Dim caripasien As New Search
        DataGridView1.DataSource = search.searchpasien(TextBox1.Text)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        updatee.ambilsok = DataGridView1.CurrentRow.Cells(0).Value.ToString
        childalat.tabel = search.searchpasien(updatee.ambilsok())
        If search.bool = False Then
            Button5.Hide()
        Else
            Button5.Show()
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim updategaes As New opupdatepasien
        updategaes.kode = DataGridView1.CurrentRow.Cells(0).Value.ToString
        updategaes.ShowDialog()
        refreshdata()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        opmenu.Show()
    End Sub

    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshdata()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If validasi.cekkosong(TextBox1.Text) = False Then
            DataGridView1.Hide()
            Button5.Hide()
        Else
            refreshdata()
            DataGridView1.Show()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If check.checkcount("dokter") = "0" Then
            MsgBox("Anda harus menambah dokter terlebih dahulu")
        Else
            optambahpasien.Show()
            combodokter()
        End If
    End Sub
    Private Sub combodokter()
        Try
            For i = 0 To check.checkcount("dokter") - 1
                optambahpasien.ComboBox1.Items.Add(read.viewdata("dokter").Rows(i).Item(2))
            Next
        Catch ex As Exception
            MsgBox("Combobox gagal diload")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class