using Moq;
using Xunit;
using System;


namespace CanHazFunny.Tests;

public class JokeServiceTests
{

    [Fact]
    public void JokeServiceCreated_IsNotNull()
    {
        JokeService service = new();
        Assert.NotNull(service);
    }

}

