using MediatR;

namespace NatijaUz.Application.Services.UserService.Commands.Password
{
    public record ChangePasswordCommand(PasswordDto dto) : IRequest<bool>;
    public class PasswordDto
    {
        public long UserId { get; set; }
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}
