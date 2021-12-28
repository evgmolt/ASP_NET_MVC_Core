using MessageService.Controllers;
using MessageService.Data;
using MessageService.Messages;
using Quartz;

namespace MessageService.Job
{
    public class SendJob : IJob
    {
        private readonly IGate _gate;
        private readonly IConfiguration _config;
        private readonly IServiceScopeFactory _scopeFactory;

        public SendJob(IConfiguration config, IGate gate, IServiceScopeFactory scopeFactory)
        {
            _gate = gate;
            _config = config;
            _scopeFactory = scopeFactory;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<MessageServiceContext>();
            var users = db.User.ToList();
            await _gate.SendMessage(_config.GetValue<string>("Message"), _config.GetValue<string>("Subject"), users);
        }
    }
}
