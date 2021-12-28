using MessageService.Models;

namespace MessageService.Messages
{
    public interface IMessageSender
    {
        Task SendAsync(IConfiguration config, string message, string subject, List<User> users);
    }
}
