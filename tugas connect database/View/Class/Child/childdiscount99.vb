Public Class childdiscount99
    Inherits classParent

    Public Overridable Function diskon(a As String)
        a = Val(a) * 99 / 100
        Return a
    End Function
End Class
