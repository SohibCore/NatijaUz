using MediatR;

namespace NatijaUz.Application.Services.UserService.Commands.Delete
{
    public record DeleteUserCommand(long UserId, long LearningCenterId) : IRequest<bool>;
}
