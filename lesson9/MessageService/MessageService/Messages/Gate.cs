using MessageService.Models;
using Quartz;

namespace MessageService.Messages
{
    public class Gate : IGate
    {
        private List<IMessageSender> _senderList = new();
        private readonly IConfiguration _config;
        public void RegisterSender(IMessageSender newSender)
        {
            _senderList.Add(newSender);
        }

        public Gate(IConfiguration config)
        {
            RegisterSender(new EmailSender());
            _config = config;
        }
        public async Task SendMessage(string message, string subject, List<User> users)
        {
            foreach(IMessageSender sender in _senderList)
            {
                await sender.SendAsync(_config, message, subject, users);
            }
        }
    }
}
