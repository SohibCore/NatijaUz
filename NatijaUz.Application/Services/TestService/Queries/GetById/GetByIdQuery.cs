using MediatR;
using NatijaUz.Application.Services.TestService.Dtos;

namespace NatijaUz.Application.Services.TestService.Queries.GetById
{
    public record GetByIdQuery(long Id) : IRequest<TestDto>;
}
