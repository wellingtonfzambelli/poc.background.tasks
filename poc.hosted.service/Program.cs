using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using poc.hosted.service.Jobs;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<MyHostedJob>();
    })
    .Build();

await host.RunAsync();