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
        string result = logFactory.configure(validPath);

        // Assert
        Assert.AreEqual(validPath, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateLogger_WithNullLogPath_ReturnsNullLogger()
    {
        
        // Arrange
        LogFactory logFactory = new();

        // Act
        logFactory.configure(null);  
        

    }
  
}
