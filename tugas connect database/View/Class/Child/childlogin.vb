Public Class childlogin
    Inherits childloginadmin
    Private coba As Integer = 3
    Public Overrides Function banyaklogin() As Integer
        Return coba
    End Function
End Class