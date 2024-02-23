namespace Calculator.Tests;
using Calculate;
using Xunit;

public class CalculateTests
{
    [Fact]
    public void Assert_CalculateAdd_Correctly()
    {
        double addTest = Calculator.Add(1, 2);

        Assert.Equal(3, addTest);
    }

    [Fact]
    public void Assert_CalculateSubtract_Correctly()
    {
        double subtractTest = Calculator.Subtract(1, 2);

        Assert.Equal(-1, subtractTest);
    }

    [Fact]
    public void Assert_CalculateMultiply_Correctly()
    {
        double multiplyTest = Calculator.Multiply(1, 2);

        Assert.Equal(2, multiplyTest);
    }

    [Fact]
    public void Assert_CalculateDivide_Correctly()
    {
        double divideTest = Calculator.Divide(1, 2);

        Assert.Equal(0.5, divideTest);
    }

    [Fact]
    public void Assert_CalculateTryCalculate_Correctly()
    {
        Calculator calculator = new();

        bool tryCalculateTest = calculator.TryCalculate("1 + 2", out double result);

        Assert.True(tryCalculateTest);
        Assert.Equal(3, result);
    }

    [Fact]
    public void Assert_CalculateTryCalculate_InvalidInput()
    {
        Calculator calculator = new();

        bool tryCalculateTest = calculator.TryCalculate("1 + 2 + 3", out double result);

        Assert.False(tryCalculateTest);
    }

    [Fact]
    public void Assert_CalculateTryCalculate_InvalidNumber()
    {
        Calculator calculator = new();

        bool tryCalculateTest = calculator.TryCalculate("a + 2", out double result);

        Assert.False(tryCalculateTest);
    }

    [Fact]
    public void Assert_CalculateTryCalculate_InvalidOperation()
    {
        Calculator calculator = new();

        bool tryCalculateTest = calculator.TryCalculate("1 ^ 2", out double result);

        Assert.False(tryCalculateTest);
    }

    [Fact]
    public void Assert_DivideByZero()
    {

        Assert.Throws<ArgumentException>(() => Calculator.Divide(1, 0));
    }
}
