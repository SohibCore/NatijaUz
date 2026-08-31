namespace NatijaUz.Application.Auth.Services.RegisterService.Interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(string to, string subject, string body);
    }
}
