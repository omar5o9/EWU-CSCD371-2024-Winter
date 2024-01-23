#nullable enable
using System;

namespace Logger;


public class LogFactory
{
    private readonly string? _logPath;

  

    public BaseLogger? CreateLogger(string className)
    {
        if (_logPath == null)
        {
            throw new ArgumentNullException(nameof(FileLogger), " File path can not be null"); ;
        }
        else
        {
            FileLogger logg = new (_logPath!)
            {
                ClassName = className,
               
            };
            return logg;
        }
    }


    
}
