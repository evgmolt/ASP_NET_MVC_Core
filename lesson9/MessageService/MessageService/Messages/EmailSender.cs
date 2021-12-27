using MessageService.Models;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Mail;

namespace MessageService.Messages
{
    public class EmailSender : IMessageSender
    {
        public async Task SendAsync(IConfiguration config, string message, string subject, List<User> users)
        {
            string myEmail = config.GetValue<string>("Email");
            Console.WriteLine(myEmail);
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(config.GetValue<string>("Name"), myEmail));

            foreach (User user in users)
            {
                emailMessage.To.Add(new MailboxAddress("", user.EMail));
            }
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync(config.GetValue<string>("Smtp"), 
                                          Int32.Parse(config.GetValue<string>("Port")),
                                          false);
                await client.AuthenticateAsync(myEmail, config.GetValue<string>("Password"));
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }

}

