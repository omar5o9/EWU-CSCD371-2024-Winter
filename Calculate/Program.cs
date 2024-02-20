namespace Calculate;

public class Program
{
    // Define two init-only setter properties, WriteLine and ReadLine, that contain delegates for writing a line of text and reading a line of text respectively

    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string> ReadLine { get; init; } = Console.ReadLine;

    public Program()
    {

    }


}
