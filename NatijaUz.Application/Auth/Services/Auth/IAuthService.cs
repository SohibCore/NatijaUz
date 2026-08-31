using NatijaUz.Application.Auth.AuthDto;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Auth.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(CreateUserDto dto, CancellationToken cancellationToken);
        Task<AuthResult> LoginAsync(LoginDto dto, CancellationToken cancellationToken);
        Task<AuthResult> VerifyEmailAsync(VerifyEmailCommand command);
    }
}
