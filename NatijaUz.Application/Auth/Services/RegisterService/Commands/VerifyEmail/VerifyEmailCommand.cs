using MediatR;
using NatijaUz.Application.Auth.AuthDto;

namespace NatijaUz.Application.Auth.Services.RegisterService.Commands.VerifyEmail
{
    public record VerifyEmailCommand(string Email, string Code) : IRequest<AuthResult>;
}
