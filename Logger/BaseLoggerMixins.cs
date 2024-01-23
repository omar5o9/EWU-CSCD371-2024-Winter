#nullable enable
using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? logger, string message, params object[] yo)
    {
        LogDo(logger, LogLevel.Error, message, yo);
    }

    public static void Warning(this BaseLogger? logger, string message, params object[] yo)
    {
        LogDo(logger, LogLevel.Warning, message, yo);
    }

    public static void Information(this BaseLogger? logger, string message, params object[] yo)
    {
        LogDo(logger, LogLevel.Information, message, yo);
    }

    public static void Debug(this BaseLogger? logger, string message, params object[] yo)
    {
        LogDo(logger, LogLevel.Debug, message, yo);
    }

    public static System.Globalization.CultureInfo? CulInfo
    {
        get; set;
    }

    public static void LogDo(this BaseLogger? logger, LogLevel level, string message, params object[] yo)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger can't be null");
        }
        string output = string.Format(CulInfo, message, yo);
        
        logger.Log(level, output);
    }
}
