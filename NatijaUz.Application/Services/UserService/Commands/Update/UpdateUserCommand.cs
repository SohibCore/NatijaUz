using MediatR;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Services.UserService.Commands.Update
{
    public record UpdateUserCommand(UpdateUserDto dto) : IRequest<UserDto>;
}
