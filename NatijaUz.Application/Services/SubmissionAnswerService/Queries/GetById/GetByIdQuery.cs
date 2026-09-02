using MediatR;
using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Queries.GetById
{
    public record GetByIdQuery(long Id) : IRequest<SubmissionAnswerDto>;
}
