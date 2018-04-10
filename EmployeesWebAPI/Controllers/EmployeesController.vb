Imports System.Web.Http
Imports EmployeesLibrary

Public Class EmployeesController
    Inherits ApiController

    Private eh = New EmployeesHelper("employees.json")

    ' GET api/employees
    Public Function GetEmployees() As IEnumerable(Of String)
        Dim employees = New List(Of String)
        For Each empl In eh.GetEmployees()
            employees.Add(empl.ToString())
        Next
        Return employees
    End Function


    ' GET api/employees/117
    Public Function GetEmployee(ByVal id As Integer) As String
        Return eh.GetEmployeeById(id).ToString()
    End Function

    ' POST api/employees
    Public Sub PostEmployee(<FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/employees/2
    Public Sub DeleteEmployee(ByVal id As Integer)
        eh.DeleteEmployee(id)
    End Sub
End Class
