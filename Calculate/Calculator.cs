using System;

namespace Calculate;
public class Calculator
{

    public static double Add(int a, int b) => a + b;
    public static double Subtract(int a, int b) => a - b;
    public static double Multiply(int a, int b) => a * b;
    public static double Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero");
        }
        return (double)a / (double)b;
    }

        
    public System.Collections.Generic.IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { get; } =
        new System.Collections.Generic.Dictionary<char, Func<int, int, double>>
    {
        {'+', Add},
        {'-', Subtract},
        {'*', Multiply},
        {'/', Divide}
    };

        
    public bool TryCalculate(string input, out double result)
    {
        result = 0;
        string[] parts = input.Split(' ');
        if (parts.Length != 3) return false;
        if (!double.TryParse(parts[0], out double a)) return false;
        if (!double.TryParse(parts[2], out double b)) return false;
        if (parts[1].Length != 1) return false;
        if (!MathematicalOperations.TryGetValue(parts[1][0], out Func<int,int,double>? operation)) return false;
        result = operation((int)a, (int)b);
        return true;
    }


}
