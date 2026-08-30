using MediatR;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Services.UserService.Commands.Create
{
    public record CreateUserCommand(CreateUserDto dto) : IRequest<UserDto>;
}
