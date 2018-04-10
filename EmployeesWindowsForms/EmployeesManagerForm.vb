Imports EmployeesLibrary
Imports System.Configuration

Public Class EmployeesManagerForm

    Private Sub GetAllEmployees(sender As Object, e As EventArgs) Handles btnGetAllEmployees.Click
        ClearList()
        Dim emp As New EmployeesHelper(ConfigurationSettings.AppSettings.Get("EmployeesFilePath"))
        Dim employees = emp.GetEmployees
        For Each item As EmployeeModel In employees
            EmployeesListBox.Items.Add(item)
        Next
    End Sub

    Private Sub SearchEmployee(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim emp As New EmployeesHelper(ConfigurationSettings.AppSettings.Get("EmployeesFilePath"))
        ClearList()
        Dim search As String = txtSearch.Text
        Dim searcId As Integer
        Int32.TryParse(search, searcId)
        Dim result As EmployeeModel = emp.GetEmployeeById(searcId)
        If result Is Nothing Then
            result = emp.GetEmployeeByName(search)
            If result Is Nothing Then
                result = emp.GetEmployeeByMail(search)
                If result Is Nothing Then
                    EmployeesListBox.Items.Add("Nothing was found")
                Else EmployeesListBox.Items.Add(result)
                End If
            Else EmployeesListBox.Items.Add(result)
            End If
        Else EmployeesListBox.Items.Add(result)
        End If
    End Sub

    Private Sub ClearList()
        Dim count As Integer = EmployeesListBox.Items.Count
        If count <> 0 Then
            For index = count - 1 To 0 Step -1
                EmployeesListBox.Items.RemoveAt(index)
            Next
        End If
    End Sub

    Private Sub AddEmployee(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim newEmp As EmployeeModel = New EmployeeModel
        newEmp.Id = Convert.ToInt32(txtId.Text)
        newEmp.FirstName = txtFirstName.Text
        newEmp.LastName = txtLastName.Text
        newEmp.Mail = txtEmail.Text
        Dim emp As New EmployeesHelper(ConfigurationSettings.AppSettings.Get("EmployeesFilePath"))
        emp.AddEmployee(newEmp)
        GetAllEmployees(sender, e)
    End Sub

    Private Sub RemoveEmployee(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim emp As New EmployeesHelper(ConfigurationSettings.AppSettings.Get("EmployeesFilePath"))
        Dim empToRemove As EmployeeModel = EmployeesListBox.SelectedItem
        emp.DeleteEmployee(empToRemove.Id)
        GetAllEmployees(sender, e)
    End Sub
End Class