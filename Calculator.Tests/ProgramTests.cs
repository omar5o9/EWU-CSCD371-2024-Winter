namespace Calculator.Tests;
using Xunit;
using Calculate;

public class ProgramTests
{
    // Write a test that sets these properties at construction time and then invokes the properties and verifies the expected behavior occurs
    [Fact]
    public void TestWriteLineAndReadLine()
    {
        // Arrange
        string expected = "Hello, World!";
        string actual = string.Empty;
        Program program = new()
        {
            WriteLine = (s) => actual = s,
            ReadLine = () => expected
        };

        // Act
        program.WriteLine(expected);

        // Assert
        Assert.Equal(expected, actual);
    }

    // Now write one that fails
    [Fact]
    public void TestWriteLineAndReadLineFail()
    {
        // Arrange
        string expected = "Hello, World!";
        string actual = string.Empty;
        Program program = new()
        {
            WriteLine = (s) => actual = s,
            ReadLine = () => expected
        };

        // Act
        program.WriteLine(expected);

        // Assert
        Assert.NotEqual("Goodbye, World!", actual);
    }
    
}
