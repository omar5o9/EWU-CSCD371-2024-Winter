
namespace Logger;

public record Employee : Person
{
    public int EmployeeId { get; set; }
    public string? Department { get; set; }
    public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    // Inheriting from Person to reuse the common code for FirstName, LastName, and FullName.
}

