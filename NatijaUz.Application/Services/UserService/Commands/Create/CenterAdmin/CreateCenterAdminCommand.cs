using MediatR;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Application.Services.UserService.Dtos.Create;

namespace NatijaUz.Application.Services.UserService.Commands.Create.CenterAdmin
{
    public record CreateCenterAdminCommand(CreateCenterAdminDlDto dto) : IRequest<UserDto>;
}
