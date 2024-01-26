
using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? logger, string message, params object[] args)
    {
        LogDo(logger, LogLevel.Error, message, args);
    }

    public static void Warning(this BaseLogger? logger, string message, params object[] args)
    {
        LogDo(logger, LogLevel.Warning, message, args);
    }

    public static void Information(this BaseLogger? logger, string message, params object[] args)
    {
        LogDo(logger, LogLevel.Information, message, args);
    }

    public static void Debug(this BaseLogger? logger, string message, params object[] args)
    {
        LogDo(logger, LogLevel.Debug, message, args);
    }

    public static System.Globalization.CultureInfo? CulInfo
    {
        get; set;
    }

    public static void LogDo(this BaseLogger? logger, LogLevel level, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger can't be null");
        }
        string output = string.Format(CulInfo, message, args);
        
        logger.Log(level, output);
    }
}
