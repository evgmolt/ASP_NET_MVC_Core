using MessageService.Models;

namespace MessageService.Messages
{
    public interface IMessageSender
    {
        Task SendAsync(string message, string subject, User user);
    }
}
