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
        List<IPerson> people = new();
        string states = SampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
        Assert.Equal("", states);
    }

}

