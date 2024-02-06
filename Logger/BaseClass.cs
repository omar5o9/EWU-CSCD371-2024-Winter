namespace Logger;

public abstract record BaseClass : IEntity
{

    public Guid Id { get; init; }

    public abstract string Name { set; get; }

}

