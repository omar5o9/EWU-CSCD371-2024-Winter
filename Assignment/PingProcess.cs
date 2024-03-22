using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput, string? StdError);

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress, IProgress<string?>? progress = null)
    {

        string pingArg = Environment.OSVersion.Platform is PlatformID.Unix ? "-c" : "-n";

        StartInfo.Arguments = $"{pingArg} 4 {hostNameOrAddress}";
        StringBuilder? stdOutput = null;
        StringBuilder? stdError = null;
        void updateStdOutput(string? line)
        {
            (stdOutput ??= new StringBuilder()).AppendLine(line);
            if (progress is not null) progress?.Report(line);
        }
        void updateStdError(string? line) =>
            (stdError ??= new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, updateStdError, default);
        return new PingResult(process.ExitCode, stdOutput?.ToString(), stdError?.ToString());

    }

    // Task 1]
    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return Task.Run(() => Run(hostNameOrAddress));

    }

    // Tasks 2 & 3]
    async public Task<PingResult> RunAsync(
    string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            PingResult result = await Task.Run(() => Run(hostNameOrAddress), cancellationToken);
            return result;
        }
        catch (OperationCanceledException)
        {
            throw new AggregateException(new TaskCanceledException());
        }

    }

    // Task 4]
    async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    {
        int count = 0;
        StringBuilder stringBuilder = new StringBuilder();
        var semaphore = new SemaphoreSlim(1);

        var tasks = hostNameOrAddresses.Select(async item =>
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                PingResult result = await RunAsync(item, cancellationToken);
                if (result.StdOutput != null)
                {
                    await semaphore.WaitAsync(cancellationToken);
                    try
                    {
                        count = 1;
                        stringBuilder.AppendLine(result.StdOutput.Trim());
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }
            }
            catch (Exception ex)
            {
                await semaphore.WaitAsync(cancellationToken);
                try
                {
                    stringBuilder.AppendLine("Error pinging " + item + ": " + ex.Message + ", "); ;
                }
                finally
                {
                    semaphore.Release();
                }
            }
        });

        await Task.WhenAll(tasks);
        return new PingResult(count, stringBuilder.ToString(), null);

    }

    // Task 5]
    public Task<int> RunLongRunningAsync(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            var process = new Process
            {
                StartInfo = UpdateProcessStartInfo(startInfo)
            };
            RunProcessInternal(process, progressOutput, progressError, cancellationToken);
            return process.ExitCode;
        }, cancellationToken);

    }

    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        var process = new Process
        {
            StartInfo = UpdateProcessStartInfo(startInfo)
        };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorHandler;

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(obj =>
            {
                if (obj is Process p && !p.HasExited)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Win32Exception ex)
                    {
                        throw new InvalidOperationException($"Error cancelling process{Environment.NewLine}{ex}");
                    }
                }
            }, process);


            if (process.StartInfo.RedirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }
            if (process.StartInfo.RedirectStandardError)
            {
                process.BeginErrorReadLine();
            }

            if (process.HasExited)
            {
                return process;
            }
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'{Environment.NewLine}{e}");
        }
        finally
        {
            if (process.StartInfo.RedirectStandardError)
            {
                process.CancelErrorRead();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                process.CancelOutputRead();
            }
            process.OutputDataReceived -= OutputHandler;
            process.ErrorDataReceived -= ErrorHandler;

            if (!process.HasExited)
            {
                process.Kill();
            }

        }
        return process;

        void OutputHandler(object s, DataReceivedEventArgs e)
        {
            progressOutput?.Invoke(e.Data);
        }

        void ErrorHandler(object s, DataReceivedEventArgs e)
        {
            progressError?.Invoke(e.Data);
        }
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        return startInfo;
    }
}