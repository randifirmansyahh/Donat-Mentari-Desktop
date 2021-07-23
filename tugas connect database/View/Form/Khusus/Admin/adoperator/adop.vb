Public Class adop
    Private validasi As New childvalidasi
    Private search As New Search
    Private read As New Read
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
        DataGridView1.DataSource = search.searchoperator(Textbox1.text)
        ceklabel()
    End Sub

    Private Sub oppasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hidebut()
        showall()
        ceklabel()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim opaddoredit As New adeditop("tambah", kode())
        opaddoredit.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If kode() = "" Then
            MsgBox("Belum ada data terpilih")
        Else
            Try
                hidebut()
                Dim edit As New adeditop("edit", kode())
                edit.ShowDialog()
            Catch ex As Exception
                MsgBox("Tidak ada data yang terpilih")
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        menuad.Show()
    End Sub
    Public Sub showall()
        hidebut()
        DataGridView1.Show()
        DataGridView1.DataSource = read.viewdata("operator")
    End Sub

    Private Sub ceklabel()
        If DataGridView1.RowCount < 1 Then
            Label4.Show()
        Else
            Label4.Hide()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub hidebut()
        Button5.Hide()
        Button6.Hide()
    End Sub

    Private Sub Textbox1_OnTextChange(sender As Object, e As EventArgs) Handles Textbox1.OnTextChange
        If validasi.cekkosong(Textbox1.text) = False Then
            DataGridView1.DataSource = read.viewdata("operator")
            hidebut
        Else
            refreshdata()
            DataGridView1.Show()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        kode() = DataGridView1.CurrentRow.Cells(0).Value.ToString
        showbut()
    End Sub

    Private Sub showbut()
        Button5.Show()
        Button6.Show()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Anda yakin untuk Menghapus " + kode() + " ?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            delete.deletefromwhatwhere("operator", "Username", kode())
            If delete.bool = True Then
                MsgBox("Data Operator Telah terhapus", MsgBoxStyle.Information)
                hidebut()
                showall()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showall()
    End Sub
End Class