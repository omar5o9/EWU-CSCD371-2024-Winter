#nullable enable
using System;
using System.IO;

namespace Logger;

public class FileLogger : BaseLogger
{
    public string FilePath;
    

    public FileLogger(string className, string filePath)
    {
        ClassName = className;
        FilePath = filePath;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        DateTime date = DateTime.Now;
        string currentDate = date.ToString("MM-dd-yyyy HH:mm:ss tt");
        string s = $"{currentDate} {nameof(FileLogger)} {logLevel}: {message}";
        File.AppendAllText(this.FilePath, s + Environment.NewLine + message);
    }

}

