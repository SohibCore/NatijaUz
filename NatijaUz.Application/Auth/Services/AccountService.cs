using NatijaUz.Domain.Enums;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace NatijaUz.Application.Auth.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextAccessor _accessor;
        public AccountService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public bool IsAuthenticated
                        => _accessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        public long UserId
        {
            get
            {
                var claim = _accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return claim != null ? long.Parse(claim) : 0;
            }
        }
        public string UserName
                        => _accessor.HttpContext?.User?.Identity?.Name ?? string.Empty;

        public UserRole Role
        {
            get
            {
                var claim = _accessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
                return claim != null ? Enum.Parse<UserRole>(claim) : throw new UnauthorizedAccessException("Foydalanuvchi roli topilmadi");
            }
        }

        public long? LearningCenterId
        {
            get
            {
                var claim = _accessor.HttpContext?.User?.FindFirst("LearningCenterId")?.Value;
                return string.IsNullOrEmpty(claim) ? null : long.Parse(claim);
            }
        }
    }
}
