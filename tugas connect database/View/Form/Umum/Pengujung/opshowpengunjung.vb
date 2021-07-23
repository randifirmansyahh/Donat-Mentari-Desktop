Public Class opshowpengunjung
    Private validasi As New childvalidasi
    Private childalat As New childalat
    Private search As New Search
    Private read As New Read
    Private check As New Check
    Private updatee As New Update
    Private delete As New Delete
    Private _aksi, _kode, nama As String
    Public Property aksi As String
        Get
            Return _aksi
        End Get
        Set(value As String)
            _aksi = value
        End Set
    End Property
    Sub New(aksi As String)
        InitializeComponent()
        _aksi = aksi
    End Sub
    
    Public Function refreshdata()
        DataGridView1.DataSource = search.searchpengunjung(TextBox1.Text)
        ceklabel()
        Return True
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        _kode = DataGridView1.CurrentRow.Cells(0).Value.ToString
        nama = DataGridView1.CurrentRow.Cells(1).Value.ToString
        If _aksi = "admin" Then
            Button6.Show()
        End If
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

    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showall()
        Button6.Hide()
        If DataGridView1.RowCount() < 1 Then
            Label4.Show()
        Else
            Label4.Hide()
        End If
    End Sub

    Private Sub ceklabel()
        If DataGridView1.RowCount() < 1 Then
            Label4.Show()
        Else
            Label4.Hide()
        End If
    End Sub
    Public Sub showall()
        DataGridView1.Show()
        DataGridView1.DataSource = search.searchpengunjung("PNJ")
        ceklabel()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = validasi.cekdoublespasi(TextBox1.Text)
        TextBox1.Select(TextBox1.Text.Length, 0)
        refreshdata()
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Anda yakin untuk Menghapus " + nama + " dari daftar pengunjung ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            updatee.updatepengunjung(_kode, "", "")
            If delete.bool = True Then
                showall()
                MsgBox("Data pengunjung telah dihapus", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim a As New cetak("pengunjung")
        a.Show()
    End Sub
End Class