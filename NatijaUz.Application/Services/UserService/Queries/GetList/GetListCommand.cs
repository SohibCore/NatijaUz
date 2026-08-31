using MediatR;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Services.UserService.Queries.GetList
{
    public record GetListCommand(UserFilterDto filter) : IRequest<List<UserListDto>>;
}
