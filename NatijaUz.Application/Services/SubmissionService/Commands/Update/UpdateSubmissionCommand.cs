using MediatR;
using NatijaUz.Application.Services.SubmissionService.Dtos;

namespace NatijaUz.Application.Services.SubmissionService.Commands.Update
{
    public record UpdateSubmissionCommand(UpdateSubmissionDto dto) : IRequest<SubmissionDto>;
}
