#nullable enable
using System;

using System.IO;


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{

    [TestMethod]
    public void Log_WritesToLogFile()
    {
        // Arrange
        string filePath = "test.log";
        FileLogger fileLogger = new(filePath);

        // Act
        fileLogger.Log(LogLevel.Information, "Test message");

        // Assert
        string fileContent = File.ReadAllText(filePath);
        Assert.IsTrue(fileContent.Contains("Test message"), "Log entry not found in the file.");

        // Cleanup
        File.Delete(filePath);
    }
}

