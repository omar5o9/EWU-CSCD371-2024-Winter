#nullable enable
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    // Test are WIP for now
    [TestMethod]
    public void CreateLogger_WithNonNullLogPath_ReturnsNonNullLogger()
    {
        // Arrange
        LogFactory logFactory = new();
        string validLogPath = "test.log";

        // Act
     
        string result = logFactory.configure(validLogPath);
        // Assert
        
        Assert.AreEqual(validLogPath, result);
    }

    [TestMethod]
    public void CreateLogger_WithNullLogPath_ReturnsNullLogger()
    {
        // Arrange
        LogFactory logFactory = new();
        string invalidLogPath = null;

        // Act

        logFactory.CreateLogger(null!);
        
    }
}
