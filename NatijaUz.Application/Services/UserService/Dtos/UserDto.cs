using NatijaUz.Domain.Enums;

namespace NatijaUz.Application.Services.UserService.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public UserRole Role { get; set; }
        public long? LearningCenterId { get; set; }
    }
}
