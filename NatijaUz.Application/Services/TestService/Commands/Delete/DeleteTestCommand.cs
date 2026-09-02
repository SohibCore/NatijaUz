using MediatR;

namespace NatijaUz.Application.Services.TestService.Commands.Delete
{
    public record DeleteTestCommand(long Id) : IRequest<bool>;
}
