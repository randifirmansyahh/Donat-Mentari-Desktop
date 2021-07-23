Public Class childdiscount
    Inherits childdiscount99

    Public Overrides Function diskon(a As String)
        a = a * 10 / 100
        Return a
    End Function
End Class
