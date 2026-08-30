namespace NatijaUz.Application.Auth.Services
{
    public interface IAccountService
    {
        bool IsAuthenticated { get; }
        long UserId { get; }
        string UserName { get; }
    }
}
