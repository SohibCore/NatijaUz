using MediatR;
using NatijaUz.Application.Services.SubmissionService.Dtos;

namespace NatijaUz.Application.Services.SubmissionService.Queries.GetById
{
    public record GetByIdQuery(long Id) : IRequest<SubmissionDto>;
}
