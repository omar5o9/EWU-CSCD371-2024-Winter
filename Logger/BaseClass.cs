namespace Logger;

public abstract class BaseClass : IEntity
{

    public abstract Guid Id { get; init; }

    public abstract string Name { set; get; }

}

