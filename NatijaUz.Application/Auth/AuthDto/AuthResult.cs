using System.Security.Claims;

namespace NatijaUz.Application.Auth.AuthDto
{
    public class AuthResult
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = null!;
        public ClaimsPrincipal ClaimsPrincipal { get; set; } = null!;
    }
}
