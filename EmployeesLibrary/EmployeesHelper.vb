Imports EmployeesLibrary
Imports Newtonsoft.Json

Public Class EmployeesHelper

    Private employees As List(Of EmployeeModel)
    Private employeesString As String
    Private pathToJson As String

    Public Sub New(pathToJson As String)
        Me.pathToJson = pathToJson

        employeesString = My.Computer.FileSystem.ReadAllText(IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathToJson))
        employees = JsonConvert.DeserializeObject(Of List(Of EmployeeModel))(employeesString)
    End Sub

    Public Function GetEmployees() As List(Of EmployeeModel)
        employees.Sort(Function(emp1, emp2) emp1.Id.CompareTo(emp2.Id))
        Return employees
    End Function

    Public Function GetEmployeeById(id As Integer) As EmployeeModel
        Return employees.Find(Function(empl) empl.Id = id)
    End Function

    Public Function GetEmployeeByMail(mail As String) As EmployeeModel
        Return employees.Find(Function(empl) empl.Mail = mail)
    End Function

    Public Function GetEmployeeByName(name As String) As EmployeeModel
        Return employees.Find(Function(empl) name.Contains(empl.FirstName))
    End Function

    Public Function DeleteEmployee(id As Integer)
        employees.Remove(employees.Find(Function(empl) empl.Id = id))
        My.Computer.FileSystem.WriteAllText(IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathToJson), JsonConvert.SerializeObject(employees), False)
    End Function
End Class
