using NatijaUz.Domain.Enums;

namespace NatijaUz.Application.Auth.AccountService
{
    public interface IAccountService
    {
        bool IsAuthenticated { get; }
        long UserId { get; }
        string UserName { get; }
        UserRole Role { get; }
        long? LearningCenterId { get; }
    }
}
