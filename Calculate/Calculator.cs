using System;

namespace Calculate
{
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
            return a/ b;
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
            var parts = input.Split(' ');
            if (parts.Length != 3) return false;
            if (!int.TryParse(parts[0], out var a)) return false;
            if (!int.TryParse(parts[2], out var b)) return false;
            if (parts[1].Length != 1) return false;
            if (!MathematicalOperations.TryGetValue(parts[1][0], out var operation)) return false;
            result = operation(a, b);
            return true;
        }


    }
}
