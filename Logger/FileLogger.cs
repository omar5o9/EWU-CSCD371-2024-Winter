#nullable enable
using System;
using System.IO;

namespace Logger;

public class FileLogger : BaseLogger
{
    private readonly string? FilePath;
    


    public FileLogger(string filePath)

    {
        this.FilePath = filePath;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        if (FilePath == null)
        {
            throw new ArgumentNullException();
        }
        DateTime date = DateTime.Now;
        string currentDate = date.ToString("MM-dd-yyyy HH:mm:ss tt");
        string s = $"{currentDate} {nameof(FileLogger)} {logLevel}: {message}";
        File.AppendAllText(path: FilePath, contents: s + Environment.NewLine + message);
    }

}

