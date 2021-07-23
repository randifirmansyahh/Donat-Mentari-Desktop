Public Class cetak
    Private _aksi As String

    Private Property aksi()
        Get
            Return _aksi
        End Get
        Set(value)
            _aksi = value
        End Set
    End Property

    Sub New(a As String)
        InitializeComponent()
        aksi() = a
    End Sub

    Private Sub cetak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cetak()
    End Sub

    Private Sub cetak()
        CrystalReportViewer1.EnableRefresh = True
        If _aksi = "pasien" Then
            Dim a As New pasien
            CrystalReportViewer1.ReportSource = a
        ElseIf _aksi = "transaksi" Then
            Dim a As New transaksi
            CrystalReportViewer1.ReportSource = a
        ElseIf _aksi = "dokter" Then
            Dim a As New dokter
            CrystalReportViewer1.ReportSource = a
        ElseIf _aksi = "petugas" Then
            Dim a As New petugas
            CrystalReportViewer1.ReportSource = a
        ElseIf _aksi = "pengunjung" Then
            Dim a As New reportpengunjung
            CrystalReportViewer1.ReportSource = a
        End If
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class