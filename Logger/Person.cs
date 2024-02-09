
namespace Logger;

public abstract record Person : BaseClass
{
    // FullName, FirstName, LastName, and MiddleName are implicit because they do not derive from BaseClass
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }

    public string FullName => $"{FirstName} {MiddleName?.Trim()} {LastName}";
}

