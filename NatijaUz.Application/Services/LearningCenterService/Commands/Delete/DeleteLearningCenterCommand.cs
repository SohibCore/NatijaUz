using MediatR;

namespace NatijaUz.Application.Services.LearningCenterService.Commands.Delete
{
    public record DeleteLearningCenterCommand(long Id) : IRequest<bool>;
}
