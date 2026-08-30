using MediatR;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Application.Services.UserService.Dtos.Create;

namespace NatijaUz.Application.Services.UserService.Commands.Create.SysAdmin
{
    public record CreateSysAdminCommand(CreateSysAdminDlDto dto) : IRequest<UserDto>;
}
