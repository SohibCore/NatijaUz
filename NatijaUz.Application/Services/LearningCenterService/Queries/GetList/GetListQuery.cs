using MediatR;
using NatijaUz.Application.Services.LearningCenterService.Dtos;

namespace NatijaUz.Application.Services.LearningCenterService.Queries.GetList
{
    public record GetListQuery(LearningCenterFilterDto filter) : IRequest<List<LearningCenterListDto>>;
}
