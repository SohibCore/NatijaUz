using MediatR;
using NatijaUz.Application.Auth.AuthDto;

namespace NatijaUz.Application.Auth.Services.VerifyEmail.Commands
{
    public record VerifyEmailCommand(string Email, string Code) : IRequest<AuthResult>;
}
