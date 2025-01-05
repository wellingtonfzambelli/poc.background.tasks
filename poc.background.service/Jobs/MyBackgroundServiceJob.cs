using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace poc.background.service.Jobs;

internal sealed class MyBackgroundServiceJob : BackgroundService
{
    private readonly ILogger<MyBackgroundServiceJob> _logger;

    public MyBackgroundServiceJob(ILogger<MyBackgroundServiceJob> logger) =>
        _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Service started in background.");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation($"Task started at {DateTime.Now}");
            
            await Task.Delay(5000, stoppingToken); // Simulating some work
        }

        _logger.LogInformation("Background service was cancelled.");
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Application has finished");
        return Task.CompletedTask;
    }
}