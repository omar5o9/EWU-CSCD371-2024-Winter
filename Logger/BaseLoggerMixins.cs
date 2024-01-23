#nullable enable
using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? logger, string message, params string[] yo)
    {
        LogDo(logger, LogLevel.Error, message, yo);
    }

    public static void LogDo(BaseLogger? logger, LogLevel level, string message, params string[] yo)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger can't be null");
        }
        string output = message;
        foreach (string i in yo)
        {
            output += $" {i}";
        }
        logger.Log(level, output);
    }
}
