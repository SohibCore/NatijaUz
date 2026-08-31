namespace NatijaUz.Application.Auth.Services.VerifyEmail.Interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(string to, string subject, string body);
    }
}
