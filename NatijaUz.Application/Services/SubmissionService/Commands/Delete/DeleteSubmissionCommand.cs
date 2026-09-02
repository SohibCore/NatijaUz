using MediatR;

namespace NatijaUz.Application.Services.SubmissionService.Commands.Delete
{
    public record DeleteSubmissionCommand(long Id) : IRequest<bool>;
}
