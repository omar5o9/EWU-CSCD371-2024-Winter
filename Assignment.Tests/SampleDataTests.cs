using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Assignment.Tests;

public class SampleDataTests
{
    private readonly SampleData _sampleData;

    public SampleDataTests()
    {
        _sampleData = new SampleData();
    }

    [Fact]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsUniqueSortedStates()
    {
        // Arrange
        List<string> expectedStates = new() { "California", "Florida", "New York", "Texas" };

        // Act
        IEnumerable<string> actualStates = _sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        Assert.Equal(expectedStates, actualStates);
    }

}

