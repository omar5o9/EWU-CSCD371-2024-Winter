#nullable enable
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void Configure_ValidPath_SetsLogPath()
    {
        // Arrange
        LogFactory logFactory = new();
        string validPath = "LogFile.txt";

        // Act
        string result = logFactory.ConfigureFileLogger(validPath);

        // Assert
        Assert.AreEqual(validPath, result);
    }

    [TestMethod]
    
    public void CreateLogger_WithNullLogPath_ReturnsNullLogger()
    {
        
        // Arrange
        LogFactory logFactory = new();

        // Act
        Assert.ThrowsException<ArgumentNullException>(() => logFactory.ConfigureFileLogger(null!));
         


    }
  
}
