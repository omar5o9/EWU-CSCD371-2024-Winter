using System;

namespace Calculate;
public class Calculator
{



    // Define static Add, Subtract, Multiple, and Divide methods that have two parameters and return a third parameter.
    public static float Add(int a, int b) => a + b;
    public static float Subtract(int a, int b) => a - b;
    public static float Multiply(int a, int b) => a * b;
    public static float Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero");
        }
        return (float)a / (float)b;
    }

        
    public System.Collections.Generic.IReadOnlyDictionary<char, Func<int, int, float>> MathematicalOperations { get; } =
        new System.Collections.Generic.Dictionary<char, Func<int, int, float>>
    {
        {'+', Add},
        {'-', Subtract},
        {'*', Multiply},
        {'/', Divide}
    };

        
    public bool TryCalculate(string input, out float result)
    {
        result = 0;
        string[] parts = input.Split(' ');
        if (parts.Length != 3) return false;
        if (!float.TryParse(parts[0], out float a)) return false;
        if (!float.TryParse(parts[2], out float b)) return false;
        if (parts[1].Length != 1) return false;
        if (!MathematicalOperations.TryGetValue(parts[1][0], out Func<int,int,float>? operation)) return false;
        result = operation((int)a, (int)b);
        return true;
    }


}
