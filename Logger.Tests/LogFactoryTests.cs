#nullable enable
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{

    [TestMethod]
    public void CreateLogger_WithNonNullLogPath_ReturnsNonNullLogger()
    {
        // Arrange
        LogFactory logFactory = new LogFactory();
        logFactory.logPath = "test.log";

        // Act
        BaseLogger? logger = logFactory.CreateLogger("TestClass");

        // Assert
        Assert.IsNotNull(logger, "Logger should not be null when logPath is not null.");
    }

    [TestMethod]
    public void CreateLogger_WithNullLogPath_ReturnsNullLogger()
    {
        // Arrange
        LogFactory logFactory = new LogFactory();
        logFactory.logPath = null;

        // Act
        BaseLogger? logger = logFactory.CreateLogger("TestClass");

        // Assert
        Assert.IsNull(logger, "Logger should be null when logPath is null.");
    }
}
