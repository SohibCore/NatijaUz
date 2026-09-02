using MediatR;
using NatijaUz.Application.Services.TestService.Dtos;

namespace NatijaUz.Application.Services.TestService.Commands.Create
{
    public record CreateTestCommand(CreateTestDto dto) : IRequest<TestDto>;
}
