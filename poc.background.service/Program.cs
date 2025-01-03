using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using poc.background.service.Jobs;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<MyBackgroundServiceJob>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();



using var host = builder.Build();
await host.RunAsync();