Imports EmployeesLibrary

<TestClass()>
Public Class ThirdUnitTest
    Private Shared Eh As EmployeesHelper
    Private Shared Empl As EmployeeModel

#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
    '
    ' Use ClassInitialize to run code before running the first test in the class
    <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
        Eh = New EmployeesHelper("employees.json")
        Empl = New EmployeeModel() With {
            .Id = 999,
            .FirstName = "TestFirstName999",
            .LastName = "TestLastName999",
            .Mail = "test999@mail.com"
        }
        Eh.AddEmployee(Empl)
    End Sub
    '
    ' Use ClassCleanup to run code after all tests in a class have run
    <ClassCleanup()> Public Shared Sub MyClassCleanup()
        Eh.DeleteEmployee(999)
    End Sub
    '
    ' Use TestInitialize to run code before running each test
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Use TestCleanup to run code after each test has run
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region

    <TestMethod()>
    Public Sub TestSearchById()
        Dim Empl = Eh.GetEmployeeById(999)
        Assert.AreEqual(ThirdUnitTest.Empl, Empl)
    End Sub

    <TestMethod()>
    Public Sub TestSearchByFirstName()
        Dim empl = Eh.GetEmployeeByName("TestFirstName999")
        Assert.AreEqual(ThirdUnitTest.Empl, empl)
    End Sub

    <TestMethod()>
    Public Sub TestSearchByLastName()
        Dim empl = Eh.GetEmployeeByName("TestLastName999")
        Assert.AreEqual(ThirdUnitTest.Empl, empl)
    End Sub

    <TestMethod()>
    Public Sub TestSearchByMail()
        Dim empl = Eh.GetEmployeeByMail("test999@mail.com")
        Assert.AreEqual(ThirdUnitTest.Empl, empl)
    End Sub

End Class
