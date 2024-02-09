
namespace Logger;

public record Employee : Person
{

    // EmployeeId and Department are implemented implicitely because they do not
    // derive from BaseClass
    public int EmployeeId { get; set; }
    public string? Department { get; set; }
    public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    // Name is explicit because it derives from Person which derives from BaseClass
}

