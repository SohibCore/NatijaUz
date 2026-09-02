using MediatR;
using NatijaUz.Application.Services.TestService.Dtos;

namespace NatijaUz.Application.Services.TestService.Commands.Update
{
    public record UpdateTestCommand(UpdateTestDto dto) : IRequest<TestDto>;
}
