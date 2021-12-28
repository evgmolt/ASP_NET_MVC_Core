using MessageService.Models;

namespace MessageService.Messages
{
    public class SmsSender : IMessageSender
    {
        public Task SendAsync(IConfiguration config, string message, string subject, List<User> user)
        {
            throw new NotImplementedException();
        }
    }
}
