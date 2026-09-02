using MediatR;
using NatijaUz.Application.Services.SubmissionService.Dtos;

namespace NatijaUz.Application.Services.SubmissionService.Commands.Create
{
    public record CreateSubmissionCommand(CreateSubmissionDto dto) : IRequest<SubmissionDto>;
}
