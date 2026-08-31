using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using NatijaUz.Application.Auth.Services.RegisterService.Interfaces;

namespace NatijaUz.Application.Auth.Services.RegisterService.Services
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly EmailSettings _settings;

        public MailKitEmailSender(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_settings.SenderName, _settings.From));
                message.To.Add(MailboxAddress.Parse(to));
                message.Subject = subject;
                message.Body = new TextPart("plain") { Text = body };

                using var client = new SmtpClient();
                await client.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_settings.Username, _settings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                Console.WriteLine("Email yuborildi: " + to);
            }
            catch (Exception ex)
            {
                Console.WriteLine("XATO: " + ex.Message);
                throw;
            }
        }
    }
}
