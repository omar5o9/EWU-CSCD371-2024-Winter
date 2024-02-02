using System;

namespace CanHazFunny;

public class OutputService : IPrintJokeInterface
{
    public void PrintJokeToScreen(string joke)
    {
        ArgumentNullException.ThrowIfNull(joke);
        Console.WriteLine(joke);
    }
}
