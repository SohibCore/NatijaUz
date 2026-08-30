using NatijaUz.Domain.Enums;

namespace NatijaUz.Application.Services.UserService.Dtos.Update
{
    public class UpdateSysAdminDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? UserName { get; set; } = null!;
        public string? FullName { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string? PasswordHash { get; set; } = null!;
        public UserRole? Role { get; set; }
        public long? LearningCenterId { get; set; }
    }
}
