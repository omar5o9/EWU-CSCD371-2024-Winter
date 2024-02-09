

namespace Logger;

public record Student : Person
{
    // StudentId is implement implicitely because it does not derive from BaseClass
    public int StudentId { get; set; }
    public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    // Name is explicit because it derives from Person which derives from BaseClass
}

