using MediatR;
using NatijaUz.Application.Services.SubmissionService.Dtos;

namespace NatijaUz.Application.Services.SubmissionService.Queries.GetList
{
    public record GetListQuery(SubmissionFilterDto filter) : IRequest<List<SubmissionListDto>>;
}
