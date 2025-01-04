using Microsoft.Extensions.Hosting;
using poc.quartz.service.Jobs;
using Quartz;
using Quartz.Impl;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // Config the Quartz
        services.AddQuartz(options =>
        {
            options.UseMicrosoftDependencyInjectionJobFactory();            
        });

        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true; // wait for the job complete
        });
    });

var app = builder.Build();

// Create the Scheduler
var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
await scheduler.Start();

// Define the Job and the Trigger
var job = JobBuilder.Create<MyQuartzJob>()
    .WithIdentity("MyJob", "Group1")
    .Build();

var trigger = TriggerBuilder.Create()
    .WithIdentity("MyTrigger", "Group1")
    .StartNow()
    .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
    .Build();

// Schedule the Job
await scheduler.ScheduleJob(job, trigger);

await app.RunAsync();