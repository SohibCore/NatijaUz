using MediatR;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Application.Auth.Services.RegisterService.Dtos;

namespace NatijaUz.Application.Auth.Services.RegisterService.Commands
{
    public record RegisterCommand(RegisterDto dto) : IRequest<RegisterDto>;
}
