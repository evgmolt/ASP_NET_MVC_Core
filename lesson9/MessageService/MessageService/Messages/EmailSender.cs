using MessageService.Models;
using System.Net.Mail;

namespace MessageService.Messages
{
    public class EMailSender : IMessageSender
    {
		public Task SendAsync(string message, string subject, User user)
		{
			
			var from = "evg.molt@gmail.com";
			var pass = "furiakrucha467";
			SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.UseDefaultCredentials = false;
			client.Credentials = new System.Net.NetworkCredential(from, pass);
			client.EnableSsl = true;
			var mail = new MailMessage(from, user.EMail);
			mail.Subject = subject;
			mail.Body = message;
			mail.IsBodyHtml = true;
			return client.SendMailAsync(mail);
		}
	}
}
