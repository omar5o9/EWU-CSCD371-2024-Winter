namespace Logger;

public record FullName
{

    // We decided to handle the full name storage this way to handle middle names being in the name or not
    // We are allowing the name to be mutable because names can be changed
    public string fullName;

    public FullName(string fName, string mName, string lName)
    {

        fullName = $"{fName} {mName?.Trim()} {lName}";

    }
}
