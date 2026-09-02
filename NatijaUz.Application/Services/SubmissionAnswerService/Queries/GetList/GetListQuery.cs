using MediatR;
using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Queries.GetList
{
    public record GetListQuery(SubmissionAnswerFilterDto filter) : IRequest<List<SubmissionAnswerListDto>>;
}
