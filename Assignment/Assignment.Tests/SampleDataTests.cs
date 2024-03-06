using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

public class SampleDataTests
{
    
    [Fact]
    public void GetAggregateSortedListOfStatesUsingCsvRows()
    {
        // Arrange
        SampleData sampleData = new();
        string expected = "CA, FL, GA, NY, TX";

        // Act
        string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        // Assert
        Assert.Equal(expected, actual);
    }



   
}

