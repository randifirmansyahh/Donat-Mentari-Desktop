Public Class opupdatepasien
    Private updatee As New Update
    Private childalat As New childalat
    Private read As New Read
    Private check As New Check
    Private _kode As String
    Private search As New Search
    Private dialpasien As New oppasien
    Public Property kode As String
        Get
            Return _kode
        End Get
        Set(value As String)
            _kode = value
        End Set
    End Property
    Private Sub showdatadokter()
        childalat.tabel = New DataTable
        childalat.tabel = read.viewwhere(_kode, "pasien")
        ComboBox1.Text = childalat.tabel.Rows(0).Item(1)
        Textusername.Text = childalat.tabel.Rows(0).Item(2)
        TextBox1.Text = childalat.tabel.Rows(0).Item(3)
        TextBox2.Text = childalat.tabel.Rows(0).Item(4)
        DateTimePicker1.Value = childalat.tabel.Rows(0).Item(5)
        DateTimePicker2.Value = childalat.tabel.Rows(0).Item(6)
        TextBox3.Text = childalat.tabel.Rows(0).Item(7)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        updatee.updatepasienordokter(_kode, ComboBox1.Text, Textusername.Text, TextBox1.Text, TextBox2.Text, CStr(DateTimePicker1.Value), CStr(DateTimePicker2.Value), TextBox3.Text)
        If updatee.bool = True Then
            dialpasien.ShowDialog()
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub opupdatepasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combodokter()
        showdatadokter()
    End Sub
    Private Sub combodokter()
        Try
            For i = 0 To check.checkcount("dokter") - 1
                ComboBox1.Items.Add(read.viewdata("dokter").Rows(i).Item(2))
            Next
        Catch ex As Exception
            MsgBox("Combobox gagal diload")
        End Try
    End Sub
End Class