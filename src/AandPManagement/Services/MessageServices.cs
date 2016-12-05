using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; }
        
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            var myMessage = new SendGrid.SendGridMessage();
            myMessage.AddTo(email);
            myMessage.From = new System.Net.Mail.MailAddress("wgwilt84@gmail.com", "Will Gwilt");
            myMessage.Subject = subject;
            myMessage.Text = message;
            myMessage.Html = message;
            var credentials = new System.Net.NetworkCredential(
                "azure_53a2a3c56b73cbf98d21c9ddd359e52b@azure.com",
                "chocolate545");
            // Create a Web transport for sending email.
            var transportWeb = new SendGrid.Web(credentials);
            return transportWeb.DeliverAsync(myMessage);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
