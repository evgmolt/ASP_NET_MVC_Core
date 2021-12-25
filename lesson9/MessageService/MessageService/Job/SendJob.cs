using Quartz;

namespace MessageService.Job
{
    public class SendJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Quartz");
            return Task.CompletedTask;
        }
    }
}
