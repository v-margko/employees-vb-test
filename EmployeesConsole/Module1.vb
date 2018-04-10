Imports System.Configuration
Imports EmployeesLibrary

Module Module1
    Private eh As EmployeesHelper
    Private employees As List(Of EmployeeModel)

    Sub Main()
        eh = New EmployeesHelper(ConfigurationSettings.AppSettings.Get("EmployeesFilePath"))
        employees = eh.GetEmployees()
        While True
            Console.WriteLine("Input command ('exit' to stop): ")
            Dim command = Console.ReadLine()
            Select Case command
                Case "exit"
                    Return
                Case "getall"
                    PrintAllEmployees()
                Case "get"
                    Console.WriteLine("Input id, name or mail: ")
                    GetEmployee(Console.ReadLine())
            End Select
        End While
        Console.Read()
    End Sub

    Sub PrintAllEmployees()
        For Each empl In employees
            Console.WriteLine(empl)
            Console.WriteLine()
        Next
    End Sub

    Sub GetEmployee(finder As String)
        Dim result As EmployeeModel
        Dim id = -1
        Dim parsed = Integer.TryParse(finder, id)
        If (parsed) Then
            result = eh.GetEmployeeById(id)
        ElseIf (finder.Contains("@")) Then
            result = eh.GetEmployeeByMail(finder)
        Else
            result = eh.GetEmployeeByName(finder)
        End If
        If Not IsNothing(result) Then
            Console.WriteLine(result)
        Else
            Console.WriteLine("Not found!")
        End If
    End Sub

End Module
