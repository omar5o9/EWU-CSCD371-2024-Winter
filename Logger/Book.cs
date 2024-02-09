
namespace Logger;

public record Book : BaseClass
{
    // Title, Author, and YearPublished are implemented implicitely because they do not
    // derive from BaseClass
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int YearPublished { get; set; }

    public string FullName => $"{Title} by {Author}";

    public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    // Name is explicit because it can cause collision with the BaseClass since it derives from it
}

