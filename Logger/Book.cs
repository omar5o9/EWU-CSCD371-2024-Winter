﻿
namespace Logger;

public record Book : BaseClass
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int YearPublished { get; set; }

    // Calculated property for the full name of the book (Title + Author)
    public string FullName => $"{Title} by {Author}";

    public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    // The calculated property makes sense here as the full name is a combination of Title and Author.
}
