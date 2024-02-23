namespace Calculator.Tests;
using Xunit;
using Calculate;

public class ProgramTests
{
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

    
}
