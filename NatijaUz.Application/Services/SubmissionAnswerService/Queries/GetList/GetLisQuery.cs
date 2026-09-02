using MediatR;
using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Queries.GetList
{
    public record GetLisQuery(SubmissionAnswerFilterDto filter) : IRequest<List<SubmissionAnswerListDto>>;
}
