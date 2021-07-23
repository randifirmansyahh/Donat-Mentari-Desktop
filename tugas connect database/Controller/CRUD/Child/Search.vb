Public Class Search
    Inherits parentCrud

    Public Overloads Function WhatFromWhatWhere(apa As String, from As String, apa2 As String, gimana As String) As DataTable
        tabel = New DataTable
        _query = "select " + apa + " from " + from + " where " + apa2 + "='" + gimana + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Overloads Function WhatFromWhatLikePesananTanggal(apa As String, from As String, gimana As String, stat As String, tgl As String) As DataTable
        tabel = New DataTable
        _query = "select " + apa + " from " + from + " where (Nama Like '%" + gimana + "%' or Nama Like '%" + gimana + "%' or Jenis Like '%" + gimana + "%' or Banyak Like '%" + gimana + "%' or Total Like '%" + gimana + "%' or Tanggal Like '%" + gimana + "%') and Status='" + stat + "' and Tanggal='" + tgl + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Overloads Function AllWhatFromWhatLikePesananTanggal(apa As String, from As String, gimana As String, tgl As String) As DataTable
        tabel = New DataTable
        _query = "select " + apa + " from " + from + " where (Nama Like '%" + gimana + "%' or Nama Like '%" + gimana + "%' or Jenis Like '%" + gimana + "%' or Banyak Like '%" + gimana + "%' or Total Like '%" + gimana + "%' or Tanggal Like '%" + gimana + "%') and Tanggal='" + tgl + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Overloads Function WhatFromWhatLikePesanan(apa As String, from As String, gimana As String, stat As String) As DataTable
        tabel = New DataTable
        _query = "select " + apa + " from " + from + " where (Nama Like '%" + gimana + "%' or Nama Like '%" + gimana + "%' or Jenis Like '%" + gimana + "%' or Banyak Like '%" + gimana + "%' or Total Like '%" + gimana + "%' or Tanggal Like '%" + gimana + "%') and Status='" + stat + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Overloads Function WhatFromWhatAllLikePesanan(apa As String, from As String, gimana As String) As DataTable
        tabel = New DataTable
        _query = "select " + apa + " from " + from + " where Nama Like '%" + gimana + "%' or Nama Like '%" + gimana + "%' or Jenis Like '%" + gimana + "%' or Banyak Like '%" + gimana + "%' or Total Like '%" + gimana + "%' or Tanggal Like '%" + gimana + "%'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function














    Public Overloads Function searchinap(cari As String, b As String) As DataTable
        tabel = New DataTable
        _query = "select c.Kode,a.Nama,b.Nama as Ditangani,a.Alamat,a.Agama,a.TTL,a.Kedatangan,a.Keluhan,c.ruang from pasien a inner join dokter b inner join inap c where a.Kode not in(select Pasien from pembayaran) and a.Ditangani=b.Kode and a.Kode=c.Pasien and (c.Kode like '%" + cari + "%' or a.Nama like '%" + cari + "%' or b.Nama like '%" + cari + "%' or a.Alamat like '%" + cari + "%' or a.Agama like '%" + cari + "%' or a.TTL like '%" + cari + "%' or a.Kedatangan like '%" + cari + "%' or a.Keluhan like '%" + cari + "%' or c.Ruang like '%" + cari + "%')"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Overloads Function searchpasien(cari As String, b As String) As DataTable
        tabel = New DataTable
        _query = "select a.Kode,a.Nama,b.Nama as Ditangani,a.Alamat,a.Agama,a.TTL,a.Kedatangan,a.Keluhan from pasien a inner join dokter b where a.Kode not in(select Pasien from pembayaran) and a.Ditangani=b.Kode and (a.Kode like '%" + cari + "%' or b.Nama like '%" + cari + "%' or a.Nama like '%" + cari + "%' or a.Alamat like '%" + cari + "%' or a.Agama like '%" + cari + "%' or a.TTL like '%" + cari + "%' or a.Kedatangan like '%" + cari + "%' or a.Keluhan like '%" + cari + "%')"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Overloads Function searchcomboinap(cari As String, b As String) As DataTable
        tabel = New DataTable
        _query = "select a.Kode,a.Nama,a.Keluhan from pasien a where a.Kode not in(select Pasien from inap)"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Function searchoperator(cari As String) As DataTable
        tabel = New DataTable
        _query = "select * from operator order by(Kode)desc where Username like '%" + cari + "%' or Password like '%" + cari + "' or Email like '%" + cari + "%'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
        End Try
        Return tabel
    End Function

    Public Function searchfoto() As DataTable
        tabel = New DataTable
        _query = "select * from berita order by(kode)desc"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function
    Public Function searchdokter(cari As String) As DataTable
        tabel = New DataTable
        _query = "select a.kode as Kode,a.nama as Nama,b.namajenis as Jenis,a.alamat as Alamat,a.agama as Agama,a.ttl TTL from dokter a inner join jenisdokter b where a.jenis=b.kode and a.Kode like '%" + cari + "%' or a.Nama like '%" + cari + "%' or a.Alamat like '%" + cari + "%' or a.Agama like '%" + cari + "%' or a.TTL like '%" + cari + "%' or b.namajenis like '%" + cari + "%'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Function searchpetugas(cari As String) As DataTable
        tabel = New DataTable
        _query = "select * from petugas where Kode like '%" + cari + "%' or Divisi like '%" + cari + "%' or Nama like '%" + cari + "%' or Alamat like '%" + cari + "%' or Agama like '%" + cari + "%' or TTL like '%" + cari + "%'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Function searchdetail(cari As String) As DataTable
        tabel = New DataTable
        _query = "select a.Kode,c.Kode as Entri,d.Kedatangan, c.Diterima,d.Kode as No, d.Nama as Pasien, c.Pembayaran from detail a inner join pembayaran c inner join pasien d where a.Pembayaran = c.Kode and c.Pasien=d.Kode and (a.Kode like '%" + cari + "%' or c.Diterima like '%" + cari + "%' or d.Nama like '%" + cari + "%' or c.Pembayaran like '%" + cari + "%')"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function

    Public Function searchpengunjung(cari As String) As DataTable
        tabel = New DataTable
        _query = "select Kode , Nama ,Keperluan from pengunjung where Kode like '%" + cari + "%' or Nama like '%" + cari + "%' or Keperluan like '%" + cari + "'"
        Try
            bool = False
            cmd_a = New MySql.Data.MySqlClient.MySqlDataAdapter(_query, openconnection())
            cmd_a.Fill(tabel)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Data Kosong")
        End Try
        Return tabel
    End Function
End Class