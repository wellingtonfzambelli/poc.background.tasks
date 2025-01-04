using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace poc.hosted.service.Jobs;

internal sealed class MyHostedJob : IHostedService
{
    private readonly ILogger<MyHostedJob> _logger;
    private Timer _timer;

    public MyHostedJob(ILogger<MyHostedJob> logger) =>
        _logger = logger;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service started.");

        _timer = new Timer(
            async state => await DoWorkAsync(cancellationToken), 
            null, 
            TimeSpan.Zero, 
            TimeSpan.FromSeconds(5) // execute each 5 seconds
        );

        return Task.CompletedTask;
    }

    private async Task DoWorkAsync(CancellationToken ct)
    {
        _logger.LogInformation($"Task started at {DateTime.Now}");

        try
        {
            await Task.Delay(1000); // Simulating async work
            _logger.LogInformation($"Task concluided at {DateTime.Now}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in executing taks.");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Dispose();
        return Task.CompletedTask;
    }
}