using MediatR;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Services.UserService.Queries.GetById
{
    public record GetByIdCommand(long Id) : IRequest<UserDto>;
}
