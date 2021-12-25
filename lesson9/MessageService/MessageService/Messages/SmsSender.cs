using MessageService.Models;

namespace MessageService.Messages
{
    public class SmsSender : IMessageSender
    {
        public Task SendAsync(string message, string subject, User user)
        {
            throw new NotImplementedException();
        }
    }
}
