using MediatR;
using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Commands.Update
{
    public record UpdateSubmissionAnswerCommand(UpdateSubmissionAnswerDto dto) : IRequest<SubmissionAnswerDto>;
}
