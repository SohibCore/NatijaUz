using MediatR;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Application.Auth.Services.RegisterService.Commands.Dtos;

namespace NatijaUz.Application.Auth.Services.RegisterService.Commands.Register
{
    public record RegisterCommand(CreateUserDto dto, string pinfl) : IRequest<RegisterDto>;
}
