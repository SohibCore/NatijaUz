using MediatR;
using NatijaUz.Application.Services.LearningCenterService.Dtos;

namespace NatijaUz.Application.Services.LearningCenterService.Queries.GetById
{
    public record GetByIdQuery(long Id) : IRequest<LearningCenterDto>;
}
