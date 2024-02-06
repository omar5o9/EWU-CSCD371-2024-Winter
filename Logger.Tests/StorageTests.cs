using Xunit;

namespace Logger.Tests;

public class StorageTests
{

    [Fact]
    public void Employee_Is_Created_WithProperDepartmentAndID()
    {
        Employee testEm = new()
        {
            EmployeeId = 32,
            Department = "IT"
        };

        Assert.Equal(32, testEm.EmployeeId);
        Assert.Equal("IT", testEm.Department);

    }

    [Fact]
    public void Book_IsCreated_WithProperTitleAuthorYearPublished()
    {
        Book testBook = new()
        {
            Title = "Test",
            Author = "Santi",
            YearPublished = 1989
        };

        Assert.Equal("Test", testBook.Title);
        Assert.Equal("Santi", testBook.Author);
        Assert.Equal(1989, testBook.YearPublished);
    }

    [Fact]
    public void Student_IsCreated_WithProperId()
    {
        Student testStudent = new()
        {
            StudentId = 31
        };

        Assert.Equal(31, testStudent.StudentId);
    }

    
}

