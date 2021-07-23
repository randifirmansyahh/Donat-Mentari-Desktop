Imports System.Drawing.Bitmap

Public Class operatorinputberita
    Private create As New Create
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog Then
            PictureBox1.Image = FromFile(OpenFileDialog1.FileName)
            Label1.Text = "Nama file: " + OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenFileDialog1.Title = "Masukkan foto anda"
        OpenFileDialog1.Filter = "JPEG File|*.jpg;*.jpeg;*.png"
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            PictureBox1.SizeMode = PictureBoxSizeMode.Normal
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Anda yakin untuk keluar dari aplikasi?", MsgBoxStyle.YesNo, "pilihan") = MsgBoxResult.Yes Then
            create.insertberita(TextBox1.Text, RichTextBox1.Text, OpenFileDialog1.FileName)
            MsgBox("Selamat, Sekarang orang orang dapat melihat berita rumah sakit ini")
            Me.Hide()
            userberita.Show()
        End If
    End Sub
End Class