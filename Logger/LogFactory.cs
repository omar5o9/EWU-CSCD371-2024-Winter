#nullable enable
namespace Logger;


public class LogFactory
{
    private readonly string? _logPath;

  

    public BaseLogger? CreateLogger(string className)
    {
        if (_logPath == null)
        {
            return null;
        }
        else
        {
            BaseLogger logg = new FileLogger(_logPath)
            {
                ClassName = className,
               
                
            };
            return logg;
        }
    }


    
}
