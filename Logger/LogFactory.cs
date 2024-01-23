#nullable enable
using System;

namespace Logger;


public class LogFactory
{
    private string? _logPath;
    public string configure(string logPath)
    {
        if (_logPath == null)
        {
            throw new ArgumentNullException(nameof(logPath), " File path can not be null"); ;
        }
        else
        {
            _logPath = logPath;
            return _logPath;
        }
    }

  

    public BaseLogger? CreateLogger(string className)
    {
        if (_logPath == null)
        {
            throw new ArgumentNullException(nameof(className), " File path can not be null"); ;
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
