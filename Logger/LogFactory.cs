namespace Logger;
#nullable enable

public class LogFactory
{
    public string? logPath;
    

    public BaseLogger? CreateLogger(string className)
    {
        if (logPath == null)
        {
            return null;
        }
        else
        {
            BaseLogger logg = new FileLogger(logPath)
            {
                ClassName = className
                
            };
            return logg;
        }
    }


    
}
