using MediatR;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Application.Services.UserService.Dtos.Create;

namespace NatijaUz.Application.Services.UserService.Commands.Create.Student
{
    public record CreateUserCommand(CreateUserDlDto dto) : IRequest<UserDto>;
}
