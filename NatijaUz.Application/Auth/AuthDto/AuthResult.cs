using NatijaUz.Domain.Enums;
using System.Security.Claims;

namespace NatijaUz.Application.Auth.AuthDto
{
    public class AuthResult
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = null!;
        public UserRole Role { get; set; }
        public long LearningCenterId { get; set; }
        public ClaimsPrincipal ClaimsPrincipal { get; set; } = null!;
    }
}
