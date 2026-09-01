using MediatR;
using NatijaUz.Application.Services.LearningCenterService.Dtos;

namespace NatijaUz.Application.Services.LearningCenterService.Commands.Create
{
    public record CreateLearningCenterCommand(CreateLearningCenterDto dto) : IRequest<LearningCenterDto>;
}
