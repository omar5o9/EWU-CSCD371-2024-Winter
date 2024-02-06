
namespace Logger;

public abstract record Person : BaseClass
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    // Calculated property for the full name of the person
    public string FullName => $"{FirstName} {LastName}";

    // Calculated property for FullName is appropriate as it combines the FirstName and LastName.
}

