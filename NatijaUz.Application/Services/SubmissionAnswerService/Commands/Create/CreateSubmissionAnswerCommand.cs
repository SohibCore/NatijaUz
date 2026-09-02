using MediatR;
using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Commands.Create
{
    public record CreateSubmissionAnswerCommand(CreateSubmissionAnswerDto dto) : IRequest<SubmissionAnswerDto>;
}
