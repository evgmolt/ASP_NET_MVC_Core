using MessageService.Models;

namespace MessageService.Messages
{
    public interface IGate
    {
        public Task SendMessage(string message, string subject, List<User> users);

    }
}
