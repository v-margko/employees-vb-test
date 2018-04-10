Public Class EmployeeModel

    Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Mail As String

    Public Overrides Function ToString() As String
        Return String.Format(" ID: {0}" & vbNewLine & " First Name: {1}" & vbNewLine & " Last Name: {2}" & vbNewLine & " E-mail: {3}", Id, FirstName, LastName, Mail)
    End Function

End Class
