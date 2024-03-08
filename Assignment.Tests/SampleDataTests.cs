using System.Linq;

namespace Assignment.Tests;

public class SampleDataTests
{
    

    [Fact]
    public void GetUniqueSortedListOfStatesUsingCsvRows_ReturnsSuccessful()
    {
        SampleData sampleData = new();
        List<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        Assert.Equal("AL", states[0]);

    }

    [Fact]
    public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsSuccessful()
    {
        SampleData sampleData = new();
        string states = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
        Assert.Equal("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", states);
        
    }

    [Fact]
    public void CsvRows_ReturnsSuccessful()
    {
        SampleData sampleData = new();
        IEnumerable<string> rows = sampleData.CsvRows;
        Assert.Equal(50, rows.Count());
    }

    [Fact]
    public void FilterByEmailAddress_ReturnsSuccessful()
    {
        SampleData sampleData = new();
        List<(string FirstName, string LastName)> people = sampleData.FilterByEmailAddress(filter => filter == "pjenyns0@state.gov").ToList();
        Assert.Single(people);
    }

    [Fact]
    public void People_ReturnsSuccessful()
    {
        SampleData sampleData = new();
        IEnumerable<IPerson> people = sampleData.People;
        Assert.Equal(50, people.Count());
    }

    

    




}

