using NatijaUz.Application.Auth.AuthDto;
using NatijaUz.Application.Auth.Services.RegisterService.Dtos;
using NatijaUz.Application.Auth.Services.VerifyEmail.Commands;

namespace NatijaUz.Application.Auth.AuthService
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken);
        Task<AuthResult> LoginAsync(LoginDto dto, CancellationToken cancellationToken);
        Task<AuthResult> VerifyEmailAsync(VerifyEmailCommand command);
    }
}
