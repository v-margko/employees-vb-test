Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports EmployeesLibrary

<TestClass()> Public Class UnitTestsForGettingEmployee

    <TestMethod()> Public Sub TestMethodForGettingEmployeeById()
        Dim eh As New EmployeesHelper("employees.json")
        Dim actualEmployee = eh.GetEmployeeById(4)
        Dim expectedEmployee As New EmployeeModel()
        expectedEmployee.FirstName = "Olga"
        expectedEmployee.LastName = "Bozova"
        expectedEmployee.Id = 4
        expectedEmployee.Mail = "obz@mail.com"
        Assert.IsTrue(actualEmployee.ToString() = expectedEmployee.ToString())
    End Sub

    <TestMethod()> Public Sub TestMethodForGettingEmployeeByMail()
        Dim eh As New EmployeesHelper("employees.json")
        Dim actualEmployee = eh.GetEmployeeByMail("obz@mail.com")
        Dim expectedEmployee As New EmployeeModel()
        expectedEmployee.FirstName = "Olga"
        expectedEmployee.LastName = "Bozova"
        expectedEmployee.Id = 4
        expectedEmployee.Mail = "obz@mail.com"
        Assert.IsTrue(actualEmployee.ToString() = expectedEmployee.ToString())
    End Sub
    <TestMethod()> Public Sub TestMethodForGettingEmployeeByName()
        Dim eh As New EmployeesHelper("employees.json")
        Dim actualEmployee = eh.GetEmployeeByName("Olga")
        Dim expectedEmployee As New EmployeeModel()
        expectedEmployee.FirstName = "Olga"
        expectedEmployee.LastName = "Bozova"
        expectedEmployee.Id = 4
        expectedEmployee.Mail = "obz@mail.com"
        Assert.IsTrue(actualEmployee.ToString() = expectedEmployee.ToString())
    End Sub

    <TestMethod()> Public Sub AddTest()
        Dim a As Integer = 5
        Dim b As Integer = 10
        Dim c = EmployeesHelper.MakeSum(a, b)
        Assert.IsTrue(c = 15)
    End Sub

End Class