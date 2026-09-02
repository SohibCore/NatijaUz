using MediatR;
using NatijaUz.Application.Services.TestService.Dtos;

namespace NatijaUz.Application.Services.TestService.Queries.GetList
{
    public record GetListQuery(TestFilterDto filter) : IRequest<List<TestListDto>>;
}
