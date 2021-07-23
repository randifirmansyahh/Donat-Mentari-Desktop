Public Class Check
    Inherits parentCrud

    Public Function cekbanyakkomentar() As DataTable
        _query = "select * from pengunjung where komentar !=''"
        Dim hus As New DataTable
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(hus)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return hus
    End Function

    Public Function checkcountwhere(apa As String, dari As String, status As String, Tanggal As String) As String
        tabel = New DataTable
        _query = "select count(" + apa + ") from " + dari + " where Status ='" + status + "' and Tanggal='" + Tanggal + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            str = tabel.Rows(0).Item(0)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return str
    End Function

    Public Function namapemesan(nama As String) As String
        tabel = New DataTable
        _query = "select Nama from pesanan where Nama ='" + nama.ToLower + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            str = tabel.Rows(0).Item(0)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return str
    End Function

    Public Function total()
        tabel = New DataTable
        _query = "select sum(total) from Pesanan where Status='Berhasil'"
        str = ""
        Try
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            str = tabel.Rows(0).Item(0)
        Catch ex As Exception
        End Try
        Return str
    End Function























    Public Function checkcount(dari As String) As String
        tabel = New DataTable
        _query = "select count(Kode) from " + dari
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            str = tabel.Rows(0).Item(0)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return str
    End Function

    Public Function cekop(a As String, b As String, c As String) As String
        Return cekloginoperator(a, b, c)
    End Function

    

    Private Function cekloginoperator(a As String, b As String, c As String) As String
        tabel = New DataTable
        _query = "select * from " + a + " where username='" + b + "'"
        str = ""
        Try
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            If tabel.Rows(0).Item(0) = b And tabel.Rows(0).Item(1) = c Then
                str = "1"
            ElseIf tabel.Rows(0).Item(0) = b And tabel.Rows(0).Item(1) <> c Then
                str = "2"
            Else
                str = "3"
            End If
        Catch ex As Exception
        End Try
        Return str
    End Function

    Public Function avaliable(dari As String, siapa As String, apa As String) As Boolean
        Dim a As Boolean
        tabel = New DataTable
        str = ""
        _query = "select Pasien from " + dari + " where " + siapa + "='" + apa + "'"
        cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
        a = True
        cmd_a.Fill(tabel)
        Try
            str = tabel.Rows(0).Item(0)
        Catch ex As Exception
            Return a = True
        End Try
        If str <> apa Then
            a = False
        Else
            a = True
        End If
        Return a
    End Function
    Public Function checkmax(dari As String) As String
        tabel = New DataTable
        _query = "select max(Kode) from " + dari
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            str = tabel.Rows(0).Item(0)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return str
    End Function

    Public Function querybebastable(a As String) As DataTable
        Dim _query As String = a
        Dim hus As New DataTable
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(hus)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return hus
    End Function

    

    Public Function checkcountfromwhatwhere(dari As String, what As String, where As String) As String
        tabel = New DataTable
        _query = "select count(Kode) from " + dari + " where " + what + "='" + where + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            str = tabel.Rows(0).Item(0)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return str
    End Function

    Public Function email() As DataTable
        _query = "select * from pengunjung where komentar !='' or email!='' order by(Kode) desc"
        Dim hus As New DataTable
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(hus)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return hus
    End Function

End Class