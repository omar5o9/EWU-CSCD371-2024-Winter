#nullable enable
using System;
using System.Globalization;
using System.IO;

namespace Logger;

public class FileLogger(string? fileName) : BaseLogger
{
    private readonly string? FilePath = fileName;
    

   

    public override void Log(LogLevel logLevel, string message)
    {
        
        DateTime date = DateTime.Now;
        string currentDate = date.ToString("MM-dd-yyyy HH:mm:ss tt", CultureInfo.CurrentCulture);
        string s = $"{currentDate} {nameof(FileLogger)} {logLevel}: {message}";
        File.AppendAllText(path: FilePath, contents: s + Environment.NewLine + message);
    }

}

