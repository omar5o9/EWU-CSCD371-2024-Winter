#nullable enable
namespace Logger;

public class LogFactory
{
    public string yo;
    public LogFactory(string className)
    {
       this.yo = className;
    }

    public BaseLogger CreateLogger(string className)
    {

        return null;
    }
}
