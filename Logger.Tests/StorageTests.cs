using Xunit;

namespace Logger.Tests;

public class StorageTests
{
    private readonly Storage storage = new();
    private readonly Book book = new();
    private readonly Student student = new();
    private readonly Employee employee = new();
    
    


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

    [Fact]
    public void Storage_DoesContain_Book()
    {
        storage.Add(book);
        Assert.True(storage.Contains(book));
    }
    [Fact]
    public void Storage_DoesNotContain_Book()
    {
        Assert.False(storage.Contains(book));
    }
    [Fact]
    public void Storage_removes()
    {
        storage.Add(student);
        storage.Remove(student);
        Assert.False(storage.Contains(student));

    }

    [Fact]
    public void Storage_DoesContain_Student()
    {
        storage.Add(student);
        Assert.True(storage.Contains(student));
    }
    [Fact]
    public void Storage_DoesNotContain_Student()
    {
        Assert.False(storage.Contains(student));
    }

    [Fact]
    public void Storage_DoesContain_Employee()
    {
        storage.Add(employee);
        Assert.True(storage.Contains(employee));
    }
    [Fact]
    public void Storage_DoesNotContain_Employee()
    {
        Assert.False(storage.Contains(employee));
    }




}

