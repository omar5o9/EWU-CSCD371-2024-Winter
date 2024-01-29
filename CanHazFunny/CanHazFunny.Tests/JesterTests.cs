using Moq;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_WithValidServices_PrintsJoke()
    {
        
        var mockJokeService = new Mock<JokeServiceInterface>();
        var mockPrinter = new Mock<PrintJokeInterface>();

        mockJokeService.Setup(j => j.GetJoke()).Returns("A funny joke");

        var jester = new Jester(mockJokeService.Object, mockPrinter.Object);


        jester.TellJoke();

        
        mockPrinter.Verify(p => p.PrintJokeToScreen("A funny joke"), Times.Once);
    }

    [Fact]
    public void TellJoke_WithChuckNorrisJoke_GetsAnotherJoke()
    {
        
        var mockJokeService = new Mock<JokeServiceInterface>();
        var mockPrinter = new Mock<PrintJokeInterface>();

        mockJokeService.SetupSequence(j => j.GetJoke())
            .Returns("A Chuck Norris joke")
            .Returns("A funny joke");

        var jester = new Jester(mockJokeService.Object, mockPrinter.Object);

        
        jester.TellJoke();

        
        mockPrinter.Verify(p => p.PrintJokeToScreen("A Chuck Norris joke"), Times.Never);
        mockPrinter.Verify(p => p.PrintJokeToScreen("A funny joke"), Times.Once);
    }

    [Fact]
    public void TellJoke_WithNullJokeService_PrintsErrorMessage()
    {
        
        var mockPrinter = new Mock<PrintJokeInterface>();

        var jester = new Jester(null, mockPrinter.Object);

        
        jester.TellJoke();

        
        mockPrinter.Verify(p => p.PrintJokeToScreen(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void TellJoke_WithNullPrinter_PrintsErrorMessage()
    {
        
        var mockJokeService = new Mock<JokeServiceInterface>();

        var jester = new Jester(mockJokeService.Object, null);

        
        jester.TellJoke();

       
    }
}
