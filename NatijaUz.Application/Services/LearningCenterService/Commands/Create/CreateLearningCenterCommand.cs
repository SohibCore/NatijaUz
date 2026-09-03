using MediatR;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Application.Services.LearningCenterService.Dtos;

namespace NatijaUz.Application.Services.LearningCenterService.Commands.Create
{
    public record CreateLearningCenterCommand(CreateLearningCenterDto centerDto, CreateUserDto userDto) : IRequest<LearningCenterDto>;
}
