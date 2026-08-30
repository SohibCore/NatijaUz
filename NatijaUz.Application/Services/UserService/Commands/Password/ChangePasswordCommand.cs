using MediatR;

namespace NatijaUz.Application.Services.UserService.Commands.Password
{
    public record ChangePasswordCommand : IRequest<bool>
    {
        public long UserId { get; set; }
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}
