using IntelliTect.TestTools;
using System.Diagnostics;
using System.Text;


namespace Assignment.Tests;

[TestClass]
public class PingProcessTests
{
    PingProcess Sut { get; set; } = new();

    [TestInitialize]
    public void TestInitialize()
    {
        Sut = new();

    }

    
    [TestMethod]
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", "-c 4 localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);

    }

    // baaad test
    /*[TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("google.com").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }
    */

    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput, string? stdError) = Sut.Run("badaddress");
        // Check if stdError is not empty
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdError));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdError!.Trim());
        Assert.AreEqual<string?>(
            "ping: badaddress: Temporary failure in name resolution".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");

        Assert.AreEqual<int>(2, exitCode);

    }

    /*
    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult result = Sut.Run("-c 4 localhost");
        AssertValidPingOutput(result);

    } */

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        var pingProcess = new PingProcess();
        var resultTask = pingProcess.RunTaskAsync("-c 4 localhost");
        resultTask.Wait(); 
        var result = resultTask.Result;

        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.ExitCode); 
        Assert.IsNotNull(result.StdOutput);

    }

    /*
    //1
    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
        // PingResult result = default;
        // Test Sut.RunAsync("localhost");
        Task<PingResult> actual = Sut.RunAsync("-c 4 localhost");
        AssertValidPingOutput(actual.Result);

    }*/

    //2
    /*[TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.
        // PingResult result = default;
        // Test Sut.RunAsync("localhost");
        PingResult actual = await Sut.RunAsync("-c 4 localhost");
        AssertValidPingOutput(actual);

    }*/
     

    //3
    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        Sut.RunAsync("-c 4 localhost", cancellationTokenSource.Token).Wait();

    }

    //3
    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        try
        {
            Sut.RunAsync("-c 4 localhost", cancellationTokenSource.Token).Wait();
        }
        catch (AggregateException aggregateException)
        {
            Exception? innerException = aggregateException.Flatten().InnerException;
            throw innerException!;
        }

    }

    /*
    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        // Pseudo Code - don't trust it!!!
        string[] hostNames = ["localhost", "localhost", "localhost", "localhost"];
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length*hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);

    } */


    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        var startInfo = new ProcessStartInfo("ping", "-c 4 localhost");
        int exitCode = await Sut.RunLongRunningAsync(startInfo, null, null, default);
        Assert.AreEqual(0, exitCode);

    }


    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        try
        {
            IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
            StringBuilder stringBuilder = new();
            numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
            int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
            Assert.AreNotEqual(lineCount, numbers.Count() + 1);

        }
        catch (AggregateException)
        {
            // Handle AggregateException if needed
        }
    }


    readonly string PingOutputLikeExpression = @"
PING * 56 data bytes
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
--- * ping statistics ---
* packets transmitted, * received, *% packet loss, time *ms
rtt min/avg/max/mdev = */*/*/* ms
".Trim();
    private void AssertValidPingOutput(int exitCode, string? stdOutput)
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression) ?? false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    /*private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput); */

}