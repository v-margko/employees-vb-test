Imports System.Text
Imports EmployeesLibrary
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class FirstTest
    Private Shared Eh As EmployeesHelper

    <ClassInitialize()> Public Shared Sub Init(ByVal testContext As TestContext)
        Eh = New EmployeesHelper("employees.json")
    End Sub

    <TestMethod()> Public Sub TestAddingEmployee()
        Dim model = New EmployeeModel With {
            .Id = 987,
            .FirstName = "TestName",
            .LastName = "TestLastName",
            .Mail = "test@mail.com"
        }
        CollectionAssert.DoesNotContain(Eh.GetEmployees(), model)
        Eh.AddEmployee(model)
        CollectionAssert.Contains(Eh.GetEmployees(), model)
    End Sub

End Class
