

namespace Logger;

public record Student : Person
{
    public int StudentId { get; set; }
    public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    // Inheriting from Person to reuse the common code for FirstName, LastName, and FullName.
}

