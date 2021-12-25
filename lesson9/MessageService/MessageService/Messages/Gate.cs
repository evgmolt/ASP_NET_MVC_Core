using MessageService.Models;
using Quartz;

namespace MessageService.Messages
{
    public class Gate : IGate
    {
        private List<IMessageSender> _senderList = new List<IMessageSender>();
        public void RegisterSender(IMessageSender newSender)
        {
            _senderList.Add(newSender);
        }

        public Gate()
        {
            RegisterSender(new EMailSender());
        }
        public async Task SendMessage(string message, string subject, List<User> users)
        {
            foreach(IMessageSender sender in _senderList)
            {
                foreach(User user in users)
                {
                    await sender.SendAsync(message, subject, user);
                }
            }
        }
    }
}
