using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Assignment.Tests;

public class SampleDataTests
{
    private readonly SampleData SampleData;

    public SampleDataTests()
    {
        SampleData = new SampleData();
    }


    [Fact]
    public void GetAggregateListOfStatesGivenPeopleCollection_EmptyList_ReturnsSuccessful()
    {
        List<IPerson> people = new List<IPerson>();
        string states = SampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
        Assert.Equal("", states);
    }

}

