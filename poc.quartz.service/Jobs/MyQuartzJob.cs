using Quartz;

namespace poc.quartz.service.Jobs;

[DisallowConcurrentExecution] // wait for the job complete
internal sealed class MyQuartzJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("Executing my schedule Quartz...");
    }
}