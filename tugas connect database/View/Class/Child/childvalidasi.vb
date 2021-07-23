Imports System.Text.RegularExpressions
Public Class childvalidasi
    Inherits classParent

    Public Sub pressangka(e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Public Sub presspass(e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or (e.KeyChar >= "0" And e.KeyChar <= "9") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Public Sub pressemail(e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or (e.KeyChar >= "0" And e.KeyChar <= "9") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = vbBack Or e.KeyChar = "@" Or e.KeyChar = "." Or e.KeyChar = "_") Then
            e.Handled = True
        End If
    End Sub

    Public Sub pressuser(e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or (e.KeyChar >= "0" And e.KeyChar <= "9") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = vbBack Or e.KeyChar = "_") Then
            e.Handled = True
        End If
    End Sub

    Public Sub presskata(e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "A" And e.KeyChar <= "Z") Or ((e.KeyChar >= "a" And e.KeyChar <= "z")) Or e.KeyChar = " " Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Public Function cekangka(a As String)
        Try
            a.Split()
            kaki = 0
            If a(0) = "0" Then
                a = ""
            End If
        Catch ex As Exception
        End Try
        Return a
    End Function

    Public Function batas5(a As String) As Boolean
        If a.Length < 5 Then
            bool = False
        Else
            bool = True
        End If
        Return bool
    End Function

    Public Function cekspasiawal(a As String)
        Try
            a.Split()
            If a(0) = " " Then
                a = ""
            End If
        Catch ex As Exception
        End Try
        Return a
    End Function

    Public Function cekdoublespasi(a As String)
        kaku = a
        kaki = ""
        Try
            kaku.Split()
            For i = 0 To a.Length - 1
                If kaku(i) = " " And kaku(i + 1) = " " Then
                    For j = 0 To i
                        kaki += kaku(j)
                    Next
                    a = kaki
                Else
                    a.Split()
                    If a(0) = " " Then
                        kaki = ""
                        For j = 1 To a.Length - 1
                            kaki += a(j)
                        Next
                        a = kaki
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
        Return a
    End Function

    Public Function cekkosong(a As String) As Boolean
        hasilvalidasi = False
        If a = "" Then
            hasilvalidasi = False
        Else
            hasilvalidasi = True
        End If
        Return hasilvalidasi
    End Function

    Public Function satuhuruf(a As String) As Boolean
        If a.Length = 1 Then
            bool = True
        Else
            bool = False
        End If
        Return bool
    End Function
End Class