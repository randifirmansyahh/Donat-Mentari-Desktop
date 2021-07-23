Imports System.Net.Mail
Public Class childsendmail
    Inherits classParent
    Private _ke, _user, _kode As String

    Public Sub alatproperty(a As String, b As String, c As String)
        ke() = a
        user() = b
        kode() = c
        send()
    End Sub

    Private Property kode As String
        Get
            Return _kode
        End Get
        Set(value As String)
            _kode = value
        End Set
    End Property
    Private Property user As String
        Get
            Return _user
        End Get
        Set(value As String)
            _user = value
        End Set
    End Property
    Private Property ke As String
        Get
            Return _ke
        End Get
        Set(value As String)
            _ke = value
        End Set
    End Property

    Public Function verifikasi(a As String, b As String, c As String)
        ke() = a
        user() = b
        kode() = c
        sendverivikasi()
        Return bool
    End Function
    Public Function balaskomentar(a As String, b As String, c As String)
        Try
            MsgBox("Mohon tunggu kami akan mengirim Balasan komentar Kepada pengunjung", MsgBoxStyle.Information)
            Dim mail As MailMessage = New MailMessage()
            Dim SmtpServer As SmtpClient = New SmtpClient("smtp.gmail.com")
            mail.From = New MailAddress("donatmentarienak@gmail.com")
            mail.To.Add(a)
            mail.Subject = "Terima Kasih telah memberi masukan kepada Donat Mentari"
            mail.Body = "Hallo " + a + ", Atas komentar anda sbb : " + b + ". Maka Kami Menjawab : " + c
            SmtpServer.Port = 587
            SmtpServer.Credentials = New System.Net.NetworkCredential("donatmentarienak@gmail.com", "2012diundur")
            SmtpServer.EnableSsl = True
            SmtpServer.Send(mail)
            MsgBox("Email Terkirim", MsgBoxStyle.Information)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Pengiriman email gagal, mungkin email yang pengunjung masukan salah")
        End Try
        Return bool
    End Function

    Private Function sendverivikasi()
        Try
            MsgBox("Mohon tunggu, kami akan mengirim Verifikasi akun kepada email kepada anda", MsgBoxStyle.Information)
            Dim mail As MailMessage = New MailMessage()
            Dim SmtpServer As SmtpClient = New SmtpClient("smtp.gmail.com")
            mail.From = New MailAddress("donatmentarienak@gmail.com")
            mail.To.Add(ke)
            mail.Subject = "Verifikasi Akun Donat Mentari"
            mail.Body = "Hallo " + user + " kode verifikasi akun Donat mentari kamu adalah : " + _kode
            SmtpServer.Port = 587
            SmtpServer.Credentials = New System.Net.NetworkCredential("donatmentarienak@gmail.com", "2012diundur")
            SmtpServer.EnableSsl = True
            SmtpServer.Send(mail)
            MsgBox("Email Terkirim mohon cek email anda untuk verifikasi", MsgBoxStyle.Information)
            bool = True
        Catch ex As Exception
            bool = False
            MsgBox("Pengiriman email gagal, mungkin email yang anda masukan salah")
        End Try
        Return bool
    End Function

    Private Sub send()
        Try
            MsgBox("Mohon tunggu, kami akan mengirim Password akun kepada email kepada anda", MsgBoxStyle.Information)
            Dim mail As MailMessage = New MailMessage()
            Dim SmtpServer As SmtpClient = New SmtpClient("smtp.gmail.com")
            mail.From = New MailAddress("donatmentarienak@gmail.com")
            mail.To.Add(ke)
            mail.Subject = "Verifikasi Password Donat Mentari"
            mail.Body = "Hallo " + user + " Password Donat Mentari kamu adalah : " + _kode
            SmtpServer.Port = 587
            SmtpServer.Credentials = New System.Net.NetworkCredential("donatmentarienak@gmail.com", "2012diundur")
            SmtpServer.EnableSsl = True
            SmtpServer.Send(mail)
            MessageBox.Show("Email Terkirim")
        Catch ex As Exception
            MsgBox("Pengiriman email gagal, mungkin email yang anda masukan sebelumnya sudah diblokir anda dapat menghubungi admin untuk info lebih lanjut", MsgBoxStyle.Information)
        End Try
    End Sub
End Class