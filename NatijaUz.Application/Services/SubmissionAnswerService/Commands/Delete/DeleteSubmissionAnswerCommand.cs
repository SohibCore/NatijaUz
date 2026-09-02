using MediatR;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Commands.Delete
{
    public record DeleteSubmissionAnswerCommand(long Id) : IRequest<bool>;
}
