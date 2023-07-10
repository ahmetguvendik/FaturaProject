using Fatura.Application.Services;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Fatura.Persistance.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string emailAdress, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["EmailConfiguration:From"]));
            email.To.Add(MailboxAddress.Parse(emailAdress));
            email.Subject = "Reset Password";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["EmailConfiguration:SmtpServer"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["EmailConfiguration:From"], _configuration["EmailConfiguration:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);  
        }
    }
}

