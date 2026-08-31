namespace NatijaUz.Application.Auth.Services.VerifyEmail.Services
{
    public class EmailSettings
    {
        public string Host { get; set; } = default!;
        public int Port { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string From { get; set; } = default!;
        public string SenderName { get; set; } = default!;
    }
}
