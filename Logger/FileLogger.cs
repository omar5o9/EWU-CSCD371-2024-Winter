using System;
using System.IO;

namespace Logger;
public class FileLogger : BaseLogger
{
    public string FilePath;
    

    public FileLogger(string filePath)
    {
        FilePath = filePath;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        DateTime date = DateTime.Now; 
        string s = $"{date} {this.ClassName} {logLevel}: {message}";
        File.AppendAllText(this.FilePath, s + Environment.NewLine + message);
    }

}

